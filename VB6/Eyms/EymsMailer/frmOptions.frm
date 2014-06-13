VERSION 5.00
Begin VB.Form frmOptions 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Options"
   ClientHeight    =   5535
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   6180
   HelpContextID   =   5
   Icon            =   "frmOptions.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5535
   ScaleWidth      =   6180
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton bHelp 
      Caption         =   "&Help"
      Height          =   315
      Left            =   5160
      TabIndex        =   11
      Top             =   5100
      Width           =   915
   End
   Begin VB.Frame Frame3 
      Caption         =   "ZIP File Options"
      Height          =   1215
      Left            =   120
      TabIndex        =   21
      Top             =   3720
      Width           =   5955
      Begin VB.TextBox optZipDir 
         Height          =   300
         Left            =   1680
         TabIndex        =   7
         Top             =   360
         Width           =   4000
      End
      Begin VB.CheckBox optDeleteZip 
         Caption         =   "Delete ZIP files after sending"
         Height          =   255
         Left            =   1680
         TabIndex        =   8
         Top             =   780
         Width           =   2475
      End
      Begin VB.Label Label4 
         Caption         =   "Zip File Directory"
         Height          =   255
         Left            =   180
         TabIndex        =   22
         Top             =   360
         Width           =   1335
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "E-Mail Options"
      Height          =   2115
      Left            =   120
      TabIndex        =   15
      Top             =   1500
      Width           =   5955
      Begin VB.TextBox optMailProfile 
         Height          =   300
         Left            =   1680
         TabIndex        =   5
         Top             =   1200
         Width           =   4000
      End
      Begin VB.TextBox optMailPassword 
         Height          =   300
         IMEMode         =   3  'DISABLE
         Left            =   1680
         PasswordChar    =   "*"
         TabIndex        =   6
         Top             =   1560
         Width           =   4000
      End
      Begin VB.TextBox optToName 
         Height          =   300
         Left            =   1680
         TabIndex        =   3
         Top             =   360
         Width           =   4000
      End
      Begin VB.TextBox optToAddress 
         Height          =   300
         Left            =   1680
         TabIndex        =   4
         Top             =   720
         Width           =   4000
      End
      Begin VB.Label Label8 
         Caption         =   "Local Mail Profile"
         Height          =   255
         Left            =   180
         TabIndex        =   20
         Top             =   1200
         Width           =   1395
      End
      Begin VB.Label Label7 
         Caption         =   "Profile Password"
         Height          =   255
         Left            =   180
         TabIndex        =   19
         Top             =   1560
         Width           =   1755
      End
      Begin VB.Label Label5 
         Caption         =   "Email To (Name)"
         Height          =   255
         Left            =   180
         TabIndex        =   18
         Top             =   360
         Width           =   1755
      End
      Begin VB.Label Label6 
         Caption         =   "Email to (Address)"
         Height          =   255
         Left            =   180
         TabIndex        =   17
         Top             =   720
         Width           =   1755
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Depot Options"
      Height          =   1275
      Left            =   120
      TabIndex        =   12
      Top             =   120
      Width           =   5895
      Begin VB.TextBox optBaseDataDir 
         Height          =   300
         Left            =   1680
         TabIndex        =   2
         Top             =   780
         Width           =   3945
      End
      Begin VB.TextBox optDepotName 
         Height          =   300
         Left            =   3420
         TabIndex        =   1
         Top             =   300
         Width           =   2205
      End
      Begin VB.TextBox optDepotCode 
         Height          =   300
         Left            =   1680
         TabIndex        =   0
         Top             =   300
         Width           =   525
      End
      Begin VB.Label Label2 
         Caption         =   "Base Data Directory"
         Height          =   255
         Left            =   180
         TabIndex        =   16
         Top             =   840
         Width           =   1515
      End
      Begin VB.Label Label3 
         Caption         =   "Depot Name"
         Height          =   255
         Left            =   2340
         TabIndex        =   14
         Top             =   360
         Width           =   1035
      End
      Begin VB.Label Label1 
         Caption         =   "Depot Code"
         Height          =   255
         Left            =   180
         TabIndex        =   13
         Top             =   360
         Width           =   1035
      End
   End
   Begin VB.CommandButton bCancel 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   315
      Left            =   4140
      TabIndex        =   10
      Top             =   5100
      Width           =   915
   End
   Begin VB.CommandButton bOK 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   315
      Left            =   3120
      TabIndex        =   9
      Top             =   5100
      Width           =   915
   End
End
Attribute VB_Name = "frmOptions"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub bCancel_Click()

    'Close options dialog
    Unload Me

End Sub

Private Sub bHelp_Click()

    With FrmMain.CommonDialog1
        .HelpCommand = cdlHelpContext
        .HelpContext = 5
        .ShowHelp
    End With

End Sub

Private Sub bOK_Click()

    'Validate all required fields contain data
    If optBaseDataDir.Text = "" Or optDepotCode.Text = "" Or optDepotName.Text = "" Or optToAddress.Text = "" Or optToName.Text = "" Or optZipDir.Text = "" Then
        MsgBox "Required data is missing!", vbOKOnly + vbExclamation, "Error"
        Exit Sub
    End If

    'Make sure that the depot code is uppercase
    optDepotCode.Text = UCase(optDepotCode.Text)

    'Make sure directory specs have trailing \'s
    If Right(optBaseDataDir, 1) <> "\" Then optBaseDataDir = optBaseDataDir + "\"
    If Right(optZipDir, 1) <> "\" Then optZipDir = optZipDir + "\"

    'Save settings to configuration variables
    FrmMain.BaseDataDir = optBaseDataDir.Text
    FrmMain.DepotCode = optDepotCode.Text
    FrmMain.DepotName = optDepotName.Text
    FrmMain.MailProfile = optMailProfile.Text
    FrmMain.MailPassword = optMailPassword.Text
    FrmMain.ToAddress = optToAddress.Text
    FrmMain.ToName = optToName.Text
    FrmMain.ZipDir = optZipDir.Text
    If optDeleteZip.Value = 1 Then
        FrmMain.DeleteZip = "Yes"
    Else
        FrmMain.DeleteZip = "No"
    End If

    'Save settings to Registry
    SaveSettingString HKEY_LOCAL_MACHINE, FrmMain.RegPath, "BaseDataDir", optBaseDataDir.Text
    SaveSettingString HKEY_LOCAL_MACHINE, FrmMain.RegPath, "DepotCode", optDepotCode.Text
    SaveSettingString HKEY_LOCAL_MACHINE, FrmMain.RegPath, "DepotName", optDepotName.Text
    SaveSettingString HKEY_LOCAL_MACHINE, FrmMain.RegPath, "MailProfile", optMailProfile.Text
    SaveSettingString HKEY_LOCAL_MACHINE, FrmMain.RegPath, "MailPassword", optMailPassword.Text
    SaveSettingString HKEY_LOCAL_MACHINE, FrmMain.RegPath, "ToAddress", optToAddress.Text
    SaveSettingString HKEY_LOCAL_MACHINE, FrmMain.RegPath, "ToName", optToName.Text
    SaveSettingString HKEY_LOCAL_MACHINE, FrmMain.RegPath, "ZipDir", optZipDir.Text
    If optDeleteZip.Value = 1 Then
        SaveSettingString HKEY_LOCAL_MACHINE, FrmMain.RegPath, "DeleteZip", "Yes"
    Else
        SaveSettingString HKEY_LOCAL_MACHINE, FrmMain.RegPath, "DeleteZip", "No"
    End If

    'Close options dialog
    Unload Me

End Sub

Private Sub Form_Load()

    optBaseDataDir.Text = FrmMain.BaseDataDir
    optDepotCode.Text = FrmMain.DepotCode
    optDepotName.Text = FrmMain.DepotName
    optMailProfile.Text = FrmMain.MailProfile
    optMailPassword.Text = FrmMain.MailPassword
    optToAddress.Text = FrmMain.ToAddress
    optToName.Text = FrmMain.ToName
    optZipDir.Text = FrmMain.ZipDir
    If FrmMain.DeleteZip = "Yes" Then
        optDeleteZip.Value = 1
    Else
        optDeleteZip.Value = 0
    End If

End Sub

Private Sub optBaseDataDir_GotFocus()

    With optBaseDataDir
        .SelStart = 0
        .SelLength = Len(.Text)
    End With

End Sub

Private Sub optDepotCode_GotFocus()

    With optDepotCode
        .SelStart = 0
        .SelLength = Len(.Text)
    End With

End Sub

Private Sub optDepotName_GotFocus()

    With optDepotName
        .SelStart = 0
        .SelLength = Len(.Text)
    End With

End Sub

Private Sub optMailProfile_GotFocus()

    With optMailProfile
        .SelStart = 0
        .SelLength = Len(.Text)
    End With

End Sub

Private Sub optMailPassword_GotFocus()

    With optMailPassword
        .SelStart = 0
        .SelLength = Len(.Text)
    End With

End Sub

Private Sub optToAddress_GotFocus()

    With optToAddress
        .SelStart = 0
        .SelLength = Len(.Text)
    End With

End Sub

Private Sub optToName_GotFocus()

    With optToName
        .SelStart = 0
        .SelLength = Len(.Text)
    End With

End Sub

Private Sub optZipDir_GotFocus()

    With optZipDir
        .SelStart = 0
        .SelLength = Len(.Text)
    End With

End Sub

