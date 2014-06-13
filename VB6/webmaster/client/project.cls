VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Project"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Attribute VB_Ext_KEY = "Member0" ,"ProjectFiles"
Option Explicit

'Property values
'*** Don't forget to update Reset method when adding new properties ***
Private mvarFile As String
Private mvarDescription As String
Private mvarWebDir As String
Private mvarSynergyDir As String
Private mvarIsOpen As Boolean
Private mvarChanged As Boolean
Private mvarServer As String
Private mvarPort As Long
Private mvarRpsMainFile As String
Private mvarRpsTextFile As String
Private mvarOlb As String
Private mvarElb As String
Private mvarProjectFiles As ProjectFiles



Private Sub Class_Initialize()

    'Set default values
    mvarDescription = "New Project"
    mvarWebDir = CurDir
    mvarSynergyDir = CurDir
    mvarIsOpen = False
    mvarChanged = True
    mvarServer = "LOCALHOST"
    mvarPort = 2331
    mvarRpsMainFile = Environ("RPSMFIL")
    mvarRpsTextFile = Environ("RPSTFIL")
    mvarOlb = "webapp.olb"
    mvarElb = "webapp.elb"

    Set mvarProjectFiles = New ProjectFiles

End Sub

Private Sub Class_Terminate()
    Set mvarProjectFiles = Nothing
End Sub


'ProjectFiles collection
Public Property Set ProjectFiles(vData As ProjectFiles)
    Set mvarProjectFiles = vData
    mvarChanged = True
End Property
Public Property Get ProjectFiles() As ProjectFiles
    Set ProjectFiles = mvarProjectFiles
End Property



'File Property
Public Property Let File(ByVal vData As String)
    mvarFile = vData
    mvarChanged = True
End Property
Public Property Get File() As String
    File = mvarFile
End Property


'Description Property
Public Property Let Description(ByVal vData As String)
    mvarDescription = vData
    mvarChanged = True
End Property
Public Property Get Description() As String
    Description = mvarDescription
End Property


'WebDir Property
Public Property Let WebDir(ByVal vData As String)
    mvarWebDir = vData
    mvarChanged = True
End Property
Public Property Get WebDir() As String
    WebDir = mvarWebDir
End Property


'SynergyDir Property
Public Property Let SynergyDir(ByVal vData As String)
    mvarSynergyDir = vData
    mvarChanged = True
End Property
Public Property Get SynergyDir() As String
    SynergyDir = mvarSynergyDir
End Property


'IsOpen Property
Public Property Let IsOpen(ByVal vData As Boolean)
    mvarIsOpen = vData
    mvarChanged = True
End Property
Public Property Get IsOpen() As Boolean
Attribute IsOpen.VB_UserMemId = 0
    IsOpen = mvarIsOpen
End Property


'Changed Property
Public Property Get Changed() As Boolean
    Changed = mvarChanged
End Property


'Server Property
Public Property Let Server(ByVal vData As String)
    mvarServer = vData
End Property
Public Property Get Server() As String
    Server = mvarServer
End Property


'Port Property
Public Property Let Port(ByVal vData As Long)
    mvarPort = vData
End Property
Public Property Get Port() As Long
    Port = mvarPort
End Property


'RpsMainFile Property
Public Property Let RpsMainFile(ByVal vData As String)
    mvarRpsMainFile = vData
End Property
Public Property Get RpsMainFile() As String
    RpsMainFile = mvarRpsMainFile
End Property


'RpsTextFile Property
Public Property Let RpsTextFile(ByVal vData As String)
    mvarRpsTextFile = vData
End Property
Public Property Get RpsTextFile() As String
    RpsTextFile = mvarRpsTextFile
End Property


'Olb Property
Public Property Let Olb(ByVal vData As String)
    mvarOlb = vData
End Property
Public Property Get Olb() As String
    Olb = mvarOlb
End Property


'Elb Property
Public Property Let Elb(ByVal vData As String)
    mvarElb = vData
End Property
Public Property Get Elb() As String
    Elb = mvarElb
End Property


'OpenExisting Method
Public Sub OpenExisting(ProjectFile As String)

    Dim Buffer As String, SubString() As String, FieldString() As String, c As Integer

    mvarProjectFiles.Add "global.asa"

    Open ProjectFile For Input As #1
    
    Do While Not EOF(1)
        
        Line Input #1, Buffer

        If Left(Buffer, 11) = "DESCRIPTION" Then
            mvarDescription = Right(Buffer, Len(Buffer) - 12)
        End If

        If Left(Buffer, 6) = "WEBDIR" Then
            mvarWebDir = Right(Buffer, Len(Buffer) - 7)
        End If

        If Left(Buffer, 6) = "SYNDIR" Then
            mvarSynergyDir = Right(Buffer, Len(Buffer) - 7)
        End If

        If Left(Buffer, 6) = "SERVER" Then
            mvarServer = Right(Buffer, Len(Buffer) - 7)
        End If

        If Left(Buffer, 4) = "PORT" Then
            mvarPort = CLng(Right(Buffer, Len(Buffer) - 5))
        End If

        If Left(Buffer, 7) = "RPSMFIL" Then
            mvarRpsMainFile = Right(Buffer, Len(Buffer) - 8)
        End If

        If Left(Buffer, 7) = "RPSTFIL" Then
            mvarRpsTextFile = Right(Buffer, Len(Buffer) - 8)
        End If

        If Left(Buffer, 3) = "OLB" Then
            mvarOlb = Right(Buffer, Len(Buffer) - 4)
        End If

        If Left(Buffer, 3) = "ELB" Then
            mvarElb = Right(Buffer, Len(Buffer) - 4)
        End If

        If Left(Buffer, 4) = "FILE" Then
            
            Buffer = Right(Buffer, Len(Buffer) - 5) 'Lose FILE=
            
            SubString = Split(Buffer, "|", 3)
            mvarProjectFiles.Add SubString(0)
            mvarProjectFiles(SubString(0)).Structure = SubString(1)
            
            FieldString = Split(SubString(2), ",", -1)

            For c = 0 To UBound(FieldString)
                mvarProjectFiles(SubString(0)).ProjectFileFields.Add FieldString(c)
            Next c

        End If

    Loop
    Close #1

    mvarFile = ProjectFile
    mvarIsOpen = True
    mvarChanged = False

End Sub


'Save Method
Public Sub Save()

    Dim File As ProjectFile
    Dim Field As ProjectFileField
    Dim Buffer As String

    If mvarIsOpen Then
        If mvarChanged Then
            If mvarFile <> "" Then
            
                Open mvarFile For Output As #1
                
                Print #1, "DESCRIPTION=" & mvarDescription
                Print #1, "WEBDIR=" & mvarWebDir
                Print #1, "SYNDIR=" & mvarSynergyDir
                Print #1, "SERVER=" & mvarServer
                Print #1, "PORT=" & mvarPort
                Print #1, "RPSMFIL=" & mvarRpsMainFile
                Print #1, "RPSTFIL=" & mvarRpsTextFile
                Print #1, "OLB=" & mvarOlb
                Print #1, "ELB=" & mvarElb
                
                For Each File In mvarProjectFiles
                    If File.FileName <> "global.asa" Then
                        Buffer = "FILE=" & File.FileName & "|" & File.Structure & "|"
                        For Each Field In mvarProjectFiles(File.FileName).ProjectFileFields
                            Buffer = Buffer & Field.FieldName & ","
                        Next Field
                        Buffer = Left(Buffer, Len(Buffer) - 1) ' Remove trailing comma
                        Print #1, Buffer
                    End If
                Next File
                
                Close #1
            
                mvarChanged = False
                       
            End If
        End If
    End If

End Sub

'Reset Method
Public Sub Reset()

    mvarFile = ""
    mvarDescription = ""
    mvarWebDir = ""
    mvarSynergyDir = ""
    mvarIsOpen = False
    mvarChanged = False
    mvarServer = ""
    mvarPort = 0
    mvarRpsMainFile = ""
    mvarRpsTextFile = ""
    mvarOlb = ""
    mvarElb = ""

    mvarProjectFiles.Clear

End Sub
