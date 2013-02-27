Public Class Form1
	Inherits System.Windows.Forms.Form

	Private ObjArray() As Object
	Private ObjCount As Integer = 0

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
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents ProgID As System.Windows.Forms.TextBox
	Friend WithEvents BtnAllocate As System.Windows.Forms.Button
	Friend WithEvents BtnDeallocate As System.Windows.Forms.Button
	Friend WithEvents BtnReset As System.Windows.Forms.Button
	Friend WithEvents ObjectCount As System.Windows.Forms.TextBox
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.BtnAllocate = New System.Windows.Forms.Button
        Me.BtnDeallocate = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ObjectCount = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ProgID = New System.Windows.Forms.TextBox
        Me.BtnReset = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'BtnAllocate
        '
        Me.BtnAllocate.Enabled = False
        Me.BtnAllocate.Location = New System.Drawing.Point(168, 48)
        Me.BtnAllocate.Name = "BtnAllocate"
        Me.BtnAllocate.Size = New System.Drawing.Size(72, 24)
        Me.BtnAllocate.TabIndex = 1
        Me.BtnAllocate.Text = "&Allocate"
        '
        'BtnDeallocate
        '
        Me.BtnDeallocate.Enabled = False
        Me.BtnDeallocate.Location = New System.Drawing.Point(248, 48)
        Me.BtnDeallocate.Name = "BtnDeallocate"
        Me.BtnDeallocate.Size = New System.Drawing.Size(72, 24)
        Me.BtnDeallocate.TabIndex = 2
        Me.BtnDeallocate.Text = "&Deallocate"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Objects allocated"
        '
        'ObjectCount
        '
        Me.ObjectCount.Location = New System.Drawing.Point(112, 48)
        Me.ObjectCount.Name = "ObjectCount"
        Me.ObjectCount.ReadOnly = True
        Me.ObjectCount.Size = New System.Drawing.Size(40, 20)
        Me.ObjectCount.TabIndex = 4
        Me.ObjectCount.Text = "0"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "COM ProgID"
        '
        'ProgID
        '
        Me.ProgID.Location = New System.Drawing.Point(112, 16)
        Me.ProgID.Name = "ProgID"
        Me.ProgID.Size = New System.Drawing.Size(288, 20)
        Me.ProgID.TabIndex = 0
        Me.ProgID.Text = ""
        '
        'BtnReset
        '
        Me.BtnReset.Enabled = False
        Me.BtnReset.Location = New System.Drawing.Point(328, 48)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(72, 24)
        Me.BtnReset.TabIndex = 3
        Me.BtnReset.Text = "&Reset"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(408, 86)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.ProgID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ObjectCount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnDeallocate)
        Me.Controls.Add(Me.BtnAllocate)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Pool Test Utility"
        Me.ResumeLayout(False)

    End Sub

#End Region

	Private Sub ProgID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgID.TextChanged

		If ProgID.Text.Length Then
			BtnAllocate.Enabled = True
		Else
			BtnAllocate.Enabled = False
		End If

	End Sub

	Private Sub ProgID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProgID.Leave

		ProgID.Enabled = False

	End Sub

	Private Sub Form1_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed

		DeallocateAll()

	End Sub

	Private Sub BtnAllocate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAllocate.Click

		BtnAllocate.Cursor = Windows.Forms.Cursors.WaitCursor

		Dim TempHandle As Object

		Try
			TempHandle = CreateObject(ProgID.Text)
			ReDim Preserve ObjArray(ObjCount)
			ObjArray(ObjCount) = TempHandle
			ObjCount = ObjCount + 1
			ObjectCount.Text = ObjCount
			If ObjCount = 1 Then
				BtnDeallocate.Enabled = True
				BtnReset.Enabled = True
			End If

		Catch ex As Exception

			If MsgBox(ex.Message & " Show full error?", MsgBoxStyle.YesNo Or _
			  MsgBoxStyle.Exclamation, "Error") = MsgBoxResult.Yes Then
				MsgBox(ex.ToString)
			End If

		Finally

			If ObjCount = 0 Then
				With ProgID
					.Enabled = True
					.Focus()
				End With
			End If

		End Try

		BtnAllocate.Cursor = Windows.Forms.Cursors.Default

	End Sub

	Private Sub BtnDeallocate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeallocate.Click

		BtnAllocate.Cursor = Windows.Forms.Cursors.WaitCursor

		ObjCount = ObjCount - 1
		ObjArray(ObjCount).Dispose()
		ObjArray(ObjCount) = Nothing
		ReDim Preserve ObjArray(ObjCount - 1)

		ObjectCount.Text = ObjCount
		If ObjCount = 0 Then
			BtnDeallocate.Enabled = False
			BtnReset.Enabled = False
			With ProgID
				.Enabled = True
				.Focus()
			End With
		End If

		BtnAllocate.Cursor = Windows.Forms.Cursors.Default

	End Sub

	Private Sub BtnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReset.Click

		BtnAllocate.Cursor = Windows.Forms.Cursors.WaitCursor

		DeallocateAll()

		BtnDeallocate.Enabled = False
		BtnReset.Enabled = False
		With ProgID
			.Enabled = True
			.Focus()
		End With

		BtnAllocate.Cursor = Windows.Forms.Cursors.Default

	End Sub

	Private Sub DeallocateAll()

		If ObjCount > 0 Then
			Dim i As Integer
			For i = 0 To ObjCount - 1
				ObjArray(i).Dispose()
				ObjArray(i) = Nothing
			Next
			ObjCount = 0
			ObjectCount.Text = "0"
		End If

	End Sub

End Class
