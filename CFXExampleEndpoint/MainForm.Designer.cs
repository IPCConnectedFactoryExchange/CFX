namespace CFXExampleEndpoint
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtTransmitChannels = new System.Windows.Forms.TextBox();
            this.btnAddTransmitChannel = new System.Windows.Forms.Button();
            this.btnClearTransmitChannels = new System.Windows.Forms.Button();
            this.txtCFXHandle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtRequestUri = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClearReceiveChannels = new System.Windows.Forms.Button();
            this.btnAddReceiveChannel = new System.Windows.Forms.Button();
            this.txtReceiveChannels = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reqHandle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.reqUri = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRequest = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.reqPassword = new System.Windows.Forms.TextBox();
            this.reqUsername = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Publish Channels:";
            // 
            // txtTransmitChannels
            // 
            this.txtTransmitChannels.Location = new System.Drawing.Point(137, 30);
            this.txtTransmitChannels.Multiline = true;
            this.txtTransmitChannels.Name = "txtTransmitChannels";
            this.txtTransmitChannels.ReadOnly = true;
            this.txtTransmitChannels.Size = new System.Drawing.Size(276, 53);
            this.txtTransmitChannels.TabIndex = 2;
            // 
            // btnAddTransmitChannel
            // 
            this.btnAddTransmitChannel.Location = new System.Drawing.Point(419, 30);
            this.btnAddTransmitChannel.Name = "btnAddTransmitChannel";
            this.btnAddTransmitChannel.Size = new System.Drawing.Size(49, 20);
            this.btnAddTransmitChannel.TabIndex = 0;
            this.btnAddTransmitChannel.Text = "+";
            this.btnAddTransmitChannel.UseVisualStyleBackColor = true;
            this.btnAddTransmitChannel.Click += new System.EventHandler(this.btnAddEventChannel_Click);
            // 
            // btnClearTransmitChannels
            // 
            this.btnClearTransmitChannels.Location = new System.Drawing.Point(474, 30);
            this.btnClearTransmitChannels.Name = "btnClearTransmitChannels";
            this.btnClearTransmitChannels.Size = new System.Drawing.Size(49, 20);
            this.btnClearTransmitChannels.TabIndex = 1;
            this.btnClearTransmitChannels.Text = "Clear";
            this.btnClearTransmitChannels.UseVisualStyleBackColor = true;
            this.btnClearTransmitChannels.Click += new System.EventHandler(this.btnClearEventChannels_Click);
            // 
            // txtCFXHandle
            // 
            this.txtCFXHandle.Location = new System.Drawing.Point(114, 22);
            this.txtCFXHandle.Name = "txtCFXHandle";
            this.txtCFXHandle.Size = new System.Drawing.Size(153, 20);
            this.txtCFXHandle.TabIndex = 0;
            this.txtCFXHandle.Text = "CFXEndpoint1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "CFX Handle";
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(1006, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 20);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(937, 21);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(63, 20);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Enabled = false;
            this.btnSendMsg.Location = new System.Drawing.Point(137, 89);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(92, 25);
            this.btnSendMsg.TabIndex = 10;
            this.btnSendMsg.Text = "Send Msg";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtRequestUri
            // 
            this.txtRequestUri.Location = new System.Drawing.Point(342, 22);
            this.txtRequestUri.Name = "txtRequestUri";
            this.txtRequestUri.Size = new System.Drawing.Size(151, 20);
            this.txtRequestUri.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Request Uri";
            // 
            // btnClearReceiveChannels
            // 
            this.btnClearReceiveChannels.Location = new System.Drawing.Point(1020, 28);
            this.btnClearReceiveChannels.Name = "btnClearReceiveChannels";
            this.btnClearReceiveChannels.Size = new System.Drawing.Size(49, 20);
            this.btnClearReceiveChannels.TabIndex = 4;
            this.btnClearReceiveChannels.Text = "Clear";
            this.btnClearReceiveChannels.UseVisualStyleBackColor = true;
            this.btnClearReceiveChannels.Click += new System.EventHandler(this.btnClearReceiveChannels_Click);
            // 
            // btnAddReceiveChannel
            // 
            this.btnAddReceiveChannel.Location = new System.Drawing.Point(965, 28);
            this.btnAddReceiveChannel.Name = "btnAddReceiveChannel";
            this.btnAddReceiveChannel.Size = new System.Drawing.Size(49, 20);
            this.btnAddReceiveChannel.TabIndex = 3;
            this.btnAddReceiveChannel.Text = "+";
            this.btnAddReceiveChannel.UseVisualStyleBackColor = true;
            this.btnAddReceiveChannel.Click += new System.EventHandler(this.btnAddReceiveChannel_Click);
            // 
            // txtReceiveChannels
            // 
            this.txtReceiveChannels.Location = new System.Drawing.Point(683, 29);
            this.txtReceiveChannels.Multiline = true;
            this.txtReceiveChannels.Name = "txtReceiveChannels";
            this.txtReceiveChannels.ReadOnly = true;
            this.txtReceiveChannels.Size = new System.Drawing.Size(276, 53);
            this.txtReceiveChannels.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(555, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Subscribe Channels:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reqHandle);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.reqUri);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnRequest);
            this.groupBox1.Controls.Add(this.btnClearReceiveChannels);
            this.groupBox1.Controls.Add(this.btnAddReceiveChannel);
            this.groupBox1.Controls.Add(this.txtReceiveChannels);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSendMsg);
            this.groupBox1.Controls.Add(this.btnClearTransmitChannels);
            this.groupBox1.Controls.Add(this.btnAddTransmitChannel);
            this.groupBox1.Controls.Add(this.txtTransmitChannels);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1090, 152);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Event Channels";
            // 
            // reqHandle
            // 
            this.reqHandle.Location = new System.Drawing.Point(683, 119);
            this.reqHandle.Name = "reqHandle";
            this.reqHandle.Size = new System.Drawing.Size(276, 20);
            this.reqHandle.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(555, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Target Handle:";
            // 
            // reqUri
            // 
            this.reqUri.Location = new System.Drawing.Point(683, 93);
            this.reqUri.Name = "reqUri";
            this.reqUri.Size = new System.Drawing.Size(276, 20);
            this.reqUri.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(555, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Target Uri:";
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(965, 89);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(93, 25);
            this.btnRequest.TabIndex = 14;
            this.btnRequest.Text = "Send Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.reqPassword);
            this.groupBox2.Controls.Add(this.reqUsername);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtRequestUri);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnOpen);
            this.groupBox2.Controls.Add(this.txtCFXHandle);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(17, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1081, 56);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "This Endpoint";
            // 
            // reqPassword
            // 
            this.reqPassword.Location = new System.Drawing.Point(784, 22);
            this.reqPassword.Name = "reqPassword";
            this.reqPassword.PasswordChar = '*';
            this.reqPassword.Size = new System.Drawing.Size(118, 20);
            this.reqPassword.TabIndex = 14;
            this.reqPassword.Text = "5673";
            // 
            // reqUsername
            // 
            this.reqUsername.Location = new System.Drawing.Point(660, 22);
            this.reqUsername.Name = "reqUsername";
            this.reqUsername.Size = new System.Drawing.Size(118, 20);
            this.reqUsername.TabIndex = 12;
            this.reqUsername.Text = "5673";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Request Username / Password";
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(17, 226);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(1090, 381);
            this.lstResults.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 616);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "CFX Endpoint (Example Application)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTransmitChannels;
        private System.Windows.Forms.Button btnAddTransmitChannel;
        private System.Windows.Forms.Button btnClearTransmitChannels;
        private System.Windows.Forms.TextBox txtCFXHandle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtRequestUri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClearReceiveChannels;
        private System.Windows.Forms.Button btnAddReceiveChannel;
        private System.Windows.Forms.TextBox txtReceiveChannels;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.TextBox reqHandle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox reqUri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox reqPassword;
        private System.Windows.Forms.TextBox reqUsername;
        private System.Windows.Forms.Label label7;
    }
}

