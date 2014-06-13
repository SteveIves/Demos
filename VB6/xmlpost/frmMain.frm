VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "Comdlg32.ocx"
Begin VB.Form frmMain 
   Caption         =   "Post XML File to Web Server"
   ClientHeight    =   1170
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   7695
   LinkTopic       =   "Form1"
   ScaleHeight     =   1170
   ScaleWidth      =   7695
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton btnPost 
      Caption         =   "&Post"
      Height          =   315
      Left            =   6480
      TabIndex        =   5
      Top             =   600
      Width           =   1155
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   60
      Top             =   660
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton btnBrowse 
      Caption         =   "&Browse"
      Height          =   315
      Left            =   6480
      TabIndex        =   1
      Top             =   120
      Width           =   1155
   End
   Begin VB.TextBox FileName 
      Height          =   315
      Left            =   1440
      TabIndex        =   0
      Top             =   120
      Width           =   4935
   End
   Begin VB.TextBox URL 
      Height          =   315
      Left            =   1440
      TabIndex        =   2
      Top             =   600
      Width           =   4935
   End
   Begin VB.Label Label1 
      Caption         =   "URL to post to"
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   4
      Top             =   660
      Width           =   1275
   End
   Begin VB.Label Label1 
      Caption         =   "File to post"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   3
      Top             =   180
      Width           =   1275
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub btnBrowse_Click()
    With CommonDialog1
        .DialogTitle = ""
        .DefaultExt = "*.xml"
        .Filter = "XML files|*.xml"
        .ShowOpen
        FileName = .FileName
    End With
End Sub

Private Sub FileName_GotFocus()
    With FileName
        .SelStart = 0
        .SelLength = Len(FileName)
    End With
End Sub

Private Sub URL_GotFocus()
    With URL
        .SelStart = 0
        .SelLength = Len(URL)
    End With
End Sub

Private Sub btnPost_Click()

    If FileName.Text = "" Or URL.Text = "" Then
        MsgBox "Please provide a file name and URL"
    Else
        On Error GoTo ErrHandler
    
        Dim doc As New DOMDocument
        Dim http As New xmlhttp
    
        With doc
            .async = False
            If Not .Load(FileName.Text) Then
                MsgBox ("Failed to load XML data into DOM")
            Else
                With http
                    .Open "POST", URL.Text, False
                    .send doc
                    If .Status <> 200 Then
                        MsgBox ("Upload failed, HTTP response was: " & .Status & " " & .statusText)
                    End If
                End With
            End If
        End With
    
    End If
    
    Exit Sub
    
ErrHandler:

    MsgBox ("Error: " & Err.Number & " " & Err.Description)

End Sub

