VERSION 5.00
Begin VB.UserControl ExcelSheet 
   ClientHeight    =   3600
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4800
   ScaleHeight     =   3600
   ScaleWidth      =   4800
End
Attribute VB_Name = "ExcelSheet"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit
Dim Excel As Object

Public Function Createbook(ByVal BookTitle As String, ByVal BookSubject As String, ByVal SheetName As String) As Boolean
Attribute Createbook.VB_Description = "Function to Create an Excel Workbook.  Requires a Title,Subject,and a Sheet Name for the First Sheet."

    Createbook = True
    On Error GoTo ErrorTrap
    'Application.WindowState = xlMaximized
    Set Excel = Workbooks.Add
    ActiveWindow.WindowState = xlMaximized
    Excel.Worksheets.Add.Name = (SheetName)
    With Excel
        .Title = (BookTitle)
        .Subject = (BookSubject)
        .Activate
    End With
    Exit Function

ErrorTrap:
    Createbook = False
    Resume Next

End Function
Public Function CreateSheet(ByVal SheetName As String) As Boolean
Attribute CreateSheet.VB_Description = "Function to Create a new Worksheet into the current workbook."

    CreateSheet = True
    
    On Error GoTo ErrorTrap
    
    ActiveWindow.WindowState = xlMaximized
    
    Excel.Worksheets.Add.Name = (SheetName)
    
    'Move the New Sheet to the End of the Workbook
    Excel.Worksheets(SheetName).Move after:=Sheets(Sheets.Count)
    
    Exit Function

ErrorTrap:
    CreateSheet = False
    Resume Next

End Function
Public Function NameSheet(ByVal SheetNo As Integer, ByVal SheetName As String) As Boolean

    'If the Sheet Number given is not valid, a subscript error
    'will be genertated and the program will abort.
    On Error GoTo ErrorTrap
    With Excel.Worksheets(SheetNo)
        .Activate
        .Name = (SheetName)
    End With
    NameSheet = True
    Exit Function

ErrorTrap:
    'Since we Errored Out, we know that the sheet specified didn't
    'exist.  Therefore just add it.
    Excel.Worksheets.Add.Name = (SheetName)
    'Move the New Sheet to the End of the Workbook
    Excel.Worksheets(SheetName).Move after:=Sheets(Sheets.Count)
    Resume Next

End Function

Public Function SaveBook(ByVal FileName As String) As Boolean

    SaveBook = True
    On Error GoTo ErrorTrap
    
    ' Select Sheet 1 so that when you go into Excel
    ' Sheet 1 will be selected.
    Excel.Worksheets(1).Activate
    If Dir$(FileName) <> "" Then
        Kill FileName
    End If

    Excel.SaveAs (FileName)
    
    Exit Function
    
ErrorTrap:
    SaveBook = False
    Resume Next

End Function

Public Function CloseBook() As Boolean

    CloseBook = True
    On Error GoTo ErrorTrap
    Excel.Application.Quit
    Set Excel = Nothing
    
    Exit Function
    
ErrorTrap:
    CloseBook = False
    Resume Next

End Function

Public Function CellContent(ByVal SheetNo As Integer, ByVal Row As Integer, ByVal Col As Integer, ByVal Value As Variant) As Boolean

    CellContent = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(SheetNo).Cells(Row, Col) = Value
    Exit Function
    
ErrorTrap:
    CellContent = False
    Resume Next

End Function

Public Function RangeContent(ByVal SheetNo As Integer, ByVal Range As String, ByVal Value As Variant) As Boolean

    RangeContent = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(SheetNo).Range(Range) = Value
    Exit Function
    
ErrorTrap:
    RangeContent = False
    Resume Next

End Function

Public Function CellFormula(ByVal SheetNo As Integer, ByVal Row As Integer, ByVal Col As Integer, ByVal Formula As Variant) As Boolean

    CellFormula = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(SheetNo).Cells(Row, Col).Formula = Formula

    Exit Function

ErrorTrap:
    CellFormula = False
    Resume Next

End Function

Public Function RangeFormula(ByVal SheetNo As Integer, ByVal Range As String, ByVal Formula As Variant) As Boolean

    RangeFormula = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(SheetNo).Range(Range).Formula = Formula

    Exit Function

ErrorTrap:
    RangeFormula = False
    Resume Next

End Function

Public Function CellBold(ByVal SheetNo As Integer, ByVal Row As Integer, ByVal Col As Integer) As Boolean

    CellBold = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(SheetNo).Cells(Row, Col).Font.Bold = True

    Exit Function

ErrorTrap:
    CellBold = False
    Resume Next

End Function

Public Function RangeBold(ByVal SheetNo As Integer, ByVal Range As String) As Boolean

    RangeBold = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(SheetNo).Range(Range).Font.Bold = True
    
    Exit Function

ErrorTrap:
    RangeBold = False
    Resume Next

End Function

Public Function CellFont(ByVal SheetNo As Integer, ByVal Row As Integer, ByVal Col As Integer, ByVal FontNo As Integer, ByVal FontSize As Integer) As Boolean

    CellFont = True
    If FontNo > 3 Then
        GoTo ErrorTrap
    ElseIf FontNo < 1 Then
        GoTo ErrorTrap
    End If
    
    On Error GoTo ErrorTrap
    
    With Excel.Worksheets(SheetNo).Cells(Row, Col).Font
        
        Select Case FontNo
        Case 1:
            .Name = "Arial"
        Case 2:
            .Name = "Times New Roman"
        Case 3:
            .Name = "Courier"
        End Select
    
        .Size = FontSize

    End With

    Exit Function

ErrorTrap:
    CellFont = False
    Resume Next

End Function

Public Function RangeFont(ByVal SheetNo As Integer, ByVal Range As String, ByVal FontNo As Integer, ByVal FontSize As Integer) As Boolean

    RangeFont = True
    If FontNo > 3 Then
        GoTo ErrorTrap
    ElseIf FontNo < 1 Then
        GoTo ErrorTrap
    End If
    
    On Error GoTo ErrorTrap
    
    With Excel.Worksheets(SheetNo).Range(Range).Font
    
        Select Case FontNo
        Case 1:
            .Name = "Arial"
        Case 2:
            .Name = "Times New Roman"
        Case 3:
            .Name = "Courier"
        End Select
    
        .Size = FontSize
        
    End With

    Exit Function

ErrorTrap:
    RangeFont = False
    Resume Next

End Function

Public Function CellItalic(ByVal SheetNo As Integer, ByVal Row As Integer, ByVal Col As Integer) As Boolean

    CellItalic = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(SheetNo).Cells(Row, Col).Font.Italic = True

    Exit Function

ErrorTrap:
    CellItalic = False
    Resume Next

End Function

Public Function RangeItalic(ByVal SheetNo As Integer, ByVal Range As String) As Boolean

    RangeItalic = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(SheetNo).Range(Range).Font.Italic = True

    Exit Function

ErrorTrap:
    RangeItalic = False
    Resume Next

End Function

Public Function CellAlign(ByVal SheetNo As Integer, ByVal Row As Integer, ByVal Col As Integer, ByVal Alignment As Byte) As Boolean

    CellAlign = True
    
    On Error GoTo ErrorTrap
    
    With Excel.Worksheets(SheetNo).Cells(Row, Col)
    
        Select Case Alignment
        Case 1:
            .HorizontalAlignment = xlHAlignLeft
        Case 2:
            .HorizontalAlignment = xlHAlignRight
        Case 3:
            .HorizontalAlignment = xlHAlignCenter
        End Select
    
    End With
    
    Exit Function

ErrorTrap:
    CellAlign = False
    Resume Next

End Function

Public Function RangeAlign(ByVal SheetNo As Integer, ByVal Range As String, ByVal Alignment As Byte) As Boolean

    RangeAlign = True
    
    On Error GoTo ErrorTrap
    
    With Excel.Worksheets(SheetNo).Range(Range)
    
        Select Case Alignment
        Case 1:
            .HorizontalAlignment = xlHAlignLeft
        Case 2:
            .HorizontalAlignment = xlHAlignRight
        Case 3:
            .HorizontalAlignment = xlHAlignCenter
        End Select
    
    End With
    
    Exit Function

ErrorTrap:
    RangeAlign = False
    Resume Next

End Function

Public Function CellFormat(ByVal SheetNo As Integer, ByVal Row As Integer, ByVal Col As Integer, ByVal Format As String) As Boolean

    CellFormat = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(SheetNo).Cells(Row, Col).NumberFormat = Format

    Exit Function
       
ErrorTrap:
    CellFormat = False
    Resume Next

End Function

Public Function RangeFormat(ByVal SheetNo As Integer, ByVal Range As String, ByVal Format As String) As Boolean

    RangeFormat = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(SheetNo).Range(Range).NumberFormat = Format

    Exit Function
    
ErrorTrap:
    RangeFormat = False
    Resume Next

End Function

Public Function ColumnWidth(ByVal SheetNo As Integer, ByVal Col As Integer, ByVal Width As Single) As Boolean

    ColumnWidth = True
    On Error GoTo ErrorHandler
    Excel.Worksheets(SheetNo).Columns(Col).ColumnWidth = Width
    
    Exit Function
    
ErrorHandler:
    ColumnWidth = False
    Resume Next

End Function

Public Function ColumnRangeWidth(ByVal SheetNo As Integer, ByVal ColRange As String, ByVal Width As Single) As Boolean

    ColumnRangeWidth = True
    On Error GoTo ErrorHandler
    Excel.Worksheets(SheetNo).Columns(ColRange).ColumnWidth = Width
    
    Exit Function
    
ErrorHandler:
    ColumnRangeWidth = False
    Resume Next

End Function

Public Function RangeGrid(ByVal SheetNo As Integer, ByVal Range As String) As Boolean

    '========================================================
    ' Fill the Inside of "Range" with continus Thin Line.
    ' and then draw the outside border with a Thick Line.
    '========================================================
    'Line Style Propertys
    '   xlContinuous
    '   xlDash
    '   xlDashDot
    '   xlDashDotDot
    '   xlDot
    '   xlDouble
    '   xlSlantDashDot
    '   xlLineStyleNone
    '========================================================
    'Weight Properties
    '   xlHariLine
    '   xlThin
    '   xlMedium
    '   xlThick
    '========================================================
    'Borders Property
    '   xlDiagonalDown
    '   xlDiagonalUp
    '   xlEdgeBottom
    '   xlEdgeLeft
    '   xlEdgeRight
    '   xlEdgeTop
    '   xlInsideHorizontal
    '   xlInsideVertical
    '========================================================
    RangeGrid = True
    On Error GoTo ErrorTrap
    
    ' Set Inside Horizontal
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlInsideHorizontal)
        .LineStyle = xlContinuous
        .Weight = xlThin
        .ColorIndex = xlAutomatic
    End With
    
    ' Set Inside Vertical
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlInsideVertical)
        .LineStyle = xlContinuous
        .Weight = xlThin
        .ColorIndex = xlAutomatic
    End With
    
    ' Set Bottom Edge to Heavy
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlEdgeBottom)
        .LineStyle = xlContinuous
        .Weight = xlThick
        .ColorIndex = xlAutomatic
    End With
    
    ' Set Top Edge to Heavy
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlEdgeTop)
        .LineStyle = xlContinuous
        .Weight = xlThick
        .ColorIndex = xlAutomatic
    End With
    
    ' Set Left Edge to Heavy
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlEdgeLeft)
        .LineStyle = xlContinuous
        .Weight = xlThick
        .ColorIndex = xlAutomatic
    End With
    
    ' Set Right Edge to Heavy
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlEdgeRight)
        .LineStyle = xlContinuous
        .Weight = xlThick
        .ColorIndex = xlAutomatic
    End With
    
    'Excel.Worksheets(SheetNo).Range(Range).Borders.Weight = xlThin
    'Excel.Worksheets(SheetNo).Range(Range).Borders.ColorIndex = xlAutomatic
    
    Exit Function

ErrorTrap:
    
    RangeGrid = False
    Resume Next

End Function

Public Function RangeGridOutside(ByVal SheetNo As Integer, ByVal Range As String) As Boolean

    RangeGridOutside = True
    On Error GoTo ErrorTrap
    
    ' Set Bottom Edge to Thick
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlEdgeBottom)
        .LineStyle = xlContinuous
        .Weight = xlThick
        .ColorIndex = xlAutomatic
    End With
    
    ' Set Top Edge to Thick
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlEdgeTop)
        .LineStyle = xlContinuous
        .Weight = xlThick
        .ColorIndex = xlAutomatic
    End With
    
    ' Set Left Edge to Thick
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlEdgeLeft)
        .LineStyle = xlContinuous
        .Weight = xlThick
        .ColorIndex = xlAutomatic
    End With
    
    ' Set Right Edge to Thick
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlEdgeRight)
        .LineStyle = xlContinuous
        .Weight = xlThick
        .ColorIndex = xlAutomatic
    End With
    
    Exit Function

ErrorTrap:
    
    RangeGridOutside = False
    Resume Next

End Function

Public Function RangeGridTop(ByVal SheetNo As Integer, ByVal Range As String) As Boolean

    ' Draw a Double Thick Line on the Top of "Grid"
    RangeGridTop = True
    
    On Error GoTo ErrorTrap
    
    ' Set Top Edge to Thick
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlEdgeTop)
        .LineStyle = xlDouble
        .Weight = xlThick
        .ColorIndex = xlAutomatic
    End With
    
    Exit Function

ErrorTrap:
    RangeGridTop = False
    Resume Next

End Function
Public Function RangeGridBottom(ByVal SheetNo As Integer, ByVal Range As String) As Boolean

    ' Draw a Double Thick Line on the Bottom of "Grid"
    RangeGridBottom = True
    
    On Error GoTo ErrorTrap
    
    ' Set Bottom Edge to Thick
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlEdgeBottom)
        .LineStyle = xlDouble
        .Weight = xlThick
        .ColorIndex = xlAutomatic
    End With
    
    Exit Function

ErrorTrap:
    
    RangeGridBottom = False
    Resume Next

End Function

Public Function RangeGridLeft(ByVal SheetNo As Integer, ByVal Range As String) As Boolean

    ' Draw a Double Thick Line on the Left Side of "Grid"
    RangeGridLeft = True
    
    On Error GoTo ErrorTrap
    
    ' Set Left Edge to Thick
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlEdgeLeft)
        .LineStyle = xlDouble
        .Weight = xlThick
        .ColorIndex = xlAutomatic
    End With

    Exit Function

ErrorTrap:
    
    RangeGridLeft = False
    Resume Next

End Function

Public Function RangeGridRight(ByVal SheetNo As Integer, ByVal Range As String) As Boolean

    ' Draw a Double Thick Line on the Right Side of "Grid"
    RangeGridRight = True
    
    On Error GoTo ErrorTrap
    
    ' Set Right Edge to Thick
    With Excel.Worksheets(SheetNo).Range(Range).Borders(xlEdgeRight)
        .LineStyle = xlDouble
        .Weight = xlThick
        .ColorIndex = xlAutomatic
    End With
    
    Exit Function

ErrorTrap:
    
    RangeGridRight = False
    Resume Next

End Function

Public Function CreateColChart(ByVal SrcSheet As Integer, ByVal DataRange As String, ByVal SheetName As String, ByVal subTitle As String) As Boolean

    'Parameters are:
    'Sheet Number of Worksheet containing Source Data
    'Range on Sheet Number for Data.  Include 1 Column and 1 Row for Titles.
    'Valid Sheet Name for Tab
    'Title for Chart
    CreateColChart = True
    
    On Error GoTo ErrorTrap
    
    Excel.Charts.Add.Name = SheetName
    
    With Excel.Charts(SheetName)
        .Move after:=Sheets(Sheets.Count)
        .ChartWizard Source:=Excel.Worksheets(SrcSheet).Range(DataRange), _
            gallery:=xl3DColumn, _
            PlotBy:=xlColumns, _
            CategoryLabels:=1, _
            SeriesLabels:=1, _
            Title:=subTitle
    End With

ErrorTrap:

    CreateColChart = False
    Resume Next

End Function
Public Function CreateBarChart(ByVal SrcSheet As Integer, ByVal DataRange As String, ByVal SheetName As String, ByVal subTitle As String) As Boolean

    'Parameters are:
    'Sheet Number of Worksheet containing Source Data
    'Range on Sheet Number for Data.  Include 1 Column and 1 Row for Titles.
    'Valid Sheet Name for Tab
    'Title for Chart
    
    CreateBarChart = True
    
    On Error GoTo ErrorTrap
    
    Excel.Charts.Add.Name = SheetName
    
    With Excel.Charts(SheetName)
        .Move after:=Sheets(Sheets.Count)
        .ChartWizard Source:=Excel.Worksheets(SrcSheet).Range(DataRange), _
            gallery:=xl3DBar, _
            PlotBy:=xlColumns, _
            CategoryLabels:=1, _
            SeriesLabels:=1, _
            Title:=subTitle
    End With
    
ErrorTrap:
    
    CreateBarChart = False
    Resume Next

End Function
Public Function CreatePieChart(ByVal SrcSheet As Integer, ByVal DataRange As String, ByVal SheetName As String, ByVal subTitle As String) As Boolean

    'Parameters are:
    'Sheet Number of Worksheet containing Source Data
    'Range on Sheet Number for Data.  Include 1 Column and 1 Row for Titles.
    'Valid Sheet Name for Tab
    'Title for Chart
    
    CreatePieChart = True
    
    On Error GoTo ErrorTrap
    
    Excel.Charts.Add.Name = SheetName
    
    With Excel.Charts(SheetName)
        .Move after:=Sheets(Sheets.Count)
        .ChartWizard Source:=Excel.Worksheets(SrcSheet).Range(DataRange), _
            gallery:=xl3DPie, _
            PlotBy:=xlColumns, _
            CategoryLabels:=1, _
            SeriesLabels:=1, _
            Title:=subTitle
    End With
    
ErrorTrap:
    
    CreatePieChart = False
    Resume Next

End Function

