VERSION 5.00
Object = "{EAB22AC0-30C1-11CF-A7EB-0000C05BAE0B}#1.1#0"; "SHDOCVW.DLL"
Begin VB.UserControl SimpleWebControl 
   ClientHeight    =   6180
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   8445
   BeginProperty Font 
      Name            =   "MS Serif"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ScaleHeight     =   6180
   ScaleWidth      =   8445
   Begin VB.CommandButton CmdForward 
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   960
      Picture         =   "SimpleWebControl.ctx":0000
      Style           =   1  'Graphical
      TabIndex        =   4
      TabStop         =   0   'False
      ToolTipText     =   "Forward a page"
      Top             =   120
      Width           =   615
   End
   Begin VB.CommandButton CmdBack 
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   240
      Picture         =   "SimpleWebControl.ctx":0442
      Style           =   1  'Graphical
      TabIndex        =   3
      TabStop         =   0   'False
      ToolTipText     =   "Previous page"
      Top             =   120
      Width           =   615
   End
   Begin VB.CommandButton CmdClose 
      Caption         =   "Close browser"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   6480
      TabIndex        =   2
      Top             =   120
      Width           =   1815
   End
   Begin SHDocVwCtl.WebBrowser WebBrowser1 
      Height          =   4935
      Left            =   120
      TabIndex        =   0
      Top             =   1200
      Width           =   8175
      ExtentX         =   14420
      ExtentY         =   8705
      ViewMode        =   1
      Offline         =   0
      Silent          =   0
      RegisterAsBrowser=   0
      RegisterAsDropTarget=   1
      AutoArrange     =   -1  'True
      NoClientEdge    =   0   'False
      AlignLeft       =   0   'False
      ViewID          =   "{0057D0E0-3573-11CF-AE69-08002B2E1262}"
      Location        =   ""
   End
   Begin VB.Label Label1 
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   -1  'True
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   120
      TabIndex        =   1
      Top             =   720
      Width           =   6135
   End
End
Attribute VB_Name = "SimpleWebControl"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Dim store_label As String
Dim site_complete As Boolean
Public Event CloseBrowser()

Private Sub CmdBack_Click()
    On Error Resume Next
    WebBrowser1.GoBack
End Sub

Private Sub CmdClose_Click()
    RaiseEvent CloseBrowser
End Sub

Private Sub CmdForward_Click()
    On Error Resume Next
    WebBrowser1.GoForward
End Sub

Private Sub UserControl_Initialize()
    site_complete = False
End Sub

Public Property Get NavigateUrl() As Variant
    'write only property
End Property

Public Property Let NavigateUrl(ByVal URL As Variant)
    WebBrowser1.Navigate URL
End Property

Public Property Get SetComment() As Variant
    'write only property
End Property

Public Property Let SetComment(ByVal vNewValue As Variant)
    store_label = vNewValue
    'Label1.Caption = vNewValue
End Property

Private Sub WebBrowser1_BeforeNavigate2(ByVal pDisp As Object, URL As Variant, Flags As Variant, TargetFrameName As Variant, PostData As Variant, Headers As Variant, Cancel As Boolean)
    Label1.Caption = "Locating site, please wait....."
End Sub

Private Sub WebBrowser1_NavigateComplete2(ByVal pDisp As Object, URL As Variant)
    Label1.Caption = store_label
End Sub
