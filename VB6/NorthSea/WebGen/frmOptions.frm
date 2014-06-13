VERSION 5.00
Begin VB.Form frmOptions 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Web Generator Options"
   ClientHeight    =   2490
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   6360
   HelpContextID   =   8
   Icon            =   "frmOptions.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2490
   ScaleWidth      =   6360
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Tag             =   "ForeVB DB=S:\Source\VB\Nss\gui\docs\WebGen.dba"
   WhatsThisButton =   -1  'True
   WhatsThisHelp   =   -1  'True
   Begin VB.Frame Frame1 
      Caption         =   "External Programs"
      Height          =   1770
      Left            =   90
      TabIndex        =   2
      Top             =   90
      Width           =   6180
      Begin VB.CommandButton FindFtp 
         Caption         =   "Search"
         Height          =   330
         Left            =   5175
         TabIndex        =   11
         Top             =   1170
         Width           =   825
      End
      Begin VB.TextBox txtFtpClient 
         Height          =   330
         Left            =   1350
         TabIndex        =   10
         Top             =   1170
         Width           =   3660
      End
      Begin VB.CommandButton FindEditor 
         Caption         =   "Search"
         Height          =   330
         Left            =   5175
         TabIndex        =   8
         Top             =   720
         Width           =   825
      End
      Begin VB.CommandButton FindBrowser 
         Caption         =   "Search"
         Height          =   330
         Left            =   5175
         TabIndex        =   7
         Top             =   270
         Width           =   825
      End
      Begin VB.TextBox txtEditor 
         Height          =   330
         Left            =   1350
         TabIndex        =   6
         Top             =   720
         Width           =   3660
      End
      Begin VB.TextBox txtBrowser 
         Height          =   330
         Left            =   1350
         TabIndex        =   4
         Top             =   270
         Width           =   3660
      End
      Begin VB.Label Label3 
         Caption         =   "FTP Client"
         Height          =   285
         Left            =   270
         TabIndex        =   9
         Top             =   1215
         Width           =   870
      End
      Begin VB.Label Label2 
         Caption         =   "HTML Editor"
         Height          =   285
         Left            =   270
         TabIndex        =   5
         Top             =   765
         Width           =   1050
      End
      Begin VB.Label Label1 
         Caption         =   "Web Browser"
         Height          =   285
         Left            =   270
         TabIndex        =   3
         Top             =   315
         Width           =   1050
      End
   End
   Begin VB.CommandButton CancelButton 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   3780
      TabIndex        =   1
      Top             =   1980
      Width           =   1215
   End
   Begin VB.CommandButton OKButton 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   375
      Left            =   5085
      TabIndex        =   0
      Top             =   1980
      Width           =   1215
   End
End
Attribute VB_Name = "frmOptions"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit

Private Sub Form_Activate()

    SaveBrowser = ToolBrowser
    SaveEditor = ToolEditor
    SaveFtpClient = ToolFtpClient

End Sub

Private Sub OKButton_Click()

    'Validate fields
    
    If txtBrowser.Text <> "" Then
        If Dir(txtBrowser.Text) = "" Then
            MsgBox "Browser not found", vbOKOnly + vbCritical, "Error"
            txtBrowser.Text = ""
            Exit Sub
        Else
            ToolBrowser = txtBrowser.Text
        End If
    End If

    If txtEditor.Text <> "" Then
        If Dir(txtEditor.Text) = "" Then
            MsgBox "HTML Editor not found", vbOKOnly + vbCritical, "Error"
            txtEditor.Text = ""
            Exit Sub
        Else
            ToolEditor = txtEditor.Text
        End If
    End If

    If txtFtpClient.Text <> "" Then
        If Dir(txtFtpClient.Text) = "" Then
            MsgBox "FTP Client not found", vbOKOnly + vbCritical, "Error"
            txtFtpClient.Text = ""
            Exit Sub
        Else
            ToolFtpClient = txtFtpClient.Text
        End If
    End If

    'Store the program options away in the registry
    Call SaveSettingString(HKEY_LOCAL_MACHINE, RegPath, "Browser", ToolBrowser)
    Call SaveSettingString(HKEY_LOCAL_MACHINE, RegPath, "Editor", ToolEditor)
    Call SaveSettingString(HKEY_LOCAL_MACHINE, RegPath, "FtpClient", ToolFtpClient)

    'Enable or disable the tools column entries
    fMain.mnuToolsBrowser.Enabled = CBool(ToolBrowser <> "")
    fMain.mnuToolsEditor.Enabled = CBool(ToolEditor <> "")
    fMain.mnuToolsFtp.Enabled = CBool(ToolFtpClient <> "")
    
    'Enable or disable the tools toolbar buttons
    fMain.tbToolBar.Buttons("Browser").Enabled = CBool(ToolBrowser <> "")
    fMain.tbToolBar.Buttons("Editor").Enabled = CBool(ToolEditor <> "")
    fMain.tbToolBar.Buttons("FtpClient").Enabled = CBool(ToolFtpClient <> "")
    
    Me.Hide

End Sub

Private Sub CancelButton_Click()

    'Restore saved settings
    
    ToolBrowser = SaveBrowser
    ToolEditor = SaveEditor
    ToolFtpClient = SaveFtpClient
    
    txtBrowser.Text = SaveBrowser
    txtEditor.Text = SaveEditor
    txtFtpClient = SaveFtpClient

    Me.Hide

End Sub

Private Sub FindBrowser_Click()

    With frmMain.dlgCommonDialog
        
        .FileName = ""
        .DialogTitle = "Find Web Browser"
        .CancelError = False
        .Flags = cdlOFNHideReadOnly + cdlOFNFileMustExist + cdlOFNExplorer + cdlOFNPathMustExist
        .Filter = "Applications (*.exe)|*.exe"
     
        .ShowOpen
        
        If Len(.FileName) <> 0 Then
            txtBrowser.Text = (.FileName)
        End If
    
    End With

End Sub

Private Sub FindEditor_Click()

    With frmMain.dlgCommonDialog
        
        .FileName = ""
        .DialogTitle = "Find HTML Editor"
        .CancelError = False
        .Flags = cdlOFNHideReadOnly + cdlOFNFileMustExist + cdlOFNExplorer + cdlOFNPathMustExist
        .Filter = "Applications (*.exe)|*.exe"
     
        .ShowOpen
        
        If Len(.FileName) <> 0 Then
            txtEditor.Text = (.FileName)
        End If
    
    End With

End Sub

Private Sub FindFtp_Click()

    With frmMain.dlgCommonDialog
        
        .FileName = ""
        .DialogTitle = "Find FTP Client"
        .CancelError = False
        .Flags = cdlOFNHideReadOnly + cdlOFNFileMustExist + cdlOFNExplorer + cdlOFNPathMustExist
        .Filter = "Applications (*.exe)|*.exe"
     
        .ShowOpen
        
        If Len(.FileName) <> 0 Then
            txtFtpClient.Text = (.FileName)
        End If
    
    End With

End Sub

