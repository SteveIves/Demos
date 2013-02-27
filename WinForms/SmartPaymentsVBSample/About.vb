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
    Friend WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents ButCancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(About))
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.ButCancel = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
        Me.pictureBox1.Location = New System.Drawing.Point(24, 8)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(400, 112)
        Me.pictureBox1.TabIndex = 1
        Me.pictureBox1.TabStop = False
        '
        'label1
        '
        Me.label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(120, 128)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(216, 24)
        Me.label1.TabIndex = 2
        Me.label1.Text = "SmartPayments for Windows (VB.NET)"
        '
        'label2
        '
        Me.label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(160, 144)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(136, 23)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Copyright (c) 2001-2004"
        '
        'ButCancel
        '
        Me.ButCancel.Location = New System.Drawing.Point(192, 248)
        Me.ButCancel.Name = "ButCancel"
        Me.ButCancel.TabIndex = 4
        Me.ButCancel.Text = "Close"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 72)
        Me.Label3.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(296, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 72)
        Me.Label4.TabIndex = 6
        '
        'About
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(456, 277)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButCancel)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.pictureBox1)
        Me.MaximizeBox = False
        Me.Name = "About"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label3.Text = "TPI Software, LLC" & vbCrLf & "17720 NE 65th Street" & vbCrLf & "Suite 202" & vbCrLf & "Redmond, WA 98052"
        Label4.Text = "www.TPISoft.com" & vbCrLf & "sales@tpisoft.com" & vbCrLf & "(425) 882-0921"
    End Sub

    Private Sub ButCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButCancel.Click
        Close()
    End Sub
End Class
