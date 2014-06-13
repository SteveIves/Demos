VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomctl.ocx"
Begin VB.Form frmMain 
   Caption         =   "Repository Class Test Program"
   ClientHeight    =   5565
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   8595
   LinkTopic       =   "Form1"
   ScaleHeight     =   5565
   ScaleWidth      =   8595
   StartUpPosition =   2  'CenterScreen
   Begin MSComctlLib.TreeView Tree 
      Height          =   5295
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   4275
      _ExtentX        =   7541
      _ExtentY        =   9340
      _Version        =   393217
      Indentation     =   529
      LabelEdit       =   1
      Style           =   7
      Appearance      =   1
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Repository As Repository

Private Sub Form_Load()
    
    With Me
        .Show
        .Refresh
    End With
    
    Set Repository = New Repository

    With Repository
        .Description = "Steves Repository"
        .Server = "localhost"
        .Port = 2331
        .MainFile = "c:\webmaster\test\rps\rpsmain.ism"
        .TextFile = "c:\webmaster\test\rps\rpstext.ism"
        .Connect
    
        If .Connected Then
            If .Download Then
                Call LoadTree
            Else
                MsgBox "Download Failed"
            End If
        Else
            MsgBox "Connect failed"
        End If
    
        .Disconnect
    
    End With

End Sub

Private Sub LoadTree()

    Dim Structure As Structure, Str As String
    Dim Field As Field, Fld As String
    Dim Relation As Relation, Rel As String
    Dim Key As Key, Ky As String
    Dim LocalFormat As DisplayFormat, Fmt As String
    Dim Tag As Tag, Tg As String

    With Tree.Nodes
    
        'Add root node "R"
        .Add , , "R", Repository.Description

        'Add sirst level nodes
        '   "S"    Srtuctures
        '   "F"     Files
        '   "M"     Formats
        '   "T"     Tamplates
        .Add "R", tvwChild, "S", "Structures"
        .Add "R", tvwChild, "F", "Files"
        .Add "R", tvwChild, "M", "Formats"
        .Add "R", tvwChild, "T", "Templates"
    
        For Each Structure In Repository.Structures
        
            Str = Structure.StructureName
        
            'Add main structure node "S:<structure>"
            .Add "S", tvwChild, "S:" & Str, Str
        
            'Add main structure children
            '   "SF:<structure>"    Fields
            '   "SK:<structure>"    Keys
            '   "SR:<structure>"    Relations
            '   "SM:<structure>"    Formats
            '   "ST:<structure>"    Tags
            .Add "S:" & Str, tvwChild, "SF:" & Str, "Fields"
            .Add "S:" & Str, tvwChild, "SK:" & Str, "Keys"
            .Add "S:" & Str, tvwChild, "SR:" & Str, "Relations"
            .Add "S:" & Str, tvwChild, "SM:" & Str, "Formats"
            .Add "S:" & Str, tvwChild, "ST:" & Str, "Tags"
    
            'Add fields
            For Each Field In Structure.Fields
                Fld = Field.FieldName
                'Add structure fields "SF:<structure>:<field>"
                .Add "SF:" & Str, tvwChild, "SF:" & Str & ":" & Fld, Fld
            Next Field
    
            'Add keys
            For Each Key In Structure.Keys
                Ky = Key.KeyName
                'Add structure keys "SK:<structure>:<key>"
                .Add "SK:" & Str, tvwChild, "SK:" & Str & ":" & Ky, Ky
            Next Key
    
            'Add relations
            For Each Relation In Structure.Relations
                Rel = Relation.RelationName
                'Add structure relations "SR:<structure>:<relation>"
                .Add "SR:" & Str, tvwChild, "SR:" & Str & ":" & Rel, Rel
            Next Relation
    
            'Add formats
            For Each LocalFormat In Structure.LocalFormats
                Fmt = LocalFormat.FormatName
                'Add structure relations "SM:<structure>:<relation>"
                .Add "SM:" & Str, tvwChild, "SM:" & Str & ":" & Fmt, Fmt
            Next LocalFormat
    
            'Add tags
            For Each Tag In Structure.Tags
                Tg = Tag.TagName
                'Add structure relations "ST:<structure>:<tag>"
                .Add "ST:" & Str, tvwChild, "ST:" & Str & ":" & Tg, Tg
            Next Tag
    
        Next Structure

    End With

    Tree.Nodes("R").Expanded = True

End Sub
