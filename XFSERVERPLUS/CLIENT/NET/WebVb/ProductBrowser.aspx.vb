
Partial Class ProductBrowser
    Inherits System.Web.UI.Page

    Private Products As xfpldemo.ProductDT

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Not IsPostBack Then

            CType(Master, LoggedInMaster).PageTitle = "Product Browser"

            With cboProductGroup
                .DataSource = Session("PRODUCTGROUPS")
                .DataBind()
                .SelectedIndex = 0
            End With

        End If

    End Sub

    Protected Sub grdProducts_InitializeDataSource(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.UltraGridEventArgs) Handles grdProducts.InitializeDataSource

        LoadProducts()
        With grdProducts
            .DataSource = Products
            .DataBind()
        End With

    End Sub

    Private Sub LoadProducts()

        Products = New xfpldemo.ProductDT()
        Dim SynServer As xfpldemo.utils = Session("SYNSERVER")

        Try
            SynServer.GetProductsTable(cboProductGroup.DataValue, Products)
        Catch ex As Exception
            Utilities.ReportError(ex, "GetProductsTable")
        End Try


    End Sub

    Protected Sub cboProductGroup_SelectedRowChanged(ByVal sender As Object, ByVal e As Infragistics.WebUI.WebCombo.SelectedRowChangedEventArgs) Handles cboProductGroup.SelectedRowChanged

        LoadProducts()

    End Sub

    Protected Sub grdProducts_DblClick(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdProducts.DblClick

    End Sub
End Class
