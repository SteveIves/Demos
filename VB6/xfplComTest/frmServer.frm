VERSION 5.00
Begin VB.Form frmServer 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Connect to Server ..."
   ClientHeight    =   1320
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   5355
   ControlBox      =   0   'False
   Icon            =   "frmServer.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1320
   ScaleWidth      =   5355
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton bCancel 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   350
      Left            =   3960
      TabIndex        =   5
      Top             =   675
      Width           =   1050
   End
   Begin VB.CommandButton bOK 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   350
      Left            =   3960
      TabIndex        =   4
      Top             =   225
      Width           =   1050
   End
   Begin VB.TextBox serverPort 
      Height          =   315
      Left            =   1800
      MaxLength       =   5
      TabIndex        =   1
      Top             =   675
      Width           =   1845
   End
   Begin VB.TextBox serverName 
      Height          =   315
      Left            =   1800
      TabIndex        =   0
      Top             =   270
      Width           =   1845
   End
   Begin VB.Label Label2 
      Caption         =   "Server Port"
      Height          =   240
      Left            =   315
      TabIndex        =   3
      Top             =   720
      Width           =   1400
   End
   Begin VB.Label Label1 
      Caption         =   "Server Name"
      Height          =   240
      Left            =   315
      TabIndex        =   2
      Top             =   315
      Width           =   1400
   End
End
Attribute VB_Name = "frmServer"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Form_Load()

    'Center dialog above main form
    Top = (frmMain.Top + (frmMain.Height / 2) - (Height / 2))
    Left = (frmMain.Left + (frmMain.Width / 2) - (Width / 2))

    If (gServerName <> "") Then
        serverName.Text = gServerName
    End If
    
    If (gServerPort <> 0) Then
        serverPort.Text = gServerPort
    End If

End Sub

Private Sub bOK_Click()
    
    'Validate server name
    
    If (serverName.Text = "") Then
        MsgBox "Server name is required", vbOKOnly, "Invalid"
        serverName.SetFocus
        Exit Sub
    End If
    
    'Validate server port
    
    If (serverPort.Text = "") Or (IsNumeric(serverPort.Text) = False) Then
        MsgBox "Numeric server port required", vbOKOnly, "Invalid"
        serverPort.Text = ""
        serverPort.SetFocus
        Exit Sub
    End If

    Dim port As Integer
    port = serverPort.Text
    If port < 1024 Or port > 65535 Then
        MsgBox "Server port must be in range 1024 to 65535", vbOKOnly, "Invalid"
        serverPort.Text = ""
        serverPort.SetFocus
        Exit Sub
    End If
    
    gServerName = UCase(serverName.Text)
    gServerPort = serverPort.Text

    Unload Me
    
End Sub

Private Sub bCancel_Click()
    gCancel = True
    Unload Me
End Sub

Private Sub serverName_GotFocus()
    serverName.SelStart = 0
    serverName.SelLength = Len(serverName.Text)
End Sub

Private Sub serverPort_GotFocus()
    serverPort.SelStart = 0
    serverPort.SelLength = Len(serverPort.Text)
End Sub

Private Sub ipAddress_GotFocus()
    ipAddress.SelStart = 0
    ipAddress.SelLength = Len(ipAddress.Text)
End Sub

