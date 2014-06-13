VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Segment"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Member0" ,"Structure"
Attribute VB_Ext_KEY = "Member1" ,"Field"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Option Explicit

'Proprty variables
Private mvarSegmentType As String
Private mvarPosition As Long
Private mvarLength As Integer
Private mvarField As String
Private mvarStructure As String
Private mvarLiteralValue As String
Private mvarDataType As Integer
Private mvarOrder As Integer


'SegmentType Property
Public Property Let SegmentType(ByVal vData As String)
    mvarSegmentType = vData
End Property
Public Property Get SegmentType() As String
    SegmentType = mvarSegmentType
End Property


'Position Property
Public Property Let Position(ByVal vData As Long)
    mvarPosition = vData
End Property
Public Property Get Position() As Long
    Position = mvarPosition
End Property


'Length Property
Public Property Let Length(ByVal vData As Integer)
    mvarLength = vData
End Property
Public Property Get Length() As Integer
    Length = mvarLength
End Property


'Field Property
Public Property Let Field(ByVal vData As String)
    mvarField = vData
End Property
Public Property Get Field() As String
    Field = mvarField
End Property


'Structure Property
Public Property Let Structure(ByVal vData As String)
    mvarStructure = vData
End Property
Public Property Get Structure() As String
    Structure = mvarStructure
End Property


'LiteralValue Property
Public Property Let LiteralValue(ByVal vData As String)
    mvarLiteralValue = vData
End Property
Public Property Get LiteralValue() As String
    LiteralValue = mvarLiteralValue
End Property


'DataType Property
Public Property Let DataType(ByVal vData As Integer)
    mvarDataType = vData
End Property
Public Property Get DataType() As Integer
    DataType = mvarDataType
End Property


'Order Property
Public Property Let Order(ByVal vData As Integer)
    mvarOrder = vData
End Property
Public Property Get Order() As Integer
    Order = mvarOrder
End Property

