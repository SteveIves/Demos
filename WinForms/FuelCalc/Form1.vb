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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtUsGallons As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtUsGallonCost As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtLitres As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtLitreCost As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtExchangeRate As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CostUS As System.Windows.Forms.TextBox
    Friend WithEvents CostUK As System.Windows.Forms.TextBox
    Friend WithEvents BtnCalc As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtUsGallons = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtUsGallonCost = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtLitres = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtLitreCost = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtExchangeRate = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.CostUS = New System.Windows.Forms.TextBox
        Me.CostUK = New System.Windows.Forms.TextBox
        Me.BtnCalc = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fuel quantity (US Gallons)"
        '
        'TxtUsGallons
        '
        Me.TxtUsGallons.Location = New System.Drawing.Point(228, 20)
        Me.TxtUsGallons.Name = "TxtUsGallons"
        Me.TxtUsGallons.Size = New System.Drawing.Size(100, 20)
        Me.TxtUsGallons.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cost per US gallon ($)"
        '
        'TxtUsGallonCost
        '
        Me.TxtUsGallonCost.Location = New System.Drawing.Point(228, 44)
        Me.TxtUsGallonCost.Name = "TxtUsGallonCost"
        Me.TxtUsGallonCost.Size = New System.Drawing.Size(100, 20)
        Me.TxtUsGallonCost.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(208, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fuel quantity (Litres)"
        '
        'TxtLitres
        '
        Me.TxtLitres.Location = New System.Drawing.Point(228, 84)
        Me.TxtLitres.Name = "TxtLitres"
        Me.TxtLitres.ReadOnly = True
        Me.TxtLitres.Size = New System.Drawing.Size(100, 20)
        Me.TxtLitres.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(208, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cost per Litre (pounds)"
        '
        'TxtLitreCost
        '
        Me.TxtLitreCost.Location = New System.Drawing.Point(228, 112)
        Me.TxtLitreCost.Name = "TxtLitreCost"
        Me.TxtLitreCost.Size = New System.Drawing.Size(100, 20)
        Me.TxtLitreCost.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(208, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Exchange rate ($/pound)"
        '
        'TxtExchangeRate
        '
        Me.TxtExchangeRate.Location = New System.Drawing.Point(228, 140)
        Me.TxtExchangeRate.Name = "TxtExchangeRate"
        Me.TxtExchangeRate.Size = New System.Drawing.Size(100, 20)
        Me.TxtExchangeRate.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 212)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(208, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Cost of fuel in US ($)"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 240)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(208, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Cost of fuel in UK ($)"
        '
        'CostUS
        '
        Me.CostUS.Location = New System.Drawing.Point(228, 208)
        Me.CostUS.Name = "CostUS"
        Me.CostUS.ReadOnly = True
        Me.CostUS.Size = New System.Drawing.Size(100, 20)
        Me.CostUS.TabIndex = 12
        '
        'CostUK
        '
        Me.CostUK.Location = New System.Drawing.Point(228, 236)
        Me.CostUK.Name = "CostUK"
        Me.CostUK.ReadOnly = True
        Me.CostUK.Size = New System.Drawing.Size(100, 20)
        Me.CostUK.TabIndex = 13
        '
        'BtnCalc
        '
        Me.BtnCalc.Location = New System.Drawing.Point(228, 276)
        Me.BtnCalc.Name = "BtnCalc"
        Me.BtnCalc.Size = New System.Drawing.Size(100, 23)
        Me.BtnCalc.TabIndex = 14
        Me.BtnCalc.Text = "Calculate"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(352, 314)
        Me.Controls.Add(Me.BtnCalc)
        Me.Controls.Add(Me.CostUK)
        Me.Controls.Add(Me.CostUS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtExchangeRate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtLitreCost)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtLitres)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtUsGallonCost)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtUsGallons)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "US vs UK Gas Cost"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub BtnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalc.Click

        TxtLitres.Text = TxtUsGallons.Text * 3.7854118
        CostUS.Text = TxtUsGallons.Text * TxtUsGallonCost.Text
        CostUK.Text = (TxtLitres.Text * TxtLitreCost.Text) * TxtExchangeRate.Text

    End Sub
End Class
