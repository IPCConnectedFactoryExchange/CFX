using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CFX.Transport;

namespace CFXExampleEndpoint
{
    public partial class AddChannelForm : Form
    {
        public AddChannelForm(string cfxHandle)
        {
            CFXHandle = cfxHandle;
            InitializeComponent();

            txtAddress.Select(txtAddress.Text.Length, 0);
        }

        private string CFXHandle;

        private void btnTest_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Exception ex;
            AmqpCFXEndpoint endPoint = new AmqpCFXEndpoint();
            if (!endPoint.TestChannel(new Uri(txtAddress.Text), AuthenticationMode.Auto, out ex))
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { 
                MessageBox.Show("Connection Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public Uri NewUri
        {
            get;
            private set;
        }

        public string NewAddress
        {
            get;
            private set;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri(txtAddress.Text);
            if (string.IsNullOrWhiteSpace(uri.Host))
            {
                MessageBox.Show("You must specify a network address for the new channel.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (uri.Port <= 0)
            {
                uri = new Uri(uri.ToString() + ":5672");
            }

            if (string.IsNullOrWhiteSpace(txtTarget.Text))
            {
                MessageBox.Show("You must specify an AMQP address for the new channel.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }

            NewUri = new Uri(txtAddress.Text);
            NewAddress = txtTarget.Text;
        }
    }
}
