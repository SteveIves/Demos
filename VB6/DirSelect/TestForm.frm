VERSION 5.00
Object = "{71B1CEEC-67CA-4463-8860-02DA299BEEA9}#1.0#0"; "SynPsg.ocx"
Begin VB.Form TestForm 
   Caption         =   "Form1"
   ClientHeight    =   4140
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6135
   LinkTopic       =   "Form1"
   ScaleHeight     =   4140
   ScaleWidth      =   6135
   StartUpPosition =   3  'Windows Default
   Begin SynPsg.DirSelect DirSelect1 
      Height          =   3915
      Left            =   120
      TabIndex        =   0
      Top             =   60
      Width           =   5835
      _ExtentX        =   10292
      _ExtentY        =   6906
   End
End
Attribute VB_Name = "TestForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Form_Load()
    
    DirSelect1.Path = "c:\"

End Sub

Private Sub DirSelect1_DirCancel()

    MsgBox "Cancel"
    End

End Sub

Private Sub DirSelect1_DirSelect(Path As String)

    MsgBox Path
    End

End Sub

