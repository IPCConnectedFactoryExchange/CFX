using System;
using System.Threading;
using CFX;
using CFX.Transport;

namespace CFX.IntegrationTests.RabbitMqRoundTrip
{
    /// <summary>
    /// Integration test runner: connects to a RabbitMQ broker via the CFX SDK, publishes a
    /// CFX message, and synchronously verifies that the same message is received back through a
    /// subscription on the bound queue. Exits 0 on success, 1 on failure (timeout / connection error).
    ///
    /// Mirrors the publish-and-verify pattern in CFXUnitTests/BrokerTests.cs (FireAndWait), but is a
    /// net8.0 console app so it runs in a Linux container, and is configured entirely from
    /// environment variables so Docker Compose / CI can point it at the broker.
    /// </summary>
    internal static class Program
    {
        private static AutoResetEvent _received;
        private static CFXEnvelope _sent;

        private static int Main()
        {
            string host = Env("BROKER_HOST", "broker");
            int port = int.Parse(Env("BROKER_PORT", "5672"));
            string user = Env("BROKER_USER", "cfxtest");
            string pass = Env("BROKER_PASS", "cfxtest");
            string exchange = Env("CFX_EXCHANGE", "/exchange/CFXTestExchange");
            string queue = Env("CFX_QUEUE", "/queue/CFXTestQueue");
            int timeoutMs = int.Parse(Env("CFX_TIMEOUT_MS", "30000"));

            // virtualHostName is null => default vhost "/". (BrokerTests uses "vhost:NAME" only for alt hosts.)
            string virtualHost = Environment.GetEnvironmentVariable("CFX_VHOST");
            if (string.IsNullOrWhiteSpace(virtualHost)) virtualHost = null;

            Uri uri = new UriBuilder("amqp", host, port) { UserName = user, Password = pass }.Uri;

            Console.WriteLine($"[cfx-test] broker={uri} exchange={exchange} queue={queue} timeout={timeoutMs}ms");

            AmqpCFXEndpoint.MaxFrameSize = 250000;
            AmqpCFXEndpoint.Codec = CFXCodec.gzip;

            _received = new AutoResetEvent(false);
            AmqpCFXEndpoint listener = null;
            AmqpCFXEndpoint publisher = null;

            try
            {
                // --- Listener: subscribe to the queue the exchange is bound to ---
                listener = new AmqpCFXEndpoint { ValidateCertificates = false };
                listener.Open("CFXIntegrationTest.Listener");
                listener.OnCFXMessageReceived += Listener_OnCFXMessageReceived;

                if (!WaitForChannel(
                        (out Exception ex) => listener.TestSubscribeChannel(uri, queue, out ex, virtualHost),
                        $"subscribe to {queue}", timeoutMs))
                {
                    return Fail("Could not establish subscribe channel before timeout.");
                }
                listener.AddSubscribeChannel(uri, queue, virtualHost);

                // --- Publisher: publish to the exchange ---
                publisher = new AmqpCFXEndpoint { ValidateCertificates = false };
                publisher.Open("CFXIntegrationTest.Publisher");

                if (!WaitForChannel(
                        (out Exception ex) => publisher.TestPublishChannel(uri, exchange, out ex, virtualHost),
                        $"publish to {exchange}", timeoutMs))
                {
                    return Fail("Could not establish publish channel before timeout.");
                }
                publisher.AddPublishChannel(uri, exchange, virtualHost);

                // --- Publish a message and synchronously wait for the listener to receive it ---
                _sent = CFXEnvelope.FromCFXMessage(new EndpointConnected
                {
                    CFXHandle = "CFXIntegrationTest.Publisher"
                });

                Console.WriteLine($"[cfx-test] publishing {_sent.MessageName} UniqueID={_sent.UniqueID}");
                publisher.Publish(_sent);

                if (!_received.WaitOne(timeoutMs))
                {
                    return Fail($"Message {_sent.UniqueID} was not received within {timeoutMs}ms.");
                }

                Console.WriteLine("PASS: message round-tripped through the broker.");
                return 0;
            }
            catch (Exception ex)
            {
                return Fail(ex.ToString());
            }
            finally
            {
                listener?.Close();
                publisher?.Close();
                _received?.Dispose();
            }
        }

        private static void Listener_OnCFXMessageReceived(AmqpChannelAddress source, CFXEnvelope message)
        {
            if (_sent != null && message != null && message.UniqueID == _sent.UniqueID)
            {
                Console.WriteLine($"[cfx-test] received {message.MessageName} UniqueID={message.UniqueID}");
                _received.Set();
            }
        }

        private delegate bool ChannelProbe(out Exception error);

        /// <summary>
        /// Polls a Test*Channel probe until it succeeds or the timeout elapses, tolerating broker
        /// startup races. Logs the last error on each failed attempt.
        /// </summary>
        private static bool WaitForChannel(ChannelProbe probe, string what, int timeoutMs)
        {
            DateTime deadline = DateTime.UtcNow.AddMilliseconds(timeoutMs);
            int attempt = 0;
            while (true)
            {
                attempt++;
                if (probe(out Exception error))
                {
                    Console.WriteLine($"[cfx-test] channel ready: {what} (attempt {attempt})");
                    return true;
                }

                if (DateTime.UtcNow >= deadline)
                {
                    Console.WriteLine($"[cfx-test] giving up on {what} after {attempt} attempts: {error?.Message}");
                    return false;
                }

                Console.WriteLine($"[cfx-test] {what} not ready (attempt {attempt}): {error?.Message}; retrying...");
                Thread.Sleep(2000);
            }
        }

        private static int Fail(string message)
        {
            Console.Error.WriteLine($"FAIL: {message}");
            return 1;
        }

        private static string Env(string name, string fallback)
        {
            string value = Environment.GetEnvironmentVariable(name);
            return string.IsNullOrWhiteSpace(value) ? fallback : value;
        }
    }
}
