VERSION 5.00
Begin {AC0714F6-3D04-11D1-AE7D-00A0C90F26F4} Connect 
   ClientHeight    =   15975
   ClientLeft      =   1740
   ClientTop       =   1545
   ClientWidth     =   18330
   _ExtentX        =   32332
   _ExtentY        =   28178
   _Version        =   393216
   Description     =   "This addin enables you to export MapPoint PushPins to TomTom OV2 format."
   DisplayName     =   "MapPoint to OV2 Utility"
   AppName         =   "Microsoft MapPoint"
   AppVer          =   "Microsoft MapPoint 11.0"
   LoadName        =   "Startup"
   LoadBehavior    =   3
   RegLocation     =   "HKEY_CURRENT_USER\Software\Microsoft\MapPoint"
End
Attribute VB_Name = "Connect"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Public m_formDisplayed   As Boolean
Public g_oApp            As MapPoint.Application
Dim m_frmAddIn           As New frmAddIn

Sub Hide() '--Hides the form and remembers its state
    On Error Resume Next
    m_formDisplayed = False
    m_frmAddIn.Hide
End Sub

Sub Show() '--Shows the form and remembers its state
    On Error Resume Next
    
    If m_frmAddIn Is Nothing Then
        Set m_frmAddIn = New frmAddIn
    End If
    
    Set m_frmAddIn.g_oApp = g_oApp
    Set m_frmAddIn.Connect = Me
    m_formDisplayed = True
    m_frmAddIn.Show vbModal
End Sub

'------------------------------------------------------
'This method adds the add-in to MapPoint
'------------------------------------------------------
Private Sub AddinInstance_OnConnection(ByVal Application As Object, ByVal ConnectMode As AddInDesignerObjects.ext_ConnectMode, ByVal AddInInst As Object, custom() As Variant)
    On Error GoTo error_handler
    
    'Save the MapPoint instance
    Set g_oApp = Application
        
    '--The following has the name of the menu item that is added:
    g_oApp.AddCommand "Export TomTom POI's ...", "Show", Me
    If ConnectMode = ext_cm_AfterStartup Then
        If GetSetting(App.Title, "Settings", "DisplayOnConnect", _
              "0") = "1" Then
            'Set this to display the form on connect
            Me.Show
        End If
    End If
    Exit Sub
    
error_handler:
    MsgBox Err.Description
End Sub

'------------------------------------------------------
'This method removes the add-in from MapPoint
'------------------------------------------------------
Private Sub AddinInstance_OnDisconnection(ByVal RemoveMode As AddInDesignerObjects.ext_DisconnectMode, custom() As Variant)
    On Error Resume Next
    
    'Delete the commands that were added for this add-in
    g_oApp.RemoveCommands Me
    Unload m_frmAddIn
    Set m_frmAddIn = Nothing
End Sub

