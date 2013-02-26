Public Class admin_OnlineUsers
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        Dim OnlineUsers As New MembershipUserCollection()

        For Each User As MembershipUser In Membership.GetAllUsers()
            If User.IsOnline Then OnlineUsers.Add(User)
        Next User

        With Users
            .DataSource = OnlineUsers
            .DataBind()
        End With

    End Sub
End Class
