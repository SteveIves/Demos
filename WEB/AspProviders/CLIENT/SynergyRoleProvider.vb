Imports System.Collections.Specialized
Imports System.Configuration.Provider
Imports System.Web.Hosting
Imports System.Web.Security

Public NotInheritable Class SynergyRoleProvider
    Inherits RoleProvider

    '
    ' If false, exceptions are Thrown to the caller. If true,
    ' exceptions are written to the event log.
    '
    Private pWriteExceptionsToEventLog As Boolean = False

    Public Property WriteExceptionsToEventLog() As Boolean
        Get
            Return pWriteExceptionsToEventLog
        End Get
        Set(ByVal value As Boolean)
            pWriteExceptionsToEventLog = value
        End Set
    End Property


    'System.Configuration.Provider.ProviderBase.Initialize Method

    Public Overrides Sub Initialize(ByVal name As String, ByVal config As NameValueCollection)

        'Initialize values from web.config.
        If IsNothing(config) Then Throw New ArgumentNullException("config")
        If IsNothing(Name) Or Name.Length = 0 Then Name = "SynergyRoleProvider"
        If String.IsNullOrEmpty(config("description")) Then
            config.Remove("description")
            config.Add("description", "Synergy ASP.NET Role Provider")
        End If

        'Initialize the abstract base class.
        MyBase.Initialize(Name, config)

        If IsNothing(config("applicationName")) Or config("applicationName").Trim() = "" Then
            pApplicationName = HostingEnvironment.ApplicationVirtualPath
        Else
            pApplicationName = config("applicationName")
        End If

        If Not IsNothing(config("writeExceptionsToEventLog")) Then
            If config("writeExceptionsToEventLog").ToUpper() = "TRUE" Then
                pWriteExceptionsToEventLog = True
            End If
        End If

    End Sub


    ' System.Web.Security.RoleProvider properties.

    Private pApplicationName As String

    Public Overrides Property ApplicationName() As String
        Get
            Return pApplicationName
        End Get
        Set(ByVal value As String)
            pApplicationName = value
        End Set
    End Property


    ' System.Web.Security.RoleProvider methods.

    Public Overrides Sub AddUsersToRoles(ByVal Usernames As String(), ByVal Rolenames As String())

        For Each Rolename As String In Rolenames
            If Not RoleExists(Rolename) Then
                Throw New ProviderException("Role name not found.")
            End If
        Next

        For Each Username As String In Usernames
            If Username.IndexOf(",") > 0 Then
                Throw New ArgumentException("User names cannot contain commas.")
            End If

            For Each Rolename As String In Rolenames
                If IsUserInRole(Username, Rolename) Then
                    Throw New ProviderException("User is already in role.")
                End If
            Next
        Next

        Dim Server As New SynPSG.ASP.AspProvider
        Dim CallStatus As Integer

        Try
            CallStatus = Server.AddUsersToRoles(pApplicationName, Usernames, Rolenames)
            If CallStatus <> 0 Then
                Dim e As New Exception("SynergyRoleProvider/AddUsersToRoles: Server returned error " & CallStatus)
                If WriteExceptionsToEventLog Then
                    WriteToEventLog(e, "SynergyRoleProvider/AddUsersToRoles")
                Else
                    Throw e
                End If
            End If
        Catch e As Exception
            If WriteExceptionsToEventLog Then
                WriteToEventLog(e, "SynergyRoleProvider/AddUsersToRoles")
            Else
                Throw e
            End If
        Finally
            Server.Dispose()
        End Try

    End Sub


    ' RoleProvider.CreateRole

    Public Overrides Sub CreateRole(ByVal Rolename As String)

        If Rolename.IndexOf(",") > 0 Then Throw New ArgumentException("Role names cannot contain commas.")

        If RoleExists(Rolename) Then Throw New ProviderException("Role name already exists.")

        Dim Server As New SynPSG.ASP.AspProvider
        Dim CallStatus As Integer

        Try
            CallStatus = Server.CreateRole(pApplicationName, Rolename)
            If CallStatus <> 0 Then
                Dim e As New Exception("SynergyRoleProvider/CreateRole: Server returned error " & CallStatus)
                If WriteExceptionsToEventLog Then
                    WriteToEventLog(e, "SynergyRoleProvider/CreateRole")
                Else
                    Throw e
                End If
            End If
        Catch e As Exception
            If WriteExceptionsToEventLog Then
                WriteToEventLog(e, "SynergyRoleProvider/CreateRole")
            Else
                Throw e
            End If
        Finally
            Server.Dispose()
        End Try

    End Sub


    ' RoleProvider.DeleteRole

    Public Overrides Function DeleteRole(ByVal Rolename As String, ByVal ThrowOnPopulatedRole As Boolean) As Boolean

        If Not RoleExists(Rolename) Then Throw New ProviderException("Role does not exist.")

        If (ThrowOnPopulatedRole And GetUsersInRole(Rolename).Length > 0) Then Throw New ProviderException("Cannot delete a populated role.")

        Dim Server As New SynPSG.ASP.AspProvider
        Dim CallStatus As Integer

        Try
            CallStatus = Server.DeleteRole(pApplicationName, rolename)
            If CallStatus <> 0 Then
                Dim e As New Exception("SynergyRoleProvider/DeleteRole: Server returned error " & CallStatus)
                If WriteExceptionsToEventLog Then
                    WriteToEventLog(e, "SynergyRoleProvider/DeleteRole")
                    Return False
                Else
                    Throw e
                End If
            End If
        Catch e As Exception
            If WriteExceptionsToEventLog Then
                WriteToEventLog(e, "SynergyRoleProvider/DeleteRole")
                Return False
            Else
                Throw e
            End If
        Finally
            Server.Dispose()
        End Try

        Return True

    End Function


    'RoleProvider.GetAllRoles

    Public Overrides Function GetAllRoles() As String()

        Dim Server As New SynPSG.ASP.AspProvider
        Dim Roles As New ArrayList()

        Try
            Server.GetAllRoles(pApplicationName, Roles)
        Catch e As Exception
            If WriteExceptionsToEventLog Then
                WriteToEventLog(e, "SynergyRoleProvider/GetAllRoles")
            Else
                Throw e
            End If
        Finally
            Server.Dispose()
        End Try

        If Roles.Count > 0 Then
            Dim RoleNames(Roles.Count - 1) As String
            Dim c As Integer
            For c = 0 To Roles.Count - 1
                RoleNames(c) = CType(Roles(c), SynPSG.ASP.Aspnet_role).Role
            Next
            Return RoleNames
        End If

        Return New String() {}

    End Function


    'RoleProvider.GetRolesForUser

    Public Overrides Function GetRolesForUser(ByVal Username As String) As String()

        Dim Server As New SynPSG.ASP.AspProvider
        Dim Roles As New ArrayList()

        Try
            Server.GetRolesForUser(pApplicationName, Username, Roles)
        Catch e As Exception
            If WriteExceptionsToEventLog Then
                WriteToEventLog(e, "SynergyRoleProvider/GetRolesForUser")
            Else
                Throw e
            End If
        Finally
            Server.Dispose()
        End Try

        If Roles.Count > 0 Then
            Dim RoleNames(Roles.Count - 1) As String
            For idx As Integer = 0 To Roles.Count - 1
                RoleNames(idx) = CType(Roles(idx), SynPSG.ASP.Aspnet_role).Role
            Next
            Return RoleNames
        End If

        Return New String() {}

    End Function


    ' RoleProvider.GetUsersInRole

    Public Overrides Function GetUsersInRole(ByVal Rolename As String) As String()

        Dim Server As New SynPSG.ASP.AspProvider
        Dim UsersInRole As New ArrayList()

        Try
            Server.GetUsersInRole(pApplicationName, Rolename, UsersInRole)
        Catch e As Exception
            If WriteExceptionsToEventLog Then
                WriteToEventLog(e, "SynergyRoleProvider/GetUsersInRole")
            Else
                Throw e
            End If
        Finally
            Server.Dispose()
        End Try

        If UsersInRole.Count > 0 Then
            Dim UserNames(UsersInRole.Count - 1) As String
            For idx As Integer = 0 To UsersInRole.Count - 1
                UserNames(idx) = CType(UsersInRole(idx), SynPSG.ASP.Aspnet_user_role).Username
            Next
            Return UserNames
        End If

        Return New String() {}

    End Function


    'RoleProvider.IsUserInRole

    Public Overrides Function IsUserInRole(ByVal Username As String, ByVal Rolename As String) As Boolean

        Dim Server As New SynPSG.ASP.AspProvider
        Dim UserIsInRole As Boolean = False

        Try
            UserIsInRole = Server.IsUserInRole(pApplicationName, Username, Rolename)
        Catch e As Exception
            If WriteExceptionsToEventLog Then
                WriteToEventLog(e, "SynergyRoleProvider/IsUserInRole")
            Else
                Throw e
            End If
        Finally
            Server.Dispose()
        End Try

        Return UserIsInRole

    End Function


    ' RoleProvider.RemoveUsersFromRoles

    Public Overrides Sub RemoveUsersFromRoles(ByVal Usernames As String(), ByVal Rolenames As String())

        For Each Rolename As String In Rolenames
            If Not RoleExists(Rolename) Then Throw New ProviderException("Role name not found.")
        Next

        For Each Username As String In Usernames
            For Each Rolename As String In Rolenames
                If Not IsUserInRole(Username, Rolename) Then
                    Throw New ProviderException("User is not in role.")
                End If
            Next
        Next

        Dim Server As New SynPSG.ASP.AspProvider
        Dim CallStatus As Integer

        Try
            CallStatus = Server.RemoveUsersFromRoles(pApplicationName, usernames, rolenames)
            If CallStatus <> 0 Then
                Dim e As New Exception("SynergyRoleProvider/RemoveUsersFromRoles: Server returned error " & CallStatus)
                If WriteExceptionsToEventLog Then
                    WriteToEventLog(e, "SynergyRoleProvider/RemoveUsersFromRoles")
                Else
                    Throw e
                End If
            End If
        Catch e As Exception
            If WriteExceptionsToEventLog Then
                WriteToEventLog(e, "SynergyRoleProvider/RemoveUsersFromRoles")
            Else
                Throw e
            End If
        Finally
            Server.Dispose()
        End Try

    End Sub


    'RoleProvider.RoleExists

    Public Overrides Function RoleExists(ByVal Rolename As String) As Boolean

        Dim Server As New SynPSG.ASP.AspProvider
        Dim Exists As Boolean = False

        Try
            Exists = Server.RoleExists(pApplicationName, Rolename)
        Catch e As Exception
            If WriteExceptionsToEventLog Then
                WriteToEventLog(e, "SynergyRoleProvider/RoleExists")
            Else
                Throw e
            End If
        Finally
            Server.Dispose()
        End Try

        Return Exists

    End Function

    'RoleProvider.FindUsersInRole

    Public Overrides Function FindUsersInRole(ByVal Rolename As String, ByVal UsernameToMatch As String) As String()

        Dim Server As New SynPSG.ASP.AspProvider
        Dim UsersInRole As New ArrayList()

        Try
            Server.FindUsersInRole(pApplicationName, Rolename, UsernameToMatch, UsersInRole)
        Catch e As Exception
            If WriteExceptionsToEventLog Then
                WriteToEventLog(e, "SynergyRoleProvider/FindUsersInRole")
            Else
                Throw e
            End If
        Finally
            Server.Dispose()
        End Try

        If UsersInRole.Count > 0 Then
            Dim UserNames(UsersInRole.Count - 1) As String
            For idx As Integer = 0 To UsersInRole.Count - 1
                UserNames(idx) = CType(UsersInRole(idx), SynPSG.ASP.Aspnet_user_role).Username
            Next
            Return UserNames
        End If

        Return New String() {}

    End Function

    '
    ' WriteToEventLog
    '   A helper function that writes exception detail to the event log. Exceptions
    ' are written to the event log as a security measure to aSub Private database
    ' details from being returned to the browser. If a method does not Return a status
    ' or boolean indicating the action succeeded or failed, a generic exception is also 
    ' Thrown by the caller.
    '

    Private Sub WriteToEventLog(ByVal Ex As Exception, ByVal Action As String)

        Dim Log As EventLog = New EventLog()

        With Log
            .Log = "Application"
            .Source = "SynergyRoleProvider"
            .WriteEntry("An exception occurred. Please check the Event Log." & vbCrLf & "Action: " & Action & vbCrLf & "Exception: " & Ex.ToString())
        End With

    End Sub

End Class
