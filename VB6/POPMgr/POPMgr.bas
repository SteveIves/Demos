Attribute VB_Name = "modPOPMgr"
Private strPOPServer As String
Private strID As String
Private strPW As String
Private blnInfoOk As Boolean
Private btPersistPW As Byte

Type tMailItem
    From As String
    Subject As String
    DateSent As String
    Bytes As Long
    Body As String
    Loaded As Boolean
    Deleted As Boolean
End Type

Public Property Get POPServer() As String

    POPServer = strPOPServer
    
End Property

Public Property Let POPServer(ByVal strNewValue As String)

    strPOPServer = strNewValue
    
End Property

Public Property Get ID() As String

    ID = strID
    
End Property

Public Property Let ID(ByVal strNewValue As String)
    
    strID = strNewValue

End Property

Public Property Get PW() As String

    PW = strPW

End Property

Public Property Let PW(ByVal strNewValue As String)

    strPW = strNewValue

End Property

Public Property Get InfoOk() As Boolean

    InfoOk = blnInfoOk

End Property

Public Property Let InfoOk(ByVal blnNewValue As Boolean)

    blnInfoOk = blnNewValue

End Property

Public Property Get PersistPW() As Byte

    PersistPW = btPersistPW

End Property

Public Property Let PersistPW(ByVal btNewValue As Byte)

    btPersistPW = btNewValue

End Property


