VERSION 5.00
Object = "{5854F53B-82BF-11D3-AA50-00A024A9DEBF}#35.0#0"; "PSG.ocx"
Begin VB.Form WordTest 
   Caption         =   "Form1"
   ClientHeight    =   5400
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   8055
   LinkTopic       =   "Form1"
   ScaleHeight     =   5400
   ScaleWidth      =   8055
   StartUpPosition =   3  'Windows Default
   Begin PSG.MsWord MsWord1 
      Height          =   4215
      Left            =   480
      TabIndex        =   0
      Top             =   300
      Width           =   6375
      _ExtentX        =   11245
      _ExtentY        =   7435
   End
End
Attribute VB_Name = "WordTest"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()

    Dim FileName As String
    FileName = "c:\steve.doc"

    With MsWord1
        .SaveDocumentAs FileName
        .AddText "ABCDEF"
        .SaveDocument
        .AddText "ABCDEF"
        .SaveDocument
        .AddText "ABCDEF"
        .SaveDocument
        .CloseDocument
    End With
    
    MsgBox "Created file " & FileName

    End

End Sub

