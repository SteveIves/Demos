Imports System.ServiceProcess

Public Class FrmMain

    Private sc As ServiceController

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LblStatus.Text = ""

    End Sub

    Private Function IsRunning(ByVal ServiceName As String) As Boolean

        Dim RetVal As Boolean = False

        sc = New ServiceController

        Try
            sc.ServiceName = ServiceName
            Select Case sc.Status
                Case ServiceControllerStatus.Running
                    RetVal = True
            End Select
        Catch ex As Exception

        End Try

        sc.Dispose()

        Return RetVal

    End Function

    Private Function StartService(ByVal ServiceName As String) As Boolean

        Dim RetVal As Boolean = False

        sc = New ServiceController

        Try
            sc.ServiceName = ServiceName
            Select Case sc.Status
                Case ServiceControllerStatus.Paused, ServiceControllerStatus.Stopped
                    sc.Start()
            End Select
            RetVal = True
        Catch ex As Exception

        End Try

        sc.Dispose()

        Return RetVal

    End Function

    Private Function StopService(ByVal ServiceName As String) As Boolean

        Dim RetVal As Boolean = False

        sc = New ServiceController

        Try
            sc.ServiceName = ServiceName
            Select Case sc.Status
                Case ServiceControllerStatus.Running
                    sc.Stop()
            End Select
            RetVal = True
        Catch ex As Exception

        End Try

        sc.Dispose()

        Return RetVal

    End Function


    Private Sub BtnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCheck.Click

        If TxtService.Text.Length > 0 Then
            If IsRunning(TxtService.Text) Then
                LblStatus.Text = "Started"
                BtnAction.Text = "Stop"
            Else
                LblStatus.Text = "Stopped"
                BtnAction.Text = "Start"
            End If
        End If

        BtnAction.Enabled = True

    End Sub

    Private Sub BtnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAction.Click

        If BtnAction.Text = "Start" Then
            If StartService(TxtService.Text) Then
                LblStatus.Text = "Started"
                BtnAction.Text = "Stop"
            End If
        Else
            If StopService(TxtService.Text) Then
                LblStatus.Text = "Stopped"
                BtnAction.Text = "Start"
            End If
        End If

    End Sub

End Class