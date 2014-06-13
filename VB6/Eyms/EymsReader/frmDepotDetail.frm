VERSION 5.00
Begin VB.Form frmDepotDetail 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Depot Details"
   ClientHeight    =   2490
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   6135
   Icon            =   "frmDepotDetail.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2490
   ScaleWidth      =   6135
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.TextBox TransformDepotCode 
      Height          =   315
      Left            =   1920
      TabIndex        =   3
      Top             =   1440
      Width           =   495
   End
   Begin VB.TextBox DepotName 
      Height          =   315
      Left            =   1920
      TabIndex        =   1
      Top             =   600
      Width           =   3975
   End
   Begin VB.TextBox DepotDataDir 
      Height          =   315
      Left            =   1920
      TabIndex        =   2
      Top             =   1020
      Width           =   3975
   End
   Begin VB.TextBox DepotCode 
      Height          =   315
      Left            =   1920
      TabIndex        =   0
      Top             =   180
      Width           =   615
   End
   Begin VB.CommandButton bHelp 
      Caption         =   "&Help"
      Height          =   375
      Left            =   4740
      TabIndex        =   6
      Top             =   1920
      Width           =   1215
   End
   Begin VB.CommandButton bCancel 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   3420
      TabIndex        =   5
      Top             =   1920
      Width           =   1215
   End
   Begin VB.CommandButton bOK 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   375
      Left            =   2100
      TabIndex        =   4
      Top             =   1920
      Width           =   1215
   End
   Begin VB.Label Label1 
      Caption         =   "Transform Depot Code"
      Height          =   255
      Index           =   3
      Left            =   180
      TabIndex        =   10
      Top             =   1440
      Width           =   1635
   End
   Begin VB.Label Label1 
      Caption         =   "Base Data Directory"
      Height          =   255
      Index           =   2
      Left            =   180
      TabIndex        =   9
      Top             =   1020
      Width           =   1635
   End
   Begin VB.Label Label1 
      Caption         =   "Depot Name"
      Height          =   255
      Index           =   1
      Left            =   180
      TabIndex        =   8
      Top             =   600
      Width           =   1635
   End
   Begin VB.Label Label1 
      Caption         =   "Depot Code"
      Height          =   255
      Index           =   0
      Left            =   180
      TabIndex        =   7
      Top             =   180
      Width           =   1635
   End
End
Attribute VB_Name = "frmDepotDetail"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit

Private Sub Form_Load()

    'If we're in edit mode then disable the depot code field and load the
    'data from th depot list on the previous dialog.

    If frmDepot.EditMode = True Then
        DepotCode.Enabled = False
        DepotCode.Text = frmDepot.DepotList.SelectedItem.Key
        DepotName.Text = frmDepot.DepotList.SelectedItem.SubItems(1)
        DepotDataDir.Text = frmDepot.DepotList.SelectedItem.SubItems(2)
        TransformDepotCode.Text = frmDepot.DepotList.SelectedItem.SubItems(3)
    End If

End Sub

Private Sub bOK_Click()

    'Check we have valid data
    If DepotCode.Text = "" Or DepotName.Text = "" Or DepotDataDir.Text = "" Or TransformDepotCode.Text = "" Then
        MsgBox "You must complete all fields!", vbOKOnly + vbExclamation, "Error"
        Exit Sub
    End If

    'Make sure the transform depot code is a 2-digit number
    If (Len(TransformDepotCode.Text)) <> 2 Or IsNumeric(TransformDepotCode.Text) = False Then
        MsgBox "Transform depot code must be a 2-digit number!", vbOKOnly + vbExclamation, "Error"
        Exit Sub
    End If

    'Make sure the depot code is in uppercase
    DepotCode.Text = UCase(DepotCode.Text)

    'Make sure the depot data directory is in uppercase
    DepotDataDir.Text = UCase(DepotDataDir.Text)

    'Make sure the data directory has a trailing \
    If Right(DepotDataDir.Text, 1) <> "\" Then
        DepotDataDir.Text = DepotDataDir.Text & "\"
    End If

    'Make sure that the data directory exists
    On Error GoTo ErrorHandler
    If Dir(DepotDataDir.Text & ".", vbDirectory) = "" Then
        If MsgBox(DepotDataDir.Text & " does not exist. Create it now?", vbYesNo + vbQuestion + vbDefaultButton1, "Create Directory?") = vbYes Then
            MkDir DepotDataDir.Text
        Else
            Exit Sub
        End If
    End If

    If frmDepot.AddMode = True Then
    
        'Add new depot into depot list
        frmDepot.DepotList.ListItems.Add , DepotCode.Text, DepotCode.Text
        frmDepot.DepotList.ListItems(DepotCode.Text).ListSubItems.Add , , DepotName.Text
        frmDepot.DepotList.ListItems(DepotCode.Text).ListSubItems.Add , , DepotDataDir.Text
        frmDepot.DepotList.ListItems(DepotCode.Text).ListSubItems.Add , , TransformDepotCode.Text

        frmDepot.DepotList.ListItems(DepotCode.Text).Selected = True
    
    Else
    
        'Amend existing depot details in depot list
        frmDepot.DepotList.SelectedItem.SubItems(1) = DepotName.Text
        frmDepot.DepotList.SelectedItem.SubItems(2) = DepotDataDir.Text
        frmDepot.DepotList.SelectedItem.SubItems(3) = TransformDepotCode.Text
    
    End If

    'Save depot to Registry
    SaveSettingString HKEY_LOCAL_MACHINE, frmMain.RegPath & "\Depots", DepotCode.Text, DepotName.Text & "@" & DepotDataDir.Text & "|" & TransformDepotCode.Text

    Unload Me

ErrorHandler:

    Select Case Err.Number
    Case 52:
        MsgBox "Invalid drive specification", vbOKOnly + vbExclamation, "Error"
    Case 35602:
        MsgBox "That depot code already exists!", vbOKOnly + vbExclamation, "Error"
    End Select

End Sub

Private Sub bCancel_Click()

    Unload Me

End Sub

Private Sub bHelp_Click()

    MsgBox "Help is not implemented yet!"

End Sub

