VERSION 5.00
Begin VB.UserControl Login 
   ClientHeight    =   1695
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   3300
   DefaultCancel   =   -1  'True
   ScaleHeight     =   1695
   ScaleWidth      =   3300
   Begin VB.CommandButton Cancel 
      Caption         =   "&Cancel"
      Height          =   330
      Left            =   1800
      TabIndex        =   5
      Top             =   1170
      Width           =   960
   End
   Begin VB.CommandButton Login 
      Caption         =   "&Login"
      Default         =   -1  'True
      Enabled         =   0   'False
      Height          =   330
      Left            =   630
      TabIndex        =   4
      Top             =   1170
      Width           =   960
   End
   Begin VB.TextBox Password 
      Height          =   330
      IMEMode         =   3  'DISABLE
      Left            =   1300
      PasswordChar    =   "*"
      TabIndex        =   3
      Top             =   675
      Width           =   1700
   End
   Begin VB.TextBox Username 
      Height          =   330
      Left            =   1300
      TabIndex        =   2
      Top             =   180
      Width           =   1700
   End
   Begin VB.Label Label2 
      Caption         =   "Password"
      Height          =   240
      Left            =   180
      TabIndex        =   1
      Top             =   720
      Width           =   1005
   End
   Begin VB.Label Label1 
      Caption         =   "Username"
      Height          =   240
      Left            =   180
      TabIndex        =   0
      Top             =   225
      Width           =   1000
   End
End
Attribute VB_Name = "Login"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

Public Event Cancel()
Public Event Login(Username As String, Password As String)

Private Sub Username_Change()
    
    If Username.Text = "" Or Password.Text = "" Then
        Login.Enabled = False
    Else
        Login.Enabled = True
    End If
        
End Sub

Private Sub Password_Change()
    
    If Username.Text = "" Or Password.Text = "" Then
        Login.Enabled = False
    Else
        Login.Enabled = True
    End If

End Sub

Private Sub Cancel_Click()

    Username.Text = ""
    Password.Text = ""
    RaiseEvent Cancel

End Sub

Private Sub Login_Click()

    RaiseEvent Login(Username.Text, Password.Text)

End Sub

Public Sub Reset()

    Password.Text = ""

End Sub
