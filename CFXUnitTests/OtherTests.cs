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
using CFX.ResourcePerformance;
using CFX.Production;
using CFX.Structures.SMTPlacement;

namespace CFXUnitTests
{
    [TestClass]
    public class OtherTests
    {
        [TestMethod]
        public void GetChanges()
        {
            string version = "1.5";
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
            ep.AddSubscribeChannel(new Uri("amqp://cfxbroker.connectedfactoryexchange.com"), "/queue/JJWTestQueue");

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
        }

        private void AppLog_OnTraceMessage(LogMessageType type, string traceMessage)
        {
            Console.WriteLine($"{traceMessage}");
        }

        [TestMethod]
        public void ReplayEvents()
        {
            CFX.Utilities.AppLog.LoggingEnabled = true;
            CFX.Utilities.AppLog.LoggingLevel = LogMessageType.All;
            //CFX.Utilities.AppLog.AmqpTraceEnabled = true;
            CFX.Utilities.AppLog.OnTraceMessage += AppLog_OnTraceMessage;


            string handle = "Heller.Reflow.1809-Booth";
            AmqpCFXEndpoint ep = new AmqpCFXEndpoint();
            ep.HeartbeatFrequency = TimeSpan.FromSeconds(4);
            ep.Open(handle);
            ep.AddPublishChannel(new Uri("amqp://cfxbroker.connectedfactoryexchange.com"), "/exchange/AegisCloud");

            string fileName = @"d:\stuff\TestData.json";
            string file;
            using (StreamReader reader = new StreamReader(fileName))
            {
                file = reader.ReadToEnd();
            }

            string message = null;
            int startPos = 0;
            DateTime? startTime = null;
            DateTime actualStart = DateTime.Now;
            List<string> messages = new List<string>();
            while ((message = GetNextMessage(file, ref startPos)) != null)
            {
                messages.Add(message);
            }

            messages.Reverse();

            foreach (string msg in messages)
            {
                CFXEnvelope env = CFXEnvelope.FromJson(msg);
                if (!startTime.HasValue) startTime = env.TimeStamp;
                env.TimeStamp = actualStart + (env.TimeStamp - startTime.Value);

                if (env.MessageBody is WorkStarted || env.MessageBody is WorkCompleted)
                {
                    env.Source = handle;
                    if (env.MessageBody is WorkStarted)
                    {
                        //WorkStarted ws = env.MessageBody as WorkStarted;
                        //ws.Units = new List<CFX.Structures.UnitPosition>();
                        //ws.Units.Add(new CFX.Structures.UnitPosition() { PositionNumber = 1 });
                    }
                    ep.Publish(env);
                    //break;
                }

            }


            DateTime start = DateTime.Now;
            while ((DateTime.Now - start) < TimeSpan.FromSeconds(30))
            {
                System.Threading.Thread.Sleep(1);
            }

        }

        public static string GetNextMessage(string data, ref int startPos)
        {
            int depth = 0;
            string result = null;
            int i = startPos;
            int actualStartPos = -1;
            for (i = startPos; i < data.Length; i++)
            {
                if (data[i] == '{')
                {
                    if (actualStartPos < 0) actualStartPos = i;
                    depth++;
                }
                else if (data[i] == '}')
                    depth--;

                if (depth == 0 && actualStartPos >= 0)
                {
                    result = data.Substring(actualStartPos, (i - actualStartPos) + 1);
                    break;
                }
            }

            startPos = i + 1;
            return result;
        }

        public static void Wait(int seconds)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start) < TimeSpan.FromSeconds(seconds))
            {
                System.Threading.Thread.Sleep(1);
            }
        }

        [TestMethod]
        public void DummyTest()
        {
            CFX.ResourcePerformance.StationStateChanged ssc = new StationStateChanged()
            {
                NewState = CFX.Structures.ResourceState.SBY_NoProductStarved
            };

            string s = ssc.ToJson();

            s = s.Replace("2202", "22A0");

            CFX.ResourcePerformance.StationStateChanged ssc2 = CFXMessage.FromJson<StationStateChanged>(s);

            

            

        }


            [TestMethod]
        public void UpgradeTest()
        {
            // Write old SMTPlacementActivity
            //SMTPlacementActivity act = new SMTPlacementActivity();
            //act.Head = new SMTHeadInformation()
            //{
            //    Head = new CFX.Structures.Head()
            //    {
            //        HeadId = "10001000",
            //        HeadName = "HEAD1",
            //        HeadSequence = 1
            //    },
            //    NumberOfNozzleLocations = 2,
            //    PlacementAccuracy = 0.00001,
            //    SMTHeadType = SMTHeadType.Pulsar
            //};

            //ActivitiesExecuted ae = new ActivitiesExecuted()
            //{
            //    Activities = new List<CFX.Structures.Activity>()
            //    {
            //        act
            //    }
            //};

            //using (StreamWriter writer = new StreamWriter(@"d:\stuff\test.txt"))
            //{
            //    writer.Write(ae.ToJson());
            //}

            ActivitiesExecuted ae2 = null;
            using (StreamReader reader = new StreamReader(@"d:\stuff\test.txt"))
            {
                string json = reader.ReadToEnd();
                ae2 = CFXMessage.FromJson<ActivitiesExecuted>(json);

            }

            string test = ae2.ToJson(true);
        }
    }
}
