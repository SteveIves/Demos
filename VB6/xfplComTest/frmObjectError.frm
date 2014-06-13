VERSION 5.00
Begin VB.Form frmObjectError 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Fatal Error"
   ClientHeight    =   2730
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   6105
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2730
   ScaleWidth      =   6105
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame Frame1 
      Height          =   2490
      Left            =   135
      TabIndex        =   1
      Top             =   90
      Width           =   4470
      Begin VB.Label Label1 
         Caption         =   $"frmObjectError.frx":0000
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   2085
         Left            =   270
         TabIndex        =   2
         Top             =   270
         Width           =   3885
      End
   End
   Begin VB.CommandButton bOK 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   420
      Left            =   4815
      TabIndex        =   0
      Top             =   180
      Width           =   1095
   End
End
Attribute VB_Name = "frmObjectError"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Form_Load()

    'Center a dialog on the main application window
    Top = (frmMain.Top + (frmMain.Height / 2) - (Height / 2))
    Left = (frmMain.Left + (frmMain.Width / 2) - (Width / 2))

End Sub

Private Sub bOK_Click()
    
    Unload Me

End Sub

