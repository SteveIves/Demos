VERSION 5.00
Begin VB.Form frmAbout 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "About Web Generator"
   ClientHeight    =   2880
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   5385
   ClipControls    =   0   'False
   Icon            =   "frmAbout.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2880
   ScaleWidth      =   5385
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Tag             =   "ForeVB DB=S:\Source\VB\Nss\gui\docs\WebGen.dba"
   WhatsThisButton =   -1  'True
   WhatsThisHelp   =   -1  'True
   Begin VB.PictureBox picIcon 
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BorderStyle     =   0  'None
      ClipControls    =   0   'False
      ForeColor       =   &H80000008&
      Height          =   480
      Left            =   240
      Picture         =   "frmAbout.frx":0442
      ScaleHeight     =   480
      ScaleMode       =   0  'User
      ScaleWidth      =   480
      TabIndex        =   1
      TabStop         =   0   'False
      Top             =   240
      Width           =   480
   End
   Begin VB.CommandButton cmdOK 
      Cancel          =   -1  'True
      Caption         =   "OK"
      Default         =   -1  'True
      Height          =   345
      Left            =   4005
      TabIndex        =   0
      Tag             =   "OK"
      Top             =   2250
      Width           =   1110
   End
   Begin VB.Line Line1 
      X1              =   270
      X2              =   5130
      Y1              =   2025
      Y2              =   2025
   End
   Begin VB.Label lblDescription 
      Caption         =   $"frmAbout.frx":0884
      ForeColor       =   &H00000000&
      Height          =   945
      Left            =   1035
      TabIndex        =   5
      Tag             =   "App Description"
      Top             =   945
      Width           =   4095
   End
   Begin VB.Label lblTitle 
      Caption         =   "Web Generator for Northsea Software Systems"
      ForeColor       =   &H00000000&
      Height          =   300
      Left            =   1035
      TabIndex        =   4
      Tag             =   "Application Title"
      Top             =   225
      Width           =   4095
   End
   Begin VB.Label lblVersion 
      Caption         =   "Version"
      Height          =   225
      Left            =   1035
      TabIndex        =   3
      Tag             =   "Version"
      Top             =   630
      Width           =   4095
   End
   Begin VB.Label lblDisclaimer 
      Caption         =   "Copyright Internet Software Services Ltd, 1999. All rights reserved."
      ForeColor       =   &H00000000&
      Height          =   510
      Left            =   255
      TabIndex        =   2
      Tag             =   "Warning: ..."
      Top             =   2160
      Width           =   3510
   End
End
Attribute VB_Name = "frmAbout"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()
    
    lblVersion.Caption = "Version " & App.Major & "." & App.Minor

End Sub

Private Sub cmdOK_Click()

    Unload Me

End Sub

