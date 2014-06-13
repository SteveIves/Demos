VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "Scheme"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "RVB_UniqueId" ,"339FEE2401F4"
Attribute VB_Ext_KEY = "SavedWithClassBuilder" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'-------------------------------------------------------------------------
' This class represents a scheme.
' It is created as needed and attributes will be loaded
' from the database and instances will be shared between users.
' If inactive for a while it will be destroyed.
' Updates are made to the database
'
' The initilise method should be called immediately after
' creation, this loads all attributes from the database
' the only item needed is the scheme id
' if there are no rows with the data, then the first write to
' the database will be an insert rather than an update
'-------------------------------------------------------------------------

Option Explicit
Option Base 0

'set this to 0 to disable debug code in this class
#Const DebugMode = 1
#If DebugMode Then
    'local variable to hold the serialized class ID that was created in Class_Initialise
    Private mlClassDebugID As Long
#End If

Private mlSchemeID As Long 'Unique scheme code number

Private mcSchemeBaseDataItems As New DataItems ' DataItems of DataItems for basic scheme data
Private muBaseDataStatus As DataStatus  ' here to co-ordinate updating to database

Private mcSchemeConsultantDataItems As New DataItems ' DataItems of DataItems for consultant data
Private mcSchemeContractorDataItems As New DataItems ' DataItems of DataItems for contractor data
Private mcSchemeCosts As New DataItems ' DataItems of CostItems for multiple scheme cost data
'Private mcSchemeCostDataItems As New DataItems ' DataItems of DataItems for costs
Private mcSchemeEstCostDataItems As New DataItems ' DataItems of data items for est costs
Private mcSchemeFundings As New DataItems ' DataItems of Funding items for multiple funding
Private mcSchemeFundingDataItems As New DataItems ' DataItems of DataItems for funding
Private mcSchemeSN1DataItems As New DataItems ' DataItems of DataItems for SN1 presentation
Private mcSchemeSFN1DataItems As New DataItems ' DataItems of DataItems for SFN1 presentation
Private mcSchemeGP2DataItems As New DataItems 'DataItems of dataItems for GP2 presentation
Private mcSchemeSiteDataItems As New DataItems ' DataItems of dataitems for site

Private mconDataValues As New rdoConnection ' database connections to get actual data values
Private mconScreenTemplate As New rdoConnection ' database connection to get data template (may refer to diff db)

' this type decribes how the local vs db data in a collection is
Private Type DataStatus
    LastUpdateTime As Date  ' Time that the data was last sucessfully written to the db
    LastUpdateUserID As Integer   ' Who wrote that data
    CurrentState As StatusTypes  ' whether the data was written properly (may not be ok if db link crashed)
End Type

Private Sub Class_Terminate()
    ' need to tidy up and release all object references
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

Public Property Let SchemeID(lValue As Long)
   Let mlSchemeID = lValue
End Property

Public Property Get SchemeID() As Long
   Let SchemeID = mlSchemeID
End Property

Public Property Get SchemeBaseDataItems() As DataItems

    Set SchemeBaseDataItems = mcSchemeBaseDataItems

End Property

Public Property Get SchemeSiteDataItems() As DataItems

    Set SchemeSiteDataItems = mcSchemeSiteDataItems

End Property

Public Property Get SchemeCosts() As DataItems

    Set SchemeCosts = mcSchemeCosts

End Property

Public Sub InitialiseSchemeData(iSchemeID As Integer)

    ' this takes a while to load the scheme
    ' note that there may be some bits that have not yet got any entries in the database
    ' table under scheme ID - when updating these must be inserted, not updated
    ' Each collection must know this
    ' need to prevent another user attempting to intialise this scheme while it is
    ' loading data - probably need flag in global area
    
    Dim rsDataValues As rdoResultset
    Dim rsTemplate As rdoResultset
    Dim iUpdateType As SchemeUpdateType
    
    Dim cSchemeCostDataItems As DataItems
    
    ' todo add on error code
    mlSchemeID = iSchemeID

    ' set up connections (not connecting yet)
    mconDataValues.Connect = gsDB_CONN_STRING
 '   mconDataValues.CursorDriver = rdUseOdbc
    
    mconDataValues.EstablishConnection
    
    mconScreenTemplate.Connect = gsDB_CONN_STRING
'    mconScreenTemplate.CursorDriver
    
    mconScreenTemplate.EstablishConnection
    
    '--------------------------------------------------------------------------
    ' load base data into scheme
    ' first get the recordset of data for the scheme base data
    
    Set rsDataValues = mconDataValues.OpenResultset("select * from Scheme where SchemeID=" & _
                   mlSchemeID, rdOpenStatic)
    ' check if there is data here
    If rsDataValues.EOF Then
        iUpdateType = Append  ' no rows returned - no data for the schemeId so must append rows
    Else
        iUpdateType = Insert  ' rows returned - data must be extracted then overwritten
    End If
        
    ' then get the recordset of data for the scheme template
    
    Set rsTemplate = mconDataValues.OpenResultset("select * from CreateSchemeTemplate", rdOpenStatic)
    
    ' go through the template setting up the data items for display as well as their
    ' values from the db if any
    
    Call FillCollectionWithData(mcSchemeBaseDataItems, rsTemplate, rsDataValues, iUpdateType)
    
    '--------------------------------------------------------------------------
    '  load site info
    
    Set rsDataValues = mconDataValues.OpenResultset("select * from Sites where SchemeID=" & _
                   mlSchemeID, rdOpenStatic)
    ' check if there is data here
    If rsDataValues.EOF Then
        iUpdateType = Append  ' no rows returned - no data for the schemeId so must append rows
    Else
        iUpdateType = Insert  ' rows returned - data must be extracted then overwritten
    End If
        
    ' then get the recordset of data for the scheme template
    
    Set rsTemplate = mconDataValues.OpenResultset("select * from SiteTemplate", rdOpenStatic)
    
    ' go through the template setting up the data items for display as well as their
    ' values from the db if any
    
    Call FillCollectionWithData(mcSchemeSiteDataItems, rsTemplate, rsDataValues, iUpdateType)
    mcSchemeSiteDataItems.DBMode = iUpdateType
    
    '--------------------------------------------------------------------------
    '  load cost info
    
    Set rsDataValues = mconDataValues.OpenResultset("select * from ActualCosts where SchemeID=" & _
                   mlSchemeID, rdOpenStatic)
    
    ' then get the recordset of data for the scheme template
    Set rsTemplate = mconDataValues.OpenResultset("select * from ActualCostTemplate", rdOpenStatic)
     
    ' check if there is data here
    If rsDataValues.EOF Then
        iUpdateType = Append  ' no rows returned - no data for the schemeId so must append rows
    Else
        iUpdateType = Insert  ' rows returned - data must be extracted then overwritten
        
        Do While Not rsDataValues.EOF
            Set cSchemeCostDataItems = New DataItems
            ' go through the template setting up the data items for display as well as their
            ' values from the db if any
    
            Call FillCollectionWithData(cSchemeCostDataItems, rsTemplate, rsDataValues, iUpdateType)
            rsTemplate.MoveFirst
            
            mcSchemeCosts.Add cSchemeCostDataItems, CStr(rsDataValues("CostID"))
            mcSchemeCosts.TableID = CStr(rsDataValues("CostID"))
            mcSchemeCosts.DBMode = Insert
            Set cSchemeCostDataItems = Nothing
            rsDataValues.MoveNext
        Loop
    End If
    
    ' append a new cost to the collection
    Set cSchemeCostDataItems = New DataItems
    Call FillCollectionWithData(cSchemeCostDataItems, rsTemplate, rsDataValues, Append)  ' type must be append - no data availailbe
    
    mcSchemeCosts.Add cSchemeCostDataItems, "<new>"
    mcSchemeCosts.TableID = "<new>"
    mcSchemeCosts.DBMode = Append
     
    Set cSchemeCostDataItems = Nothing
             
    '--------------------------------------------------------------------------
    '  load est cost info
    
    Set rsDataValues = mconDataValues.OpenResultset("select * from EstimatedCosts where SchemeID=" & _
                   mlSchemeID, rdOpenStatic)
    ' check if there is data here
    If rsDataValues.EOF Then
        iUpdateType = Append  ' no rows returned - no data for the schemeId so must append rows
    Else
        iUpdateType = Insert  ' rows returned - data must be extracted then overwritten
    End If
        
    ' then get the recordset of data for the scheme template
    
    Set rsTemplate = mconDataValues.OpenResultset("select * from EstimatedCostTemplate", rdOpenStatic)
    
    ' go through the template setting up the data items for display as well as their
    ' values from the db if any
    
    Call FillCollectionWithData(mcSchemeEstCostDataItems, rsTemplate, rsDataValues, iUpdateType)

End Sub

Private Sub FillCollectionWithData(ByRef cTargetCollection As DataItems, _
                                    rsTemplate As rdoResultset, _
                                    rsDataValues As rdoResultset, _
                                    iUpdateType As SchemeUpdateType)

    Dim oDataItem As DataItem

    Do While Not rsTemplate.EOF
        Set oDataItem = New DataItem
        Call oDataItem.InitialiseField(rsTemplate(0), rsTemplate(1), rsTemplate(2), _
                             rsTemplate(3), rsTemplate(4), rsTemplate(5), rsTemplate(6), _
                             rsTemplate(7), rsTemplate(8), rsTemplate(9))
        cTargetCollection.Add oDataItem, CStr(oDataItem.ItemCode)
        If (iUpdateType = Insert) Then
            ' there is data, so set it
            oDataItem.ItemValue = rsDataValues.rdoColumns.Item(CStr(rsTemplate(8)))  ' name of field holding values
        End If
        
        Set oDataItem = Nothing
        rsTemplate.MoveNext
    Loop

End Sub
