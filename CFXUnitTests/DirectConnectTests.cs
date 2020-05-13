using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;
using CFX;
using CFX.Transport;
using CFX.Production.TestAndInspection;
using CFX.Structures;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace CFXUnitTests
{
    [TestClass]
    public class DirectConnectTests
    {
        private TestContext testContext = null;

        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }

        [TestMethod]
        public async Task NoAuthNoSec()
        {
            await DoTests(false, false);
        }

        [TestMethod]
        public async Task AuthNoSec()
        {
            await DoTests(true, false);
        }

        [TestMethod]
        public async Task NoAuthSec()
        {
            await DoTests(false, true);
        }

        [TestMethod]
        public async Task AuthAndSec()
        {
            await DoTests(true, true);
        }

        private async Task DoTests(bool auth, bool sec)
        {
            InitializeTest(auth, sec);

            // Publish basic EndpointConnected message and ensure receipt by listener
            EndpointConnected msg = new EndpointConnected()
            {
                CFXHandle = TestSettings.ClientHandle
            };

            FireAndWait(msg);

            // Send Request/Reponse pattern command, and ensure response
            CFXEnvelope req = new CFXEnvelope(new AreYouThereRequest() { CFXHandle = listener.CFXHandle });
            req.Source = endpoint.CFXHandle;
            req.Target = listener.CFXHandle;
            CFXEnvelope resp = endpoint.ExecuteRequest(listener.RequestUri.ToString(), req);
            Assert.IsTrue(resp != null, "Response is null");
            Assert.IsTrue(resp.MessageBody is AreYouThereResponse, "Response is not AreYouThereReponse");
            Assert.IsTrue(resp.Source == listener.CFXHandle, "Bad response Source handle");
            Assert.IsTrue(resp.Target == endpoint.CFXHandle, "Bad response Target handle");

            await RunAsyncRequest();
        }

        private async Task RunAsyncRequest()
        {
            // Send Request/Reponse pattern command, and ensure response
            CFXEnvelope req = new CFXEnvelope(new AreYouThereRequest() { CFXHandle = listener.CFXHandle });
            req.Source = endpoint.CFXHandle;
            req.Target = listener.CFXHandle;
            CFXEnvelope resp = await endpoint.ExecuteRequestAsync(listener.RequestUri.ToString(), req);
            Assert.IsTrue(resp != null, "async Response is null");
            Assert.IsTrue(resp.MessageBody is AreYouThereResponse, "async Response is not AreYouThereReponse");
            Assert.IsTrue(resp.Source == listener.CFXHandle, "async Bad response Source handle");
            Assert.IsTrue(resp.Target == endpoint.CFXHandle, "async Bad response Target handle");
        }

        private AmqpCFXEndpoint endpoint = null;
        private AmqpCFXEndpoint listener = null;

        private void InitializeTest(bool auth, bool sec)
        {
            SetupListener(auth, sec);
            SetupEndpoint(auth, sec);
        }

        private void SetupListener(bool auth, bool sec)
        {
            KillListener();

            listener = new AmqpCFXEndpoint();
            listener.Open(TestSettings.ListenerHandle, TestSettings.GetListenerUri(auth, sec), certificate: TestSettings.GetCertificate(sec));
            listener.OnCFXMessageReceivedFromListener += Listener_OnCFXMessageReceivedFromListener;
            listener.OnRequestReceived += Listener_OnRequestReceived;

            listener.AddListener(TestSettings.ListenerAddress);
        }

        private void SetupEndpoint(bool auth, bool sec)
        {
            KillEndpoint();

            endpoint = new AmqpCFXEndpoint();
            endpoint.Open(TestSettings.ClientHandle, certificate: TestSettings.GetCertificate(sec));
            endpoint.ValidateCertificates = false;

            //CFX.Utilities.AppLog.LoggingEnabled = true;
            //CFX.Utilities.AppLog.LogFilePath = @"c:\stuff\cfxlog.txt";
            //CFX.Utilities.AppLog.LoggingLevel = CFX.Utilities.LogMessageType.Debug | CFX.Utilities.LogMessageType.Error | CFX.Utilities.LogMessageType.Info | CFX.Utilities.LogMessageType.Warn;
            //CFX.Utilities.AppLog.LoggingLevel = CFX.Utilities.LogMessageType.Error | CFX.Utilities.LogMessageType.Warn;
            //CFX.Utilities.AppLog.AmqpTraceEnabled = true;

            //AmqpCFXEndpoint.MaxFrameSize = 1000000;
            
            Exception ex = null;
            Uri uri = TestSettings.GetListenerUri(auth, sec);
            if (!endpoint.TestPublishChannel(uri, TestSettings.ListenerAddress, out ex))
            {
                throw new Exception($"Cannot connect to listener at {uri.ToString()}:  {ex.Message}", ex);
            }

            endpoint.AddPublishChannel(uri, TestSettings.ListenerAddress);
        }

        private System.Threading.AutoResetEvent evt;

        private void FireAndWait(CFXMessage msg)
        {
            using (evt = new System.Threading.AutoResetEvent(false))
            {
                endpoint.Publish(msg);
                if (!evt.WaitOne(60000))
                {
                    throw new TimeoutException("The message was not received by listener.  Timeout");
                }
            }
        }

        private CFXEnvelope Listener_OnRequestReceived(CFXEnvelope request)
        {
            if (request.MessageBody is AreYouThereRequest)
            {
                CFXEnvelope resp = new CFXEnvelope(new AreYouThereResponse() { CFXHandle = listener.CFXHandle, RequestNetworkUri = listener.RequestUri.ToString(), RequestTargetAddress = null });
                resp.Target = request.Source;
                resp.Source = listener.CFXHandle;
                return resp;
            }

            return null;
        }

        private void Listener_OnCFXMessageReceivedFromListener(string targetAddress, CFXEnvelope message)
        {
            if (evt != null) evt.Set();
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
