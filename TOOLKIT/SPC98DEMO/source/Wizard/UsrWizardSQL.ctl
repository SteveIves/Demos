VERSION 5.00
Object = "{FE0065C0-1B7B-11CF-9D53-00AA003C9CB6}#1.0#0"; "COMCT232.OCX"
Begin VB.UserControl UsrWizardSQL 
   ClientHeight    =   5805
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   6495
   ScaleHeight     =   5805
   ScaleWidth      =   6495
   Begin SynergyQuoteWizard.UsrSysCodeCmb UsrSysCodeCmb1 
      Height          =   375
      Left            =   1320
      TabIndex        =   15
      Top             =   2760
      Width           =   4695
      _ExtentX        =   8281
      _ExtentY        =   661
   End
   Begin SynergyQuoteWizard.UsrSqlDbCmb UsrSqlDbCmb1 
      Height          =   615
      Left            =   720
      TabIndex        =   14
      Top             =   1680
      Width           =   2415
      _ExtentX        =   4260
      _ExtentY        =   1085
   End
   Begin VB.CheckBox ChkRemote 
      Caption         =   "Is this database on a remote system?"
      Height          =   255
      Left            =   960
      TabIndex        =   3
      Top             =   2400
      Width           =   3735
   End
   Begin ComCtl2.UpDown UpDown1 
      Height          =   285
      Left            =   4080
      TabIndex        =   2
      Top             =   1920
      Width           =   240
      _ExtentX        =   423
      _ExtentY        =   503
      _Version        =   327680
      Value           =   1
      AutoBuddy       =   -1  'True
      BuddyControl    =   "SqlNum"
      BuddyDispid     =   196613
      OrigLeft        =   4816
      OrigTop         =   2400
      OrigRight       =   5056
      OrigBottom      =   2685
      Max             =   99999
      Min             =   1
      SyncBuddy       =   -1  'True
      BuddyProperty   =   0
      Enabled         =   -1  'True
   End
   Begin VB.TextBox SqlNum 
      Height          =   285
      Left            =   3360
      TabIndex        =   1
      Text            =   "0"
      Top             =   1920
      Width           =   735
   End
   Begin VB.Frame Frame1 
      Height          =   2415
      Left            =   120
      TabIndex        =   9
      Top             =   960
      Width           =   6255
      Begin VB.CheckBox ChkSql 
         Caption         =   "Do you require access to a relational database ?"
         Height          =   255
         Left            =   240
         TabIndex        =   0
         Top             =   360
         Width           =   3735
      End
      Begin VB.Label LblSqlNum 
         Caption         =   "Connections"
         Height          =   255
         Left            =   3240
         TabIndex        =   13
         Top             =   720
         Width           =   1215
      End
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
   Begin VB.CommandButton CmdNext 
      Caption         =   "Next>"
      Height          =   375
      Left            =   3840
      TabIndex        =   6
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
   Begin VB.CommandButton CmdCancel 
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   1200
      TabIndex        =   4
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
      Picture         =   "UsrWizardSQL.ctx":0000
      ScaleHeight     =   480
      ScaleWidth      =   480
      TabIndex        =   8
      Top             =   240
      Width           =   480
   End
   Begin VB.Frame Frame2 
      Height          =   855
      Left            =   120
      TabIndex        =   11
      Top             =   0
      Width           =   6255
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Caption         =   "Synergy/DE SQL Connection"
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
      Caption         =   "Synergy/DE SQL Connection allows you to access third-party relational databases from your Synergy applications."
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
      TabIndex        =   10
      Top             =   3600
      Width           =   6255
   End
End
Attribute VB_Name = "UsrWizardSQL"
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


Private Sub ChkRemote_Click()
    If ChkRemote.Value = 1 Then
        UsrSysCodeCmb1.Enabled (True)
    Else
        UsrSysCodeCmb1.Enabled (False)
        UsrSysCodeCmb1.DefIndex (DefaultSysIndex)
    End If
End Sub

Private Sub ChkSql_Click()
    If ChkSql.Value = 1 Then
        LblSqlNum.Enabled = True
        SqlNum.Enabled = True
        SqlNum.Text = 1
        UpDown1.Enabled = True
        UsrSqlDbCmb1.Enabled (True)
        ChkRemote.Enabled = True
        UsrSysCodeCmb1.Enabled (False)
    Else
        LblSqlNum.Enabled = False
        SqlNum.Enabled = False
        SqlNum.Text = 0
        UpDown1.Enabled = False
        UsrSqlDbCmb1.Enabled (False)
        ChkRemote.Enabled = False
        ChkRemote.Value = 0
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
    LblSqlNum.Enabled = False
    SqlNum.Enabled = False
    UpDown1.Enabled = False
    UsrSqlDbCmb1.Enabled (False)
    ChkRemote.Enabled = False
    UsrSysCodeCmb1.Enabled (False)
    RaiseEvent DefSysCode(SystemCode)
End Sub

Private Sub UsrSqlDBcmb1_GotFocus()
    If UsrSqlDbCmb1.SqlDbCode <> "None" Then
        LblSqlNum.Enabled = True
        SqlNum.Enabled = True
        ChkRemote.Enabled = True
    Else
        LblSqlNum.Enabled = False
        SqlNum.Text = 0
        SqlNum.Enabled = False
        ChkRemote.Value = 0
        ChkRemote.Enabled = False
    End If
End Sub

Public Property Get SQLDataBase() As Variant
    SQLDataBase = UsrSqlDbCmb1.SqlDbCode
End Property

Public Property Let SQLDataBase(ByVal vNewValue As Variant)
    'read only
End Property

Public Property Get SQLNumCons() As Variant
    SQLNumCons = SqlNum.Text
End Property

Public Property Let SQLNumCons(ByVal vNewValue As Variant)
    'read only
End Property

Public Property Get SQLClientServer() As Variant
    SQLClientServer = ChkRemote.Value
End Property

Public Property Let SQLClientServer(ByVal vNewValue As Variant)
    'read only
End Property
Public Property Get SQLSysCode() As Variant
    SQLSysCode = UsrSysCodeCmb1.SysCode
End Property
Public Property Let SetSysIndex(ByVal vNewValue As Variant)

    DefaultSysIndex = vNewValue
    UsrSysCodeCmb1.DefIndex (DefaultSysIndex)
End Property



