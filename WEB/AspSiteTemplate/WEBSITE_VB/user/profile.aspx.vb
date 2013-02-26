
Partial Class user_profile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            With Profile
                txtFirstName.Text = .FirstName
                txtLastName.Text = .LastName
            End With
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        With Profile
            .FirstName = txtFirstName.Text
            .LastName = txtLastName.Text
        End With

        Response.Redirect("~/user/Default.aspx")

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Response.Redirect("~/user/Default.aspx")

    End Sub
End Class
