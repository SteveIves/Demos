'*****************************************************************************
'This is the main (base) module that loads and activates the order entry form.
'
'
'Author Richard C. Morris
'       Synergex
'
'Public sub Main is the driver
'
'*****************************************************************************
Module OrderEntry
    'define constant values, and static messages
    Public Const CONST_INF_noconnection As String = "No connection to database established."
    Public Const CONST_INF_connected As String = "Connected to remote server."
    Public Const CONST_INF_connecting As String = "Connecting to remote server, please wait......"
    Public Const CONST_INF_locatingcustomer As String = "Locating available customer details....."
    Public Const CONST_INF_customerlocated As String = "Customer details located."
    Public Const CONST_INF_locatingproducts As String = "Locating Products...."

    Public Const CONST_ERR_nocustomer As String = "Customer account details can not be located"
    Public Const CONST_ERR_noinit As String = "Unable to locate INITIALIZE function"


    'define our application wide objects
    Public oSynergy As xfpldemo.utils
    Public oCustomer As xfpldemo.Customer
    Public oOrderForm As FrmQuickOrder
    Public oUser As xfpldemo.User

    'define applicaiton wide variables
    Public sUsername As String
    Public sPassword As String
    Public bEntered As Boolean

    Public bConnected As Boolean


    Public Sub main()
        'set default values
        bConnected = False

        'create our objects
        'oSynergy talks to the remote server
        oSynergy = New xfpldemo.utils

        'create our customer object
        oCustomer = New xfpldemo.Customer

        'oOrderForm is the Quick Entry Order form
        oOrderForm = New FrmQuickOrder

        'Process the form
        With oOrderForm
            .LblInfo.Text = CONST_INF_noconnection
            .ShowDialog()
        End With

        'disconnect from the remote server.
        If bConnected = False Then
            oSynergy.disconnect()
        End If

        'destory objects
        oSynergy = Nothing
        oOrderForm = Nothing
        oCustomer = Nothing


        'program terminate....
    End Sub

    Public Function ConnectSynergy() As Boolean
        Dim iStatus As Integer
        Dim sErrMsg As String = ""

        'get User and and password

        Dim oLoginForm As New FrmLogin
        bEntered = False
        With oLoginForm
            .TxtUser.Text = sUsername
            .TxtPass.Text = sPassword
            .ShowDialog()
        End With
        oLoginForm = Nothing

        If bEntered = False Then
            Return False
        End If
        'connect through the Synergy Server

        Try
            oSynergy.connect()
        Catch ex As Exception
            Return False
        End Try

        bConnected = True

        'let's log in correctly

        oUser = New xfpldemo.User
        With oUser
            .Username = sUsername
            .Password = sPassword
        End With

        Try
            iStatus = oSynergy.Initialize
        Catch ex As Exception
            'Can not locate the required routine
            iStatus = -999
            sErrMsg = ex.Message
        Finally
            If iStatus <> 0 Then
                sErrMsg = CONST_ERR_NOINIT
            End If
        End Try

        If iStatus <> 0 Then
            oUser = Nothing
            Return DisplayError(sErrMsg)
        End If

        Try
            iStatus = oSynergy.login(sUsername, sPassword, sErrMsg, oUser)
        Catch ex As Exception
            'Can not locate the required routine
            iStatus = -999
            sErrMsg = ex.Message
        End Try

        If iStatus <> 0 Then
            Return DisplayError(sErrMsg)
        End If

        'return a successful function call!
        Return True

    End Function

    Private Function DisplayError(ByVal sErr As String) As Boolean
        'we are unable to connect!
        MsgBox(sErr)
        oSynergy.disconnect()
        bConnected = False
        'always return a false status (fail!)
        DisplayError = False
    End Function
End Module
