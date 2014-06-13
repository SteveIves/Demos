VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomctl.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "Comdlg32.ocx"
Begin VB.Form frmMain 
   Caption         =   "WebMaster for Synergy/DE"
   ClientHeight    =   6000
   ClientLeft      =   60
   ClientTop       =   630
   ClientWidth     =   8835
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   6000
   ScaleWidth      =   8835
   Begin MSComctlLib.ImageList ToolbarImages 
      Left            =   8100
      Top             =   540
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   23
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":1272
            Key             =   "LARGE"
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":1384
            Key             =   "SMALL"
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":1496
            Key             =   "LIST"
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":15A8
            Key             =   "DETAIL"
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":16BA
            Key             =   "OPEN"
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":17CC
            Key             =   "NEW"
         EndProperty
         BeginProperty ListImage7 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":18DE
            Key             =   "SAVE"
         EndProperty
         BeginProperty ListImage8 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":19F0
            Key             =   "CUT"
         EndProperty
         BeginProperty ListImage9 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":1B02
            Key             =   "COPY"
         EndProperty
         BeginProperty ListImage10 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":1C14
            Key             =   "PASTE"
         EndProperty
         BeginProperty ListImage11 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":1D26
            Key             =   "DELETE"
         EndProperty
         BeginProperty ListImage12 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":1E38
            Key             =   "FIND"
         EndProperty
         BeginProperty ListImage13 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":1F4A
            Key             =   "HELP"
         EndProperty
         BeginProperty ListImage14 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":205C
            Key             =   "MCR"
         EndProperty
         BeginProperty ListImage15 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":216E
            Key             =   "MAPNET"
         EndProperty
         BeginProperty ListImage16 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":2280
            Key             =   "DISCNET"
         EndProperty
         BeginProperty ListImage17 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":2392
            Key             =   "PRINT"
         EndProperty
         BeginProperty ListImage18 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":24A4
            Key             =   "UNDO"
         EndProperty
         BeginProperty ListImage19 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":25B6
            Key             =   "REDO"
         EndProperty
         BeginProperty ListImage20 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":26C8
            Key             =   "PROPERTIES"
         EndProperty
         BeginProperty ListImage21 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":27DA
            Key             =   "SORTASC"
         EndProperty
         BeginProperty ListImage22 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":28EC
            Key             =   "SORTDESC"
         EndProperty
         BeginProperty ListImage23 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":29FE
            Key             =   "UP"
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.ImageList ImageList2 
      Left            =   7560
      Top             =   4920
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   32
      ImageHeight     =   32
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   20
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":2B10
            Key             =   "ROOT"
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":2C22
            Key             =   "CLOSED"
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":2D34
            Key             =   "OPEN"
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":2E46
            Key             =   "FILE"
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":2F58
            Key             =   "FILE_OPEN"
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":306A
            Key             =   "PROPERTIES"
         EndProperty
         BeginProperty ListImage7 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":317C
            Key             =   "FIELD"
         EndProperty
         BeginProperty ListImage8 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":328E
            Key             =   "FIELD_OPEN"
         EndProperty
         BeginProperty ListImage9 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":33A0
            Key             =   "PROPERTY"
         EndProperty
         BeginProperty ListImage10 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":34B2
            Key             =   "GLOBAL"
         EndProperty
         BeginProperty ListImage11 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":35C4
            Key             =   "GLOBAL_OPEN"
         EndProperty
         BeginProperty ListImage12 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":36D6
            Key             =   "RPS"
         EndProperty
         BeginProperty ListImage13 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":3D10
            Key             =   "RELATION"
         EndProperty
         BeginProperty ListImage14 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":435A
            Key             =   "RELATION_OPEN"
         EndProperty
         BeginProperty ListImage15 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":49A4
            Key             =   "TAG"
         EndProperty
         BeginProperty ListImage16 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":4FEE
            Key             =   "TAG_OPEN"
         EndProperty
         BeginProperty ListImage17 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":5638
            Key             =   "FORMAT"
         EndProperty
         BeginProperty ListImage18 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":57C6
            Key             =   "FORMAT_OPEN"
         EndProperty
         BeginProperty ListImage19 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":5954
            Key             =   "KEY"
         EndProperty
         BeginProperty ListImage20 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":5AE2
            Key             =   "KEY_OPEN"
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.ImageList ImageList1 
      Left            =   7560
      Top             =   4260
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   20
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":5C70
            Key             =   "ROOT"
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":5D82
            Key             =   "CLOSED"
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":5E94
            Key             =   "OPEN"
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":5FA6
            Key             =   "FILE"
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":60B8
            Key             =   "FILE_OPEN"
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":61CA
            Key             =   "PROPERTIES"
         EndProperty
         BeginProperty ListImage7 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":62DC
            Key             =   "FIELD"
         EndProperty
         BeginProperty ListImage8 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":63EE
            Key             =   "FIELD_OPEN"
         EndProperty
         BeginProperty ListImage9 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":6500
            Key             =   "PROPERTY"
         EndProperty
         BeginProperty ListImage10 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":6612
            Key             =   "GLOBAL"
         EndProperty
         BeginProperty ListImage11 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":6724
            Key             =   "GLOBAL_OPEN"
         EndProperty
         BeginProperty ListImage12 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":6836
            Key             =   "RPS"
         EndProperty
         BeginProperty ListImage13 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":6E70
            Key             =   "RELATION"
         EndProperty
         BeginProperty ListImage14 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":74BA
            Key             =   "RELATION_OPEN"
         EndProperty
         BeginProperty ListImage15 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":7B04
            Key             =   "TAG"
         EndProperty
         BeginProperty ListImage16 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":814E
            Key             =   "TAG_OPEN"
         EndProperty
         BeginProperty ListImage17 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":8798
            Key             =   "FORMAT"
         EndProperty
         BeginProperty ListImage18 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":8926
            Key             =   "FORMAT_OPEN"
         EndProperty
         BeginProperty ListImage19 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":8AB4
            Key             =   "KEY"
         EndProperty
         BeginProperty ListImage20 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":8C42
            Key             =   "KEY_OPEN"
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.Toolbar Toolbar 
      Align           =   1  'Align Top
      Height          =   360
      Left            =   0
      TabIndex        =   3
      Top             =   0
      Width           =   8835
      _ExtentX        =   15584
      _ExtentY        =   635
      ButtonWidth     =   609
      ButtonHeight    =   582
      AllowCustomize  =   0   'False
      Appearance      =   1
      Style           =   1
      ImageList       =   "ToolbarImages"
      _Version        =   393216
      BeginProperty Buttons {66833FE8-8583-11D1-B16A-00C0F0283628} 
         NumButtons      =   20
         BeginProperty Button1 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "NEW"
            Object.ToolTipText     =   "New"
            ImageKey        =   "NEW"
         EndProperty
         BeginProperty Button2 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "OPEN"
            Object.ToolTipText     =   "Open"
            ImageKey        =   "OPEN"
         EndProperty
         BeginProperty Button3 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "SAVE"
            Object.ToolTipText     =   "Save"
            ImageKey        =   "SAVE"
         EndProperty
         BeginProperty Button4 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button5 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "CUT"
            Object.ToolTipText     =   "Cut"
            ImageKey        =   "CUT"
         EndProperty
         BeginProperty Button6 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "COPY"
            Object.ToolTipText     =   "Copy"
            ImageKey        =   "COPY"
         EndProperty
         BeginProperty Button7 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "PASTE"
            Object.ToolTipText     =   "Paste"
            ImageKey        =   "PASTE"
         EndProperty
         BeginProperty Button8 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button9 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "UNDO"
            Object.ToolTipText     =   "Undo"
            ImageKey        =   "UNDO"
         EndProperty
         BeginProperty Button10 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "REDO"
            Object.ToolTipText     =   "Redo"
            ImageKey        =   "REDO"
         EndProperty
         BeginProperty Button11 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button12 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "FIND"
            Object.ToolTipText     =   "Find"
            ImageKey        =   "FIND"
         EndProperty
         BeginProperty Button13 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "PROPERTIES"
            Object.ToolTipText     =   "Properties"
            ImageKey        =   "PROPERTIES"
         EndProperty
         BeginProperty Button14 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button15 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "LARGE"
            Object.ToolTipText     =   "View large icons"
            ImageKey        =   "LARGE"
            Style           =   2
         EndProperty
         BeginProperty Button16 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "SMALL"
            Object.ToolTipText     =   "View small icons"
            ImageKey        =   "SMALL"
            Style           =   2
         EndProperty
         BeginProperty Button17 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "LIST"
            Object.ToolTipText     =   "View list"
            ImageKey        =   "LIST"
            Style           =   2
            Value           =   1
         EndProperty
         BeginProperty Button18 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "DETAIL"
            Object.ToolTipText     =   "View detail"
            ImageKey        =   "DETAIL"
            Style           =   2
         EndProperty
         BeginProperty Button19 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button20 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "HELP"
            Object.ToolTipText     =   "Help"
            ImageKey        =   "HELP"
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.StatusBar StatusBar 
      Align           =   2  'Align Bottom
      Height          =   330
      Left            =   0
      TabIndex        =   2
      Top             =   5670
      Width           =   8835
      _ExtentX        =   15584
      _ExtentY        =   582
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   3
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            AutoSize        =   1
            Object.Width           =   5001
            Text            =   "Project: None"
            TextSave        =   "Project: None"
            Key             =   "DESCRIPTION"
            Object.ToolTipText     =   "Displays the description of the current project"
         EndProperty
         BeginProperty Panel2 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            AutoSize        =   1
            Object.Width           =   5001
            Text            =   "File: None"
            TextSave        =   "File: None"
            Key             =   "FILE"
            Object.ToolTipText     =   "Displays the name of the current project file"
         EndProperty
         BeginProperty Panel3 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            AutoSize        =   1
            Object.Width           =   5001
            Text            =   "Server: None"
            TextSave        =   "Server: None"
            Key             =   "SERVER"
            Object.ToolTipText     =   "Displays the name and port of the associated Synergy server"
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.ListView List 
      Height          =   3495
      Left            =   4620
      TabIndex        =   1
      Top             =   1320
      Width           =   2355
      _ExtentX        =   4154
      _ExtentY        =   6165
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      FullRowSelect   =   -1  'True
      GridLines       =   -1  'True
      _Version        =   393217
      Icons           =   "ImageList2"
      SmallIcons      =   "ImageList1"
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   0
   End
   Begin MSComctlLib.TreeView Tree 
      Height          =   2775
      Left            =   600
      TabIndex        =   0
      Top             =   1260
      Width           =   2895
      _ExtentX        =   5106
      _ExtentY        =   4895
      _Version        =   393217
      Indentation     =   529
      LabelEdit       =   1
      Style           =   7
      ImageList       =   "ImageList1"
      Appearance      =   1
   End
   Begin MSComDlg.CommonDialog dlgCommonDialog 
      Left            =   7380
      Top             =   3660
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Menu mnuFile 
      Caption         =   "&File"
      Begin VB.Menu mnuFileOptions 
         Caption         =   "&New..."
         Index           =   0
         Shortcut        =   ^N
      End
      Begin VB.Menu mnuFileOptions 
         Caption         =   "&Open..."
         Index           =   1
         Shortcut        =   ^O
      End
      Begin VB.Menu mnuFileOptions 
         Caption         =   "&Close"
         Enabled         =   0   'False
         Index           =   2
      End
      Begin VB.Menu mnuFileOptions 
         Caption         =   "-"
         Index           =   3
      End
      Begin VB.Menu mnuFileOptions 
         Caption         =   "&Save"
         Enabled         =   0   'False
         Index           =   4
         Shortcut        =   ^S
      End
      Begin VB.Menu mnuFileOptions 
         Caption         =   "Save &As..."
         Enabled         =   0   'False
         Index           =   5
      End
      Begin VB.Menu mnuFileOptions 
         Caption         =   "-"
         Index           =   6
      End
      Begin VB.Menu mnuFileOptions 
         Caption         =   "E&xit"
         Index           =   7
         Shortcut        =   ^X
      End
   End
   Begin VB.Menu mnuProject 
      Caption         =   "&Project"
      Enabled         =   0   'False
      Begin VB.Menu mnuProjectOptions 
         Caption         =   "&Generate Page(s)"
         Index           =   0
         Shortcut        =   ^G
      End
      Begin VB.Menu mnuProjectOptions 
         Caption         =   "&Properties"
         Index           =   1
      End
      Begin VB.Menu mnuProjectOptions 
         Caption         =   "Test Synergy &Server"
         Index           =   2
      End
      Begin VB.Menu mnuProjectOptions 
         Caption         =   "Test &Repository Availability"
         Index           =   3
      End
   End
   Begin VB.Menu mnuTree 
      Caption         =   "Tree Options"
      Visible         =   0   'False
      Begin VB.Menu mnuTreeOptions 
         Caption         =   "Expand All"
         Index           =   0
      End
      Begin VB.Menu mnuTreeOptions 
         Caption         =   "Collapse All"
         Index           =   1
      End
      Begin VB.Menu mnuTreeOptions 
         Caption         =   "-"
         Index           =   2
      End
      Begin VB.Menu mnuTreeOptions 
         Caption         =   "Expand Branch"
         Index           =   3
      End
      Begin VB.Menu mnuTreeOptions 
         Caption         =   "Collapse Branch"
         Index           =   4
      End
   End
   Begin VB.Menu mnuView 
      Caption         =   "&View"
      Enabled         =   0   'False
      Begin VB.Menu mnuViewOptions 
         Caption         =   "&Large Icons"
         Index           =   0
      End
      Begin VB.Menu mnuViewOptions 
         Caption         =   "&Small Icons"
         Index           =   1
      End
      Begin VB.Menu mnuViewOptions 
         Caption         =   "Lis&t"
         Checked         =   -1  'True
         Index           =   2
      End
      Begin VB.Menu mnuViewOptions 
         Caption         =   "&Details"
         Index           =   3
      End
      Begin VB.Menu mnuViewOptions 
         Caption         =   "-"
         Index           =   4
         Visible         =   0   'False
      End
      Begin VB.Menu mnuViewOptions 
         Caption         =   "Create Project File"
         Enabled         =   0   'False
         Index           =   5
         Visible         =   0   'False
      End
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private SplitterMoving As Boolean
Private FormLoading As Boolean

'=============================================================================
'   FORM EVENT HANDLERS
'=============================================================================

Private Sub Form_Load()
    
    'Set default location for registry information
    RegPath = "Software\Synergex\" & App.Title
    
    FormLoading = True  'Prevent form resize event messing with the saved layout
    
    Me.Left = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Left", (Screen.Width * 0.1))
    Me.Top = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Top", (Screen.Height * 0.1))
    Me.Width = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Width", (Screen.Width * 0.8))
    Me.Height = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Height", (Screen.Height * 0.8))
    
    With Tree
        .Top = 361
        .Left = 0
        .Width = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "TreeWidth", (ScaleWidth / 2) - 10)
        .Height = ScaleHeight - Toolbar.Height - StatusBar.Height
    End With
    
    With List
        .Top = 361
        .Left = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "ListLeft", (ScaleWidth / 2) + 20)
        .Width = GetSettingLong(HKEY_LOCAL_MACHINE, RegPath, "ListWidth", (ScaleWidth / 2) - 10)
        .Height = ScaleHeight - Toolbar.Height - StatusBar.Height
    End With
    
    FormLoading = False 'Allow formresize event to do its stuff
    
    'Pre-load forms for better performance later
    Load frmDirectory
    Load frmFile
    Load frmGenerate
    Load frmProperties
    
End Sub

Private Sub Form_Resize()

    If Not FormLoading Then

        With Tree
            'Change tree height
            If (ScaleHeight - Toolbar.Height - StatusBar.Height) > 0 Then
                .Height = (ScaleHeight - Toolbar.Height - StatusBar.Height)
            End If
        End With
    
        With List
            'Change list height
            If (ScaleHeight - Toolbar.Height - StatusBar.Height) > 0 Then
                .Height = (ScaleHeight - Toolbar.Height - StatusBar.Height)
            End If
            'Change list width
            If ((ScaleWidth - Tree.Width) - 20) > 0 Then
                .Width = (ScaleWidth - Tree.Width) - 20
            End If
        End With
    
    End If

End Sub

Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    If SplitterMoving Then
    
        With Tree
            If (X > 1000) And (X < (ScaleWidth - 1000)) Then .Width = X - 10
        End With
    
        With List
            If (X > 1000) And (X < (ScaleWidth - 1000)) Then
                .Left = X + 10
                .Width = ScaleWidth - X - 20
            End If
        End With
    
    Else
        MousePointer = vbSizeWE
    End If

End Sub

Private Sub Form_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)

    SplitterMoving = True

End Sub

Private Sub Form_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)

    SplitterMoving = False

End Sub

Private Sub Form_Unload(Cancel As Integer)

    If Project.IsOpen Then
        Call CloseProject
    End If
    
    Set Project = Nothing
    Set Repository = Nothing

    End

End Sub

'=============================================================================
'   FILE MENU EVENT HANDLERS
'=============================================================================

Private Sub mnuFileOptions_Click(Index As Integer)

    Select Case Index
    
    Case 0  'File/New
        Call NewProject
    Case 1  'File/Open
        Call OpenProject
    Case 2  'File/Close
        Call CloseProject
    Case 4  'File/Save
        Call SaveProject
    Case 5  'File/Save As
        Call SaveProjectAs
    Case 7  'File/Exit
        'Save main window layout in registry
        If Me.WindowState <> vbMinimized Then
            Call SaveSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Left", Me.Left)
            Call SaveSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Top", Me.Top)
            Call SaveSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Width", Me.Width)
            Call SaveSettingLong(HKEY_LOCAL_MACHINE, RegPath, "Height", Me.Height)
            Call SaveSettingLong(HKEY_LOCAL_MACHINE, RegPath, "TreeWidth", Tree.Width)
            Call SaveSettingLong(HKEY_LOCAL_MACHINE, RegPath, "ListLeft", List.Left)
            Call SaveSettingLong(HKEY_LOCAL_MACHINE, RegPath, "ListWidth", List.Width)
        End If
        Unload frmMain
    End Select

End Sub

'=============================================================================
'   PROJECT MENU EVENT HANDLERS
'=============================================================================

Private Sub mnuProjectOptions_Click(Index As Integer)

    Select Case Index
    Case 0  'Project/Generate
        frmGenerate.Show vbModal, frmMain
    Case 1  'Project/Properties
        Call ProjectProperties
    Case 2  'Project/Test Synergy Server
        Call TestSynergyServer(Project.Server, Project.Port, True, frmMain)
    Case 3  'Project/Test Repository
        With Project
            Call TestRepository(.Server, .Port, .RpsMainFile, .RpsTextFile, True, frmMain)
        End With
    End Select

End Sub

'=============================================================================
'   VIEW MENU EVENT HANDLERS
'=============================================================================

Private Sub mnuViewOptions_Click(Index As Integer)

    Select Case Index
    Case 0  'View/Large Icons
        Call SwitchListView(lvwIcon)
    Case 1  'View/Small Icons
        Call SwitchListView(lvwSmallIcon)
    Case 2  'View/List
        Call SwitchListView(lvwList)
    Case 3  'View/Detail
        Call SwitchListView(lvwReport)
    Case 5  'Create Project File
        frmFile.Show vbModal, frmMain
    End Select

End Sub


'=============================================================================
'   TREE EVENT HANDLERS
'=============================================================================

Private Sub Tree_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    MousePointer = vbDefault

End Sub

Private Sub Tree_NodeClick(ByVal Node As MSComctlLib.Node)

    With List
        .ListItems.Clear
        .ColumnHeaders.Clear
        .MultiSelect = False
        Call SwitchListView(lvwList)
    End With

    If Node.Key = "PRJPROP" Then                    'Project properties
        Call ListProperties
    
    ElseIf (Left(Node.Key, 7) = "PRJFIL:") Then     'Specific project file
        Call ListFields
    
    ElseIf (Left(Node.Key, 7) = "RPSSTR:") Then
        Call ListStructure
    
    ElseIf (Left(Node.Key, 8) = "STRFLDS:") Then    'Structure fields
        List.MultiSelect = True
        Call ListFields
    
    ElseIf (Left(Node.Key, 7) = "PRJFLD:") _
        Or (Left(Node.Key, 7) = "STRFLD:") Then     'Specific field
            Call ListFieldProperties
    
    Else
        Call ListChildren
    
    End If

End Sub

Private Sub Tree_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)

    If Button = vbRightButton Then
    
        If Tree.Nodes.Count > 0 Then
            PopupMenu mnuTree
        End If
    
    End If

End Sub

Private Sub mnuTreeOptions_Click(Index As Integer)

    Dim Node As Node, c As Long

    Select Case Index
    Case 0  'Expand all
        For Each Node In Tree.Nodes
            Node.Expanded = True
        Next Node
    Case 1  'Collapse all
        For Each Node In Tree.Nodes
            Node.Expanded = False
        Next Node
    Case 3  'Expand Branch
        With Tree
            If .SelectedItem.Children > 0 Then
                
                For c = .SelectedItem.Child.Index To .SelectedItem.Child.LastSibling.Index
                    .Nodes(c).Expanded = True
                Next c
                .SelectedItem.Expanded = True
            End If
        End With
    Case 4  'Collapse branch
        With Tree
            If .SelectedItem.Children > 0 Then
                For c = .SelectedItem.Child.Index To .SelectedItem.Child.LastSibling.Index
                    .Nodes(c).Expanded = False
                Next c
                .SelectedItem.Expanded = False
            End If
        End With
    End Select

End Sub

'=============================================================================
'   LIST EVENT HANDLERS
'=============================================================================

Private Sub List_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    MousePointer = vbDefault

End Sub

Private Sub List_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)

    If Button = vbRightButton Then
        If Left(Tree.SelectedItem.Key, 8) = "STRFLDS:" Then
            With mnuViewOptions(5)
                .Enabled = True
                .Visible = True
            End With
        End If
        PopupMenu mnuView
        If Left(Tree.SelectedItem.Key, 8) = "STRFLDS:" Then
            With mnuViewOptions(5)
                .Enabled = False
                .Visible = False
            End With
        End If
    End If

End Sub

Private Sub List_DblClick()

    On Error GoTo done

    With Tree.Nodes(List.SelectedItem.Key)
        .Expanded = True
        .EnsureVisible
        .Selected = True
    End With

    With Tree
        .SetFocus
        Call Tree_NodeClick(.SelectedItem)
    End With

done:

End Sub

Private Sub List_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)

    Select Case ColumnHeader.Key
    Case "PROPERTY"
        List.SortKey = 0
    Case "VALUE"
        List.SortKey = 1
    End Select

    If List.Sorted = False Then
        List.Sorted = True
        List.SortOrder = lvwAscending
    Else
        If List.SortOrder = lvwAscending Then
            List.SortOrder = lvwDescending
        Else
            List.SortOrder = lvwAscending
        End If
    End If
    
End Sub

'=============================================================================
'   TOOLBAR EVENT HANDLERS
'=============================================================================

Private Sub Toolbar_ButtonClick(ByVal Button As MSComctlLib.Button)

    Select Case Button.Key
    
    Case "NEW"
        Call NewProject
    Case "OPEN"
        Call OpenProject
    Case "SAVE"
        Call SaveProject
    Case "PROPERTIES"
        Call ProjectProperties
    Case "LARGE"
        Call SwitchListView(lvwIcon)
    Case "SMALL"
        Call SwitchListView(lvwSmallIcon)
    Case "LIST"
        Call SwitchListView(lvwList)
    Case "DETAIL"
        Call SwitchListView(lvwReport)
    End Select
    
End Sub

Private Sub Toolbar_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    MousePointer = vbDefault

End Sub


'=============================================================================
'   STATUSBAR EVENT HANDLERS
'=============================================================================

Private Sub StatusBar_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    MousePointer = vbDefault

End Sub

'=============================================================================
'   UTILITY METHODS
'=============================================================================

Private Sub NewProject()

    On Error Resume Next
    If Project.IsOpen Then
        Call CloseProject
    End If
    On Error GoTo 0

    Set Project = New Project
    
    frmProperties.Show vbModal, frmMain

    If Project.IsOpen Then
        Call LoadRepository
        Call LoadTree
    End If

    Call SetupUi

End Sub

Private Sub OpenProject()

    On Error Resume Next
    If Project.IsOpen Then
       Call CloseProject
    End If
    On Error GoTo 0

    Set Project = New Project
    
    'Get file name
    With dlgCommonDialog
        
        .FileName = ""
        .DialogTitle = "Open Project"
        .CancelError = False
        .Flags = &H1004&
        .Filter = "Project Files (*.wpj)|*.wpj"
        .ShowOpen

        If Len(.FileName) <> 0 Then
            Project.OpenExisting (.FileName)
        End If

    End With
    
    frmMain.Refresh
    
    If Project.IsOpen Then
        Call LoadRepository
        Call LoadTree
    End If
    
    Call SetupUi

End Sub

Private Sub LoadTree()

    Dim File As ProjectFile
    Dim Field As ProjectFileField
    
    Dim Str As Structure
    Dim Fld As Field

    With Tree.Nodes
        
        .Add , , "ROOT", "Webmaster Workspace", "ROOT", "ROOT"
        
        'Load project details into tree
        
        .Add "ROOT", tvwChild, "PRJ", Project.Description, "ROOT", "ROOT"
        
        .Add "PRJ", tvwChild, "PRJFILS", "Files", "CLOSED", "OPEN"
        .Add "PRJ", tvwChild, "PRJPROP", "Properties", "PROPERTIES", "PROPERTIES"
    
        For Each File In Project.ProjectFiles
            If File.FileName = "global.asa" Then
                .Add "PRJFILS", tvwChild, "PRJFIL:" & File.FileName, File.FileName, "GLOBAL", "GLOBAL_OPEN"
            Else
                .Add "PRJFILS", tvwChild, "PRJFIL:" & File.FileName, File.FileName, "FILE", "FILE_OPEN"
            End If
            For Each Field In File.ProjectFileFields
                .Add "PRJFIL:" & File.FileName, tvwChild, "PRJFLD:" & File.FileName & ":" & Field.FieldName, Field.FieldName, "FIELD", "FIELD_OPEN"
            Next Field
        Next File
    
        'Load RPS details into tree
    
        .Add "ROOT", tvwChild, "RPS", "Repository", "RPS", "RPS"
        
        .Add "RPS", tvwChild, "RPSSTRS", "Structures", "CLOSED", "OPEN"
        .Add "RPS", tvwChild, "RPSFILS", "Files", "CLOSED", "OPEN"
        .Add "RPS", tvwChild, "RPSFMTS", "Formats", "CLOSED", "OPEN"
        .Add "RPS", tvwChild, "RPSTPLS", "Templates", "CLOSED", "OPEN"
    
        'Structures
        For Each Str In Repository.Structures
            
            .Add "RPSSTRS", tvwChild, "RPSSTR:" & Str.StructureName, Str.StructureName, "CLOSED", "OPEN"
        
            'Fields
            .Add "RPSSTR:" & Str.StructureName, tvwChild, "STRFLDS:" & Str.StructureName, "Fields", "FIELD", "FIELD_OPEN"
            For Each Fld In Str.Fields
                .Add "STRFLDS:" & Str.StructureName, tvwChild, "STRFLD:" & Str.StructureName & ":" & Fld.FieldName, Fld.FieldName, "FIELD", "FIELD_OPEN"
            Next Fld
            
            'Keys
            .Add "RPSSTR:" & Str.StructureName, tvwChild, "STRKEYS:" & Str.StructureName, "Keys", "KEY", "KEY_OPEN"
            
            'Relations
            .Add "RPSSTR:" & Str.StructureName, tvwChild, "STRRELS:" & Str.StructureName, "Relations", "RELATION", "RELATION_OPEN"
            
            'Formats
            .Add "RPSSTR:" & Str.StructureName, tvwChild, "STRFMTS:" & Str.StructureName, "Formats", "FORMAT", "FORMAT_OPEN"
            
            'Tags
            .Add "RPSSTR:" & Str.StructureName, tvwChild, "STRTAGS:" & Str.StructureName, "Tags", "TAG", "TAG_OPEN"
        
        
        Next Str
    
    End With
    
    Call mnuTreeOptions_Click(1)
   
    With Tree.Nodes("PRJ")
        .EnsureVisible
        .Selected = True
        .Expanded = True
    End With
    
    Tree.SetFocus
  
End Sub

Private Sub SaveProject()

    If Project.File <> "" Then
        Project.Save
    Else
        Call SaveProjectAs
    End If
    
    Call SetupUi

End Sub


Private Sub SaveProjectAs()

    If Project.IsOpen Then
    
        'Get new file name
        With frmMain.dlgCommonDialog

            .FileName = ""
            .DialogTitle = "Save Project As"
            .CancelError = False
            .Flags = &H2004&    'This should cause the common dialog to prevent
                                'the selection of an existing file, but it doesn't
                                'seem to work!!!
            .Filter = "Project Files (*.wpj)|*.wpj"
            .InitDir = App.Path

            .ShowOpen

            If Len(.FileName) > 1 Then
                Project.File = .FileName
                Project.Save
            End If

        End With
        
        Call SetupUi
    
    End If

End Sub


Private Sub CloseProject()

    If Project.IsOpen Then
        
        If Project.Changed Then
            If MsgBox("Project settings have changed. Save changes?", vbYesNo + vbDefaultButton1 + vbQuestion, "Close Project") = vbYes Then
                Call SaveProject
            End If
        End If
        
        Project.Reset

        Call SetupUi
    
        Set Project = Nothing
    
    End If

End Sub

Private Sub ProjectProperties()

    If Project.IsOpen Then
    
        frmProperties.Show vbModal, frmMain

        Call SetupUi
    
    End If

End Sub

Private Sub SetupUi()

    With frmMain
        
        .mnuFileOptions(2).Enabled = Project.IsOpen   'Enable File/Close
        .mnuFileOptions(4).Enabled = Project.IsOpen   'Enable File/Save
        .mnuFileOptions(5).Enabled = Project.IsOpen   'Enable File/Save As
        .mnuProject.Enabled = Project.IsOpen          'Enable Project menu
        .mnuView.Enabled = Project.IsOpen             'Enable View menu
        
        With Toolbar
            .Buttons("SAVE").Enabled = Project.IsOpen
            .Buttons("PROPERTIES").Enabled = Project.IsOpen
            .Buttons("LARGE").Enabled = Project.IsOpen
            .Buttons("SMALL").Enabled = Project.IsOpen
            .Buttons("LIST").Enabled = Project.IsOpen
            .Buttons("DETAIL").Enabled = Project.IsOpen
        End With
        
        Select Case Project.IsOpen
        
        Case True
            
            With StatusBar
                .Panels("DESCRIPTION").Text = "Project: " & Project.Description
                .Panels("FILE").Text = "File: " & Project.File
                .Panels("SERVER").Text = "Server: " & Project.Server & ":" & Project.Port
            End With
        
        Case False
            
            With StatusBar
                .Panels("DESCRIPTION").Text = "Project: None"
                .Panels("FILE").Text = "File: None"
                .Panels("SERVER").Text = "Server: None"
            End With
            
            Tree.Nodes.Clear
            List.ListItems.Clear
            Call SwitchListView(lvwList)
        
        End Select
    
    End With

End Sub

Private Sub LoadRepository()

    If Project.IsOpen Then
    
        frmMain.MousePointer = vbHourglass
    
        Set Repository = New Repository
        With Repository
            .Description = "Repository"
            .Server = Project.Server
            .Port = Project.Port
            .MainFile = Project.RpsMainFile
            .TextFile = Project.RpsTextFile
            .Connect
            .Download
            .Disconnect
        End With
    
        frmMain.MousePointer = vbDefault

    End If

End Sub
