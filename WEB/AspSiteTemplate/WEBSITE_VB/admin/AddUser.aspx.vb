Partial Class admin_AddUser
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        With UserRoles
            .DataSource = Roles.GetAllRoles()
            .DataBind()
        End With

    End Sub

    Protected Sub BtnAddUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddUser.Click

        Try
            AddUser()
            Response.Redirect("Users.aspx")
        Catch ex As Exception
            Message.Text = "Failed to add user. " & ex.Message
        End Try

    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

        'User clicked cancel, bail out
        Response.Redirect("~/admin/Default.aspx")

    End Sub

    Protected Sub AddUser()

        'Add basic user record
        Dim newUser As MembershipUser = Membership.CreateUser(TxtUsername.Text, TxtPassword.Text, TxtEmail.Text)

        'Update the other attributes which are not supported directly via the CreateUser method
        With newUser
            .IsApproved = ChkIsApproved.Checked
            .Comment = TxtComment.Text
        End With
        Membership.UpdateUser(newUser)

        'Add Roles for the new user account
        Dim Role As ListItem
        For Each Role In UserRoles.Items
            If Role.Selected Then
                Roles.AddUserToRole(TxtUsername.Text, Role.Text)
            End If
        Next

    End Sub

End Class