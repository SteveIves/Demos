Public Class admin_Users
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        If Alphalinks.Letter = "All" Then
            Users.DataSource = Membership.GetAllUsers()
        Else
            Users.DataSource = Membership.FindUsersByName(Alphalinks.Letter + "%")
        End If
        Users.DataBind()

    End Sub
End Class
