VERSION 5.00
Begin VB.UserControl UsrSqlDbCmb 
   ClientHeight    =   615
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   2355
   ScaleHeight     =   615
   ScaleWidth      =   2355
   Begin VB.ComboBox LstDbName 
      Height          =   315
      ItemData        =   "UsrSqlDbCmb.ctx":0000
      Left            =   0
      List            =   "UsrSqlDbCmb.ctx":0002
      Style           =   2  'Dropdown List
      TabIndex        =   1
      Top             =   240
      Width           =   2295
   End
   Begin VB.Label Label1 
      Caption         =   "Supported databases"
      Height          =   255
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   2295
   End
End
Attribute VB_Name = "UsrSqlDbCmb"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Private Sub UserControl_Initialize()
    LstDbName.AddItem "Allbase"
    LstDbName.ItemData(LstDbName.NewIndex) = 0
    LstDbName.AddItem "DB2"
    LstDbName.ItemData(LstDbName.NewIndex) = 1
    LstDbName.AddItem "Informix"
    LstDbName.ItemData(LstDbName.NewIndex) = 2
    LstDbName.AddItem "Ingress"
    LstDbName.ItemData(LstDbName.NewIndex) = 3
    LstDbName.AddItem "ODBC (not Synergy)"
    LstDbName.ItemData(LstDbName.NewIndex) = 4
    LstDbName.AddItem "Oracle"
    LstDbName.ItemData(LstDbName.NewIndex) = 5
    LstDbName.AddItem "Rdb"
    LstDbName.ItemData(LstDbName.NewIndex) = 6
    LstDbName.AddItem "SQL Server"
    LstDbName.ItemData(LstDbName.NewIndex) = 7
    LstDbName.AddItem "Sybase"
    LstDbName.ItemData(LstDbName.NewIndex) = 8
    LstDbName.ListIndex = 0
End Sub

Public Property Get SqlDbCode() As Variant
    SqlDbCode = LstDbName.ListIndex
End Property

Public Property Let SqlDbCode(ByVal vNewValue As Variant)
    'read only property
End Property

Public Sub Enabled(State As Boolean)
    If State = True Then
        Label1.Enabled = True
        LstDbName.Enabled = True
    Else
        Label1.Enabled = False
        LstDbName.Enabled = False
    End If
End Sub
