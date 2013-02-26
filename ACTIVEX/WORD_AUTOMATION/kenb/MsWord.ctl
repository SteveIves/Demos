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
Dim MsWord As Word.Application
Dim Table As Word.Table

'Default Property Values:
Dim StartPos, EndPos As Long
Const m_def_Orientation = 0

'Property Variables:
Dim m_Orientation As Long

Private Sub UserControl_Initialize()

    'Start Word as the control is instantiated
    Set MsWord = New Word.Application

End Sub

Private Sub UserControl_Terminate()

    'Close Word before the control is destroyed
    MsWord.Quit wdDoNotSaveChanges

End Sub

Public Sub StartDocument()

    MsWord.Documents.Add

End Sub

Public Sub EndDocument(ByVal FileName As String)

    With MsWord.Documents(1)
        .SaveAs FileName
        .Close
    End With

End Sub

Public Sub AddText( _
    ByVal text As String, _
    Optional ByVal style As Variant = wdStyleNormal, _
    Optional ByVal size As Single = 12, _
    Optional ByVal face As String = "Times New Roman", _
    Optional ByVal bold As Boolean = False, _
    Optional ByVal italic As Boolean = False, _
    Optional ByVal underline As Boolean = False, _
    Optional ByVal nospace As Boolean = False)
    
    With MsWord.Documents(1)
        
        'Find current end of document position
        StartPos = .Range.Characters.Count - 1
        
        If nospace = False Then
            text = text & " "
        End If
        
        'Insert new text
        .Range.InsertAfter text

        'Find new end of document position
        EndPos = .Range.End

        'Apply Style
        MsWord.Documents(1).Range(StartPos, EndPos).style = style

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

    MsWord.Documents(1).Range.Paragraphs.Add

End Sub

Public Sub AddHeading(ByVal text As String, ByVal style As Variant)

    With MsWord.Documents(1)
        StartPos = .Range.Characters.Count - 1
        .Range.InsertAfter text
        EndPos = .Range.End
        .Range(StartPos, EndPos).style = style
        .Range.Paragraphs.Add
    End With

End Sub

Public Function AddTable(ByVal rows As Integer, ByVal cols As Integer) As Integer
    
    With MsWord.Documents(1)
        Set myRange = .Range(.Characters.Count - 1, .Characters.Count - 1)
        .Tables.Add myRange, rows, cols
        AddTable = .Tables.Count
    End With

End Function

Public Sub TableAutoFormat(Table As Integer, ByVal format As Long)

    With MsWord.Documents(1).Tables(Table)
        .AutoFormat format, , , , , , , , , True
        'This seems to be an Office 2000 feature?
        '.AutoFitBehavior wdAutoFitContent
    End With
    
End Sub

Public Sub SetTableCell( _
    Table As Integer, _
    ByVal row As Integer, _
    ByVal col As Integer, _
    ByVal text As String)

    MsWord.Documents(1).Tables(Table).Cell(row, col).Range.text = text

End Sub

Public Sub ShadeTableCell( _
    Table As Integer, _
    ByVal row As Integer, _
    ByVal col As Integer)

    MsWord.Documents(1).Tables(Table).Cell(row, col).Shading.Texture = wdTexture20Percent

End Sub

Public Sub ReverseTableRow( _
    Table As Integer, _
    ByVal row As Integer)

    MsWord.Documents(1).Tables(Table).rows(row).Shading.Texture = wdTextureSolid

End Sub

Public Sub ReverseTableColumn( _
    Table As Integer, _
    ByVal col As Integer)

    MsWord.Documents(1).Tables(Table).Columns(col).Shading.Texture = wdTextureSolid

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

Public Property Let Orientation( _
    ByVal New_Orientation As Long)
    
    m_Orientation = New_Orientation
    PropertyChanged "Orientation"
    MsWord.Documents(1).PageSetup.Orientation = New_Orientation

End Property

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MemberInfo=14

Public Function SetMargins( _
    Optional ByVal top As Single = 2, _
    Optional ByVal bottom As Single = 2, _
    Optional ByVal left As Single = 2, _
    Optional ByVal right As Single = 2) _
    As Variant

    With MsWord.Documents(1).PageSetup
        .TopMargin = CentimetersToPoints(top)
        .BottomMargin = CentimetersToPoints(bottom)
        .LeftMargin = CentimetersToPoints(left)
        .RightMargin = CentimetersToPoints(right)
    End With

End Function

