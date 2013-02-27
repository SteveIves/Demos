Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents lblLogFile As System.Windows.Forms.Label
    Friend WithEvents txtLogFile As System.Windows.Forms.TextBox
    Friend WithEvents chkLogging As System.Windows.Forms.CheckBox
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents DrillLogFile As System.Windows.Forms.Button
    Friend WithEvents pnlSessionLogging As System.Windows.Forms.GroupBox
    Friend WithEvents rbSessionLoggingAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbSessionLoggingCritical As System.Windows.Forms.RadioButton
    Friend WithEvents rbSessionLoggingNone As System.Windows.Forms.RadioButton
    Friend WithEvents pnlFunctionLogging As System.Windows.Forms.GroupBox
    Friend WithEvents rbFunctionLoggingAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbFunctionLoggingCritical As System.Windows.Forms.RadioButton
    Friend WithEvents rbFunctionLoggingNone As System.Windows.Forms.RadioButton
    Friend WithEvents lblEnvironmentSettings As System.Windows.Forms.Label
    Friend WithEvents mnuFileNew As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileOpen As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileClose As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileSave As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileSaveAs As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileExit As System.Windows.Forms.MenuItem
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents lblSmcLocation As System.Windows.Forms.Label
    Friend WithEvents txtSmcLocation As System.Windows.Forms.TextBox
    Friend WithEvents pnlDebugLogging As System.Windows.Forms.GroupBox
    Friend WithEvents rbDebugLoggingNormal As System.Windows.Forms.RadioButton
    Friend WithEvents rbDebugLoggingExtended As System.Windows.Forms.RadioButton
    Friend WithEvents chkSingleLogFile As System.Windows.Forms.CheckBox
    Friend WithEvents rbDebugLoggingNone As System.Windows.Forms.RadioButton
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelpAbout As System.Windows.Forms.MenuItem
    Friend WithEvents grdLogicals As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkDataCompression As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuFileNew = New System.Windows.Forms.MenuItem
        Me.mnuFileOpen = New System.Windows.Forms.MenuItem
        Me.mnuFileClose = New System.Windows.Forms.MenuItem
        Me.mnuFileSave = New System.Windows.Forms.MenuItem
        Me.mnuFileSaveAs = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuFileExit = New System.Windows.Forms.MenuItem
        Me.mnuEdit = New System.Windows.Forms.MenuItem
        Me.mnuHelp = New System.Windows.Forms.MenuItem
        Me.mnuHelpAbout = New System.Windows.Forms.MenuItem
        Me.lblLogFile = New System.Windows.Forms.Label
        Me.txtLogFile = New System.Windows.Forms.TextBox
        Me.chkLogging = New System.Windows.Forms.CheckBox
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.DrillLogFile = New System.Windows.Forms.Button
        Me.pnlSessionLogging = New System.Windows.Forms.GroupBox
        Me.rbSessionLoggingAll = New System.Windows.Forms.RadioButton
        Me.rbSessionLoggingCritical = New System.Windows.Forms.RadioButton
        Me.rbSessionLoggingNone = New System.Windows.Forms.RadioButton
        Me.pnlFunctionLogging = New System.Windows.Forms.GroupBox
        Me.rbFunctionLoggingAll = New System.Windows.Forms.RadioButton
        Me.rbFunctionLoggingCritical = New System.Windows.Forms.RadioButton
        Me.rbFunctionLoggingNone = New System.Windows.Forms.RadioButton
        Me.lblEnvironmentSettings = New System.Windows.Forms.Label
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.lblSmcLocation = New System.Windows.Forms.Label
        Me.txtSmcLocation = New System.Windows.Forms.TextBox
        Me.pnlDebugLogging = New System.Windows.Forms.GroupBox
        Me.rbDebugLoggingNone = New System.Windows.Forms.RadioButton
        Me.rbDebugLoggingExtended = New System.Windows.Forms.RadioButton
        Me.rbDebugLoggingNormal = New System.Windows.Forms.RadioButton
        Me.chkDataCompression = New System.Windows.Forms.CheckBox
        Me.chkSingleLogFile = New System.Windows.Forms.CheckBox
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.grdLogicals = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSessionLogging.SuspendLayout()
        Me.pnlFunctionLogging.SuspendLayout()
        Me.pnlDebugLogging.SuspendLayout()
        CType(Me.grdLogicals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuEdit, Me.mnuHelp})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFileNew, Me.mnuFileOpen, Me.mnuFileClose, Me.mnuFileSave, Me.mnuFileSaveAs, Me.MenuItem2, Me.mnuFileExit})
        Me.mnuFile.Text = "&File"
        '
        'mnuFileNew
        '
        Me.mnuFileNew.Index = 0
        Me.mnuFileNew.Text = "&New..."
        '
        'mnuFileOpen
        '
        Me.mnuFileOpen.Index = 1
        Me.mnuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.mnuFileOpen.Text = "&Open..."
        '
        'mnuFileClose
        '
        Me.mnuFileClose.Enabled = False
        Me.mnuFileClose.Index = 2
        Me.mnuFileClose.Text = "&Close"
        '
        'mnuFileSave
        '
        Me.mnuFileSave.Enabled = False
        Me.mnuFileSave.Index = 3
        Me.mnuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuFileSave.Text = "&Save"
        '
        'mnuFileSaveAs
        '
        Me.mnuFileSaveAs.Enabled = False
        Me.mnuFileSaveAs.Index = 4
        Me.mnuFileSaveAs.Text = "Save &As..."
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 5
        Me.MenuItem2.Text = "-"
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Index = 6
        Me.mnuFileExit.Text = "E&xit"
        '
        'mnuEdit
        '
        Me.mnuEdit.Index = 1
        Me.mnuEdit.Text = "&Edit"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 2
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuHelpAbout})
        Me.mnuHelp.Text = "&Help"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Index = 0
        Me.mnuHelpAbout.Text = "&About"
        '
        'lblLogFile
        '
        Me.lblLogFile.Location = New System.Drawing.Point(12, 67)
        Me.lblLogFile.Name = "lblLogFile"
        Me.lblLogFile.Size = New System.Drawing.Size(80, 16)
        Me.lblLogFile.TabIndex = 0
        Me.lblLogFile.Text = "Log File Name"
        '
        'txtLogFile
        '
        Me.txtLogFile.Location = New System.Drawing.Point(96, 63)
        Me.txtLogFile.Name = "txtLogFile"
        Me.txtLogFile.Size = New System.Drawing.Size(460, 20)
        Me.txtLogFile.TabIndex = 1
        '
        'chkLogging
        '
        Me.chkLogging.Location = New System.Drawing.Point(100, 99)
        Me.chkLogging.Name = "chkLogging"
        Me.chkLogging.Size = New System.Drawing.Size(104, 24)
        Me.chkLogging.TabIndex = 2
        Me.chkLogging.Text = "Enable Logging"
        '
        'StatusBar
        '
        Me.StatusBar.Location = New System.Drawing.Point(0, 450)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1})
        Me.StatusBar.ShowPanels = True
        Me.StatusBar.Size = New System.Drawing.Size(594, 22)
        Me.StatusBar.TabIndex = 3
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Text = "No file open"
        Me.StatusBarPanel1.Width = 577
        '
        'DrillLogFile
        '
        Me.DrillLogFile.Location = New System.Drawing.Point(556, 63)
        Me.DrillLogFile.Name = "DrillLogFile"
        Me.DrillLogFile.Size = New System.Drawing.Size(24, 20)
        Me.DrillLogFile.TabIndex = 4
        Me.DrillLogFile.Text = "..."
        '
        'pnlSessionLogging
        '
        Me.pnlSessionLogging.Controls.Add(Me.rbSessionLoggingAll)
        Me.pnlSessionLogging.Controls.Add(Me.rbSessionLoggingCritical)
        Me.pnlSessionLogging.Controls.Add(Me.rbSessionLoggingNone)
        Me.pnlSessionLogging.Location = New System.Drawing.Point(96, 139)
        Me.pnlSessionLogging.Name = "pnlSessionLogging"
        Me.pnlSessionLogging.Size = New System.Drawing.Size(136, 110)
        Me.pnlSessionLogging.TabIndex = 10
        Me.pnlSessionLogging.TabStop = False
        Me.pnlSessionLogging.Text = "Session Logging"
        '
        'rbSessionLoggingAll
        '
        Me.rbSessionLoggingAll.Location = New System.Drawing.Point(20, 72)
        Me.rbSessionLoggingAll.Name = "rbSessionLoggingAll"
        Me.rbSessionLoggingAll.Size = New System.Drawing.Size(44, 24)
        Me.rbSessionLoggingAll.TabIndex = 12
        Me.rbSessionLoggingAll.Tag = ""
        Me.rbSessionLoggingAll.Text = "All"
        '
        'rbSessionLoggingCritical
        '
        Me.rbSessionLoggingCritical.Location = New System.Drawing.Point(20, 48)
        Me.rbSessionLoggingCritical.Name = "rbSessionLoggingCritical"
        Me.rbSessionLoggingCritical.Size = New System.Drawing.Size(60, 24)
        Me.rbSessionLoggingCritical.TabIndex = 11
        Me.rbSessionLoggingCritical.Tag = ""
        Me.rbSessionLoggingCritical.Text = "Critical"
        '
        'rbSessionLoggingNone
        '
        Me.rbSessionLoggingNone.Location = New System.Drawing.Point(20, 24)
        Me.rbSessionLoggingNone.Name = "rbSessionLoggingNone"
        Me.rbSessionLoggingNone.Size = New System.Drawing.Size(56, 24)
        Me.rbSessionLoggingNone.TabIndex = 10
        Me.rbSessionLoggingNone.Tag = ""
        Me.rbSessionLoggingNone.Text = "None"
        '
        'pnlFunctionLogging
        '
        Me.pnlFunctionLogging.Controls.Add(Me.rbFunctionLoggingAll)
        Me.pnlFunctionLogging.Controls.Add(Me.rbFunctionLoggingCritical)
        Me.pnlFunctionLogging.Controls.Add(Me.rbFunctionLoggingNone)
        Me.pnlFunctionLogging.Location = New System.Drawing.Point(252, 139)
        Me.pnlFunctionLogging.Name = "pnlFunctionLogging"
        Me.pnlFunctionLogging.Size = New System.Drawing.Size(136, 110)
        Me.pnlFunctionLogging.TabIndex = 11
        Me.pnlFunctionLogging.TabStop = False
        Me.pnlFunctionLogging.Text = "Function Logging"
        '
        'rbFunctionLoggingAll
        '
        Me.rbFunctionLoggingAll.Location = New System.Drawing.Point(20, 72)
        Me.rbFunctionLoggingAll.Name = "rbFunctionLoggingAll"
        Me.rbFunctionLoggingAll.Size = New System.Drawing.Size(44, 24)
        Me.rbFunctionLoggingAll.TabIndex = 12
        Me.rbFunctionLoggingAll.Text = "All"
        '
        'rbFunctionLoggingCritical
        '
        Me.rbFunctionLoggingCritical.Location = New System.Drawing.Point(20, 48)
        Me.rbFunctionLoggingCritical.Name = "rbFunctionLoggingCritical"
        Me.rbFunctionLoggingCritical.Size = New System.Drawing.Size(60, 24)
        Me.rbFunctionLoggingCritical.TabIndex = 11
        Me.rbFunctionLoggingCritical.Text = "Critical"
        '
        'rbFunctionLoggingNone
        '
        Me.rbFunctionLoggingNone.Location = New System.Drawing.Point(20, 24)
        Me.rbFunctionLoggingNone.Name = "rbFunctionLoggingNone"
        Me.rbFunctionLoggingNone.Size = New System.Drawing.Size(56, 24)
        Me.rbFunctionLoggingNone.TabIndex = 10
        Me.rbFunctionLoggingNone.Text = "None"
        '
        'lblEnvironmentSettings
        '
        Me.lblEnvironmentSettings.Location = New System.Drawing.Point(92, 259)
        Me.lblEnvironmentSettings.Name = "lblEnvironmentSettings"
        Me.lblEnvironmentSettings.Size = New System.Drawing.Size(128, 16)
        Me.lblEnvironmentSettings.TabIndex = 14
        Me.lblEnvironmentSettings.Text = "Environment Settings"
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.FileName = "doc1"
        '
        'lblSmcLocation
        '
        Me.lblSmcLocation.Location = New System.Drawing.Point(12, 39)
        Me.lblSmcLocation.Name = "lblSmcLocation"
        Me.lblSmcLocation.Size = New System.Drawing.Size(76, 16)
        Me.lblSmcLocation.TabIndex = 15
        Me.lblSmcLocation.Text = "SMC Location"
        '
        'txtSmcLocation
        '
        Me.txtSmcLocation.Location = New System.Drawing.Point(96, 35)
        Me.txtSmcLocation.Name = "txtSmcLocation"
        Me.txtSmcLocation.Size = New System.Drawing.Size(460, 20)
        Me.txtSmcLocation.TabIndex = 16
        '
        'pnlDebugLogging
        '
        Me.pnlDebugLogging.Controls.Add(Me.rbDebugLoggingNone)
        Me.pnlDebugLogging.Controls.Add(Me.rbDebugLoggingExtended)
        Me.pnlDebugLogging.Controls.Add(Me.rbDebugLoggingNormal)
        Me.pnlDebugLogging.Location = New System.Drawing.Point(404, 139)
        Me.pnlDebugLogging.Name = "pnlDebugLogging"
        Me.pnlDebugLogging.Size = New System.Drawing.Size(176, 112)
        Me.pnlDebugLogging.TabIndex = 17
        Me.pnlDebugLogging.TabStop = False
        Me.pnlDebugLogging.Text = "Debug Logging"
        '
        'rbDebugLoggingNone
        '
        Me.rbDebugLoggingNone.Location = New System.Drawing.Point(32, 24)
        Me.rbDebugLoggingNone.Name = "rbDebugLoggingNone"
        Me.rbDebugLoggingNone.Size = New System.Drawing.Size(104, 24)
        Me.rbDebugLoggingNone.TabIndex = 15
        Me.rbDebugLoggingNone.Text = "None"
        '
        'rbDebugLoggingExtended
        '
        Me.rbDebugLoggingExtended.Location = New System.Drawing.Point(32, 72)
        Me.rbDebugLoggingExtended.Name = "rbDebugLoggingExtended"
        Me.rbDebugLoggingExtended.Size = New System.Drawing.Size(104, 24)
        Me.rbDebugLoggingExtended.TabIndex = 14
        Me.rbDebugLoggingExtended.Text = "Extended"
        '
        'rbDebugLoggingNormal
        '
        Me.rbDebugLoggingNormal.Location = New System.Drawing.Point(32, 48)
        Me.rbDebugLoggingNormal.Name = "rbDebugLoggingNormal"
        Me.rbDebugLoggingNormal.Size = New System.Drawing.Size(104, 24)
        Me.rbDebugLoggingNormal.TabIndex = 13
        Me.rbDebugLoggingNormal.Text = "Normal"
        '
        'chkDataCompression
        '
        Me.chkDataCompression.Location = New System.Drawing.Point(256, 99)
        Me.chkDataCompression.Name = "chkDataCompression"
        Me.chkDataCompression.Size = New System.Drawing.Size(156, 24)
        Me.chkDataCompression.TabIndex = 18
        Me.chkDataCompression.Text = "Enable Data Compression"
        '
        'chkSingleLogFile
        '
        Me.chkSingleLogFile.Location = New System.Drawing.Point(416, 99)
        Me.chkSingleLogFile.Name = "chkSingleLogFile"
        Me.chkSingleLogFile.Size = New System.Drawing.Size(156, 24)
        Me.chkSingleLogFile.TabIndex = 19
        Me.chkSingleLogFile.Text = "Single Log File"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(343, 417)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 20
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(424, 417)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 21
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(505, 417)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 22
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'grdLogicals
        '
        Me.grdLogicals.AllowUserToResizeRows = False
        Me.grdLogicals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grdLogicals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdLogicals.Location = New System.Drawing.Point(95, 278)
        Me.grdLogicals.MultiSelect = False
        Me.grdLogicals.Name = "grdLogicals"
        Me.grdLogicals.Size = New System.Drawing.Size(485, 130)
        Me.grdLogicals.TabIndex = 23
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.toolStripSeparator, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton, Me.toolStripSeparator1, Me.HelpToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(594, 25)
        Me.ToolStrip1.TabIndex = 24
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "&New"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Enabled = False
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Enabled = False
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Enabled = False
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CutToolStripButton.Text = "C&ut"
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Enabled = False
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyToolStripButton.Text = "&Copy"
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Enabled = False
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PasteToolStripButton.Text = "&Paste"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.HelpToolStripButton.Text = "He&lp"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(594, 472)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grdLogicals)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.chkSingleLogFile)
        Me.Controls.Add(Me.chkDataCompression)
        Me.Controls.Add(Me.pnlDebugLogging)
        Me.Controls.Add(Me.txtSmcLocation)
        Me.Controls.Add(Me.chkLogging)
        Me.Controls.Add(Me.txtLogFile)
        Me.Controls.Add(Me.lblSmcLocation)
        Me.Controls.Add(Me.lblEnvironmentSettings)
        Me.Controls.Add(Me.pnlFunctionLogging)
        Me.Controls.Add(Me.pnlSessionLogging)
        Me.Controls.Add(Me.DrillLogFile)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.lblLogFile)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "xfServerPlus INI File Manager"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSessionLogging.ResumeLayout(False)
        Me.pnlFunctionLogging.ResumeLayout(False)
        Me.pnlDebugLogging.ResumeLayout(False)
        CType(Me.grdLogicals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents IniFile As New xfplIniFile()

#Region " FormEvents"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DisableControls()

        'Experimental, not working yet
        txtSmcLocation.DataBindings.Add("Text", IniFile, "CatalogLocation")
        txtLogFile.DataBindings.Add("Text", IniFile, "LogFile")
        chkLogging.DataBindings.Add("Checked", IniFile, "Logging")
        chkDataCompression.DataBindings.Add("Checked", IniFile, "Compression")
        chkSingleLogFile.DataBindings.Add("Checked", IniFile, "SingleLogFile")
        grdLogicals.DataBindings.Add("DataSource", IniFile, "EnvironmentVariables")


    End Sub

#End Region

#Region " Menu and toolbar events"

    Private Sub NewFile(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNew.Click, NewToolStripButton.Click
        IniFile.ResetToDefaults()
        EnableControls()
    End Sub

    Private Sub FileOpen(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click, OpenToolStripButton.Click

        With OpenFileDialog

            .FileName = ""
            .Filter = "xfServerPlus INI Files (xfpl.ini)|xfpl.ini|All INI Files (*.ini)|*.ini|All Files (*.*)|*.*"

            If .ShowDialog() = DialogResult.OK Then
                If IniFile.ReadFile(.FileName) Then
                    EnableControls()
                Else
                    MsgBox(IniFile.ErrorMessage)
                End If
            End If

        End With

    End Sub

    Private Sub FileClose(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileClose.Click
        IniFile.ResetToDefaults()
        DisableControls()
    End Sub

    Private Sub FileSave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileSave.Click, SaveToolStripButton.Click
        IniFile.SaveFile()
    End Sub

    Private Sub FileSaveAs(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileSaveAs.Click
        MessageBox.Show("Not implemented", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub FileExit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        Me.Close()
    End Sub

    Private Sub HelpAbout(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click, HelpToolStripButton.Click
        Dim frmAbout As New frmAboutBox()
        frmAbout.ShowDialog(Me)
    End Sub

#End Region

#Region " UI Form Events"

    Private Sub DrillLogFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrillLogFile.Click

        With OpenFileDialog
            If txtLogFile.Text <> "" Then .FileName = txtLogFile.Text
            .Filter = "xfServerPlus INI Files (xfpl.log)|xfpl.log|All Log Files (*.log)|*.log|All Files (*.*)|*.*"
            If .ShowDialog() = DialogResult.OK Then
                txtLogFile.Text = .FileName
            End If
        End With


    End Sub

    Private Sub SmcLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSmcLocation.TextChanged
        IniFile.CatalogLocation = txtSmcLocation.Text
    End Sub

    Private Sub LogFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLogFile.TextChanged
        IniFile.LogFile = txtLogFile.Text
    End Sub

    Private Sub Logging_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLogging.CheckedChanged
        IniFile.Logging = chkLogging.Checked
    End Sub

    Private Sub Compression_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDataCompression.CheckedChanged
        IniFile.Compression = chkDataCompression.Checked
    End Sub

    Private Sub SingleLogFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSingleLogFile.CheckedChanged
        IniFile.SingleLogFile = chkSingleLogFile.Checked
    End Sub


    Private Sub lstLogicals_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnEdit.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub lstLogicals_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnEdit.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim frmEv As New frmEnvVar()
        With frmEv
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                'Add the new environment variable to the IniFile object
                IniFile.EnvironmentVariables.Add(.EnvironmentVariable)
            End If
        End With

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim frmEv As New frmEnvVar()
        frmEv.ShowDialog(Me)
    End Sub

#End Region

#Region " Utility routines"

    Private Sub EnableControls()

        'SMC location controls
        lblSmcLocation.Enabled = True
        txtSmcLocation.Enabled = True

        'Log file name controls
        lblLogFile.Enabled = True
        txtLogFile.Enabled = True
        DrillLogFile.Enabled = True

        'Option checkboxes
        chkLogging.Enabled = True
        chkDataCompression.Enabled = True
        chkSingleLogFile.Enabled = True

        'Logging detail panels
        pnlSessionLogging.Enabled = True
        pnlFunctionLogging.Enabled = True
        pnlDebugLogging.Enabled = True

        'Environment settings controls
        lblEnvironmentSettings.Enabled = True
        grdLogicals.Enabled = True
        btnNew.Enabled = True
        'btnEdit.Enabled = True     'Enabled when an item is selected
        'btnDelete.Enabled = True   'Enabled when an item is selected

        'Menu entries
        mnuFileClose.Enabled = True
        mnuFileSave.Enabled = True
        mnuFileSaveAs.Enabled = True

        'Toolbar buttons
        SaveToolStripButton.Enabled = True

        'Status bar test
        StatusBarPanel1.Text = OpenFileDialog.FileName

    End Sub

    Private Sub DisableControls()

        'SMC location controls
        lblSmcLocation.Enabled = False
        txtSmcLocation.Enabled = False

        'Log file name controls
        lblLogFile.Enabled = False
        txtLogFile.Enabled = False
        DrillLogFile.Enabled = False

        'Option checkboxes
        chkLogging.Enabled = False
        chkDataCompression.Enabled = False
        chkSingleLogFile.Enabled = False

        'Logging detail panels
        pnlSessionLogging.Enabled = False
        pnlFunctionLogging.Enabled = False
        pnlDebugLogging.Enabled = False

        'Environment settings controls
        lblEnvironmentSettings.Enabled = False
        grdLogicals.Enabled = False
        btnNew.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False

        'Menu entries
        mnuFileClose.Enabled = False
        mnuFileSave.Enabled = False
        mnuFileSaveAs.Enabled = False

        'Toolbar buttons
        SaveToolStripButton.Enabled = False

        'Status bar test
        StatusBarPanel1.Text = "No file open"

    End Sub

#End Region

    Private Sub IniFile_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Handles IniFile.PropertyChanged

        Exit Sub

        Select Case e.PropertyName

            Case "SessionLogging"
                Select Case IniFile.SessionLogging
                    Case xfplIniFile.LoggingLevel.None
                        rbSessionLoggingNone.Checked = True
                    Case xfplIniFile.LoggingLevel.Critical
                        rbSessionLoggingCritical.Checked = True
                    Case xfplIniFile.LoggingLevel.All
                        rbSessionLoggingAll.Checked = True
                End Select

            Case "FunctionLogging"
                Select Case IniFile.FunctionLogging
                    Case xfplIniFile.LoggingLevel.None
                        rbFunctionLoggingNone.Checked = True
                    Case xfplIniFile.LoggingLevel.Critical
                        rbFunctionLoggingCritical.Checked = True
                    Case xfplIniFile.LoggingLevel.All
                        rbFunctionLoggingAll.Checked = True
                End Select

            Case "DebugLogging"
                Select Case IniFile.DebugLogging
                    Case xfplIniFile.DebugLoggingLevel.None
                        rbDebugLoggingNone.Checked = True
                    Case xfplIniFile.DebugLoggingLevel.Normal
                        rbDebugLoggingNormal.Checked = True
                    Case xfplIniFile.DebugLoggingLevel.Extended
                        rbDebugLoggingExtended.Checked = True
                End Select
        End Select

    End Sub

End Class
