Imports System.Data

Namespace TestWebSolution

    Partial Class BoundDataGrid2
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

            If Not IsPostBack Then

                Session("CustomerTable") = LoadTable()
                With DataGrid1
                    .DataSource = Session("CustomerTable")
                    .DataBind()
                End With

            Else

                DataGrid1.DataSource = Session("CustomerTable")

            End If

        End Sub

        Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged

            With DataGrid1
                .CurrentPageIndex = e.NewPageIndex
                .DataBind()
            End With

        End Sub

        Private Function LoadTable() As DataTable

            'This routine takes the simulated array of structures and builds a DataTable
            'which can then be used as a data source for data bound controls such as the
            'DataGrid

            Dim Count As Integer, TmpTable As DataTable, TmpRow As DataRow

            'Simulate getting an array of structures
            Dim CustomerArray As CustomerV()
            CustomerArray = LoadCustomers()

            'Create DataTable and define columns
            TmpTable = New DataTable
            With TmpTable
                .Columns.Add(New DataColumn("Account"))
                .Columns.Add(New DataColumn("Company"))
                .Columns.Add(New DataColumn("Contact"))
            End With

            'Add rows from array of structures
            For Count = 0 To UBound(CustomerArray)
                TmpRow = TmpTable.NewRow
                With CustomerArray(Count)
                    TmpRow(0) = .Account
                    TmpRow(1) = "<a href=""customer.aspx?account=" & .Account & """>" & .Company & "</a>"
                    TmpRow(2) = .Contact
                End With
                TmpTable.Rows.Add(TmpRow)
            Next

            Return TmpTable

        End Function

        Private Function LoadCustomers() As CustomerV()

            'This routine simulates a call to a Synergy method by returning an array of objects
            'containing fields as public variables.

            Const ItemCount As Integer = 123
            Dim Count As Integer, TmpArray(ItemCount) As CustomerV

            For Count = 0 To ItemCount
                TmpArray(Count) = New CustomerV
                With TmpArray(Count)
                    .Account = "CUST" & (Count + 1).ToString
                    .Company = "Company Name " & (Count + 1).ToString
                    .Contact = "Contact Name " & (Count + 1).ToString
                End With
            Next

            Return TmpArray

        End Function

    End Class

End Namespace
