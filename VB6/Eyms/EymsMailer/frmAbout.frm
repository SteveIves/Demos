VERSION 5.00
Begin VB.Form frmAbout 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "About EYMS Mailer"
   ClientHeight    =   2535
   ClientLeft      =   2340
   ClientTop       =   1935
   ClientWidth     =   5505
   ClipControls    =   0   'False
   Icon            =   "frmAbout.frx":0000
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1749.702
   ScaleMode       =   0  'User
   ScaleWidth      =   5169.479
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.Frame Frame1 
      Height          =   2415
      Left            =   60
      TabIndex        =   0
      Top             =   60
      Width           =   5355
      Begin VB.CommandButton cmdOK 
         Cancel          =   -1  'True
         Caption         =   "OK"
         Default         =   -1  'True
         Height          =   345
         Left            =   3900
         TabIndex        =   4
         Top             =   1860
         Width           =   1260
      End
      Begin VB.Image Image1 
         BorderStyle     =   1  'Fixed Single
         Height          =   1680
         Left            =   240
         Picture         =   "frmAbout.frx":0442
         Top             =   300
         Width           =   1350
      End
      Begin VB.Label lblVersion 
         Caption         =   "Version"
         Height          =   225
         Left            =   1920
         TabIndex        =   3
         Top             =   660
         Width           =   3105
      End
      Begin VB.Label lblTitle 
         Caption         =   "Application Title"
         ForeColor       =   &H00000000&
         Height          =   300
         Left            =   1920
         TabIndex        =   2
         Top             =   300
         Width           =   3045
      End
      Begin VB.Label lblDescription 
         Caption         =   $"frmAbout.frx":2A53
         ForeColor       =   &H00000000&
         Height          =   885
         Left            =   1920
         TabIndex        =   1
         Top             =   1020
         Width           =   3285
      End
   End
End
Attribute VB_Name = "frmAbout"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    Me.Caption = "About " & App.Title
    lblTitle.Caption = App.Title
    lblVersion.Caption = "Version " & App.Major & "." & App.Minor
End Sub

Private Sub cmdOK_Click()
  Unload Me
End Sub

