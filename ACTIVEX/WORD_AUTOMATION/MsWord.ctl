VERSION 5.00
Begin VB.UserControl MsWord 
   ClientHeight    =   3600
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4800
   ScaleHeight     =   3600
   ScaleWidth      =   4800
End
Attribute VB_Name = "MsWord"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Dim MsWord As New Word.Document
Dim Table As Word.Table
'Default Property Values:
Dim StartPos, EndPos As Long

Const m_def_Orientation = 0
'Property Variables:
Dim m_Orientation As Long

Public Sub AddText( _
    ByVal text As String, _
    Optional ByVal size As Single = 12, _
    Optional ByVal face As String = "Times New Roman", _
    Optional ByVal bold As Boolean = False, _
    Optional ByVal italic As Boolean = False, _
    Optional ByVal underline As Boolean = False, _
    Optional ByVal nospace As Boolean = False)

    With MsWord
        
        'Find current end of document position
        StartPos = .Range.Characters.Count - 1
        
        If nospace = False Then
            text = text & " "
        End If
        
        'Insert new text
        .Range.InsertAfter text

        'Find new end of document position
        EndPos = .Range.End

        'Apply renditions to newly added text
        With .Range(StartPos, EndPos).Font
            .Name = face
            .size = size
            .bold = bold
            .italic = italic
            .underline = underline
        End With

    End With

End Sub

Public Sub EndParagraph()

    With MsWord
        
        .Range.Paragraphs.Add
        .Range.Paragraphs.Add
    
    End With

End Sub

Public Sub AddHeading1(ByVal text As String)

    With MsWord
        
        .Range.InsertAfter text
        .Paragraphs(.Paragraphs.Count).Style = wdStyleHeading1
        .Range.Paragraphs.Add
    
    End With

End Sub

Public Sub AddHeading2(ByVal text As String)
        
    With MsWord
        
        .Range.Paragraphs.Add
        
        'Find current end of document position
        StartPos = .Range.Characters.Count - 1
        
        .Range.InsertAfter text
        
        'Find new end of document position
        EndPos = .Range.End
        
        .Range(StartPos, EndPos).Style = wdStyleHeading2
        .Range.Paragraphs.Add
        
    End With
    
End Sub

Public Sub AddHeading3(ByVal text As String)

    With MsWord
        
        .Range.InsertAfter text
        .Paragraphs(.Paragraphs.Count).Style = wdStyleHeading3
        .Range.Paragraphs.Add
    
    End With

End Sub

Public Sub SaveDocumentAs(ByVal DocName As String)

    MsWord.SaveAs DocName

End Sub

Public Sub SaveDocument()

    MsWord.Save

End Sub

Public Sub CloseDocument()

    MsWord.Close
    
End Sub

Public Function AddTable(ByVal rows As Integer, ByVal cols As Integer) As Integer
    
    With MsWord
        
        Set myRange = .Range(.Characters.Count - 1, .Characters.Count - 1)
        .Tables.Add myRange, rows, cols
        AddTable = .Tables.Count
        .Range.Paragraphs.Add
    
    End With

End Function

Public Sub TableAutoFormat(Table As Integer, ByVal format As Long)

    With MsWord
        
        .Tables(Table).AutoFormat format, , , , , , , , , True
        'This appears to be a Word 2000 feature?
        '.Tables(table).AutoFitBehavior wdAutoFitContent
    
    End With
    
End Sub

Public Sub SetTableCell(Table As Integer, ByVal row As Integer, ByVal col As Integer, ByVal text As String)

    MsWord.Tables(Table).Cell(row, col).Range.text = text

End Sub

Public Sub ShadeTableCell(Table As Integer, ByVal row As Integer, ByVal col As Integer)

    MsWord.Tables(Table).Cell(row, col).Shading.Texture = wdTexture20Percent

End Sub

Public Sub ReverseTableRow(Table As Integer, ByVal row As Integer)

    MsWord.Tables(Table).rows(row).Shading.Texture = wdTextureSolid

End Sub

Public Sub ReverseTableColumn(Table As Integer, ByVal col As Integer)

    MsWord.Tables(Table).Columns(col).Shading.Texture = wdTextureSolid

End Sub

'Initialize Properties for User Control

Private Sub UserControl_InitProperties()
    
    m_Orientation = m_def_Orientation

End Sub

'Load property values from storage

Private Sub UserControl_ReadProperties(PropBag As PropertyBag)
    
    m_Orientation = PropBag.ReadProperty("Orientation", m_def_Orientation)

End Sub

'Write property values to storage

Private Sub UserControl_WriteProperties(PropBag As PropertyBag)
    
    Call PropBag.WriteProperty("Orientation", m_Orientation, m_def_Orientation)

End Sub

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MemberInfo=8,0,0,0

Public Property Get Orientation() As Long
Attribute Orientation.VB_Description = "Page orientation"
    
    Orientation = m_Orientation

End Property

Public Property Let Orientation(ByVal New_Orientation As Long)
    
    m_Orientation = New_Orientation
    PropertyChanged "Orientation"
    MsWord.PageSetup.Orientation = New_Orientation

End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MemberInfo=14

Public Function SetMargins( _
    Optional ByVal top As Single = 2, _
    Optional ByVal bottom As Single = 2, _
    Optional ByVal left As Single = 2, _
    Optional ByVal right As Single = 2) _
    As Variant

    With MsWord.PageSetup
        
        .TopMargin = CentimetersToPoints(top)
        .BottomMargin = CentimetersToPoints(bottom)
        .LeftMargin = CentimetersToPoints(left)
        .RightMargin = CentimetersToPoints(right)
    
    End With

End Function

