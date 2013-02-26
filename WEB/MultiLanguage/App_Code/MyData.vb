Imports Microsoft.VisualBasic

Public Class MyData

    Private _Field1 As String
    Private _Field2 As String
    Private _Field3 As String

    Public Sub New(ByVal Field1 As String, ByVal Field2 As String, ByVal Field3 As String)
        _Field1 = Field1
        _Field2 = Field2
        _Field3 = Field3
    End Sub

    Public Property Field1() As String
        Get
            Return _Field1
        End Get
        Set(ByVal value As String)
            _Field1 = value
        End Set
    End Property

    Public Property Field2() As String
        Get
            Return _Field2
        End Get
        Set(ByVal value As String)
            _Field2 = value
        End Set
    End Property

    Public Property Field3() As String
        Get
            Return _Field3
        End Get
        Set(ByVal value As String)
            _Field3 = value
        End Set
    End Property

End Class
