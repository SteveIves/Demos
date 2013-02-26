Namespace TestWebSolution

Partial Class RadioButtons
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

        If IsPostBack Then
            If RadioButton1.Checked Then
                Results.Text = RadioButton1.Text
            ElseIf RadioButton2.Checked Then
                Results.Text = RadioButton2.Text
            ElseIf RadioButton3.Checked Then
                Results.Text = RadioButton3.Text
            End If

            If RadioButton4.Checked Then
                Results2.Text = RadioButton4.Text
            ElseIf RadioButton5.Checked Then
                Results2.Text = RadioButton5.Text
            ElseIf RadioButton6.Checked Then
                Results2.Text = RadioButton6.Text
            End If

        End If

    End Sub


End Class

End Namespace
