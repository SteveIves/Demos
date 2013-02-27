Public Class FrmMain

    Dim NewBrowser As FrmBrowser

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click

        NewBrowser = New FrmBrowser("C:\Dev\DOTNET\Windows\AisFIDS\AisFIDS\departures.htm")
        NewBrowser.Show()
        BtnShow.Enabled = False
        BtnHide.Enabled = True

    End Sub

    Private Sub BtnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHide.Click

        NewBrowser.Hide()
        NewBrowser = Nothing
        BtnShow.Enabled = True
        BtnHide.Enabled = False

    End Sub
End Class