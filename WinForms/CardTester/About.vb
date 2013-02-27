Public Class About
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
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(About))
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(96, 120)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(224, 24)
        Me.label1.TabIndex = 2
        Me.label1.Text = "SmartPayments     Version 2.0"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(96, 152)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(224, 23)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Copyright (c) 2001-04, TPI Software, LLC"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(96, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(224, 24)
        Me.Label3.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(96, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(224, 23)
        Me.Label4.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(96, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(224, 23)
        Me.Label5.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(96, 248)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(224, 23)
        Me.Label6.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(96, 272)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(224, 23)
        Me.Label7.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(96, 296)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(224, 23)
        Me.Label8.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(96, 320)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(224, 64)
        Me.Label9.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(32, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(400, 104)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'About
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(456, 405)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label3.Text = "www.tpisoft.com"
        Label4.Text = "17720 NE 65th Street, Suite 202"
        Label5.Text = "Redmond, WA 98052"
        Label6.Text = "(425) 882-0921"
        Label7.Text = "Sales: sales@tpisoft.com"
        Label8.Text = "Support: support@tpisoft.com"
        Label9.Text = "TPI Software offers a complete line of payment solutions to process credit, debit, check, ebt and gift/loyalty transactions. For more details please visit our web site."
    End Sub
End Class
