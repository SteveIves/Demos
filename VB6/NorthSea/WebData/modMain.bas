Attribute VB_Name = "modMain"
Option Explicit

'Name of currently open project file
Public ProjectFile As String

'Are we creating a new project?
Public CreateMode As Boolean
Public CancelCreate As Boolean

'User defined datatype for the Component() array (below)
Public Type ComponentRecord
    Description As String
    Url As String
    StartTag As String
    EndTag As String
    StartInclude As Integer
    EndInclude As Integer
    Timeout As Integer
    SheetName As String
    SheetCell As String
    GroupHeading As Boolean
End Type

'Dynamic array used to hold project components in
'frmProject and frmComponent
Public Component() As ComponentRecord

