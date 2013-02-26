VERSION 5.00
Begin VB.UserControl UsrWizardWEB 
   ClientHeight    =   5805
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   6495
   ScaleHeight     =   5805
   ScaleWidth      =   6495
   Begin VB.CheckBox ChkWeb 
      Caption         =   "Do you required Web enablement components ?"
      Height          =   495
      Left            =   720
      TabIndex        =   0
      Top             =   1920
      Width           =   4095
   End
   Begin VB.Frame Frame1 
      Height          =   2415
      Left            =   120
      TabIndex        =   6
      Top             =   960
      Width           =   6255
   End
   Begin VB.CommandButton CmdFinish 
      Caption         =   "Finish"
      Enabled         =   0   'False
      Height          =   375
      Left            =   5160
      TabIndex        =   4
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton CmdNext 
      Caption         =   "Next>"
      Height          =   375
      Left            =   3840
      TabIndex        =   3
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton CmdPrev 
      Caption         =   "<Previous"
      Height          =   375
      Left            =   2520
      TabIndex        =   2
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton CmdCancel 
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   1200
      TabIndex        =   1
      Top             =   5280
      Width           =   1215
   End
   Begin VB.PictureBox Picture1 
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BackColor       =   &H8000000A&
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   480
      Left            =   480
      Picture         =   "UsrWizardWEB.ctx":0000
      ScaleHeight     =   480
      ScaleWidth      =   480
      TabIndex        =   5
      Top             =   240
      Width           =   480
   End
   Begin VB.Frame Frame2 
      Height          =   855
      Left            =   120
      TabIndex        =   8
      Top             =   0
      Width           =   6135
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Caption         =   "Web-enabling Technologies"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   840
         TabIndex        =   9
         Top             =   360
         Width           =   4335
      End
   End
   Begin VB.Label Label1 
      Caption         =   $"UsrWizardWEB.ctx":0442
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1455
      Left            =   120
      TabIndex        =   7
      Top             =   3600
      Width           =   6255
   End
End
Attribute VB_Name = "UsrWizardWEB"
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



Public Property Get WEBRequired() As Variant
    WEBRequired = ChkWeb.Value
End Property

Public Property Let WEBRequired(ByVal vNewValue As Variant)
    'read only
End Property
