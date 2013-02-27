<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel = New System.Windows.Forms.Panel
        Me.txtExcludeAdditional = New System.Windows.Forms.TextBox
        Me.chkExcludeAdditional = New System.Windows.Forms.CheckBox
        Me.chkExcludeWeekends = New System.Windows.Forms.CheckBox
        Me.DisplayMode = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(353, 108)
        Me.Label1.TabIndex = 0
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.txtExcludeAdditional)
        Me.Panel.Controls.Add(Me.chkExcludeAdditional)
        Me.Panel.Controls.Add(Me.chkExcludeWeekends)
        Me.Panel.Controls.Add(Me.DisplayMode)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel.Location = New System.Drawing.Point(0, 0)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(997, 35)
        Me.Panel.TabIndex = 1
        '
        'txtExcludeAdditional
        '
        Me.txtExcludeAdditional.Location = New System.Drawing.Point(519, 8)
        Me.txtExcludeAdditional.Name = "txtExcludeAdditional"
        Me.txtExcludeAdditional.Size = New System.Drawing.Size(38, 20)
        Me.txtExcludeAdditional.TabIndex = 4
        Me.txtExcludeAdditional.Text = "6"
        '
        'chkExcludeAdditional
        '
        Me.chkExcludeAdditional.AutoSize = True
        Me.chkExcludeAdditional.Checked = True
        Me.chkExcludeAdditional.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExcludeAdditional.Location = New System.Drawing.Point(375, 9)
        Me.chkExcludeAdditional.Name = "chkExcludeAdditional"
        Me.chkExcludeAdditional.Size = New System.Drawing.Size(137, 17)
        Me.chkExcludeAdditional.TabIndex = 3
        Me.chkExcludeAdditional.Text = "Exclude additional days"
        Me.chkExcludeAdditional.UseVisualStyleBackColor = True
        '
        'chkExcludeWeekends
        '
        Me.chkExcludeWeekends.AutoSize = True
        Me.chkExcludeWeekends.Checked = True
        Me.chkExcludeWeekends.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExcludeWeekends.Location = New System.Drawing.Point(242, 9)
        Me.chkExcludeWeekends.Name = "chkExcludeWeekends"
        Me.chkExcludeWeekends.Size = New System.Drawing.Size(116, 17)
        Me.chkExcludeWeekends.TabIndex = 2
        Me.chkExcludeWeekends.Text = "Exclude weekends"
        Me.chkExcludeWeekends.UseVisualStyleBackColor = True
        '
        'DisplayMode
        '
        Me.DisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DisplayMode.FormattingEnabled = True
        Me.DisplayMode.Items.AddRange(New Object() {"Countdown", "Hours", "Minutes", "Seconds"})
        Me.DisplayMode.Location = New System.Drawing.Point(50, 6)
        Me.DisplayMode.Name = "DisplayMode"
        Me.DisplayMode.Size = New System.Drawing.Size(175, 21)
        Me.DisplayMode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Display"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 178)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SPC Countdown"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents DisplayMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkExcludeWeekends As System.Windows.Forms.CheckBox
    Friend WithEvents txtExcludeAdditional As System.Windows.Forms.TextBox
    Friend WithEvents chkExcludeAdditional As System.Windows.Forms.CheckBox

End Class
