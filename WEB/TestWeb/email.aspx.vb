Imports System.Net
Imports System.net.mail

Partial Class email
    Inherits System.Web.UI.Page

    Protected Sub BtnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSend.Click

        Dim NewMessage As MailMessage = New MailMessage(TxtFrom.Text, TxtTo.Text, TxtSubject.Text, TxtBody.Text)

        Dim value As ICredentialsByHost
        value = CredentialCache.DefaultCredentials

        Dim MailCLient As New SmtpClient
        MailCLient.Credentials = CredentialCache.DefaultCredentials


        Try
            MailCLient.Send(NewMessage)
        Catch ex As Exception
            ErrorDisplay.Text = ex.Message & ex.ToString
        End Try

    End Sub
End Class
