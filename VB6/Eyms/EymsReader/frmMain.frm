VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{20C62CAE-15DA-101B-B9A8-444553540000}#1.1#0"; "MSMAPI32.OCX"
Object = "{DB797681-40E0-11D2-9BD5-0060082AE372}#4.0#0"; "XCEEDZIP.DLL"
Begin VB.Form frmMain 
   Caption         =   "EYMS - Receive Wayfarer Data"
   ClientHeight    =   6945
   ClientLeft      =   60
   ClientTop       =   630
   ClientWidth     =   8385
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   6945
   ScaleWidth      =   8385
   Begin VB.ListBox MessageList 
      Height          =   1860
      Left            =   240
      Style           =   1  'Checkbox
      TabIndex        =   2
      Top             =   480
      Width           =   4755
   End
   Begin MSMAPI.MAPIMessages MAPIMessages1 
      Left            =   6900
      Top             =   5700
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
      AddressEditFieldCount=   1
      AddressModifiable=   0   'False
      AddressResolveUI=   0   'False
      FetchSorted     =   0   'False
      FetchUnreadOnly =   0   'False
   End
   Begin MSMAPI.MAPISession MAPISession1 
      Left            =   6240
      Top             =   5700
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
      DownloadMail    =   -1  'True
      LogonUI         =   -1  'True
      NewSession      =   0   'False
   End
   Begin MSComctlLib.StatusBar StatusBar1 
      Align           =   2  'Align Bottom
      Height          =   375
      Left            =   0
      TabIndex        =   0
      Top             =   6570
      Width           =   8385
      _ExtentX        =   14790
      _ExtentY        =   661
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   3
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            AutoSize        =   1
            Object.Width           =   10689
         EndProperty
         BeginProperty Panel2 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            Style           =   6
            Alignment       =   1
            AutoSize        =   2
            Object.Width           =   1773
            MinWidth        =   1764
            TextSave        =   "04/01/00"
         EndProperty
         BeginProperty Panel3 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            Style           =   5
            Alignment       =   1
            AutoSize        =   2
            Object.Width           =   1773
            MinWidth        =   1764
            TextSave        =   "21:45"
         EndProperty
      EndProperty
   End
   Begin VB.ListBox Log 
      Height          =   2400
      Left            =   240
      TabIndex        =   1
      Top             =   3120
      Width           =   5175
   End
   Begin XceedZipLibCtl.XceedZip XceedZip1 
      Left            =   7620
      Top             =   5700
      BasePath        =   ""
      CompressionLevel=   6
      EncryptionPassword=   ""
      RequiredFileAttributes=   0
      ExcludedFileAttributes=   24
      FilesToProcess  =   ""
      FilesToExclude  =   ""
      MinDateToProcess=   2
      MaxDateToProcess=   2958465
      MinSizeToProcess=   0
      MaxSizeToProcess=   0
      SplitSize       =   0
      PreservePaths   =   -1  'True
      ProcessSubfolders=   0   'False
      SkipIfExisting  =   0   'False
      SkipIfNotExisting=   0   'False
      SkipIfOlderDate =   0   'False
      SkipIfOlderVersion=   0   'False
      TempFolder      =   ""
      UseTempFile     =   -1  'True
      UnzipToFolder   =   ""
      ZipFilename     =   ""
      SpanMultipleDisks=   2
      ExtraHeaders    =   10
      ZipOpenedFiles  =   0   'False
      BackgroundProcessing=   0   'False
      SfxBinrayModule =   ""
      SfxDefaultPassword=   ""
      SfxDefaultUnzipToFolder=   ""
      SfxExistingFileBehavior=   0
      SfxReadmeFile   =   ""
      SfxExecuteAfter =   ""
      SfxInstallMode  =   0   'False
      SfxProgramGroup =   ""
      SfxProgramGroupItems=   ""
      SfxExtensionsToAssociate=   ""
      SfxIconFilename =   ""
   End
   Begin VB.Menu MnuFile 
      Caption         =   "&File"
      Begin VB.Menu MnuFileExit 
         Caption         =   "E&xit"
      End
   End
   Begin VB.Menu MnuMessage 
      Caption         =   "&Message"
      Begin VB.Menu MnuMessageProcess 
         Caption         =   "&Process Selected Messages"
      End
      Begin VB.Menu MnuMessageSelectAll 
         Caption         =   "&Select All Messages"
      End
      Begin VB.Menu MnuMessageDeselectAll 
         Caption         =   "&Deselect All Messages"
      End
      Begin VB.Menu MnuRecheckInbox 
         Caption         =   "&Recheck Inbox"
      End
   End
   Begin VB.Menu MnuLog 
      Caption         =   "&Log"
      Begin VB.Menu MnuLogClear 
         Caption         =   "&Clear Log Window"
      End
      Begin VB.Menu MnuLogShow 
         Caption         =   "&Show Log Window"
      End
   End
   Begin VB.Menu MnuTools 
      Caption         =   "&Tools"
      Begin VB.Menu MnuToolsDepots 
         Caption         =   "&Remote Depots..."
      End
      Begin VB.Menu MnuToolsOptions 
         Caption         =   "&Options..."
      End
   End
   Begin VB.Menu MnuHelp 
      Caption         =   "&Help"
      Begin VB.Menu MnuHelpAbout 
         Caption         =   "&About"
      End
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

'General public variables
Public RegPath As String
Public PasswordOK As Boolean

Public MailProfile As String
Public MailPassword As String
Public FileOverwrite As Long
Public UnreadOnly As Long
Public PreserveZip As Long
Public DeleteMessage As Long
Public TransformProcessing As Long
Public TransformDir As String

Public TotalFiles, TotalBytes As Long

Const DefaultMailProfile = ""
Const DefaultMailPassword = ""
Const DefaultFileOverwrite = 0
Const DefaultUnreadOnly = 1
Const DefaultPreserveZip = 0
Const DefaultDeleteMessage = 0
Const DefaultTransformProcessing = 0
Const DefaultTransformDir = ""

Private Sub Form_Load()

    Dim SettingWasMissing As Boolean

    If App.PrevInstance = True Then
        MsgBox "EymsReader is already running!", vbExclamation, "Information"
        End
    End If
    
    Width = Screen.Width * 0.8
    Height = Screen.Height * 0.8

    'Setup the Registry key to be used
    RegPath = "Software\Internet Software Services\EYMS Wayfarer Reader\1.0"
    
    'Restore initial window dimensions
    With frmMain
        .Top = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "WindowTop", (Screen.Height * 0.1))
        .Left = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "WindowLeft", (Screen.Width * 0.1))
        .Width = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "WindowWidth", (Screen.Width * 0.8))
        .Height = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "WindowHeight", (Screen.Height * 0.8))
    End With
    
    'Restore log window status
    MnuLogShow.Checked = CBool(GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "LogEnabled", 0))
    
    StatusBar1.Height = 300
    
    Me.Show
    
    'Get configuration settings from Registry
    MailProfile = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "MailProfile", "Not Found")
    MailPassword = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "MailPassword", "Not Found")
    FileOverwrite = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "FileOverwrite", -1)
    UnreadOnly = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "UnreadOnly", -1)
    PreserveZip = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "PreserveZip", -1)
    DeleteMessage = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "DeleteMessage", -1)
    TransformProcessing = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "TransformProcessing", -1)
    TransformDir = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "TransformDir", "Not Found")

    'Check to make sure that each setting was retrieved from the Registry.  If
    'not then use the default value and save it in the Registry.

    SettingWasMissing = False

    If MailProfile = "Not Found" Then
        SaveSettingString HKEY_LOCAL_MACHINE, RegPath, "MailProfile", DefaultMailProfile
        MailProfile = DefaultMailProfile
    End If

    If MailPassword = "Not Found" Then
        SaveSettingString HKEY_LOCAL_MACHINE, RegPath, "MailPassword", DefaultMailPassword
        MailPassword = DefaultMailPassword
    End If

    If FileOverwrite = -1 Then
        SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "FileOverwrite", DefaultFileOverwrite
        FileOverwrite = DefaultFileOverwrite
    End If

    If UnreadOnly = -1 Then
        SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "UnreadOnly", DefaultUnreadOnly
        UnreadOnly = DefaultUnreadOnly
    End If

    If PreserveZip = -1 Then
        SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "PreserveZip", DefaultPreserveZip
        PreserveZip = DefaultPreserveZip
    End If

    If DeleteMessage = -1 Then
        SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "DeleteMessage", DefaultDeleteMessage
        DeleteMessage = DefaultDeleteMessage
    End If

    If TransformProcessing = -1 Then
        SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "TransformProcessing", DefaultTransformProcessing
        TransformProcessing = DefaultTransformProcessing
    End If

    If TransformDir = "Not Found" Then
        SaveSettingString HKEY_LOCAL_MACHINE, RegPath, "TransformDir", DefaultTransformDir
        TransformDir = DefaultTransformDir
    End If

    If SettingWasMissing = True Then
        MsgBox "One or more configuration settings was not found." & Chr(13) & Chr(10) & "Please review the settings in the following dialog.", vbOKOnly, "Review Settings"
        frmOptions.Show vbModal
    End If

    'Attempt to start mail system
    Do
        If StartMailSession = True Then
            Exit Do
        Else
            Select Case MsgBox("Failed to start mail session." & Chr(13) & Chr(10) & "Try changing mail profile settings.", vbOKCancel + vbExclamation, "Mail Error")
            Case vbOK:
                frmOptions.Show vbModal
            Case vbCancel:
                End
            End Select
        End If
        AddLog "Retrying mail system startup"
    Loop

    LoadMessageList

End Sub

Private Sub Form_Resize()

    If Me.WindowState <> vbMinimized Then

        'Make sure that the window does not get too small!
        With Me
            If .Height < 3000 Then .Height = 3000
            If .Width < 6000 Then .Width = 6000
        End With
        
        'Reposition Batch List
        With MessageList
            .Top = 1
            .Left = 1
            .Width = frmMain.ScaleWidth
            If MnuLogShow.Checked = False Then
                .Height = frmMain.ScaleHeight - StatusBar1.Height - 1
            Else
                .Height = (frmMain.ScaleHeight - StatusBar1.Height - 1) / 2
            End If
        End With
        
        'Reposition log list
        With Log
            .Top = (frmMain.ScaleHeight - StatusBar1.Height) / 2
            .Left = 1
            .Width = frmMain.ScaleWidth
            .Height = (frmMain.ScaleHeight - StatusBar1.Height) / 2
            .Visible = MnuLogShow.Checked
        End With

    End If

End Sub

Private Sub Form_Unload(Cancel As Integer)

    Call EndMailSession

    SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "WindowTop", frmMain.Top
    SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "WindowLeft", frmMain.Left
    SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "WindowHeight", frmMain.Height
    SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "WindowWidth", frmMain.Width

    If MnuLogShow.Checked = True Then
        SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "LogEnabled", 1
    Else
        SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "LogEnabled", 0
    End If

End Sub

'*****************************************************************************
'***MAIN PROCESSING ROUTINES**************************************************
'*****************************************************************************

Private Function StartMailSession() As Boolean

    'Start a MAPI session and setup MAPI environment

    'Default to success
    StartMailSession = True

    On Error GoTo ErrorHandler

    AddLog "Attempting to connect to e-mail session"

    'Outlook Express doesn't seem to use the login information, but if
    'logon to an exchange server is required then the name of the exchange
    'profile to be used needs to be specified in the UserName property.  If
    'the profile is password protected then also use the Password property.
    
    If MailProfile <> "" Then
        MAPISession1.UserName = MailProfile
    End If
    
    If MailPassword <> "" Then
        MAPISession1.Password = MailPassword
    End If
    
    'Don't display a logon dialog.  If login information is invalid
    'an error will be generated.
    MAPISession1.LogonUI = False
    
    'If mail is already running on the desktop then use it, don't
    'create a new session.
    MAPISession1.NewSession = False
    
    'Don't download new mail during signon
    MAPISession1.DownLoadMail = False
    
    'Bring up the MAPI session
    MAPISession1.SignOn
    
    If MAPISession1.SessionID = 0 Then Error 3000
        
    MAPIMessages1.SessionID = MAPISession1.SessionID
    
    AddLog "Connected to e-mail session"
    
    Exit Function

ErrorHandler:

    Dim Msg As String
    Msg = "Failed to connect to e-mail session!"
    MsgBox Msg, vbOKOnly + vbCritical, "Error"
    AddLog "ERROR: " & Msg
    StartMailSession = False

End Function

Private Function EndMailSession() As Boolean
    
    'Close down the MAPI session
    
    On Error GoTo ErrorHandler
    
    'Default to success
    EndMailSession = True
    
    AddLog "Attempting to disconnect from e-mail session"
    
    MAPISession1.SignOff
    
    AddLog "Disconnected from e-mail session"

    Exit Function

ErrorHandler:

    Dim Msg As String
    Msg = "Failed to disconnect from e-mail session!"
    MsgBox Msg, vbOKOnly + vbCritical, "Error"
    AddLog "ERROR: " & Msg
    EndMailSession = False

End Function

Private Function GetNewMessages() As Long

    Dim Messages As Long

    'Get all unread messages in FIFO order
    AddLog "Searching inbox for new messages"
        
    MAPIMessages1.FetchSorted = True
    MAPIMessages1.FetchUnreadOnly = CBool(UnreadOnly)
    MAPIMessages1.Fetch

    Messages = MAPIMessages1.MsgCount

    If Messages = 0 Then
        If UnreadOnly = 1 Then
            AddLog "Inbox contains no unread messages"
        Else
            AddLog "Inbox contains no messages"
        End If
    Else
        If Messages = 1 Then
            If UnreadOnly = 1 Then
                AddLog "Inbox contains 1 unread message"
            Else
                AddLog "Inbox contains 1 message"
            End If
        Else
            If UnreadOnly = 1 Then
                AddLog "Inbox contains " & Messages & " unread messages"
            Else
                AddLog "Inbox contains " & Messages & " messages"
            End If
        End If
    End If

    GetNewMessages = Messages

End Function

Private Function LoadMessageList()

    Dim Message, Messages As Long
    Dim MsgSubject As String

    'Make sure message list is empty
    MessageList.Clear

    Messages = GetNewMessages

    If Messages > 0 Then
        
        For Message = 0 To (Messages - 1)
            
            'Select next message
            MAPIMessages1.MsgIndex = Message
            MsgSubject = MAPIMessages1.MsgSubject
            
            'Add item to list
            MessageList.AddItem MsgSubject
            
            'If message is unread...
            If MAPIMessages1.MsgRead = False Then
                'And message is one of ours...
                If InStr(1, MsgSubject, "(Wayfarer data from ") <> 0 Then
                    'Then select it
                    MessageList.Selected(MessageList.NewIndex) = True
                End If
            End If
        
        Next
        
        MessageList.ListIndex = 0
        
    End If
        
End Function

Private Function UnZip(ZipFile As String, TargetDir As String) As Boolean

    'UnZip attachment into target directory
    AddLog "Commencing unzip opertaion"
    
    'Define unzip properties
    XceedZip1.BackgroundProcessing = False
    XceedZip1.ZipFilename = ZipFile
    XceedZip1.UnzipToFolder = TargetDir

    'Do the UnZip
    If XceedZip1.UnZip = xerSuccess Then
        UnZip = True
    Else
        UnZip = False
    End If

    StatusBar1.Panels(1).Text = ""

End Function

Private Sub ClearTotals()

    'Reset total files & bytes counters
    TotalFiles = 0
    TotalBytes = 0

End Sub

Private Sub ReportTotals()

    AddLog "A total of " & TotalFiles & " files (" & FormatNumber(TotalBytes, 0, , , vbTrue) & " bytes) have been unzipped"

End Sub

Public Sub AddLog(LogEntry As String)

    Log.AddItem LogEntry
    Log.ListIndex = Log.ListCount - 1

End Sub

'*****************************************************************************
'***MENU ENTRIES**************************************************************
'*****************************************************************************

Private Sub MnuFileExit_Click()

    Unload frmMain

End Sub

Private Sub MnuMessageProcess_Click()

    Dim Message As Long
    Dim MsgSubject As String
    Dim DepotCode, DepotName, DepotDir, BatchCode As String
    Dim TransformDepotCode As String
    Dim AttachmentName As String
    Dim TargetDir As String
    Dim Pos, Pos1 As Long
            
    'Cycle through the entries in the message list, processing any
    'selected messages
            
    ClearTotals
    Message = -1

    Do
        'Move to next message
        Message = Message + 1

        'Check we haven't gone too far
        If Message > MessageList.ListCount - 1 Then Exit Do

        AddLog "------------------------------------------------------------------------------------------------------------------------------------------------"
        
        'Check if this message is selected in the list
        If MessageList.Selected(Message) = False Then
        
            AddLog "Skipping this message, it is not selected for processing"
        
        Else
            'Select this message in the MAPI message set
            MAPIMessages1.MsgIndex = Message
            
            'Retrieve subject line
            MsgSubject = MAPIMessages1.MsgSubject
    
            'Look for formatted subject text
            If InStr(1, MsgSubject, "(Wayfarer data from ") = 0 Then
            
                AddLog "Skipping this message, it does not contain inbound Wayfarer data"
                MessageList.Selected(Message) = False

            Else
                
                'Extract depot code and batch code
                Pos = InStr(1, MsgSubject, "_")
                Pos1 = InStr(Pos, MsgSubject, " ")
                DepotCode = Left(MsgSubject, Pos - 1)
                BatchCode = Mid(MsgSubject, (Pos + 1), (Pos1 - Pos - 1))
                
                'Get depot details from Registry
                DepotName = GetSettingString(HKEY_LOCAL_MACHINE, RegPath & "\Depots", CStr(DepotCode))
                
                'Extract Transform Depot Code
                Pos = InStr(1, DepotName, "|")
                TransformDepotCode = Right(DepotName, Len(DepotName) - Pos)
                DepotName = Left(DepotName, Pos - 1)
                
                'Extract depot data directory
                Pos = InStr(1, DepotName, "@")
                DepotDir = Right(DepotName, Len(DepotName) - Pos)
                
                'Remove data directory to leave depot name
                DepotName = Left(DepotName, Pos - 1)
                
                AddLog "This message contains batch " & BatchCode & " from " & DepotName
                
                AttachmentName = MAPIMessages1.AttachmentName
                
                If AttachmentName = "" Then
                    AddLog "ERROR: No ZIP file was attached to the message"
                Else
                    AddLog "File attachment is " & AttachmentName
                
                    'Calculate target directory
                    TargetDir = DepotDir & BatchCode & "\"
                    AddLog "Target directory is " & TargetDir
                    
                    'Check if this target directory already exists
                    If Dir(TargetDir & "*.*", vbNormal) <> "" Then
                        AddLog "Target directory already exists and contains files"
                        Select Case FileOverwrite
                        Case 0: 'Ask user
                            If MsgBox("Directory " & TargetDir & " already exists, and" & Chr(13) & Chr(10) & "contains files. Delete the existing files before unzipping new files?", vbYesNo + vbQuestion + vbDefaultButton1, "Delete Existing Files?") = vbYes Then
                                Kill TargetDir & "*.*"
                                AddLog "Existing files have been deleted"
                            Else
                                MsgBox "Existing files with the same name" & Chr(13) & Chr(10) & "as new files wil be overwritten!", vbOKOnly + vbExclamation, "WARNING!"
                                AddLog "Existing files were not deleted, but may have been overwritten"
                            End If
                        Case 1: 'Delete files
                            Kill TargetDir & "*.*"
                            AddLog "Existing files have been deleted"
                        Case 2: 'Overwrite duplicate files
                            AddLog "Existing files were not deleted, but may have been overwritten"
                        End Select
                    End If
                
                    'UnZip attachment into target directory
                    If UnZip(AttachmentName, TargetDir) = True Then
                        AddLog "Files unzipped successfully"
                    Else
                        AddLog "ERROR: Unzip operation failed!"
                    End If
                    
                    'Unzip attachment into Transform group directory
                    If TransformProcessing = 1 Then
                    
                        'Calculate target directory
                        TargetDir = TransformDir & Left(BatchCode, 5) & TransformDepotCode & "\"
                        AddLog "Transform directory is " & TargetDir
                    
                        'Check if this target directory already exists
                        If Dir(TargetDir & "*.*", vbNormal) <> "" Then
                            AddLog "Transform directory already exists and contains files"
                            Select Case FileOverwrite
                            Case 0: 'Ask user
                                If MsgBox("Directory " & TargetDir & " already exists, and" & Chr(13) & Chr(10) & "contains files. Delete the existing files before unzipping new files?", vbYesNo + vbQuestion + vbDefaultButton1, "Delete Existing Files?") = vbYes Then
                                    Kill TargetDir & "*.*"
                                    AddLog "Existing files have been deleted"
                                Else
                                    MsgBox "Existing files with the same name" & Chr(13) & Chr(10) & "as new files wil be overwritten!", vbOKOnly + vbExclamation, "WARNING!"
                                    AddLog "Existing files were not deleted, but may have been overwritten"
                                End If
                            Case 1: 'Delete files
                                Kill TargetDir & "*.*"
                                AddLog "Existing files have been deleted"
                            Case 2: 'Overwrite duplicate files
                                AddLog "Existing files were not deleted, but may have been overwritten"
                            End Select
                        End If
                    
                        'UnZip attachment into target directory
                        If UnZip(AttachmentName, TargetDir) = True Then
                            AddLog "Files unzipped successfully"
                        Else
                            AddLog "ERROR: Unzip operation failed!"
                        End If
                    
                    End If

                    'Deselect the message in the message list
                    MessageList.Selected(Message) = False
                    
                    If PreserveZip = 1 Then
                        FileCopy AttachmentName, DepotDir & "*.*"
                        AddLog "ZIP file copied to depot directory"
                    End If
                    
                    If DeleteMessage = 1 Then
                        'Delete message from MAPI message set
                        MAPIMessages1.Delete mapMessageDelete
                        'Delete item from message list
                        MessageList.RemoveItem (Message)
                        'Decrement counter to account for deleted message
                        Message = Message - 1
                        AddLog "Message deleted from inbox"
                    End If
                End If
            End If
        End If
    Loop
    
    AddLog "------------------------------------------------------------------------------------------------------------------------------------------------"
    AddLog "There are no more messages to process"
    ReportTotals

    'Reload the message list from the inbox.  This causes a MAPI fetch, which
    'should also delete all attachments from the TEMP directory
    LoadMessageList

End Sub

Private Sub MnuMessageSelectAll_Click()

    'Select all messages, regardless of actual inbox status

    Dim count As Long
    
    For count = 0 To (MessageList.ListCount - 1)
        MessageList.Selected(count) = True
    Next

    MessageList.ListIndex = 0

    AddLog "All messages were manually selected"

End Sub

Private Sub MnuMessageDeselectAll_Click()

    'Deselect all messages, regardless of actual inbox status

    Dim count As Long
    
    For count = 0 To (MessageList.ListCount - 1)
        MessageList.Selected(count) = False
    Next

    MessageList.ListIndex = 0

    AddLog "All messages were manually deselected"

End Sub

Private Sub MnuRecheckInbox_Click()

    'Re-load message list from inbox
    LoadMessageList

End Sub

Private Sub MnuLogShow_Click()
    
    If MnuLogShow.Checked = True Then
        MnuLogShow.Checked = False
    Else
        MnuLogShow.Checked = True
    End If
    
    Form_Resize

End Sub

Private Sub MnuLogClear_Click()
    Log.Clear
End Sub

Private Sub MnuToolsDepots_Click()

    frmDepot.Show vbModal

End Sub

Private Sub MnuToolsOptions_Click()

    frmOptions.Show vbModal

    'Re-load messages incase "only show unread" has changed
    LoadMessageList

End Sub

Private Sub MnuHelpAbout_Click()

    frmAbout.Show vbModal

End Sub

'*****************************************************************************
'***OTHER UI EVENTS***********************************************************
'*****************************************************************************

Private Sub MessageList_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)

    If Button = vbRightButton Then
        PopupMenu MnuMessage
    End If

End Sub

Private Sub MessageList_ItemCheck(Item As Integer)

    'In item checkbox in the batch list has changed value.  Set the
    'enabled status of the "Process" menu entry appropriately.

    If MessageList.SelCount > 0 Then
        MnuMessageProcess.Enabled = True
    Else
        MnuMessageProcess.Enabled = False
    End If

End Sub

Private Sub Log_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)

    If Button = vbRightButton Then
        PopupMenu MnuLog
    End If

End Sub

'*****************************************************************************
'***ZIP PROCESSING EVENTS*****************************************************
'*****************************************************************************

Private Sub XceedZip1_FileStatus(ByVal sFilename As String, ByVal lSize As Long, ByVal lCompressedSize As Long, ByVal lBytesProcessed As Long, ByVal nBytesPercent As Integer, ByVal nCompressionRatio As Integer, ByVal bFileCompleted As Boolean)

    StatusBar1.Panels(1).Text = sFilename & " (" & nBytesPercent & "%)"

End Sub

Private Sub XceedZip1_ProcessCompleted(ByVal lFilesTotal As Long, ByVal lFilesProcessed As Long, ByVal lFilesSkipped As Long, ByVal lBytesTotal As Long, ByVal lBytesProcessed As Long, ByVal lBytesSkipped As Long, ByVal lBytesOutput As Long, ByVal nCompressionRatio As Integer, ByVal xResult As XceedZipLibCtl.xcdError)

    AddLog lFilesProcessed & " files (" & FormatNumber(lBytesProcessed, 0, , , vbTrue) & " bytes) unzipped"
    
    TotalFiles = TotalFiles + lFilesProcessed
    TotalBytes = TotalBytes + lBytesProcessed

End Sub
