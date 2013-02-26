Namespace TestWebSolution

Partial Class Calendar
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

		If Not IsPostBack Then
			Dim ThisYear As Integer = Date.Now.Year
			Dim Year As Integer
			With yearList
				For Year = ThisYear - 5 To ThisYear + 5
					yearList.Items.Add(Year)
				Next
				.SelectedIndex = 5
			End With
		End If

	End Sub

	Private Sub yearList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles yearList.SelectedIndexChanged

		With Calendar1
			Dim NewDate As New Date(Integer.Parse(yearList.SelectedValue), .SelectedDate.Month, .SelectedDate.Day)
			.SelectedDate = NewDate
			.VisibleDate = .SelectedDate
		End With

		ShowDetails()

	End Sub

	Private Sub btnToday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToday.Click

		With Calendar1
			.SelectedDate = Date.Now
			.VisibleDate = .SelectedDate
		End With

		ShowDetails()

	End Sub

	Private Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged

		ShowDetails()

	End Sub

	Private Sub ShowDetails()

		With Calendar1
			'Ensure the calendar is on the correct month for the new date selection
			.VisibleDate = .SelectedDate

			txtDate.Text = .SelectedDate.ToShortDateString
			txtD8Date.Text = YYYYMMDDFromDate(.SelectedDate)
			txtD6Date.Text = YYMMDDFromDate(.SelectedDate)
		End With

	End Sub

End Class

End Namespace
