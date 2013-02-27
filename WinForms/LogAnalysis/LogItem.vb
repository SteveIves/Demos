Public Class LogItem

    Private pLineNumber As Integer
    Private pProcessID As String
    Private pText As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal LineNumber As Integer, ByVal ProcessID As String, ByVal Text As String)
        pLineNumber = LineNumber
        pProcessID = ProcessID
        pText = Text
    End Sub

    Public Property LineNumber() As Integer
        Get
            Return pLineNumber
        End Get
        Set(ByVal Value As Integer)
            pLineNumber = Value
        End Set
    End Property

    Public Property ProcessID() As String
        Get
            Return pProcessID
        End Get
        Set(ByVal Value As String)
            pProcessID = Value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return pText
        End Get
        Set(ByVal Value As String)
            pText = Value
        End Set
    End Property

End Class
