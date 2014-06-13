VERSION 5.00
Object = "*\A..\CALCUL~1\CalcCtrl.vbp"
Begin VB.Form Main 
   Caption         =   "Calculator Test Container"
   ClientHeight    =   4755
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   4755
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin CalcCtrl.CalcCtrl1 CalcCtrl11 
      Height          =   2175
      Left            =   1620
      TabIndex        =   1
      Top             =   1305
      Width           =   1455
      _ExtentX        =   2566
      _ExtentY        =   3836
   End
   Begin VB.TextBox Display 
      Enabled         =   0   'False
      Height          =   375
      Left            =   360
      TabIndex        =   0
      Top             =   360
      Width           =   3855
   End
End
Attribute VB_Name = "Main"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub CalcCtrl11_CalcDone()

    MsgBox "Calculaition complete"

End Sub

Private Sub CalcCtrl11_CloseCalc()

    MsgBox "Exit calculator"

End Sub

Private Sub CalcCtrl11_DisplayNumber(CurrentValue As Double)

    Display.Text = CStr(CurrentValue)

End Sub

