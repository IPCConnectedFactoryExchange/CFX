using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using CFXUnitTests.Properties;
using CFX.Transport;
using CFX;

namespace CFXUnitTests
{
    static class TestSettings
    {
        public static string ListenerHandle
        {
            get { return Settings.Default.ListenerHandle; }
        }

        public static string ClientHandle
        {
            get { return Settings.Default.ClientHandle; }
        }

        public static string ListenerAddress
        {
            get { return Settings.Default.ListenerAddress; }
        }

        public static string ListenerMessageSourceAddress
        {
            get
            {
                return $"/queue/{ListenerHandle}";
            }
        }

        public static string BrokerHostname
        {
            get { return Settings.Default.BrokerHostname; }
        }

        public static string BrokerExchange
        {
            get { return Settings.Default.BrokerExchange; }
        }

        public static string BrokerQueue
        {
            get { return Settings.Default.BrokerQueue; }
        }

        public static string BrokerUsername
        {
            get { return Settings.Default.BrokerUsername; }
        }

        public static string BrokerPassword
        {
            get { return Settings.Default.BrokerPassword; }
        }

        public static string BrokerVirtualHost
        {
            get { return Settings.Default.BrokerVirtualHost; }
        }

        public static Uri GetListenerUri(bool auth, bool sec)
        {
            UriBuilder uriBuilder = new UriBuilder();
            if (sec)
                uriBuilder.Scheme = "amqps";
            else
                uriBuilder.Scheme = "amqp";

            uriBuilder.Host = "localhost";

            if (Settings.Default.CustomPort != 5672 && Settings.Default.CustomPort != 5671)
                uriBuilder.Port = Settings.Default.CustomPort;

            if (auth)
            {
                uriBuilder.UserName = Settings.Default.DefaultUser;
                uriBuilder.Password = Settings.Default.DefaultPassword;
            }

            return uriBuilder.Uri;
        }

        public static Uri GetBrokerUri(bool auth, bool sec)
        {
            UriBuilder uriBuilder = new UriBuilder();
            if (sec)
                uriBuilder.Scheme = "amqps";
            else
                uriBuilder.Scheme = "amqp";

            uriBuilder.Host = BrokerHostname;

            if (auth)
            {
                uriBuilder.UserName = BrokerUsername;
                uriBuilder.Password = BrokerPassword;
            }

            return uriBuilder.Uri;
        }

        public static X509Certificate2 GetCertificate(bool sec)
        {
            if (!sec) return null;
            return AmqpUtilities.GetCertificate(Settings.Default.CertificateThumbprint);
        }

        public static CFXMessage GetDefaultMessage()
        {
            EndpointConnected msg = new EndpointConnected()
            {
                CFXHandle = ClientHandle
            };

            return msg;
        }
    }
}
