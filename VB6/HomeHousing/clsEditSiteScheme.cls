VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "EditSiteScheme"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'-------------------------------------------------------------------------
' this is the screen that is entered to change site info
'-------------------------------------------------------------------------

Option Explicit
Option Base 0

'set this to 0 to disable debug code in this class
#Const DebugMode = 1
#If DebugMode Then
    'local variable to hold the serialized class ID that was created in Class_Initialize
    Private mlClassDebugID As Long
#End If

Private msScreenID As String

Public Property Let ScreenID(ByVal vData As String)
    On Error GoTo ScreenIDLetErr

    msScreenID = vData
    Exit Property

ScreenIDLetErr:
    Call RaiseError(MyUnhandledError, "EditSchemeBasicsScreen:ScreenID Property Let")
End Property

Public Property Get ScreenID() As String
    On Error GoTo ScreenIDGetErr

    ScreenID = msScreenID
    Exit Property

ScreenIDGetErr:
    Call RaiseError(MyUnhandledError, "EditSchemeBasicsScreen:ScreenID Property Get")
End Property

Public Function Display(oUser As User) As String
'    On Error GoTo DisplayErr

    ' Passing the user to control display

    Dim iLoop As Integer
    Dim Output As String
    Dim oDataItem As DataItem
    
Output = "<html>" & vbCrLf & _
"<head>" & vbCrLf & _
"<meta http-equiv=""Content-Type""" & vbCrLf & _
"content=""text/html; charset=iso-8859-1"">" & vbCrLf & _
"<meta name=""GENERATOR"" content=""Microsoft FrontPage 2.0"">" & vbCrLf & _
"<title>Home Housing Development Tracking System - Edit Site Screen</title>" & vbCrLf & _
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
ButtonBar(msScreenID) & _
"<input type=""hidden"" name=""pagekey"" value=""" & msScreenID & """>" & vbCrLf & _
"<input type=""hidden"" name=""userid"" value=""" & oUser.UserID & """>" & vbCrLf & _
"<center><table>"

    For Each oDataItem In gcSchemes(CStr(oUser.CurrentSchemeID)).SchemeSiteDataItems
            
        Output = Output & "<tr><td align=""right""><b>" & oDataItem.DisplayTitle(oUser) & "</b></td>"
        Output = Output & "<td>" & oDataItem.DisplayData(oUser) & "</td>" & vbCrLf
    
    Next

Output = Output & "<tr><td align=right><input type=""submit"" name=""" & gsATTEMPT_SITE_UPDATE & """ value=""Update values""></td>" & vbCrLf & _
    "<td><input type=""reset"" value=""Reset details""></td></tr>" & vbCrLf & _
    "</table></body></html>"

    Call oUser.Response.Write(Output)

    Exit Function

DisplayErr:
    Call RaiseError(MyUnhandledError, "EditSiteScreen:Display Method")
End Function

Public Function GetNextPageID(oUser As User, iPage As String) As String
    ' On Error GoTo GetNextPageIDErr

    'logic to decide what the next page will be based on
    'last page and potentially data input
        
    ' look at the array of data passed
    ' if the GOTOMAINSCREEN value is present, then that has been selected
    
    Dim oDataItem As DataItem
    Dim sEntry As Variant
    Dim sTest As String
 
    GetNextPageID = gsEDIT_SITE_SCREEN_ID ' default to self
    
    ' if pressed the button, back to main screen
    If oUser.Request(gsGOTO_MAIN_SCREEN) <> "" Then
        GetNextPageID = gsMAIN_SCREEN_ID
    End If
    
    ' if doing an update put all data in, create scheme object and goto edit screen

    If oUser.Request(gsATTEMPT_SITE_UPDATE) <> "" Then
        ' do update
        ' pass through the global area to update a particular part of a
        ' scheme
        
        ' pass the user object (with the input stuff)

        Call UpdateSiteSchemeData(oUser)
        ' check error collection for raised error if failed to
        ' update properly to db
        
        GetNextPageID = gsEDIT_SITE_SCREEN_ID ' go to basic edit screen
    End If
    
    For Each sEntry In oUser.Request.Form
        If Not IsNumeric(sEntry) Then
            Select Case LCase(sEntry)  ' change to lower case
                Case gsGOTO_BASIC_SCHEME_SCREEN
                    GetNextPageID = gsEDIT_BASIC_SCHEME_SCREEN_ID
                Case gsGOTO_SITE_SCREEN
                    GetNextPageID = gsEDIT_SITE_SCREEN_ID
                Case gsGOTO_PROPERTIES_SCREEN
                    GetNextPageID = gsEDIT_PROPERTIES_SCREEN_ID
                Case gsGOTO_CONSULTANT_SCHEME_SCREEN
                    GetNextPageID = gsEDIT_CONSULTANT_SCHEME_SCREEN_ID
                Case gsGOTO_CONTRACTOR_SCHEME_SCREEN
                    GetNextPageID = gsEDIT_CONTRACTOR_SCHEME_SCREEN_ID
                Case gsGOTO_GROUP_COSTS_SCREEN
                    GetNextPageID = gsEDIT_GROUP_COSTS_SCREEN_ID
                Case gsGOTO_FUNDING_SCREEN
                    GetNextPageID = gsEDIT_FUNDING_SCREEN_ID
            End Select
        End If
    Next

    Exit Function

GetNextPageIDErr:
    Call RaiseError(MyUnhandledError, "EditSchemeBasicsScreen:GetNextPageID Method")
End Function

Private Sub Class_Initialize()
    #If DebugMode Then
        'get the next available class ID, and print out
        'that the class was created successfully
        mlClassDebugID = GetNextClassDebugID()
        Debug.Print "'" & TypeName(Me) & "' instance " & mlClassDebugID & " created"
    #End If

    msScreenID = gsEDIT_SITE_SCREEN_ID  ' sets this as the screen id
    
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


