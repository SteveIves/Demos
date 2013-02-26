VERSION 5.00
Begin VB.UserControl UsrWizardOS 
   BackColor       =   &H80000004&
   BackStyle       =   0  'Transparent
   ClientHeight    =   5805
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   6495
   ScaleHeight     =   5805
   ScaleWidth      =   6495
   Begin SynergyQuoteWizard.UsrSysCode UsrSysCode1 
      Height          =   1575
      Left            =   840
      TabIndex        =   0
      Top             =   1440
      Width           =   4815
      _ExtentX        =   8493
      _ExtentY        =   2778
   End
   Begin VB.PictureBox Picture1 
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BackColor       =   &H8000000A&
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   480
      Left            =   480
      Picture         =   "UsrWizardOS.ctx":0000
      ScaleHeight     =   480
      ScaleWidth      =   480
      TabIndex        =   5
      TabStop         =   0   'False
      Top             =   240
      Width           =   480
   End
   Begin VB.CommandButton CmdFinish 
      Caption         =   "Finish"
      Enabled         =   0   'False
      Height          =   375
      Left            =   5160
      TabIndex        =   4
      Top             =   5280
      Width           =   1200
   End
   Begin VB.CommandButton CmdNext 
      Caption         =   "Next>"
      Height          =   375
      Left            =   3840
      TabIndex        =   3
      Top             =   5280
      Width           =   1200
   End
   Begin VB.CommandButton CmdPrev 
      Caption         =   "<Previous"
      Enabled         =   0   'False
      Height          =   375
      Left            =   2520
      TabIndex        =   2
      Top             =   5280
      Width           =   1200
   End
   Begin VB.CommandButton CmdCancel 
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   1200
      TabIndex        =   1
      Top             =   5280
      Width           =   1200
   End
   Begin VB.Frame Frame1 
      Height          =   2415
      Left            =   120
      TabIndex        =   6
      Top             =   960
      Width           =   6255
   End
   Begin VB.Frame Frame2 
      Height          =   855
      Left            =   120
      TabIndex        =   9
      Top             =   0
      Width           =   6255
      Begin VB.Label Label3 
         Alignment       =   2  'Center
         Caption         =   "Main Host Platform Selection"
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
         TabIndex        =   10
         Top             =   360
         Width           =   5295
      End
   End
   Begin VB.Label Label2 
      BackColor       =   &H8000000A&
      Caption         =   "Please select the target platform from the list"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   120
      TabIndex        =   8
      Top             =   3600
      Width           =   6255
   End
   Begin VB.Label Label1 
      Caption         =   "Label1"
      Height          =   495
      Left            =   2640
      TabIndex        =   7
      Top             =   2640
      Width           =   1215
   End
End
Attribute VB_Name = "UsrWizardOS"
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

Public Property Get OSSysCode() As Variant
    OSSysCode = UsrSysCode1.SysCode
End Property

Public Property Let OSSysCode(ByVal vNewValue As Variant)
    'read only!
End Property


Public Property Get GetCurrentSysIndex() As Variant
    GetCurrentSysIndex = UsrSysCode1.CurrentSysCode
End Property

Public Property Let GetCurrentSysIndex(ByVal vNewValue As Variant)
    'read only
End Property

