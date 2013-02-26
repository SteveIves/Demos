VERSION 5.00
Object = "{65E121D4-0C60-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCHRT20.OCX"
Begin VB.UserControl Graph 
   BackColor       =   &H8000000E&
   BackStyle       =   0  'Transparent
   ClientHeight    =   4470
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   6345
   PropertyPages   =   "Graph.ctx":0000
   ScaleHeight     =   4470
   ScaleWidth      =   6345
   Begin MSChart20Lib.MSChart MSChart 
      Height          =   4455
      Left            =   0
      OleObjectBlob   =   "Graph.ctx":0016
      TabIndex        =   0
      Top             =   0
      Width           =   6345
   End
End
Attribute VB_Name = "Graph"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Ext_KEY = "PropPageWizardRun" ,"Yes"

'Default Property Values:
Const m_def_StartMonth = 1

'Property Variables:
Dim m_StartMonth As Single

Private Sub UserControl_Resize()

    With MSChart
        .Top = 1
        .Left = 1
        .Width = Width
        .Height = Height
    End With

End Sub

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MemberInfo=5
Public Sub Resize(ByVal NewWidth As Long, ByVal NewHeight As Long)
     
    Dim TwipWidth, PixelWidth, TwipHeight, PixelHeight As Long

    'Get current dimension of control in twips
    UserControl.ScaleMode = vbTwips
    TwipWidth = UserControl.ScaleWidth
    TwipHeight = UserControl.ScaleHeight

    'Get current dimension of control in pixels
    UserControl.ScaleMode = vbPixels
    PixelWidth = UserControl.ScaleWidth
    PixelHeight = UserControl.ScaleHeight

    'Apply new twip dimensions to control
    With UserControl
        .ScaleMode = vbTwips
        .Width = NewWidth * (TwipWidth / PixelWidth)
        .Height = NewHeight * (TwipHeight / PixelHeight)
    End With

End Sub

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=MSChart,MSChart,-1,ColumnCount
Public Property Get ColumnCount() As Integer
    ColumnCount = MSChart.ColumnCount
End Property

Public Property Let ColumnCount(ByVal New_ColumnCount As Integer)
    MSChart.ColumnCount() = New_ColumnCount
    PropertyChanged "ColumnCount"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=MSChart,MSChart,-1,Column
Public Property Get Column() As Integer
    Column = MSChart.Column
End Property

Public Property Let Column(ByVal New_Column As Integer)
    MSChart.Column() = New_Column
    PropertyChanged "Column"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=MSChart,MSChart,-1,ColumnLabel
Public Property Get ColumnLabel() As String
    ColumnLabel = MSChart.ColumnLabel
End Property

Public Property Let ColumnLabel(ByVal New_ColumnLabel As String)
    MSChart.ColumnLabel() = New_ColumnLabel
    PropertyChanged "ColumnLabel"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=MSChart,MSChart,-1,Row
Public Property Get Row() As Integer
Attribute Row.VB_Description = "Returns/sets the active row of the data grid."
Attribute Row.VB_ProcData.VB_Invoke_Property = "ChartProperties"
    Row = MSChart.Row
End Property

Public Property Let Row(ByVal New_Row As Integer)
    MSChart.Row() = New_Row
    PropertyChanged "Row"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=MSChart,MSChart,-1,Data
Public Property Get Data() As String
Attribute Data.VB_Description = "Returns/sets the value of a specific data point in the data grid identified by Column and Row."
Attribute Data.VB_ProcData.VB_Invoke_Property = "ChartProperties"
    Data = MSChart.Data
End Property

Public Property Let Data(ByVal New_Data As String)
    MSChart.Data() = New_Data
    PropertyChanged "Data"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=MSChart,MSChart,-1,TitleText
Public Property Get Title() As String
Attribute Title.VB_ProcData.VB_Invoke_Property = "ChartProperties"
    Title = MSChart.TitleText
End Property

Public Property Let Title(ByVal New_Title As String)
    MSChart.TitleText() = New_Title
    PropertyChanged "Title"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=MSChart,MSChart,-1,FootnoteText
Public Property Get Footnote() As String
Attribute Footnote.VB_ProcData.VB_Invoke_Property = "ChartProperties"
    Footnote = MSChart.FootnoteText
End Property

Public Property Let Footnote(ByVal New_Footnote As String)
    MSChart.FootnoteText() = New_Footnote
    PropertyChanged "Footnote"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MemberInfo=12,0,0,1
Public Property Get StartMonth() As Single
    StartMonth = m_StartMonth
End Property

Public Property Let StartMonth(ByVal New_StartMonth As Single)
    m_StartMonth = New_StartMonth
    PropertyChanged "StartMonth"
    
    If New_StartMonth <> 1 Then
    
        Dim c, m As Single
        Dim Month(12) As String
    
        Month(1) = "Jan"
        Month(2) = "Feb"
        Month(3) = "Mar"
        Month(4) = "Apr"
        Month(5) = "May"
        Month(6) = "Jun"
        Month(7) = "Jul"
        Month(8) = "Aug"
        Month(9) = "Sep"
        Month(10) = "Oct"
        Month(11) = "Nov"
        Month(12) = "Dec"
    
        For c = 1 To 12
            MSChart.Row = c
            m = New_StartMonth + c - 1
            If m > 12 Then m = m - 12
            MSChart.RowLabel = Month(m)
        Next c

    End If

End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=MSChart,MSChart,-1,ColumnLabel
Public Property Get DataLabel() As String
    DataLabel = MSChart.ColumnLabel
End Property

Public Property Let DataLabel(ByVal New_DataLabel As String)
    MSChart.ColumnLabel() = New_DataLabel
    PropertyChanged "DataLabel"
End Property

'Load property values from storage
Private Sub UserControl_ReadProperties(PropBag As PropertyBag)

    MSChart.Row = PropBag.ReadProperty("Row", 11)
    MSChart.Data = PropBag.ReadProperty("Data", "0")
    MSChart.TitleText = PropBag.ReadProperty("Title", "")
    MSChart.FootnoteText = PropBag.ReadProperty("Footnote", "")
    m_StartMonth = PropBag.ReadProperty("StartMonth", m_def_StartMonth)
    MSChart.ColumnLabel = PropBag.ReadProperty("DataLabel", "Value")

    MSChart.ColumnCount = PropBag.ReadProperty("ColumnCount", 1)
    MSChart.Column = PropBag.ReadProperty("Column", 1)
    MSChart.ColumnLabel = PropBag.ReadProperty("ColumnLabel", "Value")
    MSChart.ShowLegend = PropBag.ReadProperty("ShowLegend", False)
    MSChart.chartType = PropBag.ReadProperty("chartType", 1)
End Sub

'Write property values to storage
Private Sub UserControl_WriteProperties(PropBag As PropertyBag)

    Call PropBag.WriteProperty("Row", MSChart.Row, 11)
    Call PropBag.WriteProperty("Data", MSChart.Data, "0")
    Call PropBag.WriteProperty("Title", MSChart.TitleText, "")
    Call PropBag.WriteProperty("Footnote", MSChart.FootnoteText, "")
    Call PropBag.WriteProperty("StartMonth", m_StartMonth, m_def_StartMonth)
    Call PropBag.WriteProperty("DataLabel", MSChart.ColumnLabel, "Value")

    Call PropBag.WriteProperty("ColumnCount", MSChart.ColumnCount, 1)
    Call PropBag.WriteProperty("Column", MSChart.Column, 1)
    Call PropBag.WriteProperty("ColumnLabel", MSChart.ColumnLabel, "Value")
    Call PropBag.WriteProperty("ShowLegend", MSChart.ShowLegend, False)
    Call PropBag.WriteProperty("chartType", MSChart.chartType, 1)
End Sub

'Initialize Properties for User Control
Private Sub UserControl_InitProperties()
    m_StartMonth = m_def_StartMonth
End Sub
'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=MSChart,MSChart,-1,ShowLegend
Public Property Get ShowLegend() As Boolean
Attribute ShowLegend.VB_Description = "Determines whether the legend is displayed on the chart."
    ShowLegend = MSChart.ShowLegend
End Property

Public Property Let ShowLegend(ByVal New_ShowLegend As Boolean)
    MSChart.ShowLegend() = New_ShowLegend
    PropertyChanged "ShowLegend"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=MSChart,MSChart,-1,chartType
Public Property Get chartType() As VtChChartType
Attribute chartType.VB_Description = "Returns/sets the type of chart used to plot the data in the data grid."
    chartType = MSChart.chartType
End Property

Public Property Let chartType(ByVal New_chartType As VtChChartType)
    MSChart.chartType() = New_chartType
    PropertyChanged "chartType"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=MSChart,MSChart,-1,EditCopy
Public Sub EditCopy()
Attribute EditCopy.VB_Description = "Copies the current chart to the clipboard in Windows Metafile format."
    MSChart.EditCopy
    MsgBox "Chart copied to clipboard", vbOKCancel + vbInformation
End Sub

