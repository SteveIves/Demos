VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DisplayFormat"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Option Explicit

Private mvarFormatName As String
Private mvarFormatType As String
Private mvarFormatString As String



Public Property Let FormatName(ByVal vData As String)
    mvarFormatName = vData
End Property
Public Property Get FormatName() As String
    FormatName = mvarFormatName
End Property



Public Property Let FormatType(ByVal vData As String)
    mvarFormatType = vData
End Property
Public Property Get FormatType() As String
    FormatType = mvarFormatType
End Property



Public Property Let FormatString(ByVal vData As String)
    mvarFormatString = vData
End Property
Public Property Get FormatString() As String
    FormatString = mvarFormatString
End Property

