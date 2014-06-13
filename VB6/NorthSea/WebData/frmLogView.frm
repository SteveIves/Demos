VERSION 5.00
Begin VB.Form frmLogView 
   Caption         =   "Log Viewer"
   ClientHeight    =   5160
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   8295
   Icon            =   "frmLogView.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   5160
   ScaleWidth      =   8295
   StartUpPosition =   2  'CenterScreen
   Begin VB.TextBox TextBox 
      Height          =   4935
      Left            =   120
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   0
      Text            =   "frmLogView.frx":0442
      Top             =   120
      Width           =   8055
   End
End
Attribute VB_Name = "frmLogView"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()

    TextBox.Top = 100
    TextBox.Left = 100

End Sub

Private Sub Form_Resize()

    TextBox.Height = Height - 600
    TextBox.Width = Width - 300

End Sub
