VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Tag"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Option Explicit

'Property variables
Private mvarTagName As String 'local copy
Private mvarConnector As String 'local copy
Private mvarTagField As String 'local copy
Private mvarComparison As String 'local copy
Private mvarValue As String 'local copy



Public Property Let Value(ByVal vData As String)
    mvarValue = vData
End Property
Public Property Get Value() As String
    Value = mvarValue
End Property



Public Property Let Comparison(ByVal vData As String)
    mvarComparison = vData
End Property
Public Property Get Comparison() As String
    Comparison = mvarComparison
End Property



Public Property Let TagField(ByVal vData As String)
    mvarTagField = vData
End Property
Public Property Get TagField() As String
    TagField = mvarTagField
End Property



Public Property Let Connector(ByVal vData As String)
    mvarConnector = vData
End Property
Public Property Get Connector() As String
    Connector = mvarConnector
End Property



Public Property Let TagName(ByVal vData As String)
    mvarTagName = vData
End Property
Public Property Get TagName() As String
    TagName = mvarTagName
End Property

