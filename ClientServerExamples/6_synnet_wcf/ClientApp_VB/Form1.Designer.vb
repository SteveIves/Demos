<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.chkGeneralContact = New System.Windows.Forms.CheckBox()
        Me.chkBillingContact = New System.Windows.Forms.CheckBox()
        Me.chkSalesContact = New System.Windows.Forms.CheckBox()
        Me.chkTechnicalContact = New System.Windows.Forms.CheckBox()
        Me.chkManagementContact = New System.Windows.Forms.CheckBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblWebSite = New System.Windows.Forms.Label()
        Me.txtWebSite = New System.Windows.Forms.TextBox()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.lblHomePhone = New System.Windows.Forms.Label()
        Me.txtHomePhone = New System.Windows.Forms.TextBox()
        Me.lblMobilePhone = New System.Windows.Forms.Label()
        Me.txtMobilePhone = New System.Windows.Forms.TextBox()
        Me.lblWorkPhone = New System.Windows.Forms.Label()
        Me.txtWorkPhone = New System.Windows.Forms.TextBox()
        Me.txtDepartment = New System.Windows.Forms.TextBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtPrefix = New System.Windows.Forms.TextBox()
        Me.lblPrefix = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gridCustomers = New System.Windows.Forms.DataGridView()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.splitter1 = New System.Windows.Forms.Splitter()
        Me.gridContacts = New System.Windows.Forms.DataGridView()
        Me.colFriendlyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menuStrip1.SuspendLayout()
        Me.panel1.SuspendLayout()
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        CType(Me.gridCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'statusStrip1
        '
        Me.statusStrip1.Location = New System.Drawing.Point(0, 640)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(884, 22)
        Me.statusStrip1.TabIndex = 8
        Me.statusStrip1.Text = "statusStrip1"
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(884, 24)
        Me.menuStrip1.TabIndex = 11
        Me.menuStrip1.Text = "menuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.exitToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.fileToolStripMenuItem.Text = "&File"
        '
        'exitToolStripMenuItem
        '
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.exitToolStripMenuItem.Text = "E&xit"
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.chkGeneralContact)
        Me.panel1.Controls.Add(Me.chkBillingContact)
        Me.panel1.Controls.Add(Me.chkSalesContact)
        Me.panel1.Controls.Add(Me.chkTechnicalContact)
        Me.panel1.Controls.Add(Me.chkManagementContact)
        Me.panel1.Controls.Add(Me.lblEmail)
        Me.panel1.Controls.Add(Me.txtEmail)
        Me.panel1.Controls.Add(Me.lblWebSite)
        Me.panel1.Controls.Add(Me.txtWebSite)
        Me.panel1.Controls.Add(Me.lblFax)
        Me.panel1.Controls.Add(Me.txtFax)
        Me.panel1.Controls.Add(Me.lblHomePhone)
        Me.panel1.Controls.Add(Me.txtHomePhone)
        Me.panel1.Controls.Add(Me.lblMobilePhone)
        Me.panel1.Controls.Add(Me.txtMobilePhone)
        Me.panel1.Controls.Add(Me.lblWorkPhone)
        Me.panel1.Controls.Add(Me.txtWorkPhone)
        Me.panel1.Controls.Add(Me.txtDepartment)
        Me.panel1.Controls.Add(Me.lblDepartment)
        Me.panel1.Controls.Add(Me.lblTitle)
        Me.panel1.Controls.Add(Me.txtTitle)
        Me.panel1.Controls.Add(Me.txtPrefix)
        Me.panel1.Controls.Add(Me.lblPrefix)
        Me.panel1.Controls.Add(Me.btnCancel)
        Me.panel1.Controls.Add(Me.btnOK)
        Me.panel1.Controls.Add(Me.txtFullName)
        Me.panel1.Controls.Add(Me.txtLastName)
        Me.panel1.Controls.Add(Me.txtFirstName)
        Me.panel1.Controls.Add(Me.lblFullName)
        Me.panel1.Controls.Add(Me.lblLastName)
        Me.panel1.Controls.Add(Me.lblFirstName)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.panel1.Location = New System.Drawing.Point(552, 24)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(332, 616)
        Me.panel1.TabIndex = 12
        '
        'chkGeneralContact
        '
        Me.chkGeneralContact.AutoSize = True
        Me.chkGeneralContact.Location = New System.Drawing.Point(52, 389)
        Me.chkGeneralContact.Name = "chkGeneralContact"
        Me.chkGeneralContact.Size = New System.Drawing.Size(103, 17)
        Me.chkGeneralContact.TabIndex = 63
        Me.chkGeneralContact.Text = "General Contact"
        Me.chkGeneralContact.UseVisualStyleBackColor = True
        '
        'chkBillingContact
        '
        Me.chkBillingContact.AutoSize = True
        Me.chkBillingContact.Location = New System.Drawing.Point(206, 366)
        Me.chkBillingContact.Name = "chkBillingContact"
        Me.chkBillingContact.Size = New System.Drawing.Size(93, 17)
        Me.chkBillingContact.TabIndex = 62
        Me.chkBillingContact.Text = "Billing Contact"
        Me.chkBillingContact.UseVisualStyleBackColor = True
        '
        'chkSalesContact
        '
        Me.chkSalesContact.AutoSize = True
        Me.chkSalesContact.Location = New System.Drawing.Point(52, 366)
        Me.chkSalesContact.Name = "chkSalesContact"
        Me.chkSalesContact.Size = New System.Drawing.Size(92, 17)
        Me.chkSalesContact.TabIndex = 61
        Me.chkSalesContact.Text = "Sales Contact"
        Me.chkSalesContact.UseVisualStyleBackColor = True
        '
        'chkTechnicalContact
        '
        Me.chkTechnicalContact.AutoSize = True
        Me.chkTechnicalContact.Location = New System.Drawing.Point(206, 343)
        Me.chkTechnicalContact.Name = "chkTechnicalContact"
        Me.chkTechnicalContact.Size = New System.Drawing.Size(113, 17)
        Me.chkTechnicalContact.TabIndex = 60
        Me.chkTechnicalContact.Text = "Technical Contact"
        Me.chkTechnicalContact.UseVisualStyleBackColor = True
        '
        'chkManagementContact
        '
        Me.chkManagementContact.AutoSize = True
        Me.chkManagementContact.Location = New System.Drawing.Point(52, 343)
        Me.chkManagementContact.Name = "chkManagementContact"
        Me.chkManagementContact.Size = New System.Drawing.Size(128, 17)
        Me.chkManagementContact.TabIndex = 59
        Me.chkManagementContact.Text = "Management Contact"
        Me.chkManagementContact.UseVisualStyleBackColor = True
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(21, 308)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(32, 13)
        Me.lblEmail.TabIndex = 58
        Me.lblEmail.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(108, 305)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(211, 20)
        Me.txtEmail.TabIndex = 57
        '
        'lblWebSite
        '
        Me.lblWebSite.AutoSize = True
        Me.lblWebSite.Location = New System.Drawing.Point(21, 282)
        Me.lblWebSite.Name = "lblWebSite"
        Me.lblWebSite.Size = New System.Drawing.Size(51, 13)
        Me.lblWebSite.TabIndex = 56
        Me.lblWebSite.Text = "Web Site"
        '
        'txtWebSite
        '
        Me.txtWebSite.Location = New System.Drawing.Point(108, 279)
        Me.txtWebSite.MaxLength = 50
        Me.txtWebSite.Name = "txtWebSite"
        Me.txtWebSite.Size = New System.Drawing.Size(211, 20)
        Me.txtWebSite.TabIndex = 55
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.Location = New System.Drawing.Point(21, 256)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(24, 13)
        Me.lblFax.TabIndex = 54
        Me.lblFax.Text = "Fax"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(108, 253)
        Me.txtFax.MaxLength = 12
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(211, 20)
        Me.txtFax.TabIndex = 48
        '
        'lblHomePhone
        '
        Me.lblHomePhone.AutoSize = True
        Me.lblHomePhone.Location = New System.Drawing.Point(21, 230)
        Me.lblHomePhone.Name = "lblHomePhone"
        Me.lblHomePhone.Size = New System.Drawing.Size(69, 13)
        Me.lblHomePhone.TabIndex = 53
        Me.lblHomePhone.Text = "Home Phone"
        '
        'txtHomePhone
        '
        Me.txtHomePhone.Location = New System.Drawing.Point(108, 227)
        Me.txtHomePhone.MaxLength = 12
        Me.txtHomePhone.Name = "txtHomePhone"
        Me.txtHomePhone.Size = New System.Drawing.Size(211, 20)
        Me.txtHomePhone.TabIndex = 47
        '
        'lblMobilePhone
        '
        Me.lblMobilePhone.AutoSize = True
        Me.lblMobilePhone.Location = New System.Drawing.Point(21, 204)
        Me.lblMobilePhone.Name = "lblMobilePhone"
        Me.lblMobilePhone.Size = New System.Drawing.Size(72, 13)
        Me.lblMobilePhone.TabIndex = 52
        Me.lblMobilePhone.Text = "Mobile Phone"
        '
        'txtMobilePhone
        '
        Me.txtMobilePhone.Location = New System.Drawing.Point(108, 201)
        Me.txtMobilePhone.MaxLength = 12
        Me.txtMobilePhone.Name = "txtMobilePhone"
        Me.txtMobilePhone.Size = New System.Drawing.Size(211, 20)
        Me.txtMobilePhone.TabIndex = 46
        '
        'lblWorkPhone
        '
        Me.lblWorkPhone.AutoSize = True
        Me.lblWorkPhone.Location = New System.Drawing.Point(21, 178)
        Me.lblWorkPhone.Name = "lblWorkPhone"
        Me.lblWorkPhone.Size = New System.Drawing.Size(67, 13)
        Me.lblWorkPhone.TabIndex = 51
        Me.lblWorkPhone.Text = "Work Phone"
        '
        'txtWorkPhone
        '
        Me.txtWorkPhone.Location = New System.Drawing.Point(108, 175)
        Me.txtWorkPhone.MaxLength = 12
        Me.txtWorkPhone.Name = "txtWorkPhone"
        Me.txtWorkPhone.Size = New System.Drawing.Size(211, 20)
        Me.txtWorkPhone.TabIndex = 45
        '
        'txtDepartment
        '
        Me.txtDepartment.Location = New System.Drawing.Point(108, 149)
        Me.txtDepartment.MaxLength = 15
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(211, 20)
        Me.txtDepartment.TabIndex = 43
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Location = New System.Drawing.Point(21, 152)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(62, 13)
        Me.lblDepartment.TabIndex = 50
        Me.lblDepartment.Text = "Department"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(21, 126)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(27, 13)
        Me.lblTitle.TabIndex = 49
        Me.lblTitle.Text = "Title"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(108, 123)
        Me.txtTitle.MaxLength = 25
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(211, 20)
        Me.txtTitle.TabIndex = 42
        '
        'txtPrefix
        '
        Me.txtPrefix.Location = New System.Drawing.Point(108, 97)
        Me.txtPrefix.MaxLength = 5
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Size = New System.Drawing.Size(211, 20)
        Me.txtPrefix.TabIndex = 41
        '
        'lblPrefix
        '
        Me.lblPrefix.AutoSize = True
        Me.lblPrefix.Location = New System.Drawing.Point(21, 100)
        Me.lblPrefix.Name = "lblPrefix"
        Me.lblPrefix.Size = New System.Drawing.Size(33, 13)
        Me.lblPrefix.TabIndex = 44
        Me.lblPrefix.Text = "Prefix"
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(244, 428)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(163, 428)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtFullName
        '
        Me.txtFullName.Enabled = False
        Me.txtFullName.Location = New System.Drawing.Point(108, 71)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(211, 20)
        Me.txtFullName.TabIndex = 5
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(108, 45)
        Me.txtLastName.MaxLength = 30
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(211, 20)
        Me.txtLastName.TabIndex = 4
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(108, 19)
        Me.txtFirstName.MaxLength = 30
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(211, 20)
        Me.txtFirstName.TabIndex = 3
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Location = New System.Drawing.Point(21, 74)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(54, 13)
        Me.lblFullName.TabIndex = 2
        Me.lblFullName.Text = "Full Name"
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(21, 48)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(58, 13)
        Me.lblLastName.TabIndex = 1
        Me.lblLastName.Text = "Last Name"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(21, 22)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(57, 13)
        Me.lblFirstName.TabIndex = 0
        Me.lblFirstName.Text = "First Name"
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.gridCustomers)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.splitter1)
        Me.splitContainer1.Panel2.Controls.Add(Me.gridContacts)
        Me.splitContainer1.Size = New System.Drawing.Size(552, 616)
        Me.splitContainer1.SplitterDistance = 243
        Me.splitContainer1.TabIndex = 13
        '
        'gridCustomers
        '
        Me.gridCustomers.AllowUserToAddRows = False
        Me.gridCustomers.AllowUserToDeleteRows = False
        Me.gridCustomers.AllowUserToResizeRows = False
        Me.gridCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridCustomers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colName})
        Me.gridCustomers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridCustomers.Location = New System.Drawing.Point(0, 0)
        Me.gridCustomers.MultiSelect = False
        Me.gridCustomers.Name = "gridCustomers"
        Me.gridCustomers.ReadOnly = True
        Me.gridCustomers.RowHeadersVisible = False
        Me.gridCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridCustomers.Size = New System.Drawing.Size(243, 616)
        Me.gridCustomers.TabIndex = 0
        '
        'colName
        '
        Me.colName.DataPropertyName = "Name"
        Me.colName.HeaderText = "Customer Name"
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        '
        'splitter1
        '
        Me.splitter1.Location = New System.Drawing.Point(0, 0)
        Me.splitter1.Name = "splitter1"
        Me.splitter1.Size = New System.Drawing.Size(3, 616)
        Me.splitter1.TabIndex = 1
        Me.splitter1.TabStop = False
        '
        'gridContacts
        '
        Me.gridContacts.AllowUserToAddRows = False
        Me.gridContacts.AllowUserToDeleteRows = False
        Me.gridContacts.AllowUserToResizeRows = False
        Me.gridContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridContacts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFriendlyName})
        Me.gridContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridContacts.Location = New System.Drawing.Point(0, 0)
        Me.gridContacts.MultiSelect = False
        Me.gridContacts.Name = "gridContacts"
        Me.gridContacts.ReadOnly = True
        Me.gridContacts.RowHeadersVisible = False
        Me.gridContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridContacts.Size = New System.Drawing.Size(305, 616)
        Me.gridContacts.TabIndex = 0
        '
        'colFriendlyName
        '
        Me.colFriendlyName.DataPropertyName = "Friendly_name"
        Me.colFriendlyName.HeaderText = "Contact Name"
        Me.colFriendlyName.Name = "colFriendlyName"
        Me.colFriendlyName.ReadOnly = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 662)
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.statusStrip1)
        Me.Name = "Form1"
        Me.Text = "Synergy .NET WCF Service Client (VB)"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.ResumeLayout(False)
        CType(Me.gridCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents chkGeneralContact As System.Windows.Forms.CheckBox
    Private WithEvents chkBillingContact As System.Windows.Forms.CheckBox
    Private WithEvents chkSalesContact As System.Windows.Forms.CheckBox
    Private WithEvents chkTechnicalContact As System.Windows.Forms.CheckBox
    Private WithEvents chkManagementContact As System.Windows.Forms.CheckBox
    Private WithEvents lblEmail As System.Windows.Forms.Label
    Private WithEvents txtEmail As System.Windows.Forms.TextBox
    Private WithEvents lblWebSite As System.Windows.Forms.Label
    Private WithEvents txtWebSite As System.Windows.Forms.TextBox
    Private WithEvents lblFax As System.Windows.Forms.Label
    Private WithEvents txtFax As System.Windows.Forms.TextBox
    Private WithEvents lblHomePhone As System.Windows.Forms.Label
    Private WithEvents txtHomePhone As System.Windows.Forms.TextBox
    Private WithEvents lblMobilePhone As System.Windows.Forms.Label
    Private WithEvents txtMobilePhone As System.Windows.Forms.TextBox
    Private WithEvents lblWorkPhone As System.Windows.Forms.Label
    Private WithEvents txtWorkPhone As System.Windows.Forms.TextBox
    Private WithEvents txtDepartment As System.Windows.Forms.TextBox
    Private WithEvents lblDepartment As System.Windows.Forms.Label
    Private WithEvents lblTitle As System.Windows.Forms.Label
    Private WithEvents txtTitle As System.Windows.Forms.TextBox
    Private WithEvents txtPrefix As System.Windows.Forms.TextBox
    Private WithEvents lblPrefix As System.Windows.Forms.Label
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnOK As System.Windows.Forms.Button
    Private WithEvents txtFullName As System.Windows.Forms.TextBox
    Private WithEvents txtLastName As System.Windows.Forms.TextBox
    Private WithEvents txtFirstName As System.Windows.Forms.TextBox
    Private WithEvents lblFullName As System.Windows.Forms.Label
    Private WithEvents lblLastName As System.Windows.Forms.Label
    Private WithEvents lblFirstName As System.Windows.Forms.Label
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents gridCustomers As System.Windows.Forms.DataGridView
    Private WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents splitter1 As System.Windows.Forms.Splitter
    Private WithEvents gridContacts As System.Windows.Forms.DataGridView
    Private WithEvents colFriendlyName As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
