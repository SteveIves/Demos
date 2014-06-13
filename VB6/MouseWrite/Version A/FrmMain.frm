VERSION 5.00
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Begin VB.Form FrmMain 
   Caption         =   "MouseWrite"
   ClientHeight    =   7905
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   10005
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   48
      Charset         =   0
      Weight          =   700
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "FrmMain.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7905
   ScaleWidth      =   10005
   StartUpPosition =   3  'Windows Default
   WindowState     =   2  'Maximized
   Begin RichTextLib.RichTextBox Display 
      Height          =   2595
      Left            =   180
      TabIndex        =   0
      Top             =   180
      Width           =   6555
      _ExtentX        =   11562
      _ExtentY        =   4577
      _Version        =   393217
      Enabled         =   0   'False
      HideSelection   =   0   'False
      ScrollBars      =   2
      TextRTF         =   $"FrmMain.frx":0442
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "Arial"
         Size            =   72
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
End
Attribute VB_Name = "FrmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit


Private Sub Form_Load()

    With Display
        .Text = " "
        .SelStart = 0
        .SelLength = 1
    End With

    Me.Show

    FrmHelp.Show vbModal

End Sub

Private Sub Form_Resize()

    With Display
        .Top = 0
        .Left = 0
        .Height = FrmMain.ScaleHeight
        .Width = FrmMain.ScaleWidth
    End With

End Sub


Private Sub Form_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Dim NextLetter As Integer
    
    Select Case Button
    
    Case 1
        
        'Left Button - Advance Letter
        With Display
            NextLetter = Asc(Right(.Text, 1)) + 1
            If NextLetter = 33 Or NextLetter > 90 Then NextLetter = 65
            .Text = Left(.Text, Len(.Text) - 1) & Chr(NextLetter)
            .SelStart = Len(.Text) - 1
            .SelLength = 1
        End With
        
    Case 2
        
        'Right Button - Accept Character
        With Display
            .Text = .Text & " "
            .SelStart = Len(.Text) - 1
            .SelLength = 1
        End With
        
    Case 4
        
        'Middle Button - Erase Last character
        With Display
            .Text = Left(.Text, Len(.Text) - 1)
            If Len(.Text) = 0 Then
                .Text = " "
                .SelStart = 0
                .SelLength = 1
            Else
                .SelStart = Len(.Text) - 1
                .SelLength = 1
            End If
        End With
    
    End Select

End Sub

Private Sub Form_KeyPress(KeyAscii As Integer)

    'Respond to key presses
    
    Select Case KeyAscii
    
    Case 32 'Space bar
    
        With Display
            .Text = " "
            .SelStart = 1
            .SelLength = 1
        End With

    End Select

End Sub
