VERSION 5.00
Begin VB.UserControl Image 
   BackStyle       =   0  'Transparent
   ClientHeight    =   3600
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4800
   ScaleHeight     =   3600
   ScaleWidth      =   4800
   Begin VB.Image ImageControl 
      Height          =   2295
      Left            =   480
      Stretch         =   -1  'True
      Top             =   600
      Width           =   3135
   End
End
Attribute VB_Name = "Image"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

Private Sub UserControl_Resize()

    With ImageControl
        .Top = 1
        .Left = 1
        .Height = Height
        .Width = Width
    End With

End Sub

Public Property Let Picture(ByVal NewPicture As String)

    Dim x As Picture
    Set x = LoadPicture(NewPicture)
    ImageControl.Picture = x
    PropertyChanged "Picture"

End Property

Public Property Let Stretch(ByVal NewStretch As Integer)

    ImageControl.Stretch = CBool(NewStretch)
    PropertyChanged "Stretch"

End Property

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
