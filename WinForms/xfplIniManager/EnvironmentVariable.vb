Public Class EnvironmentVariable

    Private mName As String
    Private mValue As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal Name As String, ByVal Value As String)

        If Name.Trim.Length = 0 Then
            Throw New Exception("Property Name may not be blank")
        Else
            mName = Name
        End If

        If Value.Trim.Length = 0 Then
            Throw New Exception("Property Value may not be blank")
        Else
            mValue = Value
        End If

    End Sub

    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal Value As String)
            mName = Value
        End Set
    End Property

    Public Property Value() As String
        Get
            Return mValue
        End Get
        Set(ByVal Value As String)
            mValue = Value
        End Set
    End Property

End Class
