VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{3902390A-74D8-11D3-8536-00104B3FEBDA}#3.0#0"; "PsgMenu.ocx"
Begin VB.Form frmMain 
   Caption         =   "PsgMenu.Explorer Test Container"
   ClientHeight    =   6705
   ClientLeft      =   165
   ClientTop       =   735
   ClientWidth     =   9855
   LinkTopic       =   "Form1"
   ScaleHeight     =   6705
   ScaleWidth      =   9855
   StartUpPosition =   3  'Windows Default
   Begin PsgMenu.Explorer Explorer1 
      Height          =   5535
      Left            =   720
      TabIndex        =   2
      Top             =   720
      Width           =   8535
      _ExtentX        =   15055
      _ExtentY        =   9763
   End
   Begin MSComctlLib.StatusBar StatusBar1 
      Align           =   2  'Align Bottom
      Height          =   375
      Left            =   0
      TabIndex        =   1
      Top             =   6330
      Width           =   9855
      _ExtentX        =   17383
      _ExtentY        =   661
      Style           =   1
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   1
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.Toolbar Toolbar1 
      Align           =   1  'Align Top
      Height          =   630
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   9855
      _ExtentX        =   17383
      _ExtentY        =   1111
      ButtonWidth     =   609
      ButtonHeight    =   953
      Appearance      =   1
      _Version        =   393216
   End
   Begin VB.Menu MnuFile 
      Caption         =   "&File"
      Begin VB.Menu MnuFileExit 
         Caption         =   "E&xit"
      End
   End
   Begin VB.Menu MnuTest 
      Caption         =   "&Test"
      Begin VB.Menu MnuDispHead 
         Caption         =   "Display &Headings"
         Checked         =   -1  'True
      End
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Form_Load()

    With Explorer1
        .Top = Toolbar1.Height + 1
        .Left = 1
    End With

    Explorer1.TreeHeading = "Tree Heading"
    Explorer1.ListHeading = "ListHeading"

    Explorer1.AddRootNode "Root Node"

    Explorer1.AddFolderNode "ROOT", "FOLDER1", "Folder 1"
    Explorer1.AddFolderNode "ROOT", "FOLDER2", "Folder 2"
    Explorer1.AddFolderNode "ROOT", "FOLDER3", "Folder 3"

    Explorer1.AddFolderNode "FOLDER1", "F1S1", "Folder 1 Subfolder 1"

    Explorer1.AddNode "FOLDER1", "F1I1", "Folder 1 Item 1"
    Explorer1.AddNode "FOLDER1", "F1I2", "Folder 1 Item 2"
    Explorer1.AddNode "FOLDER1", "F1I3", "Folder 1 Item 3"

    Explorer1.AddNode "FOLDER2", "F2I1", "Folder 2 Item 1"
    Explorer1.AddNode "FOLDER2", "F2I2", "Folder 2 Item 2"
    Explorer1.AddNode "FOLDER2", "F2I3", "Folder 2 Item 3"

    Explorer1.AddNode "FOLDER3", "F3I1", "Folder 3 Item 1"
    Explorer1.AddNode "FOLDER3", "F3I2", "Folder 3 Item 2"
    Explorer1.AddNode "FOLDER3", "F3I3", "Folder 3 Item 3"

    Explorer1.SetInitialDisplay

End Sub

Private Sub Form_Resize()

    With Explorer1
        .Width = Width
        .Height = Height - Toolbar1.Height - StatusBar1.Height
    End With

End Sub

Private Sub MnuDispHead_Click()

    If Explorer1.ShowHeading = True Then
        Explorer1.ShowHeading = False
        MnuDispHead.Checked = False
    Else
        Explorer1.ShowHeading = True
        MnuDispHead.Checked = True
    End If

End Sub

Private Sub MnuFileExit_Click()

    End

End Sub

Private Sub Explorer1_LoadListItems(TreeKey As String)

    MsgBox "Load list items for tree key " & TreeKey

End Sub

Private Sub Explorer1_ItemSelected(Key As String)

    MsgBox "Item " & Key & " was selected"

End Sub


