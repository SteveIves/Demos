Public Class CheckTxForm
    Inherits System.Windows.Forms.Form

    'Dim Procedure level variables
    Dim strUserName As String
    Dim strPassword As String

    Dim TransType As String
    Dim strTransitNum As String
    Dim strAccountNum As String
    Dim strCheckNum As String
    Dim strStateCode As String
    Dim strNameOnCheck As String
    Dim strAmount As String
    Dim InvNum As String
    Dim strPNRef As String
    Dim strMICRData As String

    Dim strZip As String
    Dim strStreet As String
    Dim strExtData As String
    Dim strDL As String
    Dim strSS As String
    Dim strDOB As String
    Dim strCheckType As String



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
    Friend WithEvents label15 As System.Windows.Forms.Label
    Friend WithEvents label14 As System.Windows.Forms.Label
    Friend WithEvents label13 As System.Windows.Forms.Label
    Friend WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents refNum As System.Windows.Forms.TextBox
    Friend WithEvents ticketNum As System.Windows.Forms.TextBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents StateCode As System.Windows.Forms.TextBox
    Friend WithEvents AccountNum As System.Windows.Forms.TextBox
    Friend WithEvents CheckNum As System.Windows.Forms.TextBox
    Friend WithEvents NameonCheck As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TransitNum As System.Windows.Forms.TextBox
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
        Me.label15 = New System.Windows.Forms.Label()
        Me.label14 = New System.Windows.Forms.Label()
        Me.label13 = New System.Windows.Forms.Label()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.refNum = New System.Windows.Forms.TextBox()
        Me.ticketNum = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.StateCode = New System.Windows.Forms.TextBox()
        Me.TransitNum = New System.Windows.Forms.TextBox()
        Me.AccountNum = New System.Windows.Forms.TextBox()
        Me.CheckNum = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
        Me.NameonCheck = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(296, 464)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(72, 24)
        Me.Cancel.TabIndex = 15
        Me.Cancel.Text = "Cancel"
        '
        'Clear
        '
        Me.Clear.Location = New System.Drawing.Point(192, 464)
        Me.Clear.Name = "Clear"
        Me.Clear.Size = New System.Drawing.Size(72, 24)
        Me.Clear.TabIndex = 14
        Me.Clear.Text = "Clear"
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(80, 464)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(72, 24)
        Me.OK.TabIndex = 13
        Me.OK.Text = "OK"
        '
        'txType
        '
        Me.txType.Items.AddRange(New Object() {"Auth", "Sale", "Force", "Void"})
        Me.txType.Location = New System.Drawing.Point(176, 40)
        Me.txType.Name = "txType"
        Me.txType.Size = New System.Drawing.Size(121, 21)
        Me.txType.TabIndex = 0
        Me.txType.TabStop = False
        '
        'totalAmt
        '
        Me.totalAmt.Location = New System.Drawing.Point(176, 424)
        Me.totalAmt.Name = "totalAmt"
        Me.totalAmt.TabIndex = 12
        Me.totalAmt.Text = ""
        '
        'TaxAmt
        '
        Me.TaxAmt.Location = New System.Drawing.Point(176, 392)
        Me.TaxAmt.Name = "TaxAmt"
        Me.TaxAmt.TabIndex = 11
        Me.TaxAmt.Text = "0.00"
        '
        'SubTotalAmt
        '
        Me.SubTotalAmt.Location = New System.Drawing.Point(176, 360)
        Me.SubTotalAmt.Name = "SubTotalAmt"
        Me.SubTotalAmt.TabIndex = 10
        Me.SubTotalAmt.Text = ""
        '
        'state
        '
        Me.state.Location = New System.Drawing.Point(328, 328)
        Me.state.Name = "state"
        Me.state.Size = New System.Drawing.Size(32, 20)
        Me.state.TabIndex = 9
        Me.state.Text = ""
        '
        'zip
        '
        Me.zip.Location = New System.Drawing.Point(176, 328)
        Me.zip.Name = "zip"
        Me.zip.TabIndex = 8
        Me.zip.Text = ""
        '
        'street
        '
        Me.street.Location = New System.Drawing.Point(176, 296)
        Me.street.Name = "street"
        Me.street.Size = New System.Drawing.Size(184, 20)
        Me.street.TabIndex = 7
        Me.street.Text = ""
        '
        'label15
        '
        Me.label15.Location = New System.Drawing.Point(64, 424)
        Me.label15.Name = "label15"
        Me.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label15.TabIndex = 80
        Me.label15.Text = "Total"
        '
        'label14
        '
        Me.label14.Location = New System.Drawing.Point(64, 392)
        Me.label14.Name = "label14"
        Me.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label14.TabIndex = 79
        Me.label14.Text = "Tax"
        '
        'label13
        '
        Me.label13.Location = New System.Drawing.Point(64, 360)
        Me.label13.Name = "label13"
        Me.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label13.TabIndex = 78
        Me.label13.Text = "Sub Total"
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(280, 328)
        Me.label11.Name = "label11"
        Me.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label11.Size = New System.Drawing.Size(32, 23)
        Me.label11.TabIndex = 76
        Me.label11.Text = "State"
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(64, 328)
        Me.label10.Name = "label10"
        Me.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label10.TabIndex = 75
        Me.label10.Text = "Zip"
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(64, 296)
        Me.label9.Name = "label9"
        Me.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label9.TabIndex = 74
        Me.label9.Text = "Street"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(60, 40)
        Me.label1.Name = "label1"
        Me.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label1.Size = New System.Drawing.Size(104, 23)
        Me.label1.TabIndex = 66
        Me.label1.Text = "Transaction Type"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(64, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Transit Number"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(64, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Account Number"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(64, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Check Number"
        '
        'refNum
        '
        Me.refNum.Location = New System.Drawing.Point(176, 200)
        Me.refNum.Name = "refNum"
        Me.refNum.TabIndex = 4
        Me.refNum.Text = ""
        '
        'ticketNum
        '
        Me.ticketNum.Location = New System.Drawing.Point(176, 168)
        Me.ticketNum.Name = "ticketNum"
        Me.ticketNum.TabIndex = 3
        Me.ticketNum.Text = ""
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(64, 200)
        Me.label6.Name = "label6"
        Me.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label6.TabIndex = 87
        Me.label6.Text = "Ref Num"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(64, 168)
        Me.label5.Name = "label5"
        Me.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label5.TabIndex = 86
        Me.label5.Text = "Ticket Number"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(64, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "State Code"
        '
        'StateCode
        '
        Me.StateCode.Location = New System.Drawing.Point(176, 232)
        Me.StateCode.Name = "StateCode"
        Me.StateCode.TabIndex = 5
        Me.StateCode.Text = ""
        '
        'TransitNum
        '
        Me.TransitNum.Location = New System.Drawing.Point(176, 72)
        Me.TransitNum.Name = "TransitNum"
        Me.TransitNum.TabIndex = 0
        Me.TransitNum.Text = ""
        '
        'AccountNum
        '
        Me.AccountNum.Location = New System.Drawing.Point(176, 104)
        Me.AccountNum.Name = "AccountNum"
        Me.AccountNum.TabIndex = 1
        Me.AccountNum.Text = ""
        '
        'CheckNum
        '
        Me.CheckNum.Location = New System.Drawing.Point(176, 136)
        Me.CheckNum.Name = "CheckNum"
        Me.CheckNum.TabIndex = 2
        Me.CheckNum.Text = ""
        '
        'NameonCheck
        '
        Me.NameonCheck.Location = New System.Drawing.Point(176, 264)
        Me.NameonCheck.Name = "NameonCheck"
        Me.NameonCheck.Size = New System.Drawing.Size(184, 20)
        Me.NameonCheck.TabIndex = 6
        Me.NameonCheck.Text = ""
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(56, 264)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 24)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Name on Check"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CheckTxForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(440, 509)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.NameonCheck, Me.CheckNum, Me.AccountNum, Me.TransitNum, Me.StateCode, Me.Label7, Me.refNum, Me.ticketNum, Me.label6, Me.label5, Me.Label4, Me.Label3, Me.Label2, Me.txType, Me.totalAmt, Me.TaxAmt, Me.SubTotalAmt, Me.state, Me.zip, Me.street, Me.label15, Me.label14, Me.label13, Me.label11, Me.label10, Me.label9, Me.label1, Me.Cancel, Me.Clear, Me.OK})
        Me.MinimizeBox = False
        Me.Name = "CheckTxForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CheckTxForm"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim strResponseMSG As String

        'validate the inputs
        'we need a transit number
        If Len(TransitNum.Text) = 0 Then
            ErrorProvider1.SetError(TransitNum, "Invalid Tranist Number.")
            Exit Sub
        End If
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(TransitNum, "")

        'account number
        If Len(AccountNum.Text) = 0 Then
            ErrorProvider1.SetError(AccountNum, "Invalid Account Number.")
            Exit Sub
        End If
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(AccountNum, "")

        'check number
        If Len(CheckNum.Text) = 0 Then
            ErrorProvider1.SetError(CheckNum, "Invalid Check Number.")
            Exit Sub
        End If
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(CheckNum, "")

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

        strTransitNum = TransitNum.Text
        strAccountNum = AccountNum.Text
        strCheckNum = CheckNum.Text

        strNameOnCheck = NameonCheck.Text
        If Len(totalAmt.Text) > 0 Then
            strAmount = Format(Convert.ToDouble(totalAmt.Text), "########0.00")
        Else
            strAmount = 0
        End If

        InvNum = ticketNum.Text
        strZip = zip.Text
        strStreet = street.Text
        strPNRef = refNum.Text

        'sample extdata fields
        
        'see if in training mode
        If MainForm.objAppData.TrainingMode = "T" Then
            strExtData = "<TrainingMode>T</TrainingMode>"
        End If

        'set TransType
        TransType = txType.SelectedItem.ToString()

        'call the credit card web service
        objResponse = objPay.ProcessCheck(strUserName, strPassword, TransType, _
                strCheckNum, strTransitNum, strAccountNum, strAmount, strMICRData, strNameOnCheck, strDL, strSS, _
                strDOB, strStateCode, strCheckType, strExtData)


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

    Private Sub CheckTxForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.AppStarting()

        'set default transtype to sale
        txType.SelectedIndex = 0

        'set default so you don't have to
        'enter them every time
        TransitNum.Text = "999999992"
        AccountNum.Text = "12345678901234"
        CheckNum.Text = "12345"
        StateCode.Text = "WA"

        SubTotalAmt.Text = "1.00"
        TaxAmt.Text = "0.00"
        totalAmt.Text = "1.00"
        NameonCheck.Text = "John Doe"
        street.Text = "123 any street"
        zip.Text = "98053"

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clear.Click

        txType.SelectedIndex = 0
        TransitNum.Text = ""
        AccountNum.Text = ""
        CheckNum.Text = ""
        ticketNum.Text = ""
        StateCode.Text = ""
        zip.Text = ""
        street.Text = ""
        refNum.Text = ""
        SubTotalAmt.Text = ""
        TaxAmt.Text = ""
        totalAmt.Text = ""
        NameonCheck.Text = ""
        street.Text = ""
        zip.Text = ""
        state.Text = ""
        strMICRData = ""

    End Sub
End Class
