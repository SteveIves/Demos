VERSION 5.00
Begin VB.Form frmOptions 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Options"
   ClientHeight    =   6360
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   3990
   Icon            =   "frmOptions.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6360
   ScaleWidth      =   3990
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.Frame Frame4 
      Caption         =   "Transform Options"
      Height          =   1155
      Left            =   180
      TabIndex        =   18
      Top             =   4620
      Width           =   3615
      Begin VB.TextBox TransformDir 
         Height          =   345
         Left            =   960
         TabIndex        =   9
         Top             =   600
         Width           =   2535
      End
      Begin VB.CheckBox optTransform 
         Caption         =   "Check1"
         Height          =   195
         Left            =   300
         TabIndex        =   8
         Top             =   300
         Width           =   195
      End
      Begin VB.Label Label3 
         Caption         =   "Directory"
         Height          =   315
         Left            =   240
         TabIndex        =   20
         Top             =   660
         Width           =   735
      End
      Begin VB.Label Label2 
         Caption         =   "Copy files to Transform directory"
         Height          =   255
         Left            =   600
         TabIndex        =   19
         Top             =   300
         Width           =   2355
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "General Options"
      Height          =   1455
      Left            =   180
      TabIndex        =   17
      Top             =   120
      Width           =   3615
      Begin VB.CheckBox optPreserveZip 
         Caption         =   "Keep ZIP files after processing"
         Enabled         =   0   'False
         Height          =   255
         Left            =   300
         TabIndex        =   2
         Top             =   960
         Width           =   2715
      End
      Begin VB.CheckBox optDeleteMessage 
         Caption         =   "Delete messages after processing"
         Height          =   255
         Left            =   300
         TabIndex        =   1
         Top             =   660
         Width           =   2715
      End
      Begin VB.CheckBox optUnreadOnly 
         Caption         =   "Only display unread messages"
         Height          =   255
         Left            =   300
         TabIndex        =   0
         Top             =   360
         Value           =   1  'Checked
         Width           =   2715
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "E-Mail Profile Options"
      Height          =   1395
      Left            =   180
      TabIndex        =   14
      Top             =   1680
      Width           =   3615
      Begin VB.TextBox MailPassword 
         Height          =   315
         IMEMode         =   3  'DISABLE
         Left            =   1560
         PasswordChar    =   "*"
         TabIndex        =   4
         Top             =   780
         Width           =   1815
      End
      Begin VB.TextBox MailProfile 
         Height          =   315
         Left            =   1560
         TabIndex        =   3
         Top             =   360
         Width           =   1815
      End
      Begin VB.Label Label1 
         Caption         =   "Profile Password"
         Height          =   255
         Index           =   1
         Left            =   240
         TabIndex        =   16
         Top             =   840
         Width           =   1275
      End
      Begin VB.Label Label1 
         Caption         =   "Profile Name"
         Height          =   255
         Index           =   0
         Left            =   240
         TabIndex        =   15
         Top             =   360
         Width           =   1275
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "If files exist in target directory"
      Height          =   1335
      Left            =   180
      TabIndex        =   13
      Top             =   3180
      Width           =   3615
      Begin VB.OptionButton optOverWrite 
         Caption         =   "Overwrite duplicate files"
         Height          =   255
         Index           =   2
         Left            =   360
         TabIndex        =   7
         Top             =   900
         Width           =   2115
      End
      Begin VB.OptionButton optOverWrite 
         Caption         =   "Delete existing files"
         Height          =   255
         Index           =   1
         Left            =   360
         TabIndex        =   6
         Top             =   600
         Width           =   2115
      End
      Begin VB.OptionButton optOverWrite 
         Caption         =   "Ask operator"
         Height          =   255
         Index           =   0
         Left            =   360
         TabIndex        =   5
         Top             =   300
         Value           =   -1  'True
         Width           =   2115
      End
   End
   Begin VB.CommandButton bHelp 
      Caption         =   "&Help"
      Height          =   375
      Left            =   2700
      TabIndex        =   12
      Top             =   5880
      Width           =   1215
   End
   Begin VB.CommandButton bCancel 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   1380
      TabIndex        =   11
      Top             =   5880
      Width           =   1215
   End
   Begin VB.CommandButton bOK 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   375
      Left            =   60
      TabIndex        =   10
      Top             =   5880
      Width           =   1215
   End
End
Attribute VB_Name = "frmOptions"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Public OverWrite As Long

Private Sub Form_Load()

    'Load current config settings into dialog
    MailProfile.Text = frmMain.MailProfile
    MailPassword.Text = frmMain.MailPassword
    OverWrite = frmMain.FileOverwrite
    optOverWrite.Item(OverWrite).Value = True
    optUnreadOnly.Value = frmMain.UnreadOnly
    optPreserveZip.Value = frmMain.PreserveZip
    optDeleteMessage.Value = frmMain.DeleteMessage
    optTransform.Value = frmMain.TransformProcessing
    With TransformDir
        .Text = frmMain.TransformDir
        .Enabled = CBool(optTransform.Value)
    End With

End Sub

Private Sub bOK_Click()

    If TransformDir.Text <> "" Then
    
        TransformDir.Text = UCase(TransformDir.Text)

        If Right(TransformDir.Text, 1) <> "\" Then
            TransformDir.Text = TransformDir.Text & "\"
        End If

        On Error GoTo ErrorHandler
        If Dir(TransformDir.Text & ".", vbDirectory) = "" Then
            If MsgBox(TransformDir.Text & " does not exist. Create it now?", vbYesNo + vbQuestion + vbDefaultButton1, "Create Directory?") = vbYes Then
                MkDir TransformDir.Text
            Else
                Exit Sub
            End If
        End If
    
    End If

    'Save values to configuration variables
    frmMain.MailProfile = MailProfile.Text
    frmMain.MailPassword = MailPassword.Text
    frmMain.FileOverwrite = OverWrite
    frmMain.UnreadOnly = optUnreadOnly.Value
    frmMain.PreserveZip = optPreserveZip.Value
    frmMain.DeleteMessage = optDeleteMessage.Value
    frmMain.TransformProcessing = optTransform.Value
    frmMain.TransformDir = TransformDir.Text
    
    'Save values to registry
    
    If MailProfile.Text = "" Then
        SaveSettingString HKEY_LOCAL_MACHINE, frmMain.RegPath, "MailProfile", ""
    Else
        SaveSettingString HKEY_LOCAL_MACHINE, frmMain.RegPath, "MailProfile", MailProfile.Text
    End If
    
    If MailPassword.Text = "" Then
        SaveSettingString HKEY_LOCAL_MACHINE, frmMain.RegPath, "MailPassword", ""
    Else
        SaveSettingString HKEY_LOCAL_MACHINE, frmMain.RegPath, "MailPassword", MailPassword.Text
    End If
    
    SaveSettingLong HKEY_LOCAL_MACHINE, frmMain.RegPath, "FileOverwrite", OverWrite
    SaveSettingLong HKEY_LOCAL_MACHINE, frmMain.RegPath, "UnreadOnly", optUnreadOnly.Value
    SaveSettingLong HKEY_LOCAL_MACHINE, frmMain.RegPath, "PreserveZip", optPreserveZip.Value
    SaveSettingLong HKEY_LOCAL_MACHINE, frmMain.RegPath, "DeleteMessage", optDeleteMessage.Value

    SaveSettingLong HKEY_LOCAL_MACHINE, frmMain.RegPath, "TransformProcessing", optTransform.Value
    
    If TransformDir.Text = "" Then
        SaveSettingString HKEY_LOCAL_MACHINE, frmMain.RegPath, "TransformDir", ""
    Else
        SaveSettingString HKEY_LOCAL_MACHINE, frmMain.RegPath, "TransformDir", TransformDir.Text
    End If

    Unload Me

ErrorHandler:

    Select Case Err.Number
    Case 52:
        MsgBox "Invalid drive specification", vbOKOnly + vbExclamation, "Error"
    End Select

End Sub

Private Sub bCancel_Click()

    Unload Me
    
End Sub

Private Sub bHelp_Click()

    MsgBox "Help is not implemented yet!"

End Sub

Private Sub optOverWrite_Click(Index As Integer)

    OverWrite = Index

End Sub

Private Sub optTransform_Click()

    TransformDir.Enabled = CBool(optTransform.Value)

End Sub
