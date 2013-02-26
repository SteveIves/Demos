
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub LoginStatus1_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginStatus1.LoggedOut
        Session.Abandon()
    End Sub

End Class

