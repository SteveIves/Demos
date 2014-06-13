Attribute VB_Name = "modMain"
Option Explicit

Public Project As Project
Public Repository As Repository
Public RegPath As String

Public Sub ListChildren()

    Dim c As Integer
    
    Call SwitchListView(lvwList)
    
    With frmMain.List
        .ColumnHeaders.Clear
        .ListItems.Clear
        .Sorted = False
    End With

    With frmMain.Tree
        If .SelectedItem.Children > 0 Then
            For c = .SelectedItem.Child.Index To .SelectedItem.Child.LastSibling.Index
                If .Nodes(c).Parent.Key = .SelectedItem.Key Then
                    frmMain.List.ListItems.Add , .Nodes(c).Key, .Nodes(c).Text, .Nodes(c).Image, .Nodes(c).Image
                End If
            Next c
        End If
    End With

    frmMain.List.MultiSelect = False

End Sub

Public Sub ListStructure()

    Dim c As Integer
    Dim SplitData() As String, Structure As Structure
    
    Call SwitchListView(lvwReport)
    
    With frmMain.List
        .ColumnHeaders.Clear
        .ColumnHeaders.Add , "PROPERTY", "Field", 3000
        .ColumnHeaders.Add , "VALUE", "Description", .Width - 3000
        .ListItems.Clear
        .Sorted = False
    End With
    
    With frmMain.List
                    
        SplitData = Split(frmMain.Tree.SelectedItem.Key, ":", 3)
        Set Structure = Repository.Structures(SplitData(1))

        .ListItems.Add , "DESCRIPTION", "Description", "PROPERTY", "PROPERTY"
        .ListItems("DESCRIPTION").ListSubItems.Add , "DESCRIPTION", Structure.Description

        .ListItems.Add , "FILETYPE", "File type", "PROPERTY", "PROPERTY"
        .ListItems("FILETYPE").ListSubItems.Add , "FILETYPE", Structure.FileType

        .ListItems.Add , "USERTEXT", "User text", "PROPERTY", "PROPERTY"
        .ListItems("USERTEXT").ListSubItems.Add , "USERTEXT", Structure.UserText

        .ListItems.Add , "RECORDSIZE", "Record size", "PROPERTY", "PROPERTY"
        .ListItems("RECORDSIZE").ListSubItems.Add , "RECORDSIZE", Structure.RecordSize

        .ListItems.Add , "FIELDCOUNT", "Fields", "PROPERTY", "PROPERTY"
        .ListItems("FIELDCOUNT").ListSubItems.Add , "FIELDCOUNT", Structure.FieldCount

        .ListItems.Add , "KEYCOUNT", "Keys", "PROPERTY", "PROPERTY"
        .ListItems("KEYCOUNT").ListSubItems.Add , "KEYCOUNT", Structure.KeyCount

        .ListItems.Add , "RELCOUNT", "Relations", "PROPERTY", "PROPERTY"
        .ListItems("RELCOUNT").ListSubItems.Add , "RELCOUNT", Structure.RelationCount

        .ListItems.Add , "FILECOUNT", "Files", "PROPERTY", "PROPERTY"
        .ListItems("FILECOUNT").ListSubItems.Add , "FILECOUNT", Structure.FileCount

        .ListItems.Add , "FORMATCOUNT", "Formats", "PROPERTY", "PROPERTY"
        .ListItems("FORMATCOUNT").ListSubItems.Add , "FORMATCOUNT", Structure.FormatCount

        .ListItems.Add , "TAGCOUNT", "Tags", "PROPERTY", "PROPERTY"
        .ListItems("TAGCOUNT").ListSubItems.Add , "TAGCOUNT", Structure.TagCount

        .ListItems.Add , "TAGTYPE", "Tag type", "PROPERTY", "PROPERTY"
        .ListItems("TAGTYPE").ListSubItems.Add , "TAGTYPE", Structure.TagType

        .ListItems.Add , "FIRSTFILE", "First assigned file", "PROPERTY", "PROPERTY"
        .ListItems("FIRSTFILE").ListSubItems.Add , "FIRSTFILE", Structure.FirstFile
                
    End With

    frmMain.List.MultiSelect = False

End Sub

Public Sub ListProperties()

    If frmMain.Tree.SelectedItem.Key = "PRJPROP" Then
        
        Call SwitchListView(lvwReport)
        
        With frmMain.List
            
            .ColumnHeaders.Clear
            .ListItems.Clear
            .Sorted = False
           
            .ColumnHeaders.Add , "PROPERTY", "Property", 3000
            .ColumnHeaders.Add , "VALUE", "Value", .Width - 3000
            
            .ListItems.Add , "DESCRIPTION", "Description", "PROPERTY", "PROPERTY"
            .ListItems("DESCRIPTION").ListSubItems.Add , "DESCRIPTION", Project.Description
            .ListItems.Add , "FILE", "File", "PROPERTY", "PROPERTY"
            .ListItems("FILE").ListSubItems.Add , "FILE", Project.File
            .ListItems.Add , "WEBDIR", "Web Directory", "PROPERTY", "PROPERTY"
            .ListItems("WEBDIR").ListSubItems.Add , "WEBDIR", Project.WebDir
            .ListItems.Add , "SYNDIR", "Synergy Directory", "PROPERTY", "PROPERTY"
            .ListItems("SYNDIR").ListSubItems.Add , "SYNDIR", Project.SynergyDir
            .ListItems.Add , "SERVER", "Server", "PROPERTY", "PROPERTY"
            .ListItems("SERVER").ListSubItems.Add , "SERVER", Project.Server
            .ListItems.Add , "PORT", "Port", "PROPERTY", "PROPERTY"
            .ListItems("PORT").ListSubItems.Add , "PORT", Project.Port
            .ListItems.Add , "RPSMFIL", "Repository Main File", "PROPERTY", "PROPERTY"
            .ListItems("RPSMFIL").ListSubItems.Add , "RPSMFIL", Project.RpsMainFile
            .ListItems.Add , "RPSTFIL", "Repository Text File", "PROPERTY", "PROPERTY"
            .ListItems("RPSTFIL").ListSubItems.Add , "RPSTFIL", Project.RpsTextFile
            .ListItems.Add , "OLB", "Object Library", "PROPERTY", "PROPERTY"
            .ListItems("OLB").ListSubItems.Add , "OLB", Project.Olb
            .ListItems.Add , "ELB", "Executable library", "PROPERTY", "PROPERTY"
            .ListItems("ELB").ListSubItems.Add , "ELB", Project.Elb
        End With

    End If

End Sub


Public Sub ListFields()

    'This routine updates the main forms listview field to display a
    'list of child fields for a project file, or repository structure,
    'which has been clicked on in the main treeview.

    If frmMain.Tree.SelectedItem.Key = "PRJFIL:global.asa" Then
        With frmMain.List
            .ColumnHeaders.Clear
            .ListItems.Clear
            .Sorted = False
        End With
        Exit Sub
    End If

    Dim c As Integer
    Dim SplitData() As String, Structure As String, Field As Field
    
    Call SwitchListView(lvwReport)
    
    With frmMain.List
        .ColumnHeaders.Clear
        .ColumnHeaders.Add , "PROPERTY", "Field", 3000
        .ColumnHeaders.Add , "VALUE", "Description", .Width - 3000
        .ListItems.Clear
        .Sorted = False
    End With
    
    With frmMain.Tree
        If .SelectedItem.Children > 0 Then
            For c = .SelectedItem.Child.Index To .SelectedItem.Child.LastSibling.Index
                If .Nodes(c).Parent.Key = .SelectedItem.Key Then
                    
                    SplitData = Split(.Nodes(c).Key, ":", 3)
                                        
                    Select Case SplitData(0)
                    Case "PRJFLD"
                        Structure = Project.ProjectFiles(SplitData(1)).Structure
                    Case "STRFLD"
                        Structure = SplitData(1)
                    End Select
                    
                    Set Field = Repository.Structures(Structure).Fields(SplitData(2))
                    
                    frmMain.List.ListItems.Add , .Nodes(c).Key, Field.FieldName, "FIELD", "FIELD"
                    frmMain.List.ListItems(.Nodes(c).Key).ListSubItems.Add , .Nodes(c).Key, Field.Description
                
                End If
            Next c

            Select Case SplitData(0)
            Case "PRJFLD"
                frmMain.List.MultiSelect = False
            Case "RPSFLD"
                frmMain.List.MultiSelect = True
            End Select
        
        End If
    End With

End Sub

Public Sub ListFieldProperties()

    Dim SplitData() As String, Structure As String, Field As Field
    Dim Class As String, DataType As String

    SplitData = Split(frmMain.Tree.SelectedItem.Key, ":", 3)
    
    Select Case SplitData(0)
    Case "PRJFLD"
        Structure = Project.ProjectFiles(SplitData(1)).Structure
    Case "STRFLD"
        Structure = SplitData(1)
    End Select

    Set Field = Repository.Structures(Structure).Fields(SplitData(2))

    With frmMain.List
        
        .ColumnHeaders.Clear
        .ListItems.Clear
        .Sorted = False
        
        Call SwitchListView(lvwReport)
        
        .ColumnHeaders.Add , "PROPERTY", "Property", 3000
        .ColumnHeaders.Add , "VALUE", "Value", .Width - 3000
        
        .ListItems.Add , "STRUCTURE", "Structure", "PROPERTY", "PROPERTY"
        .ListItems("STRUCTURE").ListSubItems.Add , "STRUCTURE", Structure
        
        .ListItems.Add , "FIELD", "Field Name", "PROPERTY", "PROPERTY"
        .ListItems("FIELD").ListSubItems.Add , "FIELD", Field.FieldName
        
        .ListItems.Add , "DESCRIPTION", "Description", "PROPERTY", "PROPERTY"
        .ListItems("DESCRIPTION").ListSubItems.Add , "DESCRIPTION", Field.Description
        
        .ListItems.Add , "PROMPT", "Prompt", "PROPERTY", "PROPERTY"
        .ListItems("PROMPT").ListSubItems.Add , "PROMPT", Field.Prompt
    
        Select Case Field.DataType
        Case "A"
            DataType = "Alpha"
        Case "D"
            If Field.Precision = 0 Then
                If Field.Class = 0 Then
                    DataType = "Decimal"
                ElseIf Field.Class >= 8 Then
                    DataType = "Time (Decimal)"
                Else
                    DataType = "Date (Decimal)"
                End If
            Else
                DataType = "Implied-decimal"
            End If
        Case "I"
            DataType = "Integer"
        Case "U"
            DataType = "User-defined"
        End Select
        
        .ListItems.Add , "DATATYPE", "Data type", "PROPERTY", "PROPERTY"
        .ListItems("DATATYPE").ListSubItems.Add , "DATATYPE", DataType

        If Field.Class > 0 Then
        
            Select Case Field.Class
            Case 1
                Class = "Date (YYMMDD)"
            Case 2
                Class = "Date (YYYYMMDD)"
            Case 3
                Class = "Date (YYJJJ)"
            Case 4
                Class = "Date (YYYYJJJ)"
            Case 5
                Class = "Date (YYPP)"
            Case 6
                Class = "Date (YYYYPP)"
            Case 8
                Class = "Time (HHMMSS)"
            Case 9
                Class = "Time (HHMM)"
            End Select
            
            .ListItems.Add , "CLASS", "Field Class", "PROPERTY", "PROPERTY"
            .ListItems("CLASS").ListSubItems.Add , "CLASS", Class

            If Field.Class >= 8 Then
            
                .ListItems.Add , "TIMENOW", "Default to current time", "PROPERTY", "PROPERTY"
                If Field.TimeNow Then
                    .ListItems("TIMENOW").ListSubItems.Add , "TIMENOW", "Yes"
                Else
                    .ListItems("TIMENOW").ListSubItems.Add , "TIMENOW", "No"
                End If
        
                .ListItems.Add , "TIMEAMPM", "12-hour time (AM/PM)", "PROPERTY", "PROPERTY"
                If Field.TimeAmPm Then
                    .ListItems("TIMEAMPM").ListSubItems.Add , "TIMEAMPM", "Yes"
                Else
                    .ListItems("TIMEAMPM").ListSubItems.Add , "TIMEAMPM", "No"
                End If
            
            Else
            
                .ListItems.Add , "DATETODAY", "Default to todays date", "PROPERTY", "PROPERTY"
                If Field.DateToday Then
                    .ListItems("DATETODAY").ListSubItems.Add , "DATETODAY", "Yes"
                Else
                    .ListItems("DATETODAY").ListSubItems.Add , "DATETODAY", "No"
                End If
            
            End If
                
        End If

        .ListItems.Add , "SIZE", "Size", "PROPERTY", "PROPERTY"
        .ListItems("SIZE").ListSubItems.Add , "SIZE", Field.Size

        If Field.Precision > 0 Then
            
            .ListItems.Add , "PRECISION", "Precision", "PROPERTY", "PROPERTY"
            .ListItems("PRECISION").ListSubItems.Add , "PRECISION", Field.Precision
        
            .ListItems.Add , "NODECIMAL", "Implied decimal point on entry", "PROPERTY", "PROPERTY"
            If Field.NoDemimalRequired Then
                .ListItems("NODECIMAL").ListSubItems.Add , "NODECIMAL", "Yes"
            Else
                .ListItems("NODECIMAL").ListSubItems.Add , "NODECIMAL", "No"
            End If
        
        End If

        If Field.ArrayDimension1 > 1 Then
            .ListItems.Add , "ARRAY", "Array dimensions", "PROPERTY", "PROPERTY"
            .ListItems("ARRAY").ListSubItems.Add , "ARRAY", Field.ArrayDimension1 & " , " & Field.ArrayDimension2 & " , " & Field.ArrayDimension3 & " , " & Field.ArrayDimension4
        End If
        
        .ListItems.Add , "POSITION", "Position in record", "PROPERTY", "PROPERTY"
        .ListItems("POSITION").ListSubItems.Add , "POSITION", Field.Position

        If Field.OverlayField <> "" Then
        
            .ListItems.Add , "OVFIELD", "Overlays field", "PROPERTY", "PROPERTY"
            .ListItems("OVFIELD").ListSubItems.Add , "OVFIELD", Field.OverlayField

            .ListItems.Add , "OVOFF", "Overlay offset", "PROPERTY", "PROPERTY"
            .ListItems("OVOFF").ListSubItems.Add , "OVOFF", Field.OverlayOffset
        
        End If
        
        .ListItems.Add , "DEFAULT", "Default value", "PROPERTY", "PROPERTY"
        .ListItems("DEFAULT").ListSubItems.Add , "DEFAULT", Field.DefaultValue

        If Field.DataType = "D" Or Field.DataType = "I" Then
        
            .ListItems.Add , "MIN", "Minimum value", "PROPERTY", "PROPERTY"
            .ListItems("MIN").ListSubItems.Add , "MIN", Field.Min
        
            .ListItems.Add , "MAX", "Maximum value", "PROPERTY", "PROPERTY"
            .ListItems("MAX").ListSubItems.Add , "MAX", Field.Max

            .ListItems.Add , "NEGATIVES", "Negatives allowed", "PROPERTY", "PROPERTY"
            If Field.Negatives Then
                .ListItems("NEGATIVES").ListSubItems.Add , "NEGATIVES", "Yes"
            Else
                .ListItems("NEGATIVES").ListSubItems.Add , "NEGATIVES", "No"
            End If

        End If
        
        .ListItems.Add , "REQUIRED", "Required", "PROPERTY", "PROPERTY"
        If Field.Required Then
            .ListItems("REQUIRED").ListSubItems.Add , "REQUIRED", "Yes"
        Else
            .ListItems("REQUIRED").ListSubItems.Add , "REQUIRED", "No"
        End If

        If Field.DataType = "A" Or Field.DataType = "U" Then
        
            .ListItems.Add , "UPPERCASE", "Uppercase", "PROPERTY", "PROPERTY"
            If Field.Uppercase Then
                .ListItems("UPPERCASE").ListSubItems.Add , "UPPERCASE", "Yes"
            Else
                .ListItems("UPPERCASE").ListSubItems.Add , "UPPERCASE", "No"
            End If

        End If

        .ListItems.Add , "CHECK", "Display as checkbox", "PROPERTY", "PROPERTY"
        If Field.CheckBox Then
            .ListItems("CHECK").ListSubItems.Add , "CHECK", "Yes"
        Else
            .ListItems("CHECK").ListSubItems.Add , "CHECK", "No"
        End If

        .ListItems.Add , "RADIO", "Display as radio buttons", "PROPERTY", "PROPERTY"
        If Field.RadioButtons Then
            .ListItems("RADIO").ListSubItems.Add , "RADIO", "Yes"
        Else
            .ListItems("RADIO").ListSubItems.Add , "RADIO", "No"
        End If

        .ListItems.Add , "READONLY", "Read-only", "PROPERTY", "PROPERTY"
        If Field.ReadOnly Then
            .ListItems("READONLY").ListSubItems.Add , "READONLY", "Yes"
        Else
            .ListItems("READONLY").ListSubItems.Add , "READONLY", "No"
        End If

        .ListItems.Add , "DISABLED", "Disabled", "PROPERTY", "PROPERTY"
        If Field.Disabled Then
            .ListItems("DISABLED").ListSubItems.Add , "DISABLED", "Yes"
        Else
            .ListItems("DISABLED").ListSubItems.Add , "DISABLED", "No"
        End If

        .ListItems.Add , "PASSWORD", "Password field", "PROPERTY", "PROPERTY"
        If Field.Password Then
            .ListItems("PASSWORD").ListSubItems.Add , "PASSWORD", "Yes"
        Else
            .ListItems("PASSWORD").ListSubItems.Add , "PASSWORD", "No"
        End If

        .ListItems.Add , "AVLANG", "Available to Language", "PROPERTY", "PROPERTY"
        If Field.AvailableLanguage Then
            .ListItems("AVLANG").ListSubItems.Add , "AVLANG", "Yes"
        Else
            .ListItems("AVLANG").ListSubItems.Add , "AVLANG", "No"
        End If

        .ListItems.Add , "AVRPT", "Available to ReportWriter & ODBC", "PROPERTY", "PROPERTY"
        If Field.AvailableReportWriter Then
            .ListItems("AVRPT").ListSubItems.Add , "AVRPT", "Yes"
        Else
            .ListItems("AVRPT").ListSubItems.Add , "AVRPT", "No"
        End If

        .ListItems.Add , "AVTK", "Available to Toolkit", "PROPERTY", "PROPERTY"
        If Field.AvailableToolkit Then
            .ListItems("AVTK").ListSubItems.Add , "AVTK", "Yes"
        Else
            .ListItems("AVTK").ListSubItems.Add , "AVTK", "No"
        End If

        .ListItems.Add , "HEADING", "Report heading", "PROPERTY", "PROPERTY"
        .ListItems("HEADING").ListSubItems.Add , "HEADING", Field.ReportHeading

        .ListItems.Add , "REPJST", "Report justification", "PROPERTY", "PROPERTY"
        .ListItems("REPJST").ListSubItems.Add , "REPJST", Field.ReportJustification

        .ListItems.Add , "INPJST", "Input justification", "PROPERTY", "PROPERTY"
        .ListItems("INPJST").ListSubItems.Add , "INPJST", Field.InputJustification

        .ListItems.Add , "HELPID", "Help identifier", "PROPERTY", "PROPERTY"
        .ListItems("HELPID").ListSubItems.Add , "HELPID", Field.HelpID

        .ListItems.Add , "SBTEXT", "Status bar text", "PROPERTY", "PROPERTY"
        .ListItems("SBTEXT").ListSubItems.Add , "SBTEXT", Field.StatusBarText

        .ListItems.Add , "ODBCNAME", "ODBC column name", "PROPERTY", "PROPERTY"
        .ListItems("ODBCNAME").ListSubItems.Add , "ODBCNAME", Field.OdbcName

        .ListItems.Add , "FFONT", "Field font", "PROPERTY", "PROPERTY"
        .ListItems("FFONT").ListSubItems.Add , "FFONT", Field.FieldFont

        .ListItems.Add , "PFONT", "Prompt font", "PROPERTY", "PROPERTY"
        .ListItems("PFONT").ListSubItems.Add , "PFONT", Field.PromptFont

    End With

    frmMain.List.MultiSelect = False

End Sub

Public Function TestSynergyServer(Server As String, Port As Long, ShowMessages As Boolean, Form As Form) As Boolean

    Dim Synergy As Object, Status As Variant

    Form.MousePointer = vbHourglass

    Set Synergy = CreateObject("xfnlCom.xfProxy")
    
    Status = Synergy.xfStartup(Server, Port)

    If IsError(Status) Then
        If ShowMessages Then
            MsgBox "Connection to Synergy server failed. " & Synergy.getxfErrorMessage, vbCritical, "Server Test Failure"
        End If
        TestSynergyServer = False
    Else
        If ShowMessages Then
            MsgBox "Connected to Synergy server.", vbInformation, "Server Test Success"
        End If
        Call Synergy.xfShutdown
        Set Synergy = Nothing
        TestSynergyServer = True
    End If
    
    Form.MousePointer = vbDefault

End Function

Public Function TestRepository(Server As String, Port As Long, MainFile As String, TextFile As String, ShowMessages As Boolean, Form As Form) As Boolean

    Dim Synergy As Object, Status As Variant, ErrText As String
    
    TestRepository = False 'Default to failure

    Form.MousePointer = vbHourglass

    Set Synergy = CreateObject("xfnlCom.xfProxy")
    
    Status = Synergy.xfStartup(Server, Port)

    If IsError(Status) Then
        If ShowMessages Then
            MsgBox "Connection to Synergy server failed. " & Synergy.getxfErrorMessage, vbCritical, "Server Failure"
        End If
    Else
        
        Status = Synergy.xfSubr("validate_rps", MainFile, TextFile)
        
        If IsError(Status) Then
            If ShowMessages Then
                MsgBox "Repository validation failed. " & Synergy.getxfErrorMessage, vbCritical, "Server Failure"
            End If
        Else
            If Status <> 0 Then
                Select Case Status
                Case 1
                    ErrText = "Record not found."
                Case 2
                    ErrText = "Cannot open file."
                Case 3
                    ErrText = "Invalid function."
                Case 4
                    ErrText = "Cannot open Repository main file."
                Case 5
                    ErrText = "Cannot open Repository text file."
                Case 6
                    ErrText = "Incompatible Repository version."
                End Select
                If ShowMessages Then
                    MsgBox ErrText, vbCritical, "Repository Test Failed"
                End If
            Else
                If ShowMessages Then
                    MsgBox "Repository located and opened.", vbInformation, "Repository Test Success"
                End If
                TestRepository = True
            End If
        End If
        
        Call Synergy.xfShutdown
    
    End If
    
    Set Synergy = Nothing
    
    Form.MousePointer = vbDefault

End Function

Public Sub SwitchListView(newView As Integer)

    Dim c As Integer

    frmMain.List.View = newView
    
    For c = 0 To 3
        frmMain.mnuViewOptions(c).Checked = False
    Next c
    
    frmMain.mnuViewOptions(newView).Checked = True

    Select Case newView
    Case lvwIcon
        frmMain.Toolbar.Buttons("LARGE").Value = tbrPressed
    Case lvwSmallIcon
        frmMain.Toolbar.Buttons("SMALL").Value = tbrPressed
    Case lvwList
        frmMain.Toolbar.Buttons("LIST").Value = tbrPressed
    Case lvwReport
        frmMain.Toolbar.Buttons("DETAIL").Value = tbrPressed
    End Select

End Sub
