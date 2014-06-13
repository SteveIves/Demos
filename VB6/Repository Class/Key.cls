VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Key"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Attribute VB_Ext_KEY = "Member0" ,"Segments"
Option Explicit

'Property variables
Private mvarKeyName As String
Private mvarDescription As String
Private mvarSegments As Segments
Private mvarKeyType As Integer
Private mvarSize As Integer
Private mvarSortOrder As Integer
Private mvarDuplicates As Boolean
Private mvarDuplicatesAt As Integer
Private mvarModifiable As Boolean
Private mvarNullKeyType As Integer
Private mvarNullKeyValue As String
Private mvarKeyOfReference As Integer
Private mvarDensity As Integer
Private mvarCompressIndex As Boolean
Private mvarCompressData As Boolean
Private mvarCompressKey As Boolean



Private Sub Class_Terminate()
    Set mvarSegments = Nothing
End Sub



Public Property Get Segments() As Segments
    If mvarSegments Is Nothing Then
        Set mvarSegments = New Segments
    End If
    Set Segments = mvarSegments
End Property
Public Property Set Segments(vData As Segments)
    Set mvarSegments = vData
End Property


'KeyName Property
Public Property Let KeyName(ByVal vData As String)
    mvarKeyName = vData
End Property
Public Property Get KeyName() As String
    KeyName = mvarKeyName
End Property


'Description Property
Public Property Let Description(ByVal vData As String)
    mvarDescription = vData
End Property
Public Property Get Description() As String
    Description = mvarDescription
End Property



Public Property Let CompressKey(ByVal vData As Boolean)
    mvarCompressKey = vData
End Property
Public Property Get CompressKey() As Boolean
    CompressKey = mvarCompressKey
End Property



Public Property Let CompressData(ByVal vData As Boolean)
    mvarCompressData = vData
End Property
Public Property Get CompressData() As Boolean
    CompressData = mvarCompressData
End Property



Public Property Let CompressIndex(ByVal vData As Boolean)
    mvarCompressIndex = vData
End Property
Public Property Get CompressIndex() As Boolean
    CompressIndex = mvarCompressIndex
End Property



Public Property Let Density(ByVal vData As Integer)
    mvarDensity = vData
End Property
Public Property Get Density() As Integer
    Density = mvarDensity
End Property



Public Property Let KeyOfReference(ByVal vData As Integer)
    mvarKeyOfReference = vData
End Property
Public Property Get KeyOfReference() As Integer
    KeyOfReference = mvarKeyOfReference
End Property



Public Property Let NullKeyValue(ByVal vData As String)
    mvarNullKeyValue = vData
End Property
Public Property Get NullKeyValue() As String
    NullKeyValue = mvarNullKeyValue
End Property



Public Property Let NullKeyType(ByVal vData As Integer)
    mvarNullKeyType = vData
End Property
Public Property Get NullKeyType() As Integer
    NullKeyType = mvarNullKeyType
End Property



Public Property Let Modifiable(ByVal vData As Boolean)
    mvarModifiable = vData
End Property
Public Property Get Modifiable() As Boolean
    Modifiable = mvarModifiable
End Property



Public Property Let DuplicatesAt(ByVal vData As Integer)
    mvarDuplicatesAt = vData
End Property
Public Property Get DuplicatesAt() As Integer
    DuplicatesAt = mvarDuplicatesAt
End Property



Public Property Let Duplicates(ByVal vData As Boolean)
    mvarDuplicates = vData
End Property
Public Property Get Duplicates() As Boolean
    Duplicates = mvarDuplicates
End Property



Public Property Let SortOrder(ByVal vData As Integer)
    mvarSortOrder = vData
End Property
Public Property Get SortOrder() As Integer
    SortOrder = mvarSortOrder
End Property



Public Property Let Size(ByVal vData As Integer)
    mvarSize = vData
End Property
Public Property Get Size() As Integer
    Size = mvarSize
End Property



Public Property Let KeyType(ByVal vData As Integer)
    mvarKeyType = vData
End Property
Public Property Get KeyType() As Integer
    KeyType = mvarKeyType
End Property



