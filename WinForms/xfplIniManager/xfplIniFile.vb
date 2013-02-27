Imports System.ComponentModel

Public Class xfplIniFile
    Implements INotifyPropertyChanged

    Public Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Private mFileName As String
    Private mCatalogLocation As String
    Private mCompression As Boolean = False
    Private mSingleLogFile As Boolean = False
    Private mDebugLogging As DebugLoggingLevel = DebugLoggingLevel.None
    Private mEnvironmentVariables As New Collection
    Private mErrorMessage As String
    Private mFunctionLogging As LoggingLevel = LoggingLevel.Critical
    Private mLogging As Boolean = False
    Private mLogFile As String
    Private mSessionLogging As LoggingLevel = LoggingLevel.Critical

    Public Enum DebugLoggingLevel As Integer
        None = 0
        Normal = 1
        Extended = 2
    End Enum

    Public Enum LoggingLevel As Integer
        None = 0
        Critical = 1
        All = 2
    End Enum

    Public ReadOnly Property FileName() As String
        Get
            Return mFileName
        End Get
    End Property

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return mErrorMessage
        End Get
    End Property

    Public Property CatalogLocation() As String
        Get
            Return mCatalogLocation
        End Get
        Set(ByVal Value As String)
            mCatalogLocation = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("CatalogLocation"))
        End Set
    End Property

    Public Property Compression() As Boolean
        Get
            Return mCompression
        End Get
        Set(ByVal value As Boolean)
            mCompression = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Compression"))
        End Set
    End Property

    Public Property SingleLogFile() As Boolean
        Get
            Return mSingleLogFile
        End Get
        Set(ByVal Value As Boolean)
            mSingleLogFile = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("SingleLogFile"))
        End Set
    End Property

    Public Property DebugLogging() As DebugLoggingLevel
        Get
            Return mDebugLogging
        End Get
        Set(ByVal Value As DebugLoggingLevel)
            mDebugLogging = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("DebugLogging"))
        End Set
    End Property

    Public Property EnvironmentVariables() As Collection
        Get
            Return mEnvironmentVariables
        End Get
        Set(ByVal Value As Collection)
            mEnvironmentVariables = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("EnvironmentVariables"))
        End Set
    End Property

    Public Property FunctionLogging() As LoggingLevel
        Get
            Return mFunctionLogging
        End Get
        Set(ByVal Value As LoggingLevel)
            mFunctionLogging = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("FunctionLogging"))
        End Set
    End Property

    Public Property Logging() As Boolean
        Get
            Return mLogging
        End Get
        Set(ByVal Value As Boolean)
            mLogging = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Logging"))
        End Set
    End Property

    Public Property LogFile() As String
        Get
            Return mLogFile
        End Get
        Set(ByVal Value As String)
            mLogFile = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LogFile"))
        End Set
    End Property

    Public Property SessionLogging() As LoggingLevel
        Get
            Return mSessionLogging
        End Get
        Set(ByVal Value As LoggingLevel)
            mSessionLogging = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("SessionLogging"))
        End Set
    End Property

    Public Function ReadFile(ByVal FileName As String) As Boolean

        Dim OK As Boolean = True
        Dim Buffer As String
        Dim Sr As System.IO.StreamReader = System.IO.File.OpenText(FileName)

        mFileName = FileName
        mErrorMessage = ""

        Do
            Try
                Buffer = Sr.ReadLine()
            Catch ex As Exception
                mErrorMessage = ex.Message
                OK = False
                Exit Do
            End Try

            'End of file?
            If Buffer Is Nothing Then
                Exit Do
            Else
                If Trim(Buffer).Length > 0 Then
                    If Not ParseIniRecord(Buffer) Then
                        OK = False
                        Exit Do
                    End If
                End If
            End If

        Loop

        Sr.Close()

        Return OK

    End Function

    Private Function ParseIniRecord(ByVal Buffer As String) As Boolean

        'Parse a record from an INI file, load appropriate data into the class properties.  If an invalid record
        'is encountered then issue an error and return false

        Dim OK As Boolean = True
        Dim Pos As Integer
        Dim ParamName As String = ""
        Dim ParamValue As String = ""
        Dim ParamLogical As String = ""

        'Find the = character
        Pos = InStr(Buffer, "=")
        If Pos = 0 Then
            mErrorMessage = "Invalid INI file record, no = found!"
            OK = False
        Else

            'Extract parameter name and value
            ParamName = Trim(Buffer.Substring(0, Pos - 1))
            ParamValue = Trim(Buffer.Substring(Pos, Buffer.Length - Pos))

            'Is it an XFPL_LOGICAL?
            Pos = InStr(ParamName, ":")
            If Pos <> 0 Then
                ParamLogical = Trim(ParamName.Substring(Pos, ParamName.Length - Pos))
                ParamName = Trim(ParamName.Substring(0, Pos - 1))
            End If

            Select Case ParamName

                Case "XFPL_LOGFILE"
                    LogFile = ParamValue

                Case "XFPL_LOG"
                    ParamValue.ToUpper()
                    Select Case ParamValue
                        Case "ON"
                            Logging = True
                        Case "OFF"
                            Logging = False
                    End Select

                Case "XFPL_SESS_INFO"
                    ParamValue.ToUpper()
                    Select Case ParamValue
                        Case "NONE"
                            SessionLogging = LoggingLevel.None
                        Case "CRITICAL"
                            SessionLogging = LoggingLevel.Critical
                        Case "ALL"
                            SessionLogging = LoggingLevel.All
                    End Select

                Case "XFPL_FUNC_INFO"
                    ParamValue.ToUpper()
                    Select Case ParamValue
                        Case "NONE"
                            FunctionLogging = LoggingLevel.None
                        Case "CRITICAL"
                            FunctionLogging = LoggingLevel.Critical
                        Case "ALL"
                            FunctionLogging = LoggingLevel.All
                    End Select

                Case "XFPL_DEBUG"
                    ParamValue.ToUpper()
                    Select Case ParamValue
                        Case "OFF"
                            DebugLogging = DebugLoggingLevel.None
                        Case "ON"
                            DebugLogging = DebugLoggingLevel.Normal
                        Case "DBG_ALL"
                            DebugLogging = DebugLoggingLevel.Extended
                    End Select

                Case "XFPL_SINGLELOGFILE"
                    ParamValue.ToUpper()
                    Select Case ParamValue
                        Case "OFF"
                            SingleLogFile = False
                        Case "ON"
                            SingleLogFile = True
                    End Select

                Case "XFPL_LOGICAL"

                    If ParamLogical.Equals("XFPL_SMCPATH") Then
                        CatalogLocation = ParamValue
                    Else
                        Try
                            EnvironmentVariables.Remove(ParamLogical)
                        Catch ex As Exception
                        Finally
                            EnvironmentVariables.Add(New EnvironmentVariable(ParamLogical, ParamValue))
                        End Try
                    End If

                Case "XFPL_COMPRESS"
                    ParamValue.ToUpper()
                    Select Case ParamValue
                        Case "OFF"
                            Compression = False
                        Case "ON"
                            Compression = True
                    End Select

                Case Else
                    mErrorMessage = "Invalid INI file record. Didn't recognise " & Buffer
                    OK = False
            End Select

        End If

        Return OK

    End Function

    Public Function SaveFile() As Boolean

        Dim Sw As System.IO.StreamWriter

        mErrorMessage = ""
        Try
            Sw = System.IO.File.CreateText(FileName)
        Catch ex As Exception
            mErrorMessage = ex.Message
            Return False
        End Try

        If LogFile.Length > 0 Then
            Sw.WriteLine("XFPL_LOGFILE=" & LogFile)
        End If

        If SingleLogFile Then
            Sw.WriteLine("XFPL_SINGLELOGFILE=ON")
        Else
            Sw.WriteLine("XFPL_SINGLELOGFILE=OFF")
        End If

        If Logging Then
            Sw.WriteLine("XFPL_LOG=ON")
        Else
            Sw.WriteLine("XFPL_LOG=OFF")
        End If

        Select Case SessionLogging
            Case LoggingLevel.None
                Sw.WriteLine("XFPL_SESS_INFO=NONE")
            Case LoggingLevel.Critical
                Sw.WriteLine("XFPL_SESS_INFO=CRITICAL")
            Case LoggingLevel.All
                Sw.WriteLine("XFPL_SESS_INFO=ALL")
        End Select

        Select Case FunctionLogging
            Case LoggingLevel.None
                Sw.WriteLine("XFPL_FUNC_INFO=NONE")
            Case LoggingLevel.Critical
                Sw.WriteLine("XFPL_FUNC_INFO=CRITICAL")
            Case LoggingLevel.All
                Sw.WriteLine("XFPL_FUNC_INFO=ALL")
        End Select

        Select Case DebugLogging
            Case DebugLoggingLevel.None
                Sw.WriteLine("XFPL_DEBUG=OFF")
            Case DebugLoggingLevel.Normal
                Sw.WriteLine("XFPL_DEBUG=ON")
            Case DebugLoggingLevel.Extended
                Sw.WriteLine("XFPL_DEBUG=DBG_ALL")
        End Select

        Select Case Compression
            Case True
                Sw.WriteLine("XFPL_COMPRESS=ON")
            Case False
                Sw.WriteLine("XFPL_COMPRESS=OFF")
        End Select

        If CatalogLocation.Length > 0 Then
            Sw.WriteLine("XFPL_LOGICAL:XFPL_SMCPATH=" & Trim(CatalogLocation))
        End If

        Dim envvar As EnvironmentVariable
        For Each envvar In EnvironmentVariables
            Sw.WriteLine("XFPL_LOGICAL:" & Trim(envvar.Name) & "=" & Trim(envvar.Value))
        Next

        With Sw
            .WriteLine()
            .Close()
        End With


    End Function

    Public Sub ResetToDefaults()

        mFileName = ""
        mErrorMessage = ""

        LogFile = ""
        Logging = False
        CatalogLocation = ""
        SessionLogging = LoggingLevel.Critical
        FunctionLogging = LoggingLevel.Critical
        DebugLogging = DebugLoggingLevel.None
        SingleLogFile = False
        Compression = False
        EnvironmentVariables = New Collection

    End Sub

End Class
