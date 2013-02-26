VERSION 5.00
Begin VB.UserControl UsrWizardWelcome 
   ClientHeight    =   5805
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   6495
   ScaleHeight     =   5805
   ScaleWidth      =   6495
   Begin VB.TextBox Text1 
      Appearance      =   0  'Flat
      BackColor       =   &H80000004&
      BorderStyle     =   0  'None
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1575
      Left            =   360
      Locked          =   -1  'True
      MultiLine       =   -1  'True
      TabIndex        =   6
      TabStop         =   0   'False
      Text            =   "UsrWizardWelcome.ctx":0000
      Top             =   3000
      Width           =   5775
   End
   Begin VB.PictureBox Picture1 
      AutoSize        =   -1  'True
      Enabled         =   0   'False
      Height          =   1605
      Left            =   1320
      Picture         =   "UsrWizardWelcome.ctx":00DD
      ScaleHeight     =   1545
      ScaleWidth      =   3690
      TabIndex        =   5
      Top             =   960
      Width           =   3750
   End
   Begin VB.CommandButton CmdCancel 
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   1200
      TabIndex        =   0
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton CmdPrev 
      Caption         =   "<Previous"
      Enabled         =   0   'False
      Height          =   375
      Left            =   2520
      TabIndex        =   1
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton CmdNext 
      Caption         =   "Next>"
      Height          =   375
      Left            =   3840
      TabIndex        =   2
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton CmdFinish 
      Caption         =   "Finish"
      Enabled         =   0   'False
      Height          =   375
      Left            =   5160
      TabIndex        =   3
      Top             =   5280
      Width           =   1215
   End
   Begin VB.Label Label2 
      Alignment       =   2  'Center
      Caption         =   "Welcome to the Synergy Quote Wizard!"
      BeginProperty Font 
         Name            =   "Times New Roman"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   240
      TabIndex        =   7
      Top             =   360
      Width           =   6015
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      AutoSize        =   -1  'True
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "Times New Roman"
         Size            =   14.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   150
      TabIndex        =   4
      Top             =   120
      Width           =   6165
   End
End
Attribute VB_Name = "UsrWizardWelcome"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Public Event closecontrol()
Public Event BackPage()
Public Event ForwardPage()
Public Event WizardFinished()
Private Sub CmdCancel_Click()
    RaiseEvent closecontrol
End Sub
Private Sub CmdFinish_Click()
    RaiseEvent WizardFinished
End Sub

Private Sub CmdNext_Click()
    RaiseEvent ForwardPage
End Sub

Private Sub CmdPrev_Click()
    RaiseEvent BackPage
End Sub


