VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "DataItems"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder" ,"Yes"
Attribute VB_Ext_KEY = "Collection" ,"Class1"
Attribute VB_Ext_KEY = "Member0" ,"Class1"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'local variable to hold collection
Private mCol As Collection
Private msTableID As String  ' for lower level collections, holds the id for the linked table
Private msInsertOrUpdate As SchemeUpdateType ' for top level collections, holds the mode for the db

Public Sub Add(vObject As Variant, Optional sKey As String)

    If Len(sKey) = 0 Then
        mCol.Add vObject
    Else
        mCol.Add vObject, sKey
    End If

End Sub

Public Property Get Item(vntIndexKey As Variant) As DataItem
Attribute Item.VB_UserMemId = 0
    'used when referencing an element in the collection
    'vntIndexKey contains either the Index or Key to the collection,
    'this is why it is declared as a Variant
    'Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
  Set Item = mCol(vntIndexKey)
End Property

Public Property Get Count() As Long
    'used when retrieving the number of elements in the
    'collection. Syntax: Debug.Print x.Count
    Count = mCol.Count
End Property

Public Sub Remove(vntIndexKey As Variant)
    'used when removing an element from the collection
    'vntIndexKey contains either the Index or Key, which is why
    'it is declared as a Variant
    'Syntax: x.Remove(xyz)

    mCol.Remove vntIndexKey
End Sub

Public Property Get NewEnum() As IUnknown
Attribute NewEnum.VB_UserMemId = -4
Attribute NewEnum.VB_MemberFlags = "40"
    'this property allows you to enumerate
    'this collection with the For...Each syntax
    Set NewEnum = mCol.[_NewEnum]
End Property

Private Sub Class_Initialize()
    'creates the collection when this class is created
    Set mCol = New Collection
End Sub

Private Sub Class_Terminate()
    'destroys collection when this class is terminated
    Set mCol = Nothing
End Sub

Public Property Get TableID() As String

    TableID = msTableID
    
End Property

Public Property Let TableID(ByVal vNewValue As String)

    msTableID = vNewValue
    
End Property

Public Property Get DBMode() As SchemeUpdateType

    DBMode = msInsertOrUpdate

End Property

Public Property Let DBMode(ByVal vNewValue As SchemeUpdateType)

    msInsertOrUpdate = vNewValue

End Property
