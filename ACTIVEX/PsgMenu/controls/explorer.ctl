VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.UserControl Explorer 
   ClientHeight    =   5505
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   8490
   ScaleHeight     =   5505
   ScaleWidth      =   8490
   Begin VB.PictureBox picSplitter 
      Appearance      =   0  'Flat
      BackColor       =   &H80000003&
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   1950
      Left            =   4320
      ScaleHeight     =   1950
      ScaleWidth      =   195
      TabIndex        =   1
      Top             =   990
      Visible         =   0   'False
      Width           =   195
   End
   Begin MSComctlLib.ImageList ImageList2 
      Left            =   990
      Top             =   4410
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   24
      ImageHeight     =   23
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   2
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "explorer.ctx":0000
            Key             =   "ProgLarge"
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "explorer.ctx":067A
            Key             =   "FolderLarge"
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.ImageList ImageList1 
      Left            =   360
      Top             =   4410
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   7
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "explorer.ctx":0CF4
            Key             =   "Closed"
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "explorer.ctx":0DEE
            Key             =   "ProgSmall"
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "explorer.ctx":1330
            Key             =   "Open"
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "explorer.ctx":142A
            Key             =   "FolderSmall"
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "explorer.ctx":196C
            Key             =   "Leaf"
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "explorer.ctx":1A66
            Key             =   "Plus"
         EndProperty
         BeginProperty ListImage7 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "explorer.ctx":1B60
            Key             =   "Minus"
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.TreeView Tree 
      Height          =   3405
      Left            =   270
      TabIndex        =   0
      Top             =   1260
      Width           =   3435
      _ExtentX        =   6059
      _ExtentY        =   6006
      _Version        =   393217
      Indentation     =   617
      LabelEdit       =   1
      Style           =   7
      ImageList       =   "ImageList1"
      Appearance      =   1
   End
   Begin MSComctlLib.ListView List 
      Height          =   3300
      Left            =   4950
      TabIndex        =   2
      Top             =   1395
      Width           =   2895
      _ExtentX        =   5106
      _ExtentY        =   5821
      View            =   3
      Arrange         =   1
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      _Version        =   393217
      Icons           =   "ImageList2"
      SmallIcons      =   "ImageList1"
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   0
   End
   Begin VB.Label ListLabel 
      BorderStyle     =   1  'Fixed Single
      Height          =   285
      Left            =   4995
      TabIndex        =   4
      Top             =   855
      Width           =   1230
   End
   Begin VB.Label TreeLabel 
      BorderStyle     =   1  'Fixed Single
      Height          =   300
      Left            =   630
      TabIndex        =   3
      Top             =   810
      Width           =   1230
   End
   Begin VB.Image imgSplitter 
      Height          =   3435
      Left            =   3960
      MousePointer    =   9  'Size W E
      Top             =   1305
      Width           =   150
   End
   Begin VB.Menu mnuView 
      Caption         =   "&View"
      Begin VB.Menu mnuViewMode 
         Caption         =   "Up One Level"
         Index           =   0
      End
      Begin VB.Menu mnuViewMode 
         Caption         =   "-"
         Index           =   1
      End
      Begin VB.Menu mnuViewMode 
         Caption         =   "Large Icons"
         Index           =   2
      End
      Begin VB.Menu mnuViewMode 
         Caption         =   "Small Icons"
         Index           =   3
      End
      Begin VB.Menu mnuViewMode 
         Caption         =   "List"
         Index           =   4
      End
      Begin VB.Menu mnuViewMode 
         Caption         =   "Detail"
         Index           =   5
      End
   End
   Begin VB.Menu mnuTree 
      Caption         =   "&Tree"
      Begin VB.Menu mnuTreeMode 
         Caption         =   "Expand This Item"
         Index           =   0
      End
      Begin VB.Menu mnuTreeMode 
         Caption         =   "Collapse This Item"
         Index           =   1
      End
      Begin VB.Menu mnuTreeMode 
         Caption         =   "-"
         Index           =   2
      End
      Begin VB.Menu mnuTreeMode 
         Caption         =   "Expand All Items"
         Index           =   3
      End
      Begin VB.Menu mnuTreeMode 
         Caption         =   "Collapse All Items"
         Index           =   4
      End
   End
End
Attribute VB_Name = "Explorer"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
'Event Declarations:
Public Event LoadListItems(TreeKey As String)
Public Event ItemSelected(Key As String)
Public Event SwitchListMode(ViewMode As ListViewConstants)

Const SplitLimit = 500
Const SplitWidth = 50

Dim Moving As Boolean
Dim Node As Node

'Default Property Values:
Const m_def_StatusText = ""
Const m_def_ShowHeading = True

'Property Variables:
Dim m_StatusText As String
Dim m_ShowHeading As Boolean

Private Sub UserControl_Initialize()

    UserControl_InitProperties

    With imgSplitter
        .Top = 1
        .Left = Width / 2
        .Width = SplitWidth
        .Height = Height
    End With
    
    With picSplitter
        .Top = 1
        .Left = Width / 2
        .Width = 1
        .Height = 1
        .Visible = False
    End With

End Sub

'This method is called to re-position the constituent controls when the
'size of the UserControl changes.  It is called when the control is first
'activated, and also after Synergy uses the Resize method.

Private Sub UserControl_Resize()

    SizeControls (imgSplitter.Left)
    
End Sub

Private Sub SizeControls(x As Single)
    
    On Error Resume Next

    'Make sure the split is not too far to the left
    If x < SplitLimit Then x = SplitLimit
    
    'Make sure the split is not too far to the right
    If x > (UserControl.Width - SplitLimit) Then x = UserControl.Width - SplitLimit
    
    With TreeLabel
        .Top = 1
        .Left = 1
        .Height = 280
        .Width = x
        .Visible = m_ShowHeading
    End With
    
    With Tree
        .Left = 1
        If m_ShowHeading = True Then
            .Top = TreeLabel.Height + 1
            .Height = Height - TreeLabel.Height
        Else
            .Top = 1
            .Height = Height
        End If
        .Width = x
    End With
    
    With imgSplitter
        .Top = 1
        .Left = x
        .Height = Height
        .Width = SplitWidth
    End With
    
    With ListLabel
        .Top = 1
        .Left = x + SplitWidth
        .Height = 280
        .Width = UserControl.Width - (Tree.Width + SplitWidth)
        .Visible = m_ShowHeading
    End With

    With List
        .Left = x + SplitWidth
        If m_ShowHeading = True Then
            .Top = ListLabel.Height + 1
            .Height = Height - ListLabel.Height
        Else
            .Top = 1
            .Height = Height
        End If
        .Width = UserControl.Width - (Tree.Width + SplitWidth)
    End With
    
    'Make the control re-paint its self
    UserControl.Refresh

End Sub

Private Sub imgSplitter_MouseDown(Button As Integer, Shift As Integer, x As Single, y As Single)
    
    With imgSplitter
        picSplitter.Move .Left, .Top, .Width, .Height
    End With
    
    picSplitter.Visible = True
    
    Moving = True

End Sub

'This routine moves the split divider

Private Sub imgSplitter_MouseMove(Button As Integer, Shift As Integer, x As Single, y As Single)

    Dim Pos As Single
    
    If Moving Then
        
        'Calculate x position of mouse in user control
        Pos = x + imgSplitter.Left
        
        'Set position of divider to mouse position, within margins
        If (Pos < SplitLimit) Then
            'Too far left, set to left limit
            picSplitter.Left = SplitLimit
        ElseIf (Pos > (UserControl.Width - SplitLimit)) Then
            'Too far right, set to right limit
            picSplitter.Left = (UserControl.Width - SplitLimit)
        Else
            'OK
            picSplitter.Left = Pos
        End If

    End If

End Sub

'This routine sets the new division between the tree and list controls

Private Sub imgSplitter_MouseUp(Button As Integer, Shift As Integer, x As Single, y As Single)
    
    'Redraw everything based on new split
    SizeControls picSplitter.Left
    
    'Disable the temporary divider
    picSplitter.Visible = False
    
    Moving = False

End Sub

Private Sub Tree_Click()

    If Tree.Nodes.Count > 0 Then
        
        'Clear current ListView contents
        List.ListItems.Clear
        
        If (Tree.SelectedItem.Children = 0) Then
            
            'No children, so it's a program
            RaiseEvent LoadListItems(Tree.SelectedItem.Key)
        
        Else

            'Add the child nodes into the ListView as folder items
            Dim c, FirstChild, LastChild As Integer
            
            FirstChild = Tree.SelectedItem.Child.FirstSibling.Index
            LastChild = Tree.SelectedItem.Child.LastSibling.Index

            For c = FirstChild To LastChild
                If Tree.Nodes(c).Parent = Tree.SelectedItem Then
                    List.ListItems.Add , Tree.Nodes(c).Key, Tree.Nodes(c).Text, _
                        "FolderLarge", "FolderSmall"
                End If
            Next
        
        End If
    
    End If

End Sub

Private Sub Tree_MouseUp(Button As Integer, Shift As Integer, x As Single, y As Single)

    If Tree.Nodes.Count > 0 Then
        
        If Button = vbRightButton Then
            
            'Enable or disable the "Expand This Item" entry as appropriate
            If (Tree.SelectedItem.Children > 0) _
                And (Tree.SelectedItem.Expanded = False) Then
                mnuTreeMode(0).Enabled = True
            Else
                mnuTreeMode(0).Enabled = False
            End If
            
            'Enable or disable the "Collapse This Item" entry as appropriate
            If Tree.SelectedItem.Children > 0 And Tree.SelectedItem.Expanded = True Then
                mnuTreeMode(1).Enabled = True
            Else
                mnuTreeMode(1).Enabled = False
            End If
            
            PopupMenu mnuTree
        
        End If
    
    End If

End Sub

Private Sub mnuTreeMode_Click(Index As Integer)

    Select Case Index
        Case 0:
            Tree.SelectedItem.Expanded = True
        Case 1:
            Tree.SelectedItem.Expanded = False
        Case 3:
            ExpandAll
        Case 4:
            CollapseAll
    End Select

End Sub

Private Sub List_MouseUp(Button As Integer, Shift As Integer, x As Single, y As Single)

    If Button = vbRightButton Then
        
        'Enable all modes in the popup menu
        Dim c As Integer
        For c = 0 To 3
            mnuViewMode(c).Enabled = True
        Next
    
        'Disable the currently selected view mode
        mnuViewMode(List.View).Enabled = False
        
        'Display the popup menu
        PopupMenu mnuView
        
    End If

End Sub

Private Sub mnuViewMode_Click(Index As Integer)

    Select Case Index
    Case 0:
        Call GotoParent
    Case 2 To 5:
        RaiseEvent SwitchListMode(Index - 2)
        'The above event handler SHOULD use the ListMode property to set
        'the new list mode, but it's not currently working (Synergy Bug?)
        'So, we'll do it here also:
        List.View = (Index - 2)
    End Select
    
End Sub

Private Sub List_DblClick()

    If List.SelectedItem.Icon = "FolderLarge" Then
        'Double click on a folder, go to the appropriate place in the Tree
        Tree.Nodes.Item(List.SelectedItem.Key).Selected = True
        Tree.SetFocus
        Tree_Click
    Else
        'Double click on a program, tell Synergy to run it.
        RaiseEvent ItemSelected(List.SelectedItem.Key)
    End If

End Sub

'*************************************************************************
'*************************************************************************
'***PROPERTIES************************************************************
'*************************************************************************
'*************************************************************************

Public Property Get ListHeading() As String
    ListHeading = ListLabel.Caption
End Property

Public Property Let ListHeading(ByVal New_ListHeading As String)
    ListLabel.Caption() = New_ListHeading
    PropertyChanged "ListHeading"
End Property

Public Property Get ListMode() As ListViewConstants
    ListMode = List.View
End Property

Public Property Let ListMode(ByVal New_ListMode As ListViewConstants)
    List.View() = New_ListMode
    Select Case List.View
    Case lvwIcon:
        List.Arrange = lvwAutoTop
    Case lvwSmallIcon:
        List.Arrange = lvwAutoLeft
    End Select
    PropertyChanged "ListMode"
End Property

Public Property Get ShowHeading() As Boolean
    ShowHeading = m_ShowHeading
End Property

Public Property Let ShowHeading(ByVal New_ShowHeading As Boolean)
    m_ShowHeading = New_ShowHeading
    PropertyChanged "ShowHeading"
    SizeControls (imgSplitter.Left)
End Property

Public Property Get TreeHeading() As String
    TreeHeading = TreeLabel.Caption
End Property

Public Property Let TreeHeading(ByVal New_TreeHeading As String)
    TreeLabel.Caption() = New_TreeHeading
    PropertyChanged "TreeHeading"
End Property

'Initialize Properties for User Control

Private Sub UserControl_InitProperties()
    m_ShowHeading = m_def_ShowHeading
End Sub

'Load property values from storage

Private Sub UserControl_ReadProperties(PropBag As PropertyBag)
    ListLabel.Caption = PropBag.ReadProperty("ListHeading", "")
    List.View = PropBag.ReadProperty("ListMode", 3)
    TreeLabel.Caption = PropBag.ReadProperty("TreeHeading", "")
    m_ShowHeading = PropBag.ReadProperty("ShowHeading", m_def_ShowHeading)
End Sub

'Write property values to storage

Private Sub UserControl_WriteProperties(PropBag As PropertyBag)
    Call PropBag.WriteProperty("ListHeading", ListLabel.Caption, "")
    Call PropBag.WriteProperty("ListMode", List.View, 3)
    Call PropBag.WriteProperty("TreeHeading", TreeLabel.Caption, "")
    Call PropBag.WriteProperty("ShowHeading", m_ShowHeading, m_def_ShowHeading)
End Sub

'*************************************************************************
'*************************************************************************
'***METHODS***************************************************************
'*************************************************************************
'*************************************************************************

Public Sub AddFolderNode(ByVal Parent As String, ByVal Key As String, ByVal Text As String)

    Set Node = Tree.Nodes.Add(Parent, tvwChild, Key, Text, "Closed", "Open")
    
End Sub

Public Sub AddItem(ByVal Description As String, ByVal ProgramNumber As String)
     
    On Error Resume Next
    Dim ListItem As ListItem
    Set ListItem = List.ListItems.Add(, "P" & ProgramNumber, Description, "ProgLarge", "ProgSmall")

End Sub

Public Sub AddNode(ByVal Parent As String, ByVal Key As String, ByVal Text As String)

    Set Node = Tree.Nodes.Add(Parent, tvwChild, Key, Text, "Leaf", "Leaf")
    
End Sub

Public Sub AddRootNode(ByVal Text As String)

    Set Node = Tree.Nodes.Add(, , "ROOT", Text, "Closed", "Open")

End Sub

Public Sub CollapseAll()

    Dim c As Integer
    For c = 1 To Tree.Nodes.Count
        If Tree.Nodes(c).Children > 0 Then
            Tree.Nodes(c).Expanded = False
        End If
    Next c
    
    With Tree.Nodes.Item("ROOT")
        .Expanded = True
        .Selected = True
    End With

    Tree.SetFocus

End Sub

Public Sub ExpandAll()

    Dim c As Integer
    For c = 1 To Tree.Nodes.Count
        If Tree.Nodes(c).Children > 0 Then
            Tree.Nodes(c).Expanded = True
        End If
    Next c

    Tree.Nodes("ROOT").Selected = True
    Tree.SelectedItem.EnsureVisible

    Tree.SetFocus

End Sub

Public Sub GotoParent()

    If Tree.SelectedItem.Key <> "ROOT" Then
    
        Tree.SelectedItem.Parent.Selected = True
        Tree_Click

    End If

    Tree.SetFocus

End Sub

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MemberInfo=14

Public Sub Reset()

    TreeHeading = ""
    ListHeading = ""
    ShowHeading = m_def_ShowHeading

    Tree.Nodes.Clear
    List.ListItems.Clear

    With imgSplitter
        .Top = 1
        .Left = Width / 2
        .Width = SplitWidth
        .Height = Height
    End With
    
    With picSplitter
        .Top = 1
        .Left = Width / 2
        .Width = 1
        .Height = 1
        .Visible = False
    End With

    SizeControls (imgSplitter.Left)

End Sub

'This method is called from Synergy to make the control resize to the
'new size of it's container.  We resize the UserControl to the passed
'in dimensions, which causes the UserControl_Resize event to fire and
'thus the constituent controls to be re-positioned.
Public Sub Resize(ByVal NewWidth As Long, ByVal NewHeight As Long)

    Dim TwipWidth, PixelWidth, TwipHeight, PixelHeight As Long
    
    'Get current dimension of control in twips
    UserControl.ScaleMode = vbTwips
    TwipWidth = UserControl.ScaleWidth
    TwipHeight = UserControl.ScaleHeight
    
    'Get current dimension of control in pixels
    UserControl.ScaleMode = vbPixels
    PixelWidth = UserControl.ScaleWidth
    PixelHeight = UserControl.ScaleHeight
    
    'Apply new twip dimensions to control
    With UserControl
        .ScaleMode = vbTwips
        .Width = NewWidth * (TwipWidth / PixelWidth)
        .Height = NewHeight * (TwipHeight / PixelHeight)
    End With

End Sub

Public Sub RestoreListFocus()

    List.SetFocus

End Sub

Public Sub RestoreTreeFocus()

    Tree.SetFocus

End Sub

Public Sub SetInitialDisplay()

    'Purge unused folders from the tree
    Dim c As Integer
    c = 1
    Do
        If c > (Tree.Nodes.Count) Then
            Exit Do
        Else
            If (Tree.Nodes.Item(c).Key <> "ROOT") Then
                If (Tree.Nodes.Item(c).Parent.Key = "ROOT") _
                And (Tree.Nodes.Item(c).Children = 0) Then
                    'It's a main Branch with no children, remove it!
                    Tree.Nodes.Remove c
                Else
                    'This one's OK, move on
                    c = c + 1
                End If
            Else
                'Skip the root node
                c = c + 1
            End If
        End If
    Loop

    'Select & expand the root node
    With Tree.Nodes.Item("ROOT")
        .Expanded = True
        .Selected = True
    End With

End Sub

