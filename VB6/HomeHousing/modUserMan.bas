Attribute VB_Name = "modSessionManager"
'-------------------------------------------------------------------------
' This module holds the collection of users that have been instanciated
' since the last reboot of the server. (As it is in-process, should the
' server fail all data will be lost.  However, while the server is
' running and any users or schemes are held in the collection it will be
' unable to unload (as the collection will hold pointers to items
' within the component).
'-------------------------------------------------------------------------

Option Explicit
Option Base 0

Public gcUsers As Collection ' Collection of user objects that can be
                             ' supplied to a request page
Public gcSchemes As Collection ' Collection of scheme objects that can
                               ' be supplied to user objects
Public gcPages As Collection ' Collection of display pages - referenced by page ID
Public gbInitialised As Boolean ' flags whether the initialisation  of the
                                ' collections has occured - this will be
                                ' done the first time the coordinator class
                                ' is called
Public glCoordinatorCount As Long ' count of number of time coordinator
                                  ' object served out users
                                  
Public gaSchemeBaseDataArray() As String
                                  
Public Sub Main()
    '-------------------------------------------------------------------------
    ' Initially ensures gbInitialises is false - actual data will be set up
    ' in CountInitialise which is called by the coordinator to keep
    ' track of requests serviced
    '-------------------------------------------------------------------------

    gbInitialised = False
    glCoordinatorCount = 0

End Sub

Public Sub CountInitialise()
    '-------------------------------------------------------------------------
    ' If this is the first time called, then set up the global
    ' collections of data and the special users
    '-------------------------------------------------------------------------
    Dim oUser As New User
    Dim oLogonScreen As New LogonScreen
    Dim oMessageScreen As New MessageScreen
    Dim oMainScreen As New MainScreen
    Dim oCreateSchemeScreen As New CreateSchemeScreen
    Dim oEditBasicSchemeScreen As New EditSchemeBasicsScreen
    Dim oSelectSchemeScreen As New SelectSchemeScreen
    Dim oEditSiteScheme As New EditSiteScheme
    Dim oEditCostScheme As New EditCostsScreen
    Dim oEditGroupCostsScheme As New EditGroupCostsScreen
    
    If glCoordinatorCount = 0 Then
        ' No users or schemes have been created yet - colections are empty
        Set gcUsers = New Collection
        Set gcSchemes = New Collection
        Set gcPages = New Collection
        
        ' Initialise the users collection
        ' 1/ add the unknown user - can only respond with a logon screen

        oUser.UserID = giUNKNOWN_ID
        oUser.RealName = "UNKNOWN"
        gcUsers.Add oUser
        
        Set oUser = Nothing ' break the link
        
        ' Initialise the pages collection
        ' 1/ Need to add all available pages to the collection
        '    unfortunately this is not very general as each class has a
        '    specific name since they do different things
        '    When a new page is added you would have to go through
        '    and add it here to the collection
        '    In its initialise section the page sets its own ID - fixed
        '    ie the item number may not be important
        '    Its ID is set as the key in the collection for fast lookup
        
        gcPages.Add oLogonScreen, CStr(oLogonScreen.ScreenID)
        gcPages.Add oMainScreen, CStr(oMainScreen.ScreenID)
        gcPages.Add oMessageScreen, CStr(oMessageScreen.ScreenID)
        gcPages.Add oCreateSchemeScreen, CStr(oCreateSchemeScreen.ScreenID)
        gcPages.Add oEditBasicSchemeScreen, CStr(oEditBasicSchemeScreen.ScreenID)
        gcPages.Add oSelectSchemeScreen, CStr(oSelectSchemeScreen.ScreenID)
        gcPages.Add oEditSiteScheme, CStr(oEditSiteScheme.ScreenID)
        gcPages.Add oEditCostScheme, CStr(oEditCostScheme.ScreenID)
        gcPages.Add oEditGroupCostsScheme, CStr(oEditGroupCostsScheme.ScreenID)
       
    End If
    
    
    Set oLogonScreen = Nothing
    Set oMainScreen = Nothing
    Set oMessageScreen = Nothing
    
    ' increment count - ensures set up does not occur again
    glCoordinatorCount = glCoordinatorCount + 1

End Sub

Public Sub AddNewUser(oNewUser As User)

    ' add a new user to the globals collection
    ' key is set as the userid - this will force an error
    ' if somebody else tries to set it at the same time
    
    gcUsers.Add oNewUser, CStr(oNewUser.UserID)
    ' TODO deal with error - should only happen if two people
    ' are trying to log in on the same username very closely
    ' together
    
End Sub

Public Function ButtonBar(sCurrent As String) As String

    ButtonBar = "<center>"
    
    If sCurrent = gsEDIT_BASIC_SCHEME_SCREEN_ID Then
        ButtonBar = ButtonBar & "[General]" & vbCrLf
    Else
        ButtonBar = ButtonBar & "<input type=""submit"" value=""General""" & _
                    " Name = """ & gsGOTO_BASIC_SCHEME_SCREEN & """ >" & vbCrLf
    End If
    
    If sCurrent = gsEDIT_SITE_SCREEN_ID Then
        ButtonBar = ButtonBar & "[Site]" & vbCrLf
    Else
        ButtonBar = ButtonBar & "<input type=""submit"" value=""Site""" & _
                    " Name = """ & gsGOTO_SITE_SCREEN & """ >" & vbCrLf
    End If
   
    If sCurrent = gsEDIT_PROPERTIES_SCREEN_ID Then
        ButtonBar = ButtonBar & "[Properties]" & vbCrLf
    Else
        ButtonBar = ButtonBar & "<input type=""submit"" value=""Properties""" & _
                    " Name = """ & gsGOTO_PROPERTIES_SCREEN & """ >" & vbCrLf
    End If
   
    If sCurrent = gsEDIT_CONSULTANT_SCHEME_SCREEN_ID Then
        ButtonBar = ButtonBar & "[Consultants]" & vbCrLf
    Else
        ButtonBar = ButtonBar & "<input type=""submit"" value=""Consultants""" & _
                    " Name = """ & gsGOTO_CONSULTANT_SCHEME_SCREEN & """ >" & vbCrLf
    End If
   
    If sCurrent = gsEDIT_CONTRACTOR_SCHEME_SCREEN_ID Then
        ButtonBar = ButtonBar & "[Contractors]" & vbCrLf
    Else
        ButtonBar = ButtonBar & "<input type=""submit"" value=""Contractors""" & _
                    " Name = """ & gsGOTO_CONTRACTOR_SCHEME_SCREEN & """ >" & vbCrLf
    End If
   
    If sCurrent = gsEDIT_GROUP_COSTS_SCREEN_ID Then
        ButtonBar = ButtonBar & "[Costs]" & vbCrLf
    Else
        ButtonBar = ButtonBar & "<input type=""submit"" value=""Costs""" & _
                    " Name = """ & gsGOTO_GROUP_COSTS_SCREEN & """ >" & vbCrLf
    End If
   
    If sCurrent = gsEDIT_FUNDING_SCREEN_ID Then
        ButtonBar = ButtonBar & "[Funding]" & vbCrLf
    Else
        ButtonBar = ButtonBar & "<input type=""submit"" value=""Funding""" & _
                    " Name = """ & gsGOTO_FUNDING_SCREEN & """ >" & vbCrLf
    End If
   
    ButtonBar = ButtonBar & "<p></center>"
   
End Function

Public Function PrintData(vDataArray As Variant) As String
    ' prints a variant data array
    Dim iRowCount As Integer
    Dim sOutput As String
    
    For iRowCount = 0 To UBound(vDataArray, 2)
        sOutput = sOutput & vDataArray(0, iRowCount) & "   " & _
                  vDataArray(1, iRowCount) & vbCrLf
    Next

    PrintData = sOutput
    
End Function

Public Function LoadScheme(iSchemeID As Integer)
    Dim oScheme As Scheme
    
    Set oScheme = New Scheme
    
    On Error GoTo AlreadyLoaded
        ' if it already exists in the collection, no need to add again
        gcSchemes.Add oScheme, CStr(iSchemeID)
    
    oScheme.InitialiseSchemeData (iSchemeID)
    
AlreadyLoaded:

End Function

Public Function CreateNewScheme(sSet As String) As Integer

    ' this routine takes the input from the logon screen and sets
    ' up the data in the database - scheme ID is the unique ID
    ' returned from setting up a new scheme - returned in function
    
    Dim oScheme As Scheme
    Dim sSQL As String
    Dim conScheme As New rdoConnection
    Dim mrsScheme As rdoResultset
    Dim iSchemeID As Integer
    Dim rQuery As New rdoQuery
    
    ' first set up the scheme index (later change to stored procedure)
    ' will need to first put into the system data table which provides
    ' the schemeID and the default security group
    
    
    conScheme.Connect = gsDB_CONN_STRING
    conScheme.CursorDriver = rdUseOdbc
    conScheme.EstablishConnection rdDriverNoPrompt
    
    Set rQuery.ActiveConnection = conScheme
    
    rQuery.SQL = "exec SchemeSystemData_Add"
    
    Set mrsScheme = rQuery.OpenResultset(rdOpenForwardOnly, rdConcurReadOnly)
    
    iSchemeID = mrsScheme(0)
    
    mrsScheme.Close
    Set mrsScheme = Nothing
    rQuery.Close
    Set rQuery = Nothing
    
 Set rQuery.ActiveConnection = conScheme
   
    rQuery.SQL = "exec Scheme_Add " & iSchemeID
    
    Set mrsScheme = rQuery.OpenResultset(rdOpenForwardOnly, rdConcurReadOnly)

   
    CreateNewScheme = iSchemeID
    
    sSQL = "update " & gsSCHEME_TABLE_NAME & " set " & Left(sSet, Len(sSet) - 1) & " where schemeID=" & iSchemeID
    
    conScheme.Execute (sSQL)

    'release the connection
    rQuery.Close
    'mrsScheme.Close
    conScheme.Close
    Set rQuery = Nothing
    Set mrsScheme = Nothing
    Set conScheme = Nothing

    ' now that the scheme is in the database, add it to the collection
    ' only do if the database addition is correct
    Set oScheme = New Scheme
    oScheme.InitialiseSchemeData (iSchemeID)
    
    gcSchemes.Add oScheme, CStr(oScheme.SchemeID)
    
End Function

Public Function CreateNewSchemeAccess(sInto As String, sValues As String) As Integer

    ' this routine takes the input from the logon screen and sets
    ' up the data in the database - scheme ID is the unique ID
    ' returned from setting up a new scheme - returned in function
    
    Dim oScheme As Scheme
    Dim sSQL As String
    Dim conScheme As New rdoConnection
    Dim mrsScheme As rdoResultset
    Dim iSchemeID As Integer
    
    ' first set up the scheme index (later change to stored procedure)
    ' will need to first put into the system data table which provides
    ' the schemeID and the default security group
    
    sSQL = "insert into " & gsSCHEME_SYSTEM_TABLE_NAME & " (SecurityData) values (0)"
    
    conScheme.Connect = gsDB_CONN_STRING
    conScheme.EstablishConnection

    conScheme.Execute (sSQL)
    
    sSQL = "select * from " & gsSCHEME_SYSTEM_TABLE_NAME
    
    ' kludge to get back maximum
    Set mrsScheme = conScheme.OpenResultset(sSQL)
    Do While Not mrsScheme.EOF
        iSchemeID = mrsScheme("SchemeID")
        mrsScheme.MoveNext
    Loop
        
    CreateNewSchemeAccess = iSchemeID
    
    sSQL = "insert into " & gsSCHEME_TABLE_NAME & "(" & "SchemeID," & Left(sInto, Len(sInto) - 1) & ") values (" & iSchemeID & "," & Left(sValues, Len(sValues) - 1) & ")"
    
    conScheme.Execute (sSQL)

    'release the connection
    mrsScheme.Close
    conScheme.Close
    Set mrsScheme = Nothing
    Set conScheme = Nothing

    ' now that the scheme is in the database, add it to the collection
    ' only do if the database addition is correct
    Set oScheme = New Scheme
    oScheme.InitialiseSchemeData (iSchemeID)
    
    gcSchemes.Add oScheme, CStr(oScheme.SchemeID)
    
End Function

Public Function UpdateBasicSchemeData(oUser As User)
    ' ouser holds the request data
    
    ' get the current scheme
    Dim oScheme As Scheme
    Dim oDataItem As DataItem
    
    Set oScheme = gcSchemes(CStr(oUser.CurrentSchemeID))
    
    ' set the data in the scheme based on the inputs
    ' can do validation and checking here

    For Each oDataItem In oScheme.SchemeBaseDataItems()
        oDataItem.ItemValue = oUser.Request(CStr(oDataItem.ItemCode))
    Next
    
    ' TO DO do the update to the db and timestamp the stuff
    ' TO DO update the main list in the main screen drop down
    
End Function

Public Function UpdateSiteSchemeData(oUser As User)
    ' ouser holds the request data
    
    ' get the current scheme
    Dim oScheme As Scheme
    Dim oDataItem As DataItem
    Dim sSQL As String
    
    Set oScheme = gcSchemes(CStr(oUser.CurrentSchemeID))
    
    ' set the data in the scheme based on the inputs
    ' can do validation and checking here

    For Each oDataItem In oScheme.SchemeSiteDataItems()
        oDataItem.ItemValue = oUser.Request(CStr(oDataItem.ItemCode))
    Next
    
    ' TO DO do the update to the db and timestamp the stuff
    
    If oScheme.SchemeSiteDataItems.DBMode = Append Then
        conScheme.Connect = gsDB_CONN_STRING
        conScheme.CursorDriver = rdUseOdbc
        conScheme.EstablishConnection rdDriverNoPrompt
    
        Set rQuery.ActiveConnection = conScheme
    
        rQuery.SQL = "exec SchemeSystemData_Add"
    
        Set mrsScheme = rQuery.OpenResultset(rdOpenForwardOnly, rdConcurReadOnly)
    
        iSchemeID = mrsScheme(0)
    
        mrsScheme.Close
    Set mrsScheme = Nothing
    rQuery.Close
    Set rQuery = Nothing
    Else
    End If
    
    sSQL = MakeUpdate(oScheme.SchemeSiteDataItems, oUser.CurrentSchemeID)
   
    
    ' TO DO update the main list in the main screen drop down
    
End Function

Public Function UpdateCostSchemeData(oUser As User)
    ' ouser holds the request data
    
    ' get the current scheme
    Dim oScheme As Scheme
    Dim oDataItem As DataItem
    
    Set oScheme = gcSchemes(CStr(oUser.CurrentSchemeID))
    
    ' set the data in the scheme based on the inputs
    ' can do validation and checking here

    For Each oDataItem In oScheme.SchemeCosts(1)
        oDataItem.ItemValue = oUser.Request(CStr(oDataItem.ItemCode))
    Next
    
    ' TO DO do the update to the db and timestamp the stuff
    ' TO DO update the main list in the main screen drop down
    
End Function

Public Function UpdateEstCostSchemeData(oUser As User)
    ' ouser holds the request data
    
    ' get the current scheme
    Dim oScheme As Scheme
    Dim oDataItem As DataItem
    
    Set oScheme = gcSchemes(CStr(oUser.CurrentSchemeID))
    
    ' set the data in the scheme based on the inputs
    ' can do validation and checking here

    For Each oDataItem In oScheme.SchemeCosts(0)
        oDataItem.ItemValue = oUser.Request(CStr(oDataItem.ItemCode))
    Next
    
    ' TO DO do the update to the db and timestamp the stuff
    ' TO DO update the main list in the main screen drop down
    
End Function

Function MakeUpdate(cList As DataItems, iSchemeID As String) As String
    Dim oDataItem As DataItem
    Dim sQuote As String
    Dim sInto As String
    Dim sValues As String
    Dim sSet As String
    
    For Each oDataItem In cList
        sInto = oDataItem.ItemDBField
        
        If oDataItem.ItemDBFieldType = Text Then
            sQuote = "'"
        Else
            sQuote = ""
        End If
        
        sValues = sQuote & CStr(vValue) & sQuote & ","
        sSet = sSet & sInto & "=" & sValues
    Next
    
    ' warning this assumes that all fields are in the same table
        
    MakeUpdate = "update " & oDataItem.ItemDBTableName & " set " & Left(sSet, Len(sSet) - 1) & " where schemeID=" & iSchemeID
       
End Function

