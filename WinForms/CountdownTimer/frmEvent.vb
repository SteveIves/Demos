Public Class frmEvent

    Private Sub frmEvent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtEventDate.MinDate = Now

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If txtEventName.Text.Length = 0 Then
            MsgBox("Please provide an event name")
            txtEventName.Focus()
            Exit Sub
        End If

        With Application.UserAppDataRegistry
            .SetValue("EventName", txtEventName.Text)
            .SetValue("EventDate", dtEventDate.Value.ToShortDateString)
            .SetValue("EventTime", dtEventTime.Value.ToShortTimeString)
        End With

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

End Class