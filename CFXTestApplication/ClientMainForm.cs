using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using CFX;
using CFX.WorkCenterServices;
using CFX.Utilities;

namespace CFXTestApplication
{
    public partial class ClientMainForm : Form
    {
        public ClientMainForm()
        {
            InitializeComponent();

            gen.EndpointId = "host1.domain1.com/Line1/ReflowOven1";

            List<object> messages = gen.CreateReflowWIPMessages();

            string jsonData = "";
            foreach (object o in messages)
            {
                jsonData += JsonConvert.SerializeObject(o);
                jsonData += "\r\n";

                object o2 = JsonConvert.DeserializeObject<CFXEnvelope>(JsonConvert.SerializeObject(o));
            }

            Clipboard.Clear();
            Clipboard.SetText(jsonData);
        }

        private CFXMessageGenerator gen = new CFXMessageGenerator();
        private MqttClient client1 = null;
        private string client1Name;
        private MqttClient client2 = null;
        private Random rnd = new Random();

        private Timer timer1 = null;
        private Timer timer2 = null;

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (client1 == null)
            {
                client1Name = "Client" + rnd.Next(1, 1000);
                client1 = new MqttClient("jwalls.aiscorp.local");
                client1.Connect(client1Name);
                client1.MqttMsgPublishReceived += Client1_MqttMsgPublishReceived;
                //client1.Subscribe(new string[] { "topic1.subtopic2/#"},  new byte[] { 0x00 });
                //client1.Subscribe(new string[] { "topic1.subtopic1/#"},  new byte[] { 0x00 });
                client1.Subscribe(new string[] { "/topic2/#"},  new byte[] { 0x00 });


                timer1 = new Timer();
                timer1.Interval = rnd.Next(2000, 4000);
                timer1.Tick += Timer1_Tick;
                timer1.Start();
            }

            if (client2 == null)
            {
                client2 = new MqttClient("jwalls.aiscorp.local");
                client2.Connect("client2");
                client2.MqttMsgPublishReceived += Client2_MqttMsgPublishReceived;
                //client2.Subscribe(new string[] { "topic2/#" }, new byte[] { 0x02 });

                timer2 = new Timer();
                timer2.Interval = 2000;
                timer2.Tick += Timer2_Tick;
                timer2.Start();
            }
        }

        private void Client1_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            string clientId = (sender as MqttClient).ClientId;
            clientId = "Client1";
            string message = Encoding.Unicode.GetString(e.Message);
            string[] topicParts = e.Topic.Split('/');
            if (topicParts[1] != client1Name)
            {
                this.BeginInvoke((Action)(() => { receivedBox.AppendText(string.Format("{0} Received a message: Topic:{1}\r\n", clientId, e.Topic)); }));
            }
        }

        private void Client2_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            string clientId = (sender as MqttClient).ClientId;
            clientId = "Client2";
            string message = Encoding.Unicode.GetString(e.Message);
            string[] topicParts = e.Topic.Split('/');
            if (topicParts[1] != client1Name)
            {
                this.BeginInvoke((Action)(() => { receivedBox.AppendText(string.Format("{0} Received a message: Topic:{1}\r\n", clientId, e.Topic)); }));
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (client1 != null)
            {
                //string topic = "topic2.test/" + client1Name;
                //string message = "This is a message from " + client1Name;
                //client1.Publish(topic, Encoding.Unicode.GetBytes(message));
                //receivedBox.AppendText(client1Name + " Published a message...\r\n");
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (client2 != null)
            {
                //client2.Publish("topic1/client2", Encoding.Unicode.GetBytes("This is a message from Client 2"));
                client2.Publish("/topic1.subtopic2/client2", Encoding.Unicode.GetBytes("This is a message from Client 2"));
                client2.Publish("/topic2/client2", Encoding.Unicode.GetBytes("This is a message from Client 2"));
            }
        }

        private void ClientMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer1 != null)
            {
                timer1.Stop();
                timer1 = null;
            }

            if (client1 != null)
            {
                client1.Disconnect();
                client1 = null;
            }

            if (timer2 != null)
            {
                timer2.Stop();
                timer2 = null;
            }

            if (client2 != null)
            {
                client2.Disconnect();
                client2 = null;
            }


        }
    }
}
