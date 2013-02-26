VERSION 5.00
Begin VB.UserControl Folder 
   ClientHeight    =   4170
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   5160
   DefaultCancel   =   -1  'True
   ScaleHeight     =   4170
   ScaleWidth      =   5160
   Begin VB.CommandButton bOK 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   315
      Left            =   3690
      TabIndex        =   2
      Top             =   3150
      Width           =   1200
   End
   Begin VB.DirListBox Dir 
      Height          =   2340
      Left            =   315
      TabIndex        =   1
      Top             =   405
      Width           =   4485
   End
   Begin VB.DriveListBox Drive 
      Height          =   315
      Left            =   315
      TabIndex        =   0
      Top             =   3195
      Width           =   3045
   End
End
Attribute VB_Name = "Folder"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

Public Event FolderSelected(ByVal SelectedFolder As String)


Private Sub bOK_Click()

    RaiseEvent FolderSelected(Dir.Path)

End Sub

Private Sub Drive_Change()

    Dir.Path = Drive.Drive

End Sub

Private Sub UserControl_Resize()

    With Dir
        .Top = 100
        .Left = 100
        .Width = Width - 200
        .Height = Height - 300 - Drive.Height
    End With
    
    With Drive
        .Top = Height - .Height - 100
        .Left = 100
        .Width = Width - 1500
    End With

    With bOK
        .Top = Drive.Top
        .Left = Width - 1300
    End With

End Sub

Public Sub Resize(ByVal NewWidth As Long, ByVal NewHeight As Long)

    Dim TwipWidth, PixelWidth, TwipHeight, PixelHeight As Long
    
    'Get current dimension of control in twips
    UserControl.ScaleMode = vbTwips
    TwipWidth = UserControl.ScaleWidth
    TwipHeight = UserControl.ScaleHeight
    
    'Get current dimension of control in pixels
    UserControl.ScaleMode = vbPixels
    PixelWidth = UserControl.ScaleWidth
    PixelHeight = UserControl.ScaleHeight
    
    'Apply new twip dimensions to control
    With UserControl
        .ScaleMode = vbTwips
        .Width = NewWidth * (TwipWidth / PixelWidth)
        .Height = NewHeight * (TwipHeight / PixelHeight)
    End With

End Sub


