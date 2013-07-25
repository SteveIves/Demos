'*****************************************************************************
'Routines called by the main form
'
'Author Richard C. Morris
'       Synergex
'
'*****************************************************************************
Module FormCode
    Public Sub EnableMainElements()
        'Enable elements
        With oOrderForm
            .LblCustomer.Enabled = True
            .TxtCustomer.Enabled = True
            .BtnSearch.Enabled = True
        End With
    End Sub
    Public Sub DisableMainElements()
        With oOrderForm
            .LblCustomer.Enabled = False
            .TxtCustomer.Enabled = False
            .BtnSearch.Enabled = False
        End With
    End Sub
    Public Sub DisplayCustomer()
        'display the customer details
        With oOrderForm
            .TxtCompany.Text = oCustomer.Company
            .TxtStreet.Text = oCustomer.Street
            .TxtCity.Text = oCustomer.City
            .TxtState.Text = oCustomer.State
            .TxtZipCode.Text = oCustomer.Zip
            .AcceptButton = .BtnCustomerAccept
            .ListCustomerContacts.Items.Clear()
            .ListCustomerContacts.Items.Add("Phone : " & oCustomer.Phone_area & " " & oCustomer.Phone_number)
            .ListCustomerContacts.Items.Add("Fax : " & oCustomer.Fax_area & " " & oCustomer.Fax_number)
        End With

    End Sub
    Public Sub StartAgain()
        'hide the order group of controls
        oOrderForm.GrpOrder.Visible = False
        oOrderForm.GrpCustomer.Visible = False

        'user canceled customer selection!
        ClearCustomer()
        oOrderForm.LblCustomerName.Text = oCustomer.Company
        oOrderForm.TxtCustomer.Text = ""

        'display the other required elements
        EnableMainElements()
        oOrderForm.TxtCustomer.Focus()
        oOrderForm.LblInfo.Text = CONST_INF_connected

        With oOrderForm
            .TxtReference.Clear()
            .TxtgiftMessage.Clear()
            .ChkGiftWrap.CheckState = CheckState.Unchecked
            .GrpOrder.Visible = False
            .BtnOrder.Visible = False
            .BtnCancel.Visible = False
        End With

    End Sub
    Public Sub ClearCustomer()
        'initialise the cusotmer details
        Dim tmpCustomer As New xfpldemo.Customer

        oCustomer = tmpCustomer
        tmpCustomer = Nothing
        DisplayCustomer()
    End Sub
    Public Sub FillProductCombo(ByVal oCombo As ComboBox)
        'get all the products from remote server
        'first establish how many product groups there are
        Try
            Dim ProductGroup As New ArrayList()
            oSynergy.GetProductGroups(ProductGroup)
            With oCombo
                .DataSource = ProductGroup
                .DisplayMember = "Name"
                .ValueMember = "Description"
                .SelectedIndex = 0
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub FillProductList(ByVal sProductGroup As String, ByVal oList As ListView)

        'for the selected product group, locate the avilable products
        'initialise the list

        oList.Items.Clear()

        ' default settings
        oList.View = View.Details
        oList.LabelEdit = False
        oList.AllowColumnReorder = True
        oList.FullRowSelect = True
        oList.GridLines = True
        oList.Sorting = SortOrder.Ascending

        'now load products from the remote server

        Dim Products As New ArrayList()

        Dim sGroup() As String
        sGroup = Split(sProductGroup, " -")
        Try
            oSynergy.GetProducts(sGroup(0), Products)
            If Products.Count > 0 Then
                For Each Product As xfpldemo.Product In Products
                    'Create a list view item 
                    Dim oListItem As New ListViewItem(Product.Sku, 0)
                    oListItem.SubItems.Add(Product.Description)
                    oListItem.SubItems.Add(Product.Selling_price)
                    oListItem.SubItems.Add(Product.Moving_ave_cost_price)
                    oListItem.SubItems.Add(Product.Qty_in_stock)
                    oList.Items.AddRange(New ListViewItem() {oListItem})
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub OrderIt(ByVal sProd As String, ByVal oList As ListView)
        Dim oProduct As New xfpldemo.Product
        Dim iStatus As Integer

        oProduct.Sku = sProd
        'get product details
        Try
            iStatus = oSynergy.GetProduct(oProduct)
        Catch ex As Exception
            MsgBox(ex.Message)
            oProduct = Nothing
            Exit Try
        Finally
            'get order count
            Dim oFrmItem As New FrmItem
            oFrmItem.TxtSKU.Text = oProduct.Sku.ToString
            oFrmItem.TxtDescription.Text = oProduct.Description
            oFrmItem.ShowDialog()
            'add to our order list
            Dim oListItem As New ListViewItem(oProduct.Sku, 0)
            oListItem.SubItems.Add(oProduct.Description)
            oListItem.SubItems.Add(oFrmItem.SpinQty.Text)
            oListItem.SubItems.Add(oProduct.Selling_price)
            Dim dCost As Double
            dCost = oProduct.Selling_price * oFrmItem.SpinQty.Text
            oListItem.SubItems.Add(dCost)
            oList.Items.AddRange(New ListViewItem() {oListItem})
            oFrmItem = Nothing
        End Try
    End Sub

    Public Sub CreateOrder(ByVal oOrderList As ListView)
        'Create the order using xfServerPlus
        Dim iItems, iCount As Integer
        Dim sSKU As String
        Dim dQty As Double

        iItems = oOrderList.Items.Count
        Dim oOrderLines(iItems - 1) As xfpldemo.Order_line
        Dim oOrderHead As New xfpldemo.Order_header
        Dim dTotalValue, dTotalTax As Double
        Dim iOrderNumber As Integer

        'work through all the order item lines
        For iCount = 0 To iItems - 1
            Dim oListItem As New ListViewItem
            'get product and quantity
            sSKU = oOrderList.Items(iCount).SubItems(0).Text
            dQty = oOrderList.Items(iCount).SubItems(2).Text

            Dim oOrderLine As New xfpldemo.Order_line
            With oOrderLine
				.Line_number = iCount + 1
				.Sku = oOrderList.Items(iCount).SubItems(0).Text
				.Description = oOrderList.Items(iCount).SubItems(1).Text
				.Qty_ordered = oOrderList.Items(iCount).SubItems(2).Text
				.Price = oOrderList.Items(iCount).SubItems(3).Text
				.Line_value = oOrderList.Items(iCount).SubItems(4).Text
				.Tax = oOrderList.Items(iCount).SubItems(4).Text * 0.175
			End With
            dTotalValue = dTotalValue + oOrderLine.Line_value
            dTotalTax = dTotalTax + oOrderLine.Tax
            oOrderLines(iCount) = oOrderLine
            oOrderLine = Nothing
            oListItem = Nothing
        Next

        'now create the order
        With oOrderHead
			.Order_date = Date.Today
            .Status = "O"
            .Customer = oOrderForm.TxtCustomer.Text
            .Customer_order_ref = oOrderForm.TxtReference.Text
            .Goods_value = dTotalValue
            .Tax_value = dTotalTax
            .Shipping_value = 10.99
            .Delivery_date = Date.Today
            .Ship_date = Date.Today
            .Gift_wrap = oOrderForm.ChkGiftWrap.CheckState
            .Gift_message = oOrderForm.TxtgiftMessage.Text
        End With

        Try
            iOrderNumber = oSynergy.CreateOrder(oOrderHead, oOrderLines)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If iOrderNumber <> 0 Then
                MsgBox("Order Number : " & iOrderNumber.ToString)
            End If
        End Try

        oOrderHead = Nothing
        StartAgain()

    End Sub
End Module
