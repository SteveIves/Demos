VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.UserControl Progress 
   ClientHeight    =   945
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4305
   ScaleHeight     =   945
   ScaleWidth      =   4305
   Begin MSComctlLib.ProgressBar ProgressBar 
      Height          =   240
      Left            =   180
      TabIndex        =   0
      Top             =   540
      Width           =   3930
      _ExtentX        =   6932
      _ExtentY        =   423
      _Version        =   393216
      Appearance      =   1
   End
   Begin VB.Label Label 
      BackStyle       =   0  'Transparent
      Caption         =   "Task Progress ..."
      Height          =   240
      Left            =   180
      TabIndex        =   2
      Top             =   180
      Width           =   3075
   End
   Begin VB.Label Percent 
      Alignment       =   1  'Right Justify
      BackStyle       =   0  'Transparent
      Caption         =   "0%"
      Height          =   240
      Left            =   3420
      TabIndex        =   1
      Top             =   180
      Width           =   690
   End
End
Attribute VB_Name = "Progress"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=ProgressBar,ProgressBar,-1,Max
Public Property Get Max() As Long
    Max = ProgressBar.Max
End Property

Public Property Let Max(ByVal New_Max As Long)
    ProgressBar.Max() = New_Max
    PropertyChanged "Max"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=ProgressBar,ProgressBar,-1,Min
Public Property Get Min() As Long
    Min = ProgressBar.Min
End Property

Public Property Let Min(ByVal New_Min As Long)
    ProgressBar.Min() = New_Min
    PropertyChanged "Min"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=Caption,Label,-1,Caption
Public Property Get Caption() As String
    Caption = Label.Caption
End Property

Public Property Let Caption(ByVal New_Caption As String)
    Label.Caption() = New_Caption
    PropertyChanged "Caption"
End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=ProgressBar,ProgressBar,-1,Value
Public Property Get Value() As Long
Attribute Value.VB_Description = "Returns or sets a control's current Value property."
    Value = ProgressBar.Value
End Property

Public Property Let Value(ByVal New_Value As Long)
    If (New_Value >= Min) And (New_Value <= Max) Then
        ProgressBar.Value() = New_Value
        PropertyChanged "Value"
        Percent.Caption = CStr(((Value / Max) * 100) \ 1) & "%"
    End If
End Property

'Load property values from storage
Private Sub UserControl_ReadProperties(PropBag As PropertyBag)

    ProgressBar.Max = PropBag.ReadProperty("Max", 100)
    ProgressBar.Min = PropBag.ReadProperty("Min", 0)
    Label.Caption = PropBag.ReadProperty("Caption", "")
    ProgressBar.Value = PropBag.ReadProperty("Value", 0)
End Sub

'Write property values to storage
Private Sub UserControl_WriteProperties(PropBag As PropertyBag)

    Call PropBag.WriteProperty("Max", ProgressBar.Max, 100)
    Call PropBag.WriteProperty("Min", ProgressBar.Min, 0)
    Call PropBag.WriteProperty("Caption", Label.Caption, "")
    Call PropBag.WriteProperty("Value", ProgressBar.Value, 0)
End Sub

