Public Class Form1


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Environment.SetEnvironmentVariable("DTK_MENU_UP", "1")

    End Sub

    Private Sub MnuRepository_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRepository.Click

        Dim NewChild As New ClientForm("Repository", "RPS:rps.dbr", Me)

    End Sub


End Class
