
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ObjectDataSource1_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Updating
        System.Threading.Thread.Sleep(2000)
    End Sub
End Class