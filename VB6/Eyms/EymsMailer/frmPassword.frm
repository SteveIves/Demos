VERSION 5.00
Begin VB.Form frmPassword 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Password Required"
   ClientHeight    =   1125
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   4755
   Icon            =   "frmPassword.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1125
   ScaleWidth      =   4755
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton bHelp 
      Caption         =   "&Help"
      Height          =   375
      Left            =   3420
      TabIndex        =   4
      Top             =   600
      Width           =   1215
   End
   Begin VB.TextBox txtPassword 
      Height          =   315
      IMEMode         =   3  'DISABLE
      Left            =   1680
      PasswordChar    =   "*"
      TabIndex        =   0
      Top             =   120
      Width           =   2955
   End
   Begin VB.CommandButton CancelButton 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   2100
      TabIndex        =   2
      Top             =   600
      Width           =   1215
   End
   Begin VB.CommandButton OKButton 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   375
      Left            =   720
      TabIndex        =   1
      Top             =   600
      Width           =   1215
   End
   Begin VB.Label Label1 
      Caption         =   "Options Password"
      Height          =   255
      Left            =   240
      TabIndex        =   3
      Top             =   180
      Width           =   1335
   End
End
Attribute VB_Name = "frmPassword"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit

Private Sub bHelp_Click()

    MsgBox "Help is not implemented yet!", vbOKOnly + vbInformation, "Unavailable"

End Sub

Private Sub CancelButton_Click()

    Unload Me

End Sub

Private Sub OKButton_Click()

    'Check password here
    If UCase(txtPassword) = UCase(FrmMain.SetupPassword) Then
        FrmMain.PasswordOK = True
    Unload Me
    Else
        MsgBox "Invalid password, please try again!", vbOKOnly + vbExclamation, "Error"
        txtPassword.Text = ""
    End If

End Sub
