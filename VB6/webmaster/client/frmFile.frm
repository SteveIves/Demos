VERSION 5.00
Begin VB.Form frmFile 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Project File Properties"
   ClientHeight    =   3195
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   6030
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3195
   ScaleWidth      =   6030
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.ListBox Fields 
      Height          =   1230
      Left            =   1080
      TabIndex        =   2
      Top             =   1020
      Width           =   3495
   End
   Begin VB.TextBox Structure 
      Enabled         =   0   'False
      Height          =   315
      Left            =   1080
      TabIndex        =   1
      Top             =   600
      Width           =   3495
   End
   Begin VB.TextBox FileName 
      Height          =   315
      Left            =   1080
      TabIndex        =   0
      Top             =   180
      Width           =   3495
   End
   Begin VB.CommandButton CancelButton 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   3480
      TabIndex        =   3
      Top             =   2760
      Width           =   1215
   End
   Begin VB.CommandButton OKButton 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   375
      Left            =   4740
      TabIndex        =   4
      Top             =   2760
      Width           =   1215
   End
   Begin VB.Label Label1 
      Caption         =   "Fields"
      Height          =   195
      Index           =   2
      Left            =   240
      TabIndex        =   7
      Top             =   1080
      Width           =   800
   End
   Begin VB.Label Label1 
      Caption         =   "Structure"
      Height          =   195
      Index           =   1
      Left            =   240
      TabIndex        =   6
      Top             =   660
      Width           =   800
   End
   Begin VB.Label Label1 
      Caption         =   "File Name"
      Height          =   195
      Index           =   0
      Left            =   240
      TabIndex        =   5
      Top             =   240
      Width           =   800
   End
End
Attribute VB_Name = "frmFile"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit

Private Sub Form_Load()

    Icon = frmMain.Icon

End Sub

Private Sub Form_Activate()

    Dim c

    FileName.Text = ""

    Structure.Text = Right(frmMain.Tree.SelectedItem.Key, Len(frmMain.Tree.SelectedItem.Key) - 8)
    
    Fields.Clear
    With frmMain.List
        For c = 1 To .ListItems.Count
            If .ListItems(c).Selected Then
                Fields.AddItem .ListItems(c).Text
            End If
        Next c
    End With

End Sub

Private Sub OKButton_Click()

    Dim File As ProjectFile, c As Integer
    
    'Validate that the user has entered a file name
    If FileName.Text = "" Then
        MsgBox "Please provide a name for the web page to be generated", vbInformation, "Validation Error"
        FileName.SetFocus
        Exit Sub
    End If
    
    'Make sure that the file name has a ".asp" file extension
    If InStr(1, FileName.Text, ".asp") = 0 Then
        MsgBox "The file name must have an .asp file extension", vbInformation, "Validation Error"
        FileName.SetFocus
        Exit Sub
    End If
    
    'Make sure the file name is not already used in the project
    For Each File In Project.ProjectFiles
        If File.FileName = FileName.Text Then
            MsgBox "This project already contains a file called " & FileName.Text, vbInformation, "Validation Error"
            With FileName
                .Text = ""
                .SetFocus
            End With
            Exit Sub
        End If
    Next File
    
    'Add the file definition to the project object
    With Project
        .ProjectFiles.Add FileName.Text
        .ProjectFiles(FileName.Text).Structure = Structure.Text
        For c = 0 To Fields.ListCount - 1
            .ProjectFiles(FileName.Text).ProjectFileFields.Add Fields.List(c)
        Next c
    End With
    
    'Add the file definition to the tree
    With frmMain.Tree.Nodes
        .Add "PRJFILS", tvwChild, "PRJFIL:" & FileName.Text, FileName.Text, "CLOSED", "OPEN"
        For c = 0 To Fields.ListCount - 1
            .Add "PRJFIL:" & FileName.Text, tvwChild, "PRJFLD:" & FileName.Text & ":" & Fields.List(c), Fields.List(c), "FILE", "FILE"
        Next c
    End With

    Me.Hide

End Sub

Private Sub CancelButton_Click()

    Me.Hide

End Sub
