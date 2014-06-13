VERSION 5.00
Begin VB.Form frmDirectory 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Select Directory"
   ClientHeight    =   3945
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   4740
   Icon            =   "frmDirectory.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3945
   ScaleWidth      =   4740
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin webmaster.DirSelect DirSelect1 
      Height          =   3915
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   4695
      _ExtentX        =   8281
      _ExtentY        =   6906
   End
End
Attribute VB_Name = "frmDirectory"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit

Private Sub Form_Load()

    Icon = frmMain.Icon

End Sub

Private Sub DirSelect1_OK()

    Me.Hide

End Sub

Private Sub DirSelect1_Cancel()

    DirSelect1.Directory = ""
    Me.Hide

End Sub
