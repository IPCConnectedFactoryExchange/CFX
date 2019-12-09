using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;
using CFX;
using CFX.Transport;
using CFX.Production.TestAndInspection;
using CFX.Structures;
using System.Text;
using System.Collections.Generic;

namespace CFXUnitTests
{
    [TestClass]
    public class BrokerTests
    {
        [TestMethod]
        public void NoAuthNoSec()
        {
            DoTests(false, false);
        }

        [TestMethod]
        public void AuthNoSec()
        {
            DoTests(true, false);
        }

        [TestMethod]
        public void NoAuthSec()
        {
            DoTests(false, true);
        }

        [TestMethod]
        public void AuthAndSec()
        {
            DoTests(true, true);
        }

        [TestMethod]
        public void AltHostNoAuthNoSec()
        {
            DoTests(false, false, true);
        }

        [TestMethod]
        public void AltHostAuthNoSec()
        {
            DoTests(true, false, true);
        }

        [TestMethod]
        public void AltHostNoAuthSec()
        {
            DoTests(false, true, true);
        }

        [TestMethod]
        public void AltHostAuthAndSec()
        {
            DoTests(true, true, true);
        }


        [TestMethod]
        public void SendBigData()
        {
            InitializeTest(false, false, true);

            UnitsInspected un = new UnitsInspected()
            {
                InspectedUnits = new List<InspectedUnit>()
                {
                    new InspectedUnit()
                    {
                        UnitIdentifier = "121354546",
                    }
                }
            };

            for (int i = 0; i < 100000; i++)
            {
                Inspection insp = new Inspection()
                {
                    Measurements = new List<Measurement>()
                    {
                        new NumericMeasurement()
                        {
                            MeasurementName = "Measurement 1",
                            MeasuredValue = new NumericValue()
                            {
                                Value = 1.232546546,
                                ValueUnits = "mm",
                                ExpectedValue = 1.2364564,
                                MaximumAcceptableValue = 7.8854546,
                                MinimumAcceptableValue = 8.67867876,
                            }
                        }
                    }
                };

                un.InspectedUnits[0].Inspections.Add(insp);
            }

            //un = new UnitsInspected();

            string json = un.ToJson();

            System.Diagnostics.Debug.WriteLine($"Sending Message of Size:  {Encoding.UTF8.GetBytes(json).Length} bytes");

            FireAndWait(un);

            System.Diagnostics.Debug.WriteLine($"Message Received:  {Encoding.UTF8.GetBytes(json).Length} bytes");

        }

        [TestMethod]
        public void JJWTest()
        {
        }

        private void DoTests(bool auth, bool sec, bool useAltHost = false)
        {
            InitializeTest(auth, sec, useAltHost);

            // Publish basic EndpointConnected message and ensure receipt by listener
            EndpointConnected msg = new EndpointConnected()
            {
                CFXHandle = TestSettings.ClientHandle
            };

            FireAndWait(msg);
        }

        private AmqpCFXEndpoint endpoint = null;
        private AmqpCFXEndpoint listener = null;

        private void InitializeTest(bool auth, bool sec, bool useAltHost)
        {
            AmqpCFXEndpoint.MaxFrameSize = 250000;

            SetupListener(auth, sec, useAltHost);
            SetupEndpoint(auth, sec, useAltHost);
        }

        private void SetupListener(bool auth, bool sec, bool useAltHost)
        {
            KillListener();

            listener = new AmqpCFXEndpoint();
            listener.ValidateCertificates = true;
            listener.Open(TestSettings.ClientHandle, certificate: TestSettings.GetCertificate(sec));
            listener.OnCFXMessageReceived += Listener_OnCFXMessageReceived;

            string virtualHost = null;
            if (useAltHost) virtualHost = TestSettings.BrokerVirtualHost;

            Exception ex = null;
            Uri uri = TestSettings.GetBrokerUri(auth, sec);
            if (!listener.TestSubscribeChannel(uri, TestSettings.BrokerQueue, out ex, virtualHost, TestSettings.GetCertificate(sec)))
            {
                throw new Exception($"Cannot subscribe to broker at {uri.ToString()}, Queue {TestSettings.BrokerQueue}:  {ex.Message}", ex);
            }

            listener.AddSubscribeChannel(uri, TestSettings.BrokerQueue, TestSettings.BrokerVirtualHost, TestSettings.GetCertificate(sec));
        }

        private void Listener_OnCFXMessageReceived(AmqpChannelAddress source, CFXEnvelope message)
        {
            if (testEnv != null && testEnv.UniqueID == message.UniqueID && evt != null) evt.Set();
        }

        private void SetupEndpoint(bool auth, bool sec, bool useAltHost)
        {
            KillEndpoint();

            //CFX.Utilities.AppLog.LoggingEnabled = true;
            //CFX.Utilities.AppLog.LogFilePath = @"c:\stuff\cfxlog.txt";
            //CFX.Utilities.AppLog.LoggingLevel = CFX.Utilities.LogMessageType.Debug | CFX.Utilities.LogMessageType.Error | CFX.Utilities.LogMessageType.Info | CFX.Utilities.LogMessageType.Warn;
            //CFX.Utilities.AppLog.LoggingLevel = CFX.Utilities.LogMessageType.Error | CFX.Utilities.LogMessageType.Warn;
            //CFX.Utilities.AppLog.AmqpTraceEnabled = true;

            endpoint = new AmqpCFXEndpoint();
            endpoint.ValidateCertificates = false;
            endpoint.Open(TestSettings.ClientHandle, certificate: TestSettings.GetCertificate(sec));
                                    
            string virtualHost = null;
            if (useAltHost) virtualHost = TestSettings.BrokerVirtualHost;

            Exception ex = null;
            Uri uri = TestSettings.GetBrokerUri(auth, sec);
            if (!endpoint.TestPublishChannel(uri, TestSettings.BrokerExchange, out ex, virtualHost))  //, TestSettings.GetCertificate(sec)))
            {
                throw new Exception($"Cannot connect to broker at {uri.ToString()}, Exchange {TestSettings.BrokerExchange}:  {ex.Message}", ex);
            }

            endpoint.AddPublishChannel(uri, TestSettings.BrokerExchange, TestSettings.BrokerVirtualHost, TestSettings.GetCertificate(sec));
        }

        private System.Threading.AutoResetEvent evt;
        private CFXEnvelope testEnv = null;
        
        private void FireAndWait(CFXMessage msg)
        {
            using (evt = new System.Threading.AutoResetEvent(false))
            {
                CFXEnvelope env = CFXEnvelope.FromCFXMessage(msg);
                testEnv = env;
                endpoint.Publish(env);
                if (!evt.WaitOne(60000))
                {
                    throw new TimeoutException("The message was not received by listener.  Timeout");
                }
            }
        }


        [TestCleanup]
        public void KillAll()
        {
            KillEndpoint();
            KillListener();
        }

        private void KillListener()
        {
            if (listener != null)
            {
                listener.Close();
                listener = null;
            }
        }

        private void KillEndpoint()
        {
            if (endpoint != null)
            {
                endpoint.Close();
                endpoint = null;
            }
        }
    }
}
