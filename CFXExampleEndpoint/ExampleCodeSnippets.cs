using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CFX;
using CFX.Transport;

namespace CFXExampleEndpoint
{
    class ExampleCodeSnippets
    {
        public void SecureMessages()
        {
            AmqpCFXEndpoint endpoint = new AmqpCFXEndpoint();
            endpoint.Open("Vendor1.Model1.Machine34");

            // Note the user of "amqps://" instead of "amqp://"
            // Uri uri = new Uri("amqps://mycfxbroker.mydomain.com");

             // Encode your username and password into the destination Uri
            string username = "myusername";
            string password = "mypassword";
            string hostname = "mycfxbroker.mydomain.com";

            //  eg.  amqps://myusername:mypassword@mycfxbroker.mydomain.com
            Uri uri = new Uri(string.Format("amqps://{0}:{1}@{2}", username, password, hostname));

            // Target exchange on broker (shown here in RabbitMQ compatible format)
            string amqpTarget = "/exchange/myexchange";
            endpoint.AddPublishChannel(uri, amqpTarget);

            // Source queue on broker (shown here in RabbitMQ compatible format)
            string amqpSource = "/queue/myqueue";
            endpoint.AddSubscribeChannel(uri, amqpSource);
        }

        public void MakingRequests()
        {
            string myCFXHandle = "Vendor1.Model1.Machine34";
                        
            AmqpCFXEndpoint endpoint = new AmqpCFXEndpoint();
            endpoint.Open(myCFXHandle);

            string targetEndpointHostname = "machine55.mydomain.com";
            string targetCFXHandle = "Vendor2.Model2.Machine55";
            string remoteUri = string.Format("amqp://{0}", targetEndpointHostname);

            // Set a timeout of 20 seconds.  If the target endpoint does not
            // respond in this time, the request will time out.
            AmqpCFXEndpoint.RequestTimeout = TimeSpan.FromSeconds(20);

            // Build a GetEndpointInfomation Request
            CFXEnvelope request = CFXEnvelope.FromCFXMessage(new GetEndpointInformationRequest()
            {
                CFXHandle = targetCFXHandle
            });

            CFXEnvelope response = endpoint.ExecuteRequest(remoteUri, request);
            
        }

        AmqpCFXEndpoint endpoint;
        string myCFXHandle = "Vendor1.Model1.Machine34";
        Uri myRequestUri;

        public void OpenEndpoint()
        {
            endpoint = new AmqpCFXEndpoint();
            myRequestUri = new Uri(string.Format("amqp://{0}", System.Net.Dns.GetHostName()));

            endpoint.OnRequestReceived += Endpoint_OnRequestReceived;
            endpoint.Open(myCFXHandle, myRequestUri);
         
        }

        public void OpenEndpointSecure()
        {
            endpoint = new AmqpCFXEndpoint();
            myRequestUri = new Uri(string.Format("amqps://{0}", System.Net.Dns.GetHostName()));

            // Load certificate from local machine or user certificate store
            X509Certificate2 cert = AmqpUtilities.GetCertificate("MyCertificateName");
            
            endpoint.OnRequestReceived += Endpoint_OnRequestReceived;
            endpoint.Open(myCFXHandle, myRequestUri, cert);
        }

        private CFXEnvelope Endpoint_OnRequestReceived(CFXEnvelope request)
        {
            // Process request.  Return Result.
            if (request.MessageBody is WhoIsThereRequest)
            {
                CFXEnvelope result = CFXEnvelope.FromCFXMessage(new WhoIsThereResponse()
                { CFXHandle = myCFXHandle, RequestNetworkUri = myRequestUri.ToString(), RequestTargetAddress = "" });
                result.Source = myCFXHandle;
                result.Target = request.Source;
                return result;
            }

            return null;
        }
    }
}
