VERSION 5.00
Object = "{48E59290-9880-11CF-9754-00AA00C00908}#1.0#0"; "MSINET.OCX"
Object = "{5E9E78A0-531B-11CF-91F6-C2863C385E30}#1.0#0"; "MSFLXGRD.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form frmMain 
   ClientHeight    =   5955
   ClientLeft      =   165
   ClientTop       =   450
   ClientWidth     =   8565
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   5955
   ScaleWidth      =   8565
   WindowState     =   2  'Maximized
   Begin VB.CommandButton bNew 
      Caption         =   "&New"
      Height          =   375
      Left            =   7320
      TabIndex        =   6
      Top             =   600
      Width           =   1095
   End
   Begin VB.CommandButton bProperties 
      Caption         =   "&Properties"
      Height          =   375
      Left            =   7320
      TabIndex        =   5
      Top             =   2160
      Width           =   1095
   End
   Begin VB.CommandButton bOpen 
      Caption         =   "&Open"
      Default         =   -1  'True
      Height          =   375
      Left            =   7320
      TabIndex        =   4
      Top             =   120
      Width           =   1095
   End
   Begin MSComDlg.CommonDialog CommonDialog 
      Left            =   7800
      Top             =   5160
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton bLog 
      Caption         =   "Show &Log"
      Height          =   375
      Left            =   7320
      TabIndex        =   3
      Top             =   2880
      Width           =   1095
   End
   Begin MSFlexGridLib.MSFlexGrid Log 
      Height          =   2055
      Left            =   240
      TabIndex        =   2
      Top             =   3720
      Visible         =   0   'False
      Width           =   6975
      _ExtentX        =   12303
      _ExtentY        =   3625
      _Version        =   393216
      Rows            =   25
      Cols            =   1
      FixedRows       =   0
      FixedCols       =   0
      ScrollTrack     =   -1  'True
      HighLight       =   0
      GridLines       =   0
      AllowUserResizing=   1
   End
   Begin VB.CommandButton bGrabIt 
      Caption         =   "&Go"
      Height          =   375
      Left            =   7320
      TabIndex        =   0
      Top             =   1680
      Width           =   1095
   End
   Begin MSFlexGridLib.MSFlexGrid Grid 
      Height          =   3375
      Left            =   120
      TabIndex        =   1
      Top             =   120
      Width           =   7095
      _ExtentX        =   12515
      _ExtentY        =   5953
      _Version        =   393216
      Rows            =   50
      FixedCols       =   0
      AllowBigSelection=   0   'False
      ScrollTrack     =   -1  'True
      FocusRect       =   0
      ScrollBars      =   2
      SelectionMode   =   1
      AllowUserResizing=   1
   End
   Begin InetCtlsObjects.Inet Inet1 
      Left            =   7800
      Top             =   4320
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim HtmlBuffer, Buffer, TmpBuf, Description, Url, LastUrl, StartTag, EndTag As String
Dim SheetName, SheetCell, LastSheet As String
Dim StartPos, EndPos, Length As Long
Dim StartTagInclude, EndTagInclude, Timeout As Integer
Dim InProgress, ShowLog, GroupHeading As Boolean
Dim ResultCount As Integer
Dim LogCount As Integer
Dim ExcelActive, SheetOpen As Boolean
Public LogViewer As frmLogView

Dim Excel As Excel.Application

Private Sub Form_Load()

    Caption = App.ProductName

    'Start Excel
    AddLog "Activating Excel"
    Set Excel = CreateObject("Excel.Application")
    ExcelActive = True

    Set LogViewer = New frmLogView
   
    Top = Screen.Height * 0.1
    Left = Screen.Width * 0.1
    Width = Screen.Width * 0.8
    Height = Screen.Height * 0.8

    ShowLog = False

    With Grid
        .ColWidth(0) = .Width / 2
        .ColWidth(1) = .Width / 2
        .Row = 0
        .Col = 0
        .Text = "Description"
        .Col = 1
        .Text = "Data"
    End With

    bGrabIt.Enabled = False
    bProperties.Enabled = False
    Grid.Enabled = False
    Log.Enabled = False

End Sub

Private Sub Form_Resize()

    If frmMain.WindowState <> vbMinimized Then

        With bOpen
            .Top = 50
            .Left = frmMain.Width - bOpen.Width - 200
        End With
    
        With bNew
            .Top = bOpen.Top + bOpen.Height + 50
            .Left = bOpen.Left
        End With
    
        With bGrabIt
            .Top = bNew.Top + bNew.Height + 150
            .Left = bNew.Left
        End With
        
        With bProperties
            .Top = bGrabIt.Top + bGrabIt.Height + 50
            .Left = bGrabIt.Left
        End With
    
        With bLog
            .Top = bProperties.Top + bProperties.Height + 150
            .Left = bProperties.Left
        End With
    
        With Grid
            
            .Top = 50
            .Left = 50
            .Width = bGrabIt.Left - 150
            .ColWidth(1) = .Width - .ColWidth(0)
            
            If ShowLog = True Then
                
                .Height = (frmMain.Height - 200) / 2
            
                With Log
                    .Top = Grid.Top + Grid.Height + 50
                    .Left = Grid.Left
                    .Width = Grid.Width
                    .Height = frmMain.Height - .Top - 450
                    .ColWidth(0) = .Width * 30
                End With
            
                Log.Visible = True
            
            Else
                
                .Height = (frmMain.Height - 500)
                Log.Visible = False
            
            End If
    
        End With
    
    End If

End Sub

Private Sub Form_Unload(Cancel As Integer)

    'Stop Excel
    AddLog "Terminating Excel"
    Excel.Quit
    Set Excel = Nothing
    ExcelActive = False

End Sub

Private Sub bNew_Click()

    With CommonDialog
        
        .FileName = ""
        .DialogTitle = "New Project"
        .CancelError = False
        .Flags = &H2004&    'This should cause the common dialog to prevent
                            'the selection of an existing file, but it doesn't
                            'seem to work!!!
        .Filter = "Project Files (*.gpj)|*.gpj"
        
        .ShowOpen
        
        If Len(.FileName) <> 0 Then
            ProjectFile = .FileName
            frmMain.Caption = App.ProductName & " [" & .FileName & "]"
            frmMain.bOpen.Caption = "&Close"
            frmMain.bNew.Enabled = False
            frmMain.bGrabIt.Enabled = True
            frmMain.bProperties.Enabled = True
            Grid.Enabled = True
            Log.Enabled = True
        End If
    
    End With

End Sub

Private Sub bOpen_Click()

    If ProjectFile = "" Then

        With CommonDialog
            
            .FileName = ""
            .DialogTitle = "Open Project"
            .CancelError = False
            .Flags = &H1004&
            .Filter = "Project Files (*.gpj)|*.gpj"
            
            .ShowOpen
            
            If Len(.FileName) <> 0 Then
                ProjectFile = .FileName
                frmMain.Caption = App.ProductName & " [" & .FileName & "]"
                frmMain.bOpen.Caption = "&Close"
                frmMain.bNew.Enabled = False
                frmMain.bGrabIt.Enabled = True
                frmMain.bProperties.Enabled = True
                Grid.Enabled = True
                Log.Enabled = True
            End If
        
        
        End With

    Else
        
        ResetUI
    
        ProjectFile = ""
        frmMain.Caption = App.ProductName
        frmMain.bOpen.Caption = "&Open"
        frmMain.bNew.Enabled = True
        frmMain.bGrabIt.Enabled = False
        frmMain.bProperties.Enabled = False
        Grid.Enabled = False
        Log.Enabled = False
    
    End If

End Sub

Private Sub bGrabIt_Click()
    
    ResetUI
    
    Open ProjectFile For Input As #1
    
    Do While Not EOF(1)
        
        Line Input #1, Buffer
        
        'Check to see if we got to the end of the current section, and
        'if so, process it.

        If Left(Buffer, 1) = "[" Then
        
            If InProgress = True Then
                
                GrabData
                
                Description = ""
                Url = ""
                StartTag = ""
                EndTag = ""
                StartTagInclude = 0
                EndTagInclude = 0
                SheetName = ""
                SheetCell = ""
                InProgress = False
                GroupHeading = False
    
            End If
        
            StartPos = 2
            EndPos = InStr(StartPos, Buffer, "]")
            Length = EndPos - StartPos
            Description = Mid(Buffer, StartPos, Length)
            AddLog Description, True
            InProgress = True
        
        End If
                
        If Left(Buffer, 13) = "GROUP_HEADING" Then
            GroupHeading = True
        End If
        
        If Left(Buffer, 4) = "URL=" Then
            StartPos = 5
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            Url = Mid(Buffer, StartPos, Length)
            AddLog "URL=" & Url
        End If
        
        If Left(Buffer, 10) = "START_TAG=" Then
            StartPos = 11
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            StartTag = Mid(Buffer, StartPos, Length)
            AddLog "Start tag=" & StartTag
        End If
        
        If Left(Buffer, 8) = "END_TAG=" Then
            StartPos = 9
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            EndTag = Mid(Buffer, StartPos, Length)
            AddLog "End tag=" & EndTag
        End If
        
        If Left(Buffer, 14) = "START_INCLUDE=" Then
            StartPos = 15
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            StartTagInclude = CInt(Mid(Buffer, StartPos, Length))
            If StartTagInclude = 0 Then
                AddLog "Don't include start tag in data"
            Else
                AddLog "Include last " & CStr(StartTagInclude) & " character(s) of start tag in data"
            End If
        End If
        
        If Left(Buffer, 12) = "END_INCLUDE=" Then
            StartPos = 13
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            EndTagInclude = CInt(Mid(Buffer, StartPos, Length))
            If EndTagInclude = 0 Then
                AddLog "Don't include end tag in data"
            Else
                AddLog "Include first " & CStr(EndTagInclude) & " character(s) of end tag in data"
            End If
        End If
        
        If Left(Buffer, 8) = "TIMEOUT=" Then
            StartPos = 9
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            Timeout = CInt(Mid(Buffer, StartPos, Length))
            AddLog "Timeout after " & CStr(Timeout) & " second(s)"
        End If
        
        If Left(Buffer, 17) = "SPREADSHEET_NAME=" Then
            StartPos = 18
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            SheetName = Mid(Buffer, StartPos, Length)
            AddLog "Spreadsheet name = " & SheetName
        End If
        
        If Left(Buffer, 17) = "SPREADSHEET_CELL=" Then
            StartPos = 18
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            SheetCell = Mid(Buffer, StartPos, Length)
            AddLog "Spreadsheet cell = " & SheetCell
        End If
        
    Loop
    
    'We hit end of file.  If we were reading an entry then process it
    
    If InProgress = True Then
        
        GrabData
        
        Description = ""
        Url = ""
        StartTag = ""
        EndTag = ""
        StartTagInclude = 0
        EndTagInclude = 0
        SheetName = ""
        SheetCell = ""
        InProgress = False
        GroupHeading = False
    
    
    End If
    
    'Af there is a worksheet open then save and close it
    If SheetOpen = True Then
        AddLog "Closing spreadsheet"
        Excel.Workbooks(1).Save
        Excel.Workbooks(1).Close
        SheetOpen = False
    End If
    
    Close #1
    
End Sub

Private Sub GrabData()
    
    Dim Result As String

    On Error GoTo ErrorHandler
        
    frmMain.MousePointer = vbHourglass
        
    If SheetName <> "" Then
        
        If SheetName = LastSheet Then
            
            AddLog "Spreadsheet matches previous spreadsheet"
        
        Else
            
            'Close any previously open worksheet
            If SheetOpen = True Then
                AddLog "Closing spreadsheet"
                Excel.Workbooks(1).Save
                Excel.Workbooks(1).Close
                SheetOpen = False
            End If
            
            'Open worksheet
            AddLog "Opening spreadsheet"
            Excel.Workbooks.Open SheetName, 0
            SheetOpen = True
        
            LastSheet = SheetName

        End If
    End If

    If Url = LastUrl Then
        AddLog "URL matches previous URL, no download necessary"
    Else

        'If attempt download
        AddLog "Attempting download"
        With Inet1
            .Protocol = icHTTP
            .Url = Url
            .RequestTimeout = Timeout
        End With
        
        HtmlBuffer = Inet1.OpenURL(ByVal (Url))
        
        If HtmlBuffer = "" Then Error 3000
        
        LastUrl = Url
        AddLog "Downloaded data = " & HtmlBuffer
        
        'Replace <CR> and <LF> characters in the HTML buffer
        Do
            StartPos = InStr(1, HtmlBuffer, Chr(13))
            If StartPos = 0 Then
                Exit Do
            Else
                If StartPos > 1 Then TmpBuf = Left(HtmlBuffer, StartPos - 1)
                TmpBuf = TmpBuf & "<CR>"
                If StartPos < Len(HtmlBuffer) Then TmpBuf = TmpBuf + Right(HtmlBuffer, (Len(HtmlBuffer) - StartPos))
                HtmlBuffer = TmpBuf
            End If
        Loop
        Do
            StartPos = InStr(1, HtmlBuffer, Chr(10))
            If StartPos = 0 Then
                Exit Do
            Else
                If StartPos > 1 Then TmpBuf = Left(HtmlBuffer, StartPos - 1)
                TmpBuf = TmpBuf & "<LF>"
                If StartPos < Len(HtmlBuffer) Then TmpBuf = TmpBuf + Right(HtmlBuffer, (Len(HtmlBuffer) - StartPos))
                HtmlBuffer = TmpBuf
            End If
        Loop
        
        AddLog "Transformed data = " & HtmlBuffer
        
    End If

    frmMain.MousePointer = vbDefault
    
    AddLog "Scanning for start tag"
    StartPos = InStr(HtmlBuffer, StartTag)

    If StartPos = 0 Then
        Error 3001
    Else
        
        AddLog "Found start tag"
        
        'Look for end tag AFTER start tag
        AddLog "Scanning for end tag"
        EndPos = InStr((StartPos + Len(StartTag)), HtmlBuffer, EndTag)
    
        If EndPos = 0 Then
            Error 3002
        Else
        
            AddLog "Found end tag"
            
            'Exclude the invalid characters of start tag
            If StartTagInclude < Len(StartTag) Then
                StartPos = StartPos + (Len(StartTag) - StartTagInclude)
            End If
        
            'Possibly include valid characters of end tag
            EndPos = EndPos + EndTagInclude
        
            'Calculate the number of characters remaining
            Length = EndPos - StartPos
            
            'Extract the data we're interested in
            Result = Mid(HtmlBuffer, StartPos, Length)
            
            'Replace "&nbsp;" with " "
            Do
                StartPos = InStr(1, Result, "&nbsp;")
                If StartPos = 0 Then
                    Exit Do
                Else
                    If StartPos > 1 Then TmpBuf = Left(Result, StartPos - 1)
                    TmpBuf = TmpBuf & " "
                    If StartPos + 5 < Len(Result) Then TmpBuf = TmpBuf + Right(Result, (Len(Result) - StartPos - 5))
                    Result = TmpBuf
                End If
            Loop

            'Replace "<BR>" with " "
            Do
                StartPos = InStr(1, Result, "<BR>")
                If StartPos = 0 Then
                    Exit Do
                Else
                    If StartPos > 1 Then TmpBuf = Left(Result, StartPos - 1)
                    TmpBuf = TmpBuf & " "
                    If StartPos + 3 < Len(Result) Then TmpBuf = TmpBuf + Right(Result, (Len(Result) - StartPos - 3))
                    Result = TmpBuf
                End If
            Loop

            'Replace "<CR>" with ""
            Do
                StartPos = InStr(1, Result, "<CR>")
                If StartPos = 0 Then
                    Exit Do
                Else
                    If StartPos > 1 Then TmpBuf = Left(Result, StartPos - 1)
                    If StartPos < Len(Result) Then TmpBuf = TmpBuf + Right(Result, (Len(Result) - StartPos - 3))
                    Result = TmpBuf
                End If
            Loop
            
            'Replace "<LF>" with ""
            Do
                StartPos = InStr(1, Result, "<LF>")
                If StartPos = 0 Then
                    Exit Do
                Else
                    If StartPos > 1 Then TmpBuf = Left(Result, StartPos - 1)
                    If StartPos < Len(Result) Then TmpBuf = TmpBuf + Right(Result, (Len(Result) - StartPos - 3))
                    Result = TmpBuf
                End If
            Loop
            
            'Remove leading spaces
            Do
                If Left(Result, 1) = " " Then
                    Result = Right(Result, Len(Result) - 1)
                Else
                    Exit Do
                End If
            Loop
            
            'Remove trailing spaces
            Do
                If Right(Result, 1) = " " Then
                    Result = Left(Result, Len(Result) - 1)
                Else
                    Exit Do
                End If
            Loop
            
            
            'Display the results
            AddLog "DATA=" & Result
            AddResult Description, Result
        
        End If

    End If

    If SheetName <> "" Then
        
        'Record data in target cell
        If Result = "" Then
            AddLog "ERROR: Recording error in cell " & SheetCell, , True
            Result = "~ERROR~"
        Else
            AddLog "Recording data in cell " & SheetCell
        End If
        
        Excel.Workbooks(1).Worksheets(1).Range(SheetCell) = Result
        
    End If

    Exit Sub

ErrorHandler:
    
    frmMain.MousePointer = vbDefault

    Select Case Err.Number
    Case 3000:
        Result = "ERROR: Failed to download page!"
    Case 3001:
        Result = "ERROR: Start tag not found!"
    Case 3002:
        Result = "ERROR: End tag not found!"
    Case 35752:
        Result = "ERROR: Malformed URL!"
    Case 35761:
        Result = "ERROR: Transfer timed out!"
    Case Else
        Result = "ERROR: " & CStr(Err.Number) & " " & Err.Description
    End Select
        
    AddLog Result, , True
    AddResult Description, Result, , True
    
    If SheetName <> "" Then
        
        AddLog "ERROR: Recording error in cell " & SheetCell, , True
        Excel.Workbooks(1).Worksheets(1).Range(SheetCell) = "~ERROR~"
        
    End If
    
End Sub

Private Sub AddLog(ByVal Message As String, Optional Heading As Boolean, Optional Error As Boolean)

    LogCount = LogCount + 1

    If LogCount > Log.Rows Then
        Log.Rows = Log.Rows + 10
    End If

    With Log
        .Row = LogCount - 1
        .Col = 0
        If Not IsMissing(Heading) And Heading = True Then
            .CellBackColor = vbGreen
            .CellFontBold = True
        End If
        If Not IsMissing(Error) And Error = True Then
            .CellFontBold = True
            .CellForeColor = vbRed
            .CellBackColor = vbYellow
        End If
        .Text = Message
    
    End With

End Sub

Private Sub AddResult(ByVal Description As String, ByVal Data As String, Optional Bold As Boolean, Optional Error As Boolean)

    ResultCount = ResultCount + 1

    If ResultCount > Grid.Rows - 1 Then
        Grid.Rows = Grid.Rows + 10
    End If

    With Grid
        .Row = ResultCount
        .Col = 0
        If GroupHeading = True Then
            .CellFontBold = True
            .CellForeColor = vbBlue
        End If
        .Text = Description
        .Col = 1
        .CellAlignment = flexAlignLeftCenter
        If Not IsMissing(Error) And Error = True Then
            .CellFontBold = True
            .CellForeColor = vbRed
            .CellBackColor = vbYellow
        End If
        .Text = Data
    End With

End Sub

Private Sub ResetUI()

    With Grid
        .Clear
        .Row = 0
        .Col = 0
        .Text = "Description"
        .Col = 1
        .Text = "Data"
    End With

    Log.Clear

    ResultCount = 0
    LogCount = 0

End Sub

Private Sub bLog_Click()

    If ShowLog = False Then
        ShowLog = True
        bLog.Caption = "Hide &Log"
    Else
        ShowLog = False
        bLog.Caption = "Show &Log"
    End If

    Form_Resize

End Sub

Private Sub Grid_DblClick()

    Grid.Col = 0
    LogViewer.Caption = Grid.Text
    Grid.Col = 1
    LogViewer.TextBox.Text = Grid.Text
    LogViewer.Show vbModal, Me
    LogViewer.Caption = "Log Viewer"

End Sub

Private Sub Log_DblClick()

    LogViewer.TextBox.Text = Log.Text
    LogViewer.Show vbModal, Me

End Sub

Private Sub bProperties_Click()

    frmProject.Show vbModal, Me

End Sub

