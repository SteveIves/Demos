VERSION 5.00
Begin VB.Form frmChangePassword 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Change Options Password"
   ClientHeight    =   2070
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   5235
   HelpContextID   =   7
   Icon            =   "frmChangePassword.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2070
   ScaleWidth      =   5235
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton bHelp 
      Caption         =   "&Help"
      Height          =   375
      Left            =   3960
      TabIndex        =   8
      Top             =   1500
      Width           =   1215
   End
   Begin VB.TextBox txtNew2 
      Height          =   315
      IMEMode         =   3  'DISABLE
      Left            =   2040
      PasswordChar    =   "*"
      TabIndex        =   2
      Top             =   1020
      Width           =   3075
   End
   Begin VB.TextBox txtNew1 
      Height          =   315
      IMEMode         =   3  'DISABLE
      Left            =   2040
      PasswordChar    =   "*"
      TabIndex        =   1
      Top             =   540
      Width           =   3075
   End
   Begin VB.TextBox txtOld 
      Height          =   315
      IMEMode         =   3  'DISABLE
      Left            =   2040
      PasswordChar    =   "*"
      TabIndex        =   0
      Top             =   60
      Width           =   3075
   End
   Begin VB.CommandButton CancelButton 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   2640
      TabIndex        =   4
      Top             =   1500
      Width           =   1215
   End
   Begin VB.CommandButton OKButton 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   375
      Left            =   1320
      TabIndex        =   3
      Top             =   1500
      Width           =   1215
   End
   Begin VB.Label Label1 
      Caption         =   "Verify new password"
      Height          =   255
      Index           =   2
      Left            =   240
      TabIndex        =   7
      Top             =   1080
      Width           =   1695
   End
   Begin VB.Label Label1 
      Caption         =   "New Password"
      Height          =   255
      Index           =   1
      Left            =   240
      TabIndex        =   6
      Top             =   600
      Width           =   1695
   End
   Begin VB.Label Label1 
      Caption         =   "Old Password"
      Height          =   255
      Index           =   0
      Left            =   240
      TabIndex        =   5
      Top             =   120
      Width           =   1695
   End
End
Attribute VB_Name = "frmChangePassword"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit

Private Sub bHelp_Click()

    With FrmMain.CommonDialog1
        .HelpCommand = cdlHelpContext
        .HelpContext = 7
        .ShowHelp
    End With

End Sub

Private Sub CancelButton_Click()

    Unload Me

End Sub

Private Sub OKButton_Click()

    If UCase(txtOld.Text) <> UCase(FrmMain.SetupPassword) Then
        MsgBox "Old password is incorrect!", vbOKOnly + vbExclamation, "Error"
    Else
        If UCase(txtNew1.Text) <> UCase(txtNew2.Text) Then
            MsgBox "New passwords are not the same!", vbOKOnly + vbExclamation, "Error"
        Else
            'OK, we have everything we need.
            
            'Save new password in application
            FrmMain.SetupPassword = txtNew1.Text
            
            'Save new password in Registry
            If txtNew1.Text = "" Then
                DeleteValue HKEY_LOCAL_MACHINE, FrmMain.RegPath, "SetupPassword"
            Else
                SaveSettingString HKEY_LOCAL_MACHINE, FrmMain.RegPath, "SetupPassword", txtNew1.Text
            End If
            
            MsgBox "Options password has been changed", vbOKOnly + vbInformation, "Information"
                        
            Unload Me
                        
        End If
    End If

End Sub
