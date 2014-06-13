VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "SelectSchemeScreen"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'-------------------------------------------------------------------------
' This class allow you to select a scheme from the overall list
' must take into account permissions etc
' will include a simple search
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
Private msSchemeListArray() As String  ' simple array of schemes and descriptions


Private Function ShowSchemeList()
    ' creates a dropdown box for selecting a scheme
    Dim iLoop As Integer
    
    ShowSchemeList = "<select name=""" & gsSCHEME_OPTION_LIST & """>"
    For iLoop = 0 To UBound(msSchemeListArray, 2)
        ShowSchemeList = ShowSchemeList & "<option value=""" & msSchemeListArray(0, iLoop) & """>" & msSchemeListArray(1, iLoop) & "</option>"
    Next
    
    ShowSchemeList = ShowSchemeList & "</select>"

End Function

Public Property Let ScreenID(ByVal vData As String)
    On Error GoTo ScreenIDLetErr

    msScreenID = vData
    Exit Property

ScreenIDLetErr:
    Call RaiseError(MyUnhandledError, "MessageScreen:ScreenID Property Let")
End Property

Public Property Get ScreenID() As String
    On Error GoTo ScreenIDGetErr

    ScreenID = msScreenID
    Exit Property


ScreenIDGetErr:
    Call RaiseError(MyUnhandledError, "MessageScreen:ScreenID Property Get")
End Property

Private Sub Class_Initialize()
    
    Dim conScheme As New rdoConnection
    Dim rsScheme As rdoResultset
    Dim iLoop As Integer
        
    #If DebugMode Then
        'get the next available class ID, and print out
        'that the class was created successfully
        mlClassDebugID = GetNextClassDebugID()
        Debug.Print "'" & TypeName(Me) & "' instance " & mlClassDebugID & " created"
    #End If
    
    msScreenID = gsSELECT_SCHEME_SCREEN_ID  ' sets this as the screen id

    ' also set up the list of available schemes
    conScheme.Connect = gsDB_CONN_STRING
    conScheme.CursorDriver = rdUseClientBatch
    conScheme.EstablishConnection

    Set rsScheme = conScheme.OpenResultset("select SchemeID,SchemeDescription from Scheme", rdOpenStatic, rdConcurBatch)
'    Set rsScheme.ActiveConnection = Nothing
    
    If rsScheme.RowCount > 0 Then
    
        ReDim msSchemeListArray(1, rsScheme.RowCount - 1)
    
        iLoop = 0
        Do While Not rsScheme.EOF
            msSchemeListArray(0, iLoop) = rsScheme.rdoColumns.Item(0)
            msSchemeListArray(1, iLoop) = rsScheme.rdoColumns.Item(1)
            rsScheme.MoveNext
            iLoop = iLoop + 1
        Loop
    Else
        ReDim msSchemeListArray(1, 0)
        msSchemeListArray(0, iLoop) = "-1"
        msSchemeListArray(1, iLoop) = "(none)"
    End If
    
    rsScheme.Close
    conScheme.Close
    Set rsScheme = Nothing
    Set conScheme = Nothing
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
    'Display = "Message Screen for real name " & oUser.RealName

    ' note for simple buttons not passing special values just
    ' display own screen
    
    Dim Output As String
    Dim sEditScheme As String
    
    sEditScheme = "<form action=""dev.asp"">Select a scheme to edit - " & ShowSchemeList() & _
                      "<input type=""submit"" name=""" & gsGOTO_BASIC_SCHEME_SCREEN & """ value=""Edit"">" & vbCrLf & _
                      "<input type=""hidden"" name=""pagekey"" value=""" & msScreenID & """>" & vbCrLf & _
                        "<input type=""hidden"" name=""userid"" value=""" & oUser.UserID & """>" & vbCrLf & _
                        "</form>"

    
Output = "<html>" & vbCrLf & _
"<head>" & vbCrLf & _
"<meta http-equiv=""Content-Type""" & vbCrLf & _
"content=""text/html; charset=iso-8859-1"">" & vbCrLf & _
"<meta name=""GENERATOR"" content=""Microsoft FrontPage 2.0"">" & vbCrLf & _
"<title>Home Housing Development Tracking System - Select Scheme Screen</title>" & vbCrLf & _
"</head>" & vbCrLf & _
"<body bgcolor=""#FFFFFF"">" & vbCrLf & _
"<form action=""dev.asp"" method=""get"" name=""logon"">" & vbCrLf & _
"<input type=""hidden"" name=""pagekey"" value=""" & msScreenID & """>" & vbCrLf & _
"<input type=""hidden"" name=""userid"" value=""" & oUser.UserID & """>" & vbCrLf & _
"<table width=""100%""><tr>" & _
"<td width=""50%""><font color=""#000080"" size=""3"" face=""Arial Black"">User:" & vbCrLf & _
oUser.RealName & "</font></td>" & vbCrLf & _
    "<td><input type=""submit"" name=""" & gsGOTO_MAIN_SCREEN & """ value=""Main screen"">" & vbCrLf & _
"</td></tr></table></form>" & vbCrLf

Output = Output & _
"<blockquote>" & vbCrLf & _
    "<ul>" & vbCrLf & _
        "<li><font size=""2"" face=""Arial""><strong>" & sEditScheme & "</strong></font></li>" & vbCrLf & _
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
    
     Dim iScreenId As Integer
     
    ' message screen goes to main screen if you press the button
    
    GetNextPageID = gsSELECT_SCHEME_SCREEN_ID ' redirect to this screen default
    
    If oUser.Request(gsGOTO_MAIN_SCREEN) <> "" Then
        GetNextPageID = gsMAIN_SCREEN_ID
    End If

   If oUser.Request(gsGOTO_BASIC_SCHEME_SCREEN) <> "" Then
        GetNextPageID = gsEDIT_BASIC_SCHEME_SCREEN_ID
        iScreenId = oUser.Request(CStr(gsSCHEME_OPTION_LIST))
        oUser.CurrentSchemeID = iScreenId
        LoadScheme (iScreenId) ' loads the scheme if needed
    End If
End Function



