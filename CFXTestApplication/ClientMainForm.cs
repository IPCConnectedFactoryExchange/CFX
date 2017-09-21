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
using CFX.DataObjects;
using CFX.Production;
using CFX.Utilities;
using CFX.Transport;
using System.Diagnostics;

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
            jsonData += env.ToJson() + "\r\n";

            WorkStageStarted msg2 = new WorkStageStarted();
            env.MessageBody = msg2;
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(2);
            env.UniqueID = Guid.NewGuid();
            msg2.Stage = "Stage1";
            msg2.TransactionID = started.TransactionID;
            jsonData += env.ToJson() + "\r\n";

            WorkStageCompleted msg3 = new WorkStageCompleted();
            env.MessageBody = msg3;
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(12);
            env.UniqueID = Guid.NewGuid();
            msg3.Stage = "Stage1";
            msg3.Result = WorkResult.COMPLETED;
            msg3.TransactionID = started.TransactionID;
            jsonData += env.ToJson() + "\r\n";

            msg2 = new WorkStageStarted();
            env.MessageBody = msg2;
            env.UniqueID = Guid.NewGuid();
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(13);
            msg2.Stage = "Stage2";
            msg2.TransactionID = started.TransactionID;
            jsonData += env.ToJson() + "\r\n";

            WorkStagePaused msg5 = new WorkStagePaused();
            env.MessageBody = msg5;
            env.UniqueID = Guid.NewGuid();
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(16);
            msg5.Stage = "Stage2";
            msg5.TransactionID = started.TransactionID;
            jsonData += env.ToJson() + "\r\n";

            WorkStageResumed msg6 = new WorkStageResumed();
            env.MessageBody = msg6;
            env.UniqueID = Guid.NewGuid();
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(18);
            msg6.Stage = "Stage2";
            msg6.TransactionID = started.TransactionID;
            jsonData += env.ToJson() + "\r\n";

            msg3 = new WorkStageCompleted();
            env.MessageBody = msg3;
            env.UniqueID = Guid.NewGuid();
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(24);
            msg3.Stage = "Stage2";
            msg3.Result = WorkResult.COMPLETED;
            msg3.TransactionID = started.TransactionID;
            jsonData += env.ToJson() + "\r\n";

            WorkCompleted msg4 = new WorkCompleted();
            env.MessageBody = msg4;
            env.Source = "MACHINE12345";
            env.TimeStamp = start.AddSeconds(24);
            env.UniqueID = Guid.NewGuid();
            msg4.TransactionID = started.TransactionID;
            msg4.Result = WorkResult.COMPLETED;
            jsonData += env.ToJson() + "\r\n";

            Clipboard.Clear();
            Clipboard.SetText(jsonData);
        }

        AmqpRequestProcessor receiveProcessor;
        AmqpEventChannel sendChannel;
        private string CFXHandle = "JJWClient1";
        private string ServerCFXHandle = "JJWClient2";

        private Timer timer1 = null;
        private Timer timer2 = null;
        private string address = "amqp://guest:guest@127.0.0.1:5672";
        private string address2 = "amqp://guest:guest@127.0.0.1:5673";
        
        private void ClientMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (receiveProcessor != null)
            {
                receiveProcessor.Close();
                receiveProcessor = null;
            }

            if (sendChannel != null)
            {
                sendChannel.CloseAll();
                sendChannel = null;
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (sendChannel == null)
            {
                sendChannel = new AmqpEventChannel()
                {
                    CFXHandle = this.CFXHandle
                };

                sendChannel.AddChannel(receiveProcessor.InboundAddress, receiveProcessor.RequestHandle);
                sendChannel.OnCFXMessageReceived += SendChannel_OnCFXMessageReceived;
            }

            CFXEnvelope env = new CFXEnvelope(new LockStationRequest { ReasonCode = LockReason.QualityIssue });
            sendChannel.Send(env, "request_receiver");
            //sendChannel.CloseAll();
            //sendChannel = null;
        }

        private void SendChannel_OnCFXMessageReceived(CFXEnvelope message)
        {
            CFXEnvelope msg = message;
            this.BeginInvoke((Action)(() =>
            {
                receivedBox.Text = receivedBox.Text + msg.ToJson();
            }));
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (receiveProcessor == null)
            {
                receiveProcessor = new AmqpRequestProcessor()
                {
                    InboundHostName = "127.0.0.1"
                };

                receiveProcessor.Open(this.ServerCFXHandle);
                receiveProcessor.OnRequestReceived += ReceiveProcessor_OnRequestReceived;
                receiveProcessor.OnMessageReceived += ReceiveProcessor_OnMessageReceived;

            }
        }

        private bool ReceiveProcessor_OnMessageReceived(CFXEnvelope message)
        {
            Debug.WriteLine(message.ToJson());
            return true;
        }

        private CFXEnvelope ReceiveProcessor_OnRequestReceived(CFXEnvelope request)
        {
            if (request.MessageBody is LockStationRequest)
            {
                return new CFXEnvelope(new LockStationResponse {  Result = StatusResult.SUCCESS });
            }

            return null;
        }
    }
}
