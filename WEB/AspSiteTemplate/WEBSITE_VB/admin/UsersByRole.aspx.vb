Public Class admin_UsersByRole
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        With UserRoles
            .DataSource = Roles.GetAllRoles()
            .DataBind()
        End With

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        'The logic here is necessitated by the limitations of the built-in object model.
        'The Membership class does not provide a method to get users by role.
        'The Roles class DOES provide a GetUsersInRole method, but it returns an array of UserName strings
        'rather than a proper collection of MembershipUser objects.
        '
        'This is my workaround.
        '
        'Note to self: the two-collection approach is necessitated because you can't remove items from a collection
        'while iterating through it: "Collection was modified; enumeration operation may not execute."

        Dim allUsers As MembershipUserCollection = Membership.GetAllUsers()
        Dim filteredUsers As New MembershipUserCollection()

        If UserRoles.SelectedIndex > 0 Then
            Dim usersInRole() As String = Roles.GetUsersInRole(UserRoles.SelectedValue)
            For Each user As MembershipUser In allUsers
                For Each userInRole As String In usersInRole
                    If userInRole = user.UserName Then
                        filteredUsers.Add(user)
                        Exit For
                    End If
                Next userInRole
            Next user
        Else
            filteredUsers = allUsers
        End If

        With Users
            .DataSource = filteredUsers
            .DataBind()
        End With

    End Sub


End Class
