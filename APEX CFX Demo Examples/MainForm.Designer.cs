namespace APEX_CFX_Demo_Examples
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMyHandle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPublishStateChange = new System.Windows.Forms.Button();
            this.btnMakeValidateRequest = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMyHandle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initialize";
            // 
            // txtMyHandle
            // 
            this.txtMyHandle.Location = new System.Drawing.Point(93, 21);
            this.txtMyHandle.Name = "txtMyHandle";
            this.txtMyHandle.Size = new System.Drawing.Size(263, 20);
            this.txtMyHandle.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "My CFX Handle";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(446, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(365, 19);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "OPEN";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnPublishStateChange
            // 
            this.btnPublishStateChange.Location = new System.Drawing.Point(12, 95);
            this.btnPublishStateChange.Name = "btnPublishStateChange";
            this.btnPublishStateChange.Size = new System.Drawing.Size(533, 23);
            this.btnPublishStateChange.TabIndex = 4;
            this.btnPublishStateChange.Text = "PUBLISH StationStateChanged Event";
            this.btnPublishStateChange.UseVisualStyleBackColor = true;
            this.btnPublishStateChange.Click += new System.EventHandler(this.btnPublishStateChange_Click);
            // 
            // btnMakeValidateRequest
            // 
            this.btnMakeValidateRequest.Location = new System.Drawing.Point(12, 140);
            this.btnMakeValidateRequest.Name = "btnMakeValidateRequest";
            this.btnMakeValidateRequest.Size = new System.Drawing.Size(533, 23);
            this.btnMakeValidateRequest.TabIndex = 5;
            this.btnMakeValidateRequest.Text = "SEND ValidateUnitsRequest REQUEST";
            this.btnMakeValidateRequest.UseVisualStyleBackColor = true;
            this.btnMakeValidateRequest.Click += new System.EventHandler(this.btnMakeValidateRequest_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstResults);
            this.groupBox2.Location = new System.Drawing.Point(14, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 392);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(16, 31);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(503, 316);
            this.lstResults.TabIndex = 0;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(30, 544);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(106, 23);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy Results";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 588);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnMakeValidateRequest);
            this.Controls.Add(this.btnPublishStateChange);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "APEX CFX Demo Example";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMyHandle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnPublishStateChange;
        private System.Windows.Forms.Button btnMakeValidateRequest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Button btnCopy;
    }
}

