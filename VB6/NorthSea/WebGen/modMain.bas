Attribute VB_Name = "modMain"
Option Explicit

'------------------------PUBLIC VARIABLES----------------------------------

Public fMain As frmMain
Public fProperties As frmProperties
Public fOptions As frmOptions

'Public project flags
Public ProjectFile As String
Public ProjectOpen As Boolean
Public ProjectChanged As Boolean

'Public Tools variables
Public ToolBrowser As String
Public ToolEditor As String
Public ToolFtpClient As String

'Save areas for program options dialog
Public SaveBrowser As String
Public SaveEditor As String
Public SaveFtpClient As String

'Save areas for project options dialog
Public SaveTemplates() As String
Public SaveDescription As String
Public SaveTemplateCount As Integer
Public SaveAllowFtp As Integer
Public SaveAllowEdit As Integer
Public SaveLog As Integer
Public SaveDetailLog As Integer

'Arrays to record FTP target details for generated files
Public FtpUrlArray() As String
Public FtpDirArray() As String
Public FtpTargetFileArray() As String
Public FtpUsernameArray() As String
Public FtpPasswordArray() As String

'Main Registry data path
Public RegPath As String

'General application flags
Dim EvalExpired As Boolean
Public ProjectLoading As Boolean

Dim Excel As Excel.Application

'Support for recycle bin
Private Type SHFILEOPSTRUCT
    hwnd As Long
    wFunc As Long
    pFrom As String
    pTo As String
    fFlags As Integer
    fAborted As Boolean
    hNameMappings As Long
    lpszProgressTitle As String
End Type
Public Const FO_DELETE = &H3
Public Const FOF_ALLOWUNDO = &H40
Private Declare Function SHFileOperation Lib "shell32.dll" Alias "SHFileOperationA" (lpFileOp As SHFILEOPSTRUCT) As Long

'Support form WinHelp
Public Declare Function WinHelp% Lib "user32" Alias "WinHelpA" (ByVal hwnd&, ByVal HelpFile$, ByVal wCommand%, dwData As Any)
Public Const HELP_CONTEXT = &H1          '  Display topic in ulTopic
Public Const HELP_QUIT = &H2             '  Terminate help
Public Const HELP_INDEX = &H3            '  Display index
Public Const HELP_CONTENTS = &H3&
Public Const HELP_HELPONHELP = &H4       '  Display help on using help
Public Const HELP_SETCONTENTS = &H5&
Public Const HELP_SETINDEX = &H5         '  Set current Index for multi index help
Public Const HELP_CONTEXTPOPUP = &H8&
Public Const HELP_FORCEFILE = &H9&
Public Const HELP_KEY = &H101            '  Display topic for keyword in offabData
Public Const HELP_COMMAND = &H102&
Public Const HELP_PARTIALKEY = &H105&
Public Const HELP_MULTIKEY = &H201&
Public Const HELP_SETWINPOS = &H203&




'------------------------MAIN-LINE-----------------------------------------

Sub Main()
    
    ProjectLoading = False
    
    'Setup the Registry path to be used
    RegPath = "Software\Internet Software Services\" & App.Title
    
    If App.PrevInstance = True Then
        MsgBox "Web Generator is already running!", vbExclamation, "Information"
        End
    End If

    Dim StartupDir As String
    StartupDir = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "StartupDir")
    If StartupDir <> "" Then
        ChDrive StartupDir
        ChDir StartupDir
    End If
    
    'Load up the properties and options dialogs
    Set fProperties = New frmProperties
    Set fOptions = New frmOptions
    Set fMain = New frmMain
    
    'Get external tool definitions from Registry
    ToolBrowser = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "Browser")
    ToolEditor = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "Editor")
    ToolFtpClient = GetSettingString(HKEY_LOCAL_MACHINE, RegPath, "FtpClient")
    
    'Load application options into options dialog
    fOptions.txtBrowser.Text = ToolBrowser
    fOptions.txtEditor.Text = ToolEditor
    fOptions.txtFtpClient.Text = ToolFtpClient
    
    'If we have an external browser, enable the appropriate options
    If ToolBrowser <> "" Then
        fMain.mnuToolsBrowser.Enabled = True
        fMain.tbToolBar.Buttons("Browser").Enabled = True
    End If
    
    'If we have an external editor, enable the appropriate options
    If ToolEditor <> "" Then
        fMain.mnuToolsEditor.Enabled = True
        fMain.tbToolBar.Buttons("Editor").Enabled = True
    End If
    
    'If we have an external FTP Client, enable the appropriate options
    If ToolFtpClient <> "" Then
        fMain.mnuToolsFtp.Enabled = True
        fMain.tbToolBar.Buttons("FtpClient").Enabled = True
    End If
    
    fMain.Show

    'Usage restrictions now removed
    'CheckEval

End Sub

'------------------------PUBLIC ROUTINES-----------------------------------

Public Sub AddLog(Message As String)

    If fProperties.chkLog.Value = 1 Then
        With frmGenerate.Log
            .AddItem Message
            .ListIndex = .NewIndex
        End With
    End If

End Sub

Public Sub AddDetailLog(Message As String)

    If fProperties.chkDetailLog.Value = 1 Then
        AddLog (Message)
    End If

End Sub

Public Sub CloseProject()

    'Reset public variables
    ProjectFile = ""
    ProjectOpen = False
    ProjectChanged = False
    
    'Clear out the project properties window
    With fProperties
        .txtDescription = ""
        .lstTemplates.Clear
        .chkAllowFtp.Value = 0
    End With

    SetupUI (ProjectOpen)

End Sub

Public Sub DeleteProject()

    On Error GoTo ErrorHandler

    Dim FileOperation As SHFILEOPSTRUCT
    Dim strFile As String
    
    With FileOperation
        .wFunc = FO_DELETE
        .pFrom = ProjectFile
        .fFlags = FOF_ALLOWUNDO
    End With
    
    SHFileOperation FileOperation
        
    If Dir(ProjectFile) = "" Then
        CloseProject
    End If
    
    Exit Sub

ErrorHandler:

    MsgBox "Failed to delete project", vbOKOnly + vbCritical, "Error"

End Sub

Public Sub GenerateProject()
    
    frmGenerate.MousePointer = vbHourglass
    
    Dim Total, Success, count As Integer
    Dim ThisTemplate As String

    'How many templates are selected?
    Total = frmGenerate.TplLst.SelCount

    'Cycle through templates, recording the number and names of those
    'which were successfully generated.
    For count = 0 To (frmGenerate.TplLst.ListCount - 1)
        If frmGenerate.TplLst.Selected(count) = True Then
            ThisTemplate = frmGenerate.TplLst.List(count)
            'Process the current template
            If ParseTemplate(ThisTemplate) = True Then
                Success = Success + 1
            End If
        End If
    Next

    If Success < Total Then
        MsgBox CStr(Total - Success) & " template(s) failed, inspect log!", vbOKOnly + vbExclamation, "Generation results"
    Else
        MsgBox CStr(Total) & " template(s) successfully generated", vbOKOnly + vbInformation, "Generation Results"
    End If

    frmGenerate.MousePointer = vbDefault

End Sub

Public Sub NewProject()

    With fMain.dlgCommonDialog
        
        .FileName = ""
        .DialogTitle = "New Project"
        .CancelError = False
        .Flags = &H2004&    'This should cause the common dialog to prevent
                            'the selection of an existing file, but it doesn't
                            'seem to work!!!
        .Filter = "Project Files (*.wgp)|*.wgp"
        '.InitDir = App.Path
        
        .ShowOpen
        
        If Len(.FileName) > 1 Then
            
            fProperties.Show vbModal, fMain
            
            If ProjectChanged = True Then
                ProjectFile = .FileName
                ProjectOpen = True
                SaveProject
                SetupUI (ProjectOpen)
            End If
        
        End If
    
    End With

End Sub

Public Sub OpenProject()

    ProjectLoading = True

    With fMain.dlgCommonDialog
        
        .FileName = ""
        .DialogTitle = "Open Project"
        .CancelError = False
        .Flags = &H1004&
        .Filter = "Project Files (*.wgp)|*.wgp"
        
        .ShowOpen
        
        If Len(.FileName) <> 0 Then
        
            If ParseProject(.FileName) = True Then
                ProjectFile = .FileName
                ProjectOpen = True
                SetupUI (ProjectOpen)
            End If
        
        End If
    
    End With

    ProjectLoading = False

End Sub

Public Function ParseProject(File As String) As Boolean

    On Error GoTo ErrorHandler
    
    Dim Buffer As String
    
    Open File For Input As #1
    Do While Not EOF(1)
        Line Input #1, Buffer
    
        If Left(Buffer, 11) = "DESCRIPTION" Then
            fProperties.txtDescription.Text = Right(Buffer, Len(Buffer) - 12)
        End If
    
        If Left(Buffer, 8) = "TEMPLATE" Then
            fProperties.lstTemplates.AddItem Right(Buffer, Len(Buffer) - 9)
        End If
        
        If Left(Buffer, 9) = "ALLOW_FTP" Then
            If Right(Buffer, Len(Buffer) - 10) = "YES" Then
                fProperties.chkAllowFtp.Value = 1
            Else
                fProperties.chkAllowFtp.Value = 0
            End If
        End If

        If Left(Buffer, 10) = "ALLOW_EDIT" Then
            If Right(Buffer, Len(Buffer) - 11) = "YES" Then
                fProperties.chkAllowEdit.Value = 1
            Else
                fProperties.chkAllowEdit.Value = 0
            End If
        End If

        If Left(Buffer, 10) = "RECORD_LOG" Then
            If Right(Buffer, Len(Buffer) - 11) = "YES" Then
                fProperties.chkLog.Value = 1
            Else
                fProperties.chkLog.Value = 0
            End If
        End If
        
        If Left(Buffer, 12) = "DETAILED_LOG" Then
            If Right(Buffer, Len(Buffer) - 13) = "YES" Then
                fProperties.chkDetailLog.Value = 1
            Else
                fProperties.chkDetailLog.Value = 0
            End If
        End If

    Loop
    Close #1

    ParseProject = True

    Exit Function

ErrorHandler:

    ParseProject = False

End Function

Public Sub SaveProject()

    On Error GoTo ErrorHandler

    Open ProjectFile For Output As #1
    
    Dim c As Integer
    
    Print #1, "DESCRIPTION=" & fProperties.txtDescription.Text
    
    If fProperties.chkAllowFtp.Value = 1 Then
        Print #1, "ALLOW_FTP=YES"
    Else
        Print #1, "ALLOW_FTP=NO"
    End If
    
    If fProperties.chkAllowEdit.Value = 1 Then
        Print #1, "ALLOW_EDIT=YES"
    Else
        Print #1, "ALLOW_EDIT=NO"
    End If
    
    If fProperties.chkLog.Value = 1 Then
        Print #1, "RECORD_LOG=YES"
    Else
        Print #1, "RECORD_LOG=NO"
    End If
    
    If fProperties.chkDetailLog.Value = 1 Then
        Print #1, "DETAILED_LOG=YES"
    Else
        Print #1, "DETAILED_LOG=NO"
    End If
    
    For c = 0 To fProperties.lstTemplates.ListCount - 1
        Print #1, "TEMPLATE=" & fProperties.lstTemplates.List(c)
    Next

    Close #1
    
    ProjectChanged = False
    
    Exit Sub

ErrorHandler:

    MsgBox "Failed to save project", vbOKOnly + vbCritical, "Error"

End Sub

Public Sub SaveProjectAs()

    'Get a new project file name and save the project to the new file
    
    With fMain.dlgCommonDialog
        
        .FileName = ""
        .DialogTitle = "Save Project As"
        .CancelError = False
        .Flags = &H2004&    'This should cause the common dialog to prevent
                            'the selection of an existing file, but it doesn't
                            'seem to work!!!
        .Filter = "Project Files (*.wgp)|*.wgp"
        '.InitDir = App.Path

        .ShowOpen
        
        If Len(.FileName) > 1 Then
            
            ProjectFile = .FileName
            SaveProject
            fMain.Caption = "Web Generator [" & ProjectFile & "]"

        End If
    
    End With

End Sub

'------------------------PRIVATE ROUTINES----------------------------------

Private Sub CheckEval()

    Dim UsageCount As Integer
    Dim MaxUsage As Integer
    Dim msg As String
    
    MaxUsage = 20
    
    UsageCount = CLng(GetSettingString(HKEY_LOCAL_MACHINE, "Software\ISSL\", "AppPosTop", "3353"))
    UsageCount = (UsageCount / 7) - 479
    UsageCount = UsageCount + 1
    
    If UsageCount > MaxUsage Then
        msg = "Sorry, your evaluation has expired!"
        msg = msg & Chr(13) & "HTML Generation is now DISABLED."
        MsgBox msg, vbOKOnly + vbCritical, "Web Generator Evaluation"
        EvalExpired = True
    Else
        msg = "This is evaluation " & CStr(UsageCount) & " of " & CStr(MaxUsage) & "."
        msg = msg & Chr(13) & "HTML Generation is Enabled."
        MsgBox msg, vbOKOnly + vbInformation, "Web Generator Evaluation"
        EvalExpired = False
        UsageCount = (UsageCount + 479) * 7
        Call SaveSettingString(HKEY_LOCAL_MACHINE, "Software\ISSL\", "AppPosTop", CStr(UsageCount))
    End If

End Sub

Private Function Decrypt(Password As String) As String

    Dim c As Integer
    Dim Result As String
    
    For c = 1 To (Len(Password) - 2) Step 3
        Result = Result & Chr(CInt(Mid(Password, c, 3)))
    Next

    Decrypt = Result

End Function

Private Function Encrypt(Password As String) As String

    Dim c As Integer
    Dim Result As String

    For c = 1 To Len(Password)
        Result = Result & Format(CStr(Asc(Mid(Password, c, 1))), "000")
    Next c

    Encrypt = Result

End Function

Private Function ParseTemplate(Template As String) As Boolean

    'This is where the work happens.  This routine accepts a template
    'file name and attempts to generate the required web page(s) based on
    'the tags found therein.

    On Error GoTo ErrorHandler
    
    Dim Buffer, TmpBuf, SheetName, Message, CellRef As String
    Dim FtpUrl, FtpDir, FtpUsername, FtpPassword As String
    Dim OutDir, TemplateDir, InFile, OutFile, OutFile2 As String
    Dim FileWritten, ExcelActive, SheetOpen As Boolean
    Dim StartPos, EndPos As Long
    Dim CellData As String
    Dim FtpCommand As String

    ParseTemplate = True
    ExcelActive = False
    SheetOpen = False
    FileWritten = False
    
    'If the passed in template file does not have an explicit path then
    'assume it's in the same directory as the project file
    If InStr(1, Template, "\") = 0 Then
        StartPos = InStrRev(ProjectFile, "\")
        Template = Left(ProjectFile, StartPos) & Template
    End If
    
    'Report progress
    fMain.sbStatusBar.Panels(1).Text = "Processing " & Template & " ..."
    AddLog ("Processing template " & Template)

    'Build default output file name as same base directory and file name
    'as the template file, but with a ".htm" file extension.  This will be
    'used if there is no "TARGET" meta-tag present in the template

    StartPos = InStrRev(Template, "\")
    TemplateDir = Left(Template, StartPos)
    InFile = Right(Template, (Len(Template) - StartPos))
    OutFile = Left(InFile, (InStr(1, InFile, ".") - 1)) & ".htm"
        
    'Read the input file
    Buffer = ""
    AddDetailLog ("Opening template")
    Open Template For Input As #1
    AddDetailLog ("Reading template into memory")
    Do While Not EOF(1)
        Line Input #1, TmpBuf
        Buffer = Buffer & TmpBuf
    Loop
    AddDetailLog ("Closing template")
    Close #1
    
    'Look for the TARGET_DIR meta-tag
    AddDetailLog ("Finding TARGET_DIR meta-tag")
    StartPos = InStr(1, Buffer, "<meta name=""TARGET_DIR""")
    If StartPos = 0 Then
        AddDetailLog ("TARGET_DIR is not defined")
        OutDir = TemplateDir
        AddDetailLog ("TARGET_DIR default is " & OutDir)
    Else
        'Extract target directory name
        EndPos = InStr(StartPos, Buffer, ">")
        OutDir = Mid(Buffer, (StartPos + 33), (EndPos - StartPos - 34))
   
        'Ensure we have a trailing "\"
        If (Right(OutDir, 1)) <> "\" Then OutDir = OutDir & "\"
   
        'Log it
        AddDetailLog ("TARGET_DIR=" & OutDir)
    
        'Remove TARGET_DIR meta-tag from output
        TmpBuf = ""
        If (StartPos > 1) Then TmpBuf = Left(Buffer, (StartPos - 1))
        If (EndPos < Len(Buffer)) Then TmpBuf = TmpBuf & Right(Buffer, (Len(Buffer) - EndPos))
        Buffer = TmpBuf
    End If
    
    'Look for the TARGET meta-tag
    AddDetailLog ("Finding TARGET meta-tag")
    StartPos = InStr(1, Buffer, "<meta name=""TARGET""")
    If StartPos = 0 Then
        AddDetailLog ("TARGET is not defined")
        AddDetailLog ("TARGET default is " & OutDir & OutFile)
    Else
        'Extract target file name
        EndPos = InStr(StartPos, Buffer, ">")
        OutFile = Mid(Buffer, (StartPos + 29), (EndPos - StartPos - 30))
   
         'Log it
         AddDetailLog ("TARGET=" & OutDir & OutFile)
    
        'Remove TARGET meta-tag from output
        TmpBuf = ""
        If (StartPos > 1) Then TmpBuf = Left(Buffer, (StartPos - 1))
        If (EndPos < Len(Buffer)) Then TmpBuf = TmpBuf & Right(Buffer, (Len(Buffer) - EndPos))
        Buffer = TmpBuf
    End If
    
    'Look for the TARGET2 meta-tag
    AddDetailLog ("Finding TARGET2 meta-tag")
    StartPos = InStr(1, Buffer, "<meta name=""TARGET2""")
    If StartPos = 0 Then
        AddDetailLog ("TARGET2 is not defined")
    Else
        'Extract target file name
        EndPos = InStr(StartPos, Buffer, ">")
        OutFile2 = Mid(Buffer, (StartPos + 30), (EndPos - StartPos - 31))
    
        'Log it
        AddDetailLog ("TARGET2=" & OutDir & OutFile2)
    
        'Remove TARGET2 meta-tag from output
        TmpBuf = ""
        If (StartPos > 1) Then TmpBuf = Left(Buffer, (StartPos - 1))
        If (EndPos < Len(Buffer)) Then TmpBuf = TmpBuf & Right(Buffer, (Len(Buffer) - EndPos))
        Buffer = TmpBuf
    End If
    
    'Look for the DATASOURCE meta-tag
    AddDetailLog ("Finding DATASOURCE meta-tag")
    StartPos = InStr(1, Buffer, "<meta name=""DATASOURCE""")
    If StartPos = 0 Then
        AddDetailLog ("DATASOURCE is not defined")
    Else
        'Extract spreadsheet file name
        EndPos = InStr(StartPos, Buffer, ">")
        SheetName = Mid(Buffer, (StartPos + 33), (EndPos - StartPos - 34))
    
        'Check to see if SeetName includes a path, if not then add the path
        'of the project file
        If InStr(1, SheetName, "\") = 0 Then SheetName = TemplateDir & SheetName
        
        AddDetailLog ("DATASOURCE=" & SheetName)
    
        'Make sure the spreadsheet file is present
        If Dir(SheetName) = "" Then Error 3002
        
        'Remove DATASOURCE meta-tag from output
        TmpBuf = ""
        If (StartPos > 1) Then TmpBuf = Left(Buffer, (StartPos - 1))
        If (EndPos < Len(Buffer)) Then TmpBuf = TmpBuf & Right(Buffer, (Len(Buffer) - EndPos))
        Buffer = TmpBuf
    End If

    'Look for the FTP_URL meta-tag
    AddDetailLog ("Finding FTP_URL meta-tag")
    StartPos = InStr(1, Buffer, "<meta name=""FTP_URL""")
    
    If StartPos = 0 Then
        AddDetailLog ("FTP_URL is not defined")
    Else
        EndPos = InStr(StartPos, Buffer, ">")
        FtpUrl = Mid(Buffer, (StartPos + 30), (EndPos - StartPos - 31))
        AddDetailLog ("FTP_URL=" & FtpUrl)

        'Remove FTP_URL meta-tag from output
        TmpBuf = ""
        If (StartPos > 1) Then TmpBuf = Left(Buffer, (StartPos - 1))
        If (EndPos < Len(Buffer)) Then TmpBuf = TmpBuf & Right(Buffer, (Len(Buffer) - EndPos))
        Buffer = TmpBuf
    End If

    'Look for the FTP_DIR meta-tag
    AddDetailLog ("Finding FTP_DIR meta-tag")
    StartPos = InStr(1, Buffer, "<meta name=""FTP_DIR""")
    
    If StartPos = 0 Then
        AddDetailLog ("FTP_DIR is not defined")
    Else
        EndPos = InStr(StartPos, Buffer, ">")
        FtpDir = Mid(Buffer, (StartPos + 30), (EndPos - StartPos - 31))
        AddDetailLog ("FTP_DIR=" & FtpDir)

        'Remove FTP_DIR meta-tag from output
        TmpBuf = ""
        If (StartPos > 1) Then TmpBuf = Left(Buffer, (StartPos - 1))
        If (EndPos < Len(Buffer)) Then TmpBuf = TmpBuf & Right(Buffer, (Len(Buffer) - EndPos))
        Buffer = TmpBuf
    End If

    'Look for the FTP_USERNAME meta-tag
    AddDetailLog ("Finding FTP_USERNAME meta-tag")
    StartPos = InStr(1, Buffer, "<meta name=""FTP_USERNAME""")
    
    If StartPos = 0 Then
        AddDetailLog ("FTP_USERNAME is not defined")
    Else
        EndPos = InStr(StartPos, Buffer, ">")
        FtpUsername = Mid(Buffer, (StartPos + 35), (EndPos - StartPos - 36))
        AddDetailLog ("FTP_USERNAME=" & FtpUsername)
    
        'Remove FTP_URL meta-tag from output
        TmpBuf = ""
        If (StartPos > 1) Then TmpBuf = Left(Buffer, (StartPos - 1))
        If (EndPos < Len(Buffer)) Then TmpBuf = TmpBuf & Right(Buffer, (Len(Buffer) - EndPos))
        Buffer = TmpBuf
    End If

    'Look for the FTP_PASSWORD meta-tag
    AddDetailLog ("Finding FTP_PASSWORD meta-tag")
    StartPos = InStr(1, Buffer, "<meta name=""FTP_PASSWORD""")
    
    If StartPos = 0 Then
        AddDetailLog ("FTP_PASSWORD is not defined")
    Else
        EndPos = InStr(StartPos, Buffer, ">")
        FtpPassword = Mid(Buffer, (StartPos + 35), (EndPos - StartPos - 36))
        AddDetailLog ("FTP_PASSWORD=" & FtpPassword)
    
        'Remove FTP_URL meta-tag from output
        TmpBuf = ""
        If (StartPos > 1) Then TmpBuf = Left(Buffer, (StartPos - 1))
        If (EndPos < Len(Buffer)) Then TmpBuf = TmpBuf & Right(Buffer, (Len(Buffer) - EndPos))
        Buffer = TmpBuf
    End If

    'Open the spreadsheet in read-only mode
    If SheetName <> "" Then
                        
        AddDetailLog ("Activating Microsoft Excel")
        Set Excel = CreateObject("Excel.Application")
        ExcelActive = True
        AddDetailLog ("Microsoft Excel activated")
        
        AddDetailLog ("Opening spreadsheet")
        Excel.Workbooks.Open SheetName, 0, True
        SheetOpen = True
        AddDetailLog ("Spreadsheet is open")

    End If

    'Replace marquee tags with marquees
    AddDetailLog ("Searching for marquee replacement tags")
    TmpBuf = ""
    StartPos = 1
    Do
        'Loog for an opening ~~~
        CellData = ""
        StartPos = InStr(StartPos, Buffer, "~~~")
        If StartPos Then
        
            'Look for a matching closing ~
            EndPos = InStr(StartPos + 3, Buffer, "~")
            If EndPos = 0 Then Error 3000
        
            If SheetName <> "" Then
                'Extract cell reference
                CellRef = Mid(Buffer, (StartPos + 3), (EndPos - StartPos - 3))
            
                'Get data from Excel
                CellData = Excel.Workbooks(1).Worksheets(1).Range(CellRef).Text
                
                'Make sure that che cell data does not contain a ~ character
                If InStr(CellData, "~") <> 0 Then Error 3001
                
                'Build a new buffer with the data inserted
                AddDetailLog ("Replacing " & CellRef & " with marquee " & CellData)
            End If
            
            If (StartPos > 1) Then
                TmpBuf = Left(Buffer, (StartPos - 1))
            End If
            
            If CellData <> "" Then
                'Add the marquee code
                TmpBuf = TmpBuf & "<marquee border=1 behavior=slide>" & CellData & "</marquee>"
            End If

            If ((EndPos) < Len(Buffer)) Then
                TmpBuf = TmpBuf & Right(Buffer, (Len(Buffer) - EndPos))
            End If

            'Update the work buffer ready for next iteration
            Buffer = TmpBuf

        Else
            'No more replacement tags found in string, move on!
            Exit Do
        End If
    
    Loop
    AddDetailLog ("Finished searching for image replacement tags")


    'Replace image tags with image names
    AddDetailLog ("Searching for image replacement tags")
    TmpBuf = ""
    StartPos = 1
    Do
        'Loog for an opening ~~
        CellData = ""
        StartPos = InStr(StartPos, Buffer, "~~")
        If StartPos Then
        
            'Look for a matching closing ~
            EndPos = InStr(StartPos + 2, Buffer, "~")
            If EndPos = 0 Then Error 3000
        
            If SheetName <> "" Then
                'Extract cell reference
                CellRef = Mid(Buffer, (StartPos + 2), (EndPos - StartPos - 2))
            
                'Get data from Excel
                CellData = Excel.Workbooks(1).Worksheets(1).Range(CellRef).Text
                
                'Make sure that che cell data does not contain a ~ character
                If InStr(CellData, "~") <> 0 Then Error 3001
                
                'Build a new buffer with the data inserted
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            End If
            
            If (StartPos > 1) Then
                TmpBuf = Left(Buffer, (StartPos - 1))
            End If
            
            If CellData <> "" Then
                TmpBuf = TmpBuf & "<img src=" & CellData & ">"
            End If

            If ((EndPos) < Len(Buffer)) Then
                TmpBuf = TmpBuf & Right(Buffer, (Len(Buffer) - EndPos))
            End If

            'Update the work buffer ready for next iteration
            Buffer = TmpBuf

        Else
            'No more replacement tags found in string, move on!
            Exit Do
        End If
    
    Loop
    AddDetailLog ("Finished searching for image replacement tags")

    'Replace text tags with keywords
    AddDetailLog ("Searching for text & date replacement tags")
    TmpBuf = ""
    StartPos = 1
    Do
        'Look for an opening ~
        CellData = ""
        StartPos = InStr(StartPos, Buffer, "~")
        If StartPos Then
        
            'Look for a matching closing ~
            EndPos = InStr(StartPos + 1, Buffer, "~")
            If EndPos = 0 Then Error 3000
        
            'Extract the Excel cell reference
            CellRef = Mid(Buffer, (StartPos + 1), (EndPos - StartPos - 1))
        
            Select Case CellRef
            Case "GENERALDATE":
                CellData = CStr(FormatDateTime(Now, vbGeneralDate))
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "SHORTDATE":
                CellData = CStr(FormatDateTime(Now, vbShortDate))
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "LONGDATE":
                CellData = CStr(FormatDateTime(Now, vbLongDate))
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "SHORTTIME":
                CellData = CStr(FormatDateTime(Now, vbShortTime))
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "LONGTIME":
                CellData = CStr(FormatDateTime(Now, vbLongTime))
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "WEEKDAY":
                CellData = WeekdayName(Weekday(Now, vbSunday), False, vbSunday)
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "SHORTWEEKDAY":
                CellData = WeekdayName(Weekday(Now, vbSunday), True, vbSunday)
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "DAY":
                CellData = CStr(Day(Now))
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "MONTH":
                CellData = CStr(Month(Now))
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "MONTHNAME":
                CellData = MonthName(Month(Now), False)
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "SHORTMONTHNAME":
                CellData = MonthName(Month(Now), True)
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "YEAR":
                CellData = CStr(Year(Now))
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "HOUR"
                CellData = CStr(Hour(Now))
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "MINUTE"
                CellData = CStr(Minute(Now))
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case "SECOND"
                CellData = CStr(Second(Now))
                AddDetailLog ("Replacing " & CellRef & " with " & CellData)
            Case Else
                
                'Get the data from that cell in Excel
                If SheetName <> "" Then
                    
                    CellData = Excel.Workbooks(1).Worksheets(1).Range(CellRef).Text
                    If CellData <> "" Then
                        
                        'Make sure that che cell data does not contain a ~ character
                        If InStr(CellData, "~") <> 0 Then
                            'The data we just read from the Excel Cell contains a ~
                            'which is going to screw up future replacements.
                            Error 3001
                        End If
                        
                        AddDetailLog ("Replacing " & CellRef & " with " & CellData)
                    
                    Else
                        
                        AddDetailLog ("Replacing " & CellRef & " with <*** EMPTY CELL ***>")
                    
                    End If
                End If
            End Select

            'Build a new buffer with the tag removed and the data inserted
            If (StartPos > 1) Then
                TmpBuf = Left(Buffer, (StartPos - 1))
            End If
            TmpBuf = TmpBuf & CellData
            If ((EndPos) < Len(Buffer)) Then
                TmpBuf = TmpBuf & Right(Buffer, (Len(Buffer) - EndPos))
            End If

            'Update the work buffer ready for next iteration
            Buffer = TmpBuf

        Else
            'No more replacement tags found in string, move on!
            Exit Do
        End If
    
    Loop
    AddDetailLog ("Finished searching for text & date replacement tags")
    
    'Close the spreadsheet
    If SheetOpen = True Then
        AddDetailLog ("Closing spreadsheet")
        Excel.Workbooks(1).Close SaveChanges:=False
        SheetOpen = False
        AddDetailLog ("Spreadsheet is closed")
    End If
        
    If ExcelActive = True Then
        AddDetailLog ("Closing Micosoft Excel")
        Excel.Quit
        Set Excel = Nothing
        ExcelActive = False
        AddDetailLog ("Micosoft Excel is closed")
    End If
    
    If EvalExpired = True Then

        AddLog ("*** EVAL EXPIRED - HTML WILL NOT BE SAVED! ***")

    Else
    
        'Write the output file
        AddLog ("Creating HTML file " & OutDir & OutFile)
        
        Open OutDir & OutFile For Output As #1
        Print #1, Buffer
        Close #1
        
        'Add generated page to results list box
        With frmGenerate.Results
            .AddItem (OutDir & OutFile)
            .Selected(.ListCount - 1) = True
        End With
        FileWritten = True
        
        'If present, add the FTP target details for this file to
        'the Ftp arrays.

        If FtpUrl <> "" Then
            FtpUrlArray(frmGenerate.Results.ListCount) = FtpUrl
            FtpDirArray(frmGenerate.Results.ListCount) = FtpDir
            FtpTargetFileArray(frmGenerate.Results.ListCount) = OutFile
            FtpUsernameArray(frmGenerate.Results.ListCount) = FtpUsername
            FtpPasswordArray(frmGenerate.Results.ListCount) = FtpPassword
        End If
        
        'Write the second output file (if required)
        If OutFile2 <> "" Then
        
            AddLog ("Creating HTML file " & OutDir & OutFile2)
            
            Open OutDir & OutFile2 For Output As #1
            Print #1, Buffer
            Close #1
            
            'Add page to results list box
            With frmGenerate.Results
                .AddItem (OutDir & OutFile2)
                .Selected(.ListCount - 1) = True
            End With
            
            'If present, add the FTP target details for this file to
            'the Ftp arrays.
    
            If FtpUrl <> "" Then
                FtpUrlArray(frmGenerate.Results.ListCount) = FtpUrl
                FtpDirArray(frmGenerate.Results.ListCount) = FtpDir
                FtpTargetFileArray(frmGenerate.Results.ListCount) = OutFile2
                FtpUsernameArray(frmGenerate.Results.ListCount) = FtpUsername
                FtpPasswordArray(frmGenerate.Results.ListCount) = FtpPassword
            End If
        
        End If
        
    End If
    
    AddDetailLog ("Finished processing " & Template)
    AddLog ("------------------------------------------------------------------------------------------------------------------")
    fMain.sbStatusBar.Panels(1).Text = fProperties.txtDescription.Text

    Exit Function

ErrorHandler:

    Message = ""

    Select Case Err.Number
    Case 53:
        Message = "ERROR: Input file not found."
    Case 1004:
        'This error is generated by Excel if I attempt to reference a
        'garbage cell reference.  This can occur if there is an erroneous ~
        'character in the body of the document, not surrounding a WebGen Tag.
        Message = "ERROR: Bad cell reference. Check for misspelled tags or spurious ~ characters."
    Case 3000:
        Message = "ERROR: End of tag not found in record."
    Case 3001:
        Message = "ERROR: Cell " & CellRef & " contains illegal ~ character(s)."
    Case 3002:
        Message = "ERROR: Spreadsheet file not found"
    Case Else
        Message = "ERROR " & CStr(Err.Number) & " (" & Err.Description & ")"
    End Select
    
    AddLog (Message)
    MsgBox Message, vbOKOnly + vbCritical, "Error"

    If SheetOpen = True Then
        AddDetailLog ("Closing spreadsheet")
        Excel.Workbooks(1).Close SaveChanges:=False
        SheetOpen = False
    End If
    
    If ExcelActive = True Then
        AddDetailLog ("Terminating Micosoft Excel")
        Excel.Quit
        Set Excel = Nothing
        ExcelActive = False
    End If
    
    'Close all files
    Close
    
    'Delete the output file
    If (FileWritten = True) Then
        
        Kill OutDir & OutFile
        AddLog ("Deleting output file " & OutDir & OutFile)
    
        'Remove generated page to results list box
        frmGenerate.Results.RemoveItem (frmGenerate.Results.NewIndex)
    
    End If

    fMain.sbStatusBar.Panels(1).Text = fProperties.txtDescription.Text
    
    ParseTemplate = False
    
    AddLog ("------------------------------------------------------------------------------------------------------------------")
    
    Exit Function

End Function

Public Sub SetupUI(ByVal PrjStatus As Boolean)

    'Called with PrjStatus = True to setup the UI for an open project
    'or PrjStatus = False to setup for no open project.

    With fMain
        
        If PrjStatus = True Then
            .Caption = "Web Generator [" & ProjectFile & "]"
            .sbStatusBar.Panels(1).Text = fProperties.txtDescription.Text
        Else
            .Caption = "Web Generator"
            .sbStatusBar.Panels(1).Text = ""
        End If
        
        .mnuFileSave.Enabled = PrjStatus
        .mnuFileSaveAs.Enabled = PrjStatus
        .mnuFileClose.Enabled = PrjStatus
        .mnuFileDelete.Enabled = PrjStatus
        .mnuProjectProperties.Enabled = PrjStatus
        .mnuProjectGenerate.Enabled = PrjStatus
        
        .tbToolBar.Buttons("Save").Enabled = PrjStatus
        .tbToolBar.Buttons("Delete").Enabled = PrjStatus
        .tbToolBar.Buttons("Properties").Enabled = PrjStatus
        .tbToolBar.Buttons("Generate").Enabled = PrjStatus

    End With

End Sub
