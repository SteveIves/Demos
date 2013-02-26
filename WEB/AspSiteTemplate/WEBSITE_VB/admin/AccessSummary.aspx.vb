imports System.Web.Configuration

Partial Class admin_AccessSummary
    Inherits System.Web.UI.Page

    Private Const VirtualImageRoot As String = "~/"
    Private selectedRole, selectedUser As String

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        With UserRoles
            .DataSource = Roles.GetAllRoles()
            .DataBind()
        End With

        With UserList
            .DataSource = Membership.GetAllUsers()
            .DataBind()
        End With

        FolderTree.Nodes.Clear()

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        selectedRole = UserRoles.SelectedValue
        selectedUser = UserList.SelectedValue

    End Sub

    Private Sub PopulateTree(ByVal byUserOrRole As String)

        'Populate the tree based on the subfolders of the specified VirtualImageRoot
        Dim rootFolder As DirectoryInfo = New DirectoryInfo(Server.MapPath(VirtualImageRoot))
        Dim root As TreeNode = AddNodeAndDescendents(byUserOrRole, rootFolder, Nothing)
        FolderTree.Nodes.Add(root)

    End Sub

    Private Function AddNodeAndDescendents(ByVal byUserOrRole As String, ByVal folder As DirectoryInfo, ByVal parentNode As TreeNode) As TreeNode

        'Add the TreeNode, displaying the folder's name and storing the full path to the folder as the value...
        Dim virtualFolderPath As String
        If IsNothing(parentNode) Then
            virtualFolderPath = VirtualImageRoot
        Else
            virtualFolderPath = parentNode.Value & folder.Name & "/"
        End If

        'Instantiate the objects that we'll use to check folder security on each tree node.
        Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration(virtualFolderPath)
        Dim systemWeb As SystemWebSectionGroup = config.GetSectionGroup("system.web")
        Dim section As AuthorizationSection = systemWeb.Sections("authorization")

        Dim action As String

        Select Case byUserOrRole
            Case "ByRole"
                action = GetTheRuleForThisRole(section, virtualFolderPath)
            Case "ByUser"
                action = GetTheRuleForThisUser(section, virtualFolderPath)
            Case Else
                action = ""
        End Select

        'This is where I want to adjust the folder name.
        Dim node As New TreeNode(folder.Name & " (" & action & ")", virtualFolderPath)
        With node
            If action.Substring(0, 5) = "ALLOW" Then
                .ImageUrl = "~/images/greenlight.gif"
            Else
                .ImageUrl = "~/images/redlight.gif"
            End If
            .NavigateUrl = "AccessRules.aspx?selectedFolderName=" & folder.Name
        End With

        'Recurse through this folder's subfolders
        Dim subFolders() As DirectoryInfo = folder.GetDirectories()
        Dim subFolder As DirectoryInfo

        For Each subFolder In subFolders
            'You could use this filter out certain folders.
            If Not subFolder.Name.Equals("App_Data") Then
                Dim child As TreeNode = AddNodeAndDescendents(byUserOrRole, subFolder, node)
                node.ChildNodes.Add(child)
            End If
        Next

        Return node 'Return the new TreeNode

    End Function

    Private Function GetTheRuleForThisRole(ByVal section As AuthorizationSection, ByVal folder As String) As String

        Dim rule As AuthorizationRule

        For Each rule In section.Rules

            Dim user As String
            For Each user In rule.Users
                If user.Equals("*") Then
                    Return rule.Action.ToString().ToUpper() & ": All Users"
                End If
            Next

            Dim role As String
            For Each role In rule.Roles
                If role.Equals(selectedRole) Then
                    Return rule.Action.ToString().ToUpper() & ": Role=" & role
                End If
            Next

        Next

        Return "Allow"

    End Function

    Private Function GetTheRuleForThisUser(ByVal section As AuthorizationSection, ByVal folder As String) As String

        Dim rule As AuthorizationRule
        For Each rule In section.Rules
            Dim user As String
            For Each user In rule.Users
                If user.Equals("*") Then
                    Return rule.Action.ToString().ToUpper() & ": All Users"
                ElseIf user.Equals(selectedUser) Then
                    Return rule.Action.ToString().ToUpper() & ": User=" & user
                End If
            Next

            'Don't forget that users might belong to some roles!
            Dim role As String
            For Each role In rule.Roles
                If Roles.IsUserInRole(selectedUser, role) Then
                    Return rule.Action.ToString().ToUpper() & ": Role=" & role
                End If
            Next
        Next

        Return "ALLOW"

    End Function

    Protected Sub DisplayRoleSummary(ByVal sender As Object, ByVal e As EventArgs)
        FolderTree.Nodes.Clear()
        UserList.SelectedIndex = 0
        If UserRoles.SelectedIndex > 0 Then
            PopulateTree("ByRole")
            FolderTree.ExpandAll()
        End If
    End Sub

    Protected Sub DisplayUserSummary(ByVal sender As Object, ByVal e As EventArgs)

        FolderTree.Nodes.Clear()
        UserRoles.SelectedIndex = 0
        If UserList.SelectedIndex > 0 Then
            PopulateTree("ByUser")
            FolderTree.ExpandAll()
        End If
    End Sub

    Private Sub DisplaySecuritySummary(ByVal sender As Object, ByVal e As TreeNodeEventArgs)
        e.Node.ShowCheckBox = True
    End Sub

    Protected Sub FolderTree_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FolderTree.SelectedNodeChanged

    End Sub
End Class