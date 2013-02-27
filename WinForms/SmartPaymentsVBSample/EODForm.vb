Public Class EODForm
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
    Friend WithEvents ButInquiry As System.Windows.Forms.Button
    Friend WithEvents ButSettleCredit As System.Windows.Forms.Button
    Friend WithEvents ButSettleDebitandEBT As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.ButInquiry = New System.Windows.Forms.Button()
        Me.ButSettleCredit = New System.Windows.Forms.Button()
        Me.ButSettleDebitandEBT = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(112, 176)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(72, 24)
        Me.Cancel.TabIndex = 3
        Me.Cancel.Text = "Close"
        '
        'ButInquiry
        '
        Me.ButInquiry.Location = New System.Drawing.Point(40, 24)
        Me.ButInquiry.Name = "ButInquiry"
        Me.ButInquiry.Size = New System.Drawing.Size(112, 23)
        Me.ButInquiry.TabIndex = 0
        Me.ButInquiry.Text = "Inquiry"
        '
        'ButSettleCredit
        '
        Me.ButSettleCredit.Location = New System.Drawing.Point(40, 72)
        Me.ButSettleCredit.Name = "ButSettleCredit"
        Me.ButSettleCredit.Size = New System.Drawing.Size(112, 23)
        Me.ButSettleCredit.TabIndex = 1
        Me.ButSettleCredit.Text = "Settle Credit"
        '
        'ButSettleDebitandEBT
        '
        Me.ButSettleDebitandEBT.Location = New System.Drawing.Point(40, 120)
        Me.ButSettleDebitandEBT.Name = "ButSettleDebitandEBT"
        Me.ButSettleDebitandEBT.Size = New System.Drawing.Size(112, 23)
        Me.ButSettleDebitandEBT.TabIndex = 2
        Me.ButSettleDebitandEBT.Text = "Settle Debit && EBT"
        '
        'EODForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 221)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ButSettleDebitandEBT, Me.ButSettleCredit, Me.ButInquiry, Me.Cancel})
        Me.MaximizeBox = False
        Me.Name = "EODForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EODForm"
        Me.ResumeLayout(False)

    End Sub

#End Region

    
    Private Sub ButInquiry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButInquiry.Click
        Dim strTransType As String
        Dim strUserName As String
        Dim strPassword As String

        strUserName = MainForm.objAppData.UserID
        strPassword = MainForm.objAppData.Password

        Dim objPay As New Transaction.SmartPayments
        Dim objResponse As New Transaction.Response

        'set TransType
        strTransType = "BatchInquiry"

        objResponse = objPay.GetInfo(strUserName, strPassword, strTransType, "")
        MsgBox(objResponse.Result & vbCrLf & objResponse.RespMSG & vbCrLf & objResponse.ExtData)

    End Sub

    Private Sub ButSettleCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSettleCredit.Click
        Dim strTransType As String
        Dim strUserName As String
        Dim strPassword As String

        strUserName = MainForm.objAppData.UserID
        strPassword = MainForm.objAppData.Password

        'Dim objRichPay As New com.richsolutions.www1.RichPayments()
        'Dim objResponse As com.richsolutions.www1.Response

        Dim objPay As New Transaction.SmartPayments
        Dim objResponse As New Transaction.Response


        'set TransType
        strTransType = "CaptureAll"

        objResponse = objPay.ProcessCreditCard(strUserName, strPassword, strTransType, _
                "", "", "", "", "", "", _
                "", "", "", "", "")

        MsgBox(objResponse.Result & vbCrLf & objResponse.RespMSG & vbCrLf & objResponse.Message & vbCrLf & objResponse.AuthCode & vbCrLf & objResponse.PNRef)

    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButSettleDebitandEBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSettleDebitandEBT.Click
        Dim strTransType As String
        Dim strUserName As String
        Dim strPassword As String

        strUserName = MainForm.objAppData.UserID
        strPassword = MainForm.objAppData.Password

        
        Dim objPay As New Transaction.SmartPayments
        Dim objResponse As New Transaction.Response

        'set TransType
        strTransType = "CaptureAll"

        objResponse = objPay.ProcessDebitCard(strUserName, strPassword, strTransType, _
                "", "", "", "", "", "", "", "", "", "", "", "")

        MsgBox(objResponse.Result & vbCrLf & objResponse.RespMSG & vbCrLf & objResponse.Message & vbCrLf & objResponse.AuthCode & vbCrLf & objResponse.PNRef)

    End Sub

    Private Sub EODForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Close()
    End Sub

End Class
