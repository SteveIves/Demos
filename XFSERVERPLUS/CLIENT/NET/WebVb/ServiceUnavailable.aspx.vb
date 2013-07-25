
Partial Class ServiceUnavailable
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim ErrorPage As String = Session("ERRORPAGE")
            Dim MethodName As String = Session("ERRORMETHOD")
            Dim ex As Exception = Session("EXCEPTION")

            lblPage.Text = ErrorPage
            lblMethod.Text = MethodName
            lblException.Text = ex.Message()

            Session.Abandon()
        End If

    End Sub

    Protected Sub btnContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Response.Redirect("~/Default.aspx")

    End Sub
End Class
