
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("HELLOTEXT") = "Hello world!"

        Dim UtilObj As New UTILS.UtilsClass
        UtilObj.SayHello()

    End Sub
End Class
