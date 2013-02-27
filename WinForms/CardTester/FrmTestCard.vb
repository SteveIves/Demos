Imports System.Xml
'/* ----------------------------------------------------------------*/
'
'       Copyright © 2001-2004 TPI Software, LLC, All Rights Reserved.
'
'  Project: CardTester
'  Author: Bill Pittman
'  Comments: This Form provides an example of how to use the
'            SmartPayments CardValidator Web Service from TPI Software.
'            This form requires a web reference be set to the
'            CardValidator at the following URL:
'            http://demo.tpisoft.com/SmartPayments/validate.asmx
'            that reads the CardValidator.wsdl at the TPI Software
'            Web Site. The test comand button tests the functions.
'
'   CardValidator Web Service Uses CardValidator.wsdl.
'   CardValidator suports the following function calls:
'
'   GetCardType(CardNum As String) As String
'   ValidCardLength(CardNum As String) As Boolean
'   ValidExpDate(ExpDate As String) As Boolean
'   ValidMod10(CardNum As String) As Boolean
'   ValidCard(CardNum As String, ExpDate As String) As Integer
'   IsCommercialCard(CardNum As String) as Boolean
'
'   You can call each routine indiviually and get a boolean (True/False) response
'   or call the ValidCard routine which returns -1 for true or
'   returns an result number indicating why the card is not valid.
'
'   Return Errors for CardType
'   -1 or True = Good Card
'   1001 - no card number
'   1002 - no exp date
'   1003 - invalid card type
'   1004 - invalid card length
'   1005 - bad mod 10 check
'   1006 - bad expiration date
'/* ----------------------------------------------------------------*/

'Test card Information
'4005550000000019  Exp: 0202        -Visa
'4715000000000008  Exp: 0202        -Visa Comerical Card



Public Class FrmTestCard

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtExpDate As System.Windows.Forms.TextBox
    Friend WithEvents TxtCardNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblIssuer As System.Windows.Forms.Label
    Friend WithEvents BtnTest As System.Windows.Forms.Button
    Friend WithEvents BtnAbout As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents LblCommercialCard As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblCommercialCard = New System.Windows.Forms.Label()
        Me.LblIssuer = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtExpDate = New System.Windows.Forms.TextBox()
        Me.TxtCardNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnTest = New System.Windows.Forms.Button()
        Me.BtnAbout = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblCommercialCard, Me.LblIssuer, Me.Label4, Me.Label3, Me.TxtExpDate, Me.TxtCardNumber, Me.Label2, Me.Label1})
        Me.GroupBox1.Location = New System.Drawing.Point(16, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 152)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Credit Card Information"
        '
        'LblCommercialCard
        '
        Me.LblCommercialCard.Location = New System.Drawing.Point(144, 120)
        Me.LblCommercialCard.Name = "LblCommercialCard"
        Me.LblCommercialCard.Size = New System.Drawing.Size(96, 24)
        Me.LblCommercialCard.TabIndex = 12
        Me.LblCommercialCard.Text = "Commercial Card"
        Me.LblCommercialCard.Visible = False
        '
        'LblIssuer
        '
        Me.LblIssuer.Location = New System.Drawing.Point(144, 88)
        Me.LblIssuer.Name = "LblIssuer"
        Me.LblIssuer.Size = New System.Drawing.Size(144, 24)
        Me.LblIssuer.TabIndex = 11
        Me.LblIssuer.Text = "Issuer"
        Me.LblIssuer.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 24)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Commercial Card:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 24)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Card Issuer:"
        '
        'TxtExpDate
        '
        Me.TxtExpDate.Location = New System.Drawing.Point(144, 56)
        Me.TxtExpDate.Name = "TxtExpDate"
        Me.TxtExpDate.Size = New System.Drawing.Size(32, 20)
        Me.TxtExpDate.TabIndex = 1
        Me.TxtExpDate.Text = ""
        '
        'TxtCardNumber
        '
        Me.TxtCardNumber.Location = New System.Drawing.Point(144, 24)
        Me.TxtCardNumber.Name = "TxtCardNumber"
        Me.TxtCardNumber.Size = New System.Drawing.Size(120, 20)
        Me.TxtCardNumber.TabIndex = 0
        Me.TxtCardNumber.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "ExpDate (MMYY):"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Credit Card Number:"
        '
        'BtnTest
        '
        Me.BtnTest.Location = New System.Drawing.Point(344, 40)
        Me.BtnTest.Name = "BtnTest"
        Me.BtnTest.TabIndex = 2
        Me.BtnTest.Text = "&Test"
        '
        'BtnAbout
        '
        Me.BtnAbout.Location = New System.Drawing.Point(344, 80)
        Me.BtnAbout.Name = "BtnAbout"
        Me.BtnAbout.TabIndex = 3
        Me.BtnAbout.Text = "&About"
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(344, 120)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.TabIndex = 4
        Me.BtnClose.Text = "&Close"
        '
        'FrmTestCard
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(440, 197)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.BtnClose, Me.BtnAbout, Me.GroupBox1, Me.BtnTest})
        Me.MaximizeBox = False
        Me.Name = "FrmTestCard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Credit Card Tester by RichSolutions"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click

        'lets see if it is set to reset
        'if so clear everything and lets do it again
        If BtnTest.Text = "Reset" Then
            TxtCardNumber.Text = ""
            TxtExpDate.Text = ""
            LblIssuer.Visible = False
            LblCommercialCard.Visible = False
            BtnTest.Text = "&Test"
            EnableButtons()
            TxtCardNumber.Focus()
            Exit Sub
        End If

        'dim response values
        Dim intResponse As Integer
        Dim strResponse As String

        'disable the buttons
        DisableButtons()

        'dim the cardvalidator object based in the web reference
        Dim objCardValidator As New validate.CreditCardValidator

        'call the validcard funtion:
        'Return valus
        '-1 or True = Good Card
        '1001 - no card number
        '1002 - no exp date
        '1003 - invalid card type
        '1004 - invalid card length
        '1005 - bad mod 10 check
        '1006 - bad expiration date

        intResponse = objCardValidator.ValidCard(TxtCardNumber.Text, TxtExpDate.Text)

        Select Case intResponse
            Case Is = 0
                strResponse = "Good Card"
            Case Is = 1001  '- no card number
                strResponse = "No Card Number"
            Case Is = 1002  '- no exp date
                strResponse = "No ExpDate"
            Case Is = 1003  '- invalid card type
                strResponse = "Invalid Card Type"
            Case Is = 1004  ' - invalid card length
                strResponse = "Invalid Card Length"
            Case Is = 1005  '- bad mod 10 check
                strResponse = "Card Did not pass Mod 10 Check"
            Case Is = 1006  '- bad expiration date
                strResponse = "Bad ExpDate"
            Case Else     '- unknown
                strResponse = "Unknown Error"
        End Select

        LblIssuer.Text = objCardValidator.GetCardType(TxtCardNumber.Text)
        LblCommercialCard.Text = objCardValidator.IsCommercialCard(TxtCardNumber.Text)

        LblIssuer.Visible = True
        LblCommercialCard.Visible = True

        MsgBox(strResponse, MsgBoxStyle.Information, "Card Tester")

        If intResponse = -1 Then
            BtnTest.Text = "Reset"
        End If
        EnableButtons()
    End Sub
    Private Sub EnableButtons()
        BtnTest.Enabled = True
        BtnAbout.Enabled = True
        BtnClose.Enabled = True
    End Sub
    Private Sub DisableButtons()
        BtnTest.Enabled = False
        BtnAbout.Enabled = False
        BtnClose.Enabled = False
    End Sub

    Private Sub BtnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbout.Click
        Dim dlg = New About()
        dlg.ShowDialog()
        dlg.Dispose()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Application.Exit()
    End Sub

    Private Sub FrmTestCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
