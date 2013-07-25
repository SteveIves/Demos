Public Class FrmItem
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
    Friend WithEvents TxtSKU As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SpinQty As System.Windows.Forms.NumericUpDown
    Friend WithEvents BtnOrder As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtSKU = New System.Windows.Forms.TextBox
        Me.TxtDescription = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SpinQty = New System.Windows.Forms.NumericUpDown
        Me.BtnOrder = New System.Windows.Forms.Button
        CType(Me.SpinQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product"
        '
        'TxtSKU
        '
        Me.TxtSKU.Location = New System.Drawing.Point(80, 16)
        Me.TxtSKU.Name = "TxtSKU"
        Me.TxtSKU.TabIndex = 1
        Me.TxtSKU.Text = ""
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(192, 16)
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(256, 20)
        Me.TxtDescription.TabIndex = 2
        Me.TxtDescription.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Order Quantity"
        '
        'SpinQty
        '
        Me.SpinQty.Location = New System.Drawing.Point(104, 56)
        Me.SpinQty.Name = "SpinQty"
        Me.SpinQty.TabIndex = 4
        '
        'BtnOrder
        '
        Me.BtnOrder.Location = New System.Drawing.Point(376, 88)
        Me.BtnOrder.Name = "BtnOrder"
        Me.BtnOrder.TabIndex = 5
        Me.BtnOrder.Text = "Order"
        '
        'FrmItem
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(472, 126)
        Me.Controls.Add(Me.BtnOrder)
        Me.Controls.Add(Me.SpinQty)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.TxtSKU)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmItem"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrmItem"
        CType(Me.SpinQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOrder.Click
        Me.Hide()
    End Sub
End Class
