VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "LogonScreen"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'-------------------------------------------------------------------------
' This class is the logon screen
' will be displayed by unknown user only
'-------------------------------------------------------------------------

Option Explicit
Option Base 0

'set this to 0 to disable debug code in this class
#Const DebugMode = 1

#If DebugMode Then
    'local variable to hold the serialized class ID that was created in Class_Initialize
    Private mlClassDebugID As Long
#End If

Private msScreenID As String 'screen ID as a string

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
    #If DebugMode Then
        'get the next available class ID, and print out
        'that the class was created successfully
        mlClassDebugID = GetNextClassDebugID()
        Debug.Print "'" & TypeName(Me) & "' instance " & mlClassDebugID & " created"
    #End If
    
    msScreenID = gsLOGON_SCREEN_ID  ' sets this as the screen id

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

Public Sub Display(oUser As User)
    Dim Output As String
    
    ' Passing the user to control display
    'Display = "Logon Screen for real name " & oUser.RealName & _
     '           vbCrLf & PrintData(oUser.DataArray)
    
Output = "<html>" & vbCrLf & _
"<head>" & vbCrLf & _
"<meta http-equiv=""Content-Type""" & vbCrLf & _
"content=""text/html; charset=iso-8859-1"">" & vbCrLf & _
"<meta name=""GENERATOR"" content=""Microsoft FrontPage 2.0"">" & vbCrLf & _
"<title>Home Housing Development Tracking System - Logon Screen</title>" & vbCrLf & _
"</head>" & vbCrLf & _
"<body bgcolor=""#FFFFFF"">" & vbCrLf & _
"<p><font color=""#000080"" size=""3"" face=""Arial Black"">Home Housing" & vbCrLf & _
"Development Tracking System</font></p>" & vbCrLf & _
"<form action=""dev.asp"" method=""get"" name=""" & msScreenID & """>" & vbCrLf & _
    "<input type=""hidden"" name=""pagekey"" value=""log"">" & vbCrLf & _
    "<div align=""center""><center><table border=""7"">" & vbCrLf & _
        "<tr>" & vbCrLf & _
            "<td><table border=""0"" cellpadding=""3"" cellspacing=""5"">" & vbCrLf & _
                "<tr>" & vbCrLf & _
                    "<td align=""center"" colspan=""2""><font size=""2""><strong>Please" & vbCrLf & _
                    "enter your username and password</strong></font></td>" & vbCrLf & _
                "</tr>" & vbCrLf & _
                "<tr>" & vbCrLf & _
                    "<td align=""right"" width=""50%""" & vbCrLf & _
                    "bordercolor=""#008000"">Username</td>" & vbCrLf & _
                    "<td width=""50%""><input type=""text"" size=""20""" & vbCrLf & _
                    "name=""username""></td>" & vbCrLf & _
                "</tr>" & vbCrLf
                
Output = Output & "<tr>" & vbCrLf & _
                    "<td align=""right"" width=""50%"">Password</td>" & vbCrLf & _
                    "<td width=""50%""><input type=""text"" size=""20""" & vbCrLf & _
                    "name=""password""></td>" & vbCrLf & _
                "</tr>" & vbCrLf & _
                "<tr>" & vbCrLf & _
                    "<td align=""right""><input type=""submit""" & vbCrLf & _
                    "name=""submit"" value=""Submit details""></td>" & vbCrLf & _
                    "<td><input type=""reset"" name=""reset""" & vbCrLf & _
                    "value=""Clear entry""></td>" & vbCrLf & _
                "</tr>" & vbCrLf & _
            "</table>" & vbCrLf & _
            "</td>" & vbCrLf & _
        "</tr>" & vbCrLf & _
    "</table>" & vbCrLf & _
    "</center></div>" & vbCrLf & _
"</form>" & vbCrLf & _
"</body>" & vbCrLf & _
"</html>"

Call oUser.Response.Write(Output)

End Sub

Public Function GetNextPageID(oUser As User, sPage As String) As String
    'logic to decide what the next page will be based on
    'last page and potentially data input
    
    ' if we are here, then the user has got a valid id
    ' display the main screen - potentially the ipage will be something
    ' when the user has timed out - TODO later
    
    GetNextPageID = gsMESSAGE_SCREEN_ID ' send to the message screen first

End Function
