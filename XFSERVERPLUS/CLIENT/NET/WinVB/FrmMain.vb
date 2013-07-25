Imports xfpldemo

Public Class FrmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ProductGroupList As System.Windows.Forms.ListBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents ProductGrid As System.Windows.Forms.DataGrid
    Friend WithEvents OrderList As System.Windows.Forms.ListBox
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter3 As System.Windows.Forms.Splitter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtOrder As System.Windows.Forms.TextBox
    Friend WithEvents TxtCustRef As System.Windows.Forms.TextBox
    Friend WithEvents OrderGrid As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CboProductGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtGiftMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkGiftWrap As System.Windows.Forms.CheckBox
    Friend WithEvents TxtOrderRef As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtQtyToOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ItemGrid As System.Windows.Forms.DataGridView
    Friend WithEvents SkuDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SellingpriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyinstockDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyallocatedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyintransitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyonorderDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrderItemGrid As System.Windows.Forms.DataGridView
    Friend WithEvents OrderlineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BtnPlaceOrder As System.Windows.Forms.Button
    Friend WithEvents TxtDeliveryDate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtOrderDate As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtShipDate As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtTaxValue As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtGoodsValue As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtShippingValue As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BtnRemoveItem As System.Windows.Forms.Button
    Friend WithEvents SkuDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyorderedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LinevalueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.ProductGrid = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.ProductGroupList = New System.Windows.Forms.ListBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.OrderGrid = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Splitter3 = New System.Windows.Forms.Splitter
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TxtTaxValue = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtGoodsValue = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtShippingValue = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtShipDate = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtOrderDate = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtMessage = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtDeliveryDate = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtCustRef = New System.Windows.Forms.TextBox
        Me.TxtOrder = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.OrderList = New System.Windows.Forms.ListBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.OrderItemGrid = New System.Windows.Forms.DataGridView
        Me.SkuDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyorderedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LinevalueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderlineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.BtnRemoveItem = New System.Windows.Forms.Button
        Me.BtnPlaceOrder = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.TxtQtyToOrder = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.ItemGrid = New System.Windows.Forms.DataGridView
        Me.SkuDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SellingpriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyinstockDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyallocatedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyintransitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyonorderDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.CboProductGroup = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtGiftMessage = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ChkGiftWrap = New System.Windows.Forms.CheckBox
        Me.TxtOrderRef = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.ProductGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.OrderGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.OrderItemGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderlineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.ItemGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Controls.Add(Me.TabPage3)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(869, 534)
        Me.TabControl.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ProductGrid)
        Me.TabPage1.Controls.Add(Me.Splitter1)
        Me.TabPage1.Controls.Add(Me.ProductGroupList)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(861, 508)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Browse Products"
        '
        'ProductGrid
        '
        Me.ProductGrid.CaptionVisible = False
        Me.ProductGrid.DataMember = ""
        Me.ProductGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProductGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.ProductGrid.Location = New System.Drawing.Point(203, 0)
        Me.ProductGrid.Name = "ProductGrid"
        Me.ProductGrid.ReadOnly = True
        Me.ProductGrid.RowHeadersVisible = False
        Me.ProductGrid.Size = New System.Drawing.Size(658, 508)
        Me.ProductGrid.TabIndex = 2
        Me.ProductGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.ProductGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "Product[]"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Sku "
        Me.DataGridTextBoxColumn1.MappingName = "Sku"
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Description "
        Me.DataGridTextBoxColumn2.MappingName = "Description"
        Me.DataGridTextBoxColumn2.Width = 230
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Price "
        Me.DataGridTextBoxColumn3.MappingName = "Selling_price"
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "In Stock "
        Me.DataGridTextBoxColumn4.MappingName = "Qty_in_stock"
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Allocated "
        Me.DataGridTextBoxColumn5.MappingName = "Qty_allocated"
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "On Order "
        Me.DataGridTextBoxColumn6.MappingName = "Qty_on_order"
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(200, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 508)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'ProductGroupList
        '
        Me.ProductGroupList.Dock = System.Windows.Forms.DockStyle.Left
        Me.ProductGroupList.Location = New System.Drawing.Point(0, 0)
        Me.ProductGroupList.Name = "ProductGroupList"
        Me.ProductGroupList.Size = New System.Drawing.Size(200, 498)
        Me.ProductGroupList.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.OrderGrid)
        Me.TabPage2.Controls.Add(Me.Splitter3)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Controls.Add(Me.Splitter2)
        Me.TabPage2.Controls.Add(Me.OrderList)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(861, 508)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Browse Orders"
        '
        'OrderGrid
        '
        Me.OrderGrid.CaptionVisible = False
        Me.OrderGrid.DataMember = ""
        Me.OrderGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OrderGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.OrderGrid.Location = New System.Drawing.Point(203, 155)
        Me.OrderGrid.Name = "OrderGrid"
        Me.OrderGrid.ReadOnly = True
        Me.OrderGrid.Size = New System.Drawing.Size(658, 353)
        Me.OrderGrid.TabIndex = 4
        Me.OrderGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.DataGrid = Me.OrderGrid
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "Order_line[]"
        Me.DataGridTableStyle2.ReadOnly = True
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Sku"
        Me.DataGridTextBoxColumn7.MappingName = "Sku"
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Description"
        Me.DataGridTextBoxColumn8.MappingName = "Description"
        Me.DataGridTextBoxColumn8.Width = 220
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Each"
        Me.DataGridTextBoxColumn9.MappingName = "Price"
        Me.DataGridTextBoxColumn9.Width = 60
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Qty"
        Me.DataGridTextBoxColumn10.MappingName = "Qty_ordered"
        Me.DataGridTextBoxColumn10.Width = 60
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "Goods"
        Me.DataGridTextBoxColumn11.MappingName = "Line_value"
        Me.DataGridTextBoxColumn11.Width = 60
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "Tax"
        Me.DataGridTextBoxColumn12.MappingName = "Tax"
        Me.DataGridTextBoxColumn12.Width = 60
        '
        'Splitter3
        '
        Me.Splitter3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter3.Location = New System.Drawing.Point(203, 152)
        Me.Splitter3.Name = "Splitter3"
        Me.Splitter3.Size = New System.Drawing.Size(658, 3)
        Me.Splitter3.TabIndex = 3
        Me.Splitter3.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.TxtTaxValue)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.TxtGoodsValue)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.TxtShippingValue)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.TxtShipDate)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.TxtOrderDate)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TxtMessage)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.TxtDeliveryDate)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TxtCustRef)
        Me.Panel1.Controls.Add(Me.TxtOrder)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(203, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(658, 152)
        Me.Panel1.TabIndex = 2
        '
        'TxtTaxValue
        '
        Me.TxtTaxValue.Location = New System.Drawing.Point(317, 80)
        Me.TxtTaxValue.Name = "TxtTaxValue"
        Me.TxtTaxValue.ReadOnly = True
        Me.TxtTaxValue.Size = New System.Drawing.Size(57, 20)
        Me.TxtTaxValue.TabIndex = 17
        Me.TxtTaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(224, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 16)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Tax Value"
        '
        'TxtGoodsValue
        '
        Me.TxtGoodsValue.Location = New System.Drawing.Point(317, 56)
        Me.TxtGoodsValue.Name = "TxtGoodsValue"
        Me.TxtGoodsValue.ReadOnly = True
        Me.TxtGoodsValue.Size = New System.Drawing.Size(57, 20)
        Me.TxtGoodsValue.TabIndex = 15
        Me.TxtGoodsValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(224, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 16)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Goods Value"
        '
        'TxtShippingValue
        '
        Me.TxtShippingValue.Location = New System.Drawing.Point(317, 106)
        Me.TxtShippingValue.Name = "TxtShippingValue"
        Me.TxtShippingValue.ReadOnly = True
        Me.TxtShippingValue.Size = New System.Drawing.Size(57, 20)
        Me.TxtShippingValue.TabIndex = 13
        Me.TxtShippingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(224, 110)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 16)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Shipping Value"
        '
        'TxtShipDate
        '
        Me.TxtShipDate.Location = New System.Drawing.Point(101, 80)
        Me.TxtShipDate.Name = "TxtShipDate"
        Me.TxtShipDate.ReadOnly = True
        Me.TxtShipDate.Size = New System.Drawing.Size(100, 20)
        Me.TxtShipDate.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 16)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Ship Date"
        '
        'TxtOrderDate
        '
        Me.TxtOrderDate.Location = New System.Drawing.Point(101, 56)
        Me.TxtOrderDate.Name = "TxtOrderDate"
        Me.TxtOrderDate.ReadOnly = True
        Me.TxtOrderDate.Size = New System.Drawing.Size(100, 20)
        Me.TxtOrderDate.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Order Date"
        '
        'TxtMessage
        '
        Me.TxtMessage.Location = New System.Drawing.Point(279, 8)
        Me.TxtMessage.Name = "TxtMessage"
        Me.TxtMessage.ReadOnly = True
        Me.TxtMessage.Size = New System.Drawing.Size(346, 20)
        Me.TxtMessage.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(223, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Message"
        '
        'TxtDeliveryDate
        '
        Me.TxtDeliveryDate.Location = New System.Drawing.Point(101, 106)
        Me.TxtDeliveryDate.Name = "TxtDeliveryDate"
        Me.TxtDeliveryDate.ReadOnly = True
        Me.TxtDeliveryDate.Size = New System.Drawing.Size(100, 20)
        Me.TxtDeliveryDate.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Delivery Date"
        '
        'TxtCustRef
        '
        Me.TxtCustRef.Location = New System.Drawing.Point(101, 32)
        Me.TxtCustRef.Name = "TxtCustRef"
        Me.TxtCustRef.ReadOnly = True
        Me.TxtCustRef.Size = New System.Drawing.Size(100, 20)
        Me.TxtCustRef.TabIndex = 3
        '
        'TxtOrder
        '
        Me.TxtOrder.Location = New System.Drawing.Point(101, 8)
        Me.TxtOrder.Name = "TxtOrder"
        Me.TxtOrder.ReadOnly = True
        Me.TxtOrder.Size = New System.Drawing.Size(100, 20)
        Me.TxtOrder.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Cust Ref #"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Order #"
        '
        'Splitter2
        '
        Me.Splitter2.Location = New System.Drawing.Point(200, 0)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(3, 508)
        Me.Splitter2.TabIndex = 1
        Me.Splitter2.TabStop = False
        '
        'OrderList
        '
        Me.OrderList.Dock = System.Windows.Forms.DockStyle.Left
        Me.OrderList.Location = New System.Drawing.Point(0, 0)
        Me.OrderList.Name = "OrderList"
        Me.OrderList.Size = New System.Drawing.Size(200, 498)
        Me.OrderList.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel5)
        Me.TabPage3.Controls.Add(Me.Panel4)
        Me.TabPage3.Controls.Add(Me.Panel3)
        Me.TabPage3.Controls.Add(Me.Panel2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(861, 508)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "New Order"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.OrderItemGrid)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 337)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(861, 171)
        Me.Panel5.TabIndex = 11
        '
        'OrderItemGrid
        '
        Me.OrderItemGrid.AllowUserToAddRows = False
        Me.OrderItemGrid.AllowUserToDeleteRows = False
        Me.OrderItemGrid.AllowUserToResizeRows = False
        Me.OrderItemGrid.AutoGenerateColumns = False
        Me.OrderItemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.OrderItemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OrderItemGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SkuDataGridViewTextBoxColumn1, Me.DescriptionDataGridViewTextBoxColumn1, Me.QtyorderedDataGridViewTextBoxColumn, Me.PriceDataGridViewTextBoxColumn, Me.LinevalueDataGridViewTextBoxColumn})
        Me.OrderItemGrid.DataSource = Me.OrderlineBindingSource
        Me.OrderItemGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OrderItemGrid.Location = New System.Drawing.Point(0, 0)
        Me.OrderItemGrid.MultiSelect = False
        Me.OrderItemGrid.Name = "OrderItemGrid"
        Me.OrderItemGrid.ReadOnly = True
        Me.OrderItemGrid.RowHeadersVisible = False
        Me.OrderItemGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.OrderItemGrid.Size = New System.Drawing.Size(861, 171)
        Me.OrderItemGrid.TabIndex = 0
        '
        'SkuDataGridViewTextBoxColumn1
        '
        Me.SkuDataGridViewTextBoxColumn1.DataPropertyName = "Sku"
        Me.SkuDataGridViewTextBoxColumn1.HeaderText = "SKU"
        Me.SkuDataGridViewTextBoxColumn1.Name = "SkuDataGridViewTextBoxColumn1"
        Me.SkuDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DescriptionDataGridViewTextBoxColumn1
        '
        Me.DescriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn1.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn1.Name = "DescriptionDataGridViewTextBoxColumn1"
        Me.DescriptionDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'QtyorderedDataGridViewTextBoxColumn
        '
        Me.QtyorderedDataGridViewTextBoxColumn.DataPropertyName = "Qty_ordered"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.QtyorderedDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QtyorderedDataGridViewTextBoxColumn.HeaderText = "Qty Ordered"
        Me.QtyorderedDataGridViewTextBoxColumn.Name = "QtyorderedDataGridViewTextBoxColumn"
        Me.QtyorderedDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PriceDataGridViewTextBoxColumn
        '
        Me.PriceDataGridViewTextBoxColumn.DataPropertyName = "Price"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PriceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PriceDataGridViewTextBoxColumn.HeaderText = "Price"
        Me.PriceDataGridViewTextBoxColumn.Name = "PriceDataGridViewTextBoxColumn"
        Me.PriceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LinevalueDataGridViewTextBoxColumn
        '
        Me.LinevalueDataGridViewTextBoxColumn.DataPropertyName = "Line_value"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.LinevalueDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.LinevalueDataGridViewTextBoxColumn.HeaderText = "Total"
        Me.LinevalueDataGridViewTextBoxColumn.Name = "LinevalueDataGridViewTextBoxColumn"
        Me.LinevalueDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OrderlineBindingSource
        '
        Me.OrderlineBindingSource.DataSource = GetType(xfpldemo.Order_line)
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.BtnRemoveItem)
        Me.Panel4.Controls.Add(Me.BtnPlaceOrder)
        Me.Panel4.Controls.Add(Me.BtnAdd)
        Me.Panel4.Controls.Add(Me.TxtQtyToOrder)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 291)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(861, 46)
        Me.Panel4.TabIndex = 10
        '
        'BtnRemoveItem
        '
        Me.BtnRemoveItem.Enabled = False
        Me.BtnRemoveItem.Location = New System.Drawing.Point(246, 14)
        Me.BtnRemoveItem.Name = "BtnRemoveItem"
        Me.BtnRemoveItem.Size = New System.Drawing.Size(95, 23)
        Me.BtnRemoveItem.TabIndex = 4
        Me.BtnRemoveItem.Text = "Remove Item"
        Me.BtnRemoveItem.UseVisualStyleBackColor = True
        '
        'BtnPlaceOrder
        '
        Me.BtnPlaceOrder.Enabled = False
        Me.BtnPlaceOrder.Location = New System.Drawing.Point(347, 14)
        Me.BtnPlaceOrder.Name = "BtnPlaceOrder"
        Me.BtnPlaceOrder.Size = New System.Drawing.Size(75, 23)
        Me.BtnPlaceOrder.TabIndex = 3
        Me.BtnPlaceOrder.Text = "Place Order"
        Me.BtnPlaceOrder.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(151, 14)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(88, 23)
        Me.BtnAdd.TabIndex = 2
        Me.BtnAdd.Text = "Add to Order"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'TxtQtyToOrder
        '
        Me.TxtQtyToOrder.Location = New System.Drawing.Point(85, 14)
        Me.TxtQtyToOrder.Name = "TxtQtyToOrder"
        Me.TxtQtyToOrder.Size = New System.Drawing.Size(60, 20)
        Me.TxtQtyToOrder.TabIndex = 1
        Me.TxtQtyToOrder.Text = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Qty to Order"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ItemGrid)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 78)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(861, 213)
        Me.Panel3.TabIndex = 9
        '
        'ItemGrid
        '
        Me.ItemGrid.AllowUserToAddRows = False
        Me.ItemGrid.AllowUserToDeleteRows = False
        Me.ItemGrid.AllowUserToResizeRows = False
        Me.ItemGrid.AutoGenerateColumns = False
        Me.ItemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ItemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ItemGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SkuDataGridViewTextBoxColumn, Me.GroupDataGridViewTextBoxColumn, Me.DescriptionDataGridViewTextBoxColumn, Me.SellingpriceDataGridViewTextBoxColumn, Me.QtyinstockDataGridViewTextBoxColumn, Me.QtyallocatedDataGridViewTextBoxColumn, Me.QtyintransitDataGridViewTextBoxColumn, Me.QtyonorderDataGridViewTextBoxColumn})
        Me.ItemGrid.DataSource = Me.ProductBindingSource
        Me.ItemGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemGrid.Location = New System.Drawing.Point(0, 0)
        Me.ItemGrid.MultiSelect = False
        Me.ItemGrid.Name = "ItemGrid"
        Me.ItemGrid.ReadOnly = True
        Me.ItemGrid.RowHeadersVisible = False
        Me.ItemGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ItemGrid.Size = New System.Drawing.Size(861, 213)
        Me.ItemGrid.TabIndex = 0
        '
        'SkuDataGridViewTextBoxColumn
        '
        Me.SkuDataGridViewTextBoxColumn.DataPropertyName = "Sku"
        Me.SkuDataGridViewTextBoxColumn.HeaderText = "SKU"
        Me.SkuDataGridViewTextBoxColumn.Name = "SkuDataGridViewTextBoxColumn"
        Me.SkuDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GroupDataGridViewTextBoxColumn
        '
        Me.GroupDataGridViewTextBoxColumn.DataPropertyName = "Group"
        Me.GroupDataGridViewTextBoxColumn.HeaderText = "Group"
        Me.GroupDataGridViewTextBoxColumn.Name = "GroupDataGridViewTextBoxColumn"
        Me.GroupDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        Me.DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SellingpriceDataGridViewTextBoxColumn
        '
        Me.SellingpriceDataGridViewTextBoxColumn.DataPropertyName = "Selling_price"
        Me.SellingpriceDataGridViewTextBoxColumn.HeaderText = "Selling Price"
        Me.SellingpriceDataGridViewTextBoxColumn.Name = "SellingpriceDataGridViewTextBoxColumn"
        Me.SellingpriceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QtyinstockDataGridViewTextBoxColumn
        '
        Me.QtyinstockDataGridViewTextBoxColumn.DataPropertyName = "Qty_in_stock"
        Me.QtyinstockDataGridViewTextBoxColumn.HeaderText = "In Stock"
        Me.QtyinstockDataGridViewTextBoxColumn.Name = "QtyinstockDataGridViewTextBoxColumn"
        Me.QtyinstockDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QtyallocatedDataGridViewTextBoxColumn
        '
        Me.QtyallocatedDataGridViewTextBoxColumn.DataPropertyName = "Qty_allocated"
        Me.QtyallocatedDataGridViewTextBoxColumn.HeaderText = "Allocated"
        Me.QtyallocatedDataGridViewTextBoxColumn.Name = "QtyallocatedDataGridViewTextBoxColumn"
        Me.QtyallocatedDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QtyintransitDataGridViewTextBoxColumn
        '
        Me.QtyintransitDataGridViewTextBoxColumn.DataPropertyName = "Qty_in_transit"
        Me.QtyintransitDataGridViewTextBoxColumn.HeaderText = "In Transit"
        Me.QtyintransitDataGridViewTextBoxColumn.Name = "QtyintransitDataGridViewTextBoxColumn"
        Me.QtyintransitDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QtyonorderDataGridViewTextBoxColumn
        '
        Me.QtyonorderDataGridViewTextBoxColumn.DataPropertyName = "Qty_on_order"
        Me.QtyonorderDataGridViewTextBoxColumn.HeaderText = "On Order"
        Me.QtyonorderDataGridViewTextBoxColumn.Name = "QtyonorderDataGridViewTextBoxColumn"
        Me.QtyonorderDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ProductBindingSource
        '
        Me.ProductBindingSource.DataSource = GetType(xfpldemo.Product)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CboProductGroup)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.TxtGiftMessage)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.ChkGiftWrap)
        Me.Panel2.Controls.Add(Me.TxtOrderRef)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(861, 78)
        Me.Panel2.TabIndex = 8
        '
        'CboProductGroup
        '
        Me.CboProductGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboProductGroup.Location = New System.Drawing.Point(95, 40)
        Me.CboProductGroup.Name = "CboProductGroup"
        Me.CboProductGroup.Size = New System.Drawing.Size(144, 21)
        Me.CboProductGroup.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Product Group"
        '
        'TxtGiftMessage
        '
        Me.TxtGiftMessage.Enabled = False
        Me.TxtGiftMessage.Location = New System.Drawing.Point(403, 10)
        Me.TxtGiftMessage.Name = "TxtGiftMessage"
        Me.TxtGiftMessage.Size = New System.Drawing.Size(364, 20)
        Me.TxtGiftMessage.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(311, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Gift Message"
        '
        'ChkGiftWrap
        '
        Me.ChkGiftWrap.Location = New System.Drawing.Point(219, 10)
        Me.ChkGiftWrap.Name = "ChkGiftWrap"
        Me.ChkGiftWrap.Size = New System.Drawing.Size(76, 24)
        Me.ChkGiftWrap.TabIndex = 9
        Me.ChkGiftWrap.Text = "Gift Wrap"
        '
        'TxtOrderRef
        '
        Me.TxtOrderRef.Location = New System.Drawing.Point(95, 10)
        Me.TxtOrderRef.Name = "TxtOrderRef"
        Me.TxtOrderRef.Size = New System.Drawing.Size(100, 20)
        Me.TxtOrderRef.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Your Reference"
        '
        'FrmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(869, 534)
        Me.Controls.Add(Me.TabControl)
        Me.Name = "FrmMain"
        Me.Text = "xfNetLink .NET Sample Client"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.ProductGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.OrderGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.OrderItemGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderlineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.ItemGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Show()

        'Connect to xfServerPlus
        Try
            Synergy = New utils
            Synergy.connect()
            If Synergy.Initialize() <> 0 Then
                MsgBox("Failed to initialize server environment", MsgBoxStyle.Critical, "Error")
                Synergy.disconnect()
            Else
                Connected = True
            End If
        Catch ex As Exception
            MsgBox("Failed to connect to server. " & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            If Not Connected Then
                Synergy = Nothing
                End
            End If
        End Try

        'Process the login dialog
        Dim FrmLogin As New FrmLogin
        Do
            If FrmLogin.ShowDialog(Me) = DialogResult.Cancel Then
                End
            End If
            Me.Focus()
            Try
                User = New User
                Sts = Synergy.Login(FrmLogin.TxtUsername.Text, FrmLogin.TxtPassword.Text, ErrorText, User)
                If Sts = 0 Then
                    Exit Do
                Else
                    MsgBox(ErrorText, MsgBoxStyle.Information, "Login Failed")
                End If
            Catch ex As Exception
                MsgBox("Failed to call login. " & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Loop
        FrmLogin.Dispose()
        FrmLogin = Nothing

        'We're logged in

        'Retrieve customer record from logged in user
        Try
            Customer = New Customer
            Customer.Account = User.User_customer
            Sts = Synergy.GetCustomer(Customer, ErrorText)
            If Sts <> 0 Then
                MsgBox("Failed to retrieve users customer record." & Chr(13) & ErrorText, MsgBoxStyle.Critical, "Error")
                End
            End If
        Catch ex As Exception
            MsgBox("Failed to retrieve users customer record." & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Error")
            End
        End Try

        'Retrieve and cache product groups
        Try
            ProductGroups = New ArrayList
            Synergy.GetProductGroups(ProductGroups)
        Catch ex As Exception
            MsgBox("Failed to retrieve product groups. " & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Error")
            End
        End Try

        'Display product groups in product browser
        With ProductGroupList
            .BeginUpdate()
            .ValueMember = "Name"
            .DisplayMember = "Description"
            .DataSource = ProductGroups
            .EndUpdate()
        End With

        'Display product groups in new order page
        With CboProductGroup
            .BeginUpdate()
            .ValueMember = "Name"
            .DisplayMember = "Description"
            .DataSource = ProductGroups
            .EndUpdate()
        End With

        'Retrieve orders
        Try
            Orders = New ArrayList
            Sts = Synergy.GetOrders(Customer.Account, Orders)
        Catch ex As Exception
            MsgBox("Failed to retrieve orders. " & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Error")
            End
        End Try

        'Display orders
        With OrderList
            .BeginUpdate()
            .ValueMember = "Order"
            .DisplayMember = "Order"
            .DataSource = Orders
            .EndUpdate()
        End With

        'Create our "shopping cart"
        NewOrderItems = New ArrayList()
        OrderlineBindingSource.DataSource = NewOrderItems
        OrderlineBindingSource.RaiseListChangedEvents = True

    End Sub

    Private Sub FrmMain_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        If Connected Then
            Try
                With Synergy
                    .Cleanup()
                    .disconnect()
                End With
            Catch ex As Exception
            Finally
                Synergy = Nothing
            End Try
        End If

    End Sub

    Private Sub OrderList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderList.SelectedIndexChanged

        'Display order header information
        Dim ThisOrder As Order_header = CType(OrderList.SelectedItem, Order_header)
        With ThisOrder
            TxtOrder.Text = .Order
            TxtCustRef.Text = .Customer_order_ref
            TxtOrderDate.Text = .Order_date.ToShortDateString()
            TxtShipDate.Text = .Ship_date.ToShortDateString()
            TxtDeliveryDate.Text = .Delivery_date.ToShortDateString()
            TxtMessage.Text = .Gift_message
            TxtGoodsValue.Text = FormatCurrency(.Goods_value)
            TxtTaxValue.Text = FormatCurrency(.Tax_value)
            TxtShippingValue.Text = FormatCurrency(.Shipping_value)
        End With

        'Retrieve order line items
        Dim OrderItems As New ArrayList
        Try
            Sts = Synergy.GetOrderItems(ThisOrder.Order, OrderItems)
        Catch ex As Exception
            MsgBox("Failed to retrieve items for order. " & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        'Display order line items
        OrderGrid.DataSource = OrderItems.ToArray(GetType(Order_line))

    End Sub

    Private Sub ChkGiftWrap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGiftWrap.CheckedChanged

        With TxtGiftMessage

            .Enabled = ChkGiftWrap.Checked

            If .Enabled Then
                .Focus()
            Else
                .Text = ""
            End If

        End With

    End Sub

    Private Sub ProductGroupList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ProductGroupList.SelectedIndexChanged, CboProductGroup.SelectedIndexChanged

        'Retrieve products for selected product group
        Dim ProductCount As Integer
        Dim Products As New ArrayList

        Dim ProductGroup As String
        If sender Is ProductGroupList Then
            ProductGroup = ProductGroupList.SelectedValue
        Else
            ProductGroup = CboProductGroup.SelectedValue
        End If

        Try
            ProductCount = Synergy.GetProducts(ProductGroup, Products)
        Catch ex As Exception
            MsgBox("Failed to retrieve products for product group. " & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Error")
            End
        End Try

        If sender Is ProductGroupList Then
            ProductGrid.DataSource = Products.ToArray(GetType(Product))
        Else
            ItemGrid.DataSource = Products.ToArray(GetType(Product))
        End If

    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click

        'Make sure that we have a product selected, and something in the qualtity field
        If ((ItemGrid.SelectedRows.Count = 0) Or (TxtQtyToOrder.Text.Length = 0)) Then
            MsgBox("Select an item and enter a quantity")
            Exit Sub
        End If

        'Make sure that the quantity field contains a number.
        Dim LineQty As Integer
        Try
            LineQty = Integer.Parse(TxtQtyToOrder.Text)
        Catch ex As Exception
            MsgBox("Invalid quantity!")
            Exit Sub
        End Try

        'Get a handle on the selected product
        Dim LineProduct As Product = ItemGrid.SelectedRows(0).DataBoundItem

        'Create a new order line item and populate it with data from the selected product,
        'and the entered quantity
        Dim NewItem As New xfpldemo.Order_line()
        With NewItem
            .Sku = LineProduct.Sku
            .Description = LineProduct.Description
            .Price = LineProduct.Selling_price
            .Qty_ordered = LineQty
            .Line_value = LineProduct.Selling_price * LineQty
        End With

        'Add the new line to the "cart"
        NewOrderItems.Add(NewItem)

        'Tell the controls that are bound to the BindingSource to refresh.
        OrderlineBindingSource.ResetBindings(True)

        'Get ready for the next item
        TxtQtyToOrder.Text = "1"

    End Sub

    Private Sub OrderItemGrid_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles OrderItemGrid.CellDoubleClick

        MsgBox(OrderItemGrid.SelectedRows(0).Cells(0).Value)

    End Sub

    Private Sub BtnPlaceOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPlaceOrder.Click

        'Create a new order header record
        Dim NewOrderHeader As New Order_header()
        With NewOrderHeader
            .Order_date = Now
            .Ship_date = Now + New TimeSpan(1, 0, 0)
            .Delivery_date = Now + New TimeSpan(4, 0, 0)
            .Status = "O"
            .Customer = Customer.Account
            .Customer_order_ref = TxtOrderRef.Text
            .Goods_value = 0
            .Tax_value = 0
            .Shipping_value = 0
            If ChkGiftWrap.Checked Then
                .Gift_wrap = 1
            Else
                .Gift_wrap = 0
            End If
            .Gift_message = TxtGiftMessage.Text
        End With

        'Get the order items collection into shape.

        Dim NewOrderItemArray As Order_line()
        NewOrderItemArray = NewOrderItems.ToArray(GetType(Order_line))

        'Create the order

        Dim OrderNumber As Integer
        OrderNumber = Synergy.CreateOrder(NewOrderHeader, NewOrderItemArray)

        If OrderNumber <= 0 Then
            MsgBox("Failed to create order, status =" & OrderNumber)
        Else
            MsgBox("New order number is " & OrderNumber)
            Orders.Add(OrderNumber)
            OrderList.DataSource = Orders
        End If

        'Clean up
        NewOrderItems.Clear()
        OrderlineBindingSource.ResetBindings(False)

        TxtOrderRef.Text = ""
        ChkGiftWrap.Checked = False
        TxtGiftMessage.Text = ""
        CboProductGroup.SelectedIndex = 0
        TxtQtyToOrder.Text = "1"


    End Sub

    Private Sub OrderItemGrid_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles OrderItemGrid.DataBindingComplete

        With OrderItemGrid
            BtnRemoveItem.Enabled = (.RowCount > 0)
            BtnPlaceOrder.Enabled = (.RowCount > 0)
        End With

    End Sub

    Private Sub BtnRemoveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemoveItem.Click

        With OrderItemGrid
            'Do we have a row selected?
            If .SelectedRows.Count > 0 Then
                'Yes, remove it
                .Rows.RemoveAt(.SelectedRows(0).Index)
                'Does that leave us with rows, but none selected?
                If .SelectedRows.Count = 0 And .Rows.Count > 0 Then
                    'Yes, select the last row
                    .Rows(.Rows.Count - 1).Selected = True
                End If
            Else
                MsgBox("Select a row to delete")
            End If
        End With

    End Sub

End Class
