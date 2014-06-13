VERSION 5.00
Begin VB.Form frmComponent 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Cpmponent Properties"
   ClientHeight    =   4725
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   7530
   Icon            =   "frmComponent.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4725
   ScaleWidth      =   7530
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton bOK 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   375
      Left            =   6240
      TabIndex        =   11
      Top             =   4200
      Width           =   1215
   End
   Begin VB.CommandButton bCancel 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   4920
      TabIndex        =   10
      Top             =   4200
      Width           =   1215
   End
   Begin VB.TextBox tUrl 
      Height          =   310
      Left            =   1200
      TabIndex        =   1
      Top             =   600
      Width           =   6135
   End
   Begin VB.CheckBox tGroupHeading 
      Caption         =   "Group Heading"
      Height          =   255
      Left            =   2640
      TabIndex        =   8
      Top             =   3600
      Width           =   1695
   End
   Begin VB.TextBox tSheetCell 
      Height          =   310
      Left            =   6600
      TabIndex        =   7
      Top             =   3000
      Width           =   735
   End
   Begin VB.TextBox tSheetName 
      Height          =   310
      Left            =   1200
      TabIndex        =   6
      Top             =   3000
      Width           =   4455
   End
   Begin VB.TextBox tTimeout 
      Height          =   310
      Left            =   6600
      TabIndex        =   9
      Top             =   3480
      Width           =   735
   End
   Begin VB.TextBox tEndInclude 
      Height          =   310
      Left            =   6600
      TabIndex        =   5
      Top             =   2520
      Width           =   735
   End
   Begin VB.TextBox tStartInclude 
      Height          =   310
      Left            =   6600
      TabIndex        =   3
      Top             =   1560
      Width           =   735
   End
   Begin VB.TextBox tEndTag 
      Height          =   310
      Left            =   1200
      TabIndex        =   4
      Top             =   2040
      Width           =   6135
   End
   Begin VB.TextBox tStartTag 
      Height          =   310
      Left            =   1200
      TabIndex        =   2
      Top             =   1080
      Width           =   6135
   End
   Begin VB.TextBox tDescription 
      Height          =   310
      Left            =   1200
      TabIndex        =   0
      Top             =   120
      Width           =   6135
   End
   Begin VB.Label Label9 
      Alignment       =   1  'Right Justify
      Caption         =   "Download timeout"
      Height          =   255
      Left            =   4920
      TabIndex        =   20
      Top             =   3480
      Width           =   1605
   End
   Begin VB.Label Label8 
      Alignment       =   1  'Right Justify
      Caption         =   "Include characters from start of end tag"
      Height          =   255
      Left            =   3480
      TabIndex        =   19
      Top             =   2520
      Width           =   3015
   End
   Begin VB.Label Label7 
      Alignment       =   1  'Right Justify
      Caption         =   "Include characters from end of start tag"
      Height          =   255
      Left            =   3480
      TabIndex        =   18
      Top             =   1560
      Width           =   3015
   End
   Begin VB.Label Label6 
      Alignment       =   1  'Right Justify
      Caption         =   "Cell"
      Height          =   255
      Left            =   5880
      TabIndex        =   17
      Top             =   3000
      Width           =   615
   End
   Begin VB.Label Label5 
      Alignment       =   1  'Right Justify
      Caption         =   "Spreadsheet"
      Height          =   255
      Left            =   120
      TabIndex        =   16
      Top             =   3000
      Width           =   1005
   End
   Begin VB.Label Label4 
      Alignment       =   1  'Right Justify
      Caption         =   "End Tag"
      Height          =   255
      Left            =   120
      TabIndex        =   15
      Top             =   2040
      Width           =   1005
   End
   Begin VB.Label Label3 
      Alignment       =   1  'Right Justify
      Caption         =   "Start Tag"
      Height          =   255
      Left            =   120
      TabIndex        =   14
      Top             =   1080
      Width           =   1005
   End
   Begin VB.Label Label2 
      Alignment       =   1  'Right Justify
      Caption         =   "URL"
      Height          =   255
      Left            =   120
      TabIndex        =   13
      Top             =   600
      Width           =   1005
   End
   Begin VB.Label Label1 
      Alignment       =   1  'Right Justify
      Caption         =   "Description"
      Height          =   255
      Left            =   120
      TabIndex        =   12
      Top             =   120
      Width           =   1005
   End
End
Attribute VB_Name = "frmComponent"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()

    If CreateMode = True Then
    
        tStartInclude.Text = "0"
        tEndInclude.Text = "0"
        tTimeout.Text = "15"
    
    Else
    
        Dim c As Integer
    
        'Load form fields from array element
        c = frmProject.Components.ListIndex + 1
        tDescription.Text = Component(c).Description
        tUrl.Text = Component(c).Url
        tStartTag.Text = Component(c).StartTag
        tEndTag.Text = Component(c).EndTag
        tStartInclude.Text = CStr(Component(c).StartInclude)
        tEndInclude.Text = CStr(Component(c).EndInclude)
        tTimeout.Text = CStr(Component(c).Timeout)
        tSheetName.Text = Component(c).SheetName
        tSheetCell.Text = Component(c).SheetCell
        If Component(c).GroupHeading = True Then
            tGroupHeading.Value = 1
        Else
            tGroupHeading.Value = 0
        End If

    End If

End Sub

Private Sub bOK_Click()

    If tDescription.Text = "" Then
        
        MsgBox "You must provide a description"
        tDescription.SetFocus
    
    ElseIf tUrl.Text = "" Then
    
        MsgBox "You must provide a source URL"
        tUrl.SetFocus
    
    ElseIf tStartTag.Text = "" Then
    
        MsgBox "You must provide a start tag"
        tStartTag.SetFocus

    ElseIf IsNumeric(tStartInclude.Text) = False Then
    
        MsgBox "Include characters from start tag must be 0 or a positive number"
        tStartInclude.Text = "0"
        tStartInclude.SetFocus

    ElseIf CInt(tStartInclude.Text) < 0 Then
    
        MsgBox "Include characters from start tag must be 0 or a positive number"
        tStartInclude.Text = "0"
        tStartInclude.SetFocus

    ElseIf tEndTag.Text = "" Then
    
        MsgBox "You must provide an end tag"
        tEndTag.SetFocus

    ElseIf IsNumeric(tEndInclude.Text) = False Then
    
        MsgBox "Include characters from end tag must be 0 or a positive number"
        tEndInclude.Text = "0"
        tEndInclude.SetFocus
    
    ElseIf CInt(tEndInclude.Text) < 0 Then
    
        MsgBox "Include characters from end tag must be 0 or a positive number"
        tEndInclude.Text = "0"
        tEndInclude.SetFocus
    
    ElseIf IsNumeric(tTimeout.Text) = False Then
    
        MsgBox "Timeout must be a number and greater than 5 seconds"
        tTimeout.Text = 5
        tTimeout.SetFocus

    ElseIf CInt(tTimeout.Text) < 5 Then
    
        MsgBox "Timeout must be a number and greater than 5 seconds"
        tTimeout.Text = 5
        tTimeout.SetFocus

    Else
    
        If CreateMode = True Then
    
            Me.Hide
    
        Else
    
            Dim c As Integer
        
            'Save changes to array
            c = frmProject.Components.ListIndex + 1
            Component(c).Description = tDescription.Text
            Component(c).Url = tUrl.Text
            Component(c).StartTag = tStartTag.Text
            Component(c).EndTag = tEndTag.Text
            Component(c).StartInclude = CInt(tStartInclude.Text)
            Component(c).EndInclude = CInt(tEndInclude.Text)
            Component(c).Timeout = CInt(tTimeout.Text)
            Component(c).SheetName = tSheetName.Text
            Component(c).SheetCell = tSheetCell.Text
            If tGroupHeading.Value = 1 Then
                Component(c).GroupHeading = True
            Else
                Component(c).GroupHeading = False
            End If
            
            'Update component description in list
            frmProject.Components.List(c - 1) = tDescription.Text
        
            Unload Me
        
        End If

    End If

End Sub

Private Sub bCancel_Click()

    If CreateMode = True Then CancelCreate = True
    
    Unload Me

End Sub

