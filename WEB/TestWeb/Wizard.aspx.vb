
Partial Class Wizard
    Inherits System.Web.UI.Page

    Protected Sub Wizard1_FinishButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles Wizard1.FinishButtonClick

        Message.Text = "All done!"


    End Sub
End Class
