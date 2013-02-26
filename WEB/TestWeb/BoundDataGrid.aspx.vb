Namespace TestWebSolution

Partial Class BoundDataGrid
	Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

	'This call is required by the Web Form Designer.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


	Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
		'CODEGEN: This method call is required by the Web Form Designer
		'Do not modify it using the code editor.
		InitializeComponent()
	End Sub

#End Region

    Private CustomerArray As ArrayList

	Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not IsPostBack Then
            Trace.Write("In Page_Load (Initial)")
            CustomerArray = LoadCustomers()
            Session("CustomerArray") = CustomerArray
            With DataGrid1
                .DataSource = CustomerArray
                .DataBind()
            End With
        Else
            Trace.Write("In Page_Load (Postback)")
            CustomerArray = Session("CustomerArray")
            DataGrid1.DataSource = CustomerArray
        End If

	End Sub

	Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
		With DataGrid1
			.CurrentPageIndex = e.NewPageIndex
			.DataBind()
		End With
	End Sub

	Private Sub DataGrid1_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.EditCommand
		With DataGrid1
			.EditItemIndex = e.Item.ItemIndex
			.DataBind()
		End With
	End Sub

	Private Sub DataGrid1_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.UpdateCommand
		'Get access to the textbox controls used to do the update
		Dim txtCompany As TextBox = CType(e.Item.Cells(1).Controls(0), TextBox)
		Dim txtContact As TextBox = CType(e.Item.Cells(2).Controls(0), TextBox)
		'Update properties in the ArrayList
		With CustomerArray.Item(e.Item.ItemIndex)
			.Company = txtCompany.Text
			.Contact = txtContact.Text
		End With
		With DataGrid1
			.EditItemIndex = -1
			.DataBind()
		End With
	End Sub

	Private Sub DataGrid1_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
		With DataGrid1
			.EditItemIndex = -1
			.DataBind()
		End With
	End Sub

    Private Sub DataGrid1_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.DeleteCommand
        CustomerArray.RemoveAt(e.Item.ItemIndex)
        DataGrid1.DataBind()
    End Sub

    Private Function LoadCustomers() As ArrayList
        'Simulate an array of objects that has come back from a Synergy call
        Dim Count As Integer, Customer As CustomerP, TmpArray As New ArrayList
        For Count = 0 To 15
            Customer = New CustomerP
            With Customer
                .Account = "CUST" & (Count + 1).ToString
                .Company = "Company Name " & (Count + 1).ToString
                .Contact = "Contact Name " & (Count + 1).ToString
            End With
            TmpArray.Add(Customer)
        Next
        Return TmpArray
    End Function

End Class

End Namespace
