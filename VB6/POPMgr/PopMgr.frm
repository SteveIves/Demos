VERSION 5.00
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "MSWINSCK.OCX"
Object = "{6B7E6392-850A-101B-AFC0-4210102A8DA7}#1.3#0"; "COMCTL32.OCX"
Begin VB.Form frmPopMgr 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "POP Manager"
   ClientHeight    =   6720
   ClientLeft      =   780
   ClientTop       =   2520
   ClientWidth     =   9330
   Icon            =   "PopMgr.frx":0000
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   ScaleHeight     =   6720
   ScaleWidth      =   9330
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame fraHolder 
      BorderStyle     =   0  'None
      Height          =   3375
      Index           =   2
      Left            =   240
      TabIndex        =   13
      Top             =   3120
      Width           =   8775
      Begin VB.Frame fraTab 
         Height          =   2895
         Index           =   0
         Left            =   1680
         TabIndex        =   22
         Top             =   0
         Width           =   5175
         Begin VB.CommandButton cmdSave 
            Caption         =   "Sa&ve"
            Enabled         =   0   'False
            Height          =   495
            Left            =   3240
            TabIndex        =   21
            ToolTipText     =   "Connects and fetches headers"
            Top             =   2280
            Width           =   1215
         End
         Begin VB.CheckBox chkPersistPW 
            Caption         =   "Remember Password?"
            Height          =   375
            Left            =   240
            TabIndex        =   20
            ToolTipText     =   "If checked, you won't have to re-enter password"
            Top             =   2400
            Width           =   2175
         End
         Begin VB.TextBox txtPassword 
            Height          =   375
            IMEMode         =   3  'DISABLE
            Left            =   1080
            TabIndex        =   19
            ToolTipText     =   "Your email account password"
            Top             =   1800
            Width           =   3975
         End
         Begin VB.TextBox txtUser 
            Height          =   375
            Left            =   1080
            TabIndex        =   17
            ToolTipText     =   "Your email account name"
            Top             =   1080
            Width           =   3975
         End
         Begin VB.TextBox txtServer 
            Height          =   375
            Left            =   1080
            TabIndex        =   15
            ToolTipText     =   "Address of your POP server"
            Top             =   360
            Width           =   3975
         End
         Begin VB.Label lblPW 
            AutoSize        =   -1  'True
            Caption         =   "&Password: "
            Height          =   195
            Left            =   120
            TabIndex        =   18
            Top             =   1920
            Width           =   780
         End
         Begin VB.Label lblID 
            AutoSize        =   -1  'True
            Caption         =   "User &ID: "
            Height          =   195
            Left            =   120
            TabIndex        =   16
            Top             =   1260
            Width           =   630
         End
         Begin VB.Label lblServer 
            AutoSize        =   -1  'True
            Caption         =   "&Server: "
            Height          =   195
            Left            =   120
            TabIndex        =   14
            Top             =   480
            Width           =   555
         End
      End
   End
   Begin VB.Frame fraHolder 
      BorderStyle     =   0  'None
      Height          =   3375
      Index           =   1
      Left            =   240
      TabIndex        =   10
      Top             =   3120
      Width           =   8775
      Begin VB.TextBox txtStatus 
         Height          =   3375
         Left            =   0
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         ScrollBars      =   3  'Both
         TabIndex        =   12
         ToolTipText     =   "Server status messages"
         Top             =   0
         Width           =   8775
      End
   End
   Begin VB.Frame fraHolder 
      BorderStyle     =   0  'None
      Height          =   3375
      Index           =   0
      Left            =   240
      TabIndex        =   9
      Top             =   3120
      Width           =   8775
      Begin VB.TextBox txtOutput 
         Height          =   3375
         Left            =   0
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         ScrollBars      =   3  'Both
         TabIndex        =   11
         ToolTipText     =   "Message body text"
         Top             =   0
         Width           =   8775
      End
   End
   Begin VB.TextBox txtBytes 
      Height          =   495
      Left            =   7680
      Locked          =   -1  'True
      TabIndex        =   7
      ToolTipText     =   "Number of bytes"
      Top             =   2040
      Width           =   1575
   End
   Begin VB.TextBox txtFrom 
      Height          =   495
      Left            =   1440
      Locked          =   -1  'True
      TabIndex        =   6
      ToolTipText     =   "Name of sender"
      Top             =   2040
      Width           =   3255
   End
   Begin VB.TextBox txtDate 
      Height          =   495
      Left            =   4800
      Locked          =   -1  'True
      TabIndex        =   5
      ToolTipText     =   "Date sent"
      Top             =   2040
      Width           =   2775
   End
   Begin VB.ListBox lstHeaders 
      Height          =   1815
      Left            =   1440
      TabIndex        =   4
      ToolTipText     =   "List of subjects -- double-click to retrieve body"
      Top             =   0
      Width           =   7815
   End
   Begin VB.CommandButton cmdReset 
      Caption         =   "Reset"
      Enabled         =   0   'False
      Height          =   495
      Left            =   120
      TabIndex        =   3
      ToolTipText     =   "Resets (cancels) deletions"
      Top             =   1395
      Width           =   1215
   End
   Begin VB.CommandButton cmdDelete 
      Caption         =   "Delete"
      Enabled         =   0   'False
      Height          =   495
      Left            =   120
      TabIndex        =   2
      ToolTipText     =   "Deletes selected message"
      Top             =   765
      Width           =   1215
   End
   Begin VB.CommandButton cmdDisconnect 
      Caption         =   "Disconnect"
      Enabled         =   0   'False
      Height          =   495
      Left            =   120
      TabIndex        =   1
      ToolTipText     =   "Disconnects from server, commits all deletions"
      Top             =   2040
      Width           =   1215
   End
   Begin VB.CommandButton cmdConnect 
      Caption         =   "Connect"
      Default         =   -1  'True
      Height          =   495
      Left            =   120
      TabIndex        =   0
      ToolTipText     =   "Connects and fetches headers"
      Top             =   120
      Width           =   1215
   End
   Begin MSWinsockLib.Winsock Socket 
      Left            =   120
      Top             =   2520
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   393216
   End
   Begin ComctlLib.TabStrip tabOutput 
      Height          =   3975
      Left            =   120
      TabIndex        =   8
      Top             =   2640
      Width           =   9135
      _ExtentX        =   16113
      _ExtentY        =   7011
      _Version        =   327682
      BeginProperty Tabs {0713E432-850A-101B-AFC0-4210102A8DA7} 
         NumTabs         =   3
         BeginProperty Tab1 {0713F341-850A-101B-AFC0-4210102A8DA7} 
            Caption         =   "Text"
            Key             =   ""
            Object.Tag             =   ""
            Object.ToolTipText     =   "Message text"
            ImageVarType    =   2
         EndProperty
         BeginProperty Tab2 {0713F341-850A-101B-AFC0-4210102A8DA7} 
            Caption         =   "Status"
            Key             =   ""
            Object.Tag             =   ""
            Object.ToolTipText     =   "Server status"
            ImageVarType    =   2
         EndProperty
         BeginProperty Tab3 {0713F341-850A-101B-AFC0-4210102A8DA7} 
            Caption         =   "Settings"
            Key             =   ""
            Object.Tag             =   ""
            Object.ToolTipText     =   "User and server configuration"
            ImageVarType    =   2
         EndProperty
      EndProperty
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
End
Attribute VB_Name = "frmPopMgr"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private SessionClosed As Boolean
Private SettingsChanged As Boolean
Private MailItem() As tMailItem
Private FatalError As Boolean

'Variables and constant for testing data returned from server
Private OutText As String
Private ResponseState As String
Private ThisChunk As String
Private WholeThing As String
Private DotLine As String
Const EOM As String = vbCrLf & "." & vbCrLf

'Mode constants for WaitFor
Const STATUS = 1
Const DOT = 2
Const CLOSED = 4

Private Sub Form_Initialize()

    GetINI

End Sub

Private Sub Form_Load()

    fraHolder(0).ZOrder
    tabOutput.Tabs(2).Selected = True
    
End Sub

Private Sub Form_Unload(Cancel As Integer)

    If cmdDisconnect.Enabled Then
        cmdDisconnect_Click
    End If
    
End Sub

Private Sub cmdConnect_Click()

'Initialize
    lstHeaders.Clear
    txtOutput = ""
    txtStatus = ""
    txtFrom = ""
    txtDate = ""
    txtBytes = ""
    ReDim MailItem(0)
    FatalError = False
    
    cmdSave.Enabled = False
    
    SessionClosed = False
    
    If (Not GetID()) Then
        Exit Sub
    End If
    
    If (SettingsChanged) Then
        GetINI
    End If
    
    'Connect and log in
    If (Not InitiateSession()) Then
        Exit Sub
    End If
    
    'Retrieve message headers
    If (Not GetHeaders()) Then
        Exit Sub
    End If
    
    lstHeaders.Enabled = True
    
End Sub

Private Sub cmdDisconnect_Click()

    Send "QUIT"

    WaitFor CLOSED, OutText
    If OutText <> "+OK" Then
        If MsgBox("Attempt to close connection anyway?", vbYesNo + vbExclamation, "QUIT failure!") = vbNo Then
            Exit Sub
        End If
    End If
    
    Socket.Close
    WaitFor STATUS, OutText
    cmdDisconnect.Enabled = False
    cmdConnect.Enabled = True
    cmdDelete.Enabled = False
    cmdReset.Enabled = False
    lstHeaders.Enabled = False

End Sub

Private Sub cmdDelete_Click()
    
    Send "DELE " & (lstHeaders.ListIndex + 1)

    WaitFor STATUS, OutText
    If OutText <> "+OK" Then
        cmdDisconnect_Click
        txtStatus = txtStatus & "***POPManager: DELE failure!"
        Exit Sub
    End If

    cmdDelete.Enabled = False
    cmdReset.Enabled = True
    
    MailItem(lstHeaders.ListIndex + 1).Deleted = True

End Sub

Private Sub cmdReset_Click()

    Send "RSET"
    
    WaitFor STATUS, OutText
    If OutText <> "+OK" Then
        cmdDisconnect_Click
        txtStatus = txtStatus & "POPManager: RSET failure!"
        Exit Sub
    End If
    
    For c = 1 To UBound(MailItem)
        MailItem(c).Deleted = False
    Next
    
    cmdDelete.Enabled = True
    cmdReset.Enabled = False
    
End Sub

Private Sub cmdSave_Click()

    cmdSave.Enabled = False
    PutINI
    
End Sub

Private Sub lstHeaders_Click()

    If MailItem(lstHeaders.ListIndex + 1).Deleted Then
        cmdDelete.Enabled = False
    Else
        cmdDelete.Enabled = True
    End If
    
    txtFrom = MailItem(lstHeaders.ListIndex + 1).From
    txtDate = MailItem(lstHeaders.ListIndex + 1).DateSent
    txtBytes = MailItem(lstHeaders.ListIndex + 1).Bytes
    If MailItem(lstHeaders.ListIndex + 1).Loaded Then
        GetBody lstHeaders.ListIndex + 1
    Else
        txtOutput = ""
    End If

End Sub

Private Sub lstHeaders_DblClick()

    GetBody lstHeaders.ListIndex + 1
    
End Sub

Private Sub tabOutput_Click()

    fraHolder(tabOutput.SelectedItem.Index - 1).ZOrder
    
    If tabOutput.SelectedItem.Index = 3 Then
        txtServer.SetFocus  'Start with first field
        If txtPassword = "" Then  'or first empty
            txtPassword.SetFocus
        End If
        If txtUser = "" Then
            txtUser.SetFocus
        End If
        If txtServer = "" Then
            txtServer.SetFocus
        End If
    End If

End Sub

Private Sub chkPersistPW_Click()
        
    SettingsChanged = True
    cmdSave.Enabled = True
    
End Sub

Private Sub Socket_Close()
    
    SessionClosed = True
    
End Sub

Private Sub Socket_DataArrival(ByVal bytesTotal As Long)

    Dim strData As String
    Socket.GetData strData, vbString
    WholeThing = WholeThing + strData
    ThisChunk = strData                 'For testing content
    ResponseState = Left$(WholeThing, 3)   'For +OK and +ER tests
    DotLine = Right$(WholeThing, 5)        'For EOM tests

End Sub

Private Sub Socket_Error(ByVal Number As Integer, Description As String, ByVal Scode As Long, ByVal Source As String, ByVal HelpFile As String, ByVal HelpContext As Long, CancelDisplay As Boolean)

    txtStatus = txtStatus & "***POPManager: TCP/IP Error " & Number & ": " & Description
    FatalError = True
   
End Sub

Private Sub Send(TextOut As String)

    ClearTests
    
    Socket.SendData TextOut & vbCrLf
    
End Sub

Private Sub ClearTests()
    
    ResponseState = ""
    ThisChunk = ""
    WholeThing = ""
    DotLine = ""

End Sub

Private Sub WaitFor(Mode As Byte, TestFor As String)

    Do
        Select Case Mode
            Case STATUS
                If ResponseState = "+OK" Or ResponseState = "-ER" Then
                    txtStatus.Text = txtStatus.Text & ThisChunk 'show status
                    TestFor = ResponseState
                    Exit Do
                End If
            Case DOT
                If ResponseState = "-ER" Then  'if got here by mistake
                    txtStatus.Text = txtStatus.Text & ThisChunk 'show status
                    TestFor = ResponseState
                    Exit Do
                End If
                If DotLine = EOM Then
                    Exit Do
                End If
            Case CLOSED
                If SessionClosed Then
                    TestFor = "+OK"
                    Exit Do
                End If
        End Select
        If FatalError Then
            Socket.Close
            cmdConnect.Enabled = True
            Exit Sub
        End If
        DoEvents
    Loop

End Sub

Private Function GetID()

    GetID = True
    GetINI
    
    While modPOPMgr.InfoOk = False
        tabOutput.Tabs.Item(3).Selected = True
        tabOutput_Click
        If modPOPMgr.InfoOk = False Then
            GetID = False
            Exit Function
        End If
    Wend

End Function

Private Function InitiateSession() As Boolean

    InitiateSession = True

    cmdConnect.Enabled = False
    
    ClearTests
    
    'Connect to the server system
    On Error Resume Next
    Socket.Connect modPOPMgr.POPServer, 110
    If Err Then
        FatalError = True
        Err = 0
        Exit Function
    End If
    
    On Error GoTo 0
    WaitFor STATUS, OutText
    
    If FatalError Then
        InitiateSession = False
        Exit Function
    End If
    
    'Check if we got connected
    If OutText = "+OK" Then
        'Send username
        Send "USER " & modPOPMgr.ID
    Else
        txtStatus = txtStatus + "POPManager: Connect failure!"
        cmdDisconnect_Click
        InitiateSession = False
        Exit Function
    End If

    WaitFor STATUS, OutText
    
    'Check if username was accepted
    If OutText = "+OK" Then
        'Send password
        Send "PASS " & modPOPMgr.PW
    Else
        txtStatus = txtStatus + "POPManager: Username rejected!"
        InitiateSession = False
        cmdDisconnect_Click
        Exit Function
    End If

    WaitFor STATUS, OutText
    
    'Check if password was accepted
    If OutText = "+OK" Then
        'We're connected and logged in
        cmdDisconnect.Enabled = True
    Else
        InitiateSession = False
        cmdDisconnect_Click
        txtStatus = txtStatus & "POPManager: Login failure!"
        Exit Function
    End If
    
End Function

Private Function GetHeaders() As Boolean

    Dim Messages As Long
    Dim Start As Long
    Dim Finish As Long

    GetHeaders = True

    'Get number of messages on server

    Send "STAT"

    WaitFor STATUS, OutText
    If OutText <> "+OK" Then
        GetHeaders = False
        cmdDisconnect_Click
        MsgBox "STAT failure!"
        Exit Function
    End If

    'Parse returned string
    Start = InStr(WholeThing, " ") + 1
    Finish = InStr(Start, WholeThing, " ")
    Messages = Val(Mid$(WholeThing, Start, Finish - Start))
    
    If Messages = 0 Then    'bail out if none
        GetHeaders = False
        cmdDisconnect_Click         'disconnect
        Exit Function
    End If
    
    'Get size and headers for each message
    Dim c As Long   'Message counter
    
    For c = 1 To Messages
        ReDim Preserve MailItem(c)
        'Get info for a message
        Send "TOP " & c & " 1"
    
        WaitFor DOT, OutText

        'Parse out headers
        Start = InStr(UCase$(WholeThing), "+OK ") + 4
        Finish = InStr(Start, WholeThing, " ")
        MailItem(c).Bytes = Val(Mid$(WholeThing, Start, Finish - Start))

        Start = InStr(LCase$(WholeThing), "from:") + 5
        Finish = InStr(Start, WholeThing, vbCrLf)
        MailItem(c).From = Mid$(WholeThing, Start, Finish - Start)
        
        Start = InStr(LCase$(WholeThing), "subject:") + 8
        Finish = InStr(Start, WholeThing, vbCrLf)
        MailItem(c).Subject = Mid$(WholeThing, Start, Finish - Start)

        Start = InStr(LCase$(WholeThing), "date:") + 5
        Finish = InStr(Start, WholeThing, vbCrLf)
        MailItem(c).DateSent = Mid$(WholeThing, Start, Finish - Start)
        
        lstHeaders.AddItem MailItem(c).Subject
    Next

    lstHeaders.ListIndex = 0

End Function

Private Sub GetBody(BodyNum As Long)

'Get message body if needed

    If MailItem(BodyNum).Loaded Then
        txtOutput = MailItem(BodyNum).Body
    Else
        Send "RETR " & BodyNum
        WaitFor DOT, OutText
        MailItem(BodyNum).Body = WholeThing
        txtOutput = MailItem(BodyNum).Body
        MailItem(BodyNum).Loaded = True
    End If

End Sub

Sub PutINI()

    modPOPMgr.POPServer = Trim$(txtServer)
    modPOPMgr.ID = Trim$(txtUser)
    modPOPMgr.PW = txtPassword    'don't trim PW
    modPOPMgr.PersistPW = chkPersistPW

    SaveSetting "POPMgr", "User", "ID", modPOPMgr.ID
    SaveSetting "POPMgr", "User", "PersistPW", modPOPMgr.PersistPW
    If modPOPMgr.PersistPW Then
        SaveSetting "POPMgr", "User", "PW", modPOPMgr.PW
    Else
'        SaveSetting "POPMgr", "User", "PW", ""  'Flush it
'        modPOPMgr.PW = ""
'        txtPassword = ""
    End If
    SaveSetting "POPMgr", "Server", "Address", modPOPMgr.POPServer
    SettingsChanged = False

End Sub

Sub GetINI()

    modPOPMgr.ID = GetSetting("POPMgr", "User", "ID", "")
    modPOPMgr.PersistPW = Val(GetSetting("POPMgr", "User", "PersistPW", "0"))
    If modPOPMgr.PersistPW Then
        modPOPMgr.PW = GetSetting("POPMgr", "User", "PW", "")
    Else
        modPOPMgr.PW = txtPassword
    End If
    modPOPMgr.POPServer = GetSetting("POPMgr", "Server", "Address", "")
    
    If modPOPMgr.ID > "" And modPOPMgr.PW > "" And modPOPMgr.POPServer > "" Then
        modPOPMgr.InfoOk = True
    Else
        modPOPMgr.InfoOk = False
    End If
    
    txtServer = modPOPMgr.POPServer
    txtUser = modPOPMgr.ID
    txtPassword = modPOPMgr.PW
    chkPersistPW = modPOPMgr.PersistPW
    cmdSave.Enabled = False  'to counter checkbox click event

End Sub

Private Sub txtUser_Change()
    
    SettingsChanged = True
    cmdSave.Enabled = True

End Sub

Private Sub txtPassword_Change()
    
    SettingsChanged = True
    cmdSave.Enabled = True

End Sub

Private Sub txtServer_Change()
    
    SettingsChanged = True
    cmdSave.Enabled = True

End Sub

