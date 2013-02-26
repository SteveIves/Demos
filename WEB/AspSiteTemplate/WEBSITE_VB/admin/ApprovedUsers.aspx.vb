Partial Class admin_ApprovedUsers
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        Dim allUsers As MembershipUserCollection = Membership.GetAllUsers()
        Dim filteredUsers As MembershipUserCollection = New MembershipUserCollection()
        Dim User As MembershipUser

        For Each User In allUsers
            If User.IsApproved = rbApproved.SelectedValue Then
                filteredUsers.Add(User)
            End If
        Next User

        With Users
            .DataSource = filteredUsers
            .DataBind()
        End With

    End Sub

End Class
