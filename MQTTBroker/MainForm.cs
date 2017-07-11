using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;

namespace MQTTBroker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private MqttBroker theBroker = null;

        private void MainForm_Load(object sender, EventArgs e)
        {
            theBroker = new MqttBroker();
            theBroker.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (theBroker != null)
            {
                theBroker.Stop();
                theBroker = null;
            }
        }
    }
}
