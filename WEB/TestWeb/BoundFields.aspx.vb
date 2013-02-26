Namespace TestWebSolution

Partial Class BoundFields
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

    Public C As CustomerP

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		If Not IsPostBack Then
			GetCustomer("SYN001")
			Me.DataBind()
		End If

	End Sub

	Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

		UpdateCustomer()
		'Back to list

	End Sub

	Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

		ReleaseCustomer()
		'Back to list

	End Sub

	Private Sub GetCustomer(ByVal Account As String)

		'Simulate getting a record from the database
        C = New CustomerP
		With C
			.Account = Account
			.Company = "Initial Company Name"
			.Contact = "Initial Contact Name"
		End With

	End Sub

	Private Sub UpdateCustomer()

        C = New CustomerP
		With C
			.Account = txtAccount.Text
			.Company = txtCompany.Text
			.Contact = txtContact.Text
		End With

		'Save data to database

	End Sub

	Private Sub ReleaseCustomer()

		'Release database record

	End Sub

End Class

End Namespace
