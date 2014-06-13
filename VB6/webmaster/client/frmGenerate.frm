VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomctl.ocx"
Begin VB.Form frmGenerate 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Generate Page(s)"
   ClientHeight    =   4995
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   5235
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4995
   ScaleWidth      =   5235
   ShowInTaskbar   =   0   'False
   Begin VB.ListBox Log 
      Height          =   2400
      Left            =   60
      TabIndex        =   3
      Top             =   2520
      Width           =   5115
   End
   Begin MSComctlLib.ListView List 
      Height          =   2415
      Left            =   60
      TabIndex        =   0
      Top             =   60
      Width           =   3735
      _ExtentX        =   6588
      _ExtentY        =   4260
      View            =   2
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      Checkboxes      =   -1  'True
      FullRowSelect   =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   0
   End
   Begin VB.CommandButton CancelButton 
      Cancel          =   -1  'True
      Caption         =   "&Close"
      Height          =   375
      Left            =   3900
      TabIndex        =   2
      Top             =   540
      Width           =   1215
   End
   Begin VB.CommandButton OKButton 
      Caption         =   "&Generate"
      Default         =   -1  'True
      Height          =   375
      Left            =   3900
      TabIndex        =   1
      Top             =   120
      Width           =   1215
   End
   Begin VB.Menu mnuGenerate 
      Caption         =   "Generate"
      Visible         =   0   'False
      Begin VB.Menu mnuGenerateOptions 
         Caption         =   "Select All"
         Index           =   0
      End
      Begin VB.Menu mnuGenerateOptions 
         Caption         =   "Clear All"
         Index           =   1
      End
      Begin VB.Menu mnuGenerateOptions 
         Caption         =   "-"
         Index           =   2
      End
      Begin VB.Menu mnuGenerateOptions 
         Caption         =   "Generate Selected Pages"
         Enabled         =   0   'False
         Index           =   3
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

    Icon = frmMain.Icon

End Sub

Private Sub Form_Activate()

    Dim File As ProjectFile

    If Project.ProjectFiles.Count = 0 Then
        MsgBox "There are no files defined in this project"
        Exit Sub
    End If

    Log.Clear
    List.ListItems.Clear

    For Each File In Project.ProjectFiles
        List.ListItems.Add , File.FileName, File.FileName
        List.ListItems(File.FileName).Checked = True
    Next File

End Sub

Private Sub List_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Dim c As Integer, Item As ListItem

    If Button = vbRightButton Then
    
        For Each Item In List.ListItems
            If Item.Checked = True Then c = c + 1
        Next Item
    
        If c > 0 Then
            mnuGenerateOptions(3).Enabled = True
        Else
            mnuGenerateOptions(3).Enabled = False
        End If
    
        PopupMenu mnuGenerate

    End If

End Sub

Private Sub mnuGenerateOptions_Click(Index As Integer)

    Dim Item As ListItem

    Select Case Index
    Case 0  'Select all
    
        For Each Item In List.ListItems
            Item.Checked = True
        Next Item
    
    Case 1  'Clear all
    
        For Each Item In List.ListItems
            Item.Checked = False
        Next Item
    
    Case 3  'Generate selected pages
    
        Call Generate
    
    End Select

End Sub

Private Sub OKButton_Click()

    Log.Clear
    
    Call Generate

End Sub

Private Sub CancelButton_Click()

    Me.Hide

End Sub

Private Sub Generate()

    Dim Item As ListItem

    For Each Item In List.ListItems
    
        If Item.Checked = True Then
            Call GeneratePage(Item.Text)
        End If
    
    Next Item


End Sub

Private Sub Log_DblClick()

    Shell Log.Text, vbMaximizedFocus

End Sub

