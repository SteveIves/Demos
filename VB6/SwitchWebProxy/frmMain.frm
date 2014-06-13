VERSION 5.00
Begin VB.Form frmMain 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "IE Web Proxy Selection"
   ClientHeight    =   2175
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   4365
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2175
   ScaleWidth      =   4365
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton btnCancel 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   3120
      TabIndex        =   6
      Top             =   1620
      Width           =   1095
   End
   Begin VB.CommandButton btnOK 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   375
      Left            =   1920
      TabIndex        =   5
      Top             =   1620
      Width           =   1095
   End
   Begin VB.CheckBox chkUseProxy 
      Caption         =   "Use Web Proxy Server"
      Height          =   315
      Left            =   240
      TabIndex        =   2
      Top             =   180
      Width           =   2895
   End
   Begin VB.TextBox txtPort 
      Height          =   315
      Left            =   1260
      TabIndex        =   1
      Top             =   1080
      Width           =   1275
   End
   Begin VB.TextBox txtServer 
      Height          =   315
      Left            =   1260
      TabIndex        =   0
      Top             =   660
      Width           =   2955
   End
   Begin VB.Label Label1 
      Caption         =   "Port"
      Height          =   255
      Index           =   1
      Left            =   600
      TabIndex        =   4
      Top             =   1140
      Width           =   615
   End
   Begin VB.Label Label1 
      Caption         =   "Server"
      Height          =   255
      Index           =   0
      Left            =   600
      TabIndex        =   3
      Top             =   720
      Width           =   615
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim OldProxyEnable As Long
Dim OldProxyServer As String
Dim OldProxyName As String
Dim OldProxyPort As String

Private Sub Form_Load()

    Dim Pos As Long

    'Get current settings from Registry
    OldProxyEnable = GetSettingLong(HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Internet Settings", "ProxyEnable", 0)
    OldProxyServer = GetSettingString(HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Internet Settings", "ProxyServer", "")
    
    'Break out any port number
    Pos = InStr(1, OldProxyServer, ":")
    If Pos = 0 Then
        OldProxyName = OldProxyServer
        OldProxyPort = ""
    Else
        OldProxyName = Left(OldProxyServer, Pos - 1)
        OldProxyPort = Right(OldProxyServer, Len(OldProxyServer) - Pos)
    End If
    
    'Put current values into UI
    chkUseProxy.Value = OldProxyEnable
    txtServer.Text = OldProxyName
    txtPort.Text = OldProxyPort

    'Setup UI
    If chkUseProxy.Value = 0 Then
        With txtServer
            .Enabled = False
            .BackColor = vbButtonFace
        End With
        
        With txtPort
            .Enabled = False
            .BackColor = vbButtonFace
        End With
        
    End If
    
End Sub

Private Sub chkUseProxy_Click()

    If chkUseProxy.Value = 0 Then
        With txtServer
            .Enabled = False
            .BackColor = vbButtonFace
        End With
        With txtPort
            .Enabled = False
            .BackColor = vbButtonFace
        End With
    Else
        With txtServer
            .Enabled = True
            .BackColor = vbWindowBackground
        End With
        With txtPort
            .Enabled = True
            .BackColor = vbWindowBackground
        End With
    End If


End Sub

Private Sub btnOK_Click()

    'Save current settings to the Registry

    Dim NewProxyEnable As Long
    Dim NewProxyServer As String
    Dim NewProxyName As String
    Dim NewProxyPort As String
    
    Dim OK As Boolean
    
    OK = True
    
    'Get data from UI
    NewProxyEnable = chkUseProxy.Value
    NewProxyName = Trim(txtServer.Text)
    NewProxyPort = Trim(txtPort.Text)
        
    'Validate data
    If NewProxyEnable = 1 Then
        If NewProxyName = "" Then
            MsgBox ("Server name is required")
            With txtServer
                .Text = OldProxyName
                .SetFocus
            End With
            OK = False
        End If
    End If

    If OK Then
        If NewProxyPort = "" Then
            NewProxyServer = NewProxyName
        Else
            If IsNumeric(NewProxyPort) Then
                NewProxyServer = NewProxyName & ":" & NewProxyPort
            Else
                MsgBox ("Port must be numeric")
                With txtPort
                    .Text = OldProxyPort
                    .SetFocus
                End With
                OK = False
            End If
        End If
    End If

    If OK Then
        
        Call SaveSettingLong(HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Internet Settings", "ProxyEnable", NewProxyEnable)
        Call SaveSettingString(HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Internet Settings", "ProxyServer", NewProxyServer)
    
        End
    
    End If

End Sub

Private Sub btnCancel_Click()

    End

End Sub

