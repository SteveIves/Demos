
Partial Class ViewProduct
    Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Not IsPostBack Then
            CType(Master, LoggedInMaster).PageTitle = "View Product Detail"

            Dim SynServer As xfpldemo.utils = Session("SYNSERVER")
            Dim Product As New xfpldemo.Product()

            Product.Sku = Request.QueryString("sku")

            If SynServer.GetProduct(Product) = 0 Then
                'Success
            Else
                'Failed
            End If



		End If

	End Sub
End Class
