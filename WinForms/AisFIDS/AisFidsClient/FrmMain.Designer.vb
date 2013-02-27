<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.BtnShow = New System.Windows.Forms.Button
        Me.BtnHide = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'BtnShow
        '
        Me.BtnShow.Location = New System.Drawing.Point(12, 12)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(75, 23)
        Me.BtnShow.TabIndex = 0
        Me.BtnShow.Text = "Show Browser"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'BtnHide
        '
        Me.BtnHide.Enabled = False
        Me.BtnHide.Location = New System.Drawing.Point(120, 12)
        Me.BtnHide.Name = "BtnHide"
        Me.BtnHide.Size = New System.Drawing.Size(75, 23)
        Me.BtnHide.TabIndex = 1
        Me.BtnHide.Text = "Hide"
        Me.BtnHide.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(207, 45)
        Me.Controls.Add(Me.BtnHide)
        Me.Controls.Add(Me.BtnShow)
        Me.Name = "FrmMain"
        Me.Text = "Display Controller"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents BtnHide As System.Windows.Forms.Button
End Class
