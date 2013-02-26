Partial Class admin_EditUser
    Inherits System.Web.UI.Page

    Dim Username As String
    Dim ThisUser As MembershipUser

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Username = Request.QueryString("username")

        If IsNothing(Username) Or Username = "" Then
            Response.Redirect("Users.aspx", True)
        End If

        ThisUser = Membership.GetUser(Username)
        Message.Text = ""

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        'Load the User Roles into checkboxes.
        With cbUserRoles
            .DataSource = Roles.GetAllRoles()
            .DataBind()
        End With

        'Disable checkboxes if were not in edit mode
        If UserInfo.CurrentMode <> DetailsViewMode.Edit Then
            For Each CheckBox As ListItem In cbUserRoles.Items
                CheckBox.Enabled = False
            Next CheckBox
        End If

        'Check the checkboxes corresponding to this users roles
        For Each Role As String In Roles.GetRolesForUser(Username)
            cbUserRoles.Items.FindByValue(Role).Selected = True
        Next Role

        'Enable the unlock button of the account is locked
        BtnUnlock.Enabled = ThisUser.IsLockedOut

    End Sub

    Protected Sub UserInfo_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewUpdateEventArgs) Handles UserInfo.ItemUpdating

        'Need to handle the update manually because MembershipUser does not have a parameterless constructor  

        With ThisUser
            .Email = CStr(e.NewValues(0))
            .Comment = CStr(e.NewValues(1))
            .IsApproved = CStr(e.NewValues(2))
        End With

        Try
            'Update user info
            Membership.UpdateUser(ThisUser)

            'Update user roles
            UpdateUserRoles()

            Message.Text = "Update Successful"

            e.Cancel = True
            UserInfo.ChangeMode(DetailsViewMode.ReadOnly)

        Catch ex As Exception
            Message.Text = "Update Failed: " + ex.Message
            e.Cancel = True
            UserInfo.ChangeMode(DetailsViewMode.ReadOnly)
        End Try

    End Sub

    Private Sub UpdateUserRoles()

        For Each Checkbox As ListItem In cbUserRoles.Items

            If Checkbox.Selected Then
                'Make sure the user is in this role
                If Not Roles.IsUserInRole(Username, Checkbox.Text) Then
                    Roles.AddUserToRole(Username, Checkbox.Text)
                End If
            Else
                'Make sure the user is NOT in this role
                If Roles.IsUserInRole(Username, Checkbox.Text) Then
                    Roles.RemoveUserFromRole(Username, Checkbox.Text)
                End If
            End If

        Next Checkbox

    End Sub

    Protected Sub DeleteUser(ByVal Sender As Object, ByVal e As EventArgs) Handles BtnDelete.Click

        Membership.DeleteUser(Username, True)
        Response.Redirect("Users.aspx")

    End Sub

    Protected Sub UnlockUser(ByVal sender As Object, ByVal e As EventArgs) Handles BtnUnlock.Click

        'Unlock the user.
        ThisUser.UnlockUser()

        'DataBind the GridView to reflect same.
        UserInfo.DataBind()

    End Sub


End Class
