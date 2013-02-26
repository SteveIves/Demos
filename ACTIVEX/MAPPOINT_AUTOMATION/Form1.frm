VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   4185
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   6300
   LinkTopic       =   "Form1"
   ScaleHeight     =   4185
   ScaleWidth      =   6300
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton BtnRoute 
      Caption         =   "Calc Route"
      Height          =   495
      Left            =   120
      TabIndex        =   5
      Top             =   2520
      Width           =   2175
   End
   Begin VB.CommandButton BtnPushPin2 
      Caption         =   "Add Push Pin 2"
      Height          =   495
      Left            =   120
      TabIndex        =   4
      Top             =   1920
      Width           =   2175
   End
   Begin VB.CommandButton BtnPushPin1 
      Caption         =   "Add Push Pin 1"
      Height          =   495
      Left            =   120
      TabIndex        =   3
      Top             =   1320
      Width           =   2175
   End
   Begin VB.CommandButton BtnGotoAddress 
      Caption         =   "Goto Address"
      Height          =   495
      Left            =   120
      TabIndex        =   2
      Top             =   720
      Width           =   2175
   End
   Begin VB.CommandButton BtnDelete 
      Caption         =   "Delete Control"
      Height          =   495
      Left            =   120
      TabIndex        =   1
      Top             =   3120
      Width           =   2175
   End
   Begin VB.CommandButton BtnCreateControl 
      Caption         =   "Create Control"
      Height          =   495
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   2175
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim SynMapPoint As Object

Private Sub BtnCreateControl_Click()

    Set SynMapPoint = CreateObject("SynMapPoint.Map")

End Sub

Private Sub BtnGotoAddress_Click()

    Call SynMapPoint.GotoAddress("1601 Vineyard Road, Roseville, CA, 95747")

End Sub

Private Sub BtnPushPin1_Click()
    
    Call SynMapPoint.AddPushPin("1601 Vineyard Road, Roseville, CA, 95747", "My Apartment", "Note 1", True)

End Sub

Private Sub BtnPushPin2_Click()

    Call SynMapPoint.AddPushPin("2330 Gold Meadow Way, Gold River, CA, 95670", "Synergex", "Note 2", True)

End Sub

Private Sub BtnRoute_Click()

    Call SynMapPoint.CreateRoute

End Sub

Private Sub BtnDelete_Click()

    Call SynMapPoint.SaveMap("C:\map.ptm")
    Set SynMapPoint = Nothing

End Sub

Private Sub Form_Load()

End Sub
