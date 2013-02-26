Namespace TestWebSolution

Partial Class Repeater
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Repeater2 As System.Web.UI.WebControls.Repeater


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Sub Page_Load(ByVal Sender As Object, ByVal e As EventArgs)

        If Not IsPostBack Then

            'Get data
            Dim values As New ArrayList
            values.Add(New CustomerP("SYN001", "Synergex", "Bill Mooney"))
            values.Add(New CustomerP("SOM001", "Some Other Company", "Someone Else"))
            values.Add(New CustomerP("DIF001", "A Different company", "Yet Another Person"))
            values.Add(New CustomerP("SYN001", "Synergex", "Bill Mooney"))
            values.Add(New CustomerP("SOM001", "Some Other Company", "Someone Else"))
            values.Add(New CustomerP("DIF001", "A Different company", "Yet Another Person"))
            values.Add(New CustomerP("SYN001", "Synergex", "Bill Mooney"))
            values.Add(New CustomerP("SOM001", "Some Other Company", "Someone Else"))
            values.Add(New CustomerP("DIF001", "A Different company", "Yet Another Person"))
            values.Add(New CustomerP("SYN001", "Synergex", "Bill Mooney"))
            values.Add(New CustomerP("SOM001", "Some Other Company", "Someone Else"))
            values.Add(New CustomerP("DIF001", "A Different company", "Yet Another Person"))
            values.Add(New CustomerP("SYN001", "Synergex", "Bill Mooney"))
            values.Add(New CustomerP("SOM001", "Some Other Company", "Someone Else"))
            values.Add(New CustomerP("DIF001", "A Different company", "Yet Another Person"))
            values.Add(New CustomerP("SYN001", "Synergex", "Bill Mooney"))
            values.Add(New CustomerP("SOM001", "Some Other Company", "Someone Else"))
            values.Add(New CustomerP("DIF001", "A Different company", "Yet Another Person"))

            Repeater1.DataSource = values
            Repeater1.DataBind()

        End If

    End Sub

End Class
End Namespace
