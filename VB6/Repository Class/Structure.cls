VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Structure"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Member0" ,"Fields"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Attribute VB_Ext_KEY = "Member1" ,"Keys"
Attribute VB_Ext_KEY = "Member2" ,"LocalFormats"
Attribute VB_Ext_KEY = "Member3" ,"Relations"
Attribute VB_Ext_KEY = "Member4" ,"Tags"
Option Explicit

'Property variables
Private mvarStructureName As String
Private mvarDescription As String

'Collection object variables
Private mvarFields As Fields
Private mvarKeys As Keys
Private mvarRelations As Relations
Private mvarLocalFormats As LocalFormats
Private mvarTags As Tags
'local variable(s) to hold property value(s)
Private mvarFileType As String 'local copy
Private mvarUserText As String 'local copy
Private mvarRecordSize As Long 'local copy
Private mvarFieldCount As Integer 'local copy
Private mvarKeyCount As Integer 'local copy
Private mvarRelationCount As Integer 'local copy
Private mvarFileCount As Integer 'local copy
Private mvarFormatCount As Integer 'local copy
Private mvarTagCount As Integer 'local copy
Private mvarFirstFile As String 'local copy
Private mvarTagType As String 'local copy
Public Property Let TagType(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.TagType = 5
    mvarTagType = vData
End Property


Public Property Get TagType() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.TagType
    TagType = mvarTagType
End Property



Public Property Let FirstFile(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.FirstFile = 5
    mvarFirstFile = vData
End Property


Public Property Get FirstFile() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.FirstFile
    FirstFile = mvarFirstFile
End Property



Public Property Let TagCount(ByVal vData As Integer)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.TagCount = 5
    mvarTagCount = vData
End Property


Public Property Get TagCount() As Integer
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.TagCount
    TagCount = mvarTagCount
End Property



Public Property Let FormatCount(ByVal vData As Integer)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.FormatCount = 5
    mvarFormatCount = vData
End Property


Public Property Get FormatCount() As Integer
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.FormatCount
    FormatCount = mvarFormatCount
End Property



Public Property Let FileCount(ByVal vData As Integer)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.FileCount = 5
    mvarFileCount = vData
End Property


Public Property Get FileCount() As Integer
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.FileCount
    FileCount = mvarFileCount
End Property



Public Property Let RelationCount(ByVal vData As Integer)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.RelationCount = 5
    mvarRelationCount = vData
End Property


Public Property Get RelationCount() As Integer
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.RelationCount
    RelationCount = mvarRelationCount
End Property



Public Property Let KeyCount(ByVal vData As Integer)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.KeyCount = 5
    mvarKeyCount = vData
End Property


Public Property Get KeyCount() As Integer
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.KeyCount
    KeyCount = mvarKeyCount
End Property



Public Property Let FieldCount(ByVal vData As Integer)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.FieldCount = 5
    mvarFieldCount = vData
End Property


Public Property Get FieldCount() As Integer
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.FieldCount
    FieldCount = mvarFieldCount
End Property



Public Property Let RecordSize(ByVal vData As Long)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.RecordSize = 5
    mvarRecordSize = vData
End Property


Public Property Get RecordSize() As Long
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.RecordSize
    RecordSize = mvarRecordSize
End Property



Public Property Let UserText(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.UserText = 5
    mvarUserText = vData
End Property


Public Property Get UserText() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.UserText
    UserText = mvarUserText
End Property



Public Property Let FileType(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.FileType = 5
    mvarFileType = vData
End Property


Public Property Get FileType() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.FileType
    FileType = mvarFileType
End Property





Public Property Get Tags() As Tags
    If mvarTags Is Nothing Then
        Set mvarTags = New Tags
    End If


    Set Tags = mvarTags
End Property


Public Property Set Tags(vData As Tags)
    Set mvarTags = vData
End Property



Public Property Get LocalFormats() As LocalFormats
    If mvarLocalFormats Is Nothing Then
        Set mvarLocalFormats = New LocalFormats
    End If


    Set LocalFormats = mvarLocalFormats
End Property


Public Property Set LocalFormats(vData As LocalFormats)
    Set mvarLocalFormats = vData
End Property



Public Property Get Relations() As Relations
    If mvarRelations Is Nothing Then
        Set mvarRelations = New Relations
    End If


    Set Relations = mvarRelations
End Property


Public Property Set Relations(vData As Relations)
    Set mvarRelations = vData
End Property



'Class Events
Private Sub Class_Terminate()
  Set mvarTags = Nothing
  Set mvarLocalFormats = Nothing
  Set mvarRelations = Nothing
  Set mvarKeys = Nothing
    Set mvarFields = Nothing
End Sub


'StructureName Property
Public Property Let StructureName(ByVal vData As String)
    mvarStructureName = vData
End Property
Public Property Get StructureName() As String
    StructureName = mvarStructureName
End Property


'Description Property
Public Property Let Description(ByVal vData As String)
    mvarDescription = vData
End Property
Public Property Get Description() As String
    Description = mvarDescription
End Property


'Fields Collection
Public Property Set Fields(vData As Fields)
    Set mvarFields = vData
End Property
Public Property Get Fields() As Fields
    If mvarFields Is Nothing Then
        Set mvarFields = New Fields
    End If
    Set Fields = mvarFields
End Property


'Keys Collection
Public Property Set Keys(vData As Keys)
    Set mvarKeys = vData
End Property
Public Property Get Keys() As Keys
    If mvarKeys Is Nothing Then
        Set mvarKeys = New Keys
    End If
    Set Keys = mvarKeys
End Property

