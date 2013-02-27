Public Class FrmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents MnuFileOpen As System.Windows.Forms.MenuItem
    Friend WithEvents MnuFileClose As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuFileExit As System.Windows.Forms.MenuItem
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents TreeTab As System.Windows.Forms.TabControl
    Friend WithEvents TreeTabChronological As System.Windows.Forms.TabPage
    Friend WithEvents TreeTabSorted As System.Windows.Forms.TabPage
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents TreeViewChronological As System.Windows.Forms.TreeView
    Friend WithEvents TreeViewSorted As System.Windows.Forms.TreeView
    Friend WithEvents MnuTools As System.Windows.Forms.MenuItem
    Friend WithEvents MnuToolsRemove As System.Windows.Forms.MenuItem
    Friend WithEvents ProcessLogView As System.Windows.Forms.ListBox
    Friend WithEvents MnuToolsFind As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu = New System.Windows.Forms.MainMenu
        Me.MnuFile = New System.Windows.Forms.MenuItem
        Me.MnuFileOpen = New System.Windows.Forms.MenuItem
        Me.MnuFileClose = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MnuFileExit = New System.Windows.Forms.MenuItem
        Me.MnuTools = New System.Windows.Forms.MenuItem
        Me.MnuToolsRemove = New System.Windows.Forms.MenuItem
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel3 = New System.Windows.Forms.StatusBarPanel
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ProcessLogView = New System.Windows.Forms.ListBox
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.TreeTab = New System.Windows.Forms.TabControl
        Me.TreeTabChronological = New System.Windows.Forms.TabPage
        Me.TreeViewChronological = New System.Windows.Forms.TreeView
        Me.TreeTabSorted = New System.Windows.Forms.TabPage
        Me.TreeViewSorted = New System.Windows.Forms.TreeView
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.MnuToolsFind = New System.Windows.Forms.MenuItem
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TreeTab.SuspendLayout()
        Me.TreeTabChronological.SuspendLayout()
        Me.TreeTabSorted.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MnuFile, Me.MnuTools})
        '
        'MnuFile
        '
        Me.MnuFile.Index = 0
        Me.MnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MnuFileOpen, Me.MnuFileClose, Me.MenuItem4, Me.MnuFileExit})
        Me.MnuFile.Text = "&File"
        '
        'MnuFileOpen
        '
        Me.MnuFileOpen.Index = 0
        Me.MnuFileOpen.Text = "&Open"
        '
        'MnuFileClose
        '
        Me.MnuFileClose.Enabled = False
        Me.MnuFileClose.Index = 1
        Me.MnuFileClose.Text = "&Close"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "-"
        '
        'MnuFileExit
        '
        Me.MnuFileExit.Index = 3
        Me.MnuFileExit.Text = "E&xit"
        '
        'MnuTools
        '
        Me.MnuTools.Enabled = False
        Me.MnuTools.Index = 1
        Me.MnuTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MnuToolsRemove, Me.MnuToolsFind})
        Me.MnuTools.Text = "&Tools"
        '
        'MnuToolsRemove
        '
        Me.MnuToolsRemove.Index = 0
        Me.MnuToolsRemove.Text = "&Remove Data"
        '
        'StatusBar
        '
        Me.StatusBar.Location = New System.Drawing.Point(0, 480)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2, Me.StatusBarPanel3})
        Me.StatusBar.ShowPanels = True
        Me.StatusBar.Size = New System.Drawing.Size(840, 22)
        Me.StatusBar.TabIndex = 0
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.MinWidth = 300
        Me.StatusBarPanel1.Text = "No log file open"
        Me.StatusBarPanel1.Width = 524
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.MinWidth = 100
        Me.StatusBarPanel2.Width = 150
        '
        'StatusBarPanel3
        '
        Me.StatusBarPanel3.MinWidth = 100
        Me.StatusBarPanel3.Width = 150
        '
        'ToolBar1
        '
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(840, 42)
        Me.ToolBar1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ProcessLogView)
        Me.Panel1.Controls.Add(Me.Splitter1)
        Me.Panel1.Controls.Add(Me.TreeTab)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(0, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(840, 438)
        Me.Panel1.TabIndex = 2
        '
        'ProcessLogView
        '
        Me.ProcessLogView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProcessLogView.Location = New System.Drawing.Point(183, 0)
        Me.ProcessLogView.Name = "ProcessLogView"
        Me.ProcessLogView.Size = New System.Drawing.Size(657, 433)
        Me.ProcessLogView.TabIndex = 4
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(180, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 438)
        Me.Splitter1.TabIndex = 3
        Me.Splitter1.TabStop = False
        '
        'TreeTab
        '
        Me.TreeTab.Controls.Add(Me.TreeTabChronological)
        Me.TreeTab.Controls.Add(Me.TreeTabSorted)
        Me.TreeTab.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeTab.Location = New System.Drawing.Point(0, 0)
        Me.TreeTab.Name = "TreeTab"
        Me.TreeTab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeTab.SelectedIndex = 0
        Me.TreeTab.Size = New System.Drawing.Size(180, 438)
        Me.TreeTab.TabIndex = 2
        '
        'TreeTabChronological
        '
        Me.TreeTabChronological.Controls.Add(Me.TreeViewChronological)
        Me.TreeTabChronological.Location = New System.Drawing.Point(4, 22)
        Me.TreeTabChronological.Name = "TreeTabChronological"
        Me.TreeTabChronological.Size = New System.Drawing.Size(172, 412)
        Me.TreeTabChronological.TabIndex = 0
        Me.TreeTabChronological.Text = "Chronological"
        Me.TreeTabChronological.ToolTipText = "Group log entries by process ID, in chronogical sequence."
        '
        'TreeViewChronological
        '
        Me.TreeViewChronological.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewChronological.HideSelection = False
        Me.TreeViewChronological.ImageIndex = -1
        Me.TreeViewChronological.Location = New System.Drawing.Point(0, 0)
        Me.TreeViewChronological.Name = "TreeViewChronological"
        Me.TreeViewChronological.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeViewChronological.SelectedImageIndex = -1
        Me.TreeViewChronological.Size = New System.Drawing.Size(172, 412)
        Me.TreeViewChronological.TabIndex = 1
        '
        'TreeTabSorted
        '
        Me.TreeTabSorted.Controls.Add(Me.TreeViewSorted)
        Me.TreeTabSorted.Location = New System.Drawing.Point(4, 22)
        Me.TreeTabSorted.Name = "TreeTabSorted"
        Me.TreeTabSorted.Size = New System.Drawing.Size(172, 412)
        Me.TreeTabSorted.TabIndex = 1
        Me.TreeTabSorted.Text = "Sorted"
        Me.TreeTabSorted.ToolTipText = "Group log entries by process ID, in process ID sequence."
        '
        'TreeViewSorted
        '
        Me.TreeViewSorted.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewSorted.HideSelection = False
        Me.TreeViewSorted.ImageIndex = -1
        Me.TreeViewSorted.Location = New System.Drawing.Point(0, 0)
        Me.TreeViewSorted.Name = "TreeViewSorted"
        Me.TreeViewSorted.SelectedImageIndex = -1
        Me.TreeViewSorted.Size = New System.Drawing.Size(172, 412)
        Me.TreeViewSorted.TabIndex = 2
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.Filter = "xfServerPlus Log Files (xfpl.log)|xfpl.log|All Log Files (*.log)|*.log|All Files " & _
        "(*.*)|*.*"
        '
        'MnuToolsFind
        '
        Me.MnuToolsFind.Index = 1
        Me.MnuToolsFind.Text = "&Find"
        '
        'FrmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(840, 502)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.StatusBar)
        Me.Menu = Me.MainMenu
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Log Analysis"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TreeTab.ResumeLayout(False)
        Me.TreeTabChronological.ResumeLayout(False)
        Me.TreeTabSorted.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim LogFileName As String
    Dim RecordCount As Integer
    Dim ProcessCount As Integer
    Dim LogFile As Collection
    Dim ProcessIndex As Collection

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LogFile = New Collection
        ProcessIndex = New Collection

    End Sub

    Private Sub MnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuFileExit.Click

        End

    End Sub

    Private Sub MnuFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuFileOpen.Click

        If OpenFileDialog.ShowDialog(Me) <> DialogResult.OK Then Exit Sub

        'Initialize main counters and update the status bar
        LogFileName = OpenFileDialog.FileName
        RecordCount = 0
        ProcessCount = 0
        UpdateStatusBar()

        TreeViewChronological.BeginUpdate()
        TreeViewSorted.BeginUpdate()

        Dim Sr As System.IO.StreamReader
        Dim Record As String
        Dim ProcessID As String

        Dim ThisLog As Collection
        Dim LogEntry As LogItem

        Me.Cursor = Cursors.WaitCursor

        Sr = New System.IO.StreamReader(OpenFileDialog.FileName)

        Do
            'Read next record from log file
            Record = Sr.ReadLine()

            'End of file?
            If Record Is Nothing Then Exit Do

            'Make sure it looks like a valid log file entry
            If (Len(Record) > 10) And (Not InStr(Record.Substring(0, 9), " ")) And (Record.Substring(8, 1).Equals(":")) Then

                RecordCount += 1

                ProcessID = Record.Substring(0, 8)

                'Create a new log entry
                LogEntry = New LogItem(RecordCount, ProcessID, Record)

                'Look for a process log for this log entry.
                'If not found, create a new log and add it to the process log index
                If ProcessIndex.Count > 0 Then
                    Try
                        ThisLog = ProcessIndex.Item(ProcessID)
                    Catch ex As Exception
                        ThisLog = CreateProcessLog(ProcessID)
                    End Try
                Else
                    ThisLog = CreateProcessLog(ProcessID)
                End If

                'Add the record to the full log, keyed by record number
                LogFile.Add(LogEntry, RecordCount)

                'Add the record to the process log, keyed by record number
                ThisLog.Add(LogEntry, RecordCount)

                'Update the status bar display
                UpdateStatusBar()

            End If

        Loop

        'Close the log file
        Sr.Close()

        'Setup the UI
        TreeViewChronological.Sorted = False
        TreeViewSorted.Sorted = True

        TreeViewChronological.EndUpdate()
        TreeViewSorted.EndUpdate()

        MnuFileOpen.Enabled = False
        MnuFileClose.Enabled = True
        MnuTools.Enabled = True

        Panel1.Enabled = True

        Me.Cursor = Cursors.Default

    End Sub

    Private Function CreateProcessLog(ByVal ProcessID As String) As Collection

        'Create a new process log
        Dim NewLog As New Collection

        'Add the new process log to the process log index
        ProcessIndex.Add(NewLog, ProcessID)

        'Add the new process log to the chronological tree view
        Dim Node As New TreeNode(ProcessID)
        Dim NewNodeIndex As Integer = TreeViewChronological.Nodes.Add(Node)

        'Add the new process to the sorted tree view
        TreeViewSorted.Nodes.Add(New TreeNode(ProcessID))

        'Update the status bar counters
        ProcessCount += 1

        Return NewLog

    End Function

    Private Sub MnuFileClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuFileClose.Click

        Panel1.Enabled = False

        ProcessLogView.DataSource = Nothing

        TreeViewChronological.Nodes.Clear()
        TreeViewSorted.Nodes.Clear()
        ProcessLogView.Items.Clear()

        LogFile = New Collection
        ProcessIndex = New Collection

        StatusBarPanel1.Text = ""
        StatusBarPanel2.Text = ""
        StatusBarPanel3.Text = ""

        MnuFileOpen.Enabled = True
        MnuFileClose.Enabled = False
        MnuTools.Enabled = False

    End Sub


    Private Sub TreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) _
        Handles TreeViewChronological.AfterSelect, TreeViewSorted.AfterSelect

        TreeViewChronological.SuspendLayout()
        TreeViewSorted.SuspendLayout()

        Dim Node As TreeNode
        Dim NodeIndex As Integer

        If sender Is TreeViewChronological Then
            'Select the matching entry in the sorted tree
            For Each Node In TreeViewSorted.Nodes
                If Node.Text.Equals(TreeViewChronological.SelectedNode.Text) Then
                    NodeIndex = Node.Index
                    TreeViewSorted.SelectedNode = Node
                    TreeViewSorted.SelectedNode.EnsureVisible()
                    Exit For
                End If
            Next
        Else
            'Select the matching entry in the chronological tree
            For Each Node In TreeViewChronological.Nodes
                If Node.Text.Equals(TreeViewSorted.SelectedNode.Text) Then
                    NodeIndex = Node.Index
                    TreeViewChronological.SelectedNode = Node
                    TreeViewChronological.SelectedNode.EnsureVisible()
                    Exit For
                End If
            Next
        End If

        'Display the log for this entry
        With ProcessLogView
            .DataSource = ProcessIndex(TreeViewChronological.SelectedNode.Text)
            .ValueMember = "LineNumber"
            .DisplayMember = "Text"
        End With

        TreeViewChronological.ResumeLayout()
        TreeViewSorted.ResumeLayout()

    End Sub

    Private Sub MnuToolsRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuToolsRemove.Click

        Dim Log As Collection
        Dim Dialog As New FrmRemove

        If Dialog.ShowDialog(Me) <> DialogResult.OK Then Exit Sub

        If Dialog.rbAll.Checked Then
            'Iterate through all process logs
            For Each Log In ProcessIndex
                RemoveData(Dialog, Log)
            Next
        Else
            If IsNothing(TreeViewChronological.SelectedNode) Then
                MsgBox("No process log is selected")
            Else
                'Process a specific log
                Log = ProcessIndex(TreeViewChronological.SelectedNode.Text)
                RemoveData(Dialog, Log)
            End If

        End If

        'Reload the current log
        If Not IsNothing(TreeViewChronological.SelectedNode) Then
            With ProcessLogView
                .DataSource = Nothing
                .DataSource = ProcessIndex(TreeViewChronological.SelectedNode.Text)
                .ValueMember = "LineNumber"
                .DisplayMember = "Text"
            End With
        End If

    End Sub

    Private Sub RemoveData(ByRef Dialog As FrmRemove, ByVal Log As Collection)

        If Dialog.cbIni.Checked Then
            RemoveIniData(Log)
        End If

        If Dialog.cbSmc.Checked Then
            RemoveSmcData(Log)
        End If

        If Dialog.cbPacket.Checked Then
            RemovePacketData(Log)
        End If

        If Dialog.cbDebug.Checked Then
            RemoveSessionDebug(Log)
        End If

        If Dialog.cbPar.Checked Then
            MsgBox("Not implemented!")
        End If

        If Dialog.cbInPar.Checked Then
            MsgBox("Not implemented!")
        End If

        If Dialog.cbOutPar.Checked Then
            MsgBox("Not implemented!")
        End If

    End Sub

    Private Sub RemoveIniData(ByVal Log As Collection)

        Dim Entry As LogItem

        Dim c As Integer
        For c = Log.Count To 1 Step -1
            Entry = Log(c)
            If Entry.Text.Length >= 15 Then
                If Entry.Text.Substring(8, 7).Equals(": ini: ") Then
                    Log.Remove(c)
                    RecordCount -= 1
                    UpdateStatusBar()
                End If
            End If
        Next

    End Sub

    Public Sub RemoveSmcData(ByVal Log As Collection)

        Dim Entry As LogItem
        Dim c As Integer
        Dim Removed As Boolean

        For c = Log.Count To 1 Step -1

            Removed = False
            Entry = Log(c)

            If Entry.Text.Length >= 34 Then
                If Entry.Text.Substring(8, 26).Equals(": **Method Catalog Entry**") Then
                    Removed = RemoveEntry(Log, c)
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 15 Then
                    If Entry.Text.Substring(8, 7).Equals(": c_id=") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 17 Then
                    If Entry.Text.Substring(8, 9).Equals(": c_type=") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 21 Then
                    If Entry.Text.Substring(8, 13).Equals(": c_funcname=") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 23 Then
                    If Entry.Text.Substring(8, 15).Equals(": c_returntype=") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 22 Then
                    If Entry.Text.Substring(8, 14).Equals(": c_returnlen=") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 21 Then
                    If Entry.Text.Substring(8, 13).Equals(": c_maxparms=") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 21 Then
                    If Entry.Text.Substring(8, 13).Equals(": c_minparms=") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 17 Then
                    If Entry.Text.Substring(8, 9).Equals(": c_date=") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 20 Then
                    If Entry.Text.Substring(8, 12).Equals(": c_elbname=") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 24 Then
                    If Entry.Text.Substring(8, 16).Equals(": cmpdt record #") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 16 Then
                    If Entry.Text.Substring(8, 8).Equals(":   cmp_") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 23 Then
                    If Entry.Text.Substring(8, 15).Equals(": cmp_return  =") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 46 Then
                    If Entry.Text.Substring(8, 38).Equals(": *** No cdt file read - same compid =") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 55 Then
                    If Entry.Text.Substring(8, 47).Equals(": *** No SMC file read - retrieved from cache =") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

        Next

    End Sub

    Public Sub RemovePacketData(ByVal Log As Collection)

        Dim Entry As LogItem
        Dim c As Integer
        Dim Removed As Boolean

        For c = Log.Count To 1 Step -1

            Removed = False
            Entry = Log(c)

            If Entry.Text.Length >= 20 Then
                If Entry.Text.Substring(8, 12).Equals(": Packet = {") Then
                    Removed = RemoveEntry(Log, c)
                End If
            End If

            If Not Removed Then
                If InStr(11, Entry.Text, "^") <> 0 And InStr(11, Entry.Text, "#") <> 0 And InStr(11, Entry.Text, ";") <> 0 And InStr(11, Entry.Text, "%") <> 0 Then
                    Removed = RemoveEntry(Log, c)
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 35 Then
                    If Entry.Text.Substring(8, 27).Equals(": Peek to get packet length") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 19 Then
                    If Entry.Text.Substring(8, 11).Equals(": receive: ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 24 Then
                    If Entry.Text.Substring(8, 16).Equals(": Receive packet") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 25 Then
                    If Entry.Text.Substring(8, 17).Equals(": Receive status ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 31 Then
                    If Entry.Text.Substring(8, 23).Equals(": Send packet length = ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 22 Then
                    If Entry.Text.Substring(8, 14).Equals(": Send status ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 28 Then
                    If Entry.Text.Substring(8, 20).Equals(": Response status = ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 29 Then
                    If Entry.Text.Substring(8, 21).Equals(": Stream returned at ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If (InStr(1, Entry.Text, ";") <> 0) Then
                    If ((InStr(1, Entry.Text, "AL") <> 0) Or (InStr(1, Entry.Text, "DE") <> 0)) Then
                        If (InStr(1, Entry.Text, "#") <> 0) Then
                            Removed = RemoveEntry(Log, c)
                        End If
                    End If
                End If
            End If

            If Not Removed Then
                If InStr(10, Entry.Text, "~") <> 0 And InStr(10, Entry.Text, "#") <> 0 Then
                    Removed = RemoveEntry(Log, c)
                End If
            End If

            If Not Removed Then
                If Entry.Text.Substring(8, 1).Equals(":") And Entry.Text.Substring(9, Len(Entry.Text) - 9).Equals(" ") Then
                    Removed = RemoveEntry(Log, c)
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 14 Then
                    If Entry.Text.Substring(12, 2).Equals("  ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length < 15 Then
                    Removed = RemoveEntry(Log, c)
                End If
            End If

        Next

    End Sub

    Public Sub RemoveSessionDebug(ByVal Log As Collection)

        Dim Entry As LogItem
        Dim c As Integer
        Dim Removed As Boolean

        For c = Log.Count To 1 Step -1

            Removed = False
            Entry = Log(c)

            If Entry.Text.Length >= 26 Then
                If Entry.Text.Substring(8, 18).Equals(": Command line = {") Then
                    Removed = RemoveEntry(Log, c)
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 33 Then
                    If Entry.Text.Substring(8, 25).Equals(": xfNetLink ip address = ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 27 Then
                    If Entry.Text.Substring(8, 19).Equals(": xfNetLink port = ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 27 Then
                    If Entry.Text.Substring(8, 19).Equals(": web ip address = ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 18 Then
                    If Entry.Text.Substring(8, 10).Equals(": Domain: ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 48 Then
                    If Entry.Text.Substring(8, 40).Equals(": xfServerPlusRemoteSession connected to") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 20 Then
                    If Entry.Text.Substring(8, 12).Equals(": Function: ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 15 Then
                    If Entry.Text.Substring(8, 7).Equals(": ELB: ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 17 Then
                    If Entry.Text.Substring(8, 9).Equals(": size = ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 21 Then
                    If Entry.Text.Substring(8, 13).Equals(": os_flags = ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 26 Then
                    If Entry.Text.Substring(8, 18).Equals(": Response client ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 29 Then
                    If Entry.Text.Substring(8, 21).Equals(": Setting up argument") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 49 Then
                    If Entry.Text.Substring(8, 41).Equals(": Calling a function with return type of ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 29 Then
                    If Entry.Text.Substring(8, 21).Equals(": rcb_setfunc call { ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 28 Then
                    If Entry.Text.Substring(8, 20).Equals(": Creating rcb with ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 35 Then
                    If Entry.Text.Substring(8, 27).Equals(": Received shutdown message") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 18 Then
                    If Entry.Text.Substring(8, 10).Equals(": Setting ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 28 Then
                    If Entry.Text.Substring(8, 20).Equals(": First parameter = ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If

            If Not Removed Then
                If Entry.Text.Length >= 29 Then
                    If Entry.Text.Substring(8, 21).Equals(": Second parameter = ") Then
                        Removed = RemoveEntry(Log, c)
                    End If
                End If
            End If


        Next

    End Sub

    Private Function RemoveEntry(ByVal Log As Collection, ByVal Index As Integer) As Boolean

        Dim RetVal As Boolean = True

        Try
            Log.Remove(Index)
            RecordCount -= 1
            UpdateStatusBar()
        Catch ex As Exception
            RetVal = False
        End Try

        Return RetVal

    End Function

    Private Sub UpdateStatusBar()

        StatusBarPanel1.Text = LogFileName
        If RecordCount = 0 Then
            StatusBarPanel2.Text = ""
        Else
            StatusBarPanel2.Text = RecordCount & " log entries"
        End If

        If ProcessCount = 0 Then
            StatusBarPanel3.Text = ""
        Else
            StatusBarPanel3.Text = ProcessCount & " processes"
        End If

    End Sub

    Private Sub MnuToolsFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuToolsFind.Click

        Me.Cursor = Cursors.WaitCursor
        Dim c As Integer
        Dim LogItem As LogItem
        For Each LogItem In LogFile
            If InStr(LogItem.Text, "called at") <> 0 Then
                c += 1
            End If
        Next
        Me.Cursor = Cursors.Default
        MsgBox(c & " Matches")

    End Sub
End Class
