Public Class FrmBrowser

    Public Sub New(ByVal Page As String)

        Me.InitializeComponent()

        WebBrowser1.Url = New System.Uri(Page)

    End Sub

End Class