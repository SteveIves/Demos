Imports System.Web.Configuration

Partial Class admin_AccessRules
    Inherits System.Web.UI.Page


    Private Const VirtualImageRoot As String = "~/"
    Private SelectedFolderName As String = ""

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        With UserRoles
            .DataSource = Roles.GetAllRoles()
            .DataBind()
        End With

        With UserList
            .DataSource = Membership.GetAllUsers()
            DataBind()
        End With

        If (IsPostBack) Then
            SelectedFolderName = ""
        Else
            SelectedFolderName = Request.QueryString("SelectedFolderName")
        End If

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            PopulateTree()
        End If

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        ' The call to DisplayAccessRules, and the subsequent binding of the gridview, MUST occur
        ' inside the Page_PreRender event. I don't fully understand why, but this fixes two more .NET gotchas:
        ' 1) My technique to hide the delete rule button did not work the other way.
        '    Why? Upon page refresh, ALL ROWS HAD BUTTONS because I'd been calling DisplayAccessRules
        '    from the FolderTree_SelectedNodeChanged event.
        ' 2) I first moved this into the Page_Load event, but that caused the weird Event validation error
        '    that occurs when ASP.NET thinks someone is hacking your postback values.
        ' 
        ' This appears to be working now, so I'm leaving well enough alone.
        '
        If Not IsNothing(FolderTree.SelectedNode) Then
            DisplayAccessRules(FolderTree.SelectedValue)
            SecurityInfoSection.Visible = True
        End If

    End Sub

    Private Sub PopulateTree()

        ' Populate the tree based on the subfolders of the specified VirtualImageRoot
        Dim rootFolder As DirectoryInfo = New DirectoryInfo(Server.MapPath(VirtualImageRoot))
        Dim root As TreeNode = AddNodeAndDescendents(rootFolder, Nothing)
        FolderTree.Nodes.Add(root)
        Try
            FolderTree.SelectedNode.ImageUrl = "~/images/target.gif"
        Catch ex As Exception
        End Try

    End Sub

    Private Function AddNodeAndDescendents(ByVal folder As DirectoryInfo, ByVal parentNode As TreeNode) As TreeNode

        ' Add the TreeNode, displaying the folder's name and storing the full path to the folder as the value...

        Dim virtualFolderPath As String
        If IsNothing(parentNode) Then
            virtualFolderPath = VirtualImageRoot
        Else
            virtualFolderPath = parentNode.Value & folder.Name & "/"
        End If

        Dim node As New TreeNode(folder.Name, virtualFolderPath)
        node.Selected = folder.Name.Equals(SelectedFolderName)

        ' Recurse through this folder's subfolders
        Dim SubFolders() As DirectoryInfo = folder.GetDirectories()
        Dim SubFolder As DirectoryInfo
        Dim Child As TreeNode
        For Each SubFolder In SubFolders
            If SubFolder.Name <> "App_Data" Then
                Child = AddNodeAndDescendents(SubFolder, node)
                node.ChildNodes.Add(Child)
            End If
        Next

        Return node ' Return the new TreeNode

    End Function

    Protected Sub FolderTree_SelectedNodeChanged(ByVal sender As Object, ByVal e As EventArgs)

        ' I want to reset the Add Rule form field values whenever the user moves folders.
        ' Note that the FALSE statements below are all necessary. It is not sufficient to set
        ' the desired radio to TRUE, since the ASP.NET framework seems to treat radio buttons
        ' as individual items even if they share the same group name.
        '
        ActionDeny.Checked = True
        ActionAllow.Checked = False
        ApplyRole.Checked = True
        ApplyUser.Checked = False
        ApplyAllUsers.Checked = False
        ApplyAnonUser.Checked = False
        UserRoles.SelectedIndex = 0
        UserList.SelectedIndex = 0

        RuleCreationError.Visible = False

        'Restore previously selected folder's ImageUrl.
        ResetFolderImageUrls(FolderTree.Nodes(0))

        'Set the newly selected folder's ImageUrl.
        FolderTree.SelectedNode.ImageUrl = "~/images/target.gif"

    End Sub

    Private Sub ResetFolderImageUrls(ByVal parentNode As TreeNode)
        ' Dan Clem, 3/21/2007.
        ' I really wanted a strong visual queue indicating which folder was selected.
        ' For some reason, the ImageUrl attribute of the <SelectedNodeStyle> tag does not work here,
        ' so I resorted to this method after a number of other unsuccessful attempts.
        ' Note that without this method, each successively selected folder will retain its target.gif
        ' image on successive postbacks.
        ' 
        ' A better way to do this would be to store the value path of the selected node in ViewState,
        ' then use that value to find the previously selected node.
        ' However, I could not figure out how to use the TreeView.FindNode(valuePath) method.
        ' I even tried using hardcoded string values instead of the viewstate's stored valuePath string,
        ' but nothing ever returned a valid node, whether I tried it in Page_Load or Page_PreRender.
        '

        parentNode.ImageUrl = "~/images/folder.gif"

        'Recurse through this node's child nodes
        Dim Nodes As TreeNodeCollection = parentNode.ChildNodes
        Dim ChildNode As TreeNode
        For Each ChildNode In Nodes
            ResetFolderImageUrls(ChildNode)
        Next

    End Sub

    Private Sub DisplayAccessRules(ByVal virtualFolderPath As String)

        If ((Not virtualFolderPath.StartsWith(VirtualImageRoot)) Or (virtualFolderPath.IndexOf("..") >= 0)) Then
            '
            ' Dan Clem, 3/15/2007: from my brief testing, it appears that this may not be necessary, since ASP.NET seems to prevent this inherently, throwing this error:
            ' Cannot use a leading .. to exit above the top directory.
            ' I'm keeping it anyway, 'cause that's how 4guys did it.
            '
            Throw New ApplicationException("An attempt to access a folder outside of the website directory has been detected and blocked.")
        End If

        Dim config As Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(virtualFolderPath)
        Dim systemWeb As System.Web.Configuration.SystemWebSectionGroup = config.GetSectionGroup("system.web")
        Dim authorizationRules As System.Web.Configuration.AuthorizationRuleCollection = systemWeb.Authorization.Rules

        With RulesGrid
            .DataSource = authorizationRules
            .DataBind()
        End With

    End Sub

    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim rule As AuthorizationRule = e.Row.DataItem
            If (Not rule.ElementInformation.IsPresent) Then
                e.Row.Cells(3).Text = "Inherited from parent"
            End If
        End If
    End Sub

    Protected Function GetAction(ByVal rule As AuthorizationRule) As String
        Return rule.Action.ToString()
    End Function

    Protected Function GetRole(ByVal rule As AuthorizationRule) As String
        Return rule.Roles.ToString()
    End Function

    Protected Function GetUser(ByVal rule As AuthorizationRule) As String
        Return rule.Users.ToString()
    End Function

    Protected Sub DeleteRule(ByVal sender As Object, ByVal e As EventArgs)
        '
        ' Dan Clem, 3/16/2007.
        ' This is working quite well, however there is a defect that I am not planning to fix right now.
        ' If you delete a rule, then attempt to delete another rule from the same folder without
        ' refreshing the page, you'll get a page error. The workaround is to re-click the folder in the
        ' tree to refresh it, then delete the rule.
        ' Don't feel like worrying about this right now.
        ' 
        ' Note: this problem may have been fixed already.
        ' I stopped using the session array method for handling things.
        ' This may have fixed it. I'll test later.
        '
        Dim button As Button = sender
        Dim item As GridViewRow = button.Parent.Parent
        Dim virtualFolderPath As String = FolderTree.SelectedValue
        Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration(virtualFolderPath)
        Dim systemWeb As SystemWebSectionGroup = config.GetSectionGroup("system.web")
        Dim section As AuthorizationSection = systemWeb.Sections("authorization")
        section.Rules.RemoveAt(item.RowIndex)
        config.Save()
    End Sub

    Protected Sub MoveUp(ByVal sender As Object, ByVal e As EventArgs)
        MoveRule(sender, e, "up")
    End Sub

    Protected Sub MoveDown(ByVal sender As Object, ByVal e As EventArgs)
        MoveRule(sender, e, "down")
    End Sub

    Private Sub MoveRule(ByVal sender As Object, ByVal e As EventArgs, ByVal upOrDown As String)
        'Dan Clem, 3/17/2007
        upOrDown = upOrDown.ToLower()
        If (upOrDown = "up") Or (upOrDown = "down") Then
            Dim button As Button = sender
            Dim item As GridViewRow = button.Parent.Parent
            Dim selectedIndex As Integer = item.RowIndex
            If ((selectedIndex > 0 And upOrDown = "up") Or (upOrDown = "down")) Then
                Dim virtualFolderPath As String = FolderTree.SelectedValue
                Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration(virtualFolderPath)
                Dim systemWeb As SystemWebSectionGroup = config.GetSectionGroup("system.web")
                Dim section As AuthorizationSection = systemWeb.Sections("authorization")

                'Pull the local rules out of the authorization section, deleting them from same:
                Dim rulesArray As ArrayList = PullLocalRulesOutOfAuthorizationSection(section)

                Select Case upOrDown
                    Case "up"
                        LoadRulesInNewOrder(section, rulesArray, selectedIndex, upOrDown)
                    Case "down"
                        If (selectedIndex < rulesArray.Count - 1) Then
                            LoadRulesInNewOrder(section, rulesArray, selectedIndex, upOrDown)
                        Else
                            'DOWN button in last row was pressed. Load the rules array back in without resorting.
                            Dim x As Integer
                            For x = 0 To rulesArray.Count - 1
                                section.Rules.Add(rulesArray(x))
                            Next
                        End If
                End Select
                config.Save()
            End If
        End If
    End Sub

    Private Sub LoadRulesInNewOrder(ByVal section As AuthorizationSection, ByVal rulesArray As ArrayList, ByVal selectedIndex As Integer, ByVal upOrDown As String)
        '
        ' Dan Clem, 3/17/2007.
        ' I hope this is simple enough.
        ' Imagine you have five local rules and you click a button to move the middle one.
        ' In that scenario, all three of these methods will add rules.
        ' If, however, there are only two local rules to start with, then only the middle method will add rules.
        ' The first and third methods won't do anything, because their FOR loops will never execute.
        '
        AddFirstGroupOfRules(section, rulesArray, selectedIndex, upOrDown)
        AddTheTwoSwappedRules(section, rulesArray, selectedIndex, upOrDown)
        AddFinalGroupOfRules(section, rulesArray, selectedIndex, upOrDown)
    End Sub

    Private Sub AddFirstGroupOfRules(ByVal section As AuthorizationSection, ByVal rulesArray As ArrayList, ByVal selectedIndex As Integer, ByVal upOrDown As String)
        Dim adj As Integer
        If (upOrDown = "up") Then
            adj = 1
        Else
            adj = 0
        End If
        Dim x As Integer
        For x = 0 To selectedIndex - adj 'This was   for (int x = 0; x < selectedIndex - adj; x++)
            section.Rules.Add(rulesArray(x))
        Next
    End Sub

    Private Sub AddTheTwoSwappedRules(ByVal section As AuthorizationSection, ByVal rulesArray As ArrayList, ByVal selectedIndex As Integer, ByVal upOrDown As String)

        Select Case upOrDown
            Case "up"
                section.Rules.Add(rulesArray(selectedIndex))
                section.Rules.Add(rulesArray(selectedIndex - 1))
            Case "down"
                section.Rules.Add(rulesArray(selectedIndex + 1))
                section.Rules.Add(rulesArray(selectedIndex))
        End Select
    End Sub

    Private Sub AddFinalGroupOfRules(ByVal section As AuthorizationSection, ByVal rulesArray As ArrayList, ByVal selectedIndex As Integer, ByVal upOrDown As String)
        Dim adj As Integer
        If (upOrDown = "up") Then
            adj = 1
        Else
            adj = 2
        End If
        Dim x As Integer
        For x = selectedIndex + adj To rulesArray.Count - 1 'This was    for (int x = selectedIndex + adj; x < rulesArray.Count; x++)
            section.Rules.Add(rulesArray(x))
        Next
    End Sub

    Private Function PullLocalRulesOutOfAuthorizationSection(ByVal section As AuthorizationSection) As ArrayList
        ' Dan Clem, 3/17/2007.
        ' First load the local rules into an ArrayList.
        Dim rulesArray As ArrayList = New ArrayList()
        Dim rule As AuthorizationRule
        For Each rule In section.Rules
            If rule.ElementInformation.IsPresent Then
                rulesArray.Add(rule)
            End If
        Next
        'Next delete the rules from the section.
        For Each rule In rulesArray
            section.Rules.Remove(rule)
        Next
        Return rulesArray
    End Function

    Protected Sub CreateRule(ByVal sender As Object, ByVal e As EventArgs)
        Dim newRule As AuthorizationRule
        If ActionAllow.Checked Then
            newRule = New AuthorizationRule(AuthorizationRuleAction.Allow)
        Else
            newRule = New AuthorizationRule(AuthorizationRuleAction.Deny)
        End If

        If ApplyRole.Checked And UserRoles.SelectedIndex > 0 Then
            newRule.Roles.Add(UserRoles.Text)
            AddRule(newRule)
        ElseIf ApplyUser.Checked And UserList.SelectedIndex > 0 Then
            newRule.Users.Add(UserList.Text)
            AddRule(newRule)
        ElseIf ApplyAllUsers.Checked Then
            newRule.Users.Add("*")
            AddRule(newRule)
        ElseIf ApplyAnonUser.Checked Then
            newRule.Users.Add("?")
            AddRule(newRule)
        End If
    End Sub

    Private Sub AddRule(ByVal newRule As AuthorizationRule)
        Dim virtualFolderPath As String = FolderTree.SelectedValue
        Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration(virtualFolderPath)
        Dim systemWeb As SystemWebSectionGroup = config.GetSectionGroup("system.web")
        Dim section As AuthorizationSection = systemWeb.Sections("authorization")
        section.Rules.Add(newRule)
        Try
            config.Save()
            RuleCreationError.Visible = False
        Catch ex As Exception
            RuleCreationError.Visible = True
            RuleCreationError.Text = "<br />An error occurred and the rule was not added. I saw this happen during testing when I attempted to create a rule that the ASP.NET infrastructure realized was redundant. Specifically, I had the rule <i>DENY ALL USERS</i> in one folder, then attempted to add the same rule in a subfolder, which caused ASP.NET to throw an exception.<br /><br />Here's the error message that was thrown just now:<br /><br /><i>" & ex.Message & "</i>"
        End Try
    End Sub

End Class




