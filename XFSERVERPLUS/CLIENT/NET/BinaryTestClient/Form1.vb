Imports System.IO

Public Class Form1
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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGetLogo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtRemoteFile1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLocalFile1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLocalFile2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtRemoteFile2 As System.Windows.Forms.TextBox
    Friend WithEvents BtnGetFile As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnSendFile As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents RemoteFile1Drill As System.Windows.Forms.PictureBox
    Friend WithEvents LocalFile2Drill As System.Windows.Forms.PictureBox
    Friend WithEvents LocalFile1Drill As System.Windows.Forms.PictureBox
    Friend WithEvents RemoteFile2Drill As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BtnGetLogo = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LocalFile1Drill = New System.Windows.Forms.PictureBox
        Me.RemoteFile1Drill = New System.Windows.Forms.PictureBox
        Me.BtnGetFile = New System.Windows.Forms.Button
        Me.TxtLocalFile1 = New System.Windows.Forms.TextBox
        Me.TxtRemoteFile1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RemoteFile2Drill = New System.Windows.Forms.PictureBox
        Me.LocalFile2Drill = New System.Windows.Forms.PictureBox
        Me.BtnSendFile = New System.Windows.Forms.Button
        Me.TxtRemoteFile2 = New System.Windows.Forms.TextBox
        Me.TxtLocalFile2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.LocalFile1Drill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RemoteFile1Drill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.RemoteFile2Drill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LocalFile2Drill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(16, 80)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(268, 177)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'BtnGetLogo
        '
        Me.BtnGetLogo.Location = New System.Drawing.Point(160, 272)
        Me.BtnGetLogo.Name = "BtnGetLogo"
        Me.BtnGetLogo.Size = New System.Drawing.Size(124, 23)
        Me.BtnGetLogo.TabIndex = 3
        Me.BtnGetLogo.Text = "Get &Logo"
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(644, 324)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(124, 23)
        Me.BtnClose.TabIndex = 4
        Me.BtnClose.Text = "&Close"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(272, 44)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "This demo calls a Synergy Method to retrieve a JPG file from the server using the" & _
            " new Binary parameter types in Synergy/DE 8.3."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtnGetLogo)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 304)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Retrieve and Display Image"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LocalFile1Drill)
        Me.GroupBox2.Controls.Add(Me.RemoteFile1Drill)
        Me.GroupBox2.Controls.Add(Me.BtnGetFile)
        Me.GroupBox2.Controls.Add(Me.TxtLocalFile1)
        Me.GroupBox2.Controls.Add(Me.TxtRemoteFile1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(316, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(448, 144)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "File Download"
        '
        'LocalFile1Drill
        '
        Me.LocalFile1Drill.Image = CType(resources.GetObject("LocalFile1Drill.Image"), System.Drawing.Image)
        Me.LocalFile1Drill.Location = New System.Drawing.Point(420, 64)
        Me.LocalFile1Drill.Name = "LocalFile1Drill"
        Me.LocalFile1Drill.Size = New System.Drawing.Size(16, 16)
        Me.LocalFile1Drill.TabIndex = 10
        Me.LocalFile1Drill.TabStop = False
        '
        'RemoteFile1Drill
        '
        Me.RemoteFile1Drill.Image = CType(resources.GetObject("RemoteFile1Drill.Image"), System.Drawing.Image)
        Me.RemoteFile1Drill.Location = New System.Drawing.Point(420, 28)
        Me.RemoteFile1Drill.Name = "RemoteFile1Drill"
        Me.RemoteFile1Drill.Size = New System.Drawing.Size(16, 16)
        Me.RemoteFile1Drill.TabIndex = 9
        Me.RemoteFile1Drill.TabStop = False
        '
        'BtnGetFile
        '
        Me.BtnGetFile.Location = New System.Drawing.Point(292, 96)
        Me.BtnGetFile.Name = "BtnGetFile"
        Me.BtnGetFile.Size = New System.Drawing.Size(124, 23)
        Me.BtnGetFile.TabIndex = 7
        Me.BtnGetFile.Text = "&Get File"
        '
        'TxtLocalFile1
        '
        Me.TxtLocalFile1.Location = New System.Drawing.Point(88, 60)
        Me.TxtLocalFile1.Name = "TxtLocalFile1"
        Me.TxtLocalFile1.Size = New System.Drawing.Size(328, 20)
        Me.TxtLocalFile1.TabIndex = 3
        '
        'TxtRemoteFile1
        '
        Me.TxtRemoteFile1.Location = New System.Drawing.Point(88, 24)
        Me.TxtRemoteFile1.Name = "TxtRemoteFile1"
        Me.TxtRemoteFile1.Size = New System.Drawing.Size(328, 20)
        Me.TxtRemoteFile1.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Local File"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Remote File"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RemoteFile2Drill)
        Me.GroupBox3.Controls.Add(Me.LocalFile2Drill)
        Me.GroupBox3.Controls.Add(Me.BtnSendFile)
        Me.GroupBox3.Controls.Add(Me.TxtRemoteFile2)
        Me.GroupBox3.Controls.Add(Me.TxtLocalFile2)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(320, 160)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(448, 152)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "File Upload"
        '
        'RemoteFile2Drill
        '
        Me.RemoteFile2Drill.Image = CType(resources.GetObject("RemoteFile2Drill.Image"), System.Drawing.Image)
        Me.RemoteFile2Drill.Location = New System.Drawing.Point(416, 64)
        Me.RemoteFile2Drill.Name = "RemoteFile2Drill"
        Me.RemoteFile2Drill.Size = New System.Drawing.Size(16, 16)
        Me.RemoteFile2Drill.TabIndex = 11
        Me.RemoteFile2Drill.TabStop = False
        '
        'LocalFile2Drill
        '
        Me.LocalFile2Drill.Image = CType(resources.GetObject("LocalFile2Drill.Image"), System.Drawing.Image)
        Me.LocalFile2Drill.Location = New System.Drawing.Point(416, 32)
        Me.LocalFile2Drill.Name = "LocalFile2Drill"
        Me.LocalFile2Drill.Size = New System.Drawing.Size(16, 16)
        Me.LocalFile2Drill.TabIndex = 10
        Me.LocalFile2Drill.TabStop = False
        '
        'BtnSendFile
        '
        Me.BtnSendFile.Location = New System.Drawing.Point(288, 96)
        Me.BtnSendFile.Name = "BtnSendFile"
        Me.BtnSendFile.Size = New System.Drawing.Size(124, 23)
        Me.BtnSendFile.TabIndex = 9
        Me.BtnSendFile.Text = "&Send File"
        '
        'TxtRemoteFile2
        '
        Me.TxtRemoteFile2.Location = New System.Drawing.Point(84, 60)
        Me.TxtRemoteFile2.Name = "TxtRemoteFile2"
        Me.TxtRemoteFile2.Size = New System.Drawing.Size(328, 20)
        Me.TxtRemoteFile2.TabIndex = 6
        '
        'TxtLocalFile2
        '
        Me.TxtLocalFile2.Location = New System.Drawing.Point(84, 28)
        Me.TxtLocalFile2.Name = "TxtLocalFile2"
        Me.TxtLocalFile2.Size = New System.Drawing.Size(328, 20)
        Me.TxtLocalFile2.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Remote File"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Local File"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(774, 356)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "xfNetLink Binary Parameter Demo"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.LocalFile1Drill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RemoteFile1Drill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.RemoteFile2Drill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LocalFile2Drill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim Server As xfpldemo.utils
    Dim Connected As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Server = New xfpldemo.utils
            Server.connect()
            Connected = True
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try

    End Sub

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        If Connected Then
            Try
                Server.disconnect()
            Catch ex As Exception
            Finally
                Server = Nothing
            End Try
        End If

    End Sub

    Private Sub BtnGetLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetLogo.Click

        Dim Status As Integer
        Dim FileData(0) As Byte
        Dim GotFile As Boolean

        'Get binary file data from server
        Try
            Status = Server.GetLogo(FileData)
            GotFile = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Save binary data to local file
        If GotFile Then

            'Load the binary data into a memory stream
            Dim mem As New MemoryStream(FileData)

            'Use the memory stream as the image source for the PictureBox
            PictureBox1.Image = Image.FromStream(mem)

            BtnGetLogo.Enabled = False

        End If

    End Sub

    Private Sub BtnGetFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetFile.Click

        Dim Status As Integer
        Dim FileData(0) As Byte
        Dim GotData As Boolean
        Dim ErrorText As String = ""

        Try
            Status = Server.DownloadFile(TxtRemoteFile1.Text, FileData)
            If Status = 0 Then
                GotData = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Save binary data to a local file
        If GotData Then
            If BinaryToFile(FileData, TxtLocalFile1.Text, ErrorText) Then
                MsgBox("File was Downloaded.")
            Else
                MsgBox(ErrorText)
            End If
        End If

    End Sub

    Private Sub BtnSendFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSendFile.Click

        Dim Status As Integer
        Dim FileData() As Byte

        If FileToBinary(TxtLocalFile2.Text, FileData) Then
            Try
                Status = Server.UploadFile(FileData, TxtRemoteFile2.Text)
                If Status = 0 Then
                    MsgBox("File was uploaded.")
                Else
                    MsgBox("Failed to retrieve file.")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Failed to load file into memory")
        End If

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click

        Me.Close()

    End Sub

    Private Function BinaryToFile(ByRef FileData() As Byte, ByVal FileName As String, Optional ByRef ErrorText As String = "") As Boolean

        Dim OK As Boolean = True
        Dim fs As FileStream
        Dim bw As BinaryWriter = Nothing

        ErrorText = ""

        'Create FileStream
        Try
            fs = New FileStream(FileName, System.IO.FileMode.CreateNew)
        Catch ex As Exception
            ErrorText = "Failed to create FileStream." & vbCrLf & ex.Message
            fs = Nothing
            OK = False
        End Try

        'Create BinaryWriter
        If OK Then
            Try
                bw = New BinaryWriter(fs)
            Catch ex As Exception
                ErrorText = "Failed to create BinaryWriter." & vbCrLf & ex.Message
                bw = Nothing
                OK = False
            End Try
        End If

        'Write data to file
        If OK Then
            Dim i As Integer
            For i = 0 To UBound(FileData)
                bw.Write(FileData(i))
            Next i
        End If

        If Not IsNothing(bw) Then bw.Close()
        If Not IsNothing(fs) Then fs.Close()

        Return OK

    End Function

    Private Function FileToBinary(ByVal FileName As String, ByRef FileData() As Byte, Optional ByRef ErrorText As String = "") As Boolean

        Dim OK As Boolean = True
        Dim fs As FileStream
        Dim br As BinaryReader = Nothing

        ErrorText = ""

        'Create SileStream
        Try
            fs = New FileStream(FileName, System.IO.FileMode.Open)
        Catch ex As Exception
            ErrorText = "Failed to open file " & FileName & vbCrLf & ex.Message
            fs = Nothing
            OK = False
        End Try

        'Create BinaryReader
        If OK Then
            Try
                br = New BinaryReader(fs)
            Catch ex As Exception
                ErrorText = "Failed to create BinaryReader." & vbCrLf & ex.Message
                br = Nothing
                OK = False
            End Try
        End If

        'Read data from file
        If OK Then
            ReDim FileData(fs.Length - 1)
            FileData = br.ReadBytes(fs.Length)
        End If

        If Not IsNothing(br) Then br.Close()
        If Not IsNothing(fs) Then fs.Close()

        Return OK

    End Function

    Private Sub RemoteFile1Drill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoteFile1Drill.Click
        If OpenFileDialog.ShowDialog(Me) = DialogResult.OK Then
            TxtRemoteFile1.Text = OpenFileDialog.FileName
        End If
    End Sub

    Private Sub LocalFile1Drill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocalFile1Drill.Click
        If SaveFileDialog.ShowDialog(Me) = DialogResult.OK Then
            TxtLocalFile1.Text = SaveFileDialog.FileName
        End If
    End Sub

    Private Sub LocalFile2Drill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocalFile2Drill.Click
        If OpenFileDialog.ShowDialog(Me) = DialogResult.OK Then
            TxtLocalFile2.Text = OpenFileDialog.FileName
        End If
    End Sub

    Private Sub RemoteFile2Drill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoteFile2Drill.Click
        If SaveFileDialog.ShowDialog(Me) = DialogResult.OK Then
            TxtRemoteFile2.Text = SaveFileDialog.FileName
        End If
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class
