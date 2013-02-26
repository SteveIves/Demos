Namespace TestWebSolution

Public Class CustomerP

    Private p_Account As String
    Private p_Company As String
    Private p_Contact As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal newAccount As String, ByVal newCompany As String, ByVal newContact As String)

        p_Account = newAccount
        p_Company = newCompany
        p_Contact = newContact

    End Sub

    Public Property Account() As String
        Get
            Return p_Account
        End Get
        Set(ByVal Value As String)
            p_Account = Value
        End Set
    End Property

    Public Property Company() As String
        Get
            Return p_Company
        End Get
        Set(ByVal Value As String)
            p_Company = Value
        End Set
    End Property

    Public Property Contact() As String
        Get
            Return p_Contact
        End Get
        Set(ByVal Value As String)
            p_Contact = Value
        End Set
    End Property

End Class

End Namespace
