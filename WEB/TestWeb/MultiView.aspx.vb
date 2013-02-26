
Partial Class MultiView
    Inherits System.Web.UI.Page

    Protected Sub BtnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNext.Click

        If MultiView1.ActiveViewIndex < MultiView1.Views.Count - 1 Then
            MultiView1.ActiveViewIndex += 1
        Else
            MultiView1.ActiveViewIndex = 0
        End If

    End Sub
End Class
