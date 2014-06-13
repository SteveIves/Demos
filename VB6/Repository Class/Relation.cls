VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Relation"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Option Explicit

Private mvarRelationName As String
Private mvarFromStructure As String
Private mvarFromKey As String
Private mvarToStructure As String
Private mvarToKey As String


Public Property Let RelationName(ByVal vData As String)
    mvarRelationName = vData
End Property
Public Property Get RelationName() As String
    RelationName = mvarRelationName
End Property


Public Property Let FromStructure(ByVal vData As String)
    mvarFromStructure = vData
End Property
Public Property Get FromStructure() As String
    FromStructure = mvarFromStructure
End Property


Public Property Let FromKey(ByVal vData As String)
    mvarFromKey = vData
End Property
Public Property Get FromKey() As String
    FromKey = mvarFromKey
End Property


Public Property Let ToStructure(ByVal vData As String)
    mvarToStructure = vData
End Property
Public Property Get ToStructure() As String
    ToStructure = mvarToStructure
End Property


Public Property Let ToKey(ByVal vData As String)
    mvarToKey = vData
End Property
Public Property Get ToKey() As String
    ToKey = mvarToKey
End Property


