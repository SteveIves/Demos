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
        Me.MainMenu = New System.Windows.Forms.MenuStrip
        Me.MnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSynergyTools = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRepository = New System.Windows.Forms.ToolStripMenuItem
        Me.MainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFile, Me.MnuSynergyTools})
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(792, 24)
        Me.MainMenu.TabIndex = 0
        Me.MainMenu.Text = "MenuStrip1"
        '
        'MnuFile
        '
        Me.MnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuExit})
        Me.MnuFile.Name = "MnuFile"
        Me.MnuFile.Size = New System.Drawing.Size(35, 20)
        Me.MnuFile.Text = "&File"
        '
        'MnuExit
        '
        Me.MnuExit.Name = "MnuExit"
        Me.MnuExit.Size = New System.Drawing.Size(152, 22)
        Me.MnuExit.Text = "E&xit"
        '
        'MnuSynergyTools
        '
        Me.MnuSynergyTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuRepository})
        Me.MnuSynergyTools.Name = "MnuSynergyTools"
        Me.MnuSynergyTools.Size = New System.Drawing.Size(87, 20)
        Me.MnuSynergyTools.Text = "&Synergy Tools"
        '
        'MnuRepository
        '
        Me.MnuRepository.Name = "MnuRepository"
        Me.MnuRepository.Size = New System.Drawing.Size(152, 22)
        Me.MnuRepository.Text = "&Repository"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 490)
        Me.Controls.Add(Me.MainMenu)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MainMenu
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MainMenu.ResumeLayout(False)
        Me.MainMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSynergyTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRepository As System.Windows.Forms.ToolStripMenuItem

End Class
