VERSION 5.00
Object = "{6B7E6392-850A-101B-AFC0-4210102A8DA7}#1.1#0"; "COMCTL32.OCX"
Begin VB.UserControl CtlProgress 
   ClientHeight    =   1335
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4695
   MouseIcon       =   "UsrProgress.ctx":0000
   MousePointer    =   99  'Custom
   ScaleHeight     =   1335
   ScaleWidth      =   4695
   Begin ComctlLib.ProgressBar ProgressBar1 
      Height          =   255
      Left            =   120
      TabIndex        =   0
      Top             =   840
      Width           =   4455
      _ExtentX        =   7858
      _ExtentY        =   450
      _Version        =   327680
      Appearance      =   1
      MouseIcon       =   "UsrProgress.ctx":0442
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   300
      Left            =   120
      TabIndex        =   1
      Top             =   240
      Width           =   4455
   End
End
Attribute VB_Name = "CtlProgress"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

Public Property Get SetMin() As Integer
    SetMin = ProgressBar1.Min
End Property

Public Property Let SetMin(ByVal vNewValue As Integer)
    ProgressBar1.Min = vNewValue
    ProgressBar1.Value = ProgressBar1.Min
End Property

Public Property Get SetMax() As Integer
    SetMax = ProgressBar1.Max
End Property

Public Property Let SetMax(ByVal vNewValue As Integer)
    ProgressBar1.Max = vNewValue
End Property

Public Property Get UpdValue() As Integer
    UpdValue = ProgressBar1.Value
End Property

Public Property Let UpdValue(ByVal vNewValue As Integer)
    ProgressBar1.Value = vNewValue
End Property

Public Property Get SetLabel() As Variant
    'write only
End Property

Public Property Let SetLabel(ByVal vNewValue As Variant)
    Label1.Caption = vNewValue
End Property

Private Sub UserControl_Initialize()
    'set default properties
    ProgressBar1.Min = 1
    ProgressBar1.Max = 100
    ProgressBar1.Value = 1
End Sub

Public Property Get Complete() As Variant
    'write only
End Property

Public Property Let Complete(ByVal vNewValue As Variant)
    ProgressBar1.Value = ProgressBar1.Max
End Property
