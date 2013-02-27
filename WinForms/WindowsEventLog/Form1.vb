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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' If an event source for this application does not exist then create a new one
        If Not EventLog.SourceExists("WritsClient") Then
            EventLog.CreateEventSource("WritsClient", "Manatron Applications")
        End If

        ' Create an EventLog instance and assign its log name and source
        Dim myLog As New EventLog("Manatron Applications", ".", "WritsClient")

        ' Write entries to the log
        myLog.WriteEntry("Information message", EventLogEntryType.Information)
        myLog.WriteEntry("Application error 100.", EventLogEntryType.Error, 100)
        myLog.WriteEntry("Application warning 10.", EventLogEntryType.Warning, 10)

        'myLog.Delete("Manatron Applications")

        myLog.Dispose()

    End Sub
End Class
