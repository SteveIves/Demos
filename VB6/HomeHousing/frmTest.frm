VERSION 5.00
Begin VB.Form TestForm 
   Caption         =   "Test Client"
   ClientHeight    =   6135
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   8700
   LinkTopic       =   "Form1"
   ScaleHeight     =   6135
   ScaleWidth      =   8700
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command2 
      Caption         =   "Stop!"
      Height          =   1455
      Left            =   360
      TabIndex        =   30
      Top             =   4080
      Width           =   1455
   End
   Begin VB.TextBox Text7 
      Height          =   375
      Index           =   5
      Left            =   5400
      TabIndex        =   24
      Top             =   2760
      Width           =   855
   End
   Begin VB.TextBox Text6 
      Height          =   375
      Index           =   5
      Left            =   6360
      TabIndex        =   23
      Top             =   2760
      Width           =   1935
   End
   Begin VB.TextBox Text7 
      Height          =   375
      Index           =   4
      Left            =   5400
      TabIndex        =   22
      Top             =   2280
      Width           =   855
   End
   Begin VB.TextBox Text6 
      Height          =   375
      Index           =   4
      Left            =   6360
      TabIndex        =   21
      Top             =   2280
      Width           =   1935
   End
   Begin VB.TextBox Text7 
      Height          =   375
      Index           =   3
      Left            =   5400
      TabIndex        =   20
      Top             =   1800
      Width           =   855
   End
   Begin VB.TextBox Text6 
      Height          =   375
      Index           =   3
      Left            =   6360
      TabIndex        =   19
      Top             =   1800
      Width           =   1935
   End
   Begin VB.TextBox Text7 
      Height          =   375
      Index           =   2
      Left            =   5400
      TabIndex        =   18
      Top             =   1320
      Width           =   855
   End
   Begin VB.TextBox Text6 
      Height          =   375
      Index           =   2
      Left            =   6360
      TabIndex        =   17
      Top             =   1320
      Width           =   1935
   End
   Begin VB.TextBox Text7 
      Height          =   375
      Index           =   1
      Left            =   5400
      TabIndex        =   16
      Top             =   840
      Width           =   855
   End
   Begin VB.TextBox Text6 
      Height          =   375
      Index           =   1
      Left            =   6360
      TabIndex        =   15
      Top             =   840
      Width           =   1935
   End
   Begin VB.TextBox Text7 
      Height          =   375
      Index           =   0
      Left            =   5400
      TabIndex        =   12
      Top             =   360
      Width           =   855
   End
   Begin VB.TextBox Text6 
      Height          =   375
      Index           =   0
      Left            =   6360
      TabIndex        =   10
      Top             =   360
      Width           =   1935
   End
   Begin VB.TextBox Text5 
      Height          =   375
      Left            =   1440
      TabIndex        =   8
      Top             =   840
      Width           =   1815
   End
   Begin VB.TextBox Text4 
      Height          =   375
      Left            =   1440
      ScrollBars      =   3  'Both
      TabIndex        =   6
      Top             =   2760
      Width           =   1815
   End
   Begin VB.TextBox Text3 
      Height          =   375
      Left            =   1440
      TabIndex        =   4
      Top             =   2280
      Width           =   1815
   End
   Begin VB.TextBox Text2 
      Height          =   375
      Left            =   1440
      TabIndex        =   2
      Top             =   1440
      Width           =   1815
   End
   Begin VB.TextBox Text1 
      Height          =   1815
      Left            =   2040
      MultiLine       =   -1  'True
      ScrollBars      =   3  'Both
      TabIndex        =   1
      Top             =   3840
      Width           =   6495
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Call ""page"""
      Height          =   615
      Left            =   240
      TabIndex        =   0
      Top             =   120
      Width           =   1935
   End
   Begin VB.Label Label12 
      Caption         =   "Item 6"
      Height          =   375
      Left            =   4440
      TabIndex        =   29
      Top             =   2880
      Width           =   735
   End
   Begin VB.Label Label11 
      Caption         =   "Item 5"
      Height          =   375
      Left            =   4440
      TabIndex        =   28
      Top             =   2400
      Width           =   735
   End
   Begin VB.Label Label10 
      Caption         =   "Item 4"
      Height          =   375
      Left            =   4440
      TabIndex        =   27
      Top             =   1920
      Width           =   735
   End
   Begin VB.Label Label9 
      Caption         =   "Item 3"
      Height          =   375
      Left            =   4440
      TabIndex        =   26
      Top             =   1440
      Width           =   735
   End
   Begin VB.Label Label8 
      Caption         =   "Item 2"
      Height          =   375
      Left            =   4440
      TabIndex        =   25
      Top             =   960
      Width           =   735
   End
   Begin VB.Label Label7 
      Caption         =   "Value"
      Height          =   255
      Left            =   6480
      TabIndex        =   14
      Top             =   120
      Width           =   1215
   End
   Begin VB.Label Label6 
      Caption         =   "Key"
      Height          =   255
      Left            =   5520
      TabIndex        =   13
      Top             =   120
      Width           =   615
   End
   Begin VB.Label Label5 
      Caption         =   "Item 1"
      Height          =   375
      Left            =   4440
      TabIndex        =   11
      Top             =   480
      Width           =   735
   End
   Begin VB.Label Label4 
      Caption         =   "Page ID"
      Height          =   375
      Left            =   600
      TabIndex        =   9
      Top             =   960
      Width           =   735
   End
   Begin VB.Label Label3 
      Caption         =   "Password (userID on test)"
      Height          =   975
      Left            =   240
      TabIndex        =   7
      Top             =   2760
      Width           =   735
   End
   Begin VB.Label Label2 
      Caption         =   "Username"
      Height          =   255
      Left            =   240
      TabIndex        =   5
      Top             =   2400
      Width           =   975
   End
   Begin VB.Label Label1 
      Caption         =   "UserID"
      Height          =   255
      Left            =   600
      TabIndex        =   3
      Top             =   1560
      Width           =   615
   End
End
Attribute VB_Name = "TestForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Command1_Click()
Dim Coordinator As Variant
Dim User As Variant
Dim Output As Variant

Dim userId As Variant
Dim PageKey As Variant
Dim Username As Variant
Dim Password As Variant
ReDim InputArray(1, 10) As Variant
Dim MaxArray As Variant
Dim ArrayCount As Variant
Dim i As Integer

MaxArray = 10
ArrayCount = 0

' start coodinator
Set Coordinator = CreateObject("HomeHousingApp.Coordinator")

'UserID=Request("UserID")
'PageKey=Request("PageKey")
'Username=Request("Username")
'Password=Request("Password")

userId = Text2.Text
PageKey = Text5.Text
Username = Text3.Text
Password = Text4.Text

For i = 0 To 5
    If Text7.Item(i) <> "" Then
        InputArray(0, i) = Text7.Item(i)
        InputArray(1, i) = Text6.Item(i)
        ArrayCount = ArrayCount + 1
    End If
Next

If ArrayCount = 0 Then
    InputArray(0, 0) = 22222
    InputArray(1, 0) = 22222
    ArrayCount = 1
End If

ReDim Preserve InputArray(1, ArrayCount - 1)

If userId = "" Then
    ' try with the username and password  - will get back unknown if
    ' failed
    Set User = Coordinator.RequestNewUser(Username, Password)
    ' TODO check for errors here and set unknown if needed
Else
    ' Already have a userID - try and use that user
    Set User = Coordinator.RequestUser(userId)
End If

Call User.DataTransfer(InputArray)

' Set the output string to the page to display
' TODO check for invalid PageKey
Output = User.Display(PageKey)

Set Coordinator = Nothing
Set User = Nothing

Text1.Text = Output

End Sub
