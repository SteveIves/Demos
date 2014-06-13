VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "ProjectFile"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Member0" ,"ProjectFileFields"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Option Explicit

'Property variables
Private mvarFileName As String 'local copy
Private mvarStructure As String 'local copy

'Collection object variables
Private mvarProjectFileFields As ProjectFileFields


'Class events
Private Sub Class_Terminate()
    Set mvarProjectFileFields = Nothing
End Sub



'FileName property
Public Property Let FileName(ByVal vData As String)
    mvarFileName = vData
End Property
Public Property Get FileName() As String
Attribute FileName.VB_UserMemId = 0
    FileName = mvarFileName
End Property


'Structure property
Public Property Let Structure(ByVal vData As String)
    mvarStructure = vData
End Property
Public Property Get Structure() As String
    Structure = mvarStructure
End Property



'ProjectFields collection
Public Property Get ProjectFileFields() As ProjectFileFields
    If mvarProjectFileFields Is Nothing Then
        Set mvarProjectFileFields = New ProjectFileFields
    End If
    Set ProjectFileFields = mvarProjectFileFields
End Property
Public Property Set ProjectFileFields(vData As ProjectFileFields)
    Set mvarProjectFileFields = vData
End Property
