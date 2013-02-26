VERSION 5.00
Object = "{FE0065C0-1B7B-11CF-9D53-00AA003C9CB6}#1.0#0"; "COMCT232.OCX"
Begin VB.UserControl UsrWizardDOC 
   ClientHeight    =   5805
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   6495
   ScaleHeight     =   5805
   ScaleWidth      =   6495
   Begin ComCtl2.UpDown UpDownPaper 
      Height          =   285
      Left            =   4680
      TabIndex        =   9
      Top             =   2280
      Width           =   240
      _ExtentX        =   423
      _ExtentY        =   503
      _Version        =   327680
      Value           =   1
      AutoBuddy       =   -1  'True
      BuddyControl    =   "NumPaper"
      BuddyDispid     =   196610
      OrigLeft        =   960
      OrigTop         =   5280
      OrigRight       =   1200
      OrigBottom      =   5655
      Max             =   9999
      Min             =   1
      SyncBuddy       =   -1  'True
      BuddyProperty   =   0
      Enabled         =   -1  'True
   End
   Begin VB.TextBox NumPaper 
      Height          =   285
      Left            =   3840
      TabIndex        =   3
      Top             =   2280
      Width           =   855
   End
   Begin ComCtl2.UpDown UpDownCd 
      Height          =   285
      Left            =   4680
      TabIndex        =   8
      TabStop         =   0   'False
      Top             =   1560
      Width           =   240
      _ExtentX        =   423
      _ExtentY        =   503
      _Version        =   327680
      Value           =   1
      AutoBuddy       =   -1  'True
      BuddyControl    =   "NumCd"
      BuddyDispid     =   196612
      OrigLeft        =   3360
      OrigTop         =   1920
      OrigRight       =   3600
      OrigBottom      =   2655
      Max             =   9999
      Min             =   1
      SyncBuddy       =   -1  'True
      BuddyProperty   =   0
      Enabled         =   -1  'True
   End
   Begin VB.TextBox NumCd 
      Height          =   285
      Left            =   3840
      TabIndex        =   1
      Top             =   1560
      Width           =   855
   End
   Begin VB.Frame Frame1 
      Height          =   2415
      Left            =   120
      TabIndex        =   11
      Top             =   960
      Width           =   6255
      Begin VB.CheckBox ChkCd 
         Caption         =   "Additional on-line documentation CDs"
         Height          =   480
         Left            =   360
         TabIndex        =   0
         Top             =   480
         Width           =   3615
      End
      Begin VB.CheckBox ChkPaper 
         Caption         =   "Additional printed documentation sets"
         Height          =   480
         Left            =   360
         TabIndex        =   2
         Top             =   1200
         Width           =   3015
      End
   End
   Begin VB.PictureBox Picture1 
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BackColor       =   &H8000000A&
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   480
      Left            =   480
      Picture         =   "UsrWizardDOC.ctx":0000
      ScaleHeight     =   480
      ScaleWidth      =   480
      TabIndex        =   10
      TabStop         =   0   'False
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
   Begin VB.Frame Frame2 
      Height          =   855
      Left            =   120
      TabIndex        =   13
      Top             =   0
      Width           =   6255
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Caption         =   "Additional Documentation"
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
         TabIndex        =   14
         Top             =   360
         Width           =   5295
      End
   End
   Begin VB.Label Label1 
      Caption         =   $"UsrWizardDOC.ctx":030A
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
      TabIndex        =   12
      Top             =   3600
      Width           =   6255
   End
End
Attribute VB_Name = "UsrWizardDOC"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

Public Event closecontrol()
Public Event BackPage()
Public Event ForwardPage()
Public Event WizardFinished()

Private Sub ChkCd_Click()
    If ChkCd.Value = 1 Then
        NumCd.Enabled = True
        NumCd.Text = 1
        UpDownCd.Enabled = True
    Else
        NumCd.Enabled = False
        NumCd.Text = 0
        UpDownCd.Enabled = False
    End If
End Sub

Private Sub ChkPaper_Click()
    If ChkPaper.Value = 1 Then
        NumPaper.Enabled = True
        NumPaper.Text = 1
        UpDownPaper.Enabled = True
    Else
        NumPaper.Enabled = False
        NumPaper.Text = 0
        UpDownPaper.Enabled = False
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
    NumCd.Enabled = False
    NumCd.Text = 0
    UpDownCd.Enabled = False
    NumPaper.Enabled = False
    NumPaper.Text = 0
    UpDownPaper.Enabled = False
End Sub

Public Property Get DOConCD() As Variant
    DOConCD = NumCd.Text
End Property

Public Property Let DOConCD(ByVal vNewValue As Variant)
    'read only
End Property

Public Property Get DOConPaper() As Variant
    DOConPaper = NumPaper.Text
End Property

Public Property Let DOConPaper(ByVal vNewValue As Variant)
    'read only
End Property
