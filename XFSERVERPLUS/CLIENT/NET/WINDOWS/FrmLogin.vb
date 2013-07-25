Public Class FrmLogin
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents TxtPass As System.Windows.Forms.TextBox
    Friend WithEvents BtnLogon As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtUser = New System.Windows.Forms.TextBox
        Me.TxtPass = New System.Windows.Forms.TextBox
        Me.BtnLogon = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Name"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "password"
        '
        'TxtUser
        '
        Me.TxtUser.Location = New System.Drawing.Point(96, 24)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.Size = New System.Drawing.Size(184, 20)
        Me.TxtUser.TabIndex = 2
        Me.TxtUser.Text = ""
        '
        'TxtPass
        '
        Me.TxtPass.Location = New System.Drawing.Point(96, 56)
        Me.TxtPass.Name = "TxtPass"
        Me.TxtPass.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.TxtPass.Size = New System.Drawing.Size(184, 20)
        Me.TxtPass.TabIndex = 3
        Me.TxtPass.Text = ""
        '
        'BtnLogon
        '
        Me.BtnLogon.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnLogon.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnLogon.Location = New System.Drawing.Point(208, 88)
        Me.BtnLogon.Name = "BtnLogon"
        Me.BtnLogon.TabIndex = 4
        Me.BtnLogon.Text = "Logon"
        '
        'FrmLogin
        '
        Me.AcceptButton = Me.BtnLogon
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(288, 118)
        Me.Controls.Add(Me.BtnLogon)
        Me.Controls.Add(Me.TxtPass)
        Me.Controls.Add(Me.TxtUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Login"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnLogon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogon.Click
        sUsername = Me.TxtUser.Text.ToUpper
        sPassword = Me.TxtPass.Text.ToUpper
        bEntered = True
        Me.Hide()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        With Me
            .TxtUser.Text = "student1"
            .TxtPass.Text = "student1"
        End With
    End Sub
End Class
