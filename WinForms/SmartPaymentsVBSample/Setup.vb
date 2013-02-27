'import relevant namespaces
Imports System
Imports System.IO
Imports System.Web
Imports System.Xml.Serialization

Namespace SmartPayments.VB.Configuration

    Public Class Setup

        Public Shared ReadOnly Property Settings() As AppConfigurationData
            Get

                'attempt to load the configuration settings from cache
                Dim data As AppConfigurationData

                If data Is Nothing Then
                    Dim filename As String
                    'the configuration settings are not in cache,
                    'or have been invalidated, so get a fresh copy
                    data = LoadSettings(filename)

                End If

                Return data
            End Get
        End Property

        Public Shared Function LoadSettings(ByVal fileName As String) As AppConfigurationData
            'read our configuration data file into a stream
            Dim reader As StreamReader = File.OpenText(fileName)

            'create an XMLSerializer object that can deserialize
            'our configuration data
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(AppConfigurationData))

            'deserialize our configuration data and cast it to
            'the AppConfigurationData datatype
            Dim data As AppConfigurationData = CType(serializer.Deserialize(reader), AppConfigurationData)

            'close the stream
            reader.Close()

            Return data
        End Function

        Public Shared Function SaveSettings(ByVal fileName As String, ByVal data As AppConfigurationData) As Boolean

            'open the configuration file
            Dim writer As StreamWriter = File.CreateText(fileName)
            Dim serializer As New XmlSerializer(GetType(AppConfigurationData))

            'serialize the current state of the configuration object
            'to the configuration file
            serializer.Serialize(writer, data)

            'close the stream
            writer.Close()
            Return True
        End Function


    End Class

    Public Class AppConfigurationData
        'declare private fields
        Private _UserID As String
        Private _Password As String
        Private _Register As String
        Private _TrainingMode As String

        <XmlElement()> _
        Public Property UserID() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                _UserID = Value
            End Set
        End Property

        <XmlElement()> _
        Public Property Password() As String
            Get
                Return _Password
            End Get
            Set(ByVal Value As String)
                _Password = Value
            End Set
        End Property

        <XmlElement()> _
        Public Property Register() As String
            Get
                Return _Register
            End Get
            Set(ByVal Value As String)
                _Register = Value
            End Set
        End Property

        <XmlElement()> _
                Public Property TrainingMode() As String
            Get
                Return _TrainingMode
            End Get
            Set(ByVal Value As String)
                _TrainingMode = Value
            End Set
        End Property

    End Class

End Namespace