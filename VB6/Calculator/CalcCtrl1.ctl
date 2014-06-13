VERSION 5.00
Begin VB.UserControl CalcCtrl1 
   ClientHeight    =   2175
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   1470
   ScaleHeight     =   2175
   ScaleWidth      =   1470
   Begin VB.CommandButton button 
      Caption         =   "="
      Height          =   375
      Index           =   19
      Left            =   0
      TabIndex        =   19
      TabStop         =   0   'False
      Top             =   1800
      Width           =   1455
   End
   Begin VB.CommandButton button 
      Caption         =   "+"
      Height          =   375
      Index           =   18
      Left            =   1080
      TabIndex        =   18
      TabStop         =   0   'False
      Top             =   1440
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "."
      Height          =   375
      Index           =   17
      Left            =   720
      TabIndex        =   17
      TabStop         =   0   'False
      Top             =   1440
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "0"
      Height          =   375
      Index           =   16
      Left            =   0
      TabIndex        =   16
      TabStop         =   0   'False
      Top             =   1440
      Width           =   735
   End
   Begin VB.CommandButton button 
      Caption         =   "-"
      Height          =   375
      Index           =   15
      Left            =   1080
      TabIndex        =   15
      TabStop         =   0   'False
      Top             =   1080
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "3"
      Height          =   375
      Index           =   14
      Left            =   720
      TabIndex        =   14
      TabStop         =   0   'False
      Top             =   1080
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "2"
      Height          =   375
      Index           =   13
      Left            =   360
      TabIndex        =   13
      TabStop         =   0   'False
      Top             =   1080
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "1"
      Height          =   375
      Index           =   12
      Left            =   0
      TabIndex        =   12
      TabStop         =   0   'False
      Top             =   1080
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "X"
      Height          =   375
      Index           =   11
      Left            =   1080
      TabIndex        =   11
      TabStop         =   0   'False
      Top             =   720
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "6"
      Height          =   375
      Index           =   10
      Left            =   720
      TabIndex        =   10
      TabStop         =   0   'False
      Top             =   720
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "5"
      Height          =   375
      Index           =   9
      Left            =   360
      TabIndex        =   9
      TabStop         =   0   'False
      Top             =   720
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "4"
      Height          =   375
      Index           =   8
      Left            =   0
      TabIndex        =   8
      TabStop         =   0   'False
      Top             =   720
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "/"
      Height          =   375
      Index           =   7
      Left            =   1080
      TabIndex        =   7
      TabStop         =   0   'False
      Top             =   360
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "9"
      Height          =   375
      Index           =   6
      Left            =   720
      TabIndex        =   6
      TabStop         =   0   'False
      Top             =   360
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "8"
      Height          =   375
      Index           =   5
      Left            =   360
      TabIndex        =   5
      TabStop         =   0   'False
      Top             =   360
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "7"
      Height          =   375
      Index           =   4
      Left            =   0
      TabIndex        =   4
      TabStop         =   0   'False
      Top             =   360
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "%"
      Height          =   375
      Index           =   3
      Left            =   1080
      TabIndex        =   3
      TabStop         =   0   'False
      Top             =   0
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "Del"
      Height          =   375
      Index           =   2
      Left            =   720
      TabIndex        =   2
      TabStop         =   0   'False
      Top             =   0
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "CE"
      Height          =   375
      Index           =   1
      Left            =   360
      TabIndex        =   1
      TabStop         =   0   'False
      Top             =   0
      Width           =   375
   End
   Begin VB.CommandButton button 
      Caption         =   "C"
      Height          =   375
      Index           =   0
      Left            =   0
      TabIndex        =   0
      TabStop         =   0   'False
      Top             =   0
      Width           =   375
   End
End
Attribute VB_Name = "CalcCtrl1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Rem Update host display
Public Event DisplayNumber(CurrentValue As Double)
Rem Calculation complete (= key pressed)
Public Event CalcDone()
Rem Finished (ESC key pressed)
Public Event CloseCalc()
Dim dValue As String
Dim cValue As Double
Dim Mode As String
Dim StartNumber As Boolean

Private Sub button_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)

    'MsgBox (KeyCode)
    'MsgBox (Shift)

        Select Case KeyCode
        Case 48
            AddDigit ("0")
        Case 49
            AddDigit ("1")
        Case 50
            AddDigit ("2")
        Case 51
            AddDigit ("3")
        Case 52
            AddDigit ("4")
        Case 53
            AddDigit ("5")
        Case 54
            AddDigit ("6")
        Case 55
            AddDigit ("7")
        Case 56
            If Shift = 0 Then
                AddDigit ("8")
            Else
                Multiply
            End If
        Case 57
            AddDigit ("9")
        Case 46
            AddDigit (".")
        Case 8
            RemoveDigit
        Case 37
            Percent
        Case 187
            Add
        Case 189
            Subtract
        Case 191
            Divide
        Case 187
            Equals
        Case 67
            ClearAll
        Case 69
            ClearEntry
    End Select

End Sub

Private Sub UserControl_Initialize()
    dValue = "0"
    cValue = 0
    Mode = "Add"
    StartNumber = True
    RaiseEvent DisplayNumber(cValue)
End Sub
Private Sub button_Click(Index As Integer)
    Rem respond to button presses
    Select Case Index
        Case 16
            AddDigit ("0")
        Case 12
            AddDigit ("1")
        Case 13
            AddDigit ("2")
        Case 14
            AddDigit ("3")
        Case 8
            AddDigit ("4")
        Case 9
            AddDigit ("5")
        Case 10
            AddDigit ("6")
        Case 4
            AddDigit ("7")
        Case 5
            AddDigit ("8")
        Case 6
            AddDigit ("9")
        Case 17
            AddDigit (".")
        Case 2
            RemoveDigit
        Case 0
            ClearAll
        Case 1
            ClearEntry
        Case 3
            Percent
        Case 18
            Add
        Case 15
            Subtract
        Case 11
            Multiply
        Case 7
            Divide
        Case 19
            Equals
    End Select
End Sub
Private Sub AddDigit(Digit As String)
    Rem Add a new digit to the number being entered
    If StartNumber = True Then
        dValue = Digit
        StartNumber = False
    Else
        dValue = dValue + Digit
    End If

    RaiseEvent DisplayNumber(CDbl(dValue))

End Sub
Private Sub RemoveDigit()
    Rem Remove the last digit typed
    If Len(dValue) = 1 Then
        dValue = "0"
    Else
        dValue = Left(dValue, (Len(dValue) - 1))
    End If
    RaiseEvent DisplayNumber(CDbl(dValue))
End Sub
Private Sub ClearAll()
    Rem Clear the current number and the calculation
    dValue = "0"
    cValue = 0
    StartNumber = True
    RaiseEvent DisplayNumber(cValue)
End Sub
Private Sub ClearEntry()
    Rem Clear the current number, but not the calculation
    dValue = "0"
    RaiseEvent DisplayNumber(CDbl(dValue))
End Sub
Private Sub Add()
    Rem Add the number entered to the calculated value
    UpdateValue
    Mode = "Add"
End Sub
Private Sub Subtract()
    Rem Subtract the number entered from the calculated value
    UpdateValue
    Mode = "Subtract"
End Sub
Private Sub Multiply()
    Rem Multiply the calculated value by the number entered
    UpdateValue
    Mode = "Multiply"
End Sub
Private Sub Divide()
    Rem Divide the calculated value by the number entered
    UpdateValue
    Mode = "Divide"
End Sub
Private Sub Percent()
    MsgBox "What do you think it is, Christmas?"
End Sub
Private Sub Equals()
    UpdateValue
    'Mode = ""
    RaiseEvent CalcDone
End Sub
Private Sub UpdateValue()
    Select Case Mode
        Case "Add"
            cValue = (cValue + dValue)
        Case "Subtract"
            cValue = (cValue - dValue)
        Case "Multiply"
            cValue = (cValue * dValue)
        Case "Divide"
            cValue = (cValue / dValue)
    End Select
    
    dValue = CStr(cValue)
    StartNumber = True
    RaiseEvent DisplayNumber(cValue)
End Sub
