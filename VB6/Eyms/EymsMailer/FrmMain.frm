VERSION 5.00
Object = "{DB797681-40E0-11D2-9BD5-0060082AE372}#4.0#0"; "XceedZip.dll"
Object = "{20C62CAE-15DA-101B-B9A8-444553540000}#1.1#0"; "MSMAPI32.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "Comdlg32.ocx"
Begin VB.Form FrmMain 
   Caption         =   "EYMS - Transmit Wayfarer Data"
   ClientHeight    =   6780
   ClientLeft      =   165
   ClientTop       =   450
   ClientWidth     =   8265
   Icon            =   "FrmMain.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   6780
   ScaleWidth      =   8265
   Begin VB.CommandButton bProcess 
      Caption         =   "&Process"
      Height          =   300
      Left            =   6120
      TabIndex        =   5
      Top             =   1560
      Width           =   1200
   End
   Begin VB.CommandButton bDeselectAll 
      Caption         =   "&Deselect All"
      Height          =   300
      Left            =   6120
      TabIndex        =   4
      Top             =   1020
      Width           =   1200
   End
   Begin VB.CommandButton bSelectAll 
      Caption         =   "&Select All"
      Height          =   300
      Left            =   6120
      TabIndex        =   3
      Top             =   480
      Width           =   1200
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   7380
      Top             =   5100
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.ListBox BatchList 
      Height          =   2985
      Left            =   120
      Style           =   1  'Checkbox
      TabIndex        =   2
      Top             =   240
      Width           =   5235
   End
   Begin MSComctlLib.StatusBar StatusBar1 
      Align           =   2  'Align Bottom
      Height          =   300
      Left            =   0
      TabIndex        =   1
      Top             =   6480
      Width           =   8265
      _ExtentX        =   14579
      _ExtentY        =   529
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   3
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            AutoSize        =   1
            Object.Width           =   10478
         EndProperty
         BeginProperty Panel2 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            Style           =   6
            Alignment       =   1
            AutoSize        =   2
            Object.Width           =   1773
            MinWidth        =   1764
            TextSave        =   "12/22/99"
         EndProperty
         BeginProperty Panel3 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            Style           =   5
            Alignment       =   1
            AutoSize        =   2
            Object.Width           =   1773
            MinWidth        =   1764
            TextSave        =   "12:54 AM"
         EndProperty
      EndProperty
   End
   Begin VB.ListBox Log 
      Height          =   2790
      Left            =   60
      TabIndex        =   0
      Top             =   3600
      Width           =   5355
   End
   Begin MSMAPI.MAPIMessages MAPIMessages1 
      Left            =   5880
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
      Left            =   6600
      Top             =   5700
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
      DownloadMail    =   -1  'True
      LogonUI         =   -1  'True
      NewSession      =   0   'False
   End
   Begin XceedZipLibCtl.XceedZip XceedZip1 
      Left            =   7380
      Top             =   5760
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
   Begin VB.Menu MnuBatch 
      Caption         =   "&Batch"
      HelpContextID   =   3
      Begin VB.Menu MnuBatchProcess 
         Caption         =   "&Process Selected Batches"
      End
      Begin VB.Menu MnuBatchBar1 
         Caption         =   "-"
      End
      Begin VB.Menu MnuBatchSelectAll 
         Caption         =   "&Select All"
      End
      Begin VB.Menu MnuBatchClearAll 
         Caption         =   "&Clear All"
      End
      Begin VB.Menu MnuBatchBar2 
         Caption         =   "-"
      End
      Begin VB.Menu MnuBatchRevert 
         Caption         =   "&Re-check Actual Status"
      End
   End
   Begin VB.Menu MnuLog 
      Caption         =   "&Log"
      Begin VB.Menu MnuLogShow 
         Caption         =   "&Show Log Window"
      End
      Begin VB.Menu MnuLogClear 
         Caption         =   "&Clear Log Window"
      End
   End
   Begin VB.Menu MnuTools 
      Caption         =   "&Tools"
      Begin VB.Menu MnuToolsChangePassword 
         Caption         =   "&Change Options Password..."
      End
      Begin VB.Menu MnuToolsOptions 
         Caption         =   "&Options..."
      End
   End
   Begin VB.Menu MnuHelp 
      Caption         =   "&Help"
      Begin VB.Menu MnuHelpContents 
         Caption         =   "&Contents..."
      End
      Begin VB.Menu MnuHelpIndex 
         Caption         =   "&Index..."
      End
      Begin VB.Menu MnuHelpSearch 
         Caption         =   "&Search..."
      End
      Begin VB.Menu MnuHelpLine1 
         Caption         =   "-"
      End
      Begin VB.Menu MnuHelpOnHelp 
         Caption         =   "&Help on Using Help..."
      End
      Begin VB.Menu MnuHelpLine2 
         Caption         =   "-"
      End
      Begin VB.Menu MnuHelpAbout 
         Caption         =   "&About"
      End
   End
End
Attribute VB_Name = "FrmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

'General public variables
Public RegPath As String
Public PasswordOK As Boolean

'Configuration settings
Public BaseDataDir As String
Public DepotCode As String
Public DepotName As String
Public MailProfile As String
Public MailPassword As String
Public ToAddress  As String
Public ToName As String
Public ZipDir As String
Public DeleteZip As String
Public SetupPassword As String

'Default configuration settings
Const DefaultBaseDataDir = "C:\WayFarer\Modules\"
Const DefaultDepotCode = ""
Const DefaultDepotName = ""
Const DefaultMailProfile = ""
Const DefaultMailPassword = ""
Const DefaultToAddress = "wayfarer@eyms.swinternet.co.uk"
Const DefaultToName = "Wayfarer Controller"
Const DefaultZipDir = "C:\WayFarer\Outbound\"
Const DefaultDeleteZip = "Yes"

'**********************************************************************
'*MAIN PROCESSING ROUTINES*********************************************
'**********************************************************************

Private Sub Form_Load()

    Dim SettingWasMissing As Boolean

    If App.PrevInstance = True Then
        MsgBox "EymsMailer is already running!", vbExclamation, "Information"
        End
    End If
        
    'Setup the Registry key to be used
    RegPath = "Software\Internet Software Services\EYMS Wayfarer Mailer\1.0"

    'Restore initial window dimensions
    With FrmMain
        .Top = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "WindowTop", (Screen.Height * 0.1))
        .Left = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "WindowLeft", (Screen.Width * 0.1))
        .Width = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "WindowWidth", (Screen.Width * 0.8))
        .Height = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "WindowHeight", (Screen.Height * 0.8))
    End With
    
    'Restore log window status
    MnuLogShow.Checked = CBool(GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "LogEnabled", 0))
    
    StatusBar1.Height = 300
    
    CommonDialog1.HelpFile = App.HelpFile
    
    Me.Show
    
    'Get configuration settings from Registry
    Log.AddItem "Reading configuration settings"
    BaseDataDir = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "BaseDataDir")
    DepotCode = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "DepotCode")
    DepotName = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "DepotName")
    MailProfile = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "MailProfile")
    MailPassword = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "MailPassword")
    ToAddress = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "ToAddress")
    ToName = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "ToName")
    ZipDir = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "ZipDir")
    DeleteZip = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "DeleteZip")
    DeleteZip = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "DeleteZip")
    SetupPassword = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "SetupPassword")

    'Check to make sure that each setting was retrieved from the Registry.  If
    'not then use the default value and save it in the Registry.

    SettingWasMissing = False

    If BaseDataDir = "" Then
        SaveSettingString HKEY_LOCAL_MACHINE, RegPath, "BaseDataDir", DefaultBaseDataDir
        BaseDataDir = DefaultBaseDataDir
        SettingWasMissing = True
    End If

    If DepotCode = "" Then
        SaveSettingString HKEY_LOCAL_MACHINE, RegPath, "DepotCode", DefaultDepotCode
        DepotCode = DefaultDepotCode
        SettingWasMissing = True
    End If

    If DepotName = "" Then
        SaveSettingString HKEY_LOCAL_MACHINE, RegPath, "DepotName", DefaultDepotName
        DepotName = DefaultDepotName
        SettingWasMissing = True
    End If

    If MailProfile = "" Then
        SaveSettingString HKEY_LOCAL_MACHINE, RegPath, "MailProfile", DefaultMailProfile
        MailProfile = DefaultMailProfile
    End If

    If MailPassword = "" Then
        SaveSettingString HKEY_LOCAL_MACHINE, RegPath, "MailPassword", DefaultMailPassword
        MailPassword = DefaultMailPassword
    End If

    If ToAddress = "" Then
        SaveSettingString HKEY_LOCAL_MACHINE, RegPath, "ToAddress", DefaultToAddress
        ToAddress = DefaultToAddress
        SettingWasMissing = True
    End If

    If ToName = "" Then
        SaveSettingString HKEY_LOCAL_MACHINE, RegPath, "ToName", DefaultToName
        ToName = DefaultToName
        SettingWasMissing = True
    End If

    If ZipDir = "" Then
        SaveSettingString HKEY_LOCAL_MACHINE, RegPath, "ZipDir", DefaultZipDir
        ZipDir = DefaultZipDir
        SettingWasMissing = True
    End If

    If DeleteZip = "" Then
        SaveSettingString HKEY_LOCAL_MACHINE, RegPath, "DeleteZip", DefaultDeleteZip
        DeleteZip = DefaultDeleteZip
        SettingWasMissing = True
    End If

    If SettingWasMissing = True Then
        MsgBox "One or more configuration settings was not found." & Chr(13) & Chr(10) & "Please review the settings in the following dialog.", vbOKOnly, "Review Settings"
        frmOptions.Show vbModal
    End If

    CheckOutboundDir
    CheckBaseDataDir

    LoadBatchList

End Sub

Private Sub Form_Resize()

    If FrmMain.WindowState <> vbMinimized Then

        'Make sure that the window does not get too small!
        With Me
            If .Height < 3500 Then .Height = 3500
            If .Width < 6000 Then .Width = 6000
        End With
        
        'Reposition Batch List
        With BatchList
            .Top = 1
            .Left = 1
            .Width = FrmMain.ScaleWidth - 1300
            If MnuLogShow.Checked = False Then
                .Height = FrmMain.ScaleHeight - StatusBar1.Height - 1
            Else
                .Height = (FrmMain.ScaleHeight - StatusBar1.Height - 1) / 2
            End If
        End With
        
        'Reposition log list
        With Log
            .Top = (FrmMain.ScaleHeight - StatusBar1.Height) / 2
            .Left = 1
            .Width = FrmMain.ScaleWidth
            .Height = (FrmMain.ScaleHeight - StatusBar1.Height) / 2
            .Visible = MnuLogShow.Checked
        End With

        'Position buttons
        With bSelectAll
            .Top = 1
            .Left = Me.Width - 1350
        End With

        With bDeselectAll
            .Top = bSelectAll.Top + bSelectAll.Height + 100
            .Left = bSelectAll.Left
        End With
        
        With bProcess
            .Top = bDeselectAll.Top + bDeselectAll.Height + 100
            .Left = bSelectAll.Left
        End With

    End If

End Sub

Private Sub LoadBatchList()

    'Load (or reload) details of all data batches into the batch list

    Dim Count As Long
    Dim Mth, ThisMth As Byte
    
    Log.AddItem "Searching for Wayfarer data sets"
    
    BatchList.Clear
    
    ThisMth = Month(Now)

    'Process months from next month to end of year
    If ThisMth < 12 Then
        For Mth = ThisMth + 1 To 12
            Call LoadMonth(Mth, Count)
        Next
    End If

    'Process months from January to this month
    For Mth = 1 To ThisMth
        Call LoadMonth(Mth, Count)
    Next

    Log.AddItem "Found " & Count & " data Wayfarer data sets"

    CheckBatchStatus

    'Position to last item in list
    If BatchList.ListCount > 0 Then
        BatchList.ListIndex = BatchList.ListCount - 1
    End If

End Sub

Private Sub LoadMonth(ByVal Mth As Byte, Count As Long)

    Dim MthPrefix As String * 3
    Dim CurrentDir As String
    Dim Today As String
    
    Today = UCase(MonthName(Month(Now), True) & Format(Day(Now), "00"))

    MthPrefix = MonthName(Mth, True)
    CurrentDir = Dir(BaseDataDir & MthPrefix & "*", vbDirectory)
    
    Do While CurrentDir <> ""
        If CurrentDir <> "." And CurrentDir <> ".." Then
            If (GetAttr(BaseDataDir & CurrentDir) And vbDirectory) = vbDirectory Then
                'Got a data sub-directory.  Make sure it's not today!
                If UCase(Left(CurrentDir, 5)) <> Today Then
                    BatchList.AddItem BaseDataDir & CurrentDir & "\"
                    Count = Count + 1
                End If
            End If
        End If
        CurrentDir = Dir
    Loop


End Sub

Private Sub CheckBatchStatus()

    'Determine which batches have already been processed.  Check those
    'batches which have NOT been processed.

    Dim Count, Sent, Unsent As Long
    
    Sent = 0
    Unsent = 0

    Log.AddItem "Checking data set status"

    For Count = 0 To (BatchList.ListCount - 1)
        If Dir(BatchList.List(Count) & "zzz_data_sent") = "" Then
            BatchList.Selected(Count) = True
            Unsent = Unsent + 1
        Else
            BatchList.Selected(Count) = False
            Sent = Sent + 1
        End If
    Next

    If Unsent = 0 Then
        MnuBatchProcess.Enabled = False
        bProcess.Enabled = False
    Else
        MnuBatchProcess.Enabled = True
        bProcess.Enabled = True
    End If
    
    Log.AddItem "Found " & Unsent & " unsent and " & Sent & " sent data sets"

End Sub

Private Sub ProcessBatch(ThisBatch As String)

    On Error GoTo ErrorHandler

    Log.AddItem "------------------------------------------------------------------------------------------------------"
    Log.AddItem "Processing data set " & ThisBatch

    Me.MousePointer = vbHourglass
    
    'Declare variables
    Dim SourceFiles, ZipFile, FullZipFile As String
    Dim BatchRef, Msg As String
    Dim SubjectText, BodyText As String

    'Extract batch reference from full directory spec in batch list
    BatchRef = Left(ThisBatch, (Len(ThisBatch) - 1))
    BatchRef = Right(BatchRef, (Len(BatchRef) - Len(BaseDataDir)))
    Log.AddItem "Batch reference is " & BatchRef

    'Setup name of files to ZIP
    SourceFiles = BaseDataDir & BatchRef & "\*"
    Log.AddItem "Source file specification is " & SourceFiles

    'Setup the required ZIP file strings
    ZipFile = DepotCode & "_" & BatchRef & ".zip"
    FullZipFile = ZipDir & ZipFile
    Log.AddItem "Target ZIP file name is " & FullZipFile

    'Check if target ZIP file already exists
    Log.AddItem "Checking for existing ZIP file " & FullZipFile
    If Dir(FullZipFile) <> "" Then
        Log.AddItem "Deleting existing ZIP file " & FullZipFile
        Kill FullZipFile
    End If
    
    'Make sure we have files to work with
    If Dir(SourceFiles) = "" Then
        MsgBox "ERROR: No source files found!"
    Else
    
        'Specify path and file spec to zip.  Setting the path seperately
        'prevents the path names being stored in the resulting ZIP file
        Log.AddItem "Attempting to ZIP files"
        Dim Result As xcdError
        XceedZip1.ZipFilename = FullZipFile
        XceedZip1.BasePath = BaseDataDir & BatchRef & "\"
        XceedZip1.FilesToProcess = "*"
        XceedZip1.FilesToExclude = "zzz_data_sent"
        Result = XceedZip1.Zip

        If (Result <> xerSuccess) Then
            Msg = Str(Result)
            Log.AddItem "ERROR: Xceed ZIP error " & Msg & " was returned!"
            MsgBox Msg, vbOKOnly + vbCritical, "Error"
        Else
            
            Log.AddItem "Files zipped successfully."
            
            Log.AddItem "Composing e-mail message"

            'Setup the message text
            SubjectText = DepotCode & "_" & BatchRef & " (Wayfarer data from " & DepotName & ")"
            
            BodyText = "Attached to this message is a ZIP file called " & ZipFile & ". "
            BodyText = BodyText & "This file contains the Wayfarer data from the " & DepotName & " Depot ("
            BodyText = BodyText & DepotCode & ") for " & BatchRef & "."
            BodyText = BodyText & Chr(10) & Chr(10)
            BodyText = BodyText & "IMPORTANT:"
            BodyText = BodyText & Chr(10) & Chr(10)
            BodyText = BodyText & "This message will only be processed if it remains "
            BodyText = BodyText & "in an UNREAD state. After closing the message, please "
            BodyText = BodyText & "select 'Mark As Unread' from the 'Edit' menu."
            
            'Compose the message
            MAPIMessages1.Compose
            MAPIMessages1.RecipDisplayName = ToName
            MAPIMessages1.RecipAddress = ToAddress
            MAPIMessages1.MsgSubject = SubjectText
            MAPIMessages1.MsgNoteText = BodyText
            
            Log.AddItem "Attaching ZIP file to e-mail message"
            MAPIMessages1.AttachmentPathName = FullZipFile
            
            Log.AddItem "Adding e-mail message to outbox"
            MAPIMessages1.Send False
            
            Log.AddItem "E-mail message added to outbox"
        
            'Record that we have sent this batch
            Log.AddItem "Marking batch " & BatchRef & " as sent"
            Open BaseDataDir & BatchRef & "\zzz_data_sent" For Output As #1
            Print #1, "This directory was e-mailed on " & CStr(FormatDateTime(Now, vbLongDate)) & " at " & CStr(FormatDateTime(Now, vbShortTime))
            Close #1
            
        End If
    
        If DeleteZip = "Yes" And Dir(FullZipFile) <> "" Then
            Log.AddItem "Deleting ZIP file " & FullZipFile
            Kill FullZipFile
        End If
    
    End If

    Me.MousePointer = vbDefault

    Log.AddItem "Finished processing data set " & ThisBatch

    Exit Sub
    
ErrorHandler:

    Msg = "An error occurred while processing this data set!"
    MsgBox Msg, vbOKOnly + vbCritical, "Error"
    Log.AddItem "ERROR: " & Msg

End Sub

Private Function StartMailSession() As Boolean

    'Start a MAPI session and setup MAPI environment

    'Default to success
    StartMailSession = True

    On Error GoTo ErrorHandler

    Log.AddItem "Attempting to connect to e-mail session"

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
    
    Log.AddItem "Connected to e-mail session"
    
    Exit Function

ErrorHandler:

    Dim Msg As String
    Msg = "Failed to connect to e-mail session!"
    MsgBox Msg, vbOKOnly + vbCritical, "Error"
    Log.AddItem "ERROR: " & Msg
    StartMailSession = False

End Function

Private Function EndMailSession() As Boolean
    
    'Close down the MAPI session
    
    On Error GoTo ErrorHandler
    
    'Default to success
    EndMailSession = True
    
    Log.AddItem "Attempting to disconnect from e-mail session"
    
    MAPISession1.SignOff
    
    Log.AddItem "Disconnected from e-mail session"

    Exit Function

ErrorHandler:

    Dim Msg As String
    Msg = "Failed to disconnect from e-mail session!"
    MsgBox Msg, vbOKOnly + vbCritical, "Error"
    Log.AddItem "ERROR: " & Msg
    EndMailSession = False

End Function

Private Sub CheckBaseDataDir()

    'Verify that the base data directory exists.  If not, give the user the
    'option of creating it.

    Log.AddItem "Checking that base data directory " & BaseDataDir & " exists"

    If Dir(BaseDataDir & ".", vbDirectory) = "" Then
        If MsgBox("Base data directory " & BaseDataDir & " does not exist." & Chr(13) & Chr(10) & "Would you like to create it now?", vbYesNo + vbQuestion + vbDefaultButton1, "Error") = vbYes Then
            MkDir BaseDataDir
        Else
            MsgBox "You must resolve this problem before attempting to send data!", vbOKOnly + vbCritical, "Error"
            Log.AddItem "ERROR: Base data directory " & BaseDataDir & " does not exist!"
        End If
    End If

End Sub

Private Sub CheckOutboundDir()

    'Verify that the Zip directory exists.  If not, give the user the
    'option of creating it.
    
    Log.AddItem "Checking that ZIP directory " & ZipDir & " exists"
    
    If Dir(ZipDir & ".", vbDirectory) = "" Then
        If MsgBox("Zip directory " & ZipDir & " does not exist." & Chr(13) & Chr(10) & "Would you like to create it now?", vbYesNo + vbQuestion + vbDefaultButton1, "Error") = vbYes Then
            MkDir ZipDir
        Else
            MsgBox "You must resolve this problem before attempting to send data!", vbOKOnly + vbCritical, "Error"
            Log.AddItem "ERROR: ZIP directory " & ZipDir & " does not exist!"
        End If
    End If

End Sub

Private Sub Form_Unload(Cancel As Integer)

    SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "WindowTop", FrmMain.Top
    SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "WindowLeft", FrmMain.Left
    SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "WindowHeight", FrmMain.Height
    SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "WindowWidth", FrmMain.Width

    If MnuLogShow.Checked = True Then
        SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "LogEnabled", 1
    Else
        SaveSettingLong HKEY_LOCAL_MACHINE, RegPath, "LogEnabled", 0
    End If

End Sub

Private Sub BatchSelectAll()

    'Select all data sets, regardless of actual sent status

    Dim Count As Long
    
    For Count = 0 To (BatchList.ListCount - 1)
        BatchList.Selected(Count) = True
    Next

    Log.AddItem "All data sets were manually selected"

End Sub

Private Sub BatchClearAll()

    'Deselect all data sets, regardless of actual sent status

    Dim Count As Long
    
    For Count = 0 To (BatchList.ListCount - 1)
        BatchList.Selected(Count) = False
    Next

    Log.AddItem "All data sets were manually deselected"

End Sub

Private Sub BatchProcess()

    'Process all selected data sets

    Dim Count As Long
    
    Log.AddItem "Starting processing of " & BatchList.SelCount & " selected data sets"
    
    If StartMailSession = True Then
        For Count = 0 To (BatchList.ListCount - 1)
            If BatchList.Selected(Count) = True Then
                ProcessBatch BatchList.List(Count)
            End If
        Next
        Log.AddItem "------------------------------------------------------------------------------------------------------"
        EndMailSession
    End If

    Log.AddItem "Finished processing selected data sets"

    CheckBatchStatus

End Sub

'**********************************************************************
'*MENU ENTRIES*********************************************************
'**********************************************************************

Private Sub MnuFileExit_Click()
    Unload FrmMain
End Sub

Private Sub MnuBatchProcess_Click()
    BatchProcess
End Sub

Private Sub bProcess_Click()
    BatchProcess
End Sub

Private Sub MnuBatchSelectAll_Click()
    BatchSelectAll
End Sub

Private Sub bSelectAll_Click()
    BatchSelectAll
End Sub

Private Sub MnuBatchClearAll_Click()
    BatchClearAll
End Sub

Private Sub bDeselectAll_Click()
    BatchClearAll
End Sub

Private Sub MnuBatchRevert_Click()
    LoadBatchList
End Sub

Private Sub MnuLogShow_Click()

    'Toggle status of log window

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

Private Sub MnuToolsChangePassword_Click()

    'Show change password dialog
    frmChangePassword.Show vbModal

End Sub

Private Sub MnuToolsOptions_Click()
       
    'Prompt for options password if required, then display options
    'dialog window
       
    If SetupPassword <> "" Then
        'Password required.  Password dialog changes value of
        'PasswordOK if user enters a valid password
        PasswordOK = False
        frmPassword.Show vbModal
    Else
        'Password not required
        PasswordOK = True
    End If
    
    If PasswordOK = True Then
        'Password not required, or OK.
        frmOptions.Show vbModal
        'Make sure new directories are valid
        CheckOutboundDir
        CheckBaseDataDir
    End If

End Sub

Private Sub MnuHelpContents_Click()

    With CommonDialog1
        .HelpCommand = cdlHelpContents
        .ShowHelp
    End With

End Sub

Private Sub MnuHelpIndex_Click()
    
    With CommonDialog1
        .HelpCommand = cdlHelpPartialKey
        .ShowHelp
    End With
    
End Sub

Private Sub MnuHelpSearch_Click()
    
    With CommonDialog1
        .HelpCommand = cdlHelpPartialKey
        .ShowHelp
    End With
    
End Sub

Private Sub MnuHelpOnHelp_Click()

    With CommonDialog1
        .HelpCommand = cdlHelpHelpOnHelp
        .ShowHelp
    End With

End Sub

Private Sub MnuHelpAbout_Click()

    frmAbout.Show vbModal

End Sub

'**********************************************************************
'*OTHER UI EVENTS******************************************************
'**********************************************************************

Private Sub BatchList_ItemCheck(Item As Integer)

    'In item checkbox in the batch list has changed value.  Set the
    'enabled status of the "Process" menu entry appropriately.

    If BatchList.SelCount > 0 Then
        MnuBatchProcess.Enabled = True
        bProcess.Enabled = True
    Else
        MnuBatchProcess.Enabled = False
        bProcess.Enabled = False
    End If

End Sub

Private Sub BatchList_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)

    'Right-click on batch list.  Display popup menu.

    If Button = vbRightButton Then
        PopupMenu MnuBatch
    End If

End Sub

Private Sub Log_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)

    'Right-click on log list.  Display popup menu.

    If Button = vbRightButton Then
        PopupMenu MnuLog
    End If

End Sub
