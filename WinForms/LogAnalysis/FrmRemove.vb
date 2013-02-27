Public Class FrmRemove
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents rbCurrent As System.Windows.Forms.RadioButton
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents cbIni As System.Windows.Forms.CheckBox
    Friend WithEvents cbSmc As System.Windows.Forms.CheckBox
    Friend WithEvents cbPacket As System.Windows.Forms.CheckBox
    Friend WithEvents cbDebug As System.Windows.Forms.CheckBox
    Friend WithEvents cbPar As System.Windows.Forms.CheckBox
    Friend WithEvents cbInPar As System.Windows.Forms.CheckBox
    Friend WithEvents cbOutPar As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.rbCurrent = New System.Windows.Forms.RadioButton
        Me.rbAll = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.cbIni = New System.Windows.Forms.CheckBox
        Me.cbSmc = New System.Windows.Forms.CheckBox
        Me.cbPacket = New System.Windows.Forms.CheckBox
        Me.cbDebug = New System.Windows.Forms.CheckBox
        Me.cbPar = New System.Windows.Forms.CheckBox
        Me.cbInPar = New System.Windows.Forms.CheckBox
        Me.cbOutPar = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'rbCurrent
        '
        Me.rbCurrent.Checked = True
        Me.rbCurrent.Location = New System.Drawing.Point(20, 24)
        Me.rbCurrent.Name = "rbCurrent"
        Me.rbCurrent.Size = New System.Drawing.Size(184, 24)
        Me.rbCurrent.TabIndex = 0
        Me.rbCurrent.TabStop = True
        Me.rbCurrent.Text = "Remove data from selected log"
        '
        'rbAll
        '
        Me.rbAll.Location = New System.Drawing.Point(20, 52)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(156, 24)
        Me.rbAll.TabIndex = 1
        Me.rbAll.Text = "Remove data from all logs"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbCurrent)
        Me.GroupBox1.Controls.Add(Me.rbAll)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(220, 84)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Logs to process"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbOutPar)
        Me.GroupBox2.Controls.Add(Me.cbInPar)
        Me.GroupBox2.Controls.Add(Me.cbPar)
        Me.GroupBox2.Controls.Add(Me.cbDebug)
        Me.GroupBox2.Controls.Add(Me.cbPacket)
        Me.GroupBox2.Controls.Add(Me.cbSmc)
        Me.GroupBox2.Controls.Add(Me.cbIni)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(216, 228)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data to remove"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(64, 344)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(148, 344)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "&Cancel"
        '
        'cbIni
        '
        Me.cbIni.Location = New System.Drawing.Point(16, 20)
        Me.cbIni.Name = "cbIni"
        Me.cbIni.Size = New System.Drawing.Size(188, 24)
        Me.cbIni.TabIndex = 0
        Me.cbIni.Text = "INI file logging"
        '
        'cbSmc
        '
        Me.cbSmc.Location = New System.Drawing.Point(16, 48)
        Me.cbSmc.Name = "cbSmc"
        Me.cbSmc.Size = New System.Drawing.Size(188, 24)
        Me.cbSmc.TabIndex = 1
        Me.cbSmc.Text = "SMC logging"
        '
        'cbPacket
        '
        Me.cbPacket.Location = New System.Drawing.Point(16, 76)
        Me.cbPacket.Name = "cbPacket"
        Me.cbPacket.Size = New System.Drawing.Size(188, 24)
        Me.cbPacket.TabIndex = 2
        Me.cbPacket.Text = "Packet logging"
        '
        'cbDebug
        '
        Me.cbDebug.Location = New System.Drawing.Point(16, 104)
        Me.cbDebug.Name = "cbDebug"
        Me.cbDebug.Size = New System.Drawing.Size(188, 24)
        Me.cbDebug.TabIndex = 3
        Me.cbDebug.Text = "Session debug logging"
        '
        'cbPar
        '
        Me.cbPar.Location = New System.Drawing.Point(16, 132)
        Me.cbPar.Name = "cbPar"
        Me.cbPar.Size = New System.Drawing.Size(188, 24)
        Me.cbPar.TabIndex = 4
        Me.cbPar.Text = "Parameter data"
        '
        'cbInPar
        '
        Me.cbInPar.Location = New System.Drawing.Point(16, 160)
        Me.cbInPar.Name = "cbInPar"
        Me.cbInPar.Size = New System.Drawing.Size(188, 24)
        Me.cbInPar.TabIndex = 5
        Me.cbInPar.Text = "Incoming parameter data"
        '
        'cbOutPar
        '
        Me.cbOutPar.Location = New System.Drawing.Point(16, 188)
        Me.cbOutPar.Name = "cbOutPar"
        Me.cbOutPar.Size = New System.Drawing.Size(188, 24)
        Me.cbOutPar.TabIndex = 6
        Me.cbOutPar.Text = "Outbound parameter data"
        '
        'FrmRemove
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(234, 376)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRemove"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Remove Log Data"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If cbIni.Checked Or cbSmc.Checked Or cbPacket.Checked Or cbDebug.Checked Or cbPar.Checked Or cbInPar.Checked Or cbOutPar.Checked Then
            DialogResult = DialogResult.OK
            Me.Hide()
        Else
            MsgBox("No actions selected", , "Warning")
        End If


    End Sub
End Class
