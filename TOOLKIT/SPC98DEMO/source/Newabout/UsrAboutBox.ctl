VERSION 5.00
Begin VB.UserControl UsrAboutBox 
   ClientHeight    =   3780
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   5310
   EditAtDesignTime=   -1  'True
   ScaleHeight     =   3780
   ScaleWidth      =   5310
   Begin VB.PictureBox picIcon 
      AutoSize        =   -1  'True
      BackColor       =   &H00C0C0C0&
      BorderStyle     =   0  'None
      ClipControls    =   0   'False
      Height          =   480
      Left            =   240
      Picture         =   "UsrAboutBox.ctx":0000
      ScaleHeight     =   480
      ScaleMode       =   0  'User
      ScaleWidth      =   480
      TabIndex        =   3
      TabStop         =   0   'False
      Top             =   270
      Width           =   480
   End
   Begin VB.CommandButton cmdAction 
      Caption         =   "OK"
      Height          =   375
      Index           =   0
      Left            =   3840
      TabIndex        =   2
      Top             =   2280
      Width           =   1335
   End
   Begin VB.CommandButton cmdAction 
      Caption         =   "&System Info..."
      Height          =   375
      Index           =   1
      Left            =   3840
      TabIndex        =   1
      Top             =   2760
      Width           =   1335
   End
   Begin VB.CommandButton cmdAction 
      Caption         =   "&Credits"
      Height          =   375
      Index           =   2
      Left            =   3840
      TabIndex        =   0
      Top             =   3240
      Width           =   1335
   End
   Begin VB.Label lblCopyright 
      BackStyle       =   0  'Transparent
      Caption         =   "Copyright Synergex International Corporation"
      ForeColor       =   &H00000000&
      Height          =   570
      Left            =   1050
      TabIndex        =   8
      Top             =   1050
      Width           =   3885
   End
   Begin VB.Label lblDescription 
      BackStyle       =   0  'Transparent
      Caption         =   "Synergy product configuration application."
      ForeColor       =   &H00000000&
      Height          =   570
      Left            =   1050
      TabIndex        =   7
      Top             =   1710
      Width           =   3885
   End
   Begin VB.Label lblTitle 
      BackStyle       =   0  'Transparent
      Caption         =   "Synergy Configurator"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   18
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   480
      Index           =   0
      Left            =   1080
      TabIndex        =   6
      Top             =   240
      Width           =   3885
   End
   Begin VB.Label lblVersion 
      BackStyle       =   0  'Transparent
      Caption         =   "Version 1.0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   225
      Left            =   1050
      TabIndex        =   5
      Top             =   780
      Width           =   3885
   End
   Begin VB.Label lblWarning 
      BackStyle       =   0  'Transparent
      Caption         =   $"UsrAboutBox.ctx":0442
      ForeColor       =   &H00000000&
      Height          =   1335
      Left            =   240
      TabIndex        =   4
      Top             =   2280
      Width           =   3405
   End
End
Attribute VB_Name = "UsrAboutBox"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
'Dim AviFile As String
'Dim WavFile As String
Dim iFrmCheck As New FrmCredit
Dim msSysInfo As String

' Reg Key ROOT Types...
Const HKEY_LOCAL_MACHINE = &H80000002
Const API_SUCCESS = 0
Const KEY_QUERY_VALUE = &H1
Const REG_SZ = 1

Private Declare Function RegOpenKeyEx Lib "advapi32" _
    Alias "RegOpenKeyExA" _
        (ByVal hKey As Long, _
         ByVal lpSubKey As String, _
         ByVal ulOptions As Long, _
         ByVal samDesired As Long, _
         ByRef phkResult As Long) As Long
         
Private Declare Function RegQueryValueEx Lib "advapi32" _
    Alias "RegQueryValueExA" _
        (ByVal hKey As Long, _
         ByVal lpValueName As String, _
         ByVal lpReserved As Long, _
         ByRef lpType As Long, _
         ByVal lpData As String, _
         ByRef lpcbData As Long) As Long
         
Private Declare Function RegCloseKey Lib "advapi32" _
        (ByVal hKey As Long) As Long

Public Event CloseAbout()

Private Sub cmdAction_Click(Index As Integer)
Dim LeftPoint As Integer
Dim TopPoint As Integer

    Select Case Index
    Case 0
        RaiseEvent CloseAbout
    Case 1
        Call Shell(msSysInfo, vbNormalFocus)
    Case 2
        LeftPoint = 3375
        topoint = 3375
        iFrmCheck.CurrentX = LeftPoint
        iFrmCheck.CurrentY = TopPoint
        iFrmCheck.Show 1
    End Select
End Sub

Private Sub UserControl_Initialize()


' Look for the system information program
' If it is found, enable the command button

' Try to get program and path name from the registry
msSysInfo = GetRegString(HKEY_LOCAL_MACHINE, _
        "SOFTWARE\Microsoft\Shared Tools\MSInfo", _
        "PATH")
If Len(msSysInfo) = 0 Then
    ' Did not find that, so ...
    ' Try to get path alone from the registry
    msSysInfo = GetRegString(HKEY_LOCAL_MACHINE, _
            "SOFTWARE\Microsoft\Shared Tools Location", _
            "MSINFO")
    If Len(msSysInfo) <> 0 Then
        ' We have a path so add the file name
        ' Look for the 32 bit version of the program
        msSysInfo = msSysInfo & "\MSINFO32.EXE"
    End If
End If

End Sub
Private Function GetRegString _
                (lRegRoot As Long, _
                 sRegKey As String, _
                 sSubKey As String) As String

Dim hRegKey             As Long
Dim lResult             As Long
Dim lValueSize          As Long
Dim lValueType          As Long
Dim sTempStr            As String

Const REG_SZ = 1

GetRegString = ""

lResult = RegOpenKeyEx(lRegRoot, _
            sRegKey, _
            0&, _
            KEY_QUERY_VALUE, _
            hRegKey)
            
If lResult = API_SUCCESS Then
    ' Get the length of the value string
    lResult = RegQueryValueEx(hRegKey, _
            sSubKey, _
            0&, _
            lValueType, _
            ByVal 0&, _
            lValueSize)
            
    ' Make sure it is a string value type
    If lValueType = REG_SZ Then
        ' Initialize the variable to hold the string
        sTempStr = String(lValueSize, " ")
        ' Get the value from the registry
        lResult = RegQueryValueEx(hRegKey, _
            sSubKey, _
            0&, 0&, _
            ByVal sTempStr, _
            lValueSize)
            
        If lResult = API_SUCCESS Then
            GetRegString = Left$(sTempStr, _
                    InStr(sTempStr, vbNullChar) - 1)
        End If
    End If
    ' Close the registry key
    lResult = RegCloseKey(hRegKey)
End If

End Function

Public Sub SetAvifile(ByVal sNewAvi As String, ByVal sNewWav As String)
    Call FrmCredit.SetFileNames(sNewAvi, sNewWav)
End Sub
