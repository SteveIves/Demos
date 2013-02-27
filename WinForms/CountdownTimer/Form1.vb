
Public Class Form1

    Public SpcStartTime As Date
    Public ExcludedDays As Integer
    Public EventName As String


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Show()

        Do
            Try
                EventName = Application.UserAppDataRegistry.GetValue("EventName")
            Catch ex As Exception
                MsgBox(ex.Message)
                End
            End Try
            If Not IsNothing(EventName) Then
                Exit Do
            Else
                Dim x As New frmEvent()
                x.ShowDialog(Me)
                If x.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    End
                End If
            End If
        Loop

        Me.Text = EventName & " Countdown"

        SpcStartTime = New Date(2007, 5, 22, 9, 0, 0)
        DisplayMode.SelectedIndex = 0

        If chkExcludeWeekends.Checked Then
            ExcludedDays = WeekendDays()
        End If

        With Timer1
            .Interval = 1000
            .Start()
        End With

    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        With Label1
            .Top = Panel.Height
            .Left = 0
            .Width = Me.Width
            .Height = Me.Height - Panel.Height
        End With

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim Count As Long

        With SpcStartTime.Subtract(Now).Subtract(New TimeSpan(ExcludedDays, 0, 0, 0))

            Select Case DisplayMode.SelectedItem
                Case "Countdown"
                    Label1.Text = .Days & " days " & Format(.Hours, "00") & ":" & Format(.Minutes, "00") & ":" & Format(.Seconds, "00")
                Case "Hours"
                    Count = .TotalHours
                    Label1.Text = Format(Count, "###,###,##0") & " hours"
                Case "Minutes"
                    Count = .TotalMinutes
                    Label1.Text = Format(Count, "###,###,###,##0") & " minutes"
                Case "Seconds"
                    Count = .TotalSeconds
                    Label1.Text = Format(Count, "###,###,###,###,##0") & " seconds"
            End Select


        End With

    End Sub

    Private Function WeekendDays() As Integer

        Dim Days As Integer
        Dim Span As TimeSpan
        Dim Count As Integer
        Span = SpcStartTime - Now
        Days = Span.Days
        Dim ExcDays As Integer

        If Now.DayOfWeek = DayOfWeek.Saturday Or Now.DayOfWeek = DayOfWeek.Sunday Then
            ExcDays = 1
        End If

        For Count = 1 To Days
            If Now.AddDays(Count).DayOfWeek = DayOfWeek.Saturday Or Now.AddDays(Count).DayOfWeek = DayOfWeek.Sunday Then
                ExcDays += 1
            End If
        Next

        Return ExcDays

    End Function


    Private Sub exclude_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExcludeWeekends.CheckedChanged, chkExcludeAdditional.CheckedChanged

        ExcludedDays = 0

        If chkExcludeWeekends.Checked Then
            ExcludedDays += WeekendDays()
        End If

        If chkExcludeAdditional.Checked Then
            With (txtExcludeAdditional)
                If (.Text.Length = 0) Then
                    .Text = 0
                End If
                .Enabled = True
            End With
            ExcludedDays += Integer.Parse(txtExcludeAdditional.Text)
        Else
            With (txtExcludeAdditional)
                .Text = 0
                .Enabled = False
            End With
        End If

    End Sub

    Private Sub txtExcludeAdditional_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExcludeAdditional.TextChanged

        Try
            Integer.Parse(txtExcludeAdditional.Text)
        Catch ex As Exception
            txtExcludeAdditional.Text = ""
            Exit Sub
        End Try


    End Sub

End Class
