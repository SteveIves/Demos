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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkGeneralContact = new System.Windows.Forms.CheckBox();
            this.chkBillingContact = new System.Windows.Forms.CheckBox();
            this.chkSalesContact = new System.Windows.Forms.CheckBox();
            this.chkTechnicalContact = new System.Windows.Forms.CheckBox();
            this.chkManagementContact = new System.Windows.Forms.CheckBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblWebSite = new System.Windows.Forms.Label();
            this.txtWebSite = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblHomePhone = new System.Windows.Forms.Label();
            this.txtHomePhone = new System.Windows.Forms.TextBox();
            this.lblMobilePhone = new System.Windows.Forms.Label();
            this.txtMobilePhone = new System.Windows.Forms.TextBox();
            this.lblWorkPhone = new System.Windows.Forms.Label();
            this.txtWorkPhone = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridCustomers = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gridContacts = new System.Windows.Forms.DataGridView();
            this.colFriendlyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 640);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkGeneralContact);
            this.panel1.Controls.Add(this.chkBillingContact);
            this.panel1.Controls.Add(this.chkSalesContact);
            this.panel1.Controls.Add(this.chkTechnicalContact);
            this.panel1.Controls.Add(this.chkManagementContact);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.lblWebSite);
            this.panel1.Controls.Add(this.txtWebSite);
            this.panel1.Controls.Add(this.lblFax);
            this.panel1.Controls.Add(this.txtFax);
            this.panel1.Controls.Add(this.lblHomePhone);
            this.panel1.Controls.Add(this.txtHomePhone);
            this.panel1.Controls.Add(this.lblMobilePhone);
            this.panel1.Controls.Add(this.txtMobilePhone);
            this.panel1.Controls.Add(this.lblWorkPhone);
            this.panel1.Controls.Add(this.txtWorkPhone);
            this.panel1.Controls.Add(this.txtDepartment);
            this.panel1.Controls.Add(this.lblDepartment);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.txtPrefix);
            this.panel1.Controls.Add(this.lblPrefix);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.txtFullName);
            this.panel1.Controls.Add(this.txtLastName);
            this.panel1.Controls.Add(this.txtFirstName);
            this.panel1.Controls.Add(this.lblFullName);
            this.panel1.Controls.Add(this.lblLastName);
            this.panel1.Controls.Add(this.lblFirstName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(542, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 616);
            this.panel1.TabIndex = 5;
            // 
            // chkGeneralContact
            // 
            this.chkGeneralContact.AutoSize = true;
            this.chkGeneralContact.Location = new System.Drawing.Point(52, 389);
            this.chkGeneralContact.Name = "chkGeneralContact";
            this.chkGeneralContact.Size = new System.Drawing.Size(103, 17);
            this.chkGeneralContact.TabIndex = 63;
            this.chkGeneralContact.Text = "General Contact";
            this.chkGeneralContact.UseVisualStyleBackColor = true;
            this.chkGeneralContact.CheckedChanged += new System.EventHandler(this.fieldChanged);
            // 
            // chkBillingContact
            // 
            this.chkBillingContact.AutoSize = true;
            this.chkBillingContact.Location = new System.Drawing.Point(206, 366);
            this.chkBillingContact.Name = "chkBillingContact";
            this.chkBillingContact.Size = new System.Drawing.Size(93, 17);
            this.chkBillingContact.TabIndex = 62;
            this.chkBillingContact.Text = "Billing Contact";
            this.chkBillingContact.UseVisualStyleBackColor = true;
            this.chkBillingContact.CheckedChanged += new System.EventHandler(this.fieldChanged);
            // 
            // chkSalesContact
            // 
            this.chkSalesContact.AutoSize = true;
            this.chkSalesContact.Location = new System.Drawing.Point(52, 366);
            this.chkSalesContact.Name = "chkSalesContact";
            this.chkSalesContact.Size = new System.Drawing.Size(92, 17);
            this.chkSalesContact.TabIndex = 61;
            this.chkSalesContact.Text = "Sales Contact";
            this.chkSalesContact.UseVisualStyleBackColor = true;
            this.chkSalesContact.CheckedChanged += new System.EventHandler(this.fieldChanged);
            // 
            // chkTechnicalContact
            // 
            this.chkTechnicalContact.AutoSize = true;
            this.chkTechnicalContact.Location = new System.Drawing.Point(206, 343);
            this.chkTechnicalContact.Name = "chkTechnicalContact";
            this.chkTechnicalContact.Size = new System.Drawing.Size(113, 17);
            this.chkTechnicalContact.TabIndex = 60;
            this.chkTechnicalContact.Text = "Technical Contact";
            this.chkTechnicalContact.UseVisualStyleBackColor = true;
            this.chkTechnicalContact.CheckedChanged += new System.EventHandler(this.fieldChanged);
            // 
            // chkManagementContact
            // 
            this.chkManagementContact.AutoSize = true;
            this.chkManagementContact.Location = new System.Drawing.Point(52, 343);
            this.chkManagementContact.Name = "chkManagementContact";
            this.chkManagementContact.Size = new System.Drawing.Size(128, 17);
            this.chkManagementContact.TabIndex = 59;
            this.chkManagementContact.Text = "Management Contact";
            this.chkManagementContact.UseVisualStyleBackColor = true;
            this.chkManagementContact.CheckedChanged += new System.EventHandler(this.fieldChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(21, 308);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 58;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(108, 305);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(211, 20);
            this.txtEmail.TabIndex = 57;
            this.txtEmail.TextChanged += new System.EventHandler(this.fieldChanged);
            // 
            // lblWebSite
            // 
            this.lblWebSite.AutoSize = true;
            this.lblWebSite.Location = new System.Drawing.Point(21, 282);
            this.lblWebSite.Name = "lblWebSite";
            this.lblWebSite.Size = new System.Drawing.Size(51, 13);
            this.lblWebSite.TabIndex = 56;
            this.lblWebSite.Text = "Web Site";
            // 
            // txtWebSite
            // 
            this.txtWebSite.Location = new System.Drawing.Point(108, 279);
            this.txtWebSite.MaxLength = 50;
            this.txtWebSite.Name = "txtWebSite";
            this.txtWebSite.Size = new System.Drawing.Size(211, 20);
            this.txtWebSite.TabIndex = 55;
            this.txtWebSite.TextChanged += new System.EventHandler(this.fieldChanged);
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(21, 256);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(24, 13);
            this.lblFax.TabIndex = 54;
            this.lblFax.Text = "Fax";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(108, 253);
            this.txtFax.MaxLength = 12;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(211, 20);
            this.txtFax.TabIndex = 48;
            this.txtFax.TextChanged += new System.EventHandler(this.fieldChanged);
            // 
            // lblHomePhone
            // 
            this.lblHomePhone.AutoSize = true;
            this.lblHomePhone.Location = new System.Drawing.Point(21, 230);
            this.lblHomePhone.Name = "lblHomePhone";
            this.lblHomePhone.Size = new System.Drawing.Size(69, 13);
            this.lblHomePhone.TabIndex = 53;
            this.lblHomePhone.Text = "Home Phone";
            // 
            // txtHomePhone
            // 
            this.txtHomePhone.Location = new System.Drawing.Point(108, 227);
            this.txtHomePhone.MaxLength = 12;
            this.txtHomePhone.Name = "txtHomePhone";
            this.txtHomePhone.Size = new System.Drawing.Size(211, 20);
            this.txtHomePhone.TabIndex = 47;
            this.txtHomePhone.TextChanged += new System.EventHandler(this.fieldChanged);
            // 
            // lblMobilePhone
            // 
            this.lblMobilePhone.AutoSize = true;
            this.lblMobilePhone.Location = new System.Drawing.Point(21, 204);
            this.lblMobilePhone.Name = "lblMobilePhone";
            this.lblMobilePhone.Size = new System.Drawing.Size(72, 13);
            this.lblMobilePhone.TabIndex = 52;
            this.lblMobilePhone.Text = "Mobile Phone";
            // 
            // txtMobilePhone
            // 
            this.txtMobilePhone.Location = new System.Drawing.Point(108, 201);
            this.txtMobilePhone.MaxLength = 12;
            this.txtMobilePhone.Name = "txtMobilePhone";
            this.txtMobilePhone.Size = new System.Drawing.Size(211, 20);
            this.txtMobilePhone.TabIndex = 46;
            this.txtMobilePhone.TextChanged += new System.EventHandler(this.fieldChanged);
            // 
            // lblWorkPhone
            // 
            this.lblWorkPhone.AutoSize = true;
            this.lblWorkPhone.Location = new System.Drawing.Point(21, 178);
            this.lblWorkPhone.Name = "lblWorkPhone";
            this.lblWorkPhone.Size = new System.Drawing.Size(67, 13);
            this.lblWorkPhone.TabIndex = 51;
            this.lblWorkPhone.Text = "Work Phone";
            // 
            // txtWorkPhone
            // 
            this.txtWorkPhone.Location = new System.Drawing.Point(108, 175);
            this.txtWorkPhone.MaxLength = 12;
            this.txtWorkPhone.Name = "txtWorkPhone";
            this.txtWorkPhone.Size = new System.Drawing.Size(211, 20);
            this.txtWorkPhone.TabIndex = 45;
            this.txtWorkPhone.TextChanged += new System.EventHandler(this.fieldChanged);
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(108, 149);
            this.txtDepartment.MaxLength = 15;
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(211, 20);
            this.txtDepartment.TabIndex = 43;
            this.txtDepartment.TextChanged += new System.EventHandler(this.fieldChanged);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(21, 152);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 50;
            this.lblDepartment.Text = "Department";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(21, 126);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 49;
            this.lblTitle.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(108, 123);
            this.txtTitle.MaxLength = 25;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(211, 20);
            this.txtTitle.TabIndex = 42;
            this.txtTitle.TextChanged += new System.EventHandler(this.fieldChanged);
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(108, 97);
            this.txtPrefix.MaxLength = 5;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(211, 20);
            this.txtPrefix.TabIndex = 41;
            this.txtPrefix.TextChanged += new System.EventHandler(this.fieldChanged);
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(21, 100);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(33, 13);
            this.lblPrefix.TabIndex = 44;
            this.lblPrefix.Text = "Prefix";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(244, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(163, 428);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.Enabled = false;
            this.txtFullName.Location = new System.Drawing.Point(108, 71);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(211, 20);
            this.txtFullName.TabIndex = 5;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(108, 45);
            this.txtLastName.MaxLength = 30;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(211, 20);
            this.txtLastName.TabIndex = 4;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(108, 19);
            this.txtFirstName.MaxLength = 30;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(211, 20);
            this.txtFirstName.TabIndex = 3;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(21, 74);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(54, 13);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Full Name";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(21, 48);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(21, 22);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridCustomers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.gridContacts);
            this.splitContainer1.Size = new System.Drawing.Size(542, 616);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 6;
            // 
            // gridCustomers
            // 
            this.gridCustomers.AllowUserToAddRows = false;
            this.gridCustomers.AllowUserToDeleteRows = false;
            this.gridCustomers.AllowUserToResizeRows = false;
            this.gridCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName});
            this.gridCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCustomers.Location = new System.Drawing.Point(0, 0);
            this.gridCustomers.MultiSelect = false;
            this.gridCustomers.Name = "gridCustomers";
            this.gridCustomers.ReadOnly = true;
            this.gridCustomers.RowHeadersVisible = false;
            this.gridCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCustomers.Size = new System.Drawing.Size(240, 616);
            this.gridCustomers.TabIndex = 0;
            this.gridCustomers.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCustomers_RowEnter);
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Customer Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 616);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // gridContacts
            // 
            this.gridContacts.AllowUserToAddRows = false;
            this.gridContacts.AllowUserToDeleteRows = false;
            this.gridContacts.AllowUserToResizeRows = false;
            this.gridContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridContacts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFriendlyName});
            this.gridContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContacts.Location = new System.Drawing.Point(0, 0);
            this.gridContacts.MultiSelect = false;
            this.gridContacts.Name = "gridContacts";
            this.gridContacts.ReadOnly = true;
            this.gridContacts.RowHeadersVisible = false;
            this.gridContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridContacts.Size = new System.Drawing.Size(298, 616);
            this.gridContacts.TabIndex = 0;
            this.gridContacts.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridContacts_RowEnter);
            // 
            // colFriendlyName
            // 
            this.colFriendlyName.DataPropertyName = "Friendly_name";
            this.colFriendlyName.HeaderText = "Contact Name";
            this.colFriendlyName.Name = "colFriendlyName";
            this.colFriendlyName.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 662);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Synergy .NET WCF Service Client (C#)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContacts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gridCustomers;
        private System.Windows.Forms.DataGridView gridContacts;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFriendlyName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkGeneralContact;
        private System.Windows.Forms.CheckBox chkBillingContact;
        private System.Windows.Forms.CheckBox chkSalesContact;
        private System.Windows.Forms.CheckBox chkTechnicalContact;
        private System.Windows.Forms.CheckBox chkManagementContact;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblWebSite;
        private System.Windows.Forms.TextBox txtWebSite;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblHomePhone;
        private System.Windows.Forms.TextBox txtHomePhone;
        private System.Windows.Forms.Label lblMobilePhone;
        private System.Windows.Forms.TextBox txtMobilePhone;
        private System.Windows.Forms.Label lblWorkPhone;
        private System.Windows.Forms.TextBox txtWorkPhone;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label lblPrefix;

    }
}

