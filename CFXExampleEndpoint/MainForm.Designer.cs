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
            this.btnDeserializeOfflineJson = new System.Windows.Forms.Button();
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
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Publish Channels:";
            // 
            // txtTransmitChannels
            // 
            this.txtTransmitChannels.Location = new System.Drawing.Point(183, 37);
            this.txtTransmitChannels.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransmitChannels.Multiline = true;
            this.txtTransmitChannels.Name = "txtTransmitChannels";
            this.txtTransmitChannels.ReadOnly = true;
            this.txtTransmitChannels.Size = new System.Drawing.Size(367, 64);
            this.txtTransmitChannels.TabIndex = 2;
            // 
            // btnAddTransmitChannel
            // 
            this.btnAddTransmitChannel.Location = new System.Drawing.Point(559, 37);
            this.btnAddTransmitChannel.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTransmitChannel.Name = "btnAddTransmitChannel";
            this.btnAddTransmitChannel.Size = new System.Drawing.Size(65, 25);
            this.btnAddTransmitChannel.TabIndex = 0;
            this.btnAddTransmitChannel.Text = "+";
            this.btnAddTransmitChannel.UseVisualStyleBackColor = true;
            this.btnAddTransmitChannel.Click += new System.EventHandler(this.btnAddEventChannel_Click);
            // 
            // btnClearTransmitChannels
            // 
            this.btnClearTransmitChannels.Location = new System.Drawing.Point(632, 37);
            this.btnClearTransmitChannels.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearTransmitChannels.Name = "btnClearTransmitChannels";
            this.btnClearTransmitChannels.Size = new System.Drawing.Size(65, 25);
            this.btnClearTransmitChannels.TabIndex = 1;
            this.btnClearTransmitChannels.Text = "Clear";
            this.btnClearTransmitChannels.UseVisualStyleBackColor = true;
            this.btnClearTransmitChannels.Click += new System.EventHandler(this.btnClearEventChannels_Click);
            // 
            // txtCFXHandle
            // 
            this.txtCFXHandle.Location = new System.Drawing.Point(152, 27);
            this.txtCFXHandle.Margin = new System.Windows.Forms.Padding(4);
            this.txtCFXHandle.Name = "txtCFXHandle";
            this.txtCFXHandle.Size = new System.Drawing.Size(203, 22);
            this.txtCFXHandle.TabIndex = 0;
            this.txtCFXHandle.Text = "CFXEndpoint1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "CFX Handle";
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(1341, 26);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(1249, 26);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(84, 25);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Enabled = false;
            this.btnSendMsg.Location = new System.Drawing.Point(183, 110);
            this.btnSendMsg.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(123, 31);
            this.btnSendMsg.TabIndex = 10;
            this.btnSendMsg.Text = "Send Msg";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtRequestUri
            // 
            this.txtRequestUri.Location = new System.Drawing.Point(456, 27);
            this.txtRequestUri.Margin = new System.Windows.Forms.Padding(4);
            this.txtRequestUri.Name = "txtRequestUri";
            this.txtRequestUri.Size = new System.Drawing.Size(200, 22);
            this.txtRequestUri.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Request Uri";
            // 
            // btnClearReceiveChannels
            // 
            this.btnClearReceiveChannels.Location = new System.Drawing.Point(1360, 34);
            this.btnClearReceiveChannels.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearReceiveChannels.Name = "btnClearReceiveChannels";
            this.btnClearReceiveChannels.Size = new System.Drawing.Size(65, 25);
            this.btnClearReceiveChannels.TabIndex = 4;
            this.btnClearReceiveChannels.Text = "Clear";
            this.btnClearReceiveChannels.UseVisualStyleBackColor = true;
            this.btnClearReceiveChannels.Click += new System.EventHandler(this.btnClearReceiveChannels_Click);
            // 
            // btnAddReceiveChannel
            // 
            this.btnAddReceiveChannel.Location = new System.Drawing.Point(1287, 34);
            this.btnAddReceiveChannel.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddReceiveChannel.Name = "btnAddReceiveChannel";
            this.btnAddReceiveChannel.Size = new System.Drawing.Size(65, 25);
            this.btnAddReceiveChannel.TabIndex = 3;
            this.btnAddReceiveChannel.Text = "+";
            this.btnAddReceiveChannel.UseVisualStyleBackColor = true;
            this.btnAddReceiveChannel.Click += new System.EventHandler(this.btnAddReceiveChannel_Click);
            // 
            // txtReceiveChannels
            // 
            this.txtReceiveChannels.Location = new System.Drawing.Point(911, 36);
            this.txtReceiveChannels.Margin = new System.Windows.Forms.Padding(4);
            this.txtReceiveChannels.Multiline = true;
            this.txtReceiveChannels.Name = "txtReceiveChannels";
            this.txtReceiveChannels.ReadOnly = true;
            this.txtReceiveChannels.Size = new System.Drawing.Size(367, 64);
            this.txtReceiveChannels.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(740, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Subscribe Channels:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeserializeOfflineJson);
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
            this.groupBox1.Location = new System.Drawing.Point(23, 84);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1453, 187);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Event Channels";
            // 
            // btnDeserializeOfflineJson
            // 
            this.btnDeserializeOfflineJson.Location = new System.Drawing.Point(183, 145);
            this.btnDeserializeOfflineJson.Name = "btnDeserializeOfflineJson";
            this.btnDeserializeOfflineJson.Size = new System.Drawing.Size(123, 35);
            this.btnDeserializeOfflineJson.TabIndex = 19;
            this.btnDeserializeOfflineJson.Text = "Deserialize Json";
            this.btnDeserializeOfflineJson.UseVisualStyleBackColor = true;
            this.btnDeserializeOfflineJson.Click += new System.EventHandler(this.btnDeserializeOfflineJson_Click);
            // 
            // reqHandle
            // 
            this.reqHandle.Location = new System.Drawing.Point(911, 146);
            this.reqHandle.Margin = new System.Windows.Forms.Padding(4);
            this.reqHandle.Name = "reqHandle";
            this.reqHandle.Size = new System.Drawing.Size(367, 22);
            this.reqHandle.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(740, 149);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Target Handle:";
            // 
            // reqUri
            // 
            this.reqUri.Location = new System.Drawing.Point(911, 114);
            this.reqUri.Margin = new System.Windows.Forms.Padding(4);
            this.reqUri.Name = "reqUri";
            this.reqUri.Size = new System.Drawing.Size(367, 22);
            this.reqUri.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(740, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Target Uri:";
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(1287, 110);
            this.btnRequest.Margin = new System.Windows.Forms.Padding(4);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(124, 31);
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
            this.groupBox2.Location = new System.Drawing.Point(23, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1441, 69);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "This Endpoint";
            // 
            // reqPassword
            // 
            this.reqPassword.Location = new System.Drawing.Point(1045, 27);
            this.reqPassword.Margin = new System.Windows.Forms.Padding(4);
            this.reqPassword.Name = "reqPassword";
            this.reqPassword.PasswordChar = '*';
            this.reqPassword.Size = new System.Drawing.Size(156, 22);
            this.reqPassword.TabIndex = 14;
            this.reqPassword.Text = "5673";
            // 
            // reqUsername
            // 
            this.reqUsername.Location = new System.Drawing.Point(880, 27);
            this.reqUsername.Margin = new System.Windows.Forms.Padding(4);
            this.reqUsername.Name = "reqUsername";
            this.reqUsername.Size = new System.Drawing.Size(156, 22);
            this.reqUsername.TabIndex = 12;
            this.reqUsername.Text = "5673";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(665, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Request Username / Password";
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 16;
            this.lstResults.Location = new System.Drawing.Point(23, 278);
            this.lstResults.Margin = new System.Windows.Forms.Padding(4);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(1452, 468);
            this.lstResults.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 758);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button btnDeserializeOfflineJson;
    }
}

