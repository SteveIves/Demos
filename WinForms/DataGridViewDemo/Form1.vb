Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Server As New xfpldemo.utils()

        Dim Products As New ArrayList()

        With Server
            .connect()
            .Initialize()
            .GetProducts("BOOKS", Products)
            .Cleanup()
        End With

        With DataGridView1
            .DataSource = Products
        End With

        With DataGridView2
            .AutoGenerateColumns = False
            .DataSource = Products
        End With

        With DataGridView3
            .AutoGenerateColumns = False
            .DataSource = Products
        End With

    End Sub
End Class
