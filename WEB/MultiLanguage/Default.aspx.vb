Imports System.Threading
Imports System.Globalization

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Overrides Sub InitializeCulture()
        If Request.Form("LstLanguage") IsNot Nothing Then
            Dim selectedLanguage As String = Request.Form("LstLanguage")
            UICulture = selectedLanguage
            Culture = selectedLanguage
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage)
            Thread.CurrentThread.CurrentUICulture = New CultureInfo(selectedLanguage)
        End If
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        If Not IsPostBack Then

            Dim DataArray As New ArrayList
            DataArray.Add(New MyData("Data One", "Data Two", "Data Three"))
            DataArray.Add(New MyData("Data Four", "Data Five", "Data Six"))
            DataArray.Add(New MyData("Data Seven", "Data Eight", "Data Nine"))
            GridView1.DataSource = DataArray
            GridView1.DataBind()
        End If

    End Sub

End Class
