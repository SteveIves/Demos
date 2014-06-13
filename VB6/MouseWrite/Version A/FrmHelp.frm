VERSION 5.00
Begin VB.Form FrmHelp 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "MouseWrite Help"
   ClientHeight    =   2595
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   7440
   Icon            =   "FrmHelp.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2595
   ScaleWidth      =   7440
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      Caption         =   "Space Bar - New Message"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Index           =   3
      Left            =   120
      TabIndex        =   3
      Top             =   1980
      Width           =   7095
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      Caption         =   "Right Mouse Button - Advance Character"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Index           =   2
      Left            =   120
      TabIndex        =   2
      Top             =   1260
      Width           =   7095
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      Caption         =   "Middle Mouse Button - Delete Character"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Index           =   1
      Left            =   120
      TabIndex        =   1
      Top             =   720
      Width           =   7095
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      Caption         =   "Left Mouse Button - Advance Letter"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Index           =   0
      Left            =   120
      TabIndex        =   0
      Top             =   180
      Width           =   7095
   End
End
Attribute VB_Name = "FrmHelp"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_KeyPress(KeyAscii As Integer)

    Unload Me

End Sub

Private Sub Form_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    
    Unload Me

End Sub

Private Sub Label1_Click(Index As Integer)

    Unload FrmHelp

End Sub
