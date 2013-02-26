VERSION 5.00
Object = "{FE0065C0-1B7B-11CF-9D53-00AA003C9CB6}#1.0#0"; "COMCT232.OCX"
Begin VB.UserControl UsrWizardNET 
   ClientHeight    =   5805
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   6495
   ScaleHeight     =   5805
   ScaleWidth      =   6495
   Begin SynergyQuoteWizard.UsrSysCodeCmb UsrSysCodeCmb1 
      Height          =   375
      Left            =   1440
      TabIndex        =   11
      Top             =   2520
      Width           =   4695
      _ExtentX        =   8281
      _ExtentY        =   661
   End
   Begin VB.CheckBox ChkNetReq 
      Caption         =   "Remote client connections required ?"
      Height          =   495
      Left            =   600
      TabIndex        =   0
      Top             =   1200
      Width           =   3375
   End
   Begin VB.TextBox Numclient 
      Height          =   285
      Left            =   3360
      TabIndex        =   1
      Text            =   "0"
      Top             =   1920
      Width           =   855
   End
   Begin ComCtl2.UpDown UpDown1 
      Height          =   285
      Left            =   4200
      TabIndex        =   2
      TabStop         =   0   'False
      Top             =   1920
      Width           =   240
      _ExtentX        =   423
      _ExtentY        =   503
      _Version        =   327680
      AutoBuddy       =   -1  'True
      BuddyControl    =   "Numclient"
      BuddyDispid     =   196611
      OrigLeft        =   3856
      OrigTop         =   1440
      OrigRight       =   4096
      OrigBottom      =   1725
      Max             =   9999
      SyncBuddy       =   -1  'True
      BuddyProperty   =   0
      Enabled         =   -1  'True
   End
   Begin VB.CommandButton CmdFinish 
      Caption         =   "Finish"
      Enabled         =   0   'False
      Height          =   375
      Left            =   5160
      TabIndex        =   6
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton CmdNext 
      Caption         =   "Next>"
      Height          =   375
      Left            =   3840
      TabIndex        =   5
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton CmdPrev 
      Caption         =   "<Previous"
      Height          =   375
      Left            =   2520
      TabIndex        =   4
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton CmdCancel 
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   1200
      TabIndex        =   3
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
      Picture         =   "UsrWizardNET.ctx":0000
      ScaleHeight     =   480
      ScaleWidth      =   480
      TabIndex        =   7
      Top             =   240
      Width           =   480
   End
   Begin VB.Frame Frame2 
      Height          =   855
      Left            =   120
      TabIndex        =   9
      Top             =   0
      Width           =   6255
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Caption         =   "Synergy/DE xfServer"
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
   Begin VB.Frame Frame1 
      Caption         =   "Frame1"
      Height          =   2415
      Left            =   120
      TabIndex        =   12
      Top             =   960
      Width           =   6255
      Begin VB.Label LblNetNum 
         Caption         =   "Number of client connections"
         Height          =   255
         Left            =   960
         TabIndex        =   13
         Top             =   960
         Width           =   2175
      End
   End
   Begin VB.Label Label1 
      Caption         =   $"UsrWizardNET.ctx":0442
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
      Left            =   120
      TabIndex        =   8
      Top             =   3600
      Width           =   6255
   End
End
Attribute VB_Name = "UsrWizardNET"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Dim DefaultSysIndex As Integer
Public Event closecontrol()
Public Event BackPage()
Public Event ForwardPage()
Public Event WizardFinished()
Public Event DefSysCode(SysCode As Integer)
Dim SystemCode As Integer

Private Sub ChkNetReq_Click()
    If ChkNetReq.Value = 1 Then
        LblNetNum.Enabled = True
        Numclient.Enabled = True
        Numclient.Text = 1
        UpDown1.Enabled = True
        UsrSysCodeCmb1.Enabled (True)
    Else
        LblNetNum.Enabled = False
        Numclient.Enabled = False
        Numclient.Text = 0
        UpDown1.Enabled = False
        UsrSysCodeCmb1.Enabled (False)
        UsrSysCodeCmb1.DefIndex (DefaultSysIndex)
    End If

End Sub

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
Private Sub UserControl_Initialize()
    LblNetNum.Enabled = False
    Numclient.Enabled = False
    Numclient.Text = 0
    UpDown1.Enabled = False
    UsrSysCodeCmb1.Enabled (False)
    RaiseEvent DefSysCode(SystemCode)
End Sub


Public Property Get NetNumCons() As Variant
    NetNumCons = Numclient.Text
End Property

Public Property Let NetNumCons(ByVal vNewValue As Variant)
    'read only
End Property

Public Property Get NETSysCode() As Variant
    NETSysCode = UsrSysCodeCmb1.SysCode
End Property
Public Property Let SetSysIndex(ByVal vNewValue As Variant)
    DefaultSysIndex = vNewValue
    UsrSysCodeCmb1.DefIndex (DefaultSysIndex)
End Property



