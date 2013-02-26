VERSION 5.00
Object = "{FE0065C0-1B7B-11CF-9D53-00AA003C9CB6}#1.0#0"; "COMCT232.OCX"
Begin VB.UserControl UsrWizardENV 
   ClientHeight    =   5805
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   6495
   ScaleHeight     =   5805
   ScaleWidth      =   6495
   Begin ComCtl2.UpDown UpDown1 
      Height          =   285
      Left            =   5520
      TabIndex        =   8
      TabStop         =   0   'False
      Top             =   1560
      Width           =   240
      _ExtentX        =   423
      _ExtentY        =   503
      _Version        =   327680
      Value           =   1
      AutoBuddy       =   -1  'True
      BuddyControl    =   "PSDEnum"
      BuddyDispid     =   196610
      OrigLeft        =   3480
      OrigTop         =   1440
      OrigRight       =   3720
      OrigBottom      =   2175
      Max             =   99999
      Min             =   1
      SyncBuddy       =   -1  'True
      BuddyProperty   =   0
      Enabled         =   -1  'True
   End
   Begin VB.TextBox PSDEnum 
      Enabled         =   0   'False
      Height          =   285
      Left            =   4680
      TabIndex        =   1
      Text            =   "0"
      Top             =   1560
      Width           =   855
   End
   Begin ComCtl2.UpDown UpDown2 
      Height          =   285
      Index           =   0
      Left            =   5520
      TabIndex        =   9
      TabStop         =   0   'False
      Top             =   2280
      Width           =   240
      _ExtentX        =   423
      _ExtentY        =   503
      _Version        =   327680
      Value           =   1
      AutoBuddy       =   -1  'True
      BuddyControl    =   "RUNNum(0)"
      BuddyDispid     =   196612
      BuddyIndex      =   0
      OrigLeft        =   3480
      OrigTop         =   2400
      OrigRight       =   3720
      OrigBottom      =   2685
      Max             =   99999
      Min             =   1
      SyncBuddy       =   -1  'True
      BuddyProperty   =   0
      Enabled         =   -1  'True
   End
   Begin VB.TextBox RUNNum 
      Enabled         =   0   'False
      Height          =   285
      Index           =   0
      Left            =   4680
      TabIndex        =   3
      Text            =   "0"
      Top             =   2280
      Width           =   855
   End
   Begin VB.PictureBox Picture1 
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BackColor       =   &H8000000A&
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   480
      Left            =   480
      Picture         =   "UsrWizardENV.ctx":0000
      ScaleHeight     =   480
      ScaleWidth      =   480
      TabIndex        =   10
      TabStop         =   0   'False
      Top             =   240
      Width           =   480
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
   Begin VB.Frame Frame2 
      Height          =   855
      Left            =   120
      TabIndex        =   12
      Top             =   0
      Width           =   6255
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Caption         =   "Development && Runtime License Selection"
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
   Begin VB.Frame Frame1 
      Height          =   2415
      Left            =   120
      TabIndex        =   14
      Top             =   960
      Width           =   6255
      Begin VB.CheckBox ChkRUN 
         Caption         =   "Runtime only license"
         Height          =   480
         Left            =   360
         TabIndex        =   2
         Top             =   1200
         Width           =   1815
      End
      Begin VB.CheckBox ChkPSDE 
         Caption         =   "Professional Series (development) licenses"
         Height          =   480
         Left            =   360
         TabIndex        =   0
         Top             =   480
         Width           =   3975
      End
   End
   Begin VB.Label Label3 
      Caption         =   "Select the type of license(s) and the number for each license."
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
      TabIndex        =   15
      Top             =   4440
      Width           =   6015
   End
   Begin VB.Label Label1 
      Caption         =   "Professional Series provides the core toolset for professional developers."
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
      TabIndex        =   11
      Top             =   3600
      Width           =   6135
   End
End
Attribute VB_Name = "UsrWizardENV"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Public Event closecontrol()
Public Event BackPage()
Public Event ForwardPage()
Public Event WizardFinished()

Private Sub ChkPSDE_Click()
    If ChkPSDE.Value = 1 Then
        PSDEnum.Enabled = True
        PSDEnum.Text = 1
        UpDown1.Enabled = True
    Else
        PSDEnum.Enabled = False
        PSDEnum.Text = 0
        UpDown1.Enabled = False
    End If
End Sub

Private Sub ChkRUN_Click()
    If ChkRUN.Value = 1 Then
        RUNNum(0).Enabled = True
        RUNNum(0).Text = 1
        UpDown2(0).Enabled = True
    Else
        RUNNum(0).Enabled = False
        RUNNum(0).Text = 0
        UpDown2(0).Enabled = False
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
    PSDEnum.Text = 0
    RUNNum(0).Text = 0
    PSDEnum.Enabled = False
    UpDown1.Enabled = False
    RUNNum(0).Enabled = False
    UpDown2(0).Enabled = False
End Sub

Public Property Get ENVPsdeNum() As Variant
    ENVPsdeNum = PSDEnum
End Property

Public Property Let ENVPsdeNum(ByVal vNewValue As Variant)
    'read only!
End Property

Public Property Get ENVRunNum() As Variant
    ENVRunNum = RUNNum(0)
End Property

Public Property Let ENVRunNum(ByVal vNewValue As Variant)
    'read only!
End Property
