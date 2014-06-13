VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Repository"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Member0" ,"GlobalFormats"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Attribute VB_Ext_KEY = "Member1" ,"Structures"
Option Explicit

Private Synergy As Object

'Collection data
Private mvarStructures As Structures

'Property data
Private mvarDescription As String
Private mvarServer As String
Private mvarPort As Long
Private mvarMainFile As String
Private mvarTextFile As String
Private mvarConnected As Boolean
Private mvarGlobalFormats As GlobalFormats


Public Property Get GlobalFormats() As GlobalFormats
    If mvarGlobalFormats Is Nothing Then
        Set mvarGlobalFormats = New GlobalFormats
    End If


    Set GlobalFormats = mvarGlobalFormats
End Property


Public Property Set GlobalFormats(vData As GlobalFormats)
    Set mvarGlobalFormats = vData
End Property



'Class events
Private Sub Class_Initialize()
    Set mvarStructures = New Structures
End Sub

Private Sub Class_Terminate()
  Set mvarGlobalFormats = Nothing
    Set mvarStructures = Nothing
End Sub


'Connect Method
Public Function Connect() As Boolean

    Dim Status As Variant, Server As Variant, Port As Variant
    Dim RpsMfil As Variant, RpsTfil As Variant
    
    'Check that the required properties have been set
    If mvarServer = "" Or mvarPort = 0 Then
        Connect = False
        Exit Function
    End If

    Set Synergy = CreateObject("xfnlCOM.xfProxy")

    Server = mvarServer
    Port = mvarPort
    
    Status = Synergy.xfStartup(Server, Port)

    If IsError(Status) Then
        Set Synergy = Nothing
        mvarConnected = False
    Else
        mvarConnected = True
    End If

    If mvarConnected Then
        'Log in to Synergy application
        
        RpsMfil = mvarMainFile
        RpsTfil = mvarTextFile
        
        Status = Synergy.xfSubr("login", RpsMfil, RpsTfil)
        If IsError(Status) Then
            Call Synergy.xfShutdown
            Set Synergy = Nothing
            mvarConnected = False
        End If
    End If

    Connect = mvarConnected

End Function

'Disconnect Method
Public Function Disconnect() As Boolean

    If mvarConnected Then
        Call Synergy.xfSubr("logout")
        Call Synergy.xfShutdown
        Set Synergy = Nothing
        mvarConnected = False
        Disconnect = True
    Else
        Disconnect = False
    End If

End Function


'Download Method
Public Function Download() As Boolean

    Dim Status As Variant
    Dim Count As Variant
    Dim C As Integer
    Dim OK As Boolean
    Dim Structure As Structure
    Dim NameArray() As Variant
    Dim DataArray() As Variant
    
    Download = True
    
    'Get number of structures in RPS
    Count = 0
    Status = Synergy.xfSubr("structure_list", 1, Count)
    If IsError(Status) Then
        Download = False
    Else
        If (Status <> 0) Then
            Download = False
        Else
            If Count = 0 Then
                'No structures in Repository
                Exit Function
            End If
        End If
    End If
            
    'Get list of structure names
    If Download Then
        ReDim NameArray(Count - 1), DataArray(Count - 1)
        For C = 0 To Count - 1
            NameArray(C) = ""
            DataArray(C) = ""
        Next C
        Status = Synergy.xfSubr("structure_list", 2, Count, NameArray, DataArray)
        If IsError(Status) Then
            Download = False
        End If
    End If

    'Load structure names into Structures collection
    If Download Then
        With mvarStructures
            For C = 0 To Count - 1
                .Add NameArray(C)
                With mvarStructures(NameArray(C))
                    .Description = Mid(DataArray(C), 1, 40)
                    .FileType = Mid(DataArray(C), 41, 15)
                    .UserText = Mid(DataArray(C), 56, 60)
                    .RecordSize = CLng(Mid(DataArray(C), 116, 5))
                    .FieldCount = CInt(Mid(DataArray(C), 121, 3))
                    .KeyCount = CInt(Mid(DataArray(C), 124, 3))
                    .RelationCount = CInt(Mid(DataArray(C), 127, 2))
                    .FileCount = CInt(Mid(DataArray(C), 129, 3))
                    If (Mid(DataArray(C), 132, 3) = "   ") Then
                        .FormatCount = 0
                    Else
                        .FormatCount = CInt(Mid(DataArray(C), 132, 3))
                    End If
                    If Mid(DataArray(C), 135, 2) = "  " Then
                        .TagCount = 0
                    Else
                        .TagCount = CInt(Mid(DataArray(C), 135, 2))
                    End If
                    .TagType = Mid(DataArray(C), 137, 15)
                    .FirstFile = Mid(DataArray(C), 152, 30)
                End With
            Next C
        End With
    End If

   'Load Field details into Structures collection
    If Download Then
        For Each Structure In mvarStructures
            Count = 0
            Status = Synergy.xfSubr("structure_fields", 1, Structure.StructureName, Count)
            If IsError(Status) Then
                Download = False
            Else
                If (Status <> 0) Then
                    Download = False
                Else
                    If Count = 0 Then
                        Download = False
                    Else
                        ReDim NameArray(Count - 1), DataArray(Count - 1)
                        For C = 0 To Count - 1
                            NameArray(C) = ""
                            DataArray(C) = ""
                        Next C

                        Status = Synergy.xfSubr("structure_fields", 2, Structure.StructureName, Count, NameArray, DataArray)

                        If IsError(Status) Then
                            Download = False
                        Else
                            'Cycle through fields loading field data
                            For C = 0 To Count - 1
                                With mvarStructures(Structure.StructureName)
                                    .Fields.Add NameArray(C)
                                    With .Fields(NameArray(C))
                                        .DataType = Mid(DataArray(C), 1, 1)
                                        .Size = CLng(Mid(DataArray(C), 2, 5))
                                        .Precision = CInt(Mid(DataArray(C), 7, 2))
                                        .Required = CBool(Mid(DataArray(C), 9, 1))
                                        .Uppercase = CBool(Mid(DataArray(C), 10, 1))
                                        If Asc(Mid(DataArray(C), 11, 1)) <> 0 Then
                                            .Prompt = Trim(Mid(DataArray(C), 11, 80))
                                        End If
                                        .Negatives = CBool(Mid(DataArray(C), 91, 1))
                                        .Position = CLng(Mid(DataArray(C), 92, 5))
                                        .OverlayField = Trim(Mid(DataArray(C), 97, 30))
                                        .OverlayOffset = CLng(Mid(DataArray(C), 127, 5))
                                        If Asc(Mid(DataArray(C), 132, 1)) <> 0 Then
                                            .Description = Trim(Mid(DataArray(C), 132, 40))
                                        End If
                                        .Class = Trim(Mid(DataArray(C), 172, 1))
                                        .ArrayDimension1 = CInt(Mid(DataArray(C), 173, 3))
                                        'Array dimensions 2, 3 and 4 are returned as nulls if no value
                                        If Asc(Mid(DataArray(C), 176, 1)) <> 0 Then
                                            .ArrayDimension2 = CInt(Mid(DataArray(C), 176, 3))
                                        Else
                                            .ArrayDimension2 = 0
                                        End If
                                        If Asc(Mid(DataArray(C), 179, 1)) <> 0 Then
                    
                                            .ArrayDimension3 = CInt(Mid(DataArray(C), 179, 3))
                                        Else
                                            .ArrayDimension3 = 0
                                        End If
                                        If Asc(Mid(DataArray(C), 182, 3)) <> 0 Then
                                            .ArrayDimension4 = CInt(Mid(DataArray(C), 182, 3))
                                        Else
                                            .ArrayDimension4 = 0
                                        End If
                                        .AvailableLanguage = Not CBool(Mid(DataArray(C), 185, 1))
                                        .AvailableReportWriter = Not CBool(Mid(DataArray(C), 186, 1))
                                        .AvailableToolkit = Not CBool(Mid(DataArray(C), 187, 1))
                                        If Asc(Mid(DataArray(C), 188, 1)) <> 0 Then
                                            .ReportHeading = Trim(Mid(DataArray(C), 188, 40))
                                        End If
                                        .ReportJustification = Trim(Mid(DataArray(C), 228, 6))
                                        .InputJustification = Trim(Mid(DataArray(C), 234, 6))
                                        If Mid(DataArray(C), 240, 1) = "1" Then
                                            .RadioButtons = True
                                        Else
                                            .RadioButtons = False
                                        End If
                                        If Mid(DataArray(C), 241, 1) = "1" Then
                                            .Checkbox = True
                                        Else
                                            .Checkbox = False
                                        End If
                                        If Asc(Mid(DataArray(C), 242, 1)) <> 0 Then
                                            .HelpID = Trim(Mid(DataArray(C), 242, 80))
                                        End If
                                        If Asc(Mid(DataArray(C), 322, 1)) <> 0 Then
                                            .StatusBarText = Trim(Mid(DataArray(C), 322, 80))
                                        End If
                                        If Asc(Mid(DataArray(C), 402, 1)) <> 0 Then
                                            .OdbcName = Trim(Mid(DataArray(C), 402, 30))
                                        End If
                                        If Asc(Mid(DataArray(C), 432, 1)) <> 0 Then
                                            .FieldFont = Trim(Mid(DataArray(C), 432, 30))
                                        End If
                                        If Asc(Mid(DataArray(C), 462, 1)) <> 0 Then
                                            .PromptFont = Trim(Mid(DataArray(C), 462, 30))
                                        End If
                                        .ReadOnly = CBool(Mid(DataArray(C), 492, 1))
                                        .Disabled = CBool(Mid(DataArray(C), 493, 1))
                                        .Password = CBool(Mid(DataArray(C), 494, 1))
                                        If Asc(Mid(DataArray(C), 495, 1)) <> 0 Then
                                            .DefaultValue = Trim(Mid(DataArray(C), 495, 80))
                                        End If
                                        .DateToday = CBool(Mid(DataArray(C), 575, 1))
                                        .TimeNow = CBool(Mid(DataArray(C), 576, 1))
                                        .TimeAmPm = CBool(Mid(DataArray(C), 577, 1))
                                        .NoDemimalRequired = CBool(Mid(DataArray(C), 578, 1))
                                        .Min = CSng(Mid(DataArray(C), 579, 18) & "." & Mid(DataArray(C), 597, 10))
                                        .Max = CSng(Mid(DataArray(C), 607, 18) & "." & Mid(DataArray(C), 625, 10))
                                    End With
                                End With
                            Next C ' End of loading field data
                        End If
                    End If
                End If
            End If
        Next Structure 'End of field loading
    End If

   'Load key details into Structures collection
    If Download Then
    End If

   'Load relation details into Structures collection
    If Download Then
        For Each Structure In mvarStructures
            'Get number of relations for this structure
            Count = 0
            Status = Synergy.xfSubr("relation_list", 1, Structure.StructureName, Count)
            If IsError(Status) Then
                Download = False
                Exit For
            Else
                If (Status <> 0) Then
                    Download = False
                    Exit For
                Else
                    If Count > 0 Then
                        'Relations exist, get details
                        ReDim NameArray(Count - 1), DataAray(Count - 1)
                        For C = 0 To Count - 1
                            NameArray(C) = ""
                            DataArray(C) = ""
                        Next C
                        Status = Synergy.xfSubr("relation_list", 2, Structure.StructureName, Count, NameArray, DataArray)
                        If IsError(Status) Then
                            Download = False
                            Exit For
                        End If
                    
                        'Add relation details to structure
                        For C = 0 To Count - 1
                            With mvarStructures(Structure.StructureName)
                                .Relations.Add CStr(NameArray(C))
                                With .Relations(NameArray(C))
                                    .FromStructure = Mid(DataArray(C), 1, 30)
                                    .FromKey = Mid(DataArray(C), 31, 30)
                                    .ToStructure = Mid(DataArray(C), 61, 30)
                                    .ToKey = Mid(DataArray(C), 91, 30)
                                End With
                            End With
                        Next C
                    End If
                End If
            End If
        Next Structure
    End If

   'Load format details into Structures collection
    If Download Then
    End If

   'Load tag details into Structures collection
    If Download Then
    
        For Each Structure In mvarStructures
    
            'Get number of tags for this structure
            Count = 0
            Status = Synergy.xfSubr("tag_list", 1, Structure.StructureName, Count)
            If IsError(Status) Then
                Download = False
                Exit For
            Else
                If (Status <> 0) Then
                    Download = False
                    Exit For
                Else
                    If Count > 0 Then
                        'Tags exist, get details
                        ReDim NameArray(Count - 1), DataAray(Count - 1)
                        For C = 0 To Count - 1
                            NameArray(C) = ""
                            DataArray(C) = ""
                        Next C
                        Status = Synergy.xfSubr("tag_list", 2, Structure.StructureName, Count, NameArray, DataArray)
                        If IsError(Status) Then
                            Download = False
                            Exit For
                        End If
                    
                        'Add tag details to structure
                        For C = 0 To Count - 1
                            With mvarStructures(Structure.StructureName)
                                .Tags.Add CStr(NameArray(C))
                                With .Tags(NameArray(C))
                                    .Connector = Mid(DataArray(C), 1, 3)
                                    .TagField = Mid(DataArray(C), 4, 30)
                                    .Comparison = Mid(DataArray(C), 34, 2)
                                    .Value = Mid(DataArray(C), 36, 15)
                                End With
                            End With
                        Next C
                    End If
                End If
            End If
        
        Next Structure
    
    End If

End Function


'Structures Collection
Public Property Set Structures(vData As Structures)
    Set mvarStructures = vData
End Property
Public Property Get Structures() As Structures
'    If mvarStructures Is Nothing Then
'        Set mvarStructures = New Structures
'    End If
    Set Structures = mvarStructures
End Property


'Description Property
Public Property Let Description(ByVal vData As String)
    mvarDescription = vData
End Property
Public Property Get Description() As String
    Description = mvarDescription
End Property


'Server Property
Public Property Let Server(ByVal vData As String)
    mvarServer = vData
End Property
Public Property Get Server() As String
    Server = mvarServer
End Property


'Port Property
Public Property Let Port(ByVal vData As Long)
    mvarPort = vData
End Property
Public Property Get Port() As Long
    Port = mvarPort
End Property


'MainFile Property
Public Property Let MainFile(ByVal vData As String)
    mvarMainFile = vData
End Property
Public Property Get MainFile() As String
    MainFile = mvarMainFile
End Property


'TextFile Property
Public Property Let TextFile(ByVal vData As String)
    mvarTextFile = vData
End Property
Public Property Get TextFile() As String
    TextFile = mvarTextFile
End Property


'Connected Property
Public Property Let Connected(ByVal vData As Boolean)
    mvarConnected = vData
End Property
Public Property Get Connected() As Boolean
    Connected = mvarConnected
End Property

