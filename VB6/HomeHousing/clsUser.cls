VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "User"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Ext_KEY = "RVB_UniqueId" ,"339FEE780140"
Attribute VB_Ext_KEY = "SavedWithClassBuilder" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'-------------------------------------------------------------------------
' This class provides a record of a user.
' An instance will be created on first request for this user
' and destroyed after a suitable timeout period or on failure.
' Pending data may not be written.
' When created, it loads data from a database.
' It writes back to the database when required.
' Only one instance is available for use (the user may logon
' only once).
' It is managed by the Coordinator class.
'-------------------------------------------------------------------------

Option Explicit
Option Base 0

'set this to 0 to disable debug code in this class
#Const DebugMode = 1
#If DebugMode Then
    'local variable to hold the serialized class ID that was created in Class_Initialize
    Private mlClassDebugID As Long
#End If

Private mlUserID As Long ' Unique user identifier
Private msRealName As String ' Retrieved proper name
Private mrsUser As rdoResultset ' result set for user data
Private msDataArray() As Variant ' module copy of input data for page manipulation
Private moResponse As Response  ' response object for output - loaded on each display call
Private moRequest As Request ' request object for input - loaded on each display call
Private miCurrentSchemeID  ' id for the scheme currently being looked at by this user

Private Sub Class_Terminate()
    #If DebugMode Then
    'the class is being destroyed
        Debug.Print "'" & TypeName(Me) & "' instance " & CStr(mlClassDebugID) & " is terminating"
    #End If
End Sub

Private Sub Class_Initialize()
    #If DebugMode Then
        'get the next available class ID, and print out
        'that the class was created successfully
        mlClassDebugID = GetNextClassDebugID()
        Debug.Print "'" & TypeName(Me) & "' instance " & CStr(mlClassDebugID) & " created"
    #End If
        
End Sub

#If DebugMode Then
    Public Property Get ClassDebugID() As Long
        'if we are in debug mode, surface this property that consumers can query
        ClassDebugID = mlClassDebugID
    End Property
#End If

Public Property Get RealName() As String
   Let RealName = msRealName
End Property

Public Property Get UserID() As Long
   Let UserID = mlUserID
End Property

Public Property Let RealName(sText As String)
   Let msRealName = sText
End Property

Public Property Let UserID(lValue As Long)
    ' setting the userid
    ' this should only be done at the beginning of the life of the
    ' object - will load up data from database and set all required
    ' attributes

    Dim conUser As New rdoConnection

    conUser.Connect = gsDB_CONN_STRING
    conUser.EstablishConnection

    Set mrsUser = conUser.OpenResultset("select * from " & gsUSER_TABLE_NAME & " where " & gsUSER_ID & "=" & lValue)

    msRealName = mrsUser(gsREAL_NAME)
    Let mlUserID = lValue

End Property

Public Sub Display(vCurrentPageID As Variant, oResponse As Response, oRequest As Request)
    Dim oPage As Object
    Dim sNextPageID As String
    
    Set moResponse = oResponse
    Set moRequest = oRequest
    
    If vCurrentPageID = "" Then
        sNextPageID = gsLOGON_SCREEN_ID
    Else
        sNextPageID = vCurrentPageID
    End If
    
    ' select what page to display
    ' Check for special user first
    If mlUserID = giUNKNOWN_ID Then
        ' Unknown user can only display logon screen
        sNextPageID = gsLOGON_SCREEN_ID
    Else
        ' fetch the current page in the collection
        Set oPage = gcPages.Item(vCurrentPageID)
        
        ' Ask it what the next page will be (pass it the user for access
        ' to the input data
    
        sNextPageID = oPage.GetNextPageID(Me, CStr(sNextPageID))
    End If
    
    
    ' Find the page in the global collection and ask it to display
    Set oPage = gcPages.Item(sNextPageID)
    Call oPage.Display(Me)

End Sub

Public Sub DataTransfer(vDataArray As Variant)

    Dim i As Integer
    Dim j As Integer
    Dim iBound As Integer
    
    ' copy the data to the user object for later work in the pages
    ' data is in the form of a variant (holding a variant array)
    
    iBound = UBound(vDataArray, 2)
    ReDim msDataArray(1, iBound)
    
    For i = 0 To 1
        For j = 0 To iBound
            msDataArray(i, j) = vDataArray(i, j)
        Next
    Next

End Sub

Public Property Get DataArray() As Variant

    DataArray = msDataArray
    
End Property

Public Property Get Request() As Request
    ' read only property for request
    Set Request = moRequest

End Property

Public Property Get Response() As Response
    'read only proerty for response
    Set Response = moResponse

End Property

Public Property Get CurrentSchemeID() As Integer

    CurrentSchemeID = miCurrentSchemeID
    
End Property

Public Property Let CurrentSchemeID(ByVal iNewValue As Integer)

    miCurrentSchemeID = iNewValue

End Property
