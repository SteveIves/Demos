Namespace TestWebSolution

Partial Class RuntimeTable
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

		Dim Table As New Table
		Dim AddFirstRow As Boolean = True
		Dim AddSecondRow As Boolean = True

		With Table
			.Width = New Unit(500)
			.BorderStyle = BorderStyle.Solid
			.BorderWidth = New Unit(5)
			.GridLines = GridLines.Both
			.Visible = True
		End With

		If AddFirstRow Then
			Dim NewRow As New TableRow
			Dim c As Integer
			For c = 1 To 3
				Dim NewCell As New TableCell
				NewCell.Text = "Row 1 Column " & c
				NewRow.Cells.Add(NewCell)
			Next
			Table.Rows.Add(NewRow)
		End If

		If AddSecondRow Then
			Dim NewRow As New TableRow
			Dim c As Integer
			For c = 1 To 3
				Dim NewCell As New TableCell
				NewCell.Text = "Row 2 Column " & c
				NewRow.Cells.Add(NewCell)
			Next
			Table.Rows.Add(NewRow)
		End If

		MyBase.Controls.Add(Table)

	End Sub

End Class

End Namespace
