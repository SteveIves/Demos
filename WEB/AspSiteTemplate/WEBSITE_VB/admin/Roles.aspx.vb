Public Class admin_Roles
    Inherits System.Web.UI.Page

    Dim createRoleSuccess As Boolean = True

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        'Create a DataTable and define its columns
        Dim RoleList As New DataTable()
        With RoleList
            .Columns.Add("Role Name")
            .Columns.Add("User Count")
        End With

        'Get the list of roles in the system and how many users belong to each role
        For Each roleName As String In Roles.GetAllRoles()
            Dim numberOfUsersInRole As Integer = Roles.GetUsersInRole(roleName).Length
            Dim roleRow() As String = {roleName, numberOfUsersInRole.ToString()}
            RoleList.Rows.Add(roleRow)
        Next roleName

        'Bind the DataTable to the GridView
        With UserRoles
            .DataSource = RoleList
            .DataBind()
        End With

        If createRoleSuccess Then
            NewRole.Text = ""
        End If

    End Sub

    Protected Sub BtnAddRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddRole.Click

        Try
            Roles.CreateRole(NewRole.Text)
            'ConfirmationMessage.Text = "Role " & NewRole.Text & " was added"
            createRoleSuccess = True
        Catch ex As Exception
            ConfirmationMessage.Text = ex.Message
            createRoleSuccess = False
        End Try

    End Sub

    Protected Sub DeleteRole(ByVal sender As Object, ByVal e As CommandEventArgs)

        Try
            Roles.DeleteRole(e.CommandArgument.ToString())
            'ConfirmationMessage.Text = "Role " + e.CommandArgument.ToString() + " was deleted"
        Catch ex As Exception
            ConfirmationMessage.Text = ex.Message
        End Try

    End Sub

End Class
