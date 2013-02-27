Public Class frmEnvVar

    Private pEnvVar As EnvironmentVariable

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        pEnvVar = New EnvironmentVariable()
    End Sub

    Public Sub New(ByRef EnvironmentVariableToEdit As EnvironmentVariable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        With EnvironmentVariableToEdit
            pEnvVar = New EnvironmentVariable(.Name, .Value)
        End With
    End Sub

    Private Sub frmEnvVar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With pEnvVar
            txtVariable.Text = .Name
            txtValue.Text = .Value
        End With

    End Sub

    Public ReadOnly Property EnvironmentVariable() As EnvironmentVariable
        Get
            Return pEnvVar
        End Get
    End Property

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If txtVariable.Text.Length = 0 Then
            MessageBox.Show("Environment variable name is reqired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If txtValue.Text.Length = 0 Then
            MessageBox.Show("Environment variable value is reqired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        With pEnvVar
            .Name = txtVariable.Text
            .Value = txtValue.Text
        End With

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

End Class