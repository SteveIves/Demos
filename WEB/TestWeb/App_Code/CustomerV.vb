Namespace TestWebSolution

Public Class CustomerV

    Public Account As String
    Public Company As String
    Public Contact As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal newAccount As String, ByVal newCompany As String, ByVal newContact As String)

        Account = newAccount
        Company = newCompany
        Contact = newContact

    End Sub

End Class

End Namespace
