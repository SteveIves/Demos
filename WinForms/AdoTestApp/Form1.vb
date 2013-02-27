Imports System.Data.SqlClient

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
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents ListBox As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.ListBox = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'StatusBar
        '
        Me.StatusBar.Location = New System.Drawing.Point(0, 416)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.ShowPanels = True
        Me.StatusBar.Size = New System.Drawing.Size(752, 22)
        Me.StatusBar.TabIndex = 0
        '
        'ListBox
        '
        Me.ListBox.Location = New System.Drawing.Point(20, 12)
        Me.ListBox.Name = "ListBox"
        Me.ListBox.Size = New System.Drawing.Size(716, 381)
        Me.ListBox.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(752, 438)
        Me.Controls.Add(Me.ListBox)
        Me.Controls.Add(Me.StatusBar)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim Database As SqlConnection
    Dim Command As SqlCommand
    Dim DataReader As SqlDataReader
    Dim DbConnected As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ConnectString As String

        'Ensure the main form is visible
        Me.Show()

        'Create a connection to the Northwind database
        ConnectString = "Data Source=LOCALHOST\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Northwind"
        Me.Cursor = Cursors.WaitCursor
        StatusBar.Text = "Connecting to database..."
        Try
            Database = New SqlConnection(ConnectString)
            Database.Open()    'There's a 15 second timeout
            DbConnected = True
        Catch ex As Exception
            MsgBox("Failed to connect to database!" & vbCrLf & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            StatusBar.Text = ""
        End Try

        If Not DbConnected Then Exit Sub

        'Create and execute a SQL command
        Command = New SqlCommand("SELECT CategoryID, CategoryName FROM Categories", Database)
        DataReader = Command.ExecuteReader()

        'Display the results
        If DataReader.HasRows Then
            Do While DataReader.Read()
                ListBox.Items.Add(DataReader.GetInt32(0).ToString & " " & DataReader.GetString(1))
            Loop
        Else
            ListBox.Items.Add("No rows returned.")
        End If

        'Close the data reader
        DataReader.Close()

    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        'Close the database connection
        If DbConnected Then
            Try
                Database.Close()
            Catch ex As Exception

            End Try
        End If

    End Sub
End Class
