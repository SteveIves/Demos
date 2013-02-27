Public Class LoginForm

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Me.Cursor = Cursors.WaitCursor

        'Set up initial credentials
        Credentials = New webserver.ServiceCredentials
        With Credentials
            .Username = UsernameTextBox.Text
            .Password = PasswordTextBox.Text
        End With

        'Specify the initial credentials
        GalleryService.ServiceCredentialsValue = Credentials

        'Get a list of all galleries

        Dim Galleries() As String
        Dim LoggedIn As Boolean
        Try
            Galleries = GalleryService.Galleries
            LoggedIn = True
        Catch ex As Exception
            'If we get an error here then the login is invalid
            MsgBox(ex.Message)
            UsernameTextBox.Clear()
            PasswordTextBox.Clear()
        End Try

        Me.Cursor = Cursors.Default

        If LoggedIn Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            GalleryService = Nothing
            Credentials = Nothing
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
