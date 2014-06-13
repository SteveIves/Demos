VERSION 5.00
Begin VB.Form frmProperties 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Project Properties"
   ClientHeight    =   5400
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   7935
   Icon            =   "frmProperties.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5400
   ScaleWidth      =   7935
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.TextBox Olb 
      Height          =   315
      Left            =   1680
      TabIndex        =   11
      Top             =   2460
      Width           =   5475
   End
   Begin VB.TextBox Elb 
      Height          =   315
      Left            =   1680
      TabIndex        =   12
      Top             =   2820
      Width           =   5475
   End
   Begin VB.CommandButton RpsTfilDrill 
      Caption         =   "..."
      Height          =   315
      Left            =   7140
      TabIndex        =   10
      Top             =   2100
      Width           =   315
   End
   Begin VB.CommandButton RpsMfilDrill 
      Caption         =   "..."
      Height          =   315
      Left            =   7140
      TabIndex        =   8
      Top             =   1740
      Width           =   315
   End
   Begin VB.CommandButton SynDirDrill 
      Caption         =   "..."
      Height          =   315
      Left            =   7140
      TabIndex        =   4
      Top             =   1020
      Width           =   315
   End
   Begin VB.CommandButton WebDirDrill 
      Caption         =   "..."
      Height          =   315
      Left            =   7140
      TabIndex        =   2
      Top             =   600
      Width           =   315
   End
   Begin VB.TextBox RpsTfil 
      Height          =   315
      Left            =   1680
      TabIndex        =   9
      Top             =   2100
      Width           =   5475
   End
   Begin VB.TextBox RpsMfil 
      Height          =   315
      Left            =   1680
      TabIndex        =   7
      Top             =   1740
      Width           =   5475
   End
   Begin VB.TextBox Port 
      Height          =   315
      Left            =   6120
      TabIndex        =   6
      Top             =   1380
      Width           =   1035
   End
   Begin VB.TextBox Server 
      Height          =   315
      Left            =   1680
      TabIndex        =   5
      Top             =   1380
      Width           =   3615
   End
   Begin VB.TextBox SynDir 
      Height          =   315
      Left            =   1680
      TabIndex        =   3
      Top             =   1020
      Width           =   5475
   End
   Begin VB.TextBox WebDir 
      Height          =   315
      Left            =   1680
      TabIndex        =   1
      Top             =   600
      Width           =   5475
   End
   Begin VB.TextBox Description 
      Height          =   315
      Left            =   1680
      TabIndex        =   0
      Top             =   180
      Width           =   5475
   End
   Begin VB.CommandButton CancelButton 
      Cancel          =   -1  'True
      Caption         =   "&Cancel"
      Height          =   375
      Left            =   5340
      TabIndex        =   13
      Top             =   4860
      Width           =   1215
   End
   Begin VB.CommandButton OKButton 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   375
      Left            =   6600
      TabIndex        =   14
      Top             =   4860
      Width           =   1215
   End
   Begin VB.Label Label1 
      Caption         =   "Project OLB"
      Height          =   255
      Index           =   8
      Left            =   180
      TabIndex        =   23
      Top             =   2520
      Width           =   1395
   End
   Begin VB.Label Label1 
      Caption         =   "Project ELB"
      Height          =   255
      Index           =   7
      Left            =   180
      TabIndex        =   22
      Top             =   2880
      Width           =   1395
   End
   Begin VB.Label Label1 
      Caption         =   "RPS Text File"
      Height          =   255
      Index           =   6
      Left            =   180
      TabIndex        =   21
      Top             =   2160
      Width           =   1395
   End
   Begin VB.Label Label1 
      Caption         =   "RPS Main File"
      Height          =   255
      Index           =   5
      Left            =   180
      TabIndex        =   20
      Top             =   1800
      Width           =   1395
   End
   Begin VB.Label Label1 
      Caption         =   "Port"
      Height          =   255
      Index           =   4
      Left            =   5580
      TabIndex        =   19
      Top             =   1440
      Width           =   495
   End
   Begin VB.Label Label1 
      Caption         =   "Server"
      Height          =   255
      Index           =   3
      Left            =   180
      TabIndex        =   18
      Top             =   1440
      Width           =   1395
   End
   Begin VB.Label Label1 
      Caption         =   "Synergy Directory"
      Height          =   255
      Index           =   2
      Left            =   180
      TabIndex        =   17
      Top             =   1080
      Width           =   1395
   End
   Begin VB.Label Label1 
      Caption         =   "Web Directory"
      Height          =   255
      Index           =   1
      Left            =   180
      TabIndex        =   16
      Top             =   660
      Width           =   1395
   End
   Begin VB.Label Label1 
      Caption         =   "Description"
      Height          =   255
      Index           =   0
      Left            =   180
      TabIndex        =   15
      Top             =   240
      Width           =   1395
   End
End
Attribute VB_Name = "frmProperties"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    
    Icon = frmMain.Icon

End Sub

Private Sub Form_Activate()

    'Load current project data into form fields for amending
    With Project
        If .File = "" Then
            Caption = "New Project Properties"
        Else
            Caption = "Project Properties"
        End If
        Description.Text = .Description
        WebDir.Text = .WebDir
        SynDir.Text = .SynergyDir
        Server.Text = .Server
        Port.Text = .Port
        RpsMfil.Text = .RpsMainFile
        RpsTfil.Text = .RpsTextFile
        Olb.Text = .Olb
        Elb.Text = .Elb
    End With

End Sub

Private Sub OKButton_Click()

    If (SaveProjectData) Then Me.Hide

End Sub

Private Sub CancelButton_Click()

    Me.Hide

End Sub

Private Function SaveProjectData() As Boolean

    Dim ErrorText As String, Errors As Integer, ServerSuccess As Boolean
    
    'First validate that data is appropriate
    
    ErrorText = "Please resolve the following:"
    
    If Description.Text = "" Then
        ErrorText = ErrorText & vbCrLf & " - You must provide a project description"
        Errors = Errors + 1
    End If
    
    If WebDir.Text = "" Then
        ErrorText = ErrorText & vbCrLf & " - You must provide a web directory"
        Errors = Errors + 1
    End If
    
    If SynDir.Text = "" Then
        ErrorText = ErrorText & vbCrLf & " - You must provide a Synergy directory"
        Errors = Errors + 1
    End If
    
    If Server.Text = "" Then
        ErrorText = ErrorText & vbCrLf & " - You must provide a server name or IP address"
        Errors = Errors + 1
    End If
    
    If Port.Text = "" Then
        ErrorText = ErrorText & vbCrLf & " - You must provide a server port number between 1025 and 65535"
        Errors = Errors + 1
    Else
        If IsNumeric(Port.Text) Then
            If CLng(Port.Text) < 1025 Or CLng(Port.Text) > 65535 Then
                ErrorText = ErrorText & vbCrLf & " - Port number must be in the range 1025 to 65535"
                Errors = Errors + 1
            End If
        Else
            ErrorText = ErrorText & vbCrLf & " - Port number must be a number between 1025 and 65535"
            Errors = Errors + 1
        End If
    End If
    
    If RpsMfil.Text = "" Then
        ErrorText = ErrorText & vbCrLf & " - You must provide a Repository main file"
        Errors = Errors + 1
    Else
        If Dir(RpsMfil.Text) = "" Then
            ErrorText = ErrorText & vbCrLf & " - The Repository main file does not exist"
            Errors = Errors + 1
        End If
    End If
    
    If RpsTfil.Text = "" Then
        ErrorText = ErrorText & vbCrLf & " - You must provide a Repository text file"
        Errors = Errors + 1
    Else
        If Dir(RpsTfil.Text) = "" Then
            ErrorText = ErrorText & vbCrLf & " - The Repository text file does not exist"
            Errors = Errors + 1
        End If
    End If
    
    If Olb.Text = "" Then
        ErrorText = ErrorText & vbCrLf & " - You must provide an object library name"
        Errors = Errors + 1
    Else
        LCase Olb.Text
        If InStr(1, Olb.Text, ".olb") = 0 Then
            Olb.Text = Olb.Text & ".olb"
        End If
    End If
    
    If Elb.Text = "" Then
        ErrorText = ErrorText & vbCrLf & " - You must provide an executable library name"
        Errors = Errors + 1
    Else
        LCase Elb.Text
        If InStr(1, Elb.Text, ".elb") = 0 Then
            Elb.Text = Elb.Text & ".elb"
        End If
    End If
    
    'Validate that we can talk to the nominated Synergy server
    If TestSynergyServer(Server.Text, CLng(Port.Text), False, frmProperties) Then
        ServerSuccess = True
    Else
        ErrorText = ErrorText & vbCrLf & " - Failed to connect to Synergy server.  Verify server and port."
        Errors = Errors + 1
        Server.Text = ""
        Port.Text = ""
        Server.SetFocus
    End If
    
    'Validate that we can reach the specified Repository
    If ServerSuccess Then
        If Not TestRepository(Server.Text, CLng(Port.Text), RpsMfil.Text, RpsTfil.Text, False, frmProperties) Then
            ErrorText = ErrorText & vbCrLf & " - Failed to validate Synergy Repository.  Verify main and text files."
            Errors = Errors + 1
            RpsMfil.SetFocus
        End If
    End If
    
    If Errors Then
        MsgBox ErrorText, vbExclamation, "Project Errors"
    Else
        
        'Store project config to project variables, if changed
        With Project
            
            If .Description <> Description.Text Then
                .Description = Description.Text
            End If
            
            If .WebDir <> WebDir.Text Then
                .WebDir = WebDir.Text
            End If
            
            If .SynergyDir <> SynDir.Text Then
                .SynergyDir = SynDir.Text
            End If
            
            If .Server <> Server.Text Then
                .Server = Server.Text
            End If
            
            If .Port <> CLng(Port.Text) Then
                .Port = CLng(Port.Text)
            End If
            
            If .RpsMainFile <> RpsMfil.Text Then
                .RpsMainFile = RpsMfil.Text
            End If
            
            If .RpsTextFile <> RpsTfil.Text Then
                .RpsTextFile = RpsTfil.Text
            End If
            
            .IsOpen = True

        End With
    
        'If the main window is currently viewing project settings
        'then update the list display with the new settings
        Call ListProperties
    
        SaveProjectData = True
    
    End If
    
End Function

Private Sub WebDirDrill_Click()

    With frmDirectory
        .DirSelect1.Directory = WebDir.Text
        .Show vbModal, frmProperties
        If .DirSelect1.Directory <> "" Then
            WebDir.Text = .DirSelect1.Directory
        End If
    End With

End Sub

Private Sub SynDirDrill_Click()

    frmDirectory.Show vbModal, frmProperties

End Sub

Private Sub RpsMfilDrill_Click()

    'Get file name
    With frmMain.dlgCommonDialog
        .FileName = RpsMfil.Text
        .DialogTitle = "Select Repository Main File"
        .CancelError = False
        .Flags = &H1004&
        .Filter = "Repository Main Files (rpsmain.ism)|rpsmain.ism"
        .ShowOpen
        If Len(.FileName) <> 0 Then
            RpsMfil.Text = .FileName
        End If
    End With

End Sub


Private Sub RpsTfilDrill_Click()

    'Get file name
    With frmMain.dlgCommonDialog
        .FileName = RpsMfil.Text
        .DialogTitle = "Select Repository Text File"
        .CancelError = False
        .Flags = &H1004&
        .Filter = "Repository Text Files (rpstext.ism)|rpstext.ism"
        .ShowOpen
        If Len(.FileName) <> 0 Then
            RpsTfil.Text = .FileName
        End If
    End With

End Sub


Private Sub SelectFieldContents(Field As Object)

    With Field
        .SelStart = 0
        .SelLength = Len(.Text)
    End With

End Sub

Private Sub Description_GotFocus()

    Call SelectFieldContents(Description)

End Sub

Private Sub WebDir_GotFocus()

    Call SelectFieldContents(WebDir)

End Sub

Private Sub SynDir_GotFocus()

    Call SelectFieldContents(SynDir)

End Sub

Private Sub Server_GotFocus()

    Call SelectFieldContents(Server)

End Sub

Private Sub Server_LostFocus()

    Server.Text = UCase(Server.Text)

End Sub

Private Sub Port_GotFocus()

    Call SelectFieldContents(Port)

End Sub

Private Sub RpsMfil_GotFocus()

    Call SelectFieldContents(RpsMfil)

End Sub

Private Sub RpsTfil_GotFocus()

    Call SelectFieldContents(RpsTfil)

End Sub

