VERSION 5.00
Begin VB.UserControl UsrSysCodeCmb 
   ClientHeight    =   375
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4665
   ScaleHeight     =   375
   ScaleWidth      =   4665
   Begin VB.ComboBox LstSysCode 
      Height          =   315
      Left            =   0
      Style           =   2  'Dropdown List
      TabIndex        =   0
      Top             =   0
      Width           =   4575
   End
End
Attribute VB_Name = "UsrSysCodeCmb"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

Private Sub UserControl_Initialize()
    LstSysCode.AddItem "Altos 386 (005)"
    LstSysCode.ItemData(LstSysCode.NewIndex) = 5
    LstSysCode.AddItem "Data General AViion (010)"
    LstSysCode.ItemData(LstSysCode.NewIndex) = 10
    LstSysCode.AddItem "DEC Alpha with Digital Unix (021)"
    LstSysCode.ItemData(LstSysCode.NewIndex) = 21
    LstSysCode.AddItem "DEC Alpha with OpenVMS (200)"
    LstSysCode.ItemData(LstSysCode.NewIndex) = 200
    LstSysCode.AddItem "DEC Alpha with WindowsNT (102)"
    LstSysCode.ItemData(LstSysCode.NewIndex) = 102
    LstSysCode.AddItem "DEC VAX with OpenVMS (201)"
    LstSysCode.ItemData(LstSysCode.NewIndex) = 201
    LstSysCode.AddItem "HP9000 series (009)"
    LstSysCode.ItemData(LstSysCode.NewIndex) = 9
    LstSysCode.AddItem "IBM RS/6000 series (004)"
    LstSysCode.ItemData(LstSysCode.NewIndex) = 4
    LstSysCode.AddItem "SCO Unix (003)"
    LstSysCode.ItemData(LstSysCode.NewIndex) = 3
    LstSysCode.AddItem "Windows95/NT (101)"
    LstSysCode.ItemData(LstSysCode.NewIndex) = 101
    LstSysCode.AddItem "Silicon Graphics (012)"
    LstSysCode.ItemData(LstSysCode.NewIndex) = 12
    LstSysCode.AddItem "Sun Solaris II (020)"
    LstSysCode.ItemData(LstSysCode.NewIndex) = 20
    LstSysCode.ListIndex = 9
End Sub

Public Property Get SysCode() As Variant
    SysCode = LstSysCode.ItemData(LstSysCode.ListIndex)
End Property

Public Property Let SysCode(ByVal vNewValue As Variant)
    'can not set
End Property

Public Sub Enabled(State As Boolean)
    If State = True Then
        LstSysCode.Enabled = True
    Else
        LstSysCode.Enabled = False
    End If

End Sub

Public Sub DefIndex(Ind As Integer)
    LstSysCode.ListIndex = Ind
End Sub


