VERSION 5.00
Object = "*\ASiExplorer.vbp"
Begin VB.Form frmMain 
   Caption         =   "Form1"
   ClientHeight    =   6150
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   8505
   LinkTopic       =   "Form1"
   ScaleHeight     =   6150
   ScaleWidth      =   8505
   StartUpPosition =   3  'Windows Default
   Begin SiExplorer.Explorer Explorer1 
      Height          =   5505
      Left            =   0
      TabIndex        =   2
      Top             =   -45
      Width           =   8520
      _ExtentX        =   15028
      _ExtentY        =   9710
   End
   Begin VB.CheckBox chkHeadings 
      Caption         =   "Show Headings"
      Height          =   330
      Left            =   1215
      TabIndex        =   1
      Top             =   5625
      Value           =   1  'Checked
      Width           =   1500
   End
   Begin VB.CommandButton bReset 
      Caption         =   "&Reset"
      Height          =   375
      Left            =   90
      TabIndex        =   0
      Top             =   5625
      Width           =   1050
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub bReset_Click()

    Explorer1.Reset

End Sub

Private Sub chkHeadings_Click()

    Explorer1.ShowHeading = CBool(chkHeadings.Value)

End Sub

Private Sub Form_Load()

    With Explorer1
        .Top = 1
        .Left = 1
        .Width = frmMain.Width
        .Height = frmMain.Height - 1050
        .TreeHeading = "Tree Heading"
        .ListHeading = "List Heading"
        .StatusText = "Status bar text"
    End With
    
End Sub

Private Sub Form_Resize()

    With frmMain
        Explorer1.Width = .Width
        Explorer1.Height = .Height - 1050
        bReset.Top = .Height - 930
        chkHeadings.Top = .Height - 930
    End With
    

End Sub
