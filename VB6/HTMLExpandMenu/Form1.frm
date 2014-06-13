VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   7965
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   8415
   LinkTopic       =   "Form1"
   ScaleHeight     =   7965
   ScaleWidth      =   8415
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text2 
      Height          =   495
      Left            =   4560
      TabIndex        =   2
      Text            =   "Text2"
      Top             =   240
      Width           =   2775
   End
   Begin VB.TextBox Text1 
      Height          =   6735
      Left            =   120
      MultiLine       =   -1  'True
      ScrollBars      =   3  'Both
      TabIndex        =   1
      Text            =   "Form1.frx":0000
      Top             =   960
      Width           =   7335
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   495
      Left            =   1440
      TabIndex        =   0
      Top             =   240
      Width           =   2415
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Command1_Click()

Set obj = CreateObject("HTMLExpandMenu.TreeMenu")

Text1.Text = obj.DisplayMenu(CStr(Text2.Text), "1", "0", "Home Page", "home.htm", _
        "1", "1", "Corporate Information", "corporate.htm", "2", "0", "Introduction", "corp_intro.htm", _
        "2", "0", "History and profile", "corp_hist.htm", "2", "1", "Office locations", "corp_loc.htm", "3", "0", "Directions", "corp_dir.htm", _
        "3", "0", "Parking reservations", "corp_resv.htm", "2", "0", "Contact details", "corp_det.htm", "2", "0", "Staff details", "corp_staff.htm", _
        "1", "1", "Financial Services", "financial.htm", "2", "0", "Phase I", "fir_p1.htm", _
        "2", "0", "Phase II", "fir_p2.htm", "2", "0", "Phase III", "fir_p3.htm", _
        "2", "0", "Investigative services", "fir_inv.htm", "2", "0", "LATIMAR", "fir_lat.htm", _
        "2", "0", "<i>Epic 2</i>", "fir_epic.htm", "2", "0", "Local taxation", "fir_loctax.htm", _
        "2", "0", "ACCUMULATOR computer system", "fir_acc.htm", "2", "0", "Debt evaluation scorecards", "fir_debt.htm", _
        "2", "0", "Vehicle recovery services", "fir_vec.htm", "1", "1", "Marketing Information", "market.htm", _
        "2", "0", "Press releases", "mar_press.htm", "2", "0", "Articles and case studies", "mar_art.htm", _
        "2", "0", "Site history", "mar_site.htm", "1", "0", "Search", "search.htm", _
        "1", "0", "Feedback", "feedback.htm")
End Sub

Private Sub Form_Resize()
    Text1.Width = Form1.Width - 400
End Sub

