Namespace TestWebSolution

Partial Class BoundControls
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

	Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		'StringArray()
		ObjectArray()

	End Sub

	Private Sub ObjectArray()

		Dim Count As Integer

		'Create an array of objects
        Dim CustomerArray(5) As CustomerP
		For Count = 0 To UBound(CustomerArray)
            CustomerArray(Count) = New CustomerP
			With CustomerArray(Count)
				.Account = "CUST" & (Count + 1).ToString
				.Company = "Company Name " & (Count + 1).ToString
				.Contact = "Contact Name " & (Count + 1).ToString
			End With
		Next

		'Bind the array to the dropdown list
		With DropDownList1
			.DataSource = CustomerArray
			.DataValueField = "Account"
			.DataTextField = "Company"
			.DataBind()
		End With

	End Sub

	Private Sub StringArray()

            'Simulate an array of objects that has come back from a Synergy call
		Dim DataArray(2) As String
		DataArray(0) = "Dog"
		DataArray(1) = "Cat"
		DataArray(2) = "Rabbit"

		'Bind the ArrayList to the dropdown list
		With DropDownList1
			.DataSource = DataArray
			.DataBind()
		End With

	End Sub

End Class

End Namespace
