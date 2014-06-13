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

Public Function CreateSheet() As Boolean

    CreateSheet = True
    On Error GoTo ErrorTrap
    Set Excel = CreateObject("Excel.Sheet")

    Exit Function

ErrorTrap:
    CreateSheet = False
    Resume Next

End Function

Public Function SaveSheet(ByVal FileName As String) As Boolean

    SaveSheet = True
    On Error GoTo ErrorTrap
    
    If Dir$(FileName) <> "" Then
        Kill FileName
    End If

    Excel.SaveAs (FileName)
    
    Exit Function
    
ErrorTrap:
    SaveSheet = False
    Resume Next

End Function

Public Function CloseSheet() As Boolean

    CloseSheet = True
    On Error GoTo ErrorTrap
    Excel.Application.Quit
    Set Excel = Nothing
    
    Exit Function
    
ErrorTrap:
    CloseSheet = False
    Resume Next

End Function

Public Function CellContent(ByVal Row As Integer, ByVal Col As Integer, ByVal Value As Variant) As Boolean

    CellContent = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(1).Cells(Row, Col) = Value
    Exit Function
    
ErrorTrap:
    CellContent = False
    Resume Next

End Function

Public Function RangeContent(ByVal Range As String, ByVal Value As Variant) As Boolean

    RangeContent = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(1).Range(Range) = Value
    Exit Function
    
ErrorTrap:
    RangeContent = False
    Resume Next

End Function

Public Function CellFormula(ByVal Row As Integer, ByVal Col As Integer, ByVal Formula As Variant) As Boolean

    CellFormula = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(1).Cells(Row, Col).Formula = Formula

    Exit Function

ErrorTrap:
    CellFormula = False
    Resume Next

End Function

Public Function RangeFormula(ByVal Range As String, ByVal Formula As Variant) As Boolean

    RangeFormula = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(1).Range(Range).Formula = Formula

    Exit Function

ErrorTrap:
    RangeFormula = False
    Resume Next

End Function

Public Function CellBold(ByVal Row As Integer, ByVal Col As Integer) As Boolean

    CellBold = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(1).Cells(Row, Col).Font.Bold = True

    Exit Function

ErrorTrap:
    CellBold = False
    Resume Next

End Function

Public Function RangeBold(ByVal Range As String) As Boolean

    RangeBold = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(1).Range(Range).Font.Bold = True
    
    Exit Function

ErrorTrap:
    RangeBold = False
    Resume Next

End Function

Public Function CellItalic(ByVal Row As Integer, ByVal Col As Integer) As Boolean

    CellItalic = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(1).Cells(Row, Col).Font.Italic = True

    Exit Function

ErrorTrap:
    CellItalic = False
    Resume Next

End Function

Public Function RangeItalic(ByVal Range As String) As Boolean

    RangeItalic = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(1).Range(Range).Font.Italic = True

    Exit Function

ErrorTrap:
    RangeItalic = False
    Resume Next

End Function

Public Function CellAlign(ByVal Row As Integer, ByVal Col As Integer, ByVal Alignment As Byte) As Boolean

    CellAlign = True
    On Error GoTo ErrorTrap
    Select Case Alignment
    Case 1:     'Left justify
        Excel.Worksheets(1).Cells(Row, Col).HorizontalAlignment = xlHAlignLeft
    Case 2:     'Right justify
        Excel.Worksheets(1).Cells(Row, Col).HorizontalAlignment = xlHAlignRight
    Case 3:     'Center justify
        Excel.Worksheets(1).Cells(Row, Col).HorizontalAlignment = xlHAlignCenter
    End Select
    
    Exit Function

ErrorTrap:
    CellAlign = False
    Resume Next

End Function

Public Function RangeAlign(ByVal Range As String, ByVal Alignment As Byte) As Boolean

    RangeAlign = True
    On Error GoTo ErrorTrap
    Select Case Alignment
    Case 1:     'Left justify
        Excel.Worksheets(1).Range(Range).HorizontalAlignment = xlHAlignLeft
    Case 2:     'Right justify
        Excel.Worksheets(1).Range(Range).HorizontalAlignment = xlHAlignRight
    Case 3:     'Center justify
        Excel.Worksheets(1).Range(Range).HorizontalAlignment = xlHAlignCenter
    End Select
    
    Exit Function

ErrorTrap:
    RangeAlign = False
    Resume Next

End Function

Public Function CellFormat(ByVal Row As Integer, ByVal Col As Integer, ByVal Format As String) As Boolean

    CellFormat = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(1).Cells(Row, Col).NumberFormat = Format

    Exit Function
    
ErrorTrap:
    CellFormat = False
    Resume Next

End Function

Public Function RangeFormat(ByVal Range As String, ByVal Format As String) As Boolean

    RangeFormat = True
    On Error GoTo ErrorTrap
    Excel.Worksheets(1).Range(Range).NumberFormat = Format

    Exit Function
    
ErrorTrap:
    RangeFormat = False
    Resume Next

End Function

Public Function ColumnWidth(ByVal Col As Integer, ByVal Width As Single) As Boolean

    ColumnWidth = True
    On Error GoTo ErrorHandler
    Excel.Worksheets(1).Columns(Col).ColumnWidth = Width
    
    Exit Function
    
ErrorHandler:
    ColumnWidth = False
    Resume Next

End Function

Public Function ColumnRangeWidth(ByVal ColRange As String, ByVal Width As Single) As Boolean

    ColumnRangeWidth = True
    On Error GoTo ErrorHandler
    Excel.Worksheets(1).Columns(ColRange).ColumnWidth = Width
    
    Exit Function
    
ErrorHandler:
    ColumnRangeWidth = False
    Resume Next

End Function
