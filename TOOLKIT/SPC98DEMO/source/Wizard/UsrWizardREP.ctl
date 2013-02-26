VERSION 5.00
Object = "{FE0065C0-1B7B-11CF-9D53-00AA003C9CB6}#1.0#0"; "COMCT232.OCX"
Begin VB.UserControl UsrWizardREP 
   ClientHeight    =   5805
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   6495
   ScaleHeight     =   5805
   ScaleWidth      =   6495
   Begin ComCtl2.UpDown UpDownRwNum 
      Height          =   285
      Left            =   5400
      TabIndex        =   3
      Top             =   1560
      Width           =   240
      _ExtentX        =   423
      _ExtentY        =   503
      _Version        =   327680
      Value           =   1
      AutoBuddy       =   -1  'True
      BuddyControl    =   "RwNum"
      BuddyDispid     =   196610
      OrigLeft        =   3976
      OrigTop         =   2400
      OrigRight       =   4216
      OrigBottom      =   2685
      Max             =   99999
      Min             =   1
      SyncBuddy       =   -1  'True
      BuddyProperty   =   0
      Enabled         =   -1  'True
   End
   Begin VB.TextBox RwNum 
      Height          =   285
      Left            =   4680
      TabIndex        =   2
      Text            =   "0"
      Top             =   1560
      Width           =   735
   End
   Begin ComCtl2.UpDown UpDownRunnum 
      Height          =   285
      Left            =   5400
      TabIndex        =   1
      Top             =   2280
      Width           =   240
      _ExtentX        =   423
      _ExtentY        =   503
      _Version        =   327680
      Value           =   1
      AutoBuddy       =   -1  'True
      BuddyControl    =   "RunNum"
      BuddyDispid     =   196612
      OrigLeft        =   3120
      OrigTop         =   2520
      OrigRight       =   3360
      OrigBottom      =   3255
      Max             =   99999
      Min             =   1
      SyncBuddy       =   -1  'True
      BuddyProperty   =   0
      Enabled         =   -1  'True
   End
   Begin VB.TextBox RunNum 
      Height          =   285
      Left            =   4680
      TabIndex        =   0
      Text            =   "0"
      Top             =   2280
      Width           =   735
   End
   Begin VB.PictureBox Picture1 
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BackColor       =   &H8000000A&
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   480
      Left            =   480
      Picture         =   "UsrWizardREP.ctx":0000
      ScaleHeight     =   480
      ScaleWidth      =   480
      TabIndex        =   8
      Top             =   240
      Width           =   480
   End
   Begin VB.CommandButton CmdCancel 
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   1200
      TabIndex        =   4
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton CmdPrev 
      Caption         =   "<Previous"
      Height          =   375
      Left            =   2520
      TabIndex        =   5
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton CmdNext 
      Caption         =   "Next>"
      Height          =   375
      Left            =   3840
      TabIndex        =   6
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton CmdFinish 
      Caption         =   "Finish"
      Enabled         =   0   'False
      Height          =   375
      Left            =   5160
      TabIndex        =   7
      Top             =   5280
      Width           =   1215
   End
   Begin VB.Frame Frame1 
      Height          =   2415
      Left            =   120
      TabIndex        =   9
      Top             =   960
      Width           =   6255
      Begin VB.CheckBox RwFull 
         Caption         =   "Synergy/DE ReportWriter (development)"
         Height          =   480
         Left            =   360
         TabIndex        =   14
         Top             =   480
         Width           =   3735
      End
      Begin VB.CheckBox RwReq 
         Caption         =   "Synergy/DE ReportWriter (runtime only)"
         Height          =   480
         Left            =   360
         TabIndex        =   13
         Top             =   1200
         Width           =   3735
      End
   End
   Begin VB.Frame Frame2 
      Height          =   855
      Left            =   120
      TabIndex        =   11
      Top             =   0
      Width           =   6255
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Caption         =   "Synergy/DE ReportWriter Licenses"
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
         TabIndex        =   12
         Top             =   360
         Width           =   5295
      End
   End
   Begin VB.Label Label1 
      Caption         =   "The Synergy/DE ReportWriter is a powerful Synergy/DE UIToolkit driven reporting tool.  Use it to create or execute custom reports."
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
      TabIndex        =   10
      Top             =   3600
      Width           =   6375
      WordWrap        =   -1  'True
   End
End
Attribute VB_Name = "UsrWizardREP"
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

Public Property Get REPRwNum() As Variant
        REPRwNum = RwNum.Text
End Property

Private Sub RwFull_Click()
    If RwFull.Value = 1 Then
        RwNum.Enabled = True
        RwNum.Text = 1
        UpDownRwNum.Enabled = True
    Else
        RwNum.Enabled = False
        RwNum.Text = 0
        UpDownRwNum.Enabled = False
    End If
End Sub

Private Sub RwReq_Click()
    If RwReq.Value = 1 Then
        RUNNum.Enabled = True
        RUNNum.Text = 1
        UpDownRunnum.Enabled = True
    Else
        RwNum.Enabled = False
        RUNNum.Text = 0
        RwFull.Value = 0
        RUNNum.Enabled = False
        UpDownRunnum.Enabled = False
    End If
End Sub

Private Sub UserControl_Initialize()
    RUNNum.Text = 0
    RUNNum.Enabled = False
    RwFull.Value = 0
    RwNum.Text = 0
    RwNum.Enabled = False
    UpDownRunnum.Enabled = False
    UpDownRwNum.Enabled = False
End Sub

Public Property Get REPRunNum() As Variant
        REPRunNum = RUNNum.Text
End Property
