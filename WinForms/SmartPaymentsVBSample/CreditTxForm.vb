Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class CreditTxForm

    Inherits System.Windows.Forms.Form

    'Dim Procedure level variables
    Dim strUserName As String
    Dim strPassword As String
    Dim strRegister As String
    Dim TransType As String
    Dim strCardNum As String
    Dim strExpDate As String
    Dim strMagData As String
    Dim strNameOnCard As String
    Dim strAmount As String
    Dim InvNum As String
    Dim strPNRef As String

    Dim strZip As String
    Dim strStreet As String
    Dim strCVNum As String
    Dim strAuthCode As String
    Dim strCustCode As String
    Dim strTipAmt As String
    Dim strTaxAmt As String
    Dim strExtData As String

    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txType As System.Windows.Forms.ComboBox
    Friend WithEvents totalAmt As System.Windows.Forms.TextBox
    Friend WithEvents TaxAmt As System.Windows.Forms.TextBox
    Friend WithEvents SubTotalAmt As System.Windows.Forms.TextBox
    Friend WithEvents cvNum As System.Windows.Forms.TextBox
    Friend WithEvents state As System.Windows.Forms.TextBox
    Friend WithEvents zip As System.Windows.Forms.TextBox
    Friend WithEvents street As System.Windows.Forms.TextBox
    Friend WithEvents CardHolderName As System.Windows.Forms.TextBox
    Friend WithEvents authCode As System.Windows.Forms.TextBox
    Friend WithEvents refNum As System.Windows.Forms.TextBox
    Friend WithEvents ticketNum As System.Windows.Forms.TextBox
    Friend WithEvents cardType As System.Windows.Forms.TextBox
    Friend WithEvents expDate As System.Windows.Forms.TextBox
    Friend WithEvents cardNum As System.Windows.Forms.TextBox
    Friend WithEvents label15 As System.Windows.Forms.Label
    Friend WithEvents label14 As System.Windows.Forms.Label
    Friend WithEvents label13 As System.Windows.Forms.Label
    Friend WithEvents label12 As System.Windows.Forms.Label
    Friend WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Dim strReturn As String


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

    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Clear As System.Windows.Forms.Button
    Friend WithEvents OK As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Clear = New System.Windows.Forms.Button()
        Me.OK = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
        Me.txType = New System.Windows.Forms.ComboBox()
        Me.totalAmt = New System.Windows.Forms.TextBox()
        Me.TaxAmt = New System.Windows.Forms.TextBox()
        Me.SubTotalAmt = New System.Windows.Forms.TextBox()
        Me.cvNum = New System.Windows.Forms.TextBox()
        Me.state = New System.Windows.Forms.TextBox()
        Me.zip = New System.Windows.Forms.TextBox()
        Me.street = New System.Windows.Forms.TextBox()
        Me.CardHolderName = New System.Windows.Forms.TextBox()
        Me.authCode = New System.Windows.Forms.TextBox()
        Me.refNum = New System.Windows.Forms.TextBox()
        Me.ticketNum = New System.Windows.Forms.TextBox()
        Me.cardType = New System.Windows.Forms.TextBox()
        Me.expDate = New System.Windows.Forms.TextBox()
        Me.cardNum = New System.Windows.Forms.TextBox()
        Me.label15 = New System.Windows.Forms.Label()
        Me.label14 = New System.Windows.Forms.Label()
        Me.label13 = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(278, 458)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(72, 24)
        Me.Cancel.TabIndex = 15
        Me.Cancel.Text = "Cancel"
        '
        'Clear
        '
        Me.Clear.Location = New System.Drawing.Point(190, 458)
        Me.Clear.Name = "Clear"
        Me.Clear.Size = New System.Drawing.Size(72, 24)
        Me.Clear.TabIndex = 14
        Me.Clear.Text = "Clear"
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(102, 458)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(72, 24)
        Me.OK.TabIndex = 13
        Me.OK.Text = "OK"
        '
        'txType
        '
        Me.txType.ItemHeight = 13
        Me.txType.Items.AddRange(New Object() {"Sale", "Return", "Void", "Auth", "Force"})
        Me.txType.Location = New System.Drawing.Point(160, 26)
        Me.txType.Name = "txType"
        Me.txType.Size = New System.Drawing.Size(121, 21)
        Me.txType.TabIndex = 0
        Me.txType.TabStop = False
        '
        'totalAmt
        '
        Me.totalAmt.Location = New System.Drawing.Point(160, 408)
        Me.totalAmt.Name = "totalAmt"
        Me.totalAmt.TabIndex = 12
        Me.totalAmt.Text = ""
        '
        'TaxAmt
        '
        Me.TaxAmt.Location = New System.Drawing.Point(160, 376)
        Me.TaxAmt.Name = "TaxAmt"
        Me.TaxAmt.TabIndex = 11
        Me.TaxAmt.Text = "0.00"
        '
        'SubTotalAmt
        '
        Me.SubTotalAmt.Location = New System.Drawing.Point(160, 344)
        Me.SubTotalAmt.Name = "SubTotalAmt"
        Me.SubTotalAmt.TabIndex = 10
        Me.SubTotalAmt.Text = ""
        '
        'cvNum
        '
        Me.cvNum.Location = New System.Drawing.Point(160, 312)
        Me.cvNum.Name = "cvNum"
        Me.cvNum.TabIndex = 9
        Me.cvNum.Text = ""
        '
        'state
        '
        Me.state.Location = New System.Drawing.Point(304, 280)
        Me.state.Name = "state"
        Me.state.Size = New System.Drawing.Size(34, 20)
        Me.state.TabIndex = 8
        Me.state.Text = ""
        '
        'zip
        '
        Me.zip.Location = New System.Drawing.Point(160, 280)
        Me.zip.Name = "zip"
        Me.zip.TabIndex = 7
        Me.zip.Text = ""
        '
        'street
        '
        Me.street.Location = New System.Drawing.Point(160, 248)
        Me.street.Name = "street"
        Me.street.Size = New System.Drawing.Size(184, 20)
        Me.street.TabIndex = 6
        Me.street.Text = ""
        '
        'CardHolderName
        '
        Me.CardHolderName.Location = New System.Drawing.Point(160, 216)
        Me.CardHolderName.Name = "CardHolderName"
        Me.CardHolderName.Size = New System.Drawing.Size(184, 20)
        Me.CardHolderName.TabIndex = 5
        Me.CardHolderName.Text = ""
        '
        'authCode
        '
        Me.authCode.Location = New System.Drawing.Point(160, 184)
        Me.authCode.Name = "authCode"
        Me.authCode.TabIndex = 4
        Me.authCode.Text = ""
        '
        'refNum
        '
        Me.refNum.Location = New System.Drawing.Point(160, 152)
        Me.refNum.Name = "refNum"
        Me.refNum.TabIndex = 3
        Me.refNum.Text = ""
        '
        'ticketNum
        '
        Me.ticketNum.Location = New System.Drawing.Point(160, 122)
        Me.ticketNum.Name = "ticketNum"
        Me.ticketNum.TabIndex = 2
        Me.ticketNum.Text = ""
        '
        'cardType
        '
        Me.cardType.Enabled = False
        Me.cardType.Location = New System.Drawing.Point(248, 90)
        Me.cardType.Name = "cardType"
        Me.cardType.Size = New System.Drawing.Size(96, 20)
        Me.cardType.TabIndex = 2
        Me.cardType.TabStop = False
        Me.cardType.Text = ""
        '
        'expDate
        '
        Me.expDate.Location = New System.Drawing.Point(160, 90)
        Me.expDate.Name = "expDate"
        Me.expDate.Size = New System.Drawing.Size(32, 20)
        Me.expDate.TabIndex = 1
        Me.expDate.Text = ""
        '
        'cardNum
        '
        Me.cardNum.Location = New System.Drawing.Point(160, 58)
        Me.cardNum.Name = "cardNum"
        Me.cardNum.Size = New System.Drawing.Size(184, 20)
        Me.cardNum.TabIndex = 0
        Me.cardNum.Text = ""
        '
        'label15
        '
        Me.label15.Location = New System.Drawing.Point(48, 408)
        Me.label15.Name = "label15"
        Me.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label15.TabIndex = 48
        Me.label15.Text = "Total"
        '
        'label14
        '
        Me.label14.Location = New System.Drawing.Point(48, 376)
        Me.label14.Name = "label14"
        Me.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label14.TabIndex = 47
        Me.label14.Text = "Tax"
        '
        'label13
        '
        Me.label13.Location = New System.Drawing.Point(48, 344)
        Me.label13.Name = "label13"
        Me.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label13.TabIndex = 46
        Me.label13.Text = "Sub Total"
        '
        'label12
        '
        Me.label12.Location = New System.Drawing.Point(48, 312)
        Me.label12.Name = "label12"
        Me.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label12.TabIndex = 45
        Me.label12.Text = "CV Num"
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(264, 280)
        Me.label11.Name = "label11"
        Me.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label11.Size = New System.Drawing.Size(32, 23)
        Me.label11.TabIndex = 44
        Me.label11.Text = "State"
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(48, 280)
        Me.label10.Name = "label10"
        Me.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label10.TabIndex = 43
        Me.label10.Text = "Zip"
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(48, 248)
        Me.label9.Name = "label9"
        Me.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label9.TabIndex = 42
        Me.label9.Text = "Street"
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(48, 216)
        Me.label8.Name = "label8"
        Me.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label8.TabIndex = 41
        Me.label8.Text = "Name On Card"
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(48, 184)
        Me.label7.Name = "label7"
        Me.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label7.TabIndex = 40
        Me.label7.Text = "Auth Code"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(48, 152)
        Me.label6.Name = "label6"
        Me.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label6.TabIndex = 39
        Me.label6.Text = "Ref Num"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(48, 120)
        Me.label5.Name = "label5"
        Me.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label5.TabIndex = 38
        Me.label5.Text = "Ticket Number"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(200, 90)
        Me.label4.Name = "label4"
        Me.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label4.Size = New System.Drawing.Size(40, 23)
        Me.label4.TabIndex = 37
        Me.label4.Text = "Issuer"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(48, 88)
        Me.label3.Name = "label3"
        Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label3.TabIndex = 36
        Me.label3.Text = "Exp Date"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(48, 56)
        Me.label2.Name = "label2"
        Me.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label2.TabIndex = 35
        Me.label2.Text = "Card Num"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(48, 24)
        Me.label1.Name = "label1"
        Me.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label1.Size = New System.Drawing.Size(104, 23)
        Me.label1.TabIndex = 34
        Me.label1.Text = "Transaction Type"
        '
        'CreditTxForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(440, 509)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Cancel, Me.Clear, Me.OK, Me.txType, Me.totalAmt, Me.TaxAmt, Me.SubTotalAmt, Me.cvNum, Me.state, Me.zip, Me.street, Me.CardHolderName, Me.authCode, Me.refNum, Me.ticketNum, Me.cardType, Me.expDate, Me.cardNum, Me.label15, Me.label14, Me.label13, Me.label12, Me.label11, Me.label10, Me.label9, Me.label8, Me.label7, Me.label6, Me.label5, Me.label4, Me.label3, Me.label2, Me.label1})
        Me.MaximizeBox = False
        Me.Name = "CreditTxForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CreditTxForm"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CreditTxForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.AppStarting()

        'set default transtype to sale
        txType.SelectedIndex = 0

        'set default so you don't have to
        'enter them every time
        cardNum.Text = "5000300020003003"
        expDate.Text = "0605"

        'set sample track data for swiped trans
        'in a real app you would get this from the card reader
        strMagData = "5000300020003003=0812101543213961456"

        'lets use the RichCardValidator Web service to find out the issuer:

        Dim objCard As New Validate.CreditCardValidator

        cardType.Text = objCard.GetCardType(cardNum.Text)
        objCard = Nothing

        SubTotalAmt.Text = "1.00"
        TaxAmt.Text = "0.00"
        totalAmt.Text = "1.00"
        CardHolderName.Text = "John Doe"
        street.Text = "123 any street"
        zip.Text = "98053"

        Me.Cursor = Cursors.Default

    End Sub


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim blnCommercialCard As Boolean
        Dim strResponseMSG As String

        'validate the input

        'RichCardValidator.validate Web Service returns the following:
        '     -1  - its good
        '   1001 - no card number
        '   1002 - no exp date
        '   1003 - invalid card type
        '   1004 - invalid card length
        '   1005 - bad mod 10 check
        '   1006 - bad expiration date

        Dim objCard As New Validate.CreditCardValidator
        Select Case objCard.ValidCard(cardNum.Text, expDate.Text)
            Case Is = -1        'its good
                cardType.Text = objCard.GetCardType(cardNum.Text)

            Case Is = 1001
                ErrorProvider1.SetError(cardNum, "Invalid card number.")
                cardType.Text = ""
                Exit Sub
            Case Is = 1002
                ErrorProvider1.SetError(expDate, "Invalid expiration date.")
                cardType.Text = ""
                Exit Sub
            Case Is = 1003
                ErrorProvider1.SetError(cardNum, "Invalid card type.")
                cardType.Text = ""
                Exit Sub
            Case Is = 1004
                ErrorProvider1.SetError(cardNum, "Invalid card length.")
                cardType.Text = ""
                Exit Sub
            Case Is = 1005
                ErrorProvider1.SetError(cardNum, "Invalid card number.")
                cardType.Text = ""
                Exit Sub
            Case Is = 1006
                ErrorProvider1.SetError(expDate, "Invalid expiration date.")
                cardType.Text = ""
                Exit Sub
        End Select

        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(cardNum, "")
        ErrorProvider1.SetError(expDate, "")


        'set commercial card flag
        blnCommercialCard = objCard.IsCommercialCard(cardNum.Text)

        objCard = Nothing

        'Amount must be entered
        If Len(totalAmt.Text) = 0 Then
            ErrorProvider1.SetError(totalAmt, "Invalid amount.")
            Exit Sub
        End If

        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(totalAmt, "")

        'change the cursor to let them know we are doing somthing
        Me.Cursor = Cursors.AppStarting()
        Me.Enabled = False

        Dim objPay As New Transaction.SmartPayments
        Dim objResponse As New Transaction.Response

        strUserName = MainForm.objAppData.UserID
        strPassword = MainForm.objAppData.Password
        strRegister = MainForm.objAppData.Register

        strCardNum = cardNum.Text
        strExpDate = expDate.Text

        strNameOnCard = CardHolderName.Text
        If Len(totalAmt.Text) > 0 Then
            strAmount = Format(Convert.ToDouble(totalAmt.Text), "########0.00")
        Else
            strAmount = 0
        End If

        InvNum = ticketNum.Text
        strZip = zip.Text
        strStreet = street.Text
        strCVNum = cvNum.Text
        strPNRef = refNum.Text

        'sample extdata fields
        strAuthCode = ""    '"<AuthCode>123456</AuthCode>
        strCustCode = ""    '"<CustCode>123456</CustCode>
        strTipAmt = ""      '<TipAmt>1.00</TipAmt>
        strTaxAmt = ""      '<TaxAmt>0.25</TaxAmt>

        'see if in training mode
        If MainForm.objAppData.TrainingMode = "T" Then
            strExtData = "<TrainingMode>T</TrainingMode>"
        End If

        'set commercial card extdata 
        If blnCommercialCard = True Then
            'if its a commercial card need to set the
            'customer code and tax amount

            strCustCode = InvNum        'we are using the invoice number
            strExtData = strExtData & "<CustCode>" & strCustCode & "</CustCode>"

            strTaxAmt = Format(Convert.ToDouble(TaxAmt.Text), "########0.00")
            strExtData = strExtData & "<TaxAmt>" & strTaxAmt & "</TaxAmt>"
        End If

        'set TransType
        TransType = txType.SelectedItem.ToString()

        'call the credit card web service
        objResponse = objPay.ProcessCreditCard(strUserName, strPassword, TransType, _
                strCardNum, strExpDate, strMagData, strNameOnCard, strAmount, InvNum, _
                strPNRef, strZip, strStreet, strCVNum, strExtData)


        'reset cursor to let then know we are done
        Me.Cursor = Cursors.Default
        Me.Enabled = True

        strResponseMSG = ""
        Select Case objResponse.Result
            Case Is = 0     'Its good
                strResponseMSG = "Good" & vbCrLf
                If Len(objResponse.RespMSG) > 0 Then
                    strResponseMSG = strResponseMSG & "Response: " & objResponse.RespMSG & vbCrLf
                End If
                If Len(objResponse.AuthCode) > 0 Then
                    strResponseMSG = strResponseMSG & "Approval Code: " & objResponse.AuthCode & vbCrLf
                End If

                If Len(objResponse.PNRef) > 0 Then
                    strResponseMSG = strResponseMSG & "Reference Number: " & objResponse.PNRef & vbCrLf
                End If

                If Len(objResponse.GetAVSResult) > 0 Then
                    strResponseMSG = strResponseMSG & "AVS Match: " & objResponse.GetAVSResultTXT & vbCrLf
                End If

                If Len(objResponse.GetCVResult) > 0 Then
                    strResponseMSG = strResponseMSG & "CV Match: " & objResponse.GetCVResultTXT & vbCrLf
                End If

            Case Else
                strResponseMSG = "Bad" & vbCrLf
                strResponseMSG = strResponseMSG & "Error Number: " & objResponse.Result & vbCrLf
                strResponseMSG = strResponseMSG & "Result: " & objResponse.RespMSG & vbCrLf
                strResponseMSG = strResponseMSG & "Status: " & objResponse.Message & vbCrLf

        End Select

        MsgBox(strResponseMSG)

        objPay = Nothing
        objResponse = Nothing

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Close()
    End Sub

    Private Sub Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clear.Click

        txType.SelectedIndex = 0
        cardNum.Text = ""
        cardType.Text = ""
        expDate.Text = ""
        ticketNum.Text = ""
        zip.Text = ""
        street.Text = ""
        cvNum.Text = ""
        refNum.Text = ""
        SubTotalAmt.Text = ""
        TaxAmt.Text = ""
        totalAmt.Text = ""
        CardHolderName.Text = ""
        street.Text = ""
        zip.Text = ""
        state.Text = ""
        strMagData = ""

    End Sub

    Private Sub cardNum_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cardNum.Validating
        Me.Cursor = Cursors.AppStarting()

        'lets use the RichCardValidator Web service to Validate the card and find the issuer:
        Dim objCard As New Validate.CreditCardValidator
        If objCard.ValidCardLength(cardNum.Text) And objCard.ValidMod10(cardNum.Text) Then
            cardType.Text = objCard.GetCardType(cardNum.Text)
        Else
            ErrorProvider1.SetError(cardNum, "Invalid card number.")
            cardType.Text = ""
        End If

        objCard = Nothing
        Me.Cursor = Cursors.Default

    End Sub


End Class

