VERSION 5.00
Begin VB.Form frmSettings 
   Caption         =   "Settings"
   ClientHeight    =   2475
   ClientLeft      =   2745
   ClientTop       =   2805
   ClientWidth     =   3540
   ClipControls    =   0   'False
   ControlBox      =   0   'False
   LinkTopic       =   "Form2"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2475
   ScaleWidth      =   3540
   StartUpPosition =   1  'CenterOwner
   Begin VB.Frame fraTab 
      Height          =   2415
      Index           =   0
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   3495
      Begin VB.CommandButton cmdCancel 
         Cancel          =   -1  'True
         Caption         =   "&Cancel"
         Height          =   495
         Left            =   1950
         TabIndex        =   8
         Top             =   1800
         Width           =   1215
      End
      Begin VB.CommandButton cmdOk 
         Caption         =   "&Ok"
         Default         =   -1  'True
         Enabled         =   0   'False
         Height          =   495
         Left            =   270
         TabIndex        =   7
         Top             =   1800
         Width           =   1215
      End
      Begin VB.TextBox txtPW 
         Height          =   375
         IMEMode         =   3  'DISABLE
         Left            =   1080
         PasswordChar    =   "*"
         TabIndex        =   6
         Top             =   1320
         Width           =   2295
      End
      Begin VB.TextBox txtID 
         Height          =   375
         Left            =   1080
         TabIndex        =   4
         Top             =   840
         Width           =   2295
      End
      Begin VB.TextBox txtServer 
         Height          =   375
         Left            =   1080
         TabIndex        =   2
         Top             =   360
         Width           =   2295
      End
      Begin VB.Label lblPW 
         AutoSize        =   -1  'True
         Caption         =   "&Password: "
         Height          =   195
         Left            =   120
         TabIndex        =   5
         Top             =   1320
         Width           =   780
      End
      Begin VB.Label lblID 
         AutoSize        =   -1  'True
         Caption         =   "&ID: "
         Height          =   195
         Left            =   645
         TabIndex        =   3
         Top             =   900
         Width           =   255
      End
      Begin VB.Label lblServer 
         AutoSize        =   -1  'True
         Caption         =   "&Server: "
         Height          =   195
         Left            =   345
         TabIndex        =   1
         Top             =   480
         Width           =   555
      End
   End
End
Attribute VB_Name = "frmSettings"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()
    
    txtServer = modPOPMgr.POPServer
    txtID = modPOPMgr.ID
    txtPW = modPOPMgr.PW

End Sub

Private Sub txtID_Change()

    Validate

End Sub

Private Sub txtPW_Change()

    Validate

End Sub

Private Sub txtServer_Change()

    Validate
    
End Sub

Private Sub cmdOk_Click()

    modPOPMgr.POPServer = txtServer
    modPOPMgr.ID = txtID
    modPOPMgr.PW = txtPW
    Unload Me
    Refresh
    
End Sub

Private Sub cmdCancel_Click()

    Unload Me
    Refresh
    
End Sub

Private Sub Validate()

'   Lets trim server & account ID, but leave PW alone

    If Trim$(txtServer) > "" And _
    Trim$(txtID) > "" And _
    txtPW > "" Then
        modPOPMgr.InfoOk = True
        cmdOk.Enabled = True
    Else
        modPOPMgr.InfoOk = False
        cmdOk.Enabled = False
    End If

End Sub


