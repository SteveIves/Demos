
Partial Class LoggedInMaster
    Inherits System.Web.UI.MasterPage

    Public Property PageTitle() As String
        Get
            Return PageTitleLabel.Text
        End Get
        Set(ByVal value As String)
            PageTitleLabel.Text = value
        End Set
    End Property

End Class

