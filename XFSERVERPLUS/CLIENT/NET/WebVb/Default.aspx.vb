
Partial Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CType(Master, LoggedOutMaster).PageTitle = "xfServerPlus / xfNetLink .NET / ASP.NET Demo"
            If Not IsNothing(Session("SYNSERVER")) Then
                Session.Abandon()
            End If
            TxtUsername.Focus()
        End If

	End Sub

	Protected Sub BtnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLogin.Click

		'Define work variables
		Dim ok As Boolean = True
		Dim ErrorText As String = ""

		'Define data which will be cached
		Dim CurrentUser As New xfpldemo.User
		Dim CurrentCustomer As New xfpldemo.Customer
		Dim ProductGroups As New ArrayList()

        Dim SynServer As New xfpldemo.utils

		'Disable logout button

		'Connect to xfServerPlus
		Try
            SynServer.connect()
		Catch Ex As Exception
			Utilities.ReportError(Ex, "Connect")
		End Try

		'Setup the server-side environment
		Try
            Dim Status As Integer = SynServer.Initialize
			If Status <> 0 Then Throw New Exception("Server initialization failed")
		Catch ex As Exception
			Utilities.ReportError(ex, "Initialize")
		End Try

			'Server is ready, call the login method
			Try
            Dim Status As Integer = SynServer.Login(TxtUsername.Text, TxtPassword.Text, ErrorText, CurrentUser)
				If Status <> 0 Then
					ErrorDisplay.Text = ErrorText
					Exit Sub
				End If
			Catch ex As Exception
				Utilities.ReportError(ex, "Login")
			End Try

			'We're logged in, retrieve the customer record
			Try
				CurrentCustomer.Account = CurrentUser.User_customer
            Dim Status As Integer = SynServer.GetCustomer(CurrentCustomer, ErrorText)
				If Status <> 0 Then Throw New Exception("Failed to retrieve users customer record")
			Catch ex As Exception
				Utilities.ReportError(ex, "GetCustomer")
			End Try

			'Retrieve product groups
			Try
            SynServer.GetProductGroups(ProductGroups)
			Catch ex As Exception
				Utilities.ReportError(ex, "GetProductGroups")
			End Try


			'Cache user, customer and product group data
			Session("USER") = CurrentUser
			Session("CUSTOMER") = CurrentCustomer
			Session("PRODUCTGROUPS") = ProductGroups

			'Cache the connection to the server
			Session("SYNSERVER") = SynServer

			'Successful login
			Session("LOGGEDIN") = True

			If Not IsNothing(Session("TARGETPAGE")) Then
				Response.Redirect(Session("TARGETPAGE"), True)
			Else
				Response.Redirect("ProductBrowser.aspx", True)
			End If


	End Sub

End Class
