VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "CreateSchemeScreen"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'-------------------------------------------------------------------------
' This class provides a screen for creating a scheme -
' will need to check permission etc
'  TO DO implement copied from to create a scheme
'-------------------------------------------------------------------------

Option Explicit
Option Base 0

'set this to 0 to disable debug code in this class
#Const DebugMode = 1
#If DebugMode Then
    'local variable to hold the serialized class ID that was created in Class_Initialize
    Private mlClassDebugID As Long
#End If

Private msScreenID As String 'screen ID
Private mcScreenDataFields As New Collection  ' hold the data fields for display

Public Property Let ScreenID(ByVal vData As String)
    On Error GoTo ScreenIDLetErr

    msScreenID = vData
    Exit Property

ScreenIDLetErr:
    Call RaiseError(MyUnhandledError, "MainScreen:ScreenID Property Let")
End Property

Public Property Get ScreenID() As String
    On Error GoTo ScreenIDGetErr

    ScreenID = msScreenID
    Exit Property

ScreenIDGetErr:
    Call RaiseError(MyUnhandledError, "MainScreen:ScreenID Property Get")
End Property

Private Sub Class_Initialize()

    Dim conTemplate As New rdoConnection
    Dim rsTemplate As rdoResultset
    Dim oDataItem As DataItem
    
    #If DebugMode Then
        'get the next available class ID, and print out
        'that the class was created successfully
        mlClassDebugID = GetNextClassDebugID()
        Debug.Print "'" & TypeName(Me) & "' instance " & mlClassDebugID & " created"
    #End If
    
    msScreenID = gsCREATE_SCHEME_SCREEN_ID  ' sets this as the screen id
    
    ' Set up array template in global data
    ' 0 is Display Text, 1=DataType (0=text, 1=dropdown, 2= radio, 3=multiline 4=special)
    '     2= Source ( field name or width or row, column or special code)
    '     3= Insert field 4=uniqueID 5=database type (text, number)
    ' need to set something to ensure another person doesn't try to initialise while
    ' this is being done? TODO set flag in global data
    
    ' load up collection of data fields from database
    
    conTemplate.Connect = gsDB_CONN_STRING
    conTemplate.EstablishConnection
    Set rsTemplate = conTemplate.OpenResultset("select * from CreateSchemeTemplate")
    
    Do While Not rsTemplate.EOF
        Set oDataItem = New DataItem
        Call oDataItem.InitialiseField(rsTemplate(0), rsTemplate(1), rsTemplate(2), _
                             rsTemplate(3), rsTemplate(4), rsTemplate(5), rsTemplate(6), _
                             rsTemplate(7), rsTemplate(8), rsTemplate(9))
        mcScreenDataFields.Add oDataItem, CStr(oDataItem.ItemCode)
        Set oDataItem = Nothing
        rsTemplate.MoveNext
    Loop
    Set conTemplate = Nothing
    
End Sub

Private Sub Class_Terminate()
    'the class is being destroyed
    #If DebugMode Then
        Debug.Print "'" & TypeName(Me) & "' instance " & CStr(mlClassDebugID) & " is terminating"
    #End If
End Sub

#If DebugMode Then
    Public Property Get ClassDebugID()
        'if we are in debug mode, surface this property that consumers can query
        ClassDebugID = mlClassDebugID
    End Property
#End If

Public Function Display(oUser As User) As String
    On Error GoTo DisplayErr
    
    ' Passing the user to control display

    Dim iLoop As Integer
    Dim Output As String
    Dim oDataItem As DataItem
    
Output = "<html>" & vbCrLf & _
"<head>" & vbCrLf & _
"<meta http-equiv=""Content-Type""" & vbCrLf & _
"content=""text/html; charset=iso-8859-1"">" & vbCrLf & _
"<meta name=""GENERATOR"" content=""Microsoft FrontPage 2.0"">" & vbCrLf & _
"<title>Home Housing Development Tracking System - Create Scheme Screen</title>" & vbCrLf & _
"</head>" & vbCrLf & _
"<body bgcolor=""#FFFFFF"">" & vbCrLf & _
"<form action=""dev.asp"" method=""get"" name=""logon"">" & vbCrLf & _
"<input type=""hidden"" name=""pagekey"" value=""" & msScreenID & """>" & vbCrLf & _
"<input type=""hidden"" name=""userid"" value=""" & oUser.UserID & """>" & vbCrLf & _
"<table width=""100%""><tr>" & _
"<td width=""50%""><font color=""#000080"" size=""3"" face=""Arial Black"">User:" & vbCrLf & _
oUser.RealName & "</font></td>" & vbCrLf & _
    "<td><input type=""submit"" name=""" & gsGOTO_MAIN_SCREEN & """ value=""Main screen"">" & vbCrLf & _
"</td></tr></table></form>" & vbCrLf & _
"<p><p>" & vbCrLf & _
"</form>"
    
Output = Output & _
"<form action=""dev.asp"" method=""post"" name=""data"">" & vbCrLf & _
"<input type=""hidden"" name=""pagekey"" value=""" & msScreenID & """>" & vbCrLf & _
"<input type=""hidden"" name=""userid"" value=""" & oUser.UserID & """>" & vbCrLf & _
"<center><table>"

    For Each oDataItem In mcScreenDataFields
        
        Output = Output & "<tr><td align=right><b>" & oDataItem.DisplayTitle(oUser) & "</b></td>"
        Output = Output & "<td>" & oDataItem.DisplayData(oUser) & "</td>" & vbCrLf
    
    Next

Output = Output & "<tr><td align=right><input type=""submit"" name=""" & gsATTEMPT_CREATE & """ value=""Create scheme""></td>" & vbCrLf & _
    "<td><input type=""reset"" value=""Clear details""></td></tr>" & vbCrLf & _
    "</table></body></html>"

    Call oUser.Response.Write(Output)

    Exit Function

DisplayErr:
    Call RaiseError(MyUnhandledError, "CreateSchemeScreen:Display Method")
End Function

Public Function GetNextPageID(oUser As User, iPage As String) As String
    ' On Error GoTo GetNextPageIDErr
    
    'logic to decide what the next page will be based on
    'last page and potentially data input
        
    ' look at the array of data passed
    ' if the GOTOMAINSCREEN value is present, then that has been selected
    
    Dim sInto As String
    Dim sValues As String
    Dim sQuote As String
    Dim vKey As Variant
    Dim vValue As Variant
    Dim sSet As String
    Dim oDataItem As DataItem

    GetNextPageID = gsCREATE_SCHEME_SCREEN_ID ' default to self
    
    ' if pressed the button, back to main screen
    If oUser.Request(gsGOTO_MAIN_SCREEN) <> "" Then
        GetNextPageID = gsMAIN_SCREEN_ID
    End If
    
    ' if doing an update put all data in, create scheme object and goto edit screen

    If oUser.Request(gsATTEMPT_CREATE) <> "" Then
        ' do update
        ' ask the global area to create a new scheme - that should serialize the
        ' calls? Pass the user object to tell who wants the scheme - which also
        ' includes the input data
        
        ' validate all the data returned here if needbe
        ' at the moment we just create the sql for inserting
        ' this may be changed to use a stored proceedure
        
        ' start off with the scheme id

        sInto = ""
        sSet = ""
        sValues = ""
        sQuote = ""
    
        For Each vKey In oUser.Request.Form
            ' only number fields are data types
            If IsNumeric(vKey) Then
                vValue = oUser.Request(vKey)
                Set oDataItem = mcScreenDataFields(CStr(vKey))
        
                sInto = oDataItem.ItemDBField
        
                If oDataItem.ItemDBFieldType = Text Then
                    sQuote = "'"
                Else
                    sQuote = ""
                End If
        
                sValues = sQuote & CStr(vValue) & sQuote & ","
                sSet = sSet & sInto & "=" & sValues
            
            End If
       Next
                
        oUser.CurrentSchemeID = CreateNewScheme(sSet)
        ' check error collection for raised error
        
        GetNextPageID = gsEDIT_BASIC_SCHEME_SCREEN_ID ' go to basic edit screen
    End If

    Exit Function

GetNextPageIDErr:
    Call RaiseError(MyUnhandledError, "CreateSchemeScreen:GetNextPageID Method")
End Function


