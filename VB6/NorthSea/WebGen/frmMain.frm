VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{48E59290-9880-11CF-9754-00AA00C00908}#1.0#0"; "MSINET.OCX"
Begin VB.Form frmMain 
   BackColor       =   &H80000005&
   Caption         =   "Web Generator"
   ClientHeight    =   6660
   ClientLeft      =   165
   ClientTop       =   735
   ClientWidth     =   7410
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   6660
   ScaleWidth      =   7410
   Tag             =   "ForeVB DB=S:\Source\VB\Nss\gui\docs\WebGen.dba"
   WhatsThisButton =   -1  'True
   WhatsThisHelp   =   -1  'True
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Interval        =   15000
      Left            =   4905
      Top             =   5760
   End
   Begin VB.Timer Timer 
      Enabled         =   0   'False
      Left            =   4320
      Top             =   5760
   End
   Begin InetCtlsObjects.Inet Inet 
      Left            =   5445
      Top             =   5715
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
   End
   Begin MSComctlLib.Toolbar tbToolBar 
      Align           =   1  'Align Top
      Height          =   360
      Left            =   0
      TabIndex        =   1
      Top             =   0
      Width           =   7410
      _ExtentX        =   13070
      _ExtentY        =   635
      ButtonWidth     =   609
      ButtonHeight    =   582
      AllowCustomize  =   0   'False
      Appearance      =   1
      Style           =   1
      ImageList       =   "imlToolbarIcons"
      _Version        =   393216
      BeginProperty Buttons {66833FE8-8583-11D1-B16A-00C0F0283628} 
         NumButtons      =   13
         BeginProperty Button1 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "New"
            Object.ToolTipText     =   "New Project"
            ImageKey        =   "New"
         EndProperty
         BeginProperty Button2 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "Open"
            Object.ToolTipText     =   "Open Project"
            ImageKey        =   "Open"
         EndProperty
         BeginProperty Button3 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "Save"
            Object.ToolTipText     =   "Save Project"
            ImageKey        =   "Save"
         EndProperty
         BeginProperty Button4 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "Delete"
            Object.ToolTipText     =   "Delete Project"
            ImageKey        =   "Delete"
         EndProperty
         BeginProperty Button5 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button6 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "Properties"
            Object.ToolTipText     =   "Project Properties"
            ImageKey        =   "Properties"
         EndProperty
         BeginProperty Button7 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "Generate"
            Object.ToolTipText     =   "Generate HTML"
            ImageKey        =   "Generate2"
         EndProperty
         BeginProperty Button8 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
            Object.Width           =   500
         EndProperty
         BeginProperty Button9 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "Options"
            Object.ToolTipText     =   "Application Options"
            ImageKey        =   "Tools"
         EndProperty
         BeginProperty Button10 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button11 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "Browser"
            Object.ToolTipText     =   "Web Browser"
            ImageKey        =   "Browser"
         EndProperty
         BeginProperty Button12 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "Editor"
            Object.ToolTipText     =   "HTML Editor"
            ImageKey        =   "Editor"
         EndProperty
         BeginProperty Button13 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "FtpClient"
            Object.ToolTipText     =   "FTP Client"
            ImageKey        =   "FtpClient"
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.StatusBar sbStatusBar 
      Align           =   2  'Align Bottom
      Height          =   270
      Left            =   0
      TabIndex        =   0
      Top             =   6390
      Width           =   7410
      _ExtentX        =   13070
      _ExtentY        =   476
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   3
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            AutoSize        =   1
            Object.Width           =   7435
         EndProperty
         BeginProperty Panel2 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            Style           =   6
            AutoSize        =   2
            TextSave        =   "08/12/99"
         EndProperty
         BeginProperty Panel3 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            Style           =   5
            AutoSize        =   2
            TextSave        =   "11:27"
         EndProperty
      EndProperty
   End
   Begin MSComDlg.CommonDialog dlgCommonDialog 
      Left            =   6165
      Top             =   5760
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin MSComctlLib.ImageList imlToolbarIcons 
      Left            =   6750
      Top             =   5715
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   16
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":0442
            Key             =   "Cut"
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":0554
            Key             =   "New"
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":0666
            Key             =   "Open"
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":0778
            Key             =   "Save"
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":088A
            Key             =   "Copy"
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":099C
            Key             =   "Paste"
         EndProperty
         BeginProperty ListImage7 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":0AAE
            Key             =   "Delete"
         EndProperty
         BeginProperty ListImage8 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":0BC0
            Key             =   "Properties"
         EndProperty
         BeginProperty ListImage9 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":0CD2
            Key             =   "Undo"
         EndProperty
         BeginProperty ListImage10 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":0DE4
            Key             =   "Redo"
         EndProperty
         BeginProperty ListImage11 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":0EF6
            Key             =   "Generate"
         EndProperty
         BeginProperty ListImage12 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":1062
            Key             =   "Generate2"
         EndProperty
         BeginProperty ListImage13 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":11CE
            Key             =   "Tools"
         EndProperty
         BeginProperty ListImage14 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":133A
            Key             =   "FtpClient"
         EndProperty
         BeginProperty ListImage15 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":14A6
            Key             =   "Editor"
         EndProperty
         BeginProperty ListImage16 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":1612
            Key             =   "Browser"
         EndProperty
      EndProperty
   End
   Begin VB.Menu mnuFile 
      Caption         =   "&File"
      Begin VB.Menu mnuFileNew 
         Caption         =   "&New Project"
         Shortcut        =   ^N
      End
      Begin VB.Menu mnuFileOpen 
         Caption         =   "&Open Project..."
         Shortcut        =   ^O
      End
      Begin VB.Menu mnuFileBar0 
         Caption         =   "-"
      End
      Begin VB.Menu mnuFileSave 
         Caption         =   "&Save Project"
         Enabled         =   0   'False
         Shortcut        =   ^S
      End
      Begin VB.Menu mnuFileSaveAs 
         Caption         =   "Save Project &As..."
         Enabled         =   0   'False
      End
      Begin VB.Menu mnuFileBar1 
         Caption         =   "-"
      End
      Begin VB.Menu mnuFileDelete 
         Caption         =   "&Delete Project"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnuFileBar2 
         Caption         =   "-"
      End
      Begin VB.Menu mnuFileClose 
         Caption         =   "&Close Project"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnuFileBar3 
         Caption         =   "-"
      End
      Begin VB.Menu mnuFileExit 
         Caption         =   "E&xit"
      End
   End
   Begin VB.Menu mnuView 
      Caption         =   "&View"
      Begin VB.Menu mnuViewToolbar 
         Caption         =   "&Toolbar"
         Checked         =   -1  'True
      End
      Begin VB.Menu mnuViewStatusBar 
         Caption         =   "Status &Bar"
         Checked         =   -1  'True
      End
   End
   Begin VB.Menu mnuProject 
      Caption         =   "&Project"
      Begin VB.Menu mnuProjectGenerate 
         Caption         =   "&Generate HTML"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnuProjectProperties 
         Caption         =   "&Properties..."
         Enabled         =   0   'False
      End
   End
   Begin VB.Menu mnuTools 
      Caption         =   "&Tools"
      Begin VB.Menu mnuToolsBrowser 
         Caption         =   "&Web Browser"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnuToolsEditor 
         Caption         =   "&HTML Editor"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnuToolsFtp 
         Caption         =   "&FTP Client"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnuToolsBar1 
         Caption         =   "-"
      End
      Begin VB.Menu mnuToolsOptions 
         Caption         =   "&Options..."
      End
   End
   Begin VB.Menu mnuHelp 
      Caption         =   "&Help"
      NegotiatePosition=   3  'Right
      Begin VB.Menu mnuHelpContents 
         Caption         =   "&Contents"
      End
      Begin VB.Menu mnuHelpSearchForHelpOn 
         Caption         =   "&Search For Help On..."
      End
      Begin VB.Menu mnuHelpBar0 
         Caption         =   "-"
      End
      Begin VB.Menu mnuHelpAbout 
         Caption         =   "&About "
      End
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Form_Load()
    
    'Load window coordinates in Registry

    Me.Left = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Left", (Screen.Width * 0.1))
    Me.Top = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Top", (Screen.Height * 0.1))
    Me.Width = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Width", (Screen.Width * 0.8))
    Me.Height = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Height", (Screen.Height * 0.8))

    If Command <> "" Then
        If ParseProject(Command) = True Then
            ProjectFile = Command
            ProjectOpen = True
            SetupUI (ProjectOpen)
        Else
            MsgBox "Failed to open project " & Command
        End If
    End If

End Sub

Private Sub Form_Unload(Cancel As Integer)
    
    Dim i As Integer

    'Close all sub forms
    For i = Forms.count - 1 To 1 Step -1
        Unload Forms(i)
    Next
    
    'Save window coordinates in Registry
    
    If Me.WindowState <> vbMinimized Then
        Call SaveSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Left", Me.Left)
        Call SaveSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Top", Me.Top)
        Call SaveSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Width", Me.Width)
        Call SaveSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Height", Me.Height)
    End If
    
    Call SaveSettingString(HKEY_LOCAL_MACHINE, RegPath, "Version", App.Major & "." & App.Minor)
    
    'Terminate program
    End
    
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)

    If ProjectOpen And ProjectChanged Then
    
        Select Case MsgBox("Save project?", vbYesNoCancel + vbDefaultButton1 + vbQuestion, "Close Application")
        Case vbYes
            mnuFileSave_Click
        Case vbCancel
            Cancel = 1
        End Select

    End If

End Sub

Private Sub Form_Resize()
    
    On Error Resume Next
    If Me.Width < 3000 Then Me.Width = 3000

End Sub

Private Sub mnuToolsBrowser_Click()

    Dim ProcessID As Double
    ProcessID = Shell(ToolBrowser, vbNormalFocus)

End Sub

Private Sub mnuToolsEditor_Click()

    Dim ProcessID As Double
    ProcessID = Shell(ToolEditor, vbNormalFocus)

End Sub

Private Sub mnuToolsFtp_Click()

    Dim ProcessID As Double
    ProcessID = Shell(ToolFtpClient, vbNormalFocus)

End Sub

Private Sub mnuToolsOptions_Click()

    fOptions.Show vbModal, Me

End Sub

Private Sub tbToolBar_ButtonClick(ByVal Button As MSComCtlLib.Button)
    
    On Error Resume Next
    Select Case Button.Key
        Case "New"
            mnuFileNew_Click
        Case "Open"
            mnuFileOpen_Click
        Case "Save"
            SaveProject
        Case "Delete"
            DeleteProject
        Case "Properties"
            mnuProjectProperties_Click
        Case "Generate"
            frmGenerate.Show vbModal, Me
        Case "Options"
            mnuToolsOptions_Click
        Case "Browser"
            mnuToolsBrowser_Click
        Case "Editor"
            mnuToolsEditor_Click
        Case "FtpClient"
            mnuToolsFtp_Click
    End Select

End Sub

Private Sub mnuHelpAbout_Click()
    
    frmAbout.Show vbModal, Me

End Sub

Private Sub mnuViewStatusBar_Click()
    
    mnuViewStatusBar.Checked = Not mnuViewStatusBar.Checked
    sbStatusBar.Visible = mnuViewStatusBar.Checked

End Sub

Private Sub mnuViewToolbar_Click()
    
    mnuViewToolbar.Checked = Not mnuViewToolbar.Checked
    tbToolBar.Visible = mnuViewToolbar.Checked

End Sub

Private Sub mnuFileExit_Click()

    'unload the form
    Unload Me

End Sub

Private Sub mnuFileNew_Click()

    If ProjectOpen = True Then
        mnuFileClose_Click
    End If
    
    If ProjectOpen = False Then
        NewProject
    End If
    
End Sub

Private Sub mnuFileOpen_Click()
    
    If ProjectOpen = True Then
        mnuFileClose_Click
    End If
    
    If ProjectOpen = False Then
        OpenProject
    End If
    
End Sub

Private Sub mnuFileClose_Click()

    'If the project has changed, should we save it?
    If ProjectChanged = True Then
        Select Case MsgBox("Save changes to current project?", vbYesNoCancel + vbDefaultButton1 + vbQuestion, "Option")
        Case vbYes:
            SaveProject
        Case vbCancel:
            Exit Sub
        End Select
    End If

    CloseProject

End Sub

Private Sub mnuFileSave_Click()

    SaveProject

End Sub

Private Sub mnuFileSaveAs_Click()

    SaveProjectAs

End Sub

Private Sub mnuFileDelete_Click()

    DeleteProject

End Sub

Private Sub mnuProjectGenerate_Click()

    frmGenerate.Show vbModal, Me

End Sub

Private Sub mnuProjectProperties_Click()
    
    fProperties.Show vbModal, Me
    
    If ProjectChanged = True Then
        sbStatusBar.Panels(1).Text = fProperties.txtDescription.Text
    End If

End Sub

Private Sub Inet_StateChanged(ByVal State As Integer)

    Select Case State
    
    Case icNone '0
        AddDetailLog ("FTP: No status!")
    
    Case icHostResolvingHost '1
        AddDetailLog ("FTP: Resolving remote host name")
    
    Case icHostResolved
        AddDetailLog ("FTP: Host name resolved")
    
    Case icConnecting
        AddDetailLog ("FTP: Conecting to remote system")
    
    Case icConnected
        AddDetailLog ("FTP: Connected to remote system")
    
    Case icRequestSent
        AddDetailLog ("FTP: Request sent to remote system")
    
    Case icReceivingResponse
        AddDetailLog ("FTP: Receiving response from remote system")
    
    Case icResponseReceived
        AddDetailLog ("FTP: Received response from remote system")
    
    Case icDisconnecting
        AddDetailLog ("FTP: Disconnecting from remote system")
    
    Case icDisconnected
        AddDetailLog ("FTP: Disconnected from remote system")
    
    Case icError
        
        'Cancel the transfer timeout
        Timer1.Enabled = False
        
        AddDetailLog ("FTP: Communication error")
        frmMessage.Hide
    
    Case icResponseCompleted
        
        'The transfer is complete.  Fire a timer event, which will remove
        'the message window after a short delay.  This simply "slows down"
        'the transfer process wo that the message window doesn't flash on and
        'off the screen too fast to be read!
        
        'Cancel the transfer timeout
        Timer1.Enabled = False
        
        'Log the successful transfer
        AddDetailLog ("FTP: Transfer completed")
        
        'Leave the message window up for 1.5 seconds
        Timer.Interval = 1500
        Timer.Enabled = True

    End Select

End Sub

Private Sub Timer_Timer()

    'This routine is used to "slow down" the FTP file transfer process
    'to prevent the message window just "flashing" on and off the screen.

    Timer.Enabled = False
    frmMessage.Hide

End Sub

Private Sub Timer1_Timer()

    'This routine is called if Timer1 fires.  This would happen if an FTP
    'transfer attempt times out beyond the 15 second maximum.

    Timer1.Enabled = False
    MsgBox "FTP Transfer Failed!", vbOKOnly & vbCritical, "Error"
    frmMessage.Hide

End Sub

Private Sub mnuHelpContents_Click()

    Dim nRet As Integer
    'if there is no helpfile for this project display a message to the user
    'you can set the HelpFile for your application in the
    'Project Properties dialog
    If Len(App.HelpFile) = 0 Then
        MsgBox "Unable to display Help Contents. There is no Help associated with this project.", vbInformation, Me.Caption
    Else
        On Error Resume Next
        nRet = WinHelp(Me.hwnd, App.HelpFile, HELP_CONTENTS, 0)
        If Err Then
            MsgBox Err.Description
        End If
    End If
    
End Sub

Private Sub mnuHelpSearchForHelpOn_Click()
    
    Dim nRet As Integer

    'if there is no helpfile for this project display a message to the user
    'you can set the HelpFile for your application in the
    'Project Properties dialog
    If Len(App.HelpFile) = 0 Then
        MsgBox "Unable to display Help Contents.", vbInformation, "Help Unavailable"
    Else
        On Error Resume Next
        nRet = WinHelp(Me.hwnd, App.HelpFile, HELP_PARTIALKEY, 0)
        If Err Then
            MsgBox Err.Description
        End If
    End If

End Sub

