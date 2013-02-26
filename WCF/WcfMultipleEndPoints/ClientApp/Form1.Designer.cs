namespace ClientApp
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpTimes = new System.Windows.Forms.GroupBox();
            this.lblElapsedTimeSEC = new System.Windows.Forms.Label();
            this.txtElapsedTimeSec = new System.Windows.Forms.TextBox();
            this.lblElapsedtimeMS = new System.Windows.Forms.Label();
            this.txtElapsedTimeMs = new System.Windows.Forms.TextBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkShowMessages = new System.Windows.Forms.CheckBox();
            this.lblIterations = new System.Windows.Forms.Label();
            this.iterations = new System.Windows.Forms.NumericUpDown();
            this.grpEndpoint = new System.Windows.Forms.GroupBox();
            this.btnWsSecure = new System.Windows.Forms.Button();
            this.btnNetTcp = new System.Windows.Forms.Button();
            this.btnWsPlain = new System.Windows.Forms.Button();
            this.btnBasic = new System.Windows.Forms.Button();
            this.grpMethod = new System.Windows.Forms.GroupBox();
            this.rbGetUsername = new System.Windows.Forms.RadioButton();
            this.howManyPeople = new System.Windows.Forms.NumericUpDown();
            this.rbGetPeople = new System.Windows.Forms.RadioButton();
            this.rbAddTwoNumbers = new System.Windows.Forms.RadioButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.txtRequestData = new System.Windows.Forms.RichTextBox();
            this.requestHeader = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtResponseData = new System.Windows.Forms.RichTextBox();
            this.responseHeader = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.panel1.SuspendLayout();
            this.grpTimes.SuspendLayout();
            this.grpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iterations)).BeginInit();
            this.grpEndpoint.SuspendLayout();
            this.grpMethod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.howManyPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.requestHeader.SuspendLayout();
            this.responseHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpTimes);
            this.panel1.Controls.Add(this.grpOptions);
            this.panel1.Controls.Add(this.grpEndpoint);
            this.panel1.Controls.Add(this.grpMethod);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 480);
            this.panel1.TabIndex = 1;
            // 
            // grpTimes
            // 
            this.grpTimes.Controls.Add(this.lblElapsedTimeSEC);
            this.grpTimes.Controls.Add(this.txtElapsedTimeSec);
            this.grpTimes.Controls.Add(this.lblElapsedtimeMS);
            this.grpTimes.Controls.Add(this.txtElapsedTimeMs);
            this.grpTimes.Location = new System.Drawing.Point(12, 244);
            this.grpTimes.Name = "grpTimes";
            this.grpTimes.Size = new System.Drawing.Size(298, 60);
            this.grpTimes.TabIndex = 23;
            this.grpTimes.TabStop = false;
            this.grpTimes.Text = "Elapsed Times";
            // 
            // lblElapsedTimeSEC
            // 
            this.lblElapsedTimeSEC.AutoSize = true;
            this.lblElapsedTimeSEC.Location = new System.Drawing.Point(167, 26);
            this.lblElapsedTimeSEC.Name = "lblElapsedTimeSEC";
            this.lblElapsedTimeSEC.Size = new System.Drawing.Size(49, 13);
            this.lblElapsedTimeSEC.TabIndex = 24;
            this.lblElapsedTimeSEC.Text = "Seconds";
            // 
            // txtElapsedTimeSec
            // 
            this.txtElapsedTimeSec.Location = new System.Drawing.Point(222, 23);
            this.txtElapsedTimeSec.Name = "txtElapsedTimeSec";
            this.txtElapsedTimeSec.ReadOnly = true;
            this.txtElapsedTimeSec.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtElapsedTimeSec.Size = new System.Drawing.Size(68, 20);
            this.txtElapsedTimeSec.TabIndex = 23;
            // 
            // lblElapsedtimeMS
            // 
            this.lblElapsedtimeMS.AutoSize = true;
            this.lblElapsedtimeMS.Location = new System.Drawing.Point(11, 26);
            this.lblElapsedtimeMS.Name = "lblElapsedtimeMS";
            this.lblElapsedtimeMS.Size = new System.Drawing.Size(64, 13);
            this.lblElapsedtimeMS.TabIndex = 22;
            this.lblElapsedtimeMS.Text = "Milliseconds";
            // 
            // txtElapsedTimeMs
            // 
            this.txtElapsedTimeMs.Location = new System.Drawing.Point(81, 23);
            this.txtElapsedTimeMs.Name = "txtElapsedTimeMs";
            this.txtElapsedTimeMs.ReadOnly = true;
            this.txtElapsedTimeMs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtElapsedTimeMs.Size = new System.Drawing.Size(65, 20);
            this.txtElapsedTimeMs.TabIndex = 21;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkShowMessages);
            this.grpOptions.Controls.Add(this.lblIterations);
            this.grpOptions.Controls.Add(this.iterations);
            this.grpOptions.Location = new System.Drawing.Point(12, 170);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(298, 68);
            this.grpOptions.TabIndex = 22;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // chkShowMessages
            // 
            this.chkShowMessages.AutoSize = true;
            this.chkShowMessages.Location = new System.Drawing.Point(161, 26);
            this.chkShowMessages.Name = "chkShowMessages";
            this.chkShowMessages.Size = new System.Drawing.Size(110, 17);
            this.chkShowMessages.TabIndex = 20;
            this.chkShowMessages.Text = "Display messages";
            this.chkShowMessages.UseVisualStyleBackColor = true;
            // 
            // lblIterations
            // 
            this.lblIterations.AutoSize = true;
            this.lblIterations.Location = new System.Drawing.Point(11, 26);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(50, 13);
            this.lblIterations.TabIndex = 19;
            this.lblIterations.Text = "Iterations";
            // 
            // iterations
            // 
            this.iterations.Location = new System.Drawing.Point(67, 24);
            this.iterations.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.iterations.Name = "iterations";
            this.iterations.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.iterations.Size = new System.Drawing.Size(67, 20);
            this.iterations.TabIndex = 18;
            this.iterations.ThousandsSeparator = true;
            this.iterations.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.iterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // grpEndpoint
            // 
            this.grpEndpoint.Controls.Add(this.btnWsSecure);
            this.grpEndpoint.Controls.Add(this.btnNetTcp);
            this.grpEndpoint.Controls.Add(this.btnWsPlain);
            this.grpEndpoint.Controls.Add(this.btnBasic);
            this.grpEndpoint.Location = new System.Drawing.Point(164, 12);
            this.grpEndpoint.Name = "grpEndpoint";
            this.grpEndpoint.Size = new System.Drawing.Size(146, 152);
            this.grpEndpoint.TabIndex = 21;
            this.grpEndpoint.TabStop = false;
            this.grpEndpoint.Text = "Endpoint To Use";
            // 
            // btnWsSecure
            // 
            this.btnWsSecure.Location = new System.Drawing.Point(9, 79);
            this.btnWsSecure.Name = "btnWsSecure";
            this.btnWsSecure.Size = new System.Drawing.Size(129, 23);
            this.btnWsSecure.TabIndex = 18;
            this.btnWsSecure.Text = "WsSecure";
            this.btnWsSecure.UseVisualStyleBackColor = true;
            this.btnWsSecure.Click += new System.EventHandler(this.btnWsSecure_Click);
            // 
            // btnNetTcp
            // 
            this.btnNetTcp.Location = new System.Drawing.Point(9, 108);
            this.btnNetTcp.Name = "btnNetTcp";
            this.btnNetTcp.Size = new System.Drawing.Size(129, 23);
            this.btnNetTcp.TabIndex = 17;
            this.btnNetTcp.Text = "NetTcp";
            this.btnNetTcp.UseVisualStyleBackColor = true;
            this.btnNetTcp.Click += new System.EventHandler(this.btnNetTcp_Click);
            // 
            // btnWsPlain
            // 
            this.btnWsPlain.Location = new System.Drawing.Point(9, 50);
            this.btnWsPlain.Name = "btnWsPlain";
            this.btnWsPlain.Size = new System.Drawing.Size(129, 23);
            this.btnWsPlain.TabIndex = 16;
            this.btnWsPlain.Text = "WsPlain";
            this.btnWsPlain.UseVisualStyleBackColor = true;
            this.btnWsPlain.Click += new System.EventHandler(this.btnWsPlain_Click);
            // 
            // btnBasic
            // 
            this.btnBasic.Location = new System.Drawing.Point(9, 21);
            this.btnBasic.Name = "btnBasic";
            this.btnBasic.Size = new System.Drawing.Size(129, 23);
            this.btnBasic.TabIndex = 15;
            this.btnBasic.Text = "Basic";
            this.btnBasic.UseVisualStyleBackColor = true;
            this.btnBasic.Click += new System.EventHandler(this.btnBasic_Click);
            // 
            // grpMethod
            // 
            this.grpMethod.Controls.Add(this.rbGetUsername);
            this.grpMethod.Controls.Add(this.howManyPeople);
            this.grpMethod.Controls.Add(this.rbGetPeople);
            this.grpMethod.Controls.Add(this.rbAddTwoNumbers);
            this.grpMethod.Location = new System.Drawing.Point(12, 12);
            this.grpMethod.Name = "grpMethod";
            this.grpMethod.Size = new System.Drawing.Size(146, 152);
            this.grpMethod.TabIndex = 9;
            this.grpMethod.TabStop = false;
            this.grpMethod.Text = "Method To Call";
            // 
            // rbGetUsername
            // 
            this.rbGetUsername.AutoSize = true;
            this.rbGetUsername.Location = new System.Drawing.Point(14, 90);
            this.rbGetUsername.Name = "rbGetUsername";
            this.rbGetUsername.Size = new System.Drawing.Size(90, 17);
            this.rbGetUsername.TabIndex = 3;
            this.rbGetUsername.Text = "GetUsername";
            this.rbGetUsername.UseVisualStyleBackColor = true;
            // 
            // howManyPeople
            // 
            this.howManyPeople.Enabled = false;
            this.howManyPeople.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.howManyPeople.Location = new System.Drawing.Point(49, 66);
            this.howManyPeople.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.howManyPeople.Name = "howManyPeople";
            this.howManyPeople.Size = new System.Drawing.Size(57, 20);
            this.howManyPeople.TabIndex = 2;
            this.howManyPeople.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // rbGetPeople
            // 
            this.rbGetPeople.AutoSize = true;
            this.rbGetPeople.Location = new System.Drawing.Point(14, 43);
            this.rbGetPeople.Name = "rbGetPeople";
            this.rbGetPeople.Size = new System.Drawing.Size(75, 17);
            this.rbGetPeople.TabIndex = 1;
            this.rbGetPeople.Text = "GetPeople";
            this.rbGetPeople.UseVisualStyleBackColor = true;
            this.rbGetPeople.CheckedChanged += new System.EventHandler(this.rbGetPeople_CheckedChanged);
            // 
            // rbAddTwoNumbers
            // 
            this.rbAddTwoNumbers.AutoSize = true;
            this.rbAddTwoNumbers.Checked = true;
            this.rbAddTwoNumbers.Location = new System.Drawing.Point(14, 20);
            this.rbAddTwoNumbers.Name = "rbAddTwoNumbers";
            this.rbAddTwoNumbers.Size = new System.Drawing.Size(107, 17);
            this.rbAddTwoNumbers.TabIndex = 0;
            this.rbAddTwoNumbers.TabStop = true;
            this.rbAddTwoNumbers.Text = "AddTwoNumbers";
            this.rbAddTwoNumbers.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(322, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.txtRequestData);
            this.splitContainer3.Panel1.Controls.Add(this.requestHeader);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.txtResponseData);
            this.splitContainer3.Panel2.Controls.Add(this.responseHeader);
            this.splitContainer3.Size = new System.Drawing.Size(504, 480);
            this.splitContainer3.SplitterDistance = 238;
            this.splitContainer3.TabIndex = 2;
            // 
            // txtRequestData
            // 
            this.txtRequestData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRequestData.Location = new System.Drawing.Point(0, 25);
            this.txtRequestData.Name = "txtRequestData";
            this.txtRequestData.ReadOnly = true;
            this.txtRequestData.Size = new System.Drawing.Size(504, 213);
            this.txtRequestData.TabIndex = 2;
            this.txtRequestData.Text = "";
            // 
            // requestHeader
            // 
            this.requestHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.requestHeader.Location = new System.Drawing.Point(0, 0);
            this.requestHeader.Name = "requestHeader";
            this.requestHeader.Size = new System.Drawing.Size(504, 25);
            this.requestHeader.TabIndex = 1;
            this.requestHeader.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(98, 22);
            this.toolStripLabel1.Text = "Request Message";
            // 
            // txtResponseData
            // 
            this.txtResponseData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponseData.Location = new System.Drawing.Point(0, 25);
            this.txtResponseData.Name = "txtResponseData";
            this.txtResponseData.ReadOnly = true;
            this.txtResponseData.Size = new System.Drawing.Size(504, 213);
            this.txtResponseData.TabIndex = 2;
            this.txtResponseData.Text = "";
            // 
            // responseHeader
            // 
            this.responseHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2});
            this.responseHeader.Location = new System.Drawing.Point(0, 0);
            this.responseHeader.Name = "responseHeader";
            this.responseHeader.Size = new System.Drawing.Size(504, 25);
            this.responseHeader.TabIndex = 1;
            this.responseHeader.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(106, 22);
            this.toolStripLabel2.Text = "Response Message";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 480);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "WCF Service With Multiple Bindings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.grpTimes.ResumeLayout(false);
            this.grpTimes.PerformLayout();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iterations)).EndInit();
            this.grpEndpoint.ResumeLayout(false);
            this.grpMethod.ResumeLayout(false);
            this.grpMethod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.howManyPeople)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.requestHeader.ResumeLayout(false);
            this.requestHeader.PerformLayout();
            this.responseHeader.ResumeLayout(false);
            this.responseHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpMethod;
        private System.Windows.Forms.RadioButton rbGetUsername;
        private System.Windows.Forms.NumericUpDown howManyPeople;
        private System.Windows.Forms.RadioButton rbGetPeople;
        private System.Windows.Forms.RadioButton rbAddTwoNumbers;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox grpEndpoint;
        private System.Windows.Forms.RichTextBox txtRequestData;
        private System.Windows.Forms.ToolStrip requestHeader;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.RichTextBox txtResponseData;
        private System.Windows.Forms.ToolStrip responseHeader;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Button btnWsSecure;
        private System.Windows.Forms.Button btnNetTcp;
        private System.Windows.Forms.Button btnWsPlain;
        private System.Windows.Forms.Button btnBasic;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.NumericUpDown iterations;
        private System.Windows.Forms.GroupBox grpTimes;
        private System.Windows.Forms.Label lblElapsedTimeSEC;
        private System.Windows.Forms.TextBox txtElapsedTimeSec;
        private System.Windows.Forms.Label lblElapsedtimeMS;
        private System.Windows.Forms.TextBox txtElapsedTimeMs;
        private System.Windows.Forms.CheckBox chkShowMessages;
    }
}

