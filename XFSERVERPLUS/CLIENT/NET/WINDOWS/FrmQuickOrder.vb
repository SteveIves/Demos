Public Class FrmQuickOrder
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ' default settings
        With ListOrderItems
            .View = View.Details
            .LabelEdit = False
            .AllowColumnReorder = True
            .FullRowSelect = True
            .GridLines = True
            .Sorting = SortOrder.None
        End With
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
    Friend WithEvents LblCustomer As System.Windows.Forms.Label
    Friend WithEvents TxtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents GrpMain As System.Windows.Forms.GroupBox
    Friend WithEvents GrpCustomer As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCustomerAccept As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblInfo As System.Windows.Forms.Label
    Friend WithEvents BtnCustomerCancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCompany As System.Windows.Forms.TextBox
    Friend WithEvents TxtStreet As System.Windows.Forms.TextBox
    Friend WithEvents TxtCity As System.Windows.Forms.TextBox
    Friend WithEvents TxtState As System.Windows.Forms.TextBox
    Friend WithEvents TxtZipCode As System.Windows.Forms.TextBox
    Friend WithEvents ListCustomerContacts As System.Windows.Forms.ListBox
    Friend WithEvents LblCustomerName As System.Windows.Forms.Label
    Friend WithEvents GrpOrder As System.Windows.Forms.GroupBox
    Friend WithEvents LblProdGroup As System.Windows.Forms.Label
    Friend WithEvents CmboProdGroup As System.Windows.Forms.ComboBox
    Friend WithEvents GrpAvailableProducts As System.Windows.Forms.GroupBox
    Friend WithEvents GrpCurrentItems As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOrder As System.Windows.Forms.Button
    Friend WithEvents ListAvailableProducts As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListOrderItems As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtReference As System.Windows.Forms.TextBox
    Friend WithEvents ChkGiftWrap As System.Windows.Forms.CheckBox
    Friend WithEvents TxtgiftMessage As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmQuickOrder))
        Me.GrpMain = New System.Windows.Forms.GroupBox
        Me.LblCustomerName = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnOrder = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.LblInfo = New System.Windows.Forms.Label
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.TxtCustomer = New System.Windows.Forms.TextBox
        Me.LblCustomer = New System.Windows.Forms.Label
        Me.GrpCustomer = New System.Windows.Forms.GroupBox
        Me.TxtgiftMessage = New System.Windows.Forms.TextBox
        Me.ChkGiftWrap = New System.Windows.Forms.CheckBox
        Me.TxtReference = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtZipCode = New System.Windows.Forms.TextBox
        Me.TxtState = New System.Windows.Forms.TextBox
        Me.TxtCity = New System.Windows.Forms.TextBox
        Me.TxtStreet = New System.Windows.Forms.TextBox
        Me.TxtCompany = New System.Windows.Forms.TextBox
        Me.ListCustomerContacts = New System.Windows.Forms.ListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtnCustomerCancel = New System.Windows.Forms.Button
        Me.BtnCustomerAccept = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GrpOrder = New System.Windows.Forms.GroupBox
        Me.GrpCurrentItems = New System.Windows.Forms.GroupBox
        Me.ListOrderItems = New System.Windows.Forms.ListView
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.GrpAvailableProducts = New System.Windows.Forms.GroupBox
        Me.ListAvailableProducts = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.CmboProdGroup = New System.Windows.Forms.ComboBox
        Me.LblProdGroup = New System.Windows.Forms.Label
        Me.GrpMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GrpCustomer.SuspendLayout()
        Me.GrpOrder.SuspendLayout()
        Me.GrpCurrentItems.SuspendLayout()
        Me.GrpAvailableProducts.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.LblCustomerName)
        Me.GrpMain.Controls.Add(Me.GroupBox1)
        Me.GrpMain.Controls.Add(Me.BtnSearch)
        Me.GrpMain.Controls.Add(Me.TxtCustomer)
        Me.GrpMain.Controls.Add(Me.LblCustomer)
        Me.GrpMain.Controls.Add(Me.GrpCustomer)
        Me.GrpMain.Controls.Add(Me.GrpOrder)
        Me.GrpMain.Location = New System.Drawing.Point(8, 8)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(784, 432)
        Me.GrpMain.TabIndex = 0
        Me.GrpMain.TabStop = False
        '
        'LblCustomerName
        '
        Me.LblCustomerName.Location = New System.Drawing.Point(320, 24)
        Me.LblCustomerName.Name = "LblCustomerName"
        Me.LblCustomerName.Size = New System.Drawing.Size(392, 24)
        Me.LblCustomerName.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnOrder)
        Me.GroupBox1.Controls.Add(Me.BtnCancel)
        Me.GroupBox1.Controls.Add(Me.LblInfo)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 376)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(752, 48)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'BtnOrder
        '
        Me.BtnOrder.Location = New System.Drawing.Point(576, 16)
        Me.BtnOrder.Name = "BtnOrder"
        Me.BtnOrder.Size = New System.Drawing.Size(72, 24)
        Me.BtnOrder.TabIndex = 7
        Me.BtnOrder.Text = "Order"
        Me.BtnOrder.Visible = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(664, 16)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 24)
        Me.BtnCancel.TabIndex = 6
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.Visible = False
        '
        'LblInfo
        '
        Me.LblInfo.Location = New System.Drawing.Point(8, 16)
        Me.LblInfo.Name = "LblInfo"
        Me.LblInfo.Size = New System.Drawing.Size(456, 16)
        Me.LblInfo.TabIndex = 5
        '
        'BtnSearch
        '
        Me.BtnSearch.Image = CType(resources.GetObject("BtnSearch.Image"), System.Drawing.Image)
        Me.BtnSearch.Location = New System.Drawing.Point(232, 16)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(72, 32)
        Me.BtnSearch.TabIndex = 2
        '
        'TxtCustomer
        '
        Me.TxtCustomer.Location = New System.Drawing.Point(64, 16)
        Me.TxtCustomer.Name = "TxtCustomer"
        Me.TxtCustomer.Size = New System.Drawing.Size(160, 20)
        Me.TxtCustomer.TabIndex = 1
        '
        'LblCustomer
        '
        Me.LblCustomer.Location = New System.Drawing.Point(8, 19)
        Me.LblCustomer.Name = "LblCustomer"
        Me.LblCustomer.Size = New System.Drawing.Size(56, 24)
        Me.LblCustomer.TabIndex = 0
        Me.LblCustomer.Text = "Customer"
        '
        'GrpCustomer
        '
        Me.GrpCustomer.Controls.Add(Me.TxtgiftMessage)
        Me.GrpCustomer.Controls.Add(Me.ChkGiftWrap)
        Me.GrpCustomer.Controls.Add(Me.TxtReference)
        Me.GrpCustomer.Controls.Add(Me.Label2)
        Me.GrpCustomer.Controls.Add(Me.Label1)
        Me.GrpCustomer.Controls.Add(Me.TxtZipCode)
        Me.GrpCustomer.Controls.Add(Me.TxtState)
        Me.GrpCustomer.Controls.Add(Me.TxtCity)
        Me.GrpCustomer.Controls.Add(Me.TxtStreet)
        Me.GrpCustomer.Controls.Add(Me.TxtCompany)
        Me.GrpCustomer.Controls.Add(Me.ListCustomerContacts)
        Me.GrpCustomer.Controls.Add(Me.Label4)
        Me.GrpCustomer.Controls.Add(Me.BtnCustomerCancel)
        Me.GrpCustomer.Controls.Add(Me.BtnCustomerAccept)
        Me.GrpCustomer.Controls.Add(Me.Label5)
        Me.GrpCustomer.Controls.Add(Me.Label6)
        Me.GrpCustomer.Controls.Add(Me.Label7)
        Me.GrpCustomer.Controls.Add(Me.Label8)
        Me.GrpCustomer.Location = New System.Drawing.Point(16, 58)
        Me.GrpCustomer.Name = "GrpCustomer"
        Me.GrpCustomer.Size = New System.Drawing.Size(752, 296)
        Me.GrpCustomer.TabIndex = 3
        Me.GrpCustomer.TabStop = False
        Me.GrpCustomer.Visible = False
        '
        'TxtgiftMessage
        '
        Me.TxtgiftMessage.Enabled = False
        Me.TxtgiftMessage.Location = New System.Drawing.Point(464, 192)
        Me.TxtgiftMessage.MaxLength = 60
        Me.TxtgiftMessage.Multiline = True
        Me.TxtgiftMessage.Name = "TxtgiftMessage"
        Me.TxtgiftMessage.Size = New System.Drawing.Size(272, 40)
        Me.TxtgiftMessage.TabIndex = 18
        '
        'ChkGiftWrap
        '
        Me.ChkGiftWrap.Location = New System.Drawing.Point(368, 192)
        Me.ChkGiftWrap.Name = "ChkGiftWrap"
        Me.ChkGiftWrap.Size = New System.Drawing.Size(88, 24)
        Me.ChkGiftWrap.TabIndex = 17
        Me.ChkGiftWrap.Text = "Gift Wrap?"
        '
        'TxtReference
        '
        Me.TxtReference.Location = New System.Drawing.Point(440, 152)
        Me.TxtReference.Name = "TxtReference"
        Me.TxtReference.Size = New System.Drawing.Size(96, 20)
        Me.TxtReference.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(360, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Reference"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(344, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Contact Details"
        '
        'TxtZipCode
        '
        Me.TxtZipCode.Location = New System.Drawing.Point(240, 128)
        Me.TxtZipCode.Name = "TxtZipCode"
        Me.TxtZipCode.Size = New System.Drawing.Size(64, 20)
        Me.TxtZipCode.TabIndex = 13
        '
        'TxtState
        '
        Me.TxtState.Location = New System.Drawing.Point(120, 128)
        Me.TxtState.Name = "TxtState"
        Me.TxtState.Size = New System.Drawing.Size(32, 20)
        Me.TxtState.TabIndex = 12
        '
        'TxtCity
        '
        Me.TxtCity.Location = New System.Drawing.Point(120, 96)
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(184, 20)
        Me.TxtCity.TabIndex = 11
        '
        'TxtStreet
        '
        Me.TxtStreet.Location = New System.Drawing.Point(120, 64)
        Me.TxtStreet.Name = "TxtStreet"
        Me.TxtStreet.Size = New System.Drawing.Size(184, 20)
        Me.TxtStreet.TabIndex = 10
        '
        'TxtCompany
        '
        Me.TxtCompany.Location = New System.Drawing.Point(120, 32)
        Me.TxtCompany.Name = "TxtCompany"
        Me.TxtCompany.Size = New System.Drawing.Size(184, 20)
        Me.TxtCompany.TabIndex = 9
        '
        'ListCustomerContacts
        '
        Me.ListCustomerContacts.ColumnWidth = 150
        Me.ListCustomerContacts.Location = New System.Drawing.Point(360, 56)
        Me.ListCustomerContacts.Name = "ListCustomerContacts"
        Me.ListCustomerContacts.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.ListCustomerContacts.Size = New System.Drawing.Size(300, 82)
        Me.ListCustomerContacts.Sorted = True
        Me.ListCustomerContacts.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(176, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Zip Code"
        '
        'BtnCustomerCancel
        '
        Me.BtnCustomerCancel.Location = New System.Drawing.Point(664, 256)
        Me.BtnCustomerCancel.Name = "BtnCustomerCancel"
        Me.BtnCustomerCancel.Size = New System.Drawing.Size(72, 24)
        Me.BtnCustomerCancel.TabIndex = 3
        Me.BtnCustomerCancel.Text = "Cancel"
        '
        'BtnCustomerAccept
        '
        Me.BtnCustomerAccept.Location = New System.Drawing.Point(576, 256)
        Me.BtnCustomerAccept.Name = "BtnCustomerAccept"
        Me.BtnCustomerAccept.Size = New System.Drawing.Size(72, 24)
        Me.BtnCustomerAccept.TabIndex = 2
        Me.BtnCustomerAccept.Text = "Accept"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(56, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Street"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(56, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 23)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "State"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(56, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 23)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "City"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(56, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Name"
        '
        'GrpOrder
        '
        Me.GrpOrder.Controls.Add(Me.GrpCurrentItems)
        Me.GrpOrder.Controls.Add(Me.GrpAvailableProducts)
        Me.GrpOrder.Controls.Add(Me.CmboProdGroup)
        Me.GrpOrder.Controls.Add(Me.LblProdGroup)
        Me.GrpOrder.Location = New System.Drawing.Point(16, 56)
        Me.GrpOrder.Name = "GrpOrder"
        Me.GrpOrder.Size = New System.Drawing.Size(752, 304)
        Me.GrpOrder.TabIndex = 6
        Me.GrpOrder.TabStop = False
        Me.GrpOrder.Visible = False
        '
        'GrpCurrentItems
        '
        Me.GrpCurrentItems.Controls.Add(Me.ListOrderItems)
        Me.GrpCurrentItems.Location = New System.Drawing.Point(16, 176)
        Me.GrpCurrentItems.Name = "GrpCurrentItems"
        Me.GrpCurrentItems.Size = New System.Drawing.Size(720, 104)
        Me.GrpCurrentItems.TabIndex = 3
        Me.GrpCurrentItems.TabStop = False
        Me.GrpCurrentItems.Text = "Current Items"
        '
        'ListOrderItems
        '
        Me.ListOrderItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.ListOrderItems.Location = New System.Drawing.Point(8, 16)
        Me.ListOrderItems.Name = "ListOrderItems"
        Me.ListOrderItems.Size = New System.Drawing.Size(704, 80)
        Me.ListOrderItems.TabIndex = 0
        Me.ListOrderItems.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "SKU"
        Me.ColumnHeader7.Width = 80
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Description"
        Me.ColumnHeader8.Width = 320
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Qty Ordered"
        Me.ColumnHeader9.Width = 100
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Price"
        Me.ColumnHeader10.Width = 100
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Total Line Value"
        Me.ColumnHeader11.Width = 100
        '
        'GrpAvailableProducts
        '
        Me.GrpAvailableProducts.Controls.Add(Me.ListAvailableProducts)
        Me.GrpAvailableProducts.Location = New System.Drawing.Point(16, 48)
        Me.GrpAvailableProducts.Name = "GrpAvailableProducts"
        Me.GrpAvailableProducts.Size = New System.Drawing.Size(720, 112)
        Me.GrpAvailableProducts.TabIndex = 2
        Me.GrpAvailableProducts.TabStop = False
        Me.GrpAvailableProducts.Text = "Available Products"
        '
        'ListAvailableProducts
        '
        Me.ListAvailableProducts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader6})
        Me.ListAvailableProducts.Location = New System.Drawing.Point(8, 24)
        Me.ListAvailableProducts.Name = "ListAvailableProducts"
        Me.ListAvailableProducts.Size = New System.Drawing.Size(704, 80)
        Me.ListAvailableProducts.TabIndex = 0
        Me.ListAvailableProducts.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "SKU"
        Me.ColumnHeader1.Width = 80
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Description"
        Me.ColumnHeader2.Width = 350
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Selling Price"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Cost Price"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Quantity In Stock"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader6.Width = 80
        '
        'CmboProdGroup
        '
        Me.CmboProdGroup.Location = New System.Drawing.Point(112, 16)
        Me.CmboProdGroup.Name = "CmboProdGroup"
        Me.CmboProdGroup.Size = New System.Drawing.Size(312, 21)
        Me.CmboProdGroup.TabIndex = 1
        '
        'LblProdGroup
        '
        Me.LblProdGroup.Location = New System.Drawing.Point(24, 16)
        Me.LblProdGroup.Name = "LblProdGroup"
        Me.LblProdGroup.Size = New System.Drawing.Size(80, 16)
        Me.LblProdGroup.TabIndex = 0
        Me.LblProdGroup.Text = "Product Group"
        '
        'FrmQuickOrder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(800, 446)
        Me.Controls.Add(Me.GrpMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmQuickOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quick Order Entry"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GrpCustomer.ResumeLayout(False)
        Me.GrpCustomer.PerformLayout()
        Me.GrpOrder.ResumeLayout(False)
        Me.GrpCurrentItems.ResumeLayout(False)
        Me.GrpAvailableProducts.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Dim iStatus As Integer
        Dim sInfo As String
        Dim sErrMsg As String = ""

        sInfo = LblInfo.Text

        'do we need to connect to Synergy
        If bConnected = False Then
            LblInfo.Text = CONST_INF_connecting
            Me.Refresh()    'force the display
            If ConnectSynergy() = False Then
                LblInfo.Text = sInfo
                Return
            End If
        End If

        'sort the message out
        sInfo = CONST_INF_connected
        LblInfo.Text = sInfo

        'load available customers
        LblInfo.Text = CONST_INF_locatingcustomer

        oCustomer.Account = TxtCustomer.Text.ToUpper
        'oCustomer.Account = TxtCustomer.Text.ToUpper
        Try
            iStatus = oSynergy.GetCustomer(oCustomer, sErrMsg)
        Catch ex As Exception
            MsgBox(ex.Message)
            LblInfo.Text = sInfo
            Return
        End Try

        If iStatus <> 0 Then
            MsgBox(sErrMsg)
            LblInfo.Text = sInfo
            Return
        End If

        sInfo = CONST_INF_customerlocated
        LblInfo.Text = sInfo

        'make the customer details group visable
        GrpCustomer.Visible = True

        'hide the other unrequired elements
        DisableMainElements()

        DisplayCustomer()

    End Sub

    Private Sub BtnCustomerCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCustomerCancel.Click
        'user canceled customer selection!
        ClearCustomer()
        oOrderForm.LblCustomerName.Text = oCustomer.Company
        oOrderForm.TxtCustomer.Text = ""

        'hide the customer details group visable
        oOrderForm.GrpCustomer.Visible = False

        'display the other unrequired elements
        EnableMainElements()
        oOrderForm.TxtCustomer.Focus()
        oOrderForm.LblInfo.Text = CONST_INF_connected
    End Sub

    Private Sub BtnCustomerAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCustomerAccept.Click
        LblCustomerName.Text = oCustomer.Company

        'hide the customer details group visable
        GrpCustomer.Visible = False

        'show the order group of controls
        GrpOrder.Visible = True
        BtnOrder.Visible = True
        BtnCancel.Visible = True

        Dim sInfo As String
        sInfo = oOrderForm.LblInfo.Text
        oOrderForm.LblInfo.Text = CONST_INF_locatingproducts

        Me.Refresh()

        FillProductCombo(CmboProdGroup)
        oOrderForm.LblInfo.Text = sInfo

    End Sub

    Private Sub CmboProdGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmboProdGroup.SelectedIndexChanged
        FillProductList(CmboProdGroup.Text, ListAvailableProducts)
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

        StartAgain()

    End Sub

    Private Sub LblCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblCustomer.Click
        TxtCustomer.Text = "syn001"
    End Sub

    Private Sub ListAvailableProducts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListAvailableProducts.DoubleClick

        '        Dim oListObj As ListView
        Dim oListItem As ListViewItem
        '        oListObj = sender

        oListItem = sender.SelectedItems.Item(0)
        OrderIt(oListItem.Text, ListOrderItems)

    End Sub

    Private Sub BtnOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOrder.Click
        CreateOrder(ListOrderItems)
    End Sub

    Private Sub ChkGiftWrap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGiftWrap.CheckedChanged
        If ChkGiftWrap.CheckState = CheckState.Checked Then
            TxtgiftMessage.Enabled = True
        Else
            TxtgiftMessage.Enabled = False
        End If
    End Sub
End Class
