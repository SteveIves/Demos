VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "MainScreen"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Description = "This class provides the work to show the main choice screen"
Attribute VB_Ext_KEY = "SavedWithClassBuilder" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
  '-------------------------------------------------------------------------
' This class provides a main screen -
' will need to check permission etc
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

Public Property Let ScreenID(ByVal vData As String)
Attribute ScreenID.VB_Description = "Cross references the screen name with an ID"
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
    #If DebugMode Then
        'get the next available class ID, and print out
        'that the class was created successfully
        mlClassDebugID = GetNextClassDebugID()
        Debug.Print "'" & TypeName(Me) & "' instance " & mlClassDebugID & " created"
    #End If
    
    msScreenID = gsMAIN_SCREEN_ID  ' sets this as the screen id
    
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
    ' Passing the user to control display
    ' Display = "Main Screen for real name " & oUser.RealName
    
    Dim sNewScheme As String
    Dim Output As String
    Dim sEditScheme As String
    
    sNewScheme = "<a href=""dev.asp?userid=" & oUser.UserID & "&pagekey=" & msScreenID & "&" & _
            gsGOTO_CREATE_SCHEME_SCREEN & "=on"" >CREATE NEW SCHEME</a>"

    sEditScheme = "<a href=""dev.asp?userid=" & oUser.UserID & "&pagekey=" & msScreenID & "&" & _
            gsGOTO_SELECT_SCREEN & "=on"" >VIEW/EDIT SCHEME DATA</a>"
            
Output = "<html>" & vbCrLf & _
"<head>" & vbCrLf & _
"<meta http-equiv=""Content-Type""" & vbCrLf & _
"content=""text/html; charset=iso-8859-1"">" & vbCrLf & _
"<meta name=""GENERATOR"" content=""Microsoft FrontPage 2.0"">" & vbCrLf & _
"<title>Home Housing Development Tracking System - Main Screen</title>" & vbCrLf & _
"</head>" & vbCrLf & _
"<body bgcolor=""#FFFFFF"">" & vbCrLf & _
"<table width=""100%""><tr>" & _
"<td width=""50%""><font color=""#000080"" size=""3"" face=""Arial Black"">User:" & vbCrLf & _
oUser.RealName & "</font></td>" & vbCrLf & _
    "<td><b>[Main Screen]</b>" & vbCrLf & _
"</td></tr></table></form>" & _
"<p><p>" & _
"</form>"

Output = Output & _
"<blockquote>" & vbCrLf & _
    "<ul>" & vbCrLf & _
        "<li><font size=""2"" face=""Arial""><strong>" & sEditScheme & "</strong></font></li>" & vbCrLf & _
        "<li><font size=""2"" face=""Arial""><strong>" & sNewScheme & " </strong></font></li>" & vbCrLf & _
        "<li><font size=""2"" face=""Arial""><strong>VIEW/EDIT GLOBAL" & vbCrLf & _
            "DATA</strong></font></li>" & vbCrLf & _
        "<li><font size=""2"" face=""Arial""><strong>SEARCH BY" & vbCrLf & _
            "CATEGORY</strong></font></li>" & vbCrLf & _
        "<li><font size=""2"" face=""Arial""><strong>VIEW MIS</strong></font></li>" & vbCrLf & _
        "<li><font size=""2"" face=""Arial""><strong>GENERATE STANDARD" & vbCrLf & _
            "REPORT</strong></font></li>" & vbCrLf & _
        "<li><font size=""2"" face=""Arial""><strong>EDIT SCHEME" & vbCrLf & _
            "TEMPLATES</strong></font></li>" & vbCrLf & _
        "<li><font size=""2"" face=""Arial""><strong>MAINTAIN RESOURCE" & vbCrLf & _
            "LISTS</strong></font></li>" & vbCrLf & _
        "<li><font size=""2"" face=""Arial""><strong>MAINTAIN USERS</strong></font></li>" & vbCrLf & _
        "<li><font size=""2"" face=""Arial""><strong>SYSTEM" & vbCrLf & _
            "MAINTENANCE</strong></font></li>" & vbCrLf & _
    "</ul>" & vbCrLf & _
"</blockquote>" & vbCrLf & _
"</body>" & vbCrLf & _
"</html>"

Call oUser.Response.Write(Output)

End Function

Public Function GetNextPageID(oUser As User, iPage As String) As String
    'logic to decide what the next page will be based on
    'last page and potentially data input
    
    ' look at the array of data passed
    ' if the GOTOMAINSCREEN value is present, then that has been selected

    
    GetNextPageID = gsMAIN_SCREEN_ID
    
    If oUser.Request(gsGOTO_CREATE_SCHEME_SCREEN) = "on" Then
        GetNextPageID = gsCREATE_SCHEME_SCREEN_ID
    End If
    
    If oUser.Request(gsGOTO_SELECT_SCREEN) = "on" Then
        GetNextPageID = gsSELECT_SCHEME_SCREEN_ID
    End If
    
End Function


