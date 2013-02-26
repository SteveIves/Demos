Public Class admin_LockedUsers
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        Dim LockedUsers As New MembershipUserCollection()

        For Each User As MembershipUser In Membership.GetAllUsers()
            If User.IsLockedOut Then LockedUsers.Add(User)
        Next User

        With Users
            .DataSource = LockedUsers
            .DataBind()
        End With

    End Sub
End Class
