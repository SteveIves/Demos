Imports System.Collections.Specialized
Imports System.Configuration.Provider
Imports System.Diagnostics
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web.Configuration
Imports System.Web.Security
Imports System.Web.Security.Membership

Public NotInheritable Class SynergyMembershipProvider
    Inherits MembershipProvider

    ' Global generated password length, generic exception message, event log info.
    Private newPasswordLength As Integer = 8
    Private eventSource As String = "SynergyMembershipProvider"
    Private eventLog As String = "Application"
    Private exceptionMessage As String = "SynergyMembershipProvider: An exception occurred. Please check the Event Log."

    ' Used when determining encryption key values.
    Private machineKey As MachineKeySection

    ' If False, exceptions are thrown to the caller. If True exceptions are written to the event log.
    Private pWriteExceptionsToEventLog As Boolean

    Public Property WriteExceptionsToEventLog() As Boolean
        Get
            Return pWriteExceptionsToEventLog
        End Get
        Set(ByVal value As Boolean)
            pWriteExceptionsToEventLog = value
        End Set
    End Property

    ' System.Configuration.Provider.ProviderBase.Initialize Method
    Public Overrides Sub Initialize(ByVal Name As String, ByVal Config As NameValueCollection)

        ' Initialize values from web.config.
        If IsNothing(Config) Then Throw New ArgumentNullException("config")

        If (IsNothing(Name) Or Name.Length = 0) Then Name = "SynergyMembershipProvider"

        If String.IsNullOrEmpty(config("description")) Then
            config.Remove("description")
            config.Add("description", "Synergy ASP.NET Membership provider")
        End If

        ' Initialize the abstract base class.
        MyBase.Initialize(Name, Config)

        pApplicationName = GetConfigValue(Config("applicationName"), System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath)
        pMaxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(Config("MaxInvalidPasswordAttempts"), "5"))
        pPasswordAttemptWindow = Convert.ToInt32(GetConfigValue(Config("PasswordAttemptWindow"), "10"))
        pMinRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(Config("minRequiredAlphaNumericCharacters"), "1"))
        pMinRequiredPasswordLength = Convert.ToInt32(GetConfigValue(Config("minRequiredPasswordLength"), "7"))
        pPasswordStrengthRegularExpression = Convert.ToString(GetConfigValue(Config("passwordStrengthRegularExpression"), ""))
        pEnablePasswordReset = Convert.ToBoolean(GetConfigValue(Config("EnablePasswordReset"), "True"))
        pEnablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(Config("EnablePasswordRetrieval"), "True"))
        pRequiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(Config("RequiresQuestionAndAnswer"), "False"))
        pRequiresUniqueEmail = Convert.ToBoolean(GetConfigValue(Config("RequiresUniqueEmail"), "True"))
        pWriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(Config("WriteExceptionsToEventLog"), "True"))

        Dim temp_format As String = Config("PasswordFormat")
        If IsNothing(temp_format) Then temp_format = "Hashed"

        Select Case temp_format
            Case "Hashed"
                pPasswordFormat = MembershipPasswordFormat.Hashed
            Case "Encrypted"
                pPasswordFormat = MembershipPasswordFormat.Encrypted
            Case "Clear"
                pPasswordFormat = MembershipPasswordFormat.Clear
            Case Else
                Throw New ProviderException("SynergyMembershipProvider: Password format not supported.")
        End Select

        ' Get encryption and decryption key information from the configuration.
        Dim Cfg As System.Configuration.Configuration = _
          WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath)
        machineKey = CType(Cfg.GetSection("system.web/machineKey"), MachineKeySection)

        If machineKey.ValidationKey.Contains("AutoGenerate") Then _
          If PasswordFormat <> MembershipPasswordFormat.Clear Then _
            Throw New ProviderException("SynergyMembershipProvider: Hashed or Encrypted passwords are not supported with auto-generated keys.")

    End Sub

    ' A helper function to retrieve config values from the configuration file.
    Private Function GetConfigValue(ByVal configValue As String, ByVal defaultValue As String) As String

        If String.IsNullOrEmpty(configValue) Then _
          Return defaultValue

        Return configValue

    End Function

    ' System.Web.Security.MembershipProvider properties.

    Private pApplicationName As String
    Private pEnablePasswordReset As Boolean
    Private pEnablePasswordRetrieval As Boolean
    Private pRequiresQuestionAndAnswer As Boolean
    Private pRequiresUniqueEmail As Boolean
    Private pMaxInvalidPasswordAttempts As Integer
    Private pPasswordAttemptWindow As Integer
    Private pPasswordFormat As MembershipPasswordFormat

    Public Overrides Property ApplicationName() As String
        Get
            Return pApplicationName
        End Get
        Set(ByVal value As String)
            pApplicationName = value
        End Set
    End Property

    Public Overrides ReadOnly Property EnablePasswordReset() As Boolean
        Get
            Return pEnablePasswordReset
        End Get
    End Property


    Public Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
        Get
            Return pEnablePasswordRetrieval
        End Get
    End Property


    Public Overrides ReadOnly Property RequiresQuestionAndAnswer() As Boolean
        Get
            Return pRequiresQuestionAndAnswer
        End Get
    End Property


    Public Overrides ReadOnly Property RequiresUniqueEmail() As Boolean
        Get
            Return pRequiresUniqueEmail
        End Get
    End Property


    Public Overrides ReadOnly Property MaxInvalidPasswordAttempts() As Integer
        Get
            Return pMaxInvalidPasswordAttempts
        End Get
    End Property


    Public Overrides ReadOnly Property PasswordAttemptWindow() As Integer
        Get
            Return pPasswordAttemptWindow
        End Get
    End Property


    Public Overrides ReadOnly Property PasswordFormat() As MembershipPasswordFormat
        Get
            Return pPasswordFormat
        End Get
    End Property

    Private pMinRequiredNonAlphanumericCharacters As Integer

    Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
        Get
            Return pMinRequiredNonAlphanumericCharacters
        End Get
    End Property

    Private pMinRequiredPasswordLength As Integer

    Public Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
        Get
            Return pMinRequiredPasswordLength
        End Get
    End Property

    Private pPasswordStrengthRegularExpression As String

    Public Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
        Get
            Return pPasswordStrengthRegularExpression
        End Get
    End Property

    'System.Web.Security.MembershipProvider methods.

    'MembershipProvider.ChangePassword

    Public Overrides Function ChangePassword(ByVal Username As String, ByVal OldPassword As String, ByVal NewPassword As String) As Boolean

        'Validate that we have been given the correct old password
        If Not ValidateUser(Username, OldPassword) Then Return False

        'Raise a ValidatingPassword event (if an event handler has been declared) 
        Dim Args As ValidatePasswordEventArgs = New ValidatePasswordEventArgs(Username, NewPassword, True)
        OnValidatingPassword(Args)

        If Args.Cancel Then
            If Not Args.FailureInformation Is Nothing Then
                Throw Args.FailureInformation
            Else
                Throw New ProviderException("SynergyMembershipProvider: Change password canceled due to New password validation failure.")
            End If
        End If

        'Change the password in the Synergy database
        Dim Server As New SynPSG.ASP.AspProvider
        Try
            If Server.ChangePassword(pApplicationName, Username, EncodePassword(NewPassword)) = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ThrowException("ChangePassword", ex)
        Finally
            Server.Dispose()
        End Try

    End Function

    'MembershipProvider.ChangePasswordQuestionAndAnswer

    Public Overrides Function ChangePasswordQuestionAndAnswer(ByVal Username As String, ByVal Password As String, ByVal NewPasswordQuestion As String, ByVal NewPasswordAnswer As String) As Boolean

        'Validate that we have been given the correct old password
        If Not ValidateUser(Username, Password) Then Return False

        'Change the password question and answer in the Synergy database
        Dim Server As New SynPSG.ASP.AspProvider

        Try
            If Server.ChangePasswordQuestion(pApplicationName, Username, NewPasswordQuestion, EncodePassword(NewPasswordAnswer)) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ThrowException("ChangePasswordQuestionAndAnswer", ex)
        Finally
            Server.Dispose()
        End Try

    End Function

    'MembershipProvider.CreateUser

    Public Overrides Function CreateUser(ByVal Username As String, ByVal Password As String, ByVal Email As String, _
        ByVal PasswordQuestion As String, ByVal PasswordAnswer As String, ByVal IsApproved As Boolean, _
        ByVal ProviderUserKey As Object, ByRef Status As MembershipCreateStatus) As MembershipUser

        Dim Args As ValidatePasswordEventArgs = New ValidatePasswordEventArgs(Username, Password, True)
        OnValidatingPassword(Args)
        If Args.Cancel Then
            status = MembershipCreateStatus.InvalidPassword
            Return Nothing
        End If

        If RequiresUniqueEmail AndAlso GetUserNameByEmail(Email) <> "" Then
            status = MembershipCreateStatus.DuplicateEmail
            Return Nothing
        End If

        If IsNothing(GetUser(Username, False)) Then

            Dim CreateDate As DateTime = DateTime.Now

            If ProviderUserKey Is Nothing Then
                ProviderUserKey = Guid.NewGuid()
            Else
                If Not TypeOf ProviderUserKey Is Guid Then
                    Status = MembershipCreateStatus.InvalidProviderUserKey
                    Return Nothing
                End If
            End If

            Dim NewUser As New SynPSG.ASP.Aspnet_user
            With NewUser
                .Pkid = ProviderUserKey.ToString
                .Application = pApplicationName
                .Username = Username
                .Password = EncodePassword(Password)
                .Email = Email
                .Password_question = PasswordQuestion
                .Password_answer = EncodePassword(PasswordAnswer)
                .Is_approved = IsApproved
                .Comment = ""
                .Created_date = CreateDate
                .Created_time = CreateDate
                .Last_password_change_date = CreateDate
                .Last_password_change_time = CreateDate
                .Last_activity_date = CreateDate
                .Last_activity_time = CreateDate
                .Is_locked_out = False
                .Last_locked_out_date = CreateDate
                .Last_locked_out_time = CreateDate
                .Failed_password_count = 0
                .Failed_password_window_date = CreateDate
                .Failed_password_window_time = CreateDate
                .Failed_answer_count = 0
                .Failed_answer_window_date = CreateDate
                .Failed_answer_window_time = CreateDate
            End With

            Dim Server As New SynPSG.ASP.AspProvider

            Try
                If Server.CreateUser(NewUser) = 0 Then
                    Status = MembershipCreateStatus.Success
                Else
                    Status = MembershipCreateStatus.UserRejected
                End If
            Catch ex As Exception
                ThrowException("CreateUser", ex)
                Status = MembershipCreateStatus.ProviderError
            Finally
                Server.Dispose()
            End Try

            Return GetUser(Username, False)

        Else
            Status = MembershipCreateStatus.DuplicateUserName
        End If

        Return Nothing

    End Function

    ' MembershipProvider.DeleteUser

    Public Overrides Function DeleteUser(ByVal username As String, ByVal deleteAllRelatedData As Boolean) As Boolean

        Dim Server As New SynPSG.ASP.AspProvider

        Try
            If Server.DeleteUser(pApplicationName, username, deleteAllRelatedData) = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ThrowException("DeleteUser", ex)
        Finally
            Server.Dispose()
        End Try

    End Function

    ' MembershipProvider.GetAllUsers

    Public Overrides Function GetAllUsers(ByVal PageIndex As Integer, ByVal PageSize As Integer, ByRef TotalRecords As Integer) As MembershipUserCollection

        Dim Users As MembershipUserCollection = New MembershipUserCollection()

        Dim Server As New SynPSG.ASP.AspProvider
        Dim UserRecords As New ArrayList

        Try
            Server.GetAllUsers(pApplicationName, PageIndex, PageSize, UserRecords, TotalRecords)
        Catch Ex As Exception
            ThrowException("GetAllUsers", Ex)
        Finally
            Server.Dispose()
        End Try

        Dim UserRecord As SynPSG.ASP.Aspnet_user

        For Each UserRecord In UserRecords
            Users.Add(UserFromUserRecord(UserRecord))
        Next

        Return Users

    End Function

    ' MembershipProvider.GetNumberOfUsersOnline

    Public Overrides Function GetNumberOfUsersOnline() As Integer

        Dim NumOnline As Integer = 0
        Dim OnlineSpan As TimeSpan = New TimeSpan(0, UserIsOnlineTimeWindow, 0)
        Dim CompareTime As DateTime = DateTime.Now.Subtract(OnlineSpan)
        Dim DateTimeRec As New SynPSG.ASP.Date_time

        With DateTimeRec
            .Date_field = CompareTime
            .Time_field = CompareTime
        End With

        Dim Server As New SynPSG.ASP.AspProvider

        Try
            NumOnline = Server.GetOnlineUserCount(pApplicationName, DateTimeRec)
        Catch ex As Exception
            ThrowException("GetOnlineUserCount", ex)
        Finally
            Server.Dispose()
        End Try

        If NumOnline < 0 Then
            ThrowException("GotOnlineUserCount", New Exception("Failed to retrieve online user count"))
        End If

        Return NumOnline

    End Function

    ' MembershipProvider.GetPassword

    Public Overrides Function GetPassword(ByVal Username As String, ByVal Answer As String) As String

        If Not EnablePasswordRetrieval Then Throw New ProviderException("SynergyMembershipProvider: Password retrieval is not enabled.")

        If PasswordFormat = MembershipPasswordFormat.Hashed Then Throw New ProviderException("SynergyMembershipProvider: Cannot retrieve hashed passwords.")

        Dim Password As String = ""
        Dim PasswordAnswer As String = ""
        Dim IsLockedOut As Boolean
        Dim CallStatus As Integer

        Dim Server As New SynPSG.ASP.AspProvider

        Try
            CallStatus = Server.GetPassword(pApplicationName, Username, Password, PasswordAnswer, IsLockedOut)
        Catch ex As Exception
            ThrowException("GetPassword", ex)
        Finally
            Server.Dispose()
        End Try

        If CallStatus <> 0 Then Throw New MembershipPasswordException("The supplied user name is not found.")

        If IsLockedOut Then Throw New MembershipPasswordException("The supplied user is locked out.")

        If RequiresQuestionAndAnswer AndAlso Not CheckPassword(answer, passwordAnswer) Then
            UpdateFailureCount(Username, "passwordAnswer")
            Throw New MembershipPasswordException("Incorrect password answer.")
        End If

        If PasswordFormat = MembershipPasswordFormat.Encrypted Then Password = UnEncodePassword(Password)

        Return password

    End Function

    ' MembershipProvider.GetUser(String, Boolean)

    Public Overrides Function GetUser(ByVal Username As String, ByVal UserIsOnline As Boolean) As MembershipUser

        Dim CallStatus As Integer
        Dim UserRecord As New SynPSG.ASP.Aspnet_user

        Dim u As MembershipUser = Nothing

        Dim Server As New SynPSG.ASP.AspProvider

        Try
            CallStatus = Server.GetUserByUsername(pApplicationName, Username, UserIsOnline, UserRecord)
            If CallStatus = 0 Then
                u = UserFromUserRecord(UserRecord)
            ElseIf CallStatus > 0 Then
                ThrowException("GetUserByUsername", New Exception("Provider method returned error " & CallStatus))
            End If
        Catch ex As Exception
            ThrowException("GetUserByUsername", ex)
        Finally
            Server.Dispose()
        End Try

        Return u

    End Function

    ' MembershipProvider.GetUser(Object, Boolean)

    Public Overrides Function GetUser(ByVal providerUserKey As Object, ByVal userIsOnline As Boolean) As MembershipUser

        Dim callStatus As Integer
        Dim UserRecord As New SynPSG.ASP.Aspnet_user
        Dim Pkid As Guid = providerUserKey

        Dim Server As New SynPSG.ASP.AspProvider
        Try
            callStatus = Server.GetUserByPkid(Pkid.ToString, userIsOnline, UserRecord)
        Catch ex As Exception
            ThrowException("GetUserByPkid", ex)
        Finally
            Server.Dispose()
        End Try

        If callStatus <> 0 Then
            ThrowException("GetUserByPkid", New Exception("Failed to get user record by primary key"))
        End If

        Return UserFromUserRecord(UserRecord)

    End Function

    Private Function UserFromUserRecord(ByVal UserRecord As SynPSG.ASP.Aspnet_user) As MembershipUser

        Dim User As MembershipUser

        Dim CreateDate As DateTime
        Dim LastLoginDate As DateTime
        Dim LastActivityDate As DateTime
        Dim LastPasswordChangeDate As DateTime
        Dim LastLockoutDate As DateTime

        With UserRecord
            CreateDate = OneDateFromTwo(.Created_date, .Created_time)
            LastLoginDate = OneDateFromTwo(.Last_login_date, .Last_login_time)
            LastActivityDate = OneDateFromTwo(.Last_activity_date, .Last_activity_time)
            LastPasswordChangeDate = OneDateFromTwo(.Last_password_change_date, .Last_password_change_time)
            LastLockoutDate = OneDateFromTwo(.Last_locked_out_date, .Last_locked_out_time)
            User = New MembershipUser(Me.Name, .Username, .Pkid, .Email, .Password_question, .Comment, .Is_approved, _
            .Is_locked_out, CreateDate, LastLoginDate, LastActivityDate, LastPasswordChangeDate, LastLockoutDate)
        End With

        Return User

    End Function

    '
    ' MembershipProvider.UnlockUser
    '

    Public Overrides Function UnlockUser(ByVal username As String) As Boolean

        Dim callStatus As Integer
        Dim Server As New SynPSG.ASP.AspProvider
        Try
            callStatus = Server.UnlockUser(pApplicationName, username)
        Catch ex As Exception
            ThrowException("UnlockUser", ex)
        Finally
            Server.Dispose()
        End Try

        If callStatus <> 0 Then
            ThrowException("UnlockUser", New Exception("Failed to unlock user record"))
        End If

        Return True

    End Function


    '
    ' MembershipProvider.GetUserNameByEmail
    '
    Public Overrides Function GetUserNameByEmail(ByVal Email As String) As String

        Dim Username As String = ""
        Dim CallStatus As Integer
        Dim Server As New SynPSG.ASP.AspProvider

        Try
            CallStatus = Server.GetUsernameByEmail(pApplicationName, Email, Username)
        Catch ex As Exception
            ThrowException("GetUsernameByEmail", ex)
        Finally
            Server.Dispose()
        End Try

        If CallStatus <> 0 Then
            ThrowException("GetUsernameByEmail", New Exception("Provider method returned error " & CallStatus))
        End If

        Return Username

    End Function

    '
    ' MembershipProvider.ResetPassword
    '
    Public Overrides Function ResetPassword(ByVal Username As String, ByVal Answer As String) As String

        If Not EnablePasswordReset Then
            Throw New NotSupportedException("Password Reset is not enabled.")
        End If

        If Answer Is Nothing AndAlso RequiresQuestionAndAnswer Then
            UpdateFailureCount(Username, "passwordAnswer")
            Throw New ProviderException("SynergyMembershipProvider: Password answer required for password reset.")
        End If

        Dim newPassword As String = System.Web.Security.Membership.GeneratePassword(newPasswordLength, MinRequiredNonAlphanumericCharacters)

        Dim Args As ValidatePasswordEventArgs = New ValidatePasswordEventArgs(Username, newPassword, True)
        OnValidatingPassword(Args)
        If Args.Cancel Then
            If Not Args.FailureInformation Is Nothing Then
                Throw Args.FailureInformation
            Else
                Throw New MembershipPasswordException("Reset password canceled due to password validation failure.")
            End If
        End If

        Dim callStatus As Integer
        Dim Password As String = ""
        Dim PasswordAnswer As String = ""
        Dim IsLockedOut As Boolean

        Dim Server As New SynPSG.ASP.AspProvider
        Try
            callStatus = Server.GetPassword(pApplicationName, Username, Password, PasswordAnswer, IsLockedOut)
        Catch ex As Exception
            ThrowException("ResetPassword", ex)
        Finally
            Server.Dispose()
        End Try

        If callStatus <> 0 Then
            ThrowException("ResetPassword", New Exception("Failed to reset password"))
        End If

        'Is the user locked out?
        If IsLockedOut Then Throw New MembershipPasswordException("The supplied user is locked out.")

        If RequiresQuestionAndAnswer AndAlso Not CheckPassword(Answer, PasswordAnswer) Then
            UpdateFailureCount(Username, "passwordAnswer")
            Throw New MembershipPasswordException("Incorrect password answer.")
        End If

        'Change the password in the Synergy database
        Try
            callStatus = Server.ChangePassword(pApplicationName, Username, EncodePassword(newPassword))
        Catch ex As Exception
            ThrowException("ResetPassword", ex)
        Finally
            Server = Nothing
        End Try

        'Did it work?
        If callStatus = 0 Then
            Return newPassword
        Else
            Throw New MembershipPasswordException("User not found, or user is locked out. Password not Reset.")
            Return ""
        End If

        Return ""

    End Function

    '
    ' MembershipProvider.UpdateUser
    '
    Public Overrides Sub UpdateUser(ByVal user As MembershipUser)

        Dim callStatus As Integer
        Dim Server As New SynPSG.ASP.AspProvider
        Try
            callStatus = Server.UpdateUser(pApplicationName, user.UserName, user.Email, user.Comment, user.IsApproved)
        Catch ex As Exception
            ThrowException("UpdateUser", ex)
        Finally
            Server.Dispose()
        End Try

        If callStatus <> 0 Then
            ThrowException("UpdateUser", New Exception("Failed to update user record"))
        End If


    End Sub

    '
    ' MembershipProvider.ValidateUser
    '
    Public Overrides Function ValidateUser(ByVal username As String, ByVal password As String) As Boolean

        Dim isValid As Boolean = False
        Dim CallStatus As Integer
        Dim isApproved As Boolean
        Dim isLockedOut As Boolean
        Dim RealPassword As String = ""
        Dim Server As SynPSG.ASP.AspProvider

        Server = New SynPSG.ASP.AspProvider()
        Try
            CallStatus = Server.ValidateUser(pApplicationName, username, RealPassword, isApproved, isLockedOut)
        Catch ex As Exception
            ThrowException("ValidateUser", ex)
        Finally
            Server.Dispose()
            Server = Nothing
        End Try

        If CallStatus <> 0 Or isLockedOut Then
            Return False
        End If

        If CheckPassword(password, RealPassword) Then
            If isApproved Then
                'We're good to go
                isValid = True
                'Update date of last login
                Server = New SynPSG.ASP.AspProvider()
                Try
                    Server.SetLastLoginDate(pApplicationName, username)
                Catch ex As Exception
                    ThrowException("SetLastLoginDate", ex)
                Finally
                    Server.Dispose()
                End Try
            End If
        Else
            UpdateFailureCount(username, "password")
        End If

        Server = Nothing

        Return isValid

    End Function

    '
    ' UpdateFailureCount
    '   A helper method that performs the checks and updates associated with
    ' password failure tracking.
    '
    Private Sub UpdateFailureCount(ByVal Username As String, ByVal FailureType As String)

        Dim Server As New SynPSG.ASP.AspProvider
        Try

            Dim PasswordCounters As New SynPSG.ASP.Aspnet_password_counters()
            Dim CallStatus As Integer

            CallStatus = Server.GetPasswordCounters(pApplicationName, Username, PasswordCounters)
            If CallStatus <> 0 Then _
                Throw New ProviderException("SynergyMembershipProvider: Unable to retrieve password counters.")

            Dim WindowStart As DateTime = New DateTime()
            Dim FailureCount As Integer = 0

            With PasswordCounters
                Select Case FailureType
                    Case "password"
                        FailureCount = .Password_fail_count
                        WindowStart = OneDateFromTwo(.Password_window_date, .Password_window_time)
                    Case "passwordAnswer"
                        FailureCount = .Answer_fail_count
                        WindowStart = OneDateFromTwo(.Answer_window_date, .Answer_window_time)
                End Select
            End With

            Dim WindowEnd As DateTime = WindowStart.AddMinutes(PasswordAttemptWindow)

            If FailureCount = 0 OrElse DateTime.Now > WindowEnd Then

                ' First password failure or outside of PasswordAttemptWindow. 
                ' Start a New password failure count from 1 and a New window starting now.

                Select Case FailureType
                    Case "password"
                        CallStatus = Server.StartPasswordFailWindow(pApplicationName, Username)
                    Case "passwordAnswer"
                        CallStatus = Server.StartAnswerFailWindow(pApplicationName, Username)
                End Select

                If CallStatus <> 0 Then _
                    Throw New ProviderException("SynergyMembershipProvider: Unable to update failure count and window start.")

            Else

                FailureCount += 1

                If FailureCount >= MaxInvalidPasswordAttempts Then

                    ' Password attempts have exceeded the failure threshold. Lock out the user.
                    If Server.LockUser(pApplicationName, Username) <> 0 Then _
                        Throw New ProviderException("SynergyMembershipProvider: Unable to lock out user.")

                Else
                    ' Password attempts have not exceeded the failure threshold. Update
                    ' the failure counts. Leave the window the same.

                    Select Case FailureType
                        Case "password"
                            CallStatus = Server.IncrementPasswordFailures(pApplicationName, Username)
                        Case "passwordAnswer"
                            CallStatus = Server.IncrementAnswerFailures(pApplicationName, Username)
                    End Select

                    If CallStatus <> 0 Then _
                        Throw New ProviderException("SynergyMembershipProvider: Unable to update failure count.")

                End If
            End If

        Catch ex As Exception
            ThrowException("UpdateFailureCount", ex)
        Finally
            Server.Dispose()
        End Try

    End Sub

    '
    ' CheckPassword
    '   Compares password values based on the MembershipPasswordFormat.
    '
    Private Function CheckPassword(ByVal password As String, ByVal dbpassword As String) As Boolean
        Dim pass1 As String = password
        Dim pass2 As String = dbpassword

        Select Case PasswordFormat
            Case MembershipPasswordFormat.Encrypted
                pass2 = UnEncodePassword(dbpassword)
            Case MembershipPasswordFormat.Hashed
                pass1 = EncodePassword(password)
            Case Else
        End Select

        If pass1 = pass2 Then
            Return True
        End If

        Return False
    End Function

    '
    ' EncodePassword
    '   Encrypts, Hashes, or leaves the password clear based on the PasswordFormat.
    '
    Private Function EncodePassword(ByVal password As String) As String
        Dim encodedPassword As String = password

        Select Case PasswordFormat
            Case MembershipPasswordFormat.Clear

            Case MembershipPasswordFormat.Encrypted
                encodedPassword = _
                  Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)))
            Case MembershipPasswordFormat.Hashed
                Dim hash As HMACSHA1 = New HMACSHA1()
                hash.Key = HexToByte(machineKey.ValidationKey)
                encodedPassword = _
                  Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)))
            Case Else
                Throw New ProviderException("SynergyMembershipProvider: Unsupported password format.")
        End Select

        Return encodedPassword
    End Function

    '
    ' UnEncodePassword
    '   Decrypts or leaves the password clear based on the PasswordFormat.
    '
    Private Function UnEncodePassword(ByVal encodedPassword As String) As String
        Dim password As String = encodedPassword

        Select Case PasswordFormat
            Case MembershipPasswordFormat.Clear

            Case MembershipPasswordFormat.Encrypted
                password = _
                  Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)))
            Case MembershipPasswordFormat.Hashed
                Throw New ProviderException("SynergyMembershipProvider: Cannot unencode a hashed password.")
            Case Else
                Throw New ProviderException("SynergyMembershipProvider: Unsupported password format.")
        End Select

        Return password
    End Function

    '
    ' HexToByte
    '   Converts a hexadecimal string to a byte array. Used to convert encryption
    ' key values from the configuration.
    '
    Private Function HexToByte(ByVal hexString As String) As Byte()
        Dim ReturnBytes((hexString.Length \ 2) - 1) As Byte
        For i As Integer = 0 To ReturnBytes.Length - 1
            ReturnBytes(i) = Convert.ToByte(hexString.Substring(i * 2, 2), 16)
        Next
        Return ReturnBytes
    End Function

    '
    ' MembershipProvider.FindUsersByName
    '
    Public Overrides Function FindUsersByName( _
        ByVal usernameToMatch As String, _
        ByVal pageIndex As Integer, _
        ByVal pageSize As Integer, _
        ByRef totalRecords As Integer) _
        As MembershipUserCollection

        Dim Users As MembershipUserCollection = New MembershipUserCollection()

        Dim UserRecords As New ArrayList
        Dim Server As New SynPSG.ASP.AspProvider
        Try
            Server.GetUsersByName(pApplicationName, usernameToMatch, pageIndex, pageSize, UserRecords, totalRecords)
        Catch ex As Exception
            ThrowException("GetUsersByName", ex)
        Finally
            Server.Dispose()
        End Try

        'Did the method return success but no data?
        If totalRecords = 0 Then Return Users

        'Build the return collection
        Dim UserRecord As SynPSG.ASP.Aspnet_user
        For Each UserRecord In UserRecords
            With UserRecord
                Users.Add(New MembershipUser( _
                    Me.Name, _
                    .Username, _
                    New Guid(.Pkid), _
                    .Email, _
                    .Password_question, _
                    .Comment, _
                    .Is_approved, _
                    .Is_locked_out, _
                    ConsolidateDateTime(.Created_date, .Created_time), _
                    ConsolidateDateTime(.Last_login_date, .Last_login_time), _
                    ConsolidateDateTime(.Last_activity_date, .Last_activity_time), _
                    ConsolidateDateTime(.Last_password_change_date, .Last_password_change_time), _
                    ConsolidateDateTime(.Last_locked_out_date, .Last_locked_out_date)))
            End With
        Next

        Return Users

    End Function

    '
    ' MembershipProvider.FindUsersByEmail
    '
    Public Overrides Function FindUsersByEmail( _
        ByVal emailToMatch As String, _
        ByVal pageIndex As Integer, _
        ByVal pageSize As Integer, _
        ByRef totalRecords As Integer) _
        As MembershipUserCollection

        Dim Users As MembershipUserCollection = New MembershipUserCollection()

        Dim UserRecords As New ArrayList
        Dim Server As New SynPSG.ASP.AspProvider
        Try
            Server.GetUsersByEmail(pApplicationName, emailToMatch, pageIndex, pageSize, UserRecords, totalRecords)
        Catch ex As Exception
            ThrowException("GetUsersByEmail", ex)
        Finally
            Server.Dispose()
        End Try

        'Did the method return success but no data?
        If totalRecords = 0 Then Return Users

        'Build the return collection
        Dim UserRecord As SynPSG.ASP.Aspnet_user
        For Each UserRecord In UserRecords
            With UserRecord
                Users.Add(New MembershipUser( _
                    Me.Name, _
                    .Username, _
                    New Guid(.Pkid), _
                    .Email, _
                    .Password_question, _
                    .Comment, _
                    .Is_approved, _
                    .Is_locked_out, _
                    ConsolidateDateTime(.Created_date, .Created_time), _
                    ConsolidateDateTime(.Last_login_date, .Last_login_time), _
                    ConsolidateDateTime(.Last_activity_date, .Last_activity_time), _
                    ConsolidateDateTime(.Last_password_change_date, .Last_password_change_time), _
                    ConsolidateDateTime(.Last_locked_out_date, .Last_locked_out_date)))
            End With
        Next

        Return Users

    End Function


    Private Sub ThrowException(ByVal MethodName As String, ByVal ex As Exception)

        If pWriteExceptionsToEventLog Then
            WriteToEventLog(MethodName, ex)
            Throw New ProviderException(exceptionMessage)
        Else
            Throw ex
        End If

    End Sub


    '
    ' WriteToEventLog
    '   A helper function that writes exception detail to the event log. Exceptions
    ' are written to the event log as a security measure to aSub Private database
    ' details from being Returned to the browser. If a method does not Return a status
    ' or boolean indicating the action succeeded or failed, a generic exception is also 
    ' Thrown by the caller.
    '
    Private Sub WriteToEventLog(ByVal MethodName As String, ByVal e As Exception)

        Dim log As EventLog = New EventLog()
        log.Source = eventSource
        log.Log = eventLog

        Dim message As String = "Failed to call Synergy method " & MethodName & vbCrLf
        message &= "Exception: " & e.ToString()

        log.WriteEntry(message)

    End Sub

    Private Function ConsolidateDateTime(ByRef DateVar As Date, ByRef TimeVar As Date) As Date

        Return New Date(DateVar.Year, DateVar.Month, DateVar.Day, TimeVar.Hour, TimeVar.Minute, TimeVar.Second)

    End Function

    Private Function OneDateFromTwo( _
        ByVal SourceDate As DateTime, _
        ByVal SourceTime As DateTime _
        ) As DateTime

        Dim NewDateTime As DateTime

        NewDateTime = New DateTime( _
            SourceDate.Year, SourceDate.Month, SourceDate.Day, _
            SourceTime.Hour, SourceTime.Minute, SourceTime.Second)

        Return NewDateTime

    End Function


End Class

