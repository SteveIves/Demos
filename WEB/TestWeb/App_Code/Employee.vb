Imports Microsoft.VisualBasic

Public Class Employee

    Private _EmployeeID As Integer
    Private _FirstName As String
    Private _Lastname As String
    Private _JobTitle As String

    Public Property EmployeeID() As Integer
        Get
            Return _EmployeeID
        End Get
        Set(ByVal value As Integer)
            _EmployeeID = value
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return _FirstName
        End Get
        Set(ByVal value As String)
            _FirstName = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return _Lastname
        End Get
        Set(ByVal value As String)
            _Lastname = value
        End Set
    End Property

    Public Property JobTitle() As String
        Get
            Return _Lastname
        End Get
        Set(ByVal value As String)
            _Lastname = value
        End Set
    End Property

End Class
