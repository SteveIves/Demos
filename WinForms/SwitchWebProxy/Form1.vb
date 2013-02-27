Imports Registry = Microsoft.Win32.Registry

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
    Friend WithEvents chkUseProxy As System.Windows.Forms.CheckBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.chkUseProxy = New System.Windows.Forms.CheckBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'chkUseProxy
        '
        Me.chkUseProxy.Location = New System.Drawing.Point(16, 8)
        Me.chkUseProxy.Name = "chkUseProxy"
        Me.chkUseProxy.Size = New System.Drawing.Size(168, 24)
        Me.chkUseProxy.TabIndex = 0
        Me.chkUseProxy.Text = "Use Web Proxy Server"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(96, 40)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(168, 20)
        Me.txtServer.TabIndex = 2
        Me.txtServer.Text = ""
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(96, 72)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(64, 20)
        Me.txtPort.TabIndex = 4
        Me.txtPort.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(40, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Server"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(40, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Port"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(104, 104)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(72, 24)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(192, 104)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancel"
        '
        'Form1
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(280, 144)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnOK, Me.Label2, Me.Label1, Me.txtPort, Me.txtServer, Me.chkUseProxy})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IE Web Proxy Selection"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim OldProxyEnable As Long
    Dim OldProxyServer As String
    Dim OldProxyName As String
    Dim OldProxyPort As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Pos As Long
        Dim Key As Microsoft.Win32.RegistryKey

        'Get current settings from Registry
        Key = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Internet Settings", False)
        OldProxyEnable = Key.GetValue("ProxyEnable")
        OldProxyServer = Key.GetValue("ProxyServer")
        Key.Close()
        Key = Nothing

        'Break out any port number
        Pos = OldProxyServer.IndexOf(":")
        If Pos = -1 Then
            OldProxyName = OldProxyServer
            OldProxyPort = ""
        Else
            OldProxyName = OldProxyServer.Remove(Pos, OldProxyServer.Length - Pos)
            OldProxyPort = OldProxyServer.Remove(0, Pos + 1)
        End If

        'Put current values into UI
        If OldProxyEnable = 1 Then chkUseProxy.Checked = True
        txtServer.Text = OldProxyName
        txtPort.Text = OldProxyPort

        'Setup UI
        txtServer.Enabled = chkUseProxy.Checked
        txtPort.Enabled = chkUseProxy.Checked

    End Sub

    Private Sub chkUseProxy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseProxy.CheckedChanged

        txtServer.Enabled = chkUseProxy.Checked
        txtPort.Enabled = chkUseProxy.Checked

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        'Save current settings to the Registry

        Dim NewProxyEnable As Object
        Dim NewProxyServer As String
        Dim NewProxyName As String
        Dim NewProxyPort As String

        Dim OK As Boolean

        OK = True

        'Get data from UI
        If chkUseProxy.Checked Then
            NewProxyEnable = 1
        Else
            NewProxyEnable = 0
        End If

        NewProxyName = txtServer.Text.Trim
        NewProxyPort = txtPort.Text.Trim

        'Validate data
        If NewProxyEnable = 1 Then
            If NewProxyName = "" Then
                MsgBox("Server name is required")
                With txtServer
                    .Text = OldProxyName
                    .Focus()
                End With
                OK = False
            End If
        End If

        If OK Then
            If NewProxyPort = "" Then
                NewProxyServer = NewProxyName
            Else
                If IsNumeric(NewProxyPort) Then
                    NewProxyServer = NewProxyName & ":" & NewProxyPort
                Else
                    MsgBox("Port must be numeric")
                    With txtPort
                        .Text = OldProxyPort
                        .Focus()
                    End With
                    OK = False
                End If
            End If
        End If

        If OK Then

            Dim Key As Microsoft.Win32.RegistryKey

            Key = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Internet Settings", True)
            Key.SetValue("ProxyEnable", NewProxyEnable)
            Key.SetValue("ProxyServer", NewProxyServer)
            Key.Close()
            Key = Nothing

            End

        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        End

    End Sub

End Class
