using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CFX;
using CFX.Transport;
using CFX.Production;

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
            txtRequestPort.Text = Properties.Settings.Default.RequestPort;
            
            if (!string.IsNullOrWhiteSpace(CFXHandle))
                OpenEndpoint();

            RefreshControls();
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
                foreach (string s in txtTransmitChannels.Text.Split(';'))
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
                foreach (string s in txtReceiveChannels.Text.Split(';'))
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

        public int RequestPort
        {
            get
            {
                if (txtRequestPort.Text.Trim().Length > 0)
                    return Convert.ToInt32(txtRequestPort.Text.Trim());
                else
                    return 5673;
            }
        }

        public Uri RequestUri
        {
            get
            {
                return new Uri(string.Format("amqp://{0}:{1}", Environment.MachineName, RequestPort));
            }
        }

        public void OpenEndpoint()
        {
            CloseEndpoint();

            theEndpoint = new AmqpCFXEndpoint();
            theEndpoint.Open(CFXHandle, RequestUri);
            theEndpoint.OnCFXMessageReceived -= TheEndpoint_OnCFXMessageReceived;
            theEndpoint.OnCFXMessageReceived += TheEndpoint_OnCFXMessageReceived;

            foreach (AmqpChannelAddress addr in TransmitChannels)
            {
                theEndpoint.AddTransmitChannel(addr);
            }

            foreach (AmqpChannelAddress addr in ReceiveChannels)
            {
                theEndpoint.AddReceiverChannel(addr);
            }
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
            Properties.Settings.Default.RequestPort = txtRequestPort.Text;
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

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (!theEndpoint.IsOpen) return;

            WorkStarted ws = new WorkStarted();
            ws.Lane = "Lane1";
            ws.UnitCount = 1;
            ws.UnitLocations.Add(new UnitLocation() { UnitIdentifier = "11122456", LocationIdentifier = "1" });
            theEndpoint.SendMessage(ws);
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
            if (!string.IsNullOrWhiteSpace(txtTransmitChannels.Text))
            {
                txtReceiveChannels.Text = "";
                if (theEndpoint.IsOpen)
                {
                    CloseEndpoint();
                    OpenEndpoint();
                }
            }
        }
    }
}
