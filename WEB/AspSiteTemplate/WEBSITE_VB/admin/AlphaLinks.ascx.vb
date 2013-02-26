Partial Class admin_AlphaLinks
    Inherits System.Web.UI.UserControl

    Dim letters() As String = {"All", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

    Dim selectedLetter As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(ViewState("selectedLetter")) Then
            selectedLetter = "All"
            ViewState("selectedLetter") = "All"
        End If

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        'I moved this out of the Page_Load so that I could disable the selected link.
        'Prior to moving it out of Page_Load, the deselected link lagged one behind, because
        'Page_Load fires prior to the command event handler.

        With __theAlphalink
            .DataSource = letters
            __theAlphalink.DataBind()
        End With

    End Sub

    Public Property Letter() As String

        Get
            Return ViewState("selectedLetter").ToString()
        End Get
        Set(ByVal value As String)
            ViewState("selectedLetter") = value
        End Set

    End Property

    Protected Sub SelectLink(ByVal sender As Object, ByVal e As CommandEventArgs)

        selectedLetter = e.CommandArgument.ToString()
        ViewState("selectedLetter") = e.CommandArgument.ToString()

    End Sub

    Protected Sub DisableSelectedLink(ByVal sender As Object, ByVal e As RepeaterItemEventArgs)

        Dim lb As LinkButton = e.Item.Controls(1)
        If (lb.Text = Letter) Then
            lb.Enabled = False
        End If
    End Sub

End Class
