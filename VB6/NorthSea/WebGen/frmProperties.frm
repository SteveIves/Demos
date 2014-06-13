VERSION 5.00
Begin VB.Form frmProperties 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Project Properties"
   ClientHeight    =   4275
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   6840
   HelpContextID   =   5
   Icon            =   "frmProperties.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4275
   ScaleWidth      =   6840
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Tag             =   "ForeVB DB=S:\Source\VB\Nss\gui\docs\WebGen.dba"
   WhatsThisButton =   -1  'True
   WhatsThisHelp   =   -1  'True
   Begin VB.CheckBox chkAllowEdit 
      Caption         =   "Allow Page Editing"
      Height          =   330
      Left            =   3870
      TabIndex        =   12
      Top             =   2925
      Width           =   1905
   End
   Begin VB.CommandButton EditButton 
      Caption         =   "&Edit"
      Enabled         =   0   'False
      Height          =   375
      Left            =   5490
      TabIndex        =   11
      Top             =   2430
      Width           =   1100
   End
   Begin VB.CheckBox chkDetailLog 
      Caption         =   "Detailed Log"
      Height          =   330
      Left            =   3240
      TabIndex        =   10
      Top             =   3330
      Width           =   1275
   End
   Begin VB.CheckBox chkLog 
      Caption         =   "Log Progress"
      Height          =   330
      Left            =   1845
      TabIndex        =   9
      Top             =   3330
      Value           =   1  'Checked
      Width           =   1320
   End
   Begin VB.CheckBox chkAllowFtp 
      Caption         =   "Allow FTP Transfers"
      Height          =   330
      Left            =   1845
      TabIndex        =   4
      Top             =   2925
      Width           =   1905
   End
   Begin VB.CommandButton RemoveButton 
      Caption         =   "&Remove"
      Height          =   375
      Left            =   5490
      TabIndex        =   3
      Top             =   1215
      Width           =   1100
   End
   Begin VB.CommandButton AddButton 
      Caption         =   "&Add"
      Height          =   375
      Left            =   5490
      TabIndex        =   2
      Top             =   765
      Width           =   1100
   End
   Begin VB.ListBox lstTemplates 
      Height          =   2010
      Left            =   1845
      MultiSelect     =   2  'Extended
      TabIndex        =   1
      Top             =   765
      Width           =   3480
   End
   Begin VB.TextBox txtDescription 
      Height          =   330
      Left            =   1845
      TabIndex        =   0
      Top             =   225
      Width           =   4740
   End
   Begin VB.CommandButton CancelButton 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   4635
      TabIndex        =   6
      Top             =   3780
      Width           =   1000
   End
   Begin VB.CommandButton OKButton 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   375
      Left            =   5715
      TabIndex        =   5
      Top             =   3780
      Width           =   1000
   End
   Begin VB.Label Label2 
      Caption         =   "Templates"
      Height          =   285
      Left            =   810
      TabIndex        =   8
      Top             =   810
      Width           =   915
   End
   Begin VB.Label Label1 
      Caption         =   "Project Description"
      Height          =   285
      Left            =   270
      TabIndex        =   7
      Top             =   270
      Width           =   1455
   End
End
Attribute VB_Name = "frmProperties"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit

Private Sub Form_Activate()

    'Save the current project data.  This data will be restored if the user
    'presses the cancel button in the project properties dialog.
  
    'Save project description
    SaveDescription = txtDescription.Text
    
    'Save the number of templates in the list
    SaveTemplateCount = lstTemplates.ListCount
    
    'Save array of template file names
    Dim c As Integer
    ReDim SaveTemplates(SaveTemplateCount)
    For c = 0 To lstTemplates.ListCount - 1
        SaveTemplates(c) = lstTemplates.List(c)
    Next

    'Save the Allow FTP flag
    SaveAllowFtp = chkAllowFtp.Value
    
    'Save the Allow Edit flag
    SaveAllowEdit = chkAllowEdit.Value

    'Save Log Progress flag
    SaveLog = chkLog.Value

    'Save the detailed FTP log flag
    SaveDetailLog = chkDetailLog.Value

    'Enable or disable the Edit Template button as appropriate
    EditButton.Enabled = CBool((ToolEditor <> "") And (chkAllowEdit.Value = 1))

End Sub

Private Sub CancelButton_Click()

    'Restore the saved project settings
  
    'Restore project description
    txtDescription.Text = SaveDescription
    
    'Restore templates list
    lstTemplates.Clear
    Dim c As Integer
    For c = 0 To SaveTemplateCount - 1
        lstTemplates.AddItem SaveTemplates(c)
    Next
    
    'Restore allow FTP flag
    chkAllowFtp.Value = SaveAllowFtp
    
    'Restore allow Edit flag
    chkAllowEdit.Value = SaveAllowEdit
    
    'Restore log flag
    chkLog.Value = SaveLog
    
    'Restore detailed log flag
    chkDetailLog.Value = SaveDetailLog
    
    Me.Hide

End Sub

Private Sub OKButton_Click()

    If txtDescription.Text = "" Or lstTemplates.ListCount = 0 Then
        
        MsgBox "Project must have a description and at least one template!", _
                vbOKOnly + vbInformation, _
                "Incomplete Data"
    Else
        
        'These could be improved.  Really ProjectChanged should only
        'be set to True if the current project data is different from
        'the saved data, and the caption should only be reset if it has
        'changed
        ProjectChanged = True

        Me.Hide
        
    End If

End Sub

Private Sub AddButton_Click()

    With frmMain.dlgCommonDialog
        
        .FileName = ""
        .DialogTitle = "Add Template to Project"
        .CancelError = False
        .Flags = cdlOFNHideReadOnly + cdlOFNFileMustExist + cdlOFNExplorer + cdlOFNPathMustExist
        .Filter = "WebGen Templates (*.wgt)|*.wgt"
     
        .ShowOpen
        
        If Len(.FileName) <> 0 Then
            lstTemplates.AddItem (.FileName)
        End If
    
    End With

End Sub

Private Sub RemoveButton_Click()

    Dim c As Integer

    If lstTemplates.SelCount > 0 Then
        For c = lstTemplates.ListCount - 1 To 0 Step -1
            If lstTemplates.Selected(c) = True Then
                lstTemplates.RemoveItem c
            End If
        Next
    Else
        MsgBox "First select one or more templates to remove", vbOKOnly + vbInformation, "Error"
    End If

End Sub

Private Sub EditButton_Click()

    If lstTemplates.SelCount = 1 Then
        Dim ProcessID As Double
        ProcessID = Shell(ToolEditor & " " & lstTemplates.List(lstTemplates.ListIndex), vbNormalFocus)
    Else
        MsgBox "First select a single templates to edit", vbOKOnly + vbInformation, "Error"
    End If

End Sub

Private Sub lstTemplates_DblClick()

    If ToolEditor <> "" Then
        EditButton_Click
    End If

End Sub

Private Sub chkAllowEdit_Click()

    If ProjectLoading = False Then

        If chkAllowEdit.Value = 1 Then
            
            Dim msg As String
            msg = "If your web uses a Microsoft FrontPage theme then editing the pages" & Chr(13)
            msg = msg & "outside of the Microsoft FrontPage environment is likely to corrupt the" & Chr(13)
            msg = msg & "page content & navigation settings." & Chr(13) & Chr(13)
            msg = msg & "Do you still wish to enable page editing?"
    
            If MsgBox(msg, vbYesNo + vbQuestion + vbDefaultButton2, "Enable Editing") = vbNo Then
                chkAllowEdit.Value = 0
            End If
        End If
    
        'Enable or disable the Edit Template button as appropriate
        EditButton.Enabled = CBool((ToolEditor <> "") And (chkAllowEdit.Value = 1))

    End If

End Sub

Private Sub chkLog_Click()

    If chkLog.Value = 1 Then
        chkDetailLog.Enabled = True
    Else
        chkDetailLog.Enabled = False
        chkDetailLog.Value = 0
    End If

End Sub

