Public Class DebitTxForm
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
    Dim strPin As String

    Dim strZip As String
    Dim strStreet As String
    Dim strTipAmt As String
    Dim strTaxAmt As String
    Dim strExtData As String
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider



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
    Friend WithEvents txType As System.Windows.Forms.ComboBox
    Friend WithEvents totalAmt As System.Windows.Forms.TextBox
    Friend WithEvents TaxAmt As System.Windows.Forms.TextBox
    Friend WithEvents SubTotalAmt As System.Windows.Forms.TextBox
    Friend WithEvents state As System.Windows.Forms.TextBox
    Friend WithEvents zip As System.Windows.Forms.TextBox
    Friend WithEvents street As System.Windows.Forms.TextBox
    Friend WithEvents CardHolderName As System.Windows.Forms.TextBox
    Friend WithEvents refNum As System.Windows.Forms.TextBox
    Friend WithEvents ticketNum As System.Windows.Forms.TextBox
    Friend WithEvents cardType As System.Windows.Forms.TextBox
    Friend WithEvents expDate As System.Windows.Forms.TextBox
    Friend WithEvents cardNum As System.Windows.Forms.TextBox
    Friend WithEvents label15 As System.Windows.Forms.Label
    Friend WithEvents label14 As System.Windows.Forms.Label
    Friend WithEvents label13 As System.Windows.Forms.Label
    Friend WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Clear = New System.Windows.Forms.Button()
        Me.OK = New System.Windows.Forms.Button()
        Me.txType = New System.Windows.Forms.ComboBox()
        Me.totalAmt = New System.Windows.Forms.TextBox()
        Me.TaxAmt = New System.Windows.Forms.TextBox()
        Me.SubTotalAmt = New System.Windows.Forms.TextBox()
        Me.state = New System.Windows.Forms.TextBox()
        Me.zip = New System.Windows.Forms.TextBox()
        Me.street = New System.Windows.Forms.TextBox()
        Me.CardHolderName = New System.Windows.Forms.TextBox()
        Me.refNum = New System.Windows.Forms.TextBox()
        Me.ticketNum = New System.Windows.Forms.TextBox()
        Me.cardType = New System.Windows.Forms.TextBox()
        Me.expDate = New System.Windows.Forms.TextBox()
        Me.cardNum = New System.Windows.Forms.TextBox()
        Me.label15 = New System.Windows.Forms.Label()
        Me.label14 = New System.Windows.Forms.Label()
        Me.label13 = New System.Windows.Forms.Label()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
        Me.SuspendLayout()
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(296, 416)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(72, 24)
        Me.Cancel.TabIndex = 14
        Me.Cancel.Text = "Cancel"
        '
        'Clear
        '
        Me.Clear.Location = New System.Drawing.Point(200, 416)
        Me.Clear.Name = "Clear"
        Me.Clear.Size = New System.Drawing.Size(72, 24)
        Me.Clear.TabIndex = 13
        Me.Clear.Text = "Clear"
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(104, 416)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(74, 24)
        Me.OK.TabIndex = 12
        Me.OK.Text = "OK"
        '
        'txType
        '
        Me.txType.Items.AddRange(New Object() {"Sale", "Return"})
        Me.txType.Location = New System.Drawing.Point(184, 32)
        Me.txType.Name = "txType"
        Me.txType.Size = New System.Drawing.Size(121, 21)
        Me.txType.TabIndex = 53
        Me.txType.TabStop = False
        '
        'totalAmt
        '
        Me.totalAmt.Location = New System.Drawing.Point(184, 352)
        Me.totalAmt.Name = "totalAmt"
        Me.totalAmt.TabIndex = 11
        Me.totalAmt.Text = ""
        '
        'TaxAmt
        '
        Me.TaxAmt.Location = New System.Drawing.Point(184, 320)
        Me.TaxAmt.Name = "TaxAmt"
        Me.TaxAmt.TabIndex = 10
        Me.TaxAmt.Text = "0.00"
        '
        'SubTotalAmt
        '
        Me.SubTotalAmt.Location = New System.Drawing.Point(184, 288)
        Me.SubTotalAmt.Name = "SubTotalAmt"
        Me.SubTotalAmt.TabIndex = 9
        Me.SubTotalAmt.Text = ""
        '
        'state
        '
        Me.state.Location = New System.Drawing.Point(336, 256)
        Me.state.Name = "state"
        Me.state.Size = New System.Drawing.Size(34, 20)
        Me.state.TabIndex = 8
        Me.state.Text = ""
        '
        'zip
        '
        Me.zip.Location = New System.Drawing.Point(184, 256)
        Me.zip.Name = "zip"
        Me.zip.TabIndex = 7
        Me.zip.Text = ""
        '
        'street
        '
        Me.street.Location = New System.Drawing.Point(184, 224)
        Me.street.Name = "street"
        Me.street.Size = New System.Drawing.Size(184, 20)
        Me.street.TabIndex = 6
        Me.street.Text = ""
        '
        'CardHolderName
        '
        Me.CardHolderName.Location = New System.Drawing.Point(184, 192)
        Me.CardHolderName.Name = "CardHolderName"
        Me.CardHolderName.Size = New System.Drawing.Size(184, 20)
        Me.CardHolderName.TabIndex = 5
        Me.CardHolderName.Text = ""
        '
        'refNum
        '
        Me.refNum.Location = New System.Drawing.Point(184, 160)
        Me.refNum.Name = "refNum"
        Me.refNum.TabIndex = 4
        Me.refNum.Text = ""
        '
        'ticketNum
        '
        Me.ticketNum.Location = New System.Drawing.Point(184, 128)
        Me.ticketNum.Name = "ticketNum"
        Me.ticketNum.TabIndex = 3
        Me.ticketNum.Text = ""
        '
        'cardType
        '
        Me.cardType.Enabled = False
        Me.cardType.Location = New System.Drawing.Point(272, 96)
        Me.cardType.Name = "cardType"
        Me.cardType.Size = New System.Drawing.Size(96, 20)
        Me.cardType.TabIndex = 2
        Me.cardType.TabStop = False
        Me.cardType.Text = ""
        '
        'expDate
        '
        Me.expDate.Location = New System.Drawing.Point(184, 96)
        Me.expDate.Name = "expDate"
        Me.expDate.Size = New System.Drawing.Size(32, 20)
        Me.expDate.TabIndex = 1
        Me.expDate.Text = ""
        '
        'cardNum
        '
        Me.cardNum.Location = New System.Drawing.Point(184, 64)
        Me.cardNum.Name = "cardNum"
        Me.cardNum.Size = New System.Drawing.Size(184, 20)
        Me.cardNum.TabIndex = 0
        Me.cardNum.Text = ""
        '
        'label15
        '
        Me.label15.Location = New System.Drawing.Point(72, 352)
        Me.label15.Name = "label15"
        Me.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label15.TabIndex = 80
        Me.label15.Text = "Total"
        '
        'label14
        '
        Me.label14.Location = New System.Drawing.Point(72, 320)
        Me.label14.Name = "label14"
        Me.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label14.TabIndex = 79
        Me.label14.Text = "Tax"
        '
        'label13
        '
        Me.label13.Location = New System.Drawing.Point(72, 288)
        Me.label13.Name = "label13"
        Me.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label13.TabIndex = 78
        Me.label13.Text = "Sub Total"
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(296, 256)
        Me.label11.Name = "label11"
        Me.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label11.Size = New System.Drawing.Size(32, 23)
        Me.label11.TabIndex = 76
        Me.label11.Text = "State"
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(72, 256)
        Me.label10.Name = "label10"
        Me.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label10.TabIndex = 75
        Me.label10.Text = "Zip"
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(72, 224)
        Me.label9.Name = "label9"
        Me.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label9.TabIndex = 74
        Me.label9.Text = "Street"
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(72, 192)
        Me.label8.Name = "label8"
        Me.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label8.TabIndex = 73
        Me.label8.Text = "Name On Card"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(72, 160)
        Me.label6.Name = "label6"
        Me.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label6.TabIndex = 71
        Me.label6.Text = "Ref Num"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(72, 128)
        Me.label5.Name = "label5"
        Me.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label5.TabIndex = 70
        Me.label5.Text = "Ticket Number"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(224, 96)
        Me.label4.Name = "label4"
        Me.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label4.Size = New System.Drawing.Size(40, 23)
        Me.label4.TabIndex = 69
        Me.label4.Text = "Issuer"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(72, 96)
        Me.label3.Name = "label3"
        Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label3.TabIndex = 68
        Me.label3.Text = "Exp Date"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(72, 64)
        Me.label2.Name = "label2"
        Me.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label2.TabIndex = 67
        Me.label2.Text = "Card Num"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(72, 32)
        Me.label1.Name = "label1"
        Me.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label1.Size = New System.Drawing.Size(104, 23)
        Me.label1.TabIndex = 66
        Me.label1.Text = "Transaction Type"
        '
        'DebitTxForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(440, 461)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txType, Me.totalAmt, Me.TaxAmt, Me.SubTotalAmt, Me.state, Me.zip, Me.street, Me.CardHolderName, Me.refNum, Me.ticketNum, Me.cardType, Me.expDate, Me.cardNum, Me.label15, Me.label14, Me.label13, Me.label11, Me.label10, Me.label9, Me.label8, Me.label6, Me.label5, Me.label4, Me.label3, Me.label2, Me.label1, Me.Cancel, Me.Clear, Me.OK})
        Me.MinimizeBox = False
        Me.Name = "DebitTxForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DebitTxForm"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Close()
    End Sub

    Private Sub DebitTxForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.AppStarting()

        'set default transtype to sale
        txType.SelectedIndex = 0

        'We know its a debit card
        cardType.Text = "DBT"

        'set default so you don't have to
        'enter them every time
        cardNum.Text = "5000300020003003"
        expDate.Text = "0605"

        'set sample track data for swiped trans
        'in a real app you would get this from the card reader
        'this is track II data
        strMagData = "5000300020003003=0812101543213961456"

        'In a real app you will get this from the pin-pad
        strPin = "1234567890123456"

        SubTotalAmt.Text = "1.00"
        TaxAmt.Text = "0.00"
        totalAmt.Text = "1.00"
        CardHolderName.Text = "John Doe"
        street.Text = "123 any street"
        zip.Text = "98053"

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clear.Click

        txType.SelectedIndex = 0
        cardNum.Text = ""
        cardType.Text = ""
        expDate.Text = ""
        ticketNum.Text = ""
        zip.Text = ""
        street.Text = ""
        refNum.Text = ""
        SubTotalAmt.Text = ""
        TaxAmt.Text = ""
        totalAmt.Text = ""
        CardHolderName.Text = ""
        street.Text = ""
        zip.Text = ""
        state.Text = ""
        strMagData = ""

        'We know its a debit card
        cardType.Text = "DBT"


    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim strResponseMSG As String

        'validate the input

        'RichCardValidator Web Service checks the following:
        'mod 10 check
        'bad expiration date

        Dim objCard As New Validate.CreditCardValidator
        If Not objCard.ValidMod10(cardNum.Text) Then
            ErrorProvider1.SetError(cardNum, "Invalid card number.")
            Exit Sub
        End If

        If Not objCard.ValidExpDate(expDate.Text) Then
            ErrorProvider1.SetError(expDate, "Invalid expiration date.")
            Exit Sub
        End If

        objCard = Nothing

        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(cardNum, "")
        ErrorProvider1.SetError(expDate, "")

        'Amount must be entered
        If Len(totalAmt.Text) = 0 Then
            ErrorProvider1.SetError(totalAmt, "Invalid amount.")
            Exit Sub
        End If

        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(totalAmt, "")

        'one last check
        'all debit cards must be swiped and have a pin number
        'we have these hard coded in this example but in the real world
        'they are inputs so we need to check for them
        If Len(strMagData) < 20 Or InStr(strMagData, "=") = 0 Then
            MsgBox("Card must be swiped and Track II data required", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If Len(strPin) = 0 Then
            MsgBox("Cardholder must enter pin number", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

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

        'see if in training mode
        If MainForm.objAppData.TrainingMode = "T" Then
            strExtData = "<TrainingMode>T</TrainingMode>"
        End If

        'set TransType
        TransType = txType.SelectedItem.ToString()

        'call the credit card web service
        objResponse = objPay.ProcessDebitCard(strUserName, strPassword, TransType, _
                strCardNum, strExpDate, strMagData, strNameOnCard, strAmount, InvNum, _
                "", strPin, strRegister, "", "", strExtData)


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
End Class
