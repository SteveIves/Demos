VERSION 5.00
Object = "{6B7E6392-850A-101B-AFC0-4210102A8DA7}#1.2#0"; "COMCTL32.OCX"
Begin VB.Form frmMain 
   BackColor       =   &H8000000C&
   Caption         =   "Synergy/DE xfNetLink COM Edition Test Platform"
   ClientHeight    =   4605
   ClientLeft      =   165
   ClientTop       =   735
   ClientWidth     =   6825
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   4605
   ScaleWidth      =   6825
   StartUpPosition =   3  'Windows Default
   Begin ComctlLib.Toolbar Toolbar 
      Align           =   1  'Align Top
      Height          =   420
      Left            =   0
      TabIndex        =   1
      Top             =   0
      Width           =   6825
      _ExtentX        =   12039
      _ExtentY        =   741
      ButtonWidth     =   609
      ButtonHeight    =   582
      AllowCustomize  =   0   'False
      Appearance      =   1
      ImageList       =   "ImageList"
      _Version        =   327682
      BeginProperty Buttons {0713E452-850A-101B-AFC0-4210102A8DA7} 
         NumButtons      =   2
         BeginProperty Button1 {0713F354-850A-101B-AFC0-4210102A8DA7} 
            Key             =   ""
            Object.ToolTipText     =   "Connect to xfServer"
            Object.Tag             =   ""
            ImageIndex      =   1
            Style           =   2
         EndProperty
         BeginProperty Button2 {0713F354-850A-101B-AFC0-4210102A8DA7} 
            Key             =   ""
            Object.ToolTipText     =   "Disconnect from xfServer"
            Object.Tag             =   ""
            ImageIndex      =   2
            Style           =   2
            Value           =   1
         EndProperty
      EndProperty
   End
   Begin ComctlLib.StatusBar StatusBar 
      Align           =   2  'Align Bottom
      Height          =   315
      Left            =   0
      TabIndex        =   0
      Top             =   4290
      Width           =   6825
      _ExtentX        =   12039
      _ExtentY        =   556
      SimpleText      =   ""
      _Version        =   327682
      BeginProperty Panels {0713E89E-850A-101B-AFC0-4210102A8DA7} 
         NumPanels       =   3
         BeginProperty Panel1 {0713E89F-850A-101B-AFC0-4210102A8DA7} 
            Alignment       =   1
            Object.Width           =   3528
            MinWidth        =   3528
            TextSave        =   ""
            Key             =   ""
            Object.Tag             =   ""
            Object.ToolTipText     =   "Indicates if currently connected to xfServerPlus"
         EndProperty
         BeginProperty Panel2 {0713E89F-850A-101B-AFC0-4210102A8DA7} 
            Alignment       =   1
            Object.Width           =   3881
            MinWidth        =   3881
            TextSave        =   ""
            Key             =   ""
            Object.Tag             =   ""
            Object.ToolTipText     =   "xfServerPlus node name"
         EndProperty
         BeginProperty Panel3 {0713E89F-850A-101B-AFC0-4210102A8DA7} 
            Alignment       =   1
            TextSave        =   ""
            Key             =   ""
            Object.Tag             =   ""
            Object.ToolTipText     =   "xfServerPlus port number"
         EndProperty
      EndProperty
   End
   Begin ComctlLib.ImageList ImageList 
      Left            =   720
      Top             =   2160
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   327682
      BeginProperty Images {0713E8C2-850A-101B-AFC0-4210102A8DA7} 
         NumListImages   =   3
         BeginProperty ListImage1 {0713E8C3-850A-101B-AFC0-4210102A8DA7} 
            Picture         =   "frmMain.frx":0442
            Key             =   ""
         EndProperty
         BeginProperty ListImage2 {0713E8C3-850A-101B-AFC0-4210102A8DA7} 
            Picture         =   "frmMain.frx":075C
            Key             =   ""
         EndProperty
         BeginProperty ListImage3 {0713E8C3-850A-101B-AFC0-4210102A8DA7} 
            Picture         =   "frmMain.frx":0A76
            Key             =   ""
         EndProperty
      EndProperty
   End
   Begin VB.Menu FileCol 
      Caption         =   "&File"
      Begin VB.Menu MnuFile 
         Caption         =   "E&xit"
         Index           =   0
      End
   End
   Begin VB.Menu TestCol 
      Caption         =   "&Test"
      Begin VB.Menu MnuTest 
         Caption         =   "&Connect"
         Index           =   0
         Shortcut        =   ^C
      End
      Begin VB.Menu MnuTest 
         Caption         =   "&Disconnect"
         Enabled         =   0   'False
         Index           =   1
         Shortcut        =   ^D
      End
      Begin VB.Menu MnuTest 
         Caption         =   "-"
         Index           =   2
      End
      Begin VB.Menu MnuTest 
         Caption         =   "Run Test &1"
         Enabled         =   0   'False
         Index           =   3
      End
      Begin VB.Menu MnuTest 
         Caption         =   "Run Test &2"
         Enabled         =   0   'False
         Index           =   4
      End
      Begin VB.Menu MnuTest 
         Caption         =   "Run Test &3"
         Enabled         =   0   'False
         Index           =   5
      End
      Begin VB.Menu MnuTest 
         Caption         =   "Run Test &4"
         Enabled         =   0   'False
         Index           =   6
      End
      Begin VB.Menu MnuTest 
         Caption         =   "Run Test &5"
         Enabled         =   0   'False
         Index           =   7
      End
      Begin VB.Menu MnuTest 
         Caption         =   "Run Test &6"
         Enabled         =   0   'False
         Index           =   8
      End
   End
   Begin VB.Menu HelpCol 
      Caption         =   "&Help"
      Begin VB.Menu MnuHelp 
         Caption         =   "&About"
         Index           =   0
      End
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Form_Load()

    CenterOnScreen
    gCancel = False
    SetupDisconnected
    
    Me.Show
    
    'Create an xfProxy object
    On Error GoTo ErrorHandler
    Set xfpl = CreateObject("xfnlCOM.xfProxy")
    
    Exit Sub
    
ErrorHandler:

    Select Case Err.Number
    Case 429
        frmObjectError.Show 1
        End
    End Select
    
    Resume

End Sub

Private Sub MnuFile_Click(Index As Integer)

    Select Case Index
        Case 0  'File/Exit
            Unload Me
    End Select

End Sub

Private Sub MnuTest_Click(Index As Integer)

    Select Case Index
        Case 0  'Test/Login
            Connect
        Case 1  'Test/Logout
            Disconnect
        Case 3
            Test1
        Case 4
            Test2
        Case 5
            Test3
        Case 6
            Test4
        Case 7
            Test5
        Case 8
            Test6
    End Select

End Sub

Private Sub MnuHelp_Click(Index As Integer)

    Select Case Index
    Case 0
        frmAbout.Show 1
    End Select

End Sub

Private Sub SetupConnected()

    gConnected = True

    StatusBar.Panels(1).Text = "Status: Connected."
    StatusBar.Panels(2).Text = "Node: " & gServerName
    StatusBar.Panels(3).Text = "Port: " & CStr(gServerPort)

    MnuTest(0).Enabled = False
    MnuTest(1).Enabled = True
    MnuTest(3).Enabled = True
    MnuTest(4).Enabled = True
    MnuTest(5).Enabled = True
    MnuTest(6).Enabled = True
    MnuTest(7).Enabled = True
    MnuTest(8).Enabled = True
    
    Toolbar.Buttons(1).Value = tbrPressed
    Toolbar.Buttons(2).Value = tbrUnpressed

End Sub

Private Sub SetupDisconnected()
    
    gConnected = False
    
    StatusBar.Panels(1).Text = "Status: Not connected."
    StatusBar.Panels(2).Text = "Node: <NONE>"
    StatusBar.Panels(3).Text = "Port: <NONE>"
    
    MnuTest(0).Enabled = True
    MnuTest(1).Enabled = False
    MnuTest(3).Enabled = False
    MnuTest(4).Enabled = False
    MnuTest(5).Enabled = False
    MnuTest(6).Enabled = False
    MnuTest(7).Enabled = False
    MnuTest(8).Enabled = False

    Toolbar.Buttons(1).Value = tbrUnpressed
    Toolbar.Buttons(2).Value = tbrPressed

End Sub

Private Sub CenterOnScreen()

    Top = (Screen.Height / 6)
    Left = (Screen.Width / 6)
    Height = (((Screen.Height / 3) * 2))
    Width = (((Screen.Width / 3) * 2))

End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)

    If gConnected = True Then

        Msg = "Disconnect form " + gServerName + " ?"
        Mode = vbYesNoCancel + vbQuestion + vbDefaultButton1 + vbApplicationModal
        Title = "Connected!"

        Select Case MsgBox(Msg, Mode, Title)
        Case vbYes
            Disconnect
        Case vbNo
            Msg = "Connection to " + gServerName + " will NOT be closed!"
            Mode = vbOKOnly + vbExclamation
            Title = "Confirmation"
            MsgBox Msg, Mode, Title
        Case vbCancel
            Cancel = 1
        End Select

    End If

End Sub

Private Sub Connect()

    'Get details of server to connect to
    
    frmServer.Show 1
    
    'Check if user pressed "Cancel" in server options form
    
    If gCancel = True Then
        Toolbar.Buttons(1).Value = tbrUnpressed
        Toolbar.Buttons(2).Value = tbrPressed
        gCancel = False
        Exit Sub
    End If
    
    'Connect to xfServerPlus
    Dim status
    status = xfpl.xfStartup(gServerName, gServerPort, "10.1.1.1")
    
    If IsError(status) Then
        MsgBox "xfStartup failed: " + xfpl.getxfErrorMessage()
    Else
        SetupConnected
    End If
    
End Sub

Private Sub Disconnect()

    Dim status
    
    status = xfpl.xfShutdown()
    
    If IsError(status) Then
        MsgBox "Disconnect from xfServerPlus failed!"
    Else
        SetupDisconnected
    End If

End Sub

Private Sub Test1()

    'Test calling a function with no return and no updated parameters

    Dim result
    Dim TestString As String
    
    'result = xfpl.xfSubr("xfpl_tst1", TestString, 12345, 1234567.911, 9876543)

    If IsError(result) Then
        MsgBox xfpl.getxfErrorMessage, vbOKOnly + vbCritical, "Failure"
    Else
        MsgBox "Test 1 Succeeded", vbOKOnly + vbInformation, "Success"
    End If

End Sub

Private Sub Test2()

    'Test calling a function with updated results
    
    Dim result
    
    Dim d1 As Double
    Dim d2 As Double
    Dim d3 As Double
    Dim d4 As Double
    Dim d5 As Double
    Dim d6 As Double
    Dim d7 As Double
    Dim d8 As Variant   'Getting updated data currently requires variant!
    Dim d9 As Double
    Dim d10 As Double

    d1 = 1234567891
    d2 = 333.334
    d3 = 123456.7891
    d4 = 1234567.891
    d5 = 123456789
    d6 = 0.9988332
    d7 = 1.2345
    d8 = 88991010#
    d9 = 654321
    d10 = 123456789.87
    
    result = xfpl.xfSubr("xfpl_tst2", d1, d2, d3, d4, d5, d6, d7, d8, d9, d10)
    
    If IsError(result) Then
        MsgBox xfpl.getxfErrorMessage, vbOKOnly + vbCritical, "Failure"
    Else
        MsgBox "Test 2 Succeeded", vbOKOnly + vbInformation, "Success"
    End If
    
End Sub

Private Sub Test3()

    'Test return value of string

    Dim result

    Dim s1 As String
    Dim s2
    
    s1 = "abcde"
    s2 = "54321"
    
    'result = xfpl.xfSubr("xfpl_tst6", s1, s2)
    
    If IsError(result) Then
        MsgBox xfpl.getxfErrorMessage, vbOKOnly + vbCritical, "Failure"
    Else
        If (s1 <> "abcde") Or (s2 <> "back") Or (result <> 123456789) Then
            MsgBox "Test 3 failed, check return values", vbOKOnly + vbCritical, "Failure"
        Else
            MsgBox "Test 3 Succeeded", vbOKOnly + vbInformation, "Success"
        End If
    End If
    
End Sub

Private Sub Test4()

    MsgBox "Not implemented yet!", vbOKOnly + vbExclamation, "Test 4"

End Sub

Private Sub Test5()

    MsgBox "Not implemented yet!", vbOKOnly + vbExclamation, "Test 5"

End Sub

Private Sub Test6()

    MsgBox "Not implemented yet!", vbOKOnly + vbExclamation, "Test 6"

End Sub

Private Sub Toolbar_ButtonClick(ByVal Button As ComctlLib.Button)

    Select Case Button.Index
    Case 1
        Connect
    Case 2
        Disconnect
    End Select
    
'    Select Case Button.Index
'    Case 1
'        If Button.Value = tbrPressed Then
'            Connect
'        Else
'            Disconnect
'        End If
'    End Select
    

End Sub
