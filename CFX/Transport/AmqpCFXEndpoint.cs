using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Transport
{
    public class AmqpCFXEndpoint : IDisposable
    {
        public AmqpCFXEndpoint()
        {
            channels = new ConcurrentDictionary<string, AmqpConnection>();
            IsOpen = false;
        }

        private AmqpRequestProcessor requestProcessor;
        private ConcurrentDictionary<string, AmqpConnection> channels;

        public event OnRequestHandler OnRequestReceived;
        public event CFXMessageReceivedHandler OnCFXMessageReceived;

        public string CFXHandle
        {
            get;
            private set;
        }

        public Uri RequestUri
        {
            get;
            private set;
        }

        public bool IsOpen
        {
            get;
            private set;
        }

        public void Open(string cfxHandle, IPAddress requestAddress, int requestPort = 5672)
        {
            Uri uri = new Uri(string.Format("amqp://{0}:{1}", requestAddress.ToString(), requestPort));
            Open(cfxHandle, uri);
        }

        public void Open(string cfxHandle, Uri requestUri = null)
        {
            IsOpen = false;

            try
            {
                this.CFXHandle = cfxHandle;
                if (requestUri != null)
                    this.RequestUri = requestUri;
                else
                    this.RequestUri = new Uri(string.Format("amqp://{0}:5672", Environment.MachineName));

                //requestProcessor = new AmqpRequestProcessor();
                //requestProcessor.Open(this.CFXHandle, this.RequestUri);
                //requestProcessor.OnRequestReceived += RequestProcessor_OnRequestReceived;

                IsOpen = true;
            }
            catch (Exception ex)
            {
                Cleanup();
                Debug.WriteLine(ex.Message);
            }
        }

        public static bool TestChannel(Uri channelUri, out Exception error)
        {
            bool result = false;
            error = null;

            try
            {
                AmqpConnection conn = new AmqpConnection();
                conn.Open(channelUri);
                conn.Close();
                result = true;
            }
            catch (Exception ex)
            {
                error = ex;
                Debug.WriteLine(ex.Message);
            }

            return result;
        }

        public void AddTransmitChannel(AmqpChannelAddress address)
        {
            AddTransmitChannel(address.Uri, address.Address);
        }

        public void AddTransmitChannel(Uri networkAddress, string address)
        {
            if (!IsOpen) throw new Exception("The Endpoint must be open before adding or removing channels.");
            string key = networkAddress.ToString();

            AmqpConnection channel = null;
            if (channels.ContainsKey(key))
            {
                channel = channels[key];
            }
            else
            {
                channel = new AmqpConnection();
                channel.Open(networkAddress);
                channel.OnCFXMessageReceived += Channel_OnCFXMessageReceived;
                channels[key] = channel;
            }

            if (channel != null)
            {
                channel.AddTransmitChannel(address);
            }
        }

        public void AddReceiverChannel(AmqpChannelAddress address)
        {
            AddReceiverChannel(address.Uri, address.Address);
        }

        public void AddReceiverChannel(Uri networkAddress, string address)
        {
            if (!IsOpen) throw new Exception("The Endpoint must be open before adding or removing channels.");
            string key = networkAddress.ToString();

            AmqpConnection channel = null;
            if (channels.ContainsKey(key))
            {
                channel = channels[key];
            }
            else
            {
                channel = new AmqpConnection();
                channel.Open(networkAddress);
                channel.OnCFXMessageReceived += Channel_OnCFXMessageReceived;
                channels[key] = channel;
            }

            if (channel != null)
            {
                channel.AddReceiverChannel(address);
            }
        }

        public void RemoveTransmitEventChannel(Uri networkAddress, string source, string target)
        {
            if (!IsOpen) throw new Exception("The Endpoint must be open before adding or removing channels.");
            string key = networkAddress.ToString();
            
            //if (channels.ContainsKey(key))
            //{
            //    AmqpConnection channel;
            //    channels.TryRemove(key, out channel);
            //    if (channel != null) channel.Close();
            //}
        }
        
        private void Channel_OnCFXMessageReceived(AmqpChannelAddress source, CFXEnvelope message)
        {
            OnCFXMessageReceived?.Invoke(source, message);
        }

        private CFXEnvelope RequestProcessor_OnRequestReceived(CFXEnvelope request)
        {
            if (OnRequestReceived != null) return OnRequestReceived(request);
            return null;
        }

        public void Close()
        {
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void Cleanup()
        {
            if (requestProcessor != null)
            {
                requestProcessor.Close();
                requestProcessor = null;
            }

            IsOpen = false;
        }

        public void SendMessage(CFXEnvelope env)
        {
            foreach (AmqpConnection channel in channels.Values)
            {
                channel.Send(env);
            }
        }

        public void SendMessage(CFXMessage msg)
        {
            CFXEnvelope env = new CFXEnvelope();
            env.MessageBody = msg;
            SendMessage(env);
        }

    }
}
