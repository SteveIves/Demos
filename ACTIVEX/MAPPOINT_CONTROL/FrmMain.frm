VERSION 5.00
Object = "{9425D128-6763-451F-9C98-D9CFA7D9922F}#64.0#0"; "SynMapPoint.ocx"
Begin VB.Form FrmMain 
   Caption         =   "Form1"
   ClientHeight    =   7350
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   9585
   LinkTopic       =   "Form1"
   ScaleHeight     =   7350
   ScaleWidth      =   9585
   StartUpPosition =   3  'Windows Default
   Begin SynMapPoint.MapPointControl MapPointControl1 
      Height          =   5295
      Left            =   1020
      TabIndex        =   0
      Top             =   1080
      Width           =   7575
      _ExtentX        =   13361
      _ExtentY        =   9340
   End
End
Attribute VB_Name = "FrmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Resize()

    With MapPointControl1
        .Top = 1
        .Left = 1
        .Width = Me.ScaleWidth
        .Height = Me.ScaleHeight
    End With


End Sub
