VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "DataItem"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Option Explicit

'set this to 0 to disable debug code in this class
#Const DebugMode = 1


#If DebugMode Then
    'local variable to hold the serialized class ID that was created in Class_Initialize
    Private mlClassDebugID As Long
#End If

Private muItemType As FieldType
Private miItemSize As Integer
Private miItemCode As Integer
Private mvItemValue As Variant
'Private msSource As String
'Private msSourceID As String
'Private msSourceDesc As String
Private muDBFieldType As DbType
Private msDBFieldName As String
Private msDbTableName As String
Private msMultiChoiceArray() As String
Private msDisplayText As String

Public Function DisplayTitle(oUser As User) As String

    DisplayTitle = msDisplayText

End Function

Public Function DisplayData(oUser As User) As String

    Dim iLoop As Integer
    Dim sTempDisplayData As String
    
    If IsNull(mvItemValue) Then
        mvItemValue = ""
    End If
    
    Select Case muItemType
        Case WebTextBox
            DisplayData = "<input type=""text"" name=""" & _
                           miItemCode & """size=""" & miItemSize & _
                           """ value=""" & CStr(mvItemValue) & """>"
        Case WebDropDown
            For iLoop = 0 To UBound(msMultiChoiceArray, 2)
                If CStr(mvItemValue) <> msMultiChoiceArray(0, iLoop) Then
                    sTempDisplayData = sTempDisplayData & "<option value=""" & msMultiChoiceArray(0, iLoop) & _
                              """>" & msMultiChoiceArray(1, iLoop) & "</option>" & vbCrLf
                Else ' add option on the front to display first
                    sTempDisplayData = "<option value=""" & msMultiChoiceArray(0, iLoop) & _
                              """>" & msMultiChoiceArray(1, iLoop) & "</option>" & sTempDisplayData & vbCrLf
                End If
            Next
            DisplayData = "<select name=""" & miItemCode & """>" & vbCrLf & sTempDisplayData & "</select>"
        Case WebMultiLine
            DisplayData = "<textarea name=""" & miItemCode & """>" & CStr(mvItemValue) & "</textarea>"
        Case WebRadioButton
            ' todo stuff here
        Case WebSpecial
            ' todo stuff here
    End Select
                          
End Function
Public Function DisplayFixedData(oUser As User) As String

    Dim iLoop As Integer
    Dim sTempDisplayData As String
    
    If IsNull(mvItemValue) Then
        mvItemValue = ""
    End If
    
    Select Case muItemType
        Case WebTextBox
            DisplayFixedData = CStr(mvItemValue)
        Case WebDropDown
            For iLoop = 0 To UBound(msMultiChoiceArray, 2)
                If CStr(mvItemValue) = msMultiChoiceArray(0, iLoop) Then
                    DisplayFixedData = msMultiChoiceArray(1, iLoop)
                End If
            Next
        Case WebMultiLine
            DisplayFixedData = CStr(mvItemValue)
        Case WebRadioButton
            ' todo stuff here
        Case WebSpecial
            ' todo stuff here
    End Select
                          
End Function


Public Sub InitialiseField(uType As FieldType, _
                            iSize As Integer, _
                            iCode As Integer, _
                            sSource As String, _
                            sSourceID As String, _
                            sSourceDes As String, _
                            uDbType As DbType, _
                            sDbTable As String, _
                            sDbField As String, _
                            sDisplay As String)

    Dim conTemp As New rdoConnection
    Dim rsTemp As rdoResultset
    Dim iLoop As Integer
    
    muItemType = uType
    miItemSize = iSize
    miItemCode = iCode
    muDBFieldType = uDbType
    msDBFieldName = sDbField
    msDbTableName = sDbTable
    msDisplayText = sDisplay
    
    If (muItemType = WebDropDown) Or (muItemType = WebRadioButton) Then
        ' load the array from the source
        conTemp.Connect = gsDB_CONN_STRING
        conTemp.CursorDriver = rdUseClientBatch
        conTemp.EstablishConnection
        Set rsTemp = conTemp.OpenResultset("select * from " & sSource, rdOpenStatic, rdConcurBatch)
        Set rsTemp.ActiveConnection = Nothing
        conTemp.Close
        Set conTemp = Nothing ' kill connection asap
    
        ReDim msMultiChoiceArray(1, rsTemp.RowCount - 1)
        
        For iLoop = 0 To rsTemp.RowCount - 1
            msMultiChoiceArray(0, iLoop) = CStr(rsTemp(sSourceID))
            msMultiChoiceArray(1, iLoop) = CStr(rsTemp(sSourceDes))
            rsTemp.MoveNext
        Next
        rsTemp.Close
        Set rsTemp = Nothing
    End If
    
End Sub

Public Property Get ItemValue() As Variant

    If IsObject(mvItemValue) Then
        Set ItemValue = mvItemValue
    Else
        ItemValue = mvItemValue
    End If
End Property

Public Property Let ItemValue(vNewValue As Variant)

    mvItemValue = vNewValue
    
End Property


Public Property Get ItemCode() As Integer
 
    ItemCode = miItemCode

End Property

Public Property Get ItemSize() As Integer
   
   ItemSize = miItemSize

End Property

Public Property Get ItemType() As FieldType

        ItemType = muItemType

End Property

Public Property Get ItemDBField() As String

        ItemDBField = msDBFieldName

End Property

Public Property Get ItemDisplay() As String

        ItemDisplay = msDisplayText

End Property

Public Property Get ItemDBFieldType() As DbType

        ItemDBFieldType = muDBFieldType

End Property

Public Property Get ItemDBTableName() As String

        ItemDBTableName = msDbTableName
        
End Property



Private Sub Class_Initialize()
    #If DebugMode Then
        'get the next available class ID, and print out
        'that the class was created successfully
        mlClassDebugID = GetNextClassDebugID()
        Debug.Print "'" & TypeName(Me) & "' instance " & mlClassDebugID & " created"
    #End If
End Sub

Private Sub Class_Terminate()
    'the class is being destroyed
    #If DebugMode Then
        Debug.Print "'" & TypeName(Me) & "' instance " & CStr(mlClassDebugID) & " is terminating"
    #End If
End Sub

#If DebugMode Then
    Public Property Get ClassDebugID()
        'if we are in debug mode, surface this property that consumers can query
        ClassDebugID = mlClassDebugID
    End Property
#End If

