VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmDepot 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Remote Depots"
   ClientHeight    =   3195
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   6840
   Icon            =   "frmDepot.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3195
   ScaleWidth      =   6840
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton bDelete 
      Caption         =   "&Delete"
      Height          =   375
      Left            =   5520
      TabIndex        =   3
      Top             =   1020
      Width           =   1215
   End
   Begin VB.CommandButton bEdit 
      Caption         =   "&Edit"
      Height          =   375
      Left            =   5520
      TabIndex        =   2
      Top             =   540
      Width           =   1215
   End
   Begin VB.CommandButton bAdd 
      Caption         =   "&Add"
      Height          =   375
      Left            =   5520
      TabIndex        =   1
      Top             =   60
      Width           =   1215
   End
   Begin MSComctlLib.ListView DepotList 
      Height          =   2595
      Left            =   60
      TabIndex        =   0
      Top             =   60
      Width           =   5355
      _ExtentX        =   9446
      _ExtentY        =   4577
      View            =   3
      LabelEdit       =   1
      Sorted          =   -1  'True
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      FullRowSelect   =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   4
      BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Text            =   "Code"
         Object.Width           =   1235
      EndProperty
      BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   1
         Text            =   "Depot Name"
         Object.Width           =   3881
      EndProperty
      BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   2
         Text            =   "Data Directory"
         Object.Width           =   4145
      EndProperty
      BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   3
         Text            =   "Transform Depot"
         Object.Width           =   2540
      EndProperty
   End
   Begin VB.CommandButton bHelp 
      Caption         =   "&Help"
      Height          =   375
      Left            =   5520
      TabIndex        =   5
      Top             =   2760
      Width           =   1215
   End
   Begin VB.CommandButton bClose 
      Caption         =   "&Close"
      Default         =   -1  'True
      Height          =   375
      Left            =   4200
      TabIndex        =   4
      Top             =   2760
      Width           =   1215
   End
End
Attribute VB_Name = "frmDepot"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Public AddMode As Boolean
Public EditMode As Boolean

Private Sub Form_Load()

    'Load depots from Registry
    Dim Dlist As String
    Dim dCode, dName, dDir, dTfCode As String
    Dim Pos, Pos1 As Long
    
    'Get list of depots from Registry "DepotList" key
    Dlist = GetSettingString(HKEY_LOCAL_MACHINE, frmMain.RegPath, "DepotList")

    If Dlist <> "" Then
    
        Do
            'Extract next depot code from string
            Pos = InStr(1, Dlist, ",")
            dCode = Left(Dlist, Pos - 1)
            
            'Retrieve depot information from Registry
            dName = GetSettingString(HKEY_LOCAL_MACHINE, frmMain.RegPath & "\Depots", CStr(dCode))
            
            'Extract transform depot code
            Pos1 = InStr(1, dName, "|")
            dTfCode = Right(dName, Len(dName) - Pos1)
            dName = Left(dName, Pos1 - 1)
            
            'Extract depot data directory
            Pos1 = InStr(1, dName, "@")
            dDir = Right(dName, Len(dName) - Pos1)
            
            'Remove data directory to leave depot name
            dName = Left(dName, Pos1 - 1)
            
            'Remove this depot from depot list string
            Dlist = Right(Dlist, Len(Dlist) - Pos)
            
            'Add depot to depot list control
            DepotList.ListItems.Add , dCode, dCode
            DepotList.ListItems(dCode).ListSubItems.Add , , dName
            DepotList.ListItems(dCode).ListSubItems.Add , , dDir
            DepotList.ListItems(dCode).ListSubItems.Add , , dTfCode

            'Any more?
            If Dlist = "" Then Exit Do
        Loop
    
    End If

End Sub

Private Sub Form_Unload(Cancel As Integer)

    'This routine saves a list of depots in the registry, so that the
    'list can easily be retrieved next time round.
    
    Dim Count As Long
    Dim Dlist As String

    If DepotList.ListItems.Count > 0 Then
        For Count = 1 To DepotList.ListItems.Count
            Dlist = Dlist & DepotList.ListItems(Count).Key & ","
        Next
        SaveSettingString HKEY_LOCAL_MACHINE, frmMain.RegPath, "DepotList", Dlist
    Else
        DeleteValue HKEY_LOCAL_MACHINE, frmMain.RegPath, "DepotList"
    End If

End Sub

Private Sub bAdd_Click()

    AddMode = True
    frmDepotDetail.Show vbModal
    AddMode = False

End Sub

Private Sub bEdit_Click()

    If DepotList.ListItems.Count > 0 Then
        
        EditMode = True
        frmDepotDetail.Show vbModal
        EditMode = False
    
    End If

End Sub

Private Sub DepotList_DblClick()

    If DepotList.ListItems.Count > 0 Then
        bEdit_Click
    End If

End Sub

Private Sub bDelete_Click()

    If DepotList.ListItems.Count > 0 Then
    
        If MsgBox("Delete this depot?", vbYesNo + vbQuestion + vbDefaultButton2, "Confirm") = vbYes Then
        
            'Delete depot from registry
            DeleteValue HKEY_LOCAL_MACHINE, frmMain.RegPath & "\Depots", DepotList.SelectedItem.Key
        
            'Delete depot from list
            DepotList.ListItems.Remove (DepotList.SelectedItem.Key)
        
        End If
    
    End If

End Sub

Private Sub bClose_Click()

    Unload Me

End Sub

Private Sub bHelp_Click()

    MsgBox "Help is not yet implemented!"

End Sub

Private Sub SaveDepotList()


End Sub
