VERSION 5.00
Object = "{FE0065C0-1B7B-11CF-9D53-00AA003C9CB6}#1.0#0"; "COMCT232.OCX"
Begin VB.UserControl CtlMailWorking 
   BorderStyle     =   1  'Fixed Single
   ClientHeight    =   1440
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4080
   ScaleHeight     =   1440
   ScaleWidth      =   4080
   Begin ComCtl2.Animation Animation1 
      Height          =   735
      Left            =   120
      TabIndex        =   1
      Top             =   0
      Width           =   3855
      _ExtentX        =   6800
      _ExtentY        =   1296
      _Version        =   327680
      FullWidth       =   257
      FullHeight      =   49
   End
   Begin VB.Label Label1 
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   840
      Width           =   3975
   End
End
Attribute VB_Name = "CtlMailWorking"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Public Property Get label() As Variant

End Property

Public Property Let label(ByVal vNewValue As Variant)
    Label1.Caption = vNewValue
End Property


Public Property Get GetIconHandle() As Variant
    GetIconHandle = LoadPicture("d:\workingmouse.ico")
End Property

Public Property Let GetIconHandle(ByVal vNewValue As Variant)
    'read only!
End Property


Public Sub FileName(ByVal AviFile As String, MouseFile As String)
    Animation1.Open AviFile
    Animation1.Play
    UserControl.MouseIcon = LoadPicture(MouseFile)
    UserControl.MousePointer = 99
End Sub
