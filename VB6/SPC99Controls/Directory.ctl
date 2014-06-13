VERSION 5.00
Begin VB.UserControl Directory 
   ClientHeight    =   3600
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4800
   ScaleHeight     =   3600
   ScaleWidth      =   4800
End
Attribute VB_Name = "Directory"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
'Default Property Values:
Const m_def_Pattern = ""
'Property Variables:
Dim m_Pattern As String

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MemberInfo=13,0,0,
Public Property Get Pattern() As String
Attribute Pattern.VB_Description = "File pattern to search for"
    Pattern = m_Pattern
End Property

Public Property Let Pattern(ByVal New_Pattern As String)
    m_Pattern = New_Pattern
    PropertyChanged "Pattern"
End Property
'
''WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
''MemberInfo=13
'Public Function GetNextFile() As String
'
'End Function

'Initialize Properties for User Control
Private Sub UserControl_InitProperties()
    m_Pattern = m_def_Pattern
End Sub

'Load property values from storage
Private Sub UserControl_ReadProperties(PropBag As PropertyBag)

    m_Pattern = PropBag.ReadProperty("Pattern", m_def_Pattern)
End Sub

'Write property values to storage
Private Sub UserControl_WriteProperties(PropBag As PropertyBag)

    Call PropBag.WriteProperty("Pattern", m_Pattern, m_def_Pattern)
End Sub

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MemberInfo=13
Public Sub GetNextFile(ByVal Initialize As Boolean, FileName As String)
Attribute GetNextFile.VB_Description = "Method to return next file name which matches Pattern.  Returns blank string when no morematching files exist."

    If Initialize = True Then
        FileName = Dir(m_Pattern, vbNormal + vbReadOnly + vbHidden + vbSystem + vbArchive)
    Else
        FileName = Dir
    End If

End Sub

