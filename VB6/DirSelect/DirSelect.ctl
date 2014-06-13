VERSION 5.00
Begin VB.UserControl DirSelect 
   ClientHeight    =   3885
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   5820
   DefaultCancel   =   -1  'True
   ScaleHeight     =   3885
   ScaleWidth      =   5820
   Begin VB.TextBox SelectedValue 
      Enabled         =   0   'False
      Height          =   315
      Left            =   60
      TabIndex        =   4
      Top             =   60
      Width           =   5655
   End
   Begin VB.CommandButton btnCancel 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   315
      Left            =   4560
      TabIndex        =   3
      Top             =   3480
      Width           =   1035
   End
   Begin VB.CommandButton btnOK 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   315
      Left            =   3420
      TabIndex        =   2
      Top             =   3480
      Width           =   1035
   End
   Begin VB.DirListBox Dir 
      Height          =   3015
      Left            =   60
      TabIndex        =   0
      Top             =   420
      Width           =   5655
   End
   Begin VB.DriveListBox Drive 
      Height          =   315
      Left            =   60
      TabIndex        =   1
      Top             =   3480
      Width           =   3195
   End
End
Attribute VB_Name = "DirSelect"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

Public Event DirSelect(Path As String)
Public Event DirCancel()

Private Sub UserControl_Initialize()
    SelectedValue.Text = Dir.Path
End Sub

Private Sub Dir_Change()
    SelectedValue.Text = Dir.Path
End Sub

Private Sub Drive_Change()
    Dir.Path = Drive.Drive
    SelectedValue.Text = Dir.Path
End Sub

Private Sub btnOK_Click()
    RaiseEvent DirSelect(Dir.Path)
End Sub

Private Sub btnCancel_Click()
    RaiseEvent DirCancel
End Sub

Public Property Get Path() As String
    Path = Dir.Path
End Property

Public Property Let Path(ByVal NewPath As String)
    Dir.Path = NewPath
    Drive.Drive = NewPath
    SelectedValue.Text = Dir.Path
End Property
