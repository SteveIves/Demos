VERSION 5.00
Object = "{648A5603-2C6E-101B-82B6-000000000014}#1.1#0"; "MSCOMM32.OCX"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3195
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3195
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin MSCommLib.MSComm MSComm1 
      Left            =   1920
      Top             =   630
      _ExtentX        =   794
      _ExtentY        =   794
      _Version        =   393216
      DTREnable       =   -1  'True
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()

    Dim Instring As String              'Input buffer
    MSComm1.CommPort = 1                'Use COM1
    MSComm1.Settings = "115200,N,8,1"   'Port settings
    MSComm1.InputLen = 0                'Read entire buffer when Input used
    MSComm1.PortOpen = True             'Open the port
    MSComm1.Output = "AT" + Chr$(13)    'Send AT
    Do                                  'Wait for data
        DoEvents
    Loop Until MSComm1.InBufferCount >= 2
    Instring = MSComm1.Input            'Read OK response
    MSComm1.PortOpen = False            'Close port

    End

End Sub

