VERSION 5.00
Object = "{FBBBDA71-8570-11D3-9195-00E098079A0F}#27.0#0"; "PSG.ocx"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3195
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3195
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin PSG.MsWord MsWord1 
      Height          =   615
      Left            =   660
      TabIndex        =   0
      Top             =   360
      Width           =   975
      _ExtentX        =   1720
      _ExtentY        =   1085
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()

    MsWord1.StartDocument
    MsWord1.AddText "Hello World!"
    MsWord1.EndDocument "C:\steve.doc"

End Sub
