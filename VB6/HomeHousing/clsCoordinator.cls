VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "Coordinator"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Ext_KEY = "RVB_UniqueId" ,"339FECC4021C"
Attribute VB_Ext_KEY = "SavedWithClassBuilder" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'-------------------------------------------------------------------------
' This class provides the public interface to the user and session
' objects.
' It is a multi use in-process class that will be loaded into the IIS
' on receipt of a server request.
' It will be able to return to the IIS web page an instance of the
' user class either appropriate to the user supplied or
' a new user based on a password.
' If the password is unavailable then the user does not exist.
' This class is created at each request but the user object are held
' persistently and are created by the UserManager class
'-------------------------------------------------------------------------
Option Base 0
Option Explicit

'set this to 0 to disable debug code in this class
#Const DebugMode = 1
#If DebugMode Then
    'local variable to hold the serialized class ID that was created in Class_Initialize
    Private mlClassDebugID As Long
#End If

Private mlUserID As Long

Private Sub Class_Terminate()
    #If DebugMode Then
    'the class is being destroyed
        Debug.Print "'" & TypeName(Me) & "' instance " & CStr(mlClassDebugID) & " is terminating"
    #End If
End Sub

Private Sub Class_Initialize()
    CountInitialise   ' call the initialisation routine in the global module
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

Public Function RequestUser(vUserID As Variant) As Object
    ' Method to find a user object for the output
    ' If the object already exists then pass it back
    ' If the object does not exist then it used to exist but
    ' timed out (ie user has left screen on)
    ' In this case, act as if a logon failure has occured
    
    Dim oUser As User
    Dim oGuestUser As User
    Dim bFoundUser As Boolean
    
    Set RequestUser = Nothing
    
    For Each oUser In gcUsers
        If oUser.UserID = vUserID Then
            ' found the already created user - pass back
            Set RequestUser = oUser
            bFoundUser = True
            Exit For
        ElseIf oUser.UserID = giUNKNOWN_ID Then
            ' if the actual user is found then it
            ' overwrites or skips out the unknown user
            ' Otherwise this is returned which can only provide the
            ' logon screen - this assumes the unknown user has already
            ' been set up correctly
            Set RequestUser = oUser
        End If
    Next
 
End Function

Public Function RequestNewUser(vUsername As Variant, vPassword As Variant) As Object
    ' Method to create a new user against a username and password
    ' returns user object if successful, raises error if not
    
    Dim oNewUser As New User
    Dim iUserID As Integer

    ' Perform validation check
    ' simple validation with temporary connection
    Dim conUser As New rdoConnection
    Dim mrsUser As rdoResultset
    
    conUser.Connect = gsDB_CONN_STRING
    conUser.EstablishConnection

    Set mrsUser = conUser.OpenResultset("select " & gsUSER_ID & " from " & gsUSER_TABLE_NAME & _
    " where " & gsUSERNAME & "='" & vUsername & "' and " & gsPASSWORD & "='" & vPassword & "'")

    If Not mrsUser.EOF Then
        iUserID = mrsUser(gsUSER_ID) ' found a valid user
    Else
        iUserID = giUNKNOWN_ID ' unknown user
    End If
    
    'release the connection
    mrsUser.Close
    conUser.Close
    Set mrsUser = Nothing
    Set conUser = Nothing
    
    
    Set RequestNewUser = Nothing
    
    oNewUser.UserID = iUserID
    
    Call AddNewUser(oNewUser)   ' this function is done in the global module
                          ' should ensure that is another thread is going through the
                          ' same process or the user has already logged on
                          ' it will block with an error message
    ' TODO check for raised error here and redisplay logon?
    
    Set RequestNewUser = oNewUser
 
End Function

