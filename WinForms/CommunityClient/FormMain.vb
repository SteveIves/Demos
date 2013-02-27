Imports System.Windows.Forms
Imports Infragistics.win.UltraWinExplorerBar

Public Class FormMain

    Private Sub FormMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        My.Application.Log.WriteEntry("CommunityClient Started", TraceEventType.Information)

        'Instantiate the web service
        GalleryService = New webserver.GalleryService

        'GalleryService.Url = "http://ivesworld.com/community/photos/galleryservice.asmx"

        'Ping the web server to make sure it is on-line
        StatusBar.Panels(0).Text = "Verifying connection to web service " & GalleryService.Url
        Me.Refresh()
        Try
            GalleryService.Ping()
        Catch ex As Exception
            MsgBox("Can't communicate with web server!")
            Me.Close()
            Exit Sub
        End Try
        StatusBar.Panels(0).Text = ""

        Dim c As Integer
        Dim OK As Boolean = True
        Dim Galleries() As String
        Dim Albums() As webserver.Album
        Dim Album As webserver.Album
        Dim ExplorerBarGroup As UltraExplorerBarGroup
        Dim ExplorerBarItem As UltraExplorerBarItem

        Me.Show()

        If LoginForm.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Me.Close()
            Exit Sub
        End If

        With Me
            .Cursor = Cursors.WaitCursor
            .Refresh()
        End With

        'Configure status bar for gallery processing
        With StatusBar
            .Panels(0).Text = "Retrieving galleries..."
            .Refresh()
        End With

        'Retrieve galleries that the user has post access to
        Galleries = GalleryService.Galleries

        'Create an explorer bar group for each gallery
        For c = 0 To UBound(Galleries)
            ExplorerBarGroup = ExplorerBar.Groups.Add(Galleries(c), Galleries(c))
            ExplorerBarGroup.Expanded = False
        Next

        'Reset status bar
        With StatusBar
            .Panels(0).Text = ""
            .Refresh()
        End With

        'Add albums for each gallery

        If ExplorerBar.Groups.Count > 0 Then

            'Setup status bar for album processing
            With StatusBar
                With .Panels(0)
                    .Text = "Loading albums..."
                End With
                With .Panels(1)
                    With .ProgressBarInfo
                        .Minimum = 0
                        .Maximum = ExplorerBar.Groups.Count
                        .Value = 0
                    End With
                    .Visible = True
                End With
                .Refresh()
            End With

            'Retrieve albums for each gallery
            For Each ExplorerBarGroup In ExplorerBar.Groups

                'Update status bar
                With StatusBar
                    With .Panels(1)
                        .ProgressBarInfo.Value += 1
                    End With
                    .Refresh()
                End With

                Credentials.SectionName = ExplorerBarGroup.Key

                Albums = GalleryService.GetAlbumHeirarchy()

                For Each Album In Albums
                    ExplorerBarItem = ExplorerBarGroup.Items.Add
                    With ExplorerBarItem
                        .Key = Album.ID
                        .Text = Album.Name
                        .ToolTipText = "Album ID " & Album.ID
                        .Tag = Album
                    End With
                Next

            Next

            'Reset status bar
            With StatusBar
                With .Panels(0)
                    .Text = ""
                End With
                With .Panels(1)
                    .Visible = False
                    .ProgressBarInfo.Value = 0
                End With
                .Refresh()
            End With

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FormMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If Not IsNothing(GalleryService) Then
            GalleryService.Dispose()
            GalleryService = Nothing
        End If

        Credentials = Nothing

        My.Application.Log.WriteEntry("CommunityClient Stopped", TraceEventType.Information)

    End Sub

    Private Sub ToolbarManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles ToolbarManager.ToolClick

        Select Case e.Tool.Key
            Case "MnuFileExit"    ' PopupMenuTool
                Me.Close()
            Case "MnuHelpAbout"
                Dim AboutBox As New AboutBox
                AboutBox.ShowDialog(Me)
        End Select

    End Sub

    Private Sub ExplorerBar_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles ExplorerBar.ItemClick

        Dim NewForm As New AlbumForm(e.Item.Group.Text, e.Item.Tag)
        With NewForm
            .MdiParent = Me
            .Show()
        End With

    End Sub
End Class
