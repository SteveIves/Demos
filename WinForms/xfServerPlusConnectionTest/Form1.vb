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
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIncrement As System.Windows.Forms.TextBox
    Friend WithEvents BtnDisconnect As System.Windows.Forms.Button
    Friend WithEvents BtnConnect As System.Windows.Forms.Button
    Friend WithEvents txtConnectionCount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.GroupBox
    Friend WithEvents pgCyclesCompleted As System.Windows.Forms.ProgressBar
    Friend WithEvents btnConnectDisconnect As System.Windows.Forms.Button
    Friend WithEvents txtCycleCount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.GroupBox
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtIncrement = New System.Windows.Forms.TextBox
        Me.BtnDisconnect = New System.Windows.Forms.Button
        Me.BtnConnect = New System.Windows.Forms.Button
        Me.txtConnectionCount = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.GroupBox
        Me.pgCyclesCompleted = New System.Windows.Forms.ProgressBar
        Me.btnConnectDisconnect = New System.Windows.Forms.Button
        Me.txtCycleCount = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(311, 310)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtPort)
        Me.Panel1.Controls.Add(Me.txtServer)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(12, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(374, 87)
        Me.Panel1.TabIndex = 14
        Me.Panel1.TabStop = False
        Me.Panel1.Text = "Server Connection Details"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(126, 52)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(66, 20)
        Me.txtPort.TabIndex = 17
        Me.txtPort.Text = "2356"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(126, 24)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(126, 20)
        Me.txtServer.TabIndex = 16
        Me.txtServer.Text = "localhost"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Port"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Server"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtIncrement)
        Me.Panel2.Controls.Add(Me.BtnDisconnect)
        Me.Panel2.Controls.Add(Me.BtnConnect)
        Me.Panel2.Controls.Add(Me.txtConnectionCount)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(12, 98)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(374, 100)
        Me.Panel2.TabIndex = 15
        Me.Panel2.TabStop = False
        Me.Panel2.Text = "Cumulative Connection Test"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Increment by"
        '
        'txtIncrement
        '
        Me.txtIncrement.Location = New System.Drawing.Point(126, 28)
        Me.txtIncrement.Name = "txtIncrement"
        Me.txtIncrement.Size = New System.Drawing.Size(100, 20)
        Me.txtIncrement.TabIndex = 13
        Me.txtIncrement.Text = "10"
        '
        'BtnDisconnect
        '
        Me.BtnDisconnect.Location = New System.Drawing.Point(264, 58)
        Me.BtnDisconnect.Name = "BtnDisconnect"
        Me.BtnDisconnect.Size = New System.Drawing.Size(84, 23)
        Me.BtnDisconnect.TabIndex = 16
        Me.BtnDisconnect.Text = "Disconnect All"
        '
        'BtnConnect
        '
        Me.BtnConnect.Location = New System.Drawing.Point(264, 26)
        Me.BtnConnect.Name = "BtnConnect"
        Me.BtnConnect.Size = New System.Drawing.Size(84, 23)
        Me.BtnConnect.TabIndex = 15
        Me.BtnConnect.Text = "Connect"
        '
        'txtConnectionCount
        '
        Me.txtConnectionCount.Enabled = False
        Me.txtConnectionCount.Location = New System.Drawing.Point(126, 60)
        Me.txtConnectionCount.Name = "txtConnectionCount"
        Me.txtConnectionCount.ReadOnly = True
        Me.txtConnectionCount.Size = New System.Drawing.Size(100, 20)
        Me.txtConnectionCount.TabIndex = 14
        Me.txtConnectionCount.Text = "0"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Current connections"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pgCyclesCompleted)
        Me.Panel3.Controls.Add(Me.btnConnectDisconnect)
        Me.Panel3.Controls.Add(Me.txtCycleCount)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(12, 204)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(374, 100)
        Me.Panel3.TabIndex = 16
        Me.Panel3.TabStop = False
        Me.Panel3.Text = "Connect / Disconnect Test"
        '
        'pgCyclesCompleted
        '
        Me.pgCyclesCompleted.Location = New System.Drawing.Point(22, 63)
        Me.pgCyclesCompleted.Name = "pgCyclesCompleted"
        Me.pgCyclesCompleted.Size = New System.Drawing.Size(333, 12)
        Me.pgCyclesCompleted.Step = 1
        Me.pgCyclesCompleted.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pgCyclesCompleted.TabIndex = 19
        '
        'btnConnectDisconnect
        '
        Me.btnConnectDisconnect.Location = New System.Drawing.Point(271, 26)
        Me.btnConnectDisconnect.Name = "btnConnectDisconnect"
        Me.btnConnectDisconnect.Size = New System.Drawing.Size(84, 23)
        Me.btnConnectDisconnect.TabIndex = 18
        Me.btnConnectDisconnect.Text = "Go"
        '
        'txtCycleCount
        '
        Me.txtCycleCount.Location = New System.Drawing.Point(133, 28)
        Me.txtCycleCount.Name = "txtCycleCount"
        Me.txtCycleCount.Size = New System.Drawing.Size(100, 20)
        Me.txtCycleCount.TabIndex = 16
        Me.txtCycleCount.Text = "100"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 16)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Connect/Disconnect"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(400, 345)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "xfServerPlus Connection Test"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim ObjectArray As ArrayList

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ObjectArray = New ArrayList

    End Sub

    Private Sub BtnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConnect.Click

        Panel1.Enabled = False
        Panel3.Enabled = False

        Dim count As Integer
        For count = 1 To txtIncrement.Text

            Try

                'Create a new object
                Dim NewObject As New spc2004.utils

                'Connect to xfServerPlus
                NewObject.connect(txtServer.Text, txtPort.Text)

                'Add it to the ArrayList
                ObjectArray.Add(NewObject)

                txtConnectionCount.Text = ObjectArray.Count

            Catch ex As Exception

                MsgBox(ex.Message)
                Exit For

            End Try

            Me.Refresh()

        Next

    End Sub

    Private Sub BtnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDisconnect.Click

        DoDisconnect()
        Panel1.Enabled = True
        Panel3.Enabled = True

    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Integer.Parse(txtConnectionCount.Text) > 0 Then
            DoDisconnect()
        End If

    End Sub

    Private Sub DoDisconnect()

        Dim count As Integer
        Dim ThisObject As spc2004.utils

        For count = ObjectArray.Count - 1 To 0 Step -1
            ThisObject = ObjectArray(count)
            ThisObject.disconnect()
            ObjectArray.RemoveAt(count)
            txtConnectionCount.Text = ObjectArray.Count
            Me.Refresh()
        Next

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnConnectDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnectDisconnect.Click

        Panel1.Enabled = False
        Panel2.Enabled = False
        Panel3.Enabled = False

        Dim Cycles As Integer
        Dim NewObject As New spc2004.utils

        Try
            Cycles = Integer.Parse(txtCycleCount.Text)
        Catch ex As Exception
            MsgBox("Invalid cycle count")
            Exit Sub
        End Try

        With pgCyclesCompleted
            .Maximum = Cycles
            .Value = 0
        End With

        For Cycle As Integer = 1 To Cycles
            Try
                NewObject.connect(txtServer.Text, txtPort.Text)
                NewObject.disconnect()
                pgCyclesCompleted.PerformStep()
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit For
            End Try
        Next

        pgCyclesCompleted.Value = 0

        Panel1.Enabled = True
        Panel2.Enabled = True
        Panel3.Enabled = True

        With txtCycleCount
            .Focus()
            .SelectAll()
        End With

    End Sub

End Class
