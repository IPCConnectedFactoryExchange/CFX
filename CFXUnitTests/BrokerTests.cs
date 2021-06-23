using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;
using CFX;
using CFX.Transport;
using CFX.Production.TestAndInspection;
using CFX.Structures;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

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
            Stopwatch sw = Stopwatch.StartNew();
            InitializeTest(false, false, false);

            Debug.WriteLine($"Initialized at {sw.ElapsedMilliseconds} ms");

            UnitsRepaired un = new UnitsInspected()
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

            Debug.WriteLine($"Created Big Message at {sw.ElapsedMilliseconds} ms");

            //string json = un.ToJson();

            //Debug.WriteLine($"Serialized to JSON at {sw.ElapsedMilliseconds} ms,  Raw Message size = {json.Length} bytes");

            FireAndWait(un);

            Debug.WriteLine($"Got message back at {sw.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        public void PublishTest()
        {
            //CFX.Utilities.AppLog.LoggingLevel = CFX.Utilities.LogMessageType.All;

            //AmqpCFXEndpoint ep = new AmqpCFXEndpoint();
            ////ep.HeartbeatFrequency = TimeSpan.FromSeconds(5);

            //Uri broker = new Uri("amqp://cfxbroker.connectedfactoryexchange.com");
            //ep.Open("Aegis.CFXSimulator.Machine1");
            //ep.AddPublishChannel(broker, "/exchange/AegisCloud");

            //CFX.ResourcePerformance.StationStateChanged ssc = new CFX.ResourcePerformance.StationStateChanged()
            //{
            //    NewState = ResourceState.NST,
            //    OldState = ResourceState.PRD
            //};

            //ep.Publish(ssc);

            //DateTime start = DateTime.Now;
            //while ((DateTime.Now - start) < TimeSpan.FromSeconds(80))
            //{
            //    System.Threading.Thread.Sleep(200);
            //}
        }

        [TestMethod]
        public void TestHeaders()
        {
            //SetupListener(false, false, false);

            //endpoint = new AmqpCFXEndpoint();
            //endpoint.ValidateCertificates = false;
            //endpoint.Open("JJWTest.Endpoint1");

            //endpoint.SubjectFormat = "Route1.${CFX-MessageName}";

            //Exception ex = null;
            //Uri uri = TestSettings.GetBrokerUri(false, false);
            //endpoint.AddPublishChannel(uri, "/exchange/jjwtestex");
            //endpoint.PurgeAllSpools();
            
            //UnitsInspected un = new UnitsInspected()
            //{
            //    InspectedUnits = new List<InspectedUnit>()
            //    {
            //        new InspectedUnit()
            //        {
            //            UnitIdentifier = "121354546",
            //        }
            //    }
            //};

            //try { FireAndWait(un, 2000); Debug.WriteLine($"Received Message {un.GetType().Name}"); }
            //catch { Debug.WriteLine($"DID NOT Receive Message {un.GetType().Name}"); }

            //CFX.Production.WorkStarted ws = new CFX.Production.WorkStarted()
            //{
            //    PrimaryIdentifier = "UNIT100001"
            //};

            //try { FireAndWait(ws, 2000); Debug.WriteLine($"Received Message {ws.GetType().Name}"); }
            //catch { Debug.WriteLine($"DID NOT Receive Message {ws.GetType().Name}"); }

            //CFX.ResourcePerformance.StationStateChanged sc = new CFX.ResourcePerformance.StationStateChanged()
            //{
            //    NewState = ResourceState.ENG,
            //    OldState = ResourceState.NST
            //};

            //try { FireAndWait(sc, 2000); Debug.WriteLine($"Received Message {sc.GetType().Name}"); }
            //catch { Debug.WriteLine($"DID NOT Receive Message {sc.GetType().Name}"); }

            //KillAll();
        }

        private void Ep_OnCFXMessageReceivedFromListener(string targetAddress, CFXEnvelope message)
        {
            System.Diagnostics.Debug.WriteLine($"Message received from endpoint {message.Source} on listener {targetAddress}");
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
            AmqpCFXEndpoint.Codec = CFXCodec.gzip;
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

            listener.AddSubscribeChannel(uri, TestSettings.BrokerQueue, virtualHost, TestSettings.GetCertificate(sec));
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

            endpoint.AddPublishChannel(uri, TestSettings.BrokerExchange, virtualHost, TestSettings.GetCertificate(sec));
        }

        private System.Threading.AutoResetEvent evt;
        private CFXEnvelope testEnv = null;
        
        private void FireAndWait(CFXMessage msg, int timeout = 60000)
        {
            using (evt = new System.Threading.AutoResetEvent(false))
            {
                CFXEnvelope env = CFXEnvelope.FromCFXMessage(msg);
                testEnv = env;
                endpoint.Publish(env);
                if (!evt.WaitOne(timeout))
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
