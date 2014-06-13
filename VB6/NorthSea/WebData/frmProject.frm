VERSION 5.00
Begin VB.Form frmProject 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Project Components"
   ClientHeight    =   4710
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   6600
   Icon            =   "frmProject.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4710
   ScaleWidth      =   6600
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton bRemove 
      Caption         =   "&Remove"
      Height          =   375
      Left            =   5280
      TabIndex        =   4
      Top             =   1800
      Width           =   1215
   End
   Begin VB.CommandButton bAdd 
      Caption         =   "&Add"
      Height          =   375
      Left            =   5280
      TabIndex        =   3
      Top             =   1320
      Width           =   1215
   End
   Begin VB.CommandButton bProperties 
      Caption         =   "&Properties"
      Default         =   -1  'True
      Height          =   375
      Left            =   5280
      TabIndex        =   5
      Top             =   2280
      Width           =   1215
   End
   Begin VB.CommandButton bCancel 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   5280
      TabIndex        =   2
      Top             =   600
      Width           =   1215
   End
   Begin VB.CommandButton bOK 
      Caption         =   "&OK"
      Height          =   375
      Left            =   5280
      TabIndex        =   1
      Top             =   120
      Width           =   1215
   End
   Begin VB.CommandButton bDown 
      Caption         =   "Move &Down"
      Height          =   375
      Left            =   5280
      TabIndex        =   7
      Top             =   3480
      Width           =   1215
   End
   Begin VB.CommandButton bUp 
      Caption         =   "Move &Up"
      Height          =   375
      Left            =   5280
      TabIndex        =   6
      Top             =   3000
      Width           =   1215
   End
   Begin VB.ListBox Components 
      Height          =   4350
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   5055
   End
End
Attribute VB_Name = "frmProject"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim ArraySize As Integer

Private Sub Form_Load()

    Dim Buffer As String
    Dim Count As Integer
    Dim StartPos, EndPos, Length As Integer

    Open ProjectFile For Input As #1
    
    Count = 0
    ArraySize = 5
    
    ReDim Component(ArraySize)
    
    Do While Not EOF(1)
        
        Line Input #1, Buffer

        If Left(Buffer, 1) = "[" Then
            
            Count = Count + 1
            If Count > ArraySize Then
                ArraySize = ArraySize + 5
                ReDim Preserve Component(ArraySize)
            End If
            
            Component(Count).Description = Mid(Buffer, 2, Len(Buffer) - 2)
            Components.AddItem Component(Count).Description
        End If

        If Left(Buffer, 13) = "GROUP_HEADING" Then
            Component(Count).GroupHeading = True
        End If
        
        If Left(Buffer, 4) = "URL=" Then
            StartPos = 5
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            Component(Count).Url = Mid(Buffer, StartPos, Length)
        End If
        
        If Left(Buffer, 10) = "START_TAG=" Then
            StartPos = 11
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            Component(Count).StartTag = Mid(Buffer, StartPos, Length)
        End If
        
        If Left(Buffer, 8) = "END_TAG=" Then
            StartPos = 9
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            Component(Count).EndTag = Mid(Buffer, StartPos, Length)
        End If
        
        If Left(Buffer, 14) = "START_INCLUDE=" Then
            StartPos = 15
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            Component(Count).StartInclude = CInt(Mid(Buffer, StartPos, Length))
        End If
        
        If Left(Buffer, 12) = "END_INCLUDE=" Then
            StartPos = 13
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            Component(Count).EndInclude = CInt(Mid(Buffer, StartPos, Length))
        End If
        
        If Left(Buffer, 8) = "TIMEOUT=" Then
            StartPos = 9
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            Component(Count).Timeout = CInt(Mid(Buffer, StartPos, Length))
        End If
        
        If Left(Buffer, 17) = "SPREADSHEET_NAME=" Then
            StartPos = 18
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            Component(Count).SheetName = Mid(Buffer, StartPos, Length)
        End If
        
        If Left(Buffer, 17) = "SPREADSHEET_CELL=" Then
            StartPos = 18
            EndPos = Len(Buffer) + 1
            Length = EndPos - StartPos
            Component(Count).SheetCell = Mid(Buffer, StartPos, Length)
        End If
    Loop

    Close 1

    'Select the first component in the list
    If Components.ListCount > 0 Then Components.Selected(0) = True

End Sub

Private Sub bOK_Click()

    Dim Count As Integer

    Open ProjectFile For Output As #1
    
    For Count = 1 To Components.ListCount
    
        Print #1, "[" & Component(Count).Description & "]"
        If Component(Count).GroupHeading = True Then
            Print #1, "GROUP_HEADING"
        End If
        Print #1, "URL=" & Component(Count).Url
        Print #1, "START_TAG=" & Component(Count).StartTag
        Print #1, "END_TAG=" & Component(Count).EndTag
        Print #1, "START_INCLUDE=" & Component(Count).StartInclude
        Print #1, "END_INCLUDE=" & Component(Count).EndInclude
        Print #1, "TIMEOUT=" & Component(Count).Timeout
        Print #1, "SPREADSHEET_NAME=" & Component(Count).SheetName
        Print #1, "SPREADSHEET_CELL=" & Component(Count).SheetCell
        Print #1, ""
    
    Next
    
    Close 1
    
    Unload Me

End Sub

Private Sub bCancel_Click()

    Unload Me

End Sub

Private Sub bAdd_Click()

    Dim c As Integer
    
    CreateMode = True
    CancelCreate = False

    frmComponent.Show vbModal, Me
    
    'If the user pressed OK then the frmComponent form is now hidden, but
    'contains the data for the new component.  We need to add the
    'new component to the array and list here.  If the user pressed Cancel
    'then CancelCreate is True
    
    If CancelCreate = False Then
    
        'Insert a new item into the list, below the current item
        Components.AddItem frmComponent.tDescription.Text

        'Check that we have enough room in the array for an additional item
        If Components.ListCount > ArraySize Then
            ArraySize = ArraySize + 5
            ReDim Preserve Component(ArraySize)
        End If

        'Add the new data to the array
        c = Components.ListCount
        Component(c).Description = frmComponent.tDescription.Text
        Component(c).Url = frmComponent.tUrl.Text
        Component(c).StartTag = frmComponent.tStartTag.Text
        Component(c).EndTag = frmComponent.tEndTag.Text
        Component(c).StartInclude = CInt(frmComponent.tStartInclude.Text)
        Component(c).EndInclude = CInt(frmComponent.tEndInclude.Text)
        Component(c).SheetName = frmComponent.tSheetName.Text
        Component(c).SheetCell = frmComponent.tSheetCell.Text
        Component(c).Timeout = CInt(frmComponent.tTimeout.Text)
        If frmComponent.tGroupHeading.Value = 1 Then
            Component(c).GroupHeading = True
        Else
            Component(c).GroupHeading = False
        End If

        Unload frmComponent

    End If
    
    CreateMode = False

End Sub

Private Sub bRemove_Click()

    Dim ThisListIndex, LastListIndex As Integer
    Dim ThisArrayIndex, LastArrayIndex As Integer
    Dim c As Integer

    'If there are items in the list
    If Components.ListCount > 0 Then
    
        'And there is an item selected
        If Components.SelCount = 1 Then
        
            'Get the details of the item to be deleted
            ThisListIndex = Components.ListIndex
            LastListIndex = Components.ListCount - 1
            ThisArrayIndex = ThisListIndex + 1
            LastArrayIndex = LastListIndex + 1
        
            'If the item to be deleted is the last in the list
            If ThisListIndex = LastListIndex Then
            
                'Remove the item from the list
                Components.RemoveItem (ThisListIndex)
            
                'Clear the data from the array
                Component(ThisArrayIndex).Description = ""
                Component(ThisArrayIndex).Url = ""
                Component(ThisArrayIndex).StartTag = ""
                Component(ThisArrayIndex).EndTag = ""
                Component(ThisArrayIndex).StartInclude = 0
                Component(ThisArrayIndex).EndInclude = 0
                Component(ThisArrayIndex).SheetName = ""
                Component(ThisArrayIndex).SheetCell = ""
                Component(ThisArrayIndex).Timeout = 0
                Component(ThisArrayIndex).GroupHeading = False

                'If there are still items in the list then
                'Select the last one
                If Components.ListCount > 0 Then
                    Components.Selected(Components.ListCount - 1) = True
                End If

            Else
            
                'Shuffle subsequent array items up one and reset counter

                For c = ThisArrayIndex + 1 To LastArrayIndex

                    'Move array data up one
                    Component(c - 1) = Component(c)
                    
                    'Update list display
                    Components.List(c - 2) = Component(c - 1).Description
                
                Next

                'Remove the last item from the list
                Components.RemoveItem (LastListIndex)

                'Clear the data from the array
                Component(LastArrayIndex).Description = ""
                Component(LastArrayIndex).Url = ""
                Component(LastArrayIndex).StartTag = ""
                Component(LastArrayIndex).EndTag = ""
                Component(LastArrayIndex).StartInclude = 0
                Component(LastArrayIndex).EndInclude = 0
                Component(LastArrayIndex).SheetName = ""
                Component(LastArrayIndex).SheetCell = ""
                Component(LastArrayIndex).Timeout = 0
                Component(LastArrayIndex).GroupHeading = False
            
            End If

        End If

    End If

End Sub

Private Sub Components_DblClick()

    bProperties_Click

End Sub

Private Sub bProperties_Click()

    If Components.SelCount = 1 Then
        frmComponent.Show vbModal, Me
    End If

End Sub

Private Sub bUp_Click()

    Dim SaveComponent As ComponentRecord
    Dim ThisListEntry, PreviousListEntry As Integer
    Dim ThisArrayEntry, PreviousArrayEntry As Integer

    'If there are items above this one
    If Components.ListIndex > 0 Then

        'Get list entry numbers of the two items concerned
        ThisListEntry = Components.ListIndex
        PreviousListEntry = ThisListEntry - 1
        ThisArrayEntry = ThisListEntry + 1
        PreviousArrayEntry = PreviousListEntry + 1

        'Save current component to temporary storage
        SaveComponent = Component(ThisArrayEntry)
        
        'Move item data from previous item into current item
        Component(ThisArrayEntry) = Component(PreviousArrayEntry)
        
        'Move item from temporary storage into previous item
        Component(PreviousArrayEntry) = SaveComponent
        
        'Update the list display to reflect the changes
        Components.List(PreviousListEntry) = Component(PreviousArrayEntry).Description
        Components.List(ThisListEntry) = Component(ThisArrayEntry).Description
        
        'Make previous item the new current item
        Components.Selected(PreviousListEntry) = True

    End If

End Sub

Private Sub bDown_Click()

    Dim SaveComponent As ComponentRecord
    Dim ThisListEntry, NextListEntry As Integer
    Dim ThisArrayEntry, NextArrayEntry As Integer

    'If there are items below this one
    If Components.ListIndex < Components.ListCount - 1 Then

        'Get list entry numbers of the two items concerned
        ThisListEntry = Components.ListIndex
        NextListEntry = ThisListEntry + 1
        ThisArrayEntry = ThisListEntry + 1
        NextArrayEntry = NextListEntry + 1
        
        'Save current component to temporary storage
        SaveComponent = Component(ThisArrayEntry)
        
        'Move item data from next item into current item
        Component(ThisArrayEntry) = Component(NextArrayEntry)
        
        'Move item from temporary storage into next item
        Component(NextArrayEntry) = SaveComponent
        
        'Update the list display to reflect the changes
        Components.List(ThisListEntry) = Component(ThisArrayEntry).Description
        Components.List(NextListEntry) = Component(NextArrayEntry).Description
        
        'Make next item the new current item
        Components.Selected(NextListEntry) = True

    End If

End Sub

