
Partial Class OrderBrowser
    Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Not IsPostBack Then
            CType(Master, LoggedInMaster).PageTitle = "Order Browser"
			'Default to orders for the current year
			datFromDate.Value = New Date(Now.Year, 1, 1)
			LoadOrders()
		End If

	End Sub

	Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click

		LoadOrders()

	End Sub

	Private Sub LoadOrders()

		Dim Customer As xfpldemo.Customer = Session("CUSTOMER")
		Dim FromDate As Nullable(Of Date) = datFromDate.Value
		Dim ToDate As Nullable(Of Date) = datToDate.Value
		Dim Orders As New xfpldemo.Order_headerDT()
		Dim SynServer As xfpldemo.utils = Session("SYNSERVER")

		Try
			If Not SynServer.GetOrdersByDate(Customer.Account, FromDate, ToDate, Orders) Then
				Throw New Exception("Failed to retrieve customer orders")
			End If
		Catch ex As Exception
			Utilities.ReportError(ex, "GetOrdersByDate")
		End Try

		With grdOrders
			.DataSource = Orders
			.DataBind()
		End With

	End Sub

End Class
