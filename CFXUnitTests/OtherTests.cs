using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using CFX;
using CFX.Transport;
using CFX.Utilities;
using System.IO;

namespace CFXUnitTests
{
    [TestClass]
    public class OtherTests
    {
        [TestMethod]
        public void GetChanges()
        {
            string version = "1.2";
            List<string> lines = new List<string>();

            Assembly assembly = Assembly.GetAssembly(typeof(CFX.CFXEnvelope));

            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttribute<CreatedVersionAttribute>(false)?.CreatedVersion == version)
                {
                    if (type.IsEnum)
                        lines.Add($"New Enumeration:  {type.FullName}");
                    else
                        lines.Add($"New Class:  {type.FullName}");
                    continue;
                }

                foreach (PropertyInfo prop in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Where(p => p.GetCustomAttribute<CreatedVersionAttribute>()?.CreatedVersion == version))
                {
                    lines.Add($"New Property:  {type.FullName} :: {prop.Name}");
                }

                if (type.IsEnum)
                {
                    foreach (MemberInfo mi in type.GetMembers().Where(mi => mi.GetCustomAttribute<CreatedVersionAttribute>()?.CreatedVersion == version))
                    {
                        lines.Add($"New Enum Value:  {type.FullName} :: {mi.Name}");
                    }
                }
            }

            lines.Sort();
            StringBuilder report = new StringBuilder();
            lines.ForEach(l => report.AppendLine(l));

            System.Diagnostics.Debug.WriteLine(report.ToString());
            System.Windows.Forms.Clipboard.SetText(report.ToString());

        }

        [TestMethod]
        public void HeartbeatTest()
        {
            string handle = "Aegis.CFXSimulator.Machine1";
            AmqpCFXEndpoint ep = new AmqpCFXEndpoint();
            ep.HeartbeatFrequency = TimeSpan.FromSeconds(4);
            ep.Open(handle);
            ep.AddPublishChannel(new Uri("amqp://cfxbroker.connectedfactoryexchange.com"), "/exchange/AegisCloud");
            //ep.Publish(new CFX.EndpointConnected() { CFXHandle = handle });

            DateTime start = DateTime.Now;
            while ((DateTime.Now - start) < TimeSpan.FromSeconds(30))
            {
                System.Threading.Thread.Sleep(1);
            }
        }


        [TestMethod]
        public void MalformedTest()
        {
            CFX.Utilities.AppLog.LoggingEnabled = true;
            CFX.Utilities.AppLog.LoggingLevel = LogMessageType.All;
            //CFX.Utilities.AppLog.AmqpTraceEnabled = true;
            CFX.Utilities.AppLog.OnTraceMessage += AppLog_OnTraceMessage;

            
            string handle = "Aegis.CFXSimulator.Machine1";
            AmqpCFXEndpoint ep = new AmqpCFXEndpoint();
            ep.HeartbeatFrequency = TimeSpan.FromSeconds(4);
            ep.Open(handle);
            ep.OnCFXMessageReceived += Ep_OnCFXMessageReceived;
            ep.OnMalformedMessageReceived += Ep_OnMalformedMessageReceived;
            ep.AddSubscribeChannel(new Uri("amqp://jwalls:Aegis220*@cfxbroker.connectedfactoryexchange.com"), "/queue/JJWTestQueue");

            DateTime start = DateTime.Now;
            while ((DateTime.Now - start) < TimeSpan.FromSeconds(30))
            {
                System.Threading.Thread.Sleep(1);
            }
        }

        private void Ep_OnMalformedMessageReceived(AmqpChannelAddress source, string message)
        {
            Console.WriteLine($"MALFORMED MESSAGE RECEIVED:  \r\n{message}");
        }

        private void Ep_OnCFXMessageReceived(AmqpChannelAddress source, CFXEnvelope message)
        {
            int z1 = 0;
        }

        private void AppLog_OnTraceMessage(LogMessageType type, string traceMessage)
        {
            Console.WriteLine($"{traceMessage}");
        }
    }
}
