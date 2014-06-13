VERSION 5.00
Begin VB.Form frmGenerate 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Generate HTML Files"
   ClientHeight    =   5910
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   7260
   HelpContextID   =   1
   Icon            =   "frmGenerate.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5910
   ScaleWidth      =   7260
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Tag             =   "ForeVB DB=S:\Source\VB\Nss\gui\docs\WebGen.dba"
   WhatsThisButton =   -1  'True
   WhatsThisHelp   =   -1  'True
   Begin VB.Frame Frame3 
      Caption         =   "Generated Pages"
      Height          =   1725
      Left            =   90
      TabIndex        =   7
      Top             =   1755
      Width           =   7080
      Begin VB.CommandButton TransferButton 
         Caption         =   "&Transfer"
         Enabled         =   0   'False
         Height          =   375
         Left            =   5700
         TabIndex        =   12
         Top             =   1140
         Width           =   1215
      End
      Begin VB.CommandButton EditButton 
         Caption         =   "&Edit"
         Enabled         =   0   'False
         Height          =   375
         Left            =   5715
         TabIndex        =   8
         Top             =   720
         Width           =   1215
      End
      Begin VB.CommandButton ViewButton 
         Caption         =   "&View"
         Enabled         =   0   'False
         Height          =   375
         Left            =   5715
         TabIndex        =   4
         Top             =   270
         Width           =   1215
      End
      Begin VB.ListBox Results 
         BackColor       =   &H8000000F&
         Enabled         =   0   'False
         Height          =   960
         Left            =   180
         Style           =   1  'Checkbox
         TabIndex        =   3
         TabStop         =   0   'False
         Top             =   270
         Width           =   5325
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "Generation Log"
      Height          =   2265
      Left            =   90
      TabIndex        =   5
      Top             =   3600
      Width           =   7080
      Begin VB.CommandButton CloseButton 
         Cancel          =   -1  'True
         Caption         =   "&Close"
         Height          =   375
         Left            =   5715
         TabIndex        =   10
         Top             =   1710
         Width           =   1215
      End
      Begin VB.CommandButton ClearButton 
         Caption         =   "Clear &Log"
         Height          =   375
         Left            =   5715
         TabIndex        =   9
         Top             =   270
         Width           =   1215
      End
      Begin VB.ListBox Log 
         Height          =   1815
         Left            =   180
         TabIndex        =   6
         TabStop         =   0   'False
         Top             =   270
         Width           =   5325
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Templates to Process"
      Height          =   1635
      Left            =   90
      TabIndex        =   0
      Top             =   45
      Width           =   7080
      Begin VB.CommandButton EditTemplateButton 
         Caption         =   "&Edit"
         Enabled         =   0   'False
         Height          =   375
         Left            =   5715
         TabIndex        =   11
         Top             =   765
         Width           =   1215
      End
      Begin VB.CommandButton GenerateButton 
         Caption         =   "&Generate"
         Default         =   -1  'True
         Height          =   375
         Left            =   5715
         TabIndex        =   2
         Top             =   270
         Width           =   1215
      End
      Begin VB.ListBox TplLst 
         Height          =   1185
         ItemData        =   "frmGenerate.frx":0442
         Left            =   180
         List            =   "frmGenerate.frx":0444
         Style           =   1  'Checkbox
         TabIndex        =   1
         Top             =   270
         Width           =   5325
      End
   End
   Begin VB.Menu mnuTOptHead 
      Caption         =   "Template List Options"
      Visible         =   0   'False
      Begin VB.Menu mnuTOpt 
         Caption         =   "Select All"
         Index           =   0
      End
      Begin VB.Menu mnuTOpt 
         Caption         =   "Unselect All"
         Index           =   1
      End
      Begin VB.Menu mnuTOpt 
         Caption         =   "Reverse Selection"
         Index           =   2
      End
   End
End
Attribute VB_Name = "frmGenerate"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit

Private Sub Form_Load()

    Dim TemplateCount, c As Integer

    'Disable logging controls if logging is disabled in project properties
    If fProperties.chkLog.Value = 0 Then
        Log.Enabled = False
        Log.BackColor = vbButtonFace
        ClearButton.Enabled = False
        Log.AddItem ("Loging is disabled in project properties")
    End If
    
    'Load template list with templates from project properties dialog
    TemplateCount = fProperties.lstTemplates.ListCount
    For c = 0 To TemplateCount - 1
        With TplLst
            .AddItem fProperties.lstTemplates.List(c)
            .Selected(c) = True
            .ListIndex = 0
        End With
    Next

    'Size the Ftp arrays big enough to hold data for each template.  Each
    'template can have 2 target files (TARGET1 and TARGET2), so the arrays
    'need to be twice as big as the number of templates in the project.

    ReDim FtpUrlArray(1 To (TemplateCount * 2))
    ReDim FtpDirArray(1 To (TemplateCount * 2))
    ReDim FtpTargetFileArray(1 To (TemplateCount * 2))
    ReDim FtpUsernameArray(1 To (TemplateCount * 2))
    ReDim FtpPasswordArray(1 To (TemplateCount * 2))

    EditTemplateButton.Enabled = CBool((ToolEditor <> "") _
                        And (fProperties.chkAllowEdit.Value = 1))

End Sub

Private Sub Form_Unload(Cancel As Integer)

    TplLst.Clear
    Log.Clear

End Sub

Private Sub GenerateButton_Click()

    'Disable all components in the results box
    With Results
        .Clear
        .BackColor = vbButtonFace
        .Enabled = False
    End With
    ViewButton.Enabled = False
    EditButton.Enabled = False
    TransferButton.Enabled = False

    GenerateProject

    'Enable components in the results list box as appropriate
    If Results.ListCount > 0 Then
        'We have files generated!
        With Results
            .BackColor = vbWindowBackground
            .Enabled = True
            .Selected(0) = True
        End With
        ViewButton.Enabled = CBool(ToolBrowser <> "")
        EditButton.Enabled = CBool((ToolEditor <> "") _
                            And fProperties.chkAllowEdit.Value = 1)
        TransferButton.Enabled = CBool(fProperties.chkAllowFtp.Value)
        If TransferButton.Enabled = True Then
            TransferButton.SetFocus
        End If
    Else
        'No files were generated!
        CloseButton.SetFocus
    End If

End Sub

Private Sub CloseButton_Click()

    Unload Me

End Sub

Private Sub EditTemplateButton_Click()

    If TplLst.ListIndex <> -1 Then
        Dim ProcessID As Double
        ProcessID = Shell(ToolEditor & " " & TplLst.List(TplLst.ListIndex), vbNormalFocus)
    End If

End Sub

Private Sub Results_DblClick()
    
    If ToolBrowser <> "" Then
        ViewButton_Click
    End If

End Sub

Private Sub ViewButton_Click()

    If Results.ListIndex <> -1 Then
        Dim ProcessID As Double
        ProcessID = Shell(ToolBrowser & " " & Results.List(Results.ListIndex), vbNormalFocus)
    End If

End Sub

Private Sub EditButton_Click()

    If Results.ListIndex <> -1 Then
        Dim ProcessID As Double
        ProcessID = Shell(ToolEditor & " " & Results.List(Results.ListIndex), vbNormalFocus)
    End If

End Sub

Private Sub TransferButton_Click()

    Dim c As Integer
    Dim Message As String
    
    Message = "Transfer selected files to their target system. Before"
    Message = Message & Chr(13)
    Message = Message & "proceeding please ensure you have refreshed the"
    Message = Message & Chr(13)
    Message = Message & "FrontPage web, if required.  Proceed?"
    
    If MsgBox(Message, vbYesNo + vbInformation, "Reminder") = vbYes Then
        AddLog ("Beginning FTP file transfer(s)")
        For c = 1 To Results.ListCount
            If Results.Selected(c - 1) = True Then
                If FtpUrlArray(c) <> "" Then
                    FtpTransfer (c)
                End If
            End If
        Next c
        AddLog ("-----")
        AddLog ("FTP file transfer(s) complete")
        AddLog ("------------------------------------------------------------------------------------------------------------------")
    End If

End Sub

Private Sub FtpTransfer(c As Integer)

    Dim Message, FtpCommand As String

    'Make sure URL does have a trailing "/"
    If Right(FtpUrlArray(c), 1) <> "/" Then
        FtpUrlArray(c) = FtpUrlArray(c) & "/"
    End If
    
    'Make sure target directory (if any) does not have a leading "/"
    If FtpDirArray(c) <> "" Then
        If Left(FtpDirArray(c), 1) = "/" Then
            FtpDirArray(c) = Right(FtpDirArray(c), Len(FtpDirArray(c)) - 1)
        End If
    End If

    'Make sure target directory (if any) does have a trailing "/"
    If FtpDirArray(c) <> "" Then
        If Right(FtpDirArray(c), 1) <> "/" Then
            FtpDirArray(c) = FtpDirArray(c) & "/"
        End If
    End If

    'Build FTP command line: PUT input file
    FtpCommand = "PUT " & Results.List(c - 1) & " "
    
    'Add target sub-directory to command string
    If FtpDirArray(c) <> "" Then
'        FtpCommand = FtpCommand & "/" & FtpDirArray(c)
        FtpCommand = FtpCommand & FtpDirArray(c)
    End If
    
    'Add output file to command string
    FtpCommand = FtpCommand & FtpTargetFileArray(c)

    AddLog ("-----")
    AddLog ("Sending " & Results.List(c - 1))
    AddDetailLog ("URL=" & FtpUrlArray(c))
    AddDetailLog ("DIR=" & FtpDirArray(c))
    AddDetailLog ("UID=" & FtpUsernameArray(c))
    AddDetailLog ("PWD=" & FtpPasswordArray(c))
    AddDetailLog ("CMD=" & FtpCommand)

'TEMPORARY MESSAGE - REMOVE THIS CODE!!!
'MsgBox FtpCommand

    'Set off the timer to detect FTP failure
    With fMain.Timer1
        .Interval = 15000
        .Enabled = True
    End With
    
    'Set off the synchronus FTP transfer
    On Error GoTo FtpErrorHandler
    With fMain.Inet
        .URL = FtpUrlArray(c)
        .UserName = FtpUsernameArray(c)
        .Password = FtpPasswordArray(c)
        .Execute , FtpCommand
    End With
    
    'Show the "in progress" window.  The reason for doing this is that
    'it hands execution to the message window, so that we don't attempt
    'to transfer the next file before the current transfer has completed.
    'The message window is unloaded by the Inet_StateChanged event procedure
    'in frmMain when it detects that the current transfer is complete.  At
    'that point, execution continues from here and we process the next file
     
    frmMessage.Show vbModal, frmGenerate
    fMain.Inet.Execute , "CLOSE"
    
    Exit Sub

FtpErrorHandler:
    
    Message = ""

    If Err.Number Then
        Select Case Err.Number
        Case 35754:
            Message = "Unable to connect to FTP Server."
        Case Else
            Message = Err.Description
        End Select
    Else
        Message = "Unknown FTP error"
    End If

    fMain.Timer1.Enabled = False
    
    MsgBox Message, vbOKOnly + vbCritical, "Error"
    AddLog (Message)
   
End Sub

Private Sub ClearButton_Click()

    Log.Clear

End Sub

Private Sub TplLst_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)

    If Button = vbRightButton Then
    
        PopupMenu mnuTOptHead
    
    End If

End Sub

Private Sub mnuTOpt_Click(Index As Integer)

    Dim count As Integer

    Select Case Index
    Case 0:     'Select All
        If TplLst.ListCount > 0 Then
            For count = 0 To (TplLst.ListCount - 1)
                TplLst.Selected(count) = True
            Next
        End If
    Case 1:     'Unselect All
        If TplLst.ListCount > 0 Then
            For count = 0 To (TplLst.ListCount - 1)
                TplLst.Selected(count) = False
            Next
        End If
    Case 2:     'Reverse Selection
        If TplLst.ListCount > 0 Then
            For count = 0 To (TplLst.ListCount - 1)
                TplLst.Selected(count) = Not (TplLst.Selected(count))
            Next
        End If
    End Select

End Sub

