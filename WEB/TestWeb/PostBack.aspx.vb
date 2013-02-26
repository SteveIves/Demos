Namespace TestWebSolution

Partial Class PostBack
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
		'Put user code to initialize the page here

		If Not IsPostBack Then
			Log.Items.Add("In Page_Load")
		Else
			Log.Items.Add("In Page_Load (postback)")
		End If

    End Sub

	Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

		Log.Items.Add("In Button1_Click")


	End Sub

	Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

		Log.Items.Add("In TextBox1_TextChanged")
		TextBox2.Text = TextBox1.Text

	End Sub

End Class

End Namespace
