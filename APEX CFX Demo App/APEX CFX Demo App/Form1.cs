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
using CFX.Structures;
using CFX.ResourcePerformance;
using CFX.Transport;

namespace APEX_CFX_Demo_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lastStateChange = DateTime.Now;
        }

        AmqpCFXEndpoint theEndpoint;
        string myHandle = "MyCompany.MyMachineModel.MyMachineSerialNumber";
        string myBroker = "amqp://cfx.aiscorp.com:5672";
        string myExchange = "/exchange/AegisCloud";

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (theEndpoint != null) btnClose_Click(sender, e);

            theEndpoint = new AmqpCFXEndpoint();
            theEndpoint.Open(myHandle);
            theEndpoint.AddPublishChannel(new Uri(myBroker), myExchange);
            btnSend.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            if (theEndpoint != null)
            {
                theEndpoint.Close();
                theEndpoint = null;
            }
        }

        private ResourceState currentState = ResourceState.Off;
        private DateTime lastStateChange;

        private void btnSend_Click(object sender, EventArgs e)
        {
            CFXEnvelope msg;

            if (currentState == ResourceState.Off)
            {
                msg = new CFXEnvelope(new StationStateChanged()
                {
                    NewState = ResourceState.On,
                    OldState = currentState,
                    OldStateDuration = DateTime.Now - lastStateChange,
                });
            }
            else
            {
                msg = new CFXEnvelope(new StationStateChanged()
                {
                    NewState = ResourceState.Off,
                    OldState = currentState,
                    OldStateDuration = DateTime.Now - lastStateChange,
                });
            }

            lastStateChange = msg.TimeStamp;
            currentState = (msg.MessageBody as StationStateChanged).NewState;

            theEndpoint.Publish(msg);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnClose_Click(sender, e);
        }
    }
}
