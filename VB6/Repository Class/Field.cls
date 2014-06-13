VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Field"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"No"
Option Explicit

Private mvarFieldName As String
Private mvarDataType As String
Private mvarSize As Long
Private mvarPrecision As Integer
Private mvarRequired As Boolean
Private mvarUppercase As Boolean
Private mvarPrompt As String
Private mvarNegatives As Boolean
Private mvarPosition As Long
Private mvarOverlayField As String
Private mvarOverlayOffset As Long
Private mvarDescription As String
Private mvarClass As String
Private mvarArrayDimension1 As Integer
Private mvarArrayDimension2 As Integer
Private mvarArrayDimension3 As Integer
Private mvarArrayDimension4 As Integer
Private mvarAvailableLanguage As Boolean
Private mvarAvailableReportWriter As Boolean
Private mvarAvailableToolkit As Boolean
Private mvarReportHeading As String
Private mvarReportJustification As String
Private mvarInputJustification As String
Private mvarRadioButtons As Boolean
Private mvarCheckbox As Boolean
Private mvarHelpID As String
Private mvarStatusBarText As String
Private mvarOdbcName As String
Private mvarFieldFont As String
Private mvarPromptFont As String
Private mvarReadOnly As Boolean
Private mvarDisabled As Boolean
Private mvarPassword As Boolean
Private mvarDefaultValue As String
Private mvarDateToday As Boolean
Private mvarTimeNow As Boolean
Private mvarTimeAmPm As Boolean
Private mvarNoDemimalRequired As Boolean
Private mvarMin As Single
Private mvarMax As Single


'FieldName Property
Public Property Let FieldName(ByVal vData As String)
    mvarFieldName = vData
End Property
Public Property Get FieldName() As String
    FieldName = mvarFieldName
End Property


'DataType Property
Public Property Let DataType(ByVal vData As String)
    mvarDataType = vData
End Property
Public Property Get DataType() As String
    DataType = mvarDataType
End Property


'Size Property
Public Property Let Size(ByVal vData As Long)
    mvarSize = vData
End Property
Public Property Get Size() As Long
    Size = mvarSize
End Property


'Precision Property
Public Property Let Precision(ByVal vData As Integer)
    mvarPrecision = vData
End Property
Public Property Get Precision() As Integer
    Precision = mvarPrecision
End Property


'Required Property
Public Property Let Required(ByVal vData As Boolean)
    mvarRequired = vData
End Property
Public Property Get Required() As Boolean
    Required = mvarRequired
End Property


'Uppercase Property
Public Property Let Uppercase(ByVal vData As Boolean)
    mvarUppercase = vData
End Property
Public Property Get Uppercase() As Boolean
    Uppercase = mvarUppercase
End Property


'Prompt Property
Public Property Let Prompt(ByVal vData As String)
    mvarPrompt = vData
End Property
Public Property Get Prompt() As String
    Prompt = mvarPrompt
End Property


'Negatives Property
Public Property Let Negatives(ByVal vData As Boolean)
    mvarNegatives = vData
End Property
Public Property Get Negatives() As Boolean
    Negatives = mvarNegatives
End Property


'Position Property
Public Property Let Position(ByVal vData As Long)
    mvarPosition = vData
End Property
Public Property Get Position() As Long
    Position = mvarPosition
End Property


'OverlayField Property
Public Property Let OverlayField(ByVal vData As String)
    mvarOverlayField = vData
End Property
Public Property Get OverlayField() As String
    OverlayField = mvarOverlayField
End Property


'OverlayOffset Property
Public Property Let OverlayOffset(ByVal vData As Long)
    mvarOverlayOffset = vData
End Property
Public Property Get OverlayOffset() As Long
    OverlayOffset = mvarOverlayOffset
End Property


'Description Property
Public Property Let Description(ByVal vData As String)
    mvarDescription = vData
End Property
Public Property Get Description() As String
    Description = mvarDescription
End Property


'Class Property
Public Property Let Class(ByVal vData As String)
    mvarClass = vData
End Property
Public Property Get Class() As String
    Class = mvarClass
End Property


'ArrayDimension1 Property
Public Property Let ArrayDimension1(ByVal vData As Integer)
    mvarArrayDimension1 = vData
End Property
Public Property Get ArrayDimension1() As Integer
    ArrayDimension1 = mvarArrayDimension1
End Property


'ArrayDimension2 Property
Public Property Let ArrayDimension2(ByVal vData As Integer)
    mvarArrayDimension2 = vData
End Property
Public Property Get ArrayDimension2() As Integer
    ArrayDimension2 = mvarArrayDimension2
End Property


'ArrayDimension3 Property
Public Property Let ArrayDimension3(ByVal vData As Integer)
    mvarArrayDimension3 = vData
End Property
Public Property Get ArrayDimension3() As Integer
    ArrayDimension3 = mvarArrayDimension3
End Property


'ArrayDimension4 Property
Public Property Let ArrayDimension4(ByVal vData As Integer)
    mvarArrayDimension4 = vData
End Property
Public Property Get ArrayDimension4() As Integer
    ArrayDimension4 = mvarArrayDimension4
End Property


'AvailableLanguage Property
Public Property Let AvailableLanguage(ByVal vData As Boolean)
    mvarAvailableLanguage = vData
End Property
Public Property Get AvailableLanguage() As Boolean
    AvailableLanguage = mvarAvailableLanguage
End Property


'AvailableReportWriter Property
Public Property Let AvailableReportWriter(ByVal vData As Boolean)
    mvarAvailableReportWriter = vData
End Property
Public Property Get AvailableReportWriter() As Boolean
    AvailableReportWriter = mvarAvailableReportWriter
End Property


'AvailableToolkit Property
Public Property Let AvailableToolkit(ByVal vData As Boolean)
    mvarAvailableToolkit = vData
End Property
Public Property Get AvailableToolkit() As Boolean
    AvailableToolkit = mvarAvailableToolkit
End Property


'ReportHeading Property
Public Property Let ReportHeading(ByVal vData As String)
    mvarReportHeading = vData
End Property
Public Property Get ReportHeading() As String
    ReportHeading = mvarReportHeading
End Property


'ReportJustification Property
Public Property Let ReportJustification(ByVal vData As String)
    mvarReportJustification = vData
End Property
Public Property Get ReportJustification() As String
    ReportJustification = mvarReportJustification
End Property


'InputJustification Property
Public Property Let InputJustification(ByVal vData As String)
    mvarInputJustification = vData
End Property
Public Property Get InputJustification() As String
    InputJustification = mvarInputJustification
End Property


'RadioButtons Property
Public Property Let RadioButtons(ByVal vData As Boolean)
    mvarRadioButtons = vData
End Property
Public Property Get RadioButtons() As Boolean
    RadioButtons = mvarRadioButtons
End Property


'Checkbox Property
Public Property Let Checkbox(ByVal vData As Boolean)
    mvarCheckbox = vData
End Property
Public Property Get Checkbox() As Boolean
    Checkbox = mvarCheckbox
End Property


'HelpID Property
Public Property Let HelpID(ByVal vData As String)
    mvarHelpID = vData
End Property
Public Property Get HelpID() As String
    HelpID = mvarHelpID
End Property


'StatusBarText Property
Public Property Let StatusBarText(ByVal vData As String)
    mvarStatusBarText = vData
End Property
Public Property Get StatusBarText() As String
    StatusBarText = mvarStatusBarText
End Property


'OdbcName Property
Public Property Let OdbcName(ByVal vData As String)
    mvarOdbcName = vData
End Property
Public Property Get OdbcName() As String
    OdbcName = mvarOdbcName
End Property


'FieldFont Property
Public Property Let FieldFont(ByVal vData As String)
    mvarFieldFont = vData
End Property
Public Property Get FieldFont() As String
    FieldFont = mvarFieldFont
End Property


'PromptFont Property
Public Property Let PromptFont(ByVal vData As String)
    mvarPromptFont = vData
End Property
Public Property Get PromptFont() As String
    PromptFont = mvarPromptFont
End Property


'ReadOnly Property
Public Property Let ReadOnly(ByVal vData As Boolean)
    mvarReadOnly = vData
End Property
Public Property Get ReadOnly() As Boolean
    ReadOnly = mvarReadOnly
End Property


'Disabled Property
Public Property Let Disabled(ByVal vData As Boolean)
    mvarDisabled = vData
End Property
Public Property Get Disabled() As Boolean
    Disabled = mvarDisabled
End Property


'Password Property
Public Property Let Password(ByVal vData As Boolean)
    mvarPassword = vData
End Property
Public Property Get Password() As Boolean
    Password = mvarPassword
End Property


'DefaultValue Property
Public Property Let DefaultValue(ByVal vData As String)
    mvarDefaultValue = vData
End Property
Public Property Get DefaultValue() As String
    DefaultValue = mvarDefaultValue
End Property


'DateToday Property
Public Property Let DateToday(ByVal vData As Boolean)
    mvarDateToday = vData
End Property
Public Property Get DateToday() As Boolean
    DateToday = mvarDateToday
End Property


'TimeNow Property
Public Property Let TimeNow(ByVal vData As Boolean)
    mvarTimeNow = vData
End Property
Public Property Get TimeNow() As Boolean
    TimeNow = mvarTimeNow
End Property


'TimeAmPm Property
Public Property Let TimeAmPm(ByVal vData As Boolean)
    mvarTimeAmPm = vData
End Property
Public Property Get TimeAmPm() As Boolean
    TimeAmPm = mvarTimeAmPm
End Property


'NoDecimalRequired Property
Public Property Let NoDemimalRequired(ByVal vData As Boolean)
    mvarNoDemimalRequired = vData
End Property
Public Property Get NoDemimalRequired() As Boolean
    NoDemimalRequired = mvarNoDemimalRequired
End Property


'Min Property
Public Property Let Min(ByVal vData As Single)
    mvarMin = vData
End Property
Public Property Get Min() As Single
    Min = mvarMin
End Property


'Max property
Public Property Let Max(ByVal vData As Single)
    mvarMax = vData
End Property
Public Property Get Max() As Single
    Max = mvarMax
End Property
