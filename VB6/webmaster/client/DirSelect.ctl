VERSION 5.00
Begin VB.UserControl DirSelect 
   ClientHeight    =   3885
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4725
   DefaultCancel   =   -1  'True
   ScaleHeight     =   3885
   ScaleWidth      =   4725
   Begin VB.CommandButton OK 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   375
      Left            =   3600
      TabIndex        =   3
      Top             =   3420
      Width           =   1035
   End
   Begin VB.CommandButton Cancel 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   2520
      TabIndex        =   2
      Top             =   3420
      Width           =   1035
   End
   Begin VB.DirListBox Dir 
      Height          =   2790
      Left            =   120
      TabIndex        =   1
      Top             =   120
      Width           =   4455
   End
   Begin VB.DriveListBox Drive 
      Height          =   315
      Left            =   120
      TabIndex        =   0
      Top             =   3000
      Width           =   4515
   End
End
Attribute VB_Name = "DirSelect"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False

'Property variables
Private mvarDirectory As String

Public Event Cancel()
Public Event OK()

Private Sub Dir_Change()

    mvarDirectory = Dir.Path

End Sub

Private Sub Drive_Change()

    Dim SaveDrive As String

    SaveDrive = Drive.Drive

    On Error Resume Next
    Dir.Path = Drive.Drive
    
    If Err.Number = 68 Then
        MsgBox "Drive is not available"
        Drive.Drive = SaveDrive
        Dir.Path = SaveDrive
    End If
    
    On Error GoTo 0
    
    mvarDirectory = Dir.Path

End Sub

Private Sub Cancel_Click()
    
    RaiseEvent Cancel

End Sub

Private Sub OK_Click()
    RaiseEvent OK
End Sub


'Directory property
Public Property Let Directory(ByVal vNewValue As String)
    mvarDirectory = vNewValue
    Drive.Drive = vNewValue
    Dir.Path = vNewValue
End Property
Public Property Get Directory() As String
    Directory = mvarDirectory
End Property
