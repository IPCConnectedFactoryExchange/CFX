using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CFX;
using CFX.Structures;
using CFX.Transport;
using CFX.Production;
using CFX.ResourcePerformance;
using CFX.InformationSystem.UnitValidation;
using CFX.Sensor.Identification;
using System.Security.Cryptography.X509Certificates;

namespace CFXExampleEndpoint
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            theEndpoint = new AmqpCFXEndpoint();
            txtCFXHandle.Text = Properties.Settings.Default.CFXHandle;
            txtTransmitChannels.Text = Properties.Settings.Default.TransmitChannels;
            txtReceiveChannels.Text = Properties.Settings.Default.ReceiveChannels;
            txtRequestUri.Text = Properties.Settings.Default.RequestUri;
            reqUri.Text = Properties.Settings.Default.RequestTargetUri;
            reqHandle.Text = Properties.Settings.Default.RequestTargetHandle;
            reqUsername.Text = Properties.Settings.Default.RequestUsername;
            reqPassword.Text = Properties.Settings.Default.RequestPassword;

            //CFXExampleGenerator gen = new CFXExampleGenerator();
            //string result = gen.GenerateAll();
            //File.WriteAllText(@"y:\JJWCode\CFX_JSON_Examples.txt", result, Encoding.UTF8);
            //return;

            if (!string.IsNullOrWhiteSpace(CFXHandle))
                OpenEndpoint();

            RefreshControls();

            CFX.Utilities.AppLog.LoggingEnabled = true;
            CFX.Utilities.AppLog.LogFilePath = @"c:\stuff\mylog.txt";
            //CFX.Utilities.AppLog.AmqpTraceEnabled = false;
            CFX.Utilities.AppLog.LoggingLevel = CFX.Utilities.LogMessageType.Error | CFX.Utilities.LogMessageType.Info | CFX.Utilities.LogMessageType.Debug | CFX.Utilities.LogMessageType.Warn;
        }

        public string CFXHandle
        {
            get
            {
                return txtCFXHandle.Text;
            }
        }

        private List<AmqpChannelAddress> TransmitChannels
        {
            get
            {
                List<AmqpChannelAddress> result = new List<AmqpChannelAddress>();
                foreach (string s in txtTransmitChannels.Text.Split('\n'))
                {
                    string [] addr = s.Split(',');
                    if (addr.Length == 2)
                    {
                        result.Add(new AmqpChannelAddress { Uri = new Uri(addr[0]), Address = addr[1].Trim() });
                    }
                }

                return result;
            }
        }

        private List<AmqpChannelAddress> ReceiveChannels
        {
            get
            {
                List<AmqpChannelAddress> result = new List<AmqpChannelAddress>();
                foreach (string s in txtReceiveChannels.Text.Split('\n'))
                {
                    string[] addr = s.Split(',');
                    if (addr.Length == 2)
                    {
                        result.Add(new AmqpChannelAddress { Uri = new Uri(addr[0]), Address = addr[1].Trim() });
                    }
                }

                return result;
            }
        }

        private Uri RequestUri
        {
            get
            {
                string url = txtRequestUri.Text.Trim();
                if (string.IsNullOrWhiteSpace(url)) return null;
                Uri reqUri = new Uri(url);
                if (!string.IsNullOrWhiteSpace(reqUsername.Text))
                {
                    UriBuilder uriBuilder = new UriBuilder();
                    uriBuilder.Scheme = reqUri.Scheme;
                    uriBuilder.Host = reqUri.Host;
                    uriBuilder.Path = reqUri.PathAndQuery;
                    uriBuilder.Port = reqUri.Port;
                    uriBuilder.UserName = reqUsername.Text;
                    uriBuilder.Password = reqPassword.Text;
                    reqUri = uriBuilder.Uri;
                }

                return reqUri;
            }
        }

        public void OpenEndpoint()
        {
            CloseEndpoint();

            //AmqpCFXEndpoint.MaxMessagesPerTransmit = 1;

            try
            {
                theEndpoint = new AmqpCFXEndpoint();

                X509Certificate2 requestCert = null;
                if (RequestUri?.Scheme.ToLower() == "amqps")
                {
                    requestCert = AmqpUtilities.GetCertificate("aishqcfx01v");
                }

                theEndpoint.Open(CFXHandle, RequestUri, requestCert);
                theEndpoint.OnCFXMessageReceived -= TheEndpoint_OnCFXMessageReceived;
                theEndpoint.OnCFXMessageReceived += TheEndpoint_OnCFXMessageReceived;
                theEndpoint.OnRequestReceived -= TheEndpoint_OnRequestReceived;
                theEndpoint.OnRequestReceived += TheEndpoint_OnRequestReceived;

                //X509Certificate cert = AmqpUtilities.GetCertificate("aishqcfx01v");
                X509Certificate cert = null;
                //string targetHostName = "vhost:/jjwtesthost";
                string targetHostName = null; 

                foreach (AmqpChannelAddress addr in TransmitChannels)
                {
                    theEndpoint.AddPublishChannel(addr, AuthenticationMode.Auto, cert, targetHostName);
                }

                foreach (AmqpChannelAddress addr in ReceiveChannels)
                {
                    theEndpoint.AddSubscribeChannel(addr, AuthenticationMode.Auto, cert, targetHostName);
                }
            }
            catch (Exception ex)
            {
                lstResults.Items.Insert(0, "Exception Opening Endpoint:  " + ex.Message);
            }
        }

        private CFXEnvelope TheEndpoint_OnRequestReceived(CFXEnvelope request)
        {
            CFXMessage response = null;

            if (request.MessageBody is IdentifyUnitsRequest)
            {
                response = new IdentifyUnitsResponse()
                {
                    Result = new RequestResult()
                    {
                        Result = StatusResult.Success,
                        ResultCode = 0
                    },
                    PrimaryIdentifier = "UNIT-235445989494",
                    Units = new List<UnitPosition>(new UnitPosition[]
                    {
                        new UnitPosition()
                        {
                            UnitIdentifier = "UNIT-235445989494-A",
                            PositionNumber = 1
                        },
                        new UnitPosition()
                        {
                            UnitIdentifier = "UNIT-235445989494-B",
                            PositionNumber = 1
                        }
                    })
                };
            }

            if (response != null)
            {
                CFXEnvelope env = new CFXEnvelope(response);
                return env;
            }
            
            return null;
        }

        private const int maxResults = 10000;

        private void TheEndpoint_OnCFXMessageReceived(AmqpChannelAddress source, CFX.CFXEnvelope message)
        {
            this.BeginInvoke(((Action)(() =>
            {
                message.ToJson().Split(new string[] { "\r\n" }, StringSplitOptions.None).Reverse().ToList().ForEach(s => lstResults.Items.Insert(0, s));
                while (lstResults.Items.Count > maxResults)
                {
                    lstResults.Items.RemoveAt(maxResults);
                }
            })));
        }

        public void CloseEndpoint()
        {
            if (theEndpoint.IsOpen)
            {
                theEndpoint.OnCFXMessageReceived -= this.TheEndpoint_OnCFXMessageReceived;
                theEndpoint.Close();
            }
        }
        private void RefreshControls()
        {
            if (theEndpoint != null && theEndpoint.IsOpen)
            {
                btnOpen.Enabled = false;
                btnClose.Enabled = true;
                btnSendMsg.Enabled = true;
            }
            else
            {
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                btnSendMsg.Enabled = false;
            }

        }

        private AmqpCFXEndpoint theEndpoint;
        
        private void btnAddEventChannel_Click(object sender, EventArgs e)
        {
            if (CFXHandle == null)
            {
                MessageBox.Show("You must set your CFXHandle before adding event channels.");
                return;
            }

            AddChannelForm frm = new AddChannelForm(CFXHandle);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtTransmitChannels.Text += string.Format("{0},{1}\r\n", frm.NewUri, frm.NewAddress);
                if (theEndpoint.IsOpen)
                {
                    CloseEndpoint();
                    OpenEndpoint();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseEndpoint();

            Properties.Settings.Default.CFXHandle = CFXHandle;
            Properties.Settings.Default.TransmitChannels = txtTransmitChannels.Text;
            Properties.Settings.Default.ReceiveChannels = txtReceiveChannels.Text;
            Properties.Settings.Default.RequestUri = txtRequestUri.Text;
            Properties.Settings.Default.RequestTargetUri = reqUri.Text;
            Properties.Settings.Default.RequestTargetHandle = reqHandle.Text;
            Properties.Settings.Default.RequestUsername = reqUsername.Text;
            Properties.Settings.Default.RequestPassword = reqPassword.Text;
            Properties.Settings.Default.Save();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenEndpoint();
            RefreshControls();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseEndpoint();
            RefreshControls();
        }

        private void btnClearEventChannels_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTransmitChannels.Text))
            {
                txtTransmitChannels.Text = "";
                if (theEndpoint.IsOpen)
                {
                    CloseEndpoint();
                    OpenEndpoint();
                }
            }
        }

        private ResourceState lastState;
        private DateTime lastStateChange = DateTime.Now;

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (!theEndpoint.IsOpen) return;

            List<CFXEnvelope> messages = new List<CFXEnvelope>();

            //WorkStarted ws = new WorkStarted();
            //ws.TransactionID = Guid.NewGuid();
            //ws.Lane = "Lane1";
            //ws.Units.Add(new UnitPosition() { UnitIdentifier = "11122456", PositionNumber = 1, PositionName = "1" });
            //messages.Add(CFXEnvelope.FromCFXMessage(ws));

            //WorkCompleted wc = new WorkCompleted();
            //wc.TransactionID = ws.TransactionID;
            //wc.Result = WorkResult.Failed;
            //messages.Add(CFXEnvelope.FromCFXMessage(wc));

            ResourceState[] states = new ResourceState []
            {
                ResourceState.Setup,
                ResourceState.ReadyProcessingExecuting,
                ResourceState.Idle
            };

            ResourceState newState = lastState;
            Random r = new Random();
            while (newState == lastState)
            {
                newState = states[r.Next(0, 2)];
            }

            CFXEnvelope env = new CFXEnvelope(new StationStateChanged()
            {
                NewState = newState,
                OldState = lastState,
                OldStateDuration = DateTime.Now - lastStateChange
            });
            messages.Add(env);

            lastState = (env.MessageBody as StationStateChanged).NewState;
            lastStateChange = DateTime.Now;
            
            //theEndpoint.Publish(ws);
            theEndpoint.PublishMany(messages);
        }

        private void btnAddReceiveChannel_Click(object sender, EventArgs e)
        {
            if (CFXHandle == null)
            {
                MessageBox.Show("You must set your CFXHandle before adding event channels.");
                return;
            }

            AddChannelForm frm = new AddChannelForm(CFXHandle);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtReceiveChannels.Text += string.Format("{0},{1}\r\n", frm.NewUri, frm.NewAddress);
                if (theEndpoint.IsOpen)
                {
                    CloseEndpoint();
                    OpenEndpoint();
                }
            }
        }

        private void btnClearReceiveChannels_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtReceiveChannels.Text))
            {
                txtReceiveChannels.Text = "";
                if (theEndpoint.IsOpen)
                {
                    CloseEndpoint();
                    OpenEndpoint();
                }
            }
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            CFXEnvelope request = new CFXEnvelope("CFX.Sensor.Identification.IdentifyUnitsRequest");
            request.Source = CFXHandle;
            request.Target = reqHandle.Text;

            string target = reqUri.Text;

            CFXEnvelope response = null;
            try
            {
                response = theEndpoint.ExecuteRequest(target, request);
            }
            catch (Exception ex)
            {
                lstResults.Items.Insert(0, "Exception during request process:  " + ex.Message);
            }

            if (response != null) response.ToJson().Split(new string[] { "\r\n" }, StringSplitOptions.None).Reverse().ToList().ForEach(s => lstResults.Items.Insert(0, s));
        }
    }
}
