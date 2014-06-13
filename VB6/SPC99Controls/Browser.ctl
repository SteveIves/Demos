VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{EAB22AC0-30C1-11CF-A7EB-0000C05BAE0B}#1.1#0"; "shdocvw.dll"
Begin VB.UserControl Browser 
   ClientHeight    =   3600
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4800
   ScaleHeight     =   3600
   ScaleWidth      =   4800
   Begin MSComctlLib.Toolbar Toolbar1 
      Align           =   1  'Align Top
      Height          =   435
      Left            =   0
      TabIndex        =   2
      Top             =   330
      Width           =   4800
      _ExtentX        =   8467
      _ExtentY        =   767
      ButtonWidth     =   609
      ButtonHeight    =   609
      Appearance      =   1
      _Version        =   393216
      Begin VB.ComboBox Address 
         Height          =   315
         Left            =   45
         TabIndex        =   3
         Top             =   45
         Width           =   4695
      End
   End
   Begin MSComctlLib.ImageList ImageList 
      Left            =   4140
      Top             =   2880
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   7
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Browser.ctx":0000
            Key             =   "Back"
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Browser.ctx":0452
            Key             =   "Forward"
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Browser.ctx":08A4
            Key             =   "Stop"
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Browser.ctx":0CF6
            Key             =   "Home"
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Browser.ctx":1148
            Key             =   "Refresh"
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Browser.ctx":159A
            Key             =   "Find"
         EndProperty
         BeginProperty ListImage7 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Browser.ctx":19EC
            Key             =   "Exit"
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.Toolbar Toolbar 
      Align           =   1  'Align Top
      Height          =   330
      Left            =   0
      TabIndex        =   1
      Top             =   0
      Width           =   4800
      _ExtentX        =   8467
      _ExtentY        =   582
      ButtonWidth     =   609
      AllowCustomize  =   0   'False
      Style           =   1
      ImageList       =   "ImageList"
      _Version        =   393216
      BeginProperty Buttons {66833FE8-8583-11D1-B16A-00C0F0283628} 
         NumButtons      =   6
         BeginProperty Button1 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "Back"
            Description     =   "Back to previous page"
            Object.ToolTipText     =   "Back"
            ImageKey        =   "Back"
         EndProperty
         BeginProperty Button2 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "Forward"
            Description     =   "Forward to next page"
            Object.ToolTipText     =   "Forward"
            ImageKey        =   "Forward"
         EndProperty
         BeginProperty Button3 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Description     =   "Separator"
            Style           =   3
            Object.Width           =   500
         EndProperty
         BeginProperty Button4 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "Stop"
            Description     =   "Stop current operation"
            Object.ToolTipText     =   "Stop"
            ImageKey        =   "Stop"
         EndProperty
         BeginProperty Button5 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "Home"
            Description     =   "Return to home page"
            Object.ToolTipText     =   "Home"
            ImageKey        =   "Home"
         EndProperty
         BeginProperty Button6 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "Refresh"
            Description     =   "Re-load the current page"
            Object.ToolTipText     =   "Refresh"
            ImageKey        =   "Refresh"
         EndProperty
      EndProperty
   End
   Begin SHDocVwCtl.WebBrowser WebBrowser 
      Height          =   2265
      Left            =   315
      TabIndex        =   0
      Top             =   1080
      Width           =   3210
      ExtentX         =   5662
      ExtentY         =   3995
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
End
Attribute VB_Name = "Browser"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

Dim DontNavigateNow As Boolean

Public Event LocationChange(LocationName As String)

Private Sub Address_Click()

    If DontNavigateNow Then Exit Sub
    WebBrowser.Navigate2 (Address.Text)

End Sub

Private Sub Address_KeyPress(KeyAscii As Integer)

    On Error Resume Next
    If KeyAscii = vbKeyReturn Then
        Address_Click
    End If

End Sub

Private Sub Toolbar_ButtonClick(ByVal Button As MSComctlLib.Button)

    On Error Resume Next

    Select Case Button.Key
    Case "Back":
        WebBrowser.GoBack
    Case "Forward":
        WebBrowser.GoForward
    Case "Stop":
        WebBrowser.Stop
    Case "Home":
        WebBrowser.GoHome
        Address.AddItem (WebBrowser.LocationURL)
        Address.ListIndex = Address.NewIndex
    Case "Refresh"
        WebBrowser.Refresh
    End Select

End Sub

Private Sub UserControl_Resize()
    
    'Size and position browser
    With WebBrowser
        .Top = Toolbar.Height + Toolbar1.Height + 1
        .Left = 1
        .Height = Height - Toolbar.Height - Toolbar1.Height
        .Width = Width
    End With

    With Address
        .Width = Width - 50
    End With

End Sub

Public Sub ShowPage(ByVal NewPage As String)

    With Address
        .Text = NewPage
        .AddItem .Text
    End With
    WebBrowser.Navigate2 (NewPage)

End Sub

Public Sub Resize(ByVal NewWidth As Long, ByVal NewHeight As Long)

    Dim TwipWidth, PixelWidth, TwipHeight, PixelHeight As Long
    
    'Get current dimension of control in twips
    UserControl.ScaleMode = vbTwips
    TwipWidth = UserControl.ScaleWidth
    TwipHeight = UserControl.ScaleHeight
    
    'Get current dimension of control in pixels
    UserControl.ScaleMode = vbPixels
    PixelWidth = UserControl.ScaleWidth
    PixelHeight = UserControl.ScaleHeight
    
    'Apply new twip dimensions to control
    With UserControl
        .ScaleMode = vbTwips
        .Width = NewWidth * (TwipWidth / PixelWidth)
        .Height = NewHeight * (TwipHeight / PixelHeight)
    End With

End Sub

Private Sub WebBrowser_DocumentComplete(ByVal pDisp As Object, URL As Variant)

    On Error Resume Next
    RaiseEvent LocationChange(WebBrowser.LocationName)

End Sub

Private Sub WebBrowser_NavigateComplete2(ByVal pDisp As Object, URL As Variant)

    Dim i As Integer
    Dim Found As Boolean
    RaiseEvent LocationChange(WebBrowser.LocationName)
    For i = 0 To Address.ListCount - 1
        If Address.List(i) = WebBrowser.LocationURL Then
            Found = True
            Exit For
        End If
    Next i
    DontNavigateNow = True
    If Found Then
        Address.RemoveItem i
    End If
    With Address
        .AddItem WebBrowser.LocationURL, 0
        .ListIndex = 0
    End With
    DontNavigateNow = False

End Sub
