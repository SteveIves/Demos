VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsConvertXML"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

    Private strName As String
    Private strAddress As String

    ' ****************
    ' Database stuff *
    ' ****************
    Private ADO_Conn As New ADODB.Connection

    'Private Const strConnectString = "Driver={SQL Server};Server=Pavilion;UID=sa;PWD=;database=Synergex"
    Private Const strConnectString = "Driver={SQL Server};Server=PHOEBE;UID=sa;PWD=;database=Jim"

'************************************************************************
'Public Sub ConvertXML(ByVal XML_File As String, ByRef strName As String)
Public Function ConvertXML(ByVal NameAddressRecord As String)
'************************************************************************

'
'   Called from project in "Test Convert XML" folder
'

    On Error GoTo Error_ConvertXML
    
    'TestUpdate
    
    Dim objDomDoc As New MSXML2.DOMDocument
    Dim objDomNode As MSXML2.IXMLDOMNode
        
    MsgBox "Data received in DLL (variable NameAddressRecord):   " & vbCrLf & vbCrLf & NameAddressRecord
    
    objDomDoc.loadXML NameAddressRecord
    
    '************************************************************************
    ' Check status of load
    '************************************************************************
    
    
    
    
    MsgBox "objDomDoc.Text:   " & vbCrLf & vbCrLf _
        & objDomDoc.Text
    
    DisplayNode objDomDoc.childNodes, 0
    
    ' ***************
    ' UPDATE DATABASE
    ' ***************
    Dim ADO_Cmd As New ADODB.Command
    Dim RS As New ADODB.Recordset
    Dim strParameter As ADODB.Parameter
    Dim strStoredProc As String
    ' ****************
    
    strStoredProc = "sp_Test_Insert"
    
    ADO_Cmd.CommandType = adCmdStoredProc
    ADO_Cmd.Name = "test"
    ADO_Cmd.CommandText = strStoredProc

    Set strParameter = ADO_Cmd.CreateParameter("Insert_Name", adChar, adParamInput, 30, strName)
    
    ADO_Cmd.Parameters.Append strParameter

    Set strParameter = ADO_Cmd.CreateParameter("Insert_Address", adChar, adParamInput, 30, strAddress)
    
    ADO_Cmd.Parameters.Append strParameter

    ' Determine if a new connection to the Data Source is needed
    If ADO_Conn.State = adStateClosed Then
        ' Open an ADO connection
        ADO_Conn.Open strConnectString
    End If
    
    Set ADO_Cmd.ActiveConnection = ADO_Conn
    
    ' Insert record
    RS.Open ADO_Cmd
    
    Set objDomDoc = Nothing
    
    ConvertXML = "DONE     "
    
    Exit Function

Error_ConvertXML:

    MsgBox "In " & "ConvertXML" & vbCrLf & vbCrLf _
        & "Error Number:  " & Err.Number & vbCrLf & vbCrLf _
        & "Error Description:  " & Err.Description
    
    Set objDomDoc = Nothing
    
End Function

'************************************************************************
Public Sub DisplayNode(ByRef Nodes As MSXML2.IXMLDOMNodeList, _
    ByVal Indent As Integer)
'************************************************************************

    Dim xNode As MSXML2.IXMLDOMNode
    
    Indent = Indent + 2

    For Each xNode In Nodes
        If xNode.nodeType = NODE_TEXT Then
            Select Case True
                
                Case xNode.parentNode.nodeName = "Name"

                    strName = xNode.nodeValue
                    
                Case xNode.parentNode.nodeName = "Address"
                    
                    strAddress = xNode.nodeValue

            End Select
            
        End If

        If xNode.hasChildNodes Then
            DisplayNode xNode.childNodes, Indent
        End If

    Next xNode
    
End Sub

'************************************************************************
Private Sub TestUpdate()
'************************************************************************

    Dim ADO_Cmd As New ADODB.Command
    Dim RS As New ADODB.Recordset
    Dim strParameter As ADODB.Parameter
    Dim strStoredProc As String
    ' ****************
    
    On Error GoTo Error_TestUpdate
    
    strName = "Test Update Name"
    strAddress = "Test Update Address"
        
    strStoredProc = "sp_Test_Insert"
    
    ADO_Cmd.CommandType = adCmdStoredProc
    ADO_Cmd.Name = "test"
    ADO_Cmd.CommandText = strStoredProc

    Set strParameter = ADO_Cmd.CreateParameter("Insert_Name", adChar, adParamInput, 30, strName)
    
    ADO_Cmd.Parameters.Append strParameter

    Set strParameter = ADO_Cmd.CreateParameter("Insert_Address", adChar, adParamInput, 30, strAddress)
    
    ADO_Cmd.Parameters.Append strParameter

    ' Determine if a new connection to the Data Source is needed
    If ADO_Conn.State = adStateClosed Then
        ' Open an ADO connection
        ADO_Conn.Open strConnectString
    End If
    
    Set ADO_Cmd.ActiveConnection = ADO_Conn
    
    ' Insert record
    RS.Open ADO_Cmd

    Exit Sub

Error_TestUpdate:

    MsgBox "In " & "TestUpdate" & vbCrLf & vbCrLf _
        & "Error Number:  " & Err.Number & vbCrLf & vbCrLf _
        & "Error Description:  " & Err.Description

End Sub
