Imports Microsoft.VisualBasic

Public Class Utilities

    Public Shared Sub CheckLoggedIn()

        'This routine checks that the user has logged in.  It should be called as
        'the first thing in the Page_Load code for any page which should be restricted
        'to access by logged in users only.

        'Get a handle on the Session, Request and Response objects
        Dim Session As HttpSessionState = HttpContext.Current.Session
        Dim Request As HttpRequest = HttpContext.Current.Request
        Dim Response As HttpResponse = HttpContext.Current.Response

        'If the user has logged in then there will be a connection to xfServerPlus
        'stored in the users session.  Find out if it is there.

        If IsNothing(Session("SERVER")) Then

            'There is no saved server connection, therefore the user has not logged in.
            'Record the page that the user was attempting to access.  The login page
            'will check this following a successful login and will send them there.
            Session("TARGETPAGE") = Request.AppRelativeCurrentExecutionFilePath

            'Send the user to the login page.
            Response.Redirect("~/Login.aspx", True)

        End If

    End Sub

    Public Shared Sub ReportError(ByVal Ex As Exception, Optional ByVal MethodName As String = "")

        'Get a handle on the Session, Request and Response objects
        Dim Session As HttpSessionState = HttpContext.Current.Session
        Dim Request As HttpRequest = HttpContext.Current.Request
        Dim Response As HttpResponse = HttpContext.Current.Response

        'Record the exception
        Session("EXCEPTION") = Ex
        Session("ERRORPAGE") = Request.AppRelativeCurrentExecutionFilePath
        Session("ERRORMETHOD") = MethodName

        'Go to the service unavailable page
        Response.Redirect("~/ServiceUnavailable.aspx", True)

    End Sub

    '
    '8 digit date routines
    '

    Public Shared Function FormatYYYYMMDD(ByVal DateYYYYMMDD As Integer) As String

        'This routine accepts an integer in YYYYMMDD format and returns a
        'string in MM/DD/YYYY format.

        Dim StringDate As String
        Dim RetDate As String

        StringDate = DateYYYYMMDD.ToString
        RetDate = StringDate.Substring(4, 2) & "/" & StringDate.Substring(6, 2) & "/" & StringDate.Substring(0, 4)

        Return RetDate

    End Function


    Public Shared Function YYYYMMDDToDate(ByVal DateYYYYMMDD As Integer) As Date

        Dim StringDate As String = DateYYYYMMDD.ToString
        Dim Year As Integer = Integer.Parse(StringDate.Substring(0, 4))
        Dim Month As Integer = Integer.Parse(StringDate.Substring(4, 2))
        Dim Day As Integer = Integer.Parse(StringDate.Substring(6, 2))

        Return New Date(Year, Month, Day)

    End Function


    Public Shared Function FormatMMDDYYYY(ByVal D8Date As Integer) As String

        Dim RetVal As String = ""

        If D8Date <> 0 Then
            RetVal = Format(D8Date, "00/00/0000")
        End If

        Return RetVal

    End Function

    '
    '6-digit date routines
    '

    Public Shared Function FormatYYMMDD(ByVal DateYYMMDD As Integer) As String

        Dim StringDate As String
        Dim RetDate As String

        StringDate = DateYYMMDD.ToString
        RetDate = StringDate.Substring(2, 2) & "/" & StringDate.Substring(4, 2) & "/" & StringDate.Substring(0, 2)

        Return RetDate

    End Function

    Public Shared Function YYMMDDToDate(ByVal DateYYMMDD As Integer) As Date

        Dim StringDate As String = DateYYMMDD.ToString
        Dim Year As Integer = Integer.Parse(StringDate.Substring(0, 2))
        Dim Month As Integer = Integer.Parse(StringDate.Substring(2, 2))
        Dim Day As Integer = Integer.Parse(StringDate.Substring(4, 2))

        Return New Date(Year, Month, Day)

    End Function

    Public Shared Function DateFromMMDDYY(ByVal DateMMDDYY As Integer) As Date

        'Accepts an integer containing a date in MMDDYY format
        'and returns a date object representing that date

        Dim StringDate As String
        Dim Year As Integer, Month As Integer, Day As Integer

        StringDate = Format(DateMMDDYY, "000000")

        Year = Year2to4(Integer.Parse(StringDate.Substring(4, 2)))
        Month = Integer.Parse(StringDate.Substring(0, 2))
        Day = Integer.Parse(StringDate.Substring(2, 2))

        Return New Date(Year, Month, Day)

    End Function


    Public Shared Function DateToMMDDYY(ByVal RealDate As Date) As Integer

        'Accepts a date object and returns an integer containing a
        'representation of the date in MMDDYY format.

        Return Year4to2(RealDate.Year) + (RealDate.Day * 100) + (RealDate.Month * 10000)

    End Function

    '
    '4-digit time routines
    '

    Public Shared Function FormatHHMM(ByVal D4Time As Integer) As String

        Dim retval As String = ""

        If D4Time <> 0 Then
            retval = Format(D4Time, "00:00")
        End If

        Return retval

    End Function

    '
    '6-digit time routines
    '

    Public Shared Function FormatHHMMSS(ByVal D6Time As Integer) As String

        Dim RetVal As String = ""

        If D6Time <> 0 Then
            RetVal = Format(D6Time, "00:00:00")
        End If

        Return RetVal

    End Function

    Public Shared Function Year2to4(ByVal Year As Integer) As Integer

        If Year < 50 Then
            Year = Year + 2000
        Else
            Year = Year + 1900
        End If

        Return Year

    End Function

    Public Shared Function Year4to2(ByVal Year As Integer) As Integer

        Dim NewYear As Integer

        If Year >= 2000 Then
            NewYear = Year - 2000
        Else
            NewYear = Year - 1900
        End If

        Return NewYear

    End Function

    Public Shared Function FormatD10Phone(ByVal D10Phone As Integer) As String

        Dim RetVal As String = ""

        If D10Phone <> 0 Then
            RetVal = Format(D10Phone, "(000) 000-0000")
        End If

        Return RetVal

    End Function

    Public Shared Function OneDateFromTwo( _
        ByVal SourceDate As DateTime, _
        ByVal SourceTime As DateTime _
        ) As DateTime

        Dim NewDateTime As DateTime

        NewDateTime = New DateTime( _
            SourceDate.Year, SourceDate.Month, SourceDate.Day, _
            SourceTime.Hour, SourceTime.Minute, SourceTime.Second)

        Return NewDateTime

    End Function


    Public Shared Function BinaryToFile(ByRef FileData() As Byte, ByVal FileName As String, Optional ByRef ErrorText As String = "") As Boolean

        Dim OK As Boolean = True
        Dim fs As System.IO.FileStream = Nothing
        Dim bw As System.IO.BinaryWriter = Nothing

        ErrorText = ""

        'Create FileStream
        Try
            fs = New System.IO.FileStream(FileName, System.IO.FileMode.CreateNew)
        Catch ex As Exception
            ErrorText = "Failed to create FileStream." & vbCrLf & ex.Message
            fs = Nothing
            OK = False
        End Try

        'Create BinaryWriter
        If OK Then
            Try
                bw = New System.IO.BinaryWriter(fs)
            Catch ex As Exception
                ErrorText = "Failed to create BinaryWriter." & vbCrLf & ex.Message
                bw = Nothing
                OK = False
            End Try
        End If

        'Write data to file
        If OK Then
            Dim i As Integer
            For i = 0 To UBound(FileData)
                bw.Write(FileData(i))
            Next i
        End If

        If Not IsNothing(bw) Then bw.Close()
        If Not IsNothing(fs) Then fs.Close()

        Return OK

    End Function

    Private Shared Function FileToBinary(ByVal FileName As String, ByRef FileData() As Byte, Optional ByRef ErrorText As String = "") As Boolean

        Dim OK As Boolean = True
        Dim fs As System.IO.FileStream = Nothing
        Dim br As System.IO.BinaryReader = Nothing

        ErrorText = ""

        'Create SileStream
        Try
            fs = New System.IO.FileStream(FileName, System.IO.FileMode.Open)
        Catch ex As Exception
            ErrorText = "Failed to open file " & FileName & vbCrLf & ex.Message
            fs = Nothing
            OK = False
        End Try

        'Create BinaryReader
        If OK Then
            Try
                br = New System.IO.BinaryReader(fs)
            Catch ex As Exception
                ErrorText = "Failed to create BinaryReader." & vbCrLf & ex.Message
                br = Nothing
                OK = False
            End Try
        End If

        'Read data from file
        If OK Then
            ReDim FileData(fs.Length - 1)
            FileData = br.ReadBytes(fs.Length)
        End If

        If Not IsNothing(br) Then br.Close()
        If Not IsNothing(fs) Then fs.Close()

        Return OK

    End Function

End Class
