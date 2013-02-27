
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
    Friend WithEvents MnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents MnuFileExit As System.Windows.Forms.MenuItem
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MnuFileOpen As System.Windows.Forms.MenuItem
    Friend WithEvents MnuFileClose As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents TreeView As System.Windows.Forms.TreeView
    Friend WithEvents Splitter As System.Windows.Forms.Splitter
    Friend WithEvents ListView As System.Windows.Forms.ListView
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu = New System.Windows.Forms.MainMenu
        Me.MnuFile = New System.Windows.Forms.MenuItem
        Me.MnuFileOpen = New System.Windows.Forms.MenuItem
        Me.MnuFileClose = New System.Windows.Forms.MenuItem
        Me.MnuFileExit = New System.Windows.Forms.MenuItem
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.ToolBar = New System.Windows.Forms.ToolBar
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.TreeView = New System.Windows.Forms.TreeView
        Me.Splitter = New System.Windows.Forms.Splitter
        Me.ListView = New System.Windows.Forms.ListView
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MnuFile})
        '
        'MnuFile
        '
        Me.MnuFile.Index = 0
        Me.MnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MnuFileOpen, Me.MnuFileClose, Me.MnuFileExit})
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
        'MnuFileExit
        '
        Me.MnuFileExit.Index = 2
        Me.MnuFileExit.Text = "E&xit"
        '
        'StatusBar
        '
        Me.StatusBar.Location = New System.Drawing.Point(0, 476)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(764, 22)
        Me.StatusBar.TabIndex = 0
        '
        'ToolBar
        '
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(764, 42)
        Me.ToolBar.TabIndex = 1
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.DefaultExt = "xml"
        Me.OpenFileDialog.Filter = "XML Files|*.xml"
        Me.OpenFileDialog.ReadOnlyChecked = True
        Me.OpenFileDialog.ShowReadOnly = True
        '
        'TreeView
        '
        Me.TreeView.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeView.ImageIndex = -1
        Me.TreeView.Location = New System.Drawing.Point(0, 42)
        Me.TreeView.Name = "TreeView"
        Me.TreeView.SelectedImageIndex = -1
        Me.TreeView.Size = New System.Drawing.Size(284, 434)
        Me.TreeView.TabIndex = 2
        '
        'Splitter
        '
        Me.Splitter.Location = New System.Drawing.Point(284, 42)
        Me.Splitter.Name = "Splitter"
        Me.Splitter.Size = New System.Drawing.Size(3, 434)
        Me.Splitter.TabIndex = 3
        Me.Splitter.TabStop = False
        '
        'ListView
        '
        Me.ListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView.Location = New System.Drawing.Point(287, 42)
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(477, 434)
        Me.ListView.TabIndex = 4
        '
        'FrmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(764, 498)
        Me.Controls.Add(Me.ListView)
        Me.Controls.Add(Me.Splitter)
        Me.Controls.Add(Me.TreeView)
        Me.Controls.Add(Me.ToolBar)
        Me.Controls.Add(Me.StatusBar)
        Me.Menu = Me.MainMenu
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GENCS+"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuFileExit.Click
        Me.Close()
    End Sub

    Private Sub MnuFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuFileOpen.Click
        If OpenFileDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            XmlFileName = OpenFileDialog.FileName
            Dim ErrorText As String = ""
            If ParseFile(XmlFileName, ErrorText) Then
                Me.Text = "GENCS+ [" & XmlFileName & "]"
                MnuFileClose.Enabled = True
            Else
                MsgBox("Failed to parse file " & XmlFileName & vbCrLf & ErrorText)
            End If
        End If
    End Sub

    Private Sub MnuFileClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuFileClose.Click

        'Reset data
        XmlFileName = ""
        ComponentName = ""

        'Reset UI

        TreeView.Nodes.Clear()
        ListView.Items.Clear()
        Me.Text = "GENCS+"
        MnuFileClose.Enabled = False

    End Sub

    '****************************************************************************************************

    Private Function ParseFile(ByVal FileName As String, ByRef ErrorText As String) As Boolean

        Dim OK As Boolean = True
        ErrorText = ""

        'Parse the XML document

        Dim doc As New System.Xml.XmlDocument
        Try
            doc.Load(FileName)
        Catch ex As Exception
            ErrorText = ex.Message
            OK = False
        End Try

        'Get the root node

        Dim RootNode As System.Xml.XmlNode
        If OK Then
            RootNode = doc.DocumentElement

            If RootNode.Name <> "component" Then
                ErrorText = "Not an XML file from GENXML"
                OK = False
            End If
        End If

        'Get the component name
        If OK Then
            Try
                ComponentName = RootNode.Attributes("name").Value
            Catch ex As Exception
                'Root node doesn't have a "name" attribute
                ErrorText = "Not an XML file from GENXML"
                OK = False
            End Try

        End If

        'Add the component to the tree view

        Dim TreeRoot, TreeInterfaces, TreeStructures As TreeNode
        If OK Then

            TreeRoot = TreeView.Nodes.Add("Component " & ComponentName)

            TreeInterfaces = New TreeNode("Interfaces")
            TreeRoot.Nodes.Add(TreeInterfaces)

            TreeStructures = New TreeNode("Structures")
            TreeRoot.Nodes.Add(TreeStructures)

        End If

        'Add interfaces & structures

        If OK Then

            Dim Child As System.Xml.XmlNode

            For Each Child In RootNode.ChildNodes()
                Select Case Child.Name
                    Case "interface"
                        AddInterface(TreeInterfaces, Child)
                    Case "structure"
                        AddStructure(TreeStructures, Child)
                End Select
            Next

        End If

        TreeRoot.Expand()
        TreeInterfaces.Expand()
        TreeStructures.Expand()

        Return OK

    End Function

    Private Sub AddInterface(ByRef TreeInterfaces As TreeNode, ByRef XmlInterface As System.Xml.XmlNode)

        Dim TreeInterface, TreeMethod As TreeNode, Method, Parameter As System.Xml.XmlNode

        Dim ParamData As String
        Dim ParamSize As String

        TreeInterface = New TreeNode(XmlInterface.Attributes("name").Value)

        For Each Method In XmlInterface.ChildNodes()

            TreeMethod = New TreeNode(Method.Attributes("name").Value & "()")

            If Method.HasChildNodes Then

                For Each Parameter In Method.ChildNodes
                    Select Case Parameter.Name

                        Case "methodresult"

                            ParamData = ""

                        Case "param"

                            ParamData = Parameter.Attributes("name").Value

                            ParamSize = ""
                            If Not IsNothing(Parameter.Attributes.GetNamedItem("size")) Then
                                ParamSize = Parameter.Attributes.GetNamedItem("size").Value
                            End If

                            Select Case Parameter.Attributes("type").Value
                                Case "alpha"
                                    ParamData = Trim(ParamData) & " (a" & ParamSize
                                Case "decimal"
                                    ParamData = Trim(ParamData) & " (d" & ParamSize
                                    If Not IsNothing(Parameter.Attributes.GetNamedItem("precision")) Then
                                        ParamData = Trim(ParamData) & "." & Parameter.Attributes("precision").Value
                                    End If
                                Case "integer"
                                    ParamData = Trim(ParamData) & " (i" & ParamSize
                                Case "structure"
                                    ParamData = Trim(ParamData) & " (structure"
                                Case "handle"
                                    ParamData = Trim(ParamData) & " (handle"
                            End Select

                            If Not IsNothing(Parameter.Attributes.GetNamedItem("dim")) Then
                                ParamData = Trim(ParamData) & ", array"
                            End If

                            If IsNothing(Parameter.Attributes.GetNamedItem("dir")) Then
                                ParamData = Trim(ParamData) & ", in"
                            Else
                                ParamData = Trim(ParamData) & ", " & Parameter.Attributes.GetNamedItem("dir").Value
                            End If

                            ParamData = Trim(ParamData) & ")"

                    End Select

                    TreeMethod.Nodes.Add(ParamData)

                Next
            End If

            TreeInterface.Nodes.Add(TreeMethod)

        Next

        TreeInterfaces.Nodes.Add(TreeInterface)

    End Sub

    Private Sub AddStructure(ByRef TreeStructures As TreeNode, ByRef XmlStructure As System.Xml.XmlNode)

        Dim TreeStructure, TreeField As TreeNode, Field As System.Xml.XmlNode
        Dim StructureSize As Integer
        Dim FieldSpec As String

        StructureSize = XmlStructure.Attributes("size").Value

        TreeStructure = New TreeNode(XmlStructure.Attributes("name").Value & " (" & StructureSize & " bytes)")

        For Each Field In XmlStructure.ChildNodes()

            Select Case Field.Attributes("type").Value
                Case "alpha"
                    FieldSpec = "A" & Field.Attributes("size").Value
                Case "decimal"
                    FieldSpec = "D" & Field.Attributes("size").Value
                    If Not IsNothing(Field.Attributes.GetNamedItem("precision")) Then
                        FieldSpec = Trim(FieldSpec) & "." & Field.Attributes("precision").Value
                    End If
                Case "date"
                    FieldSpec = "DT" & Field.Attributes("size").Value
                    FieldSpec = Trim(FieldSpec) & " - " & Field.Attributes("format").Value
                Case "time"
                    FieldSpec = "TM" & Field.Attributes("size").Value
            End Select

            TreeField = New TreeNode(Field.Attributes("name").Value & " (" & FieldSpec & ")")
            TreeStructure.Nodes.Add(TreeField)
        Next

        TreeStructures.Nodes.Add(TreeStructure)

    End Sub

End Class
