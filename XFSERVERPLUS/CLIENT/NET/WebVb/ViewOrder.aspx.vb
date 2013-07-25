
Partial Class ViewOrder
    Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Not IsPostBack Then
            CType(Master, LoggedInMaster).PageTitle = "View an Order"
			LoadOrder()
		End If

	End Sub

	Private Sub LoadOrder()

			Dim SynServer As xfpldemo.utils = Session("SYNSERVER")


			Dim OrderNumber As Integer = Request.QueryString("order")
			Dim OrderHeader As New xfpldemo.Order_header
			Dim OrderItems As New xfpldemo.Order_lineDT()

			If SynServer.GetOrder(OrderNumber, OrderHeader, OrderItems) Then
				'Success
			Else
				'Failed
			End If

	End Sub

End Class
