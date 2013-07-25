Public Class Form1
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
    Friend WithEvents txtKeyword As System.Windows.Forms.TextBox
	Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnNextPage As System.Windows.Forms.Button
    Friend WithEvents ResultsList As System.Windows.Forms.ListView
    Friend WithEvents cboMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMatchingResults As System.Windows.Forms.TextBox
    Friend WithEvents txtDownloadedResults As System.Windows.Forms.TextBox
    Friend WithEvents txtMatchingPages As System.Windows.Forms.TextBox
    Friend WithEvents txtDownloadedPages As System.Windows.Forms.TextBox
    Friend WithEvents SKU As System.Windows.Forms.ColumnHeader
    Friend WithEvents DESCRIPTION As System.Windows.Forms.ColumnHeader
    Friend WithEvents GROUP As System.Windows.Forms.ColumnHeader
    Friend WithEvents SELLING_PRICE As System.Windows.Forms.ColumnHeader
    Friend WithEvents PRICE_GROUP As System.Windows.Forms.ColumnHeader
    Friend WithEvents LAST_SALE As System.Windows.Forms.ColumnHeader
    Friend WithEvents LAST_COST_PRICE As System.Windows.Forms.ColumnHeader
    Friend WithEvents MOVING_AVE_COST_PRICE As System.Windows.Forms.ColumnHeader
    Friend WithEvents QTY_IN_STOCK As System.Windows.Forms.ColumnHeader
    Friend WithEvents QTY_ALLOCATED As System.Windows.Forms.ColumnHeader
    Friend WithEvents QTY_IN_TRANSIT As System.Windows.Forms.ColumnHeader
    Friend WithEvents QTY_ON_ORDER As System.Windows.Forms.ColumnHeader
    Friend WithEvents REFERENCE As System.Windows.Forms.ColumnHeader
    Friend WithEvents PUBLISHER As System.Windows.Forms.ColumnHeader
    Friend WithEvents AUTHOR As System.Windows.Forms.ColumnHeader
    Friend WithEvents TYPE As System.Windows.Forms.ColumnHeader
    Friend WithEvents RELEASE_DATE As System.Windows.Forms.ColumnHeader
    Friend WithEvents RATING As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtKeyword = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnNextPage = New System.Windows.Forms.Button
        Me.ResultsList = New System.Windows.Forms.ListView
        Me.SKU = New System.Windows.Forms.ColumnHeader
        Me.GROUP = New System.Windows.Forms.ColumnHeader
        Me.DESCRIPTION = New System.Windows.Forms.ColumnHeader
        Me.PRICE_GROUP = New System.Windows.Forms.ColumnHeader
        Me.SELLING_PRICE = New System.Windows.Forms.ColumnHeader
        Me.LAST_SALE = New System.Windows.Forms.ColumnHeader
        Me.LAST_COST_PRICE = New System.Windows.Forms.ColumnHeader
        Me.MOVING_AVE_COST_PRICE = New System.Windows.Forms.ColumnHeader
        Me.QTY_IN_STOCK = New System.Windows.Forms.ColumnHeader
        Me.QTY_ALLOCATED = New System.Windows.Forms.ColumnHeader
        Me.QTY_IN_TRANSIT = New System.Windows.Forms.ColumnHeader
        Me.QTY_ON_ORDER = New System.Windows.Forms.ColumnHeader
        Me.REFERENCE = New System.Windows.Forms.ColumnHeader
        Me.PUBLISHER = New System.Windows.Forms.ColumnHeader
        Me.AUTHOR = New System.Windows.Forms.ColumnHeader
        Me.TYPE = New System.Windows.Forms.ColumnHeader
        Me.RELEASE_DATE = New System.Windows.Forms.ColumnHeader
        Me.RATING = New System.Windows.Forms.ColumnHeader
        Me.cboMode = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtMatchingResults = New System.Windows.Forms.TextBox
        Me.txtDownloadedResults = New System.Windows.Forms.TextBox
        Me.txtMatchingPages = New System.Windows.Forms.TextBox
        Me.txtDownloadedPages = New System.Windows.Forms.TextBox
        Me.BtnSave = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtKeyword
        '
        Me.txtKeyword.Location = New System.Drawing.Point(84, 16)
        Me.txtKeyword.Name = "txtKeyword"
        Me.txtKeyword.Size = New System.Drawing.Size(268, 20)
        Me.txtKeyword.TabIndex = 1
        Me.txtKeyword.Text = ""
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(192, 40)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 20)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "New &Search"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Keywords"
        '
        'BtnNextPage
        '
        Me.BtnNextPage.Location = New System.Drawing.Point(280, 40)
        Me.BtnNextPage.Name = "BtnNextPage"
        Me.BtnNextPage.Size = New System.Drawing.Size(72, 20)
        Me.BtnNextPage.TabIndex = 4
        Me.BtnNextPage.Text = "Next &Page"
        '
        'ResultsList
        '
        Me.ResultsList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.SKU, Me.GROUP, Me.DESCRIPTION, Me.PRICE_GROUP, Me.SELLING_PRICE, Me.LAST_SALE, Me.LAST_COST_PRICE, Me.MOVING_AVE_COST_PRICE, Me.QTY_IN_STOCK, Me.QTY_ALLOCATED, Me.QTY_IN_TRANSIT, Me.QTY_ON_ORDER, Me.REFERENCE, Me.PUBLISHER, Me.AUTHOR, Me.TYPE, Me.RELEASE_DATE, Me.RATING})
        Me.ResultsList.FullRowSelect = True
        Me.ResultsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ResultsList.Location = New System.Drawing.Point(24, 72)
        Me.ResultsList.MultiSelect = False
        Me.ResultsList.Name = "ResultsList"
        Me.ResultsList.Size = New System.Drawing.Size(840, 296)
        Me.ResultsList.TabIndex = 5
        Me.ResultsList.View = System.Windows.Forms.View.Details
        '
        'SKU
        '
        Me.SKU.Text = "SKU"
        Me.SKU.Width = 74
        '
        'GROUP
        '
        Me.GROUP.Text = "GROUP"
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.Text = "DESCRIPTION"
        Me.DESCRIPTION.Width = 200
        '
        'PRICE_GROUP
        '
        Me.PRICE_GROUP.Text = "PRICE_GROUP"
        Me.PRICE_GROUP.Width = 93
        '
        'SELLING_PRICE
        '
        Me.SELLING_PRICE.Text = "SELLING_PRICE"
        Me.SELLING_PRICE.Width = 101
        '
        'LAST_SALE
        '
        Me.LAST_SALE.Text = "LAST_SALE"
        '
        'LAST_COST_PRICE
        '
        Me.LAST_COST_PRICE.Text = "LAST_COST_PRICE"
        '
        'MOVING_AVE_COST_PRICE
        '
        Me.MOVING_AVE_COST_PRICE.Text = "MOVING_AVE_COST_PRICE"
        '
        'QTY_IN_STOCK
        '
        Me.QTY_IN_STOCK.Text = "QTY_IN_STOCK"
        '
        'QTY_ALLOCATED
        '
        Me.QTY_ALLOCATED.Text = "QTY_ALLOCATED"
        '
        'QTY_IN_TRANSIT
        '
        Me.QTY_IN_TRANSIT.Text = "QTY_IN_TRANSIT"
        '
        'QTY_ON_ORDER
        '
        Me.QTY_ON_ORDER.Text = "QTY_ON_ORDER"
        '
        'REFERENCE
        '
        Me.REFERENCE.Text = "REFERENCE"
        '
        'PUBLISHER
        '
        Me.PUBLISHER.Text = "PUBLISHER"
        '
        'AUTHOR
        '
        Me.AUTHOR.Text = "AUTHOR"
        '
        'TYPE
        '
        Me.TYPE.Text = "TYPE"
        '
        'RELEASE_DATE
        '
        Me.RELEASE_DATE.Text = "RELEASE_DATE"
        '
        'RATING
        '
        Me.RATING.Text = "RATING"
        '
        'cboMode
        '
        Me.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMode.Items.AddRange(New Object() {"books", "music", "classical", "dvd", "vhs", "electronics", "kitchen", "software", "videogames", "magazines", "photo", "tools"})
        Me.cboMode.Location = New System.Drawing.Point(84, 40)
        Me.cboMode.Name = "cboMode"
        Me.cboMode.Size = New System.Drawing.Size(104, 21)
        Me.cboMode.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Category"
        '
        'StatusBar
        '
        Me.StatusBar.Location = New System.Drawing.Point(0, 416)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(876, 22)
        Me.StatusBar.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(504, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Matching results"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(696, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Matching pages"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(504, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Downloaded results"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(696, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Downloaded pages"
        '
        'txtMatchingResults
        '
        Me.txtMatchingResults.Enabled = False
        Me.txtMatchingResults.Location = New System.Drawing.Point(604, 8)
        Me.txtMatchingResults.Name = "txtMatchingResults"
        Me.txtMatchingResults.Size = New System.Drawing.Size(60, 20)
        Me.txtMatchingResults.TabIndex = 13
        Me.txtMatchingResults.Text = ""
        '
        'txtDownloadedResults
        '
        Me.txtDownloadedResults.Enabled = False
        Me.txtDownloadedResults.Location = New System.Drawing.Point(604, 36)
        Me.txtDownloadedResults.Name = "txtDownloadedResults"
        Me.txtDownloadedResults.Size = New System.Drawing.Size(60, 20)
        Me.txtDownloadedResults.TabIndex = 14
        Me.txtDownloadedResults.Text = ""
        '
        'txtMatchingPages
        '
        Me.txtMatchingPages.Enabled = False
        Me.txtMatchingPages.Location = New System.Drawing.Point(804, 12)
        Me.txtMatchingPages.Name = "txtMatchingPages"
        Me.txtMatchingPages.Size = New System.Drawing.Size(60, 20)
        Me.txtMatchingPages.TabIndex = 15
        Me.txtMatchingPages.Text = ""
        '
        'txtDownloadedPages
        '
        Me.txtDownloadedPages.Enabled = False
        Me.txtDownloadedPages.Location = New System.Drawing.Point(804, 40)
        Me.txtDownloadedPages.Name = "txtDownloadedPages"
        Me.txtDownloadedPages.Size = New System.Drawing.Size(60, 20)
        Me.txtDownloadedPages.TabIndex = 16
        Me.txtDownloadedPages.Text = ""
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(788, 376)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(76, 24)
        Me.BtnSave.TabIndex = 5
        Me.BtnSave.Text = "&Save"
        '
        'Form1
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(876, 438)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.txtDownloadedPages)
        Me.Controls.Add(Me.txtMatchingPages)
        Me.Controls.Add(Me.txtDownloadedResults)
        Me.Controls.Add(Me.txtMatchingResults)
        Me.Controls.Add(Me.txtKeyword)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboMode)
        Me.Controls.Add(Me.ResultsList)
        Me.Controls.Add(Me.BtnNextPage)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "Form1"
        Me.Text = "Amazon Product Search"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Const PageSize As Integer = 10

    Dim Keywords As String
    Dim Mode As String
    Dim Page As Integer
    Dim TotalResults As Integer
    Dim TotalPages As Integer

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        BtnNextPage.Enabled = True
        ResultsList.Items.Clear()
        TotalResults = 0
        TotalPages = 0

        Keywords = txtKeyword.Text
        Page = 1
        Mode = cboMode.Text

        DoKeywordSearch()

    End Sub

    Private Sub BtnNextPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNextPage.Click

        If Page < TotalPages Then
            Page += 1
            DoKeywordSearch()
        End If

    End Sub

    Private Sub DoKeywordSearch()

        Dim Amazon As New AmazonClient.com.amazon.soap.AmazonSearchService
        Dim SearchRequest As New AmazonClient.com.amazon.soap.KeywordRequest
        Dim ProductInfo As AmazonClient.com.amazon.soap.ProductInfo
        Dim OK As Boolean = False

        'Setup search criteria

        With SearchRequest
            .keyword = Keywords
            .page = Page
            .mode = Mode
            .tag = "webservices-20"
            .type = "heavy"
            .devtag = "DGTK7FBBG9G4A"
            .sort = "+titlerank"
        End With

        'Do the search

        StatusBar.Text = "Searching on amazon.com..."
        Me.Cursor = Cursors.WaitCursor

        Try
            ProductInfo = Amazon.KeywordSearchRequest(SearchRequest)
            OK = True
        Catch ex As Exception
            MsgBox("Amazon search failed. " & ex.Message)
        End Try

        Me.Cursor = Cursors.Default
        StatusBar.Text = ""

        'Deal with resulting data

        If OK Then
            ProcessResults(ProductInfo)
        End If

        'Clean up

        ProductInfo = Nothing
        Amazon = Nothing

    End Sub

    Private Sub ProcessResults(ByVal ProductInfo As AmazonClient.com.amazon.soap.ProductInfo)

        If ProductInfo.TotalResults = 0 Then
            StatusBar.Text = "No matching results"
        Else

            Dim ProductDetails(UBound(ProductInfo.Details)) As AmazonClient.com.amazon.soap.Details
            Dim Count As Integer
            Dim NewItem As ListViewItem
            Dim ProductRecord As xfpldemo.Product
            Dim x As New Random(Integer.Parse(Now.Second))

            TotalResults = ProductInfo.TotalResults
            TotalPages = ProductInfo.TotalPages

            txtDownloadedResults.Text = Page * PageSize
            txtMatchingResults.Text = TotalResults
            txtDownloadedPages.Text = Page
            txtMatchingPages.Text = TotalPages

            ProductDetails = ProductInfo.Details


            For Count = 0 To UBound(ProductInfo.Details)

                ProductRecord = New xfpldemo.Product

                With ProductDetails(Count)
                    ProductRecord.Sku = .Asin
                    ProductRecord.Group = Mode.ToUpper
                    ProductRecord.Description = .ProductName
                    ProductRecord.Price_group = Mode.ToUpper
                    ProductRecord.Selling_price = MakeSellingPrice(.ListPrice)
                    'ProductRecord.Last_sale
                    ProductRecord.Last_cost_price = MakeCostPrice(ProductRecord.Selling_price)
                    ProductRecord.Moving_ave_cost_price = ProductRecord.Last_cost_price
                    ProductRecord.Qty_in_stock = x.NextDouble * 100
                    ProductRecord.Qty_allocated = (ProductRecord.Qty_in_stock / 100) * (x.NextDouble * 10)
                    ProductRecord.Qty_on_order = 0
                    ProductRecord.Qty_in_transit = 0
                    If Not IsNothing(.Isbn) Then
                        ProductRecord.Reference = .Isbn
                    End If
                    If Not IsNothing(.Publisher) Then
                        ProductRecord.Publisher = .Publisher
                    End If
                    ProductRecord.Author = ""
                    ProductRecord.Type = ""
                    'ProductRecord.Release_date = Date.Parse(.ReleaseDate)
                    ProductRecord.Rating = ""
                End With

                With ProductRecord

                    NewItem = ResultsList.Items.Add(ProductRecord.Sku)
                    NewItem.SubItems.Add(ProductRecord.Group)
                    NewItem.SubItems.Add(.Description)
                    NewItem.SubItems.Add(.Price_group)
                    NewItem.SubItems.Add(.Selling_price)
                    NewItem.SubItems.Add(.Last_sale)
                    NewItem.SubItems.Add(.Last_cost_price)
                    NewItem.SubItems.Add(.Moving_ave_cost_price)
                    NewItem.SubItems.Add(.Qty_in_stock)
                    NewItem.SubItems.Add(.Qty_allocated)
                    NewItem.SubItems.Add(.Qty_in_transit)
                    NewItem.SubItems.Add(.Qty_on_order)
                    NewItem.SubItems.Add(.Reference)
                    NewItem.SubItems.Add(.Publisher)
                    NewItem.SubItems.Add(.Author)
                    NewItem.SubItems.Add(.Type)
                    NewItem.SubItems.Add(.Release_date)
                    NewItem.SubItems.Add(.Rating)

                End With

                NewItem.Tag = ProductRecord

            Next

            If Page = TotalPages Then
                BtnNextPage.Enabled = False
            End If

            ProductDetails = Nothing

        End If

    End Sub

    Private Function MakeSellingPrice(ByVal ListPrice As String) As String

        Dim OutStr As String

        If IsNothing(ListPrice) Or (ListPrice = "") Then
            Dim x As New Random(Integer.Parse(Now.Second))
            OutStr = "9.99"
        Else
            Dim trimoff(1) As Char
            trimoff(0) = "$"
            trimoff(1) = " "
            OutStr = ListPrice.Trim(trimoff)
        End If

        Return OutStr

    End Function

    Private Function MakeCostPrice(ByVal ListPrice As String) As String

        Dim OutStr As String

        Dim trimoff(1) As Char
        trimoff(0) = "$"
        trimoff(1) = " "

        Dim CostPrice As Decimal
        CostPrice = (Decimal.Parse(ListPrice.Trim(trimoff)) / 100) * 75
        OutStr = CostPrice.ToString

        Return OutStr

    End Function

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        Dim Product(ResultsList.Items.Count - 1) As xfpldemo.Product
        Dim count As Integer
        For count = 0 To ResultsList.Items.Count - 1
            Product(count) = ResultsList.Items(count).Tag
        Next

        Dim x As New xfpldemo.utils
        Try
            StatusBar.Text = "Saving records to database..."
            Me.Cursor = Cursors.WaitCursor
            With x
                .connect()
                .Initialize()
                .AddProducts(Product)
                StatusBar.Text = "Records saved."
            End With
        Catch ex As Exception
            MsgBox("Failed to save records to database. " & ex.Message)
        Finally
            With x
                .Cleanup()
                .disconnect()
            End With
            Me.Cursor = Cursors.Default
            StatusBar.Text = ""
        End Try

    End Sub
End Class
