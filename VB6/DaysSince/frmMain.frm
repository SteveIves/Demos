VERSION 5.00
Begin VB.Form frmMain 
   BorderStyle     =   3  'Fixed Dialog
   ClientHeight    =   1680
   ClientLeft      =   45
   ClientTop       =   45
   ClientWidth     =   6900
   ControlBox      =   0   'False
   BeginProperty Font 
      Name            =   "Verdana"
      Size            =   36
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1680
   ScaleWidth      =   6900
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      AutoSize        =   -1  'True
      Caption         =   "Label1"
      Height          =   885
      Left            =   1020
      TabIndex        =   0
      Top             =   360
      Width           =   5055
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Click()

    Unload Me

End Sub

Private Sub Form_Load()

    'Label1.Caption = DateDiff("d", DateSerial(1999, 12, 1), Date) & " Days"
    Label1.Caption = "It's day " & DateDiff("d", DateSerial(2004, 5, 2), Date)

End Sub

Private Sub Label1_Click()

    Unload frmMain

End Sub
