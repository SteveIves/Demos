Public Class SetupForm
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
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents trainingMode As System.Windows.Forms.GroupBox
    Friend WithEvents isTraining As System.Windows.Forms.RadioButton
    Friend WithEvents isNotTraining As System.Windows.Forms.RadioButton
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Password As System.Windows.Forms.TextBox
    Friend WithEvents UserID As System.Windows.Forms.TextBox
    Friend WithEvents Register As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.Register = New System.Windows.Forms.TextBox
        Me.Password = New System.Windows.Forms.TextBox
        Me.UserID = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.trainingMode = New System.Windows.Forms.GroupBox
        Me.isTraining = New System.Windows.Forms.RadioButton
        Me.isNotTraining = New System.Windows.Forms.RadioButton
        Me.OK = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.groupBox1.SuspendLayout()
        Me.trainingMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.Register)
        Me.groupBox1.Controls.Add(Me.Password)
        Me.groupBox1.Controls.Add(Me.UserID)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Location = New System.Drawing.Point(8, 40)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(312, 136)
        Me.groupBox1.TabIndex = 1
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "SmartPayments Setup"
        '
        'Register
        '
        Me.Register.Location = New System.Drawing.Point(128, 88)
        Me.Register.Name = "Register"
        Me.Register.TabIndex = 5
        Me.Register.Text = ""
        '
        'Password
        '
        Me.Password.Location = New System.Drawing.Point(128, 56)
        Me.Password.Name = "Password"
        Me.Password.TabIndex = 4
        Me.Password.Text = "DEMO"
        '
        'UserID
        '
        Me.UserID.Location = New System.Drawing.Point(128, 24)
        Me.UserID.Name = "UserID"
        Me.UserID.TabIndex = 3
        Me.UserID.Text = "DEMO"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(16, 88)
        Me.label5.Name = "label5"
        Me.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label5.TabIndex = 4
        Me.label5.Text = "Register Number"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(16, 56)
        Me.label4.Name = "label4"
        Me.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label4.TabIndex = 3
        Me.label4.Text = "Password"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(16, 24)
        Me.label3.Name = "label3"
        Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label3.TabIndex = 2
        Me.label3.Text = "User ID"
        '
        'trainingMode
        '
        Me.trainingMode.Controls.Add(Me.isTraining)
        Me.trainingMode.Controls.Add(Me.isNotTraining)
        Me.trainingMode.Location = New System.Drawing.Point(80, 200)
        Me.trainingMode.Name = "trainingMode"
        Me.trainingMode.Size = New System.Drawing.Size(144, 80)
        Me.trainingMode.TabIndex = 7
        Me.trainingMode.TabStop = False
        Me.trainingMode.Text = "Training Mode"
        '
        'isTraining
        '
        Me.isTraining.Location = New System.Drawing.Point(16, 24)
        Me.isTraining.Name = "isTraining"
        Me.isTraining.Size = New System.Drawing.Size(104, 16)
        Me.isTraining.TabIndex = 7
        Me.isTraining.Text = "True"
        '
        'isNotTraining
        '
        Me.isNotTraining.Location = New System.Drawing.Point(16, 48)
        Me.isNotTraining.Name = "isNotTraining"
        Me.isNotTraining.TabIndex = 8
        Me.isNotTraining.Text = "False"
        '
        'OK
        '
        Me.OK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK.Location = New System.Drawing.Point(56, 312)
        Me.OK.Name = "OK"
        Me.OK.TabIndex = 10
        Me.OK.Text = "OK"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(184, 312)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.TabIndex = 11
        Me.Cancel.Text = "Cancel"
        '
        'SetupForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(336, 357)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.trainingMode)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "SetupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SetupForm"
        Me.groupBox1.ResumeLayout(False)
        Me.trainingMode.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        MainForm.objAppData.UserID = UserID.Text
        MainForm.objAppData.Password = Password.Text
        MainForm.objAppData.Register = Register.Text

        If isTraining.Checked = True Then
            MainForm.objAppData.TrainingMode = "T"
        Else
            MainForm.objAppData.TrainingMode = "F"
        End If
        
        MainForm.objSetup.SaveSettings(MainForm.SmartPaymentsConfFileName, MainForm.objAppData)

    End Sub

    Private Sub SetupForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UserID.Text = MainForm.objAppData.UserID
        Password.Text = MainForm.objAppData.Password
        Register.Text = MainForm.objAppData.Register
        If MainForm.objAppData.TrainingMode = "T" Then
            isTraining.Checked = True
        Else
            isNotTraining.Checked = True
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Close()
    End Sub
End Class

