Public Class Form1

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        System.Environment.SetEnvironmentVariable("DTK_MENU_UP", "1")

    End Sub

    Private Sub UltraToolbarsManager_ToolClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles ToolbarManager.ToolClick

        If InStr(e.Tool.Key, ".dbr") Or InStr(e.Tool.Key, ".exe") Then
            Dim NewChild As New ClientForm(e.Tool.SharedProps.CustomizerCaption, e.Tool.Key, Me)
        Else
            Select Case e.Tool.Key

                Case "ArCustomerMaintenance"
                    Dim NewChild As New ArCustomerMaintenance()
                    With NewChild
                        .MdiParent = Me
                        .Show()
                    End With

                Case "MenuOptionExit"
                    Me.Close()

                Case "MenuItemCut"

                Case "MenuItemCopy"

                Case "MenuItemPaste"

                Case "ViewTabs"                     'Window menu tools
                    MdiManager.Enabled = True
                    With ToolbarManager
                        .EventManager.SetEnabled(Infragistics.Win.UltraWinToolbars.ToolbarEventIds.ToolClick, False)
                        CType(.Tools("ViewForms"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = False
                        .EventManager.SetEnabled(Infragistics.Win.UltraWinToolbars.ToolbarEventIds.ToolClick, True)
                    End With

                Case "ViewForms"
                    MdiManager.Enabled = False
                    With ToolbarManager
                        .EventManager.SetEnabled(Infragistics.Win.UltraWinToolbars.ToolbarEventIds.ToolClick, False)
                        CType(ToolbarManager.Tools("ViewTabs"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = False
                        .EventManager.SetEnabled(Infragistics.Win.UltraWinToolbars.ToolbarEventIds.ToolClick, True)
                    End With

                Case "ViewRibbon"
                    ToolbarManager.Ribbon.Visible = True

                Case "ViewMenus"
                    ToolbarManager.Ribbon.Visible = False

                Case Else
                    MsgBox("Item " & e.Tool.Key & " has not been implemented yet!")

            End Select
        End If

        'Look for the current tool in the recently used menu
        Dim Tool As Infragistics.Win.UltraWinToolbars.ButtonTool
        For Each Tool In ToolbarManager.Ribbon.ApplicationMenu.ToolAreaRight.Tools
            'Is it this one?
            If Tool.Key = e.Tool.Key Then
                'Yes, remove it from the recently used menu
                ToolbarManager.Ribbon.ApplicationMenu.ToolAreaRight.Tools.Remove(Tool)
            End If
        Next

        'Add the tool just used to the bottom of the recenlty used list
        ToolbarManager.Ribbon.ApplicationMenu.ToolAreaRight.Tools.AddTool(e.Tool.Key)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
