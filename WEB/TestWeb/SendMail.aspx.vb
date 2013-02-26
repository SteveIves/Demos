Imports System.Web.Mail


Namespace TestWebSolution


Partial Class SendMail
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents aserver As System.Web.UI.WebControls.TextBox


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim Message As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage
        Message.To = toaddress.Text
        Message.From = fromaddress.Text
        Message.Subject = subject.Text
        Message.Body = Message.To
        Try
            SmtpMail.SmtpServer = aserver.Text
            SmtpMail.Send(Message)
        Catch ehttp As System.Web.HttpException
            log.Items.Add(ehttp.Message)
            log.Items.Add("Here is the full error message")
            log.Items.Add(ehttp.ToString())
        End Try

    End Sub
End Class

End Namespace
