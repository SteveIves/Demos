
Public Class MainForm
    Inherits System.Windows.Forms.Form


    Public Shared SmartPaymentsConfFileName As String
    Public Shared objSetup As SmartPayments.VB.Configuration.Setup
    Friend WithEvents TxMenuItemEBT As System.Windows.Forms.MenuItem
    Public Shared objAppData As SmartPayments.VB.Configuration.AppConfigurationData

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call


        '"SmartPayments.cfg" - default config file
        'set the location of the file based on where
        'the assembly is located
        SmartPaymentsConfFileName = Microsoft.VisualBasic.Left(System.Reflection.Assembly.GetExecutingAssembly.Location, InStr(System.Reflection.Assembly.GetExecutingAssembly.Location, "\bin\")) & "\SmartPayments.cfg"

        objAppData = objSetup.LoadSettings(SmartPaymentsConfFileName)


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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents ExitmenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents FileMenu As System.Windows.Forms.MenuItem
    Friend WithEvents TxMenu As System.Windows.Forms.MenuItem
    Friend WithEvents EODMenu As System.Windows.Forms.MenuItem
    Friend WithEvents SetupMenu As System.Windows.Forms.MenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.MenuItem
    Friend WithEvents TxMenuItemCredit As System.Windows.Forms.MenuItem
    Friend WithEvents TxMenuItemDebit As System.Windows.Forms.MenuItem
    Friend WithEvents TxMenuItemCheck As System.Windows.Forms.MenuItem
    Friend WithEvents HelpMenuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents logo As System.Windows.Forms.PictureBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.FileMenu = New System.Windows.Forms.MenuItem
        Me.ExitmenuItem = New System.Windows.Forms.MenuItem
        Me.TxMenu = New System.Windows.Forms.MenuItem
        Me.TxMenuItemCredit = New System.Windows.Forms.MenuItem
        Me.TxMenuItemDebit = New System.Windows.Forms.MenuItem
        Me.TxMenuItemCheck = New System.Windows.Forms.MenuItem
        Me.TxMenuItemEBT = New System.Windows.Forms.MenuItem
        Me.EODMenu = New System.Windows.Forms.MenuItem
        Me.SetupMenu = New System.Windows.Forms.MenuItem
        Me.HelpMenu = New System.Windows.Forms.MenuItem
        Me.HelpMenuAbout = New System.Windows.Forms.MenuItem
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.logo = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FileMenu, Me.TxMenu, Me.EODMenu, Me.SetupMenu, Me.HelpMenu})
        '
        'FileMenu
        '
        Me.FileMenu.Index = 0
        Me.FileMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ExitmenuItem})
        Me.FileMenu.Text = "&File"
        '
        'ExitmenuItem
        '
        Me.ExitmenuItem.Index = 0
        Me.ExitmenuItem.Text = "&Exit"
        '
        'TxMenu
        '
        Me.TxMenu.Index = 1
        Me.TxMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.TxMenuItemCredit, Me.TxMenuItemDebit, Me.TxMenuItemCheck, Me.TxMenuItemEBT})
        Me.TxMenu.Text = "&Transactions"
        '
        'TxMenuItemCredit
        '
        Me.TxMenuItemCredit.Index = 0
        Me.TxMenuItemCredit.Text = "&Credit"
        '
        'TxMenuItemDebit
        '
        Me.TxMenuItemDebit.Index = 1
        Me.TxMenuItemDebit.Text = "&Debit"
        '
        'TxMenuItemCheck
        '
        Me.TxMenuItemCheck.Index = 2
        Me.TxMenuItemCheck.Text = "&Check"
        '
        'TxMenuItemEBT
        '
        Me.TxMenuItemEBT.Index = 3
        Me.TxMenuItemEBT.Text = "&EBT"
        '
        'EODMenu
        '
        Me.EODMenu.Index = 2
        Me.EODMenu.Text = "&End-of-day"
        '
        'SetupMenu
        '
        Me.SetupMenu.Index = 3
        Me.SetupMenu.Text = "&Setup"
        '
        'HelpMenu
        '
        Me.HelpMenu.Index = 4
        Me.HelpMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.HelpMenuAbout})
        Me.HelpMenu.Text = "&Help"
        '
        'HelpMenuAbout
        '
        Me.HelpMenuAbout.Index = 0
        Me.HelpMenuAbout.Text = "&About"
        '
        'StatusBar
        '
        Me.StatusBar.Location = New System.Drawing.Point(0, 258)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(432, 22)
        Me.StatusBar.TabIndex = 1
        Me.StatusBar.Text = "Status"
        '
        'logo
        '
        Me.logo.Image = CType(resources.GetObject("logo.Image"), System.Drawing.Image)
        Me.logo.Location = New System.Drawing.Point(16, 64)
        Me.logo.Name = "logo"
        Me.logo.Size = New System.Drawing.Size(400, 112)
        Me.logo.TabIndex = 3
        Me.logo.TabStop = False
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 280)
        Me.Controls.Add(Me.logo)
        Me.Controls.Add(Me.StatusBar)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SmartPayments for Windows"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub ExitmenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitmenuItem.Click
        Application.Exit()
    End Sub

    Private Sub HelpMenuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpMenuAbout.Click
        Dim dlg = New About()
        dlg.ShowDialog()
        dlg.Dispose()
    End Sub

    Private Sub SetupMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetupMenu.Click
        Dim dlg As New SetupForm()
        If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            SetStatusBar()
        End If
        dlg.Dispose()
    End Sub


    Private Sub TxMenuItemCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxMenuItemCredit.Click
        
        Dim dlg As New CreditTxForm()

        dlg.ShowDialog()
        dlg.Dispose()
    End Sub

    Private Sub TxMenuItemDebit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxMenuItemDebit.Click
        Dim dlg As New DebitTxForm()
        dlg.ShowDialog()
        dlg.Dispose()
    End Sub

    Private Sub TxMenuItemCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxMenuItemCheck.Click
        Dim dlg As New CheckTxForm()

        dlg.ShowDialog()
        dlg.Dispose()
    End Sub

    Private Sub EODMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EODMenu.Click
        Dim dlg As New EODForm()
        dlg.ShowDialog()
        dlg.Dispose()
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetStatusBar()
    End Sub

    Private Sub SetStatusBar()
        If objAppData.TrainingMode = "T" Then
            StatusBar.Text = "Training Mode On"
        Else
            StatusBar.Text = "Training Mode Off"
        End If
    End Sub


    Private Sub TxMenuItemEBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxMenuItemEBT.Click
        Dim dlg As New EBTTxForm()
        dlg.ShowDialog()
        dlg.Dispose()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
