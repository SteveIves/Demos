VERSION 5.00
Begin VB.UserControl UsrWizardDIST 
   ClientHeight    =   5805
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   6495
   ScaleHeight     =   5805
   ScaleWidth      =   6495
   Begin VB.CommandButton CmdFinish 
      Caption         =   "Finish"
      Enabled         =   0   'False
      Height          =   375
      Left            =   5160
      TabIndex        =   3
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
   Begin VB.CommandButton CmdPrev 
      Caption         =   "<Previous"
      Height          =   375
      Left            =   2520
      TabIndex        =   1
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton CmdCancel 
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   1200
      TabIndex        =   0
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
      Picture         =   "UsrWizardDIST.ctx":0000
      ScaleHeight     =   480
      ScaleWidth      =   480
      TabIndex        =   5
      TabStop         =   0   'False
      Top             =   240
      Width           =   480
   End
   Begin VB.Frame Frame1 
      Height          =   2415
      Left            =   120
      TabIndex        =   4
      Top             =   960
      Width           =   6255
      Begin VB.Frame Frame3 
         BorderStyle     =   0  'None
         Caption         =   "Frame3"
         Height          =   1575
         Left            =   720
         TabIndex        =   10
         Top             =   480
         Width           =   5175
         Begin VB.OptionButton OptMedia 
            Caption         =   "Media kit with printed installation and configuration guide"
            Height          =   255
            Index           =   3
            Left            =   0
            TabIndex        =   14
            Top             =   1200
            Width           =   5055
         End
         Begin VB.OptionButton OptMedia 
            Caption         =   "Media kit with online documentation"
            Height          =   255
            Index           =   2
            Left            =   0
            TabIndex        =   13
            Top             =   840
            Width           =   4575
         End
         Begin VB.OptionButton OptMedia 
            Caption         =   "Media kit with printed documentation"
            Height          =   255
            Index           =   1
            Left            =   0
            TabIndex        =   12
            Top             =   480
            Width           =   4815
         End
         Begin VB.OptionButton OptMedia 
            Caption         =   "Media kit with online and printed documentation"
            Height          =   375
            Index           =   0
            Left            =   0
            TabIndex        =   11
            Top             =   120
            Width           =   4455
         End
      End
      Begin VB.CheckBox ChkMedia 
         Caption         =   "Media and documentation kit required ?"
         Height          =   255
         Left            =   360
         TabIndex        =   9
         Top             =   240
         Width           =   4695
      End
   End
   Begin VB.Frame Frame2 
      Height          =   855
      Left            =   120
      TabIndex        =   6
      Top             =   0
      Width           =   6255
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Caption         =   "Synergy/DE Distribution Media"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   13.5
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   840
         TabIndex        =   7
         Top             =   360
         Width           =   5295
      End
   End
   Begin VB.Label Label1 
      Caption         =   $"UsrWizardDIST.ctx":0442
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
Attribute VB_Name = "UsrWizardDist"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Public Event closecontrol()
Public Event BackPage()
Public Event ForwardPage()
Public Event WizardFinished()
Private Sub ChkMedia_Click()
    If ChkMedia.Value = 1 Then
        Frame3.Enabled = True
        OptMedia.Item(0).Value = True
        OptMedia.Item(0).Enabled = True
        OptMedia.Item(1).Enabled = True
        OptMedia.Item(2).Enabled = True
        OptMedia.Item(3).Enabled = True
    Else
        Call DisableChoice
    End If
    
End Sub
Private Sub DisableChoice()
        Frame3.Enabled = False
        OptMedia.Item(0).Enabled = False
        OptMedia.Item(1).Enabled = False
        OptMedia.Item(2).Enabled = False
        OptMedia.Item(3).Enabled = False
        OptMedia.Item(0).Value = False
        OptMedia.Item(1).Value = False
        OptMedia.Item(2).Value = False
        OptMedia.Item(3).Value = False
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


Public Property Get DISTType() As String
    If OptMedia.Item(0).Value = True Then
        DISTType = "A"
    End If
    If OptMedia.Item(1).Value = True Then
        DISTType = "B"
    End If
    If OptMedia.Item(2).Value = True Then
        DISTType = "C"
    End If
    If OptMedia.Item(3).Value = True Then
        DISTType = "D"
    End If
End Property

Private Sub UserControl_Initialize()
        Call DisableChoice
End Sub
