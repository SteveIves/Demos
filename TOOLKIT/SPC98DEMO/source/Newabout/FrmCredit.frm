VERSION 5.00
Object = "{FE0065C0-1B7B-11CF-9D53-00AA003C9CB6}#1.0#0"; "COMCT232.OCX"
Object = "{C1A8AF28-1257-101B-8FB0-0020AF039CA3}#1.1#0"; "MCI32.OCX"
Begin VB.Form FrmCredit 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Credits"
   ClientHeight    =   2880
   ClientLeft      =   3900
   ClientTop       =   3705
   ClientWidth     =   4005
   Icon            =   "FrmCredit.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   MouseIcon       =   "FrmCredit.frx":0442
   MousePointer    =   99  'Custom
   ScaleHeight     =   2880
   ScaleWidth      =   4005
   ShowInTaskbar   =   0   'False
   Begin MCI.MMControl MMControl1 
      Height          =   495
      Left            =   240
      TabIndex        =   1
      Top             =   1200
      Visible         =   0   'False
      Width           =   3540
      _ExtentX        =   6244
      _ExtentY        =   873
      _Version        =   327680
      DeviceType      =   ""
      FileName        =   ""
   End
   Begin ComCtl2.Animation Animation1 
      Height          =   615
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   1095
      _ExtentX        =   1931
      _ExtentY        =   1085
      _Version        =   327680
      FullWidth       =   73
      FullHeight      =   41
   End
End
Attribute VB_Name = "FrmCredit"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Form_Load()
    
    MMControl1.filename = WavFile
    MMControl1.Command = "Open"
    MMControl1.Command = "Play"
    
    Animation1.Open AviFile
    Animation1.Play
    Animation1.Play 1, 1, 100
End Sub

Public Sub SetFileNames(ByVal NewAvi As String, ByVal NewWav As String)
    AviFile = NewAvi
    WavFile = NewWav
End Sub
