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
using CFX;
using CFX.Production;
using CFX.Utilities;
using CFX.Connection;

namespace CFXTestApplication
{
    public partial class ClientMainForm : Form
    {
        public ClientMainForm()
        {
            InitializeComponent();

            CFXEnvelope env = new CFXEnvelope();
            DateTime start = env.TimeStamp;

            WorkStarted started = new WorkStarted();
            env.MessageBody = started;
            env.Source = "MACHINE12345";
            started.UnitCount = 2;
            started.Lane = "1";
            started.UnitLocations.Add(new UnitLocation { UnitIdentifier = "UNIT1112245", LocationIdentifier = "1" });
            started.UnitLocations.Add(new UnitLocation { UnitIdentifier = "UNIT1112246", LocationIdentifier = "2" });

            string jsonData = "";
            jsonData += JsonConvert.SerializeObject(env) + "\r\n";

            WorkStageStarted msg2 = new WorkStageStarted();
            env.MessageBody = msg2;
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(2);
            env.UniqueID = Guid.NewGuid();
            msg2.Stage = "Stage1";
            msg2.TransactionID = started.TransactionID;
            jsonData += JsonConvert.SerializeObject(env) + "\r\n";

            WorkStageCompleted msg3 = new WorkStageCompleted();
            env.MessageBody = msg3;
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(12);
            env.UniqueID = Guid.NewGuid();
            msg3.Stage = "Stage1";
            msg3.Result = WorkResult.COMPLETED;
            msg3.TransactionID = started.TransactionID;
            jsonData += JsonConvert.SerializeObject(env) + "\r\n";

            msg2 = new WorkStageStarted();
            env.MessageBody = msg2;
            env.UniqueID = Guid.NewGuid();
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(13);
            msg2.Stage = "Stage2";
            msg2.TransactionID = started.TransactionID;
            jsonData += JsonConvert.SerializeObject(env) + "\r\n";

            WorkStagePaused msg5 = new WorkStagePaused();
            env.MessageBody = msg5;
            env.UniqueID = Guid.NewGuid();
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(16);
            msg5.Stage = "Stage2";
            msg5.TransactionID = started.TransactionID;
            jsonData += JsonConvert.SerializeObject(env) + "\r\n";

            WorkStageResumed msg6 = new WorkStageResumed();
            env.MessageBody = msg6;
            env.UniqueID = Guid.NewGuid();
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(18);
            msg6.Stage = "Stage2";
            msg6.TransactionID = started.TransactionID;
            jsonData += JsonConvert.SerializeObject(env) + "\r\n";

            msg3 = new WorkStageCompleted();
            env.MessageBody = msg3;
            env.UniqueID = Guid.NewGuid();
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(24);
            msg3.Stage = "Stage2";
            msg3.Result = WorkResult.COMPLETED;
            msg3.TransactionID = started.TransactionID;
            jsonData += JsonConvert.SerializeObject(env) + "\r\n";

            WorkCompleted msg4 = new WorkCompleted();
            env.MessageBody = msg4;
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(24);
            env.UniqueID = Guid.NewGuid();
            msg4.TransactionID = started.TransactionID;
            msg4.Result = WorkResult.COMPLETED;
            jsonData += JsonConvert.SerializeObject(env) + "\r\n";

            Clipboard.Clear();
            Clipboard.SetText(jsonData);
        }

        AmqpChannel receiveChannel;
        AmqpChannel sendChannel;
        private string client1Name;

        private Timer timer1 = null;
        private Timer timer2 = null;
        private string address = "amqp://guest:guest@127.0.0.1:5672";
        private string address2 = "amqp://guest:guest@127.0.0.1:5673";
        
        private void ClientMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (receiveChannel != null)
            {
                receiveChannel.Close();
                receiveChannel = null;
            }

            if (sendChannel != null)
            {
                sendChannel.Close();
                sendChannel = null;
            }

        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (sendChannel == null)
            {
                sendChannel = new AmqpChannel();
                sendChannel.Connect(receiveChannel.InboundAddress, "JJWClient");
            }

            CFXEnvelope env = new CFXEnvelope();
            WorkStarted started = new WorkStarted();
            started.UnitCount = 2;
            started.UnitLocations.Add(new UnitLocation { UnitIdentifier = "111112256", LocationIdentifier = "1" });
            started.UnitLocations.Add(new UnitLocation { UnitIdentifier = "111112257", LocationIdentifier = "2" });
            env.MessageBody = started;

            sendChannel.Send(env, "JJWClient");
            sendChannel.Close();
            sendChannel = null;
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            receiveChannel = new AmqpChannel();
            receiveChannel.Listen("JJWServer");
        }
    }
}
