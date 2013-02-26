VERSION 5.00
Object = "{FE0065C0-1B7B-11CF-9D53-00AA003C9CB6}#1.0#0"; "COMCT232.OCX"
Begin VB.UserControl UsrWizardODBC 
   ClientHeight    =   5805
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   6495
   ScaleHeight     =   5805
   ScaleWidth      =   6495
   Begin SynergyQuoteWizard.UsrSysCodeCmb UsrSysCodeCmb1 
      Height          =   375
      Left            =   1440
      TabIndex        =   14
      Top             =   2640
      Width           =   4695
      _ExtentX        =   8281
      _ExtentY        =   661
   End
   Begin VB.CheckBox ChkRemote 
      Caption         =   "Is the data on a remote server machine"
      Height          =   495
      Left            =   1200
      TabIndex        =   2
      Top             =   2040
      Width           =   4575
   End
   Begin VB.TextBox OdbcNum 
      Height          =   285
      Left            =   3840
      TabIndex        =   1
      Text            =   "0"
      Top             =   1680
      Width           =   975
   End
   Begin ComCtl2.UpDown UpDown1 
      Height          =   285
      Left            =   4800
      TabIndex        =   7
      TabStop         =   0   'False
      Top             =   1680
      Width           =   240
      _ExtentX        =   423
      _ExtentY        =   503
      _Version        =   327680
      Value           =   1
      AutoBuddy       =   -1  'True
      BuddyControl    =   "OdbcNum"
      BuddyDispid     =   196611
      OrigLeft        =   1800
      OrigTop         =   2520
      OrigRight       =   2040
      OrigBottom      =   2775
      Max             =   99999
      Min             =   1
      SyncBuddy       =   -1  'True
      BuddyProperty   =   0
      Enabled         =   -1  'True
   End
   Begin VB.CheckBox ChkODBC 
      Caption         =   "Do you require the Synergy/DE xfODBC driver ?"
      Height          =   495
      Left            =   360
      TabIndex        =   0
      Top             =   1200
      Width           =   4455
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
      Picture         =   "UsrWizardODBC.ctx":0000
      ScaleHeight     =   480
      ScaleWidth      =   480
      TabIndex        =   8
      TabStop         =   0   'False
      Top             =   240
      Width           =   480
   End
   Begin VB.Frame Frame1 
      Enabled         =   0   'False
      Height          =   2415
      Left            =   120
      TabIndex        =   10
      Top             =   960
      Width           =   6255
      Begin VB.Label LblOdbcNum 
         Caption         =   "How many concurrent connections ?"
         Height          =   255
         Left            =   840
         TabIndex        =   11
         Top             =   720
         Width           =   2775
      End
   End
   Begin VB.Frame Frame2 
      Height          =   855
      Left            =   120
      TabIndex        =   12
      Top             =   0
      Width           =   6255
      Begin VB.Label Label3 
         Alignment       =   2  'Center
         Caption         =   "Synergy/DE xfODBC Data access"
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
         TabIndex        =   13
         Top             =   360
         Width           =   5295
      End
   End
   Begin VB.Label Label1 
      Caption         =   "Synergy/DE xfODBC allows thrid-party ODBC-enabled applications to access your Synergy ISAMxf databases."
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
      TabIndex        =   9
      Top             =   3600
      Width           =   6255
   End
End
Attribute VB_Name = "UsrWizardODBC"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Dim DefaultSysIndex As Integer
Public Event closecontrol()
Public Event BackPage()
Public Event ForwardPage()
Public Event WizardFinished()

Private Sub ChkODBC_Click()
    If ChkODBC.Value = 1 Then
        LblOdbcNum.Enabled = True
        OdbcNum.Enabled = True
        OdbcNum.Text = 1
        UpDown1.Enabled = True
        ChkRemote.Enabled = True
        UsrSysCodeCmb1.Enabled (False)
    Else
        LblOdbcNum.Enabled = False
        OdbcNum.Enabled = False
        OdbcNum.Text = 0
        UpDown1.Enabled = False
        ChkRemote.Enabled = False
        ChkRemote.Value = 0
        UsrSysCodeCmb1.Enabled (False)
        UsrSysCodeCmb1.DefIndex (DefaultSysIndex)
    End If

End Sub

Private Sub ChkRemote_Click()
    If ChkRemote.Value = 1 Then
        UsrSysCodeCmb1.Enabled (True)
    Else
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
    LblOdbcNum.Enabled = False
    OdbcNum.Enabled = False
    UpDown1.Enabled = False
    ChkRemote.Enabled = False
    UsrSysCodeCmb1.Enabled (False)
End Sub

Public Property Get ODBCNumCons() As Variant
    If ChkODBC.Value = 1 Then
        ODBCNumCons = OdbcNum.Text
    Else
        ODBCNumCons = 0
    End If
End Property

Public Property Let ODBCNumCons(ByVal vNewValue As Variant)
    'read only
End Property

Public Property Get ODBCClientServer() As Variant
    ODBCClientServer = ChkRemote.Value
End Property

Public Property Let ODBCClientServer(ByVal vNewValue As Variant)
    'read only
End Property
Public Property Get ODBCSysCode() As Variant
    ODBCSysCode = UsrSysCodeCmb1.SysCode
End Property

Public Property Let SetSysIndex(ByVal vNewValue As Variant)

    DefaultSysIndex = vNewValue
    UsrSysCodeCmb1.DefIndex (DefaultSysIndex)
End Property

