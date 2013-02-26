VERSION 5.00
Begin VB.UserControl Map 
   ClientHeight    =   3600
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4800
   ScaleHeight     =   3600
   ScaleWidth      =   4800
   Begin VB.PictureBox Picture1 
      Height          =   1695
      Left            =   240
      ScaleHeight     =   1635
      ScaleWidth      =   2475
      TabIndex        =   0
      Top             =   480
      Width           =   2535
   End
End
Attribute VB_Name = "Map"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Public Event Quit()

Dim WithEvents MapPoint As MapPoint.Application
Attribute MapPoint.VB_VarHelpID = -1
Dim WithEvents Map As MapPoint.Map
Attribute Map.VB_VarHelpID = -1

Private Sub UserControl_Initialize()
    Set MapPoint = CreateObject("mappoint.application")
    Set Map = MapPoint.ActiveMap
    With MapPoint
        .Visible = True
        .UserControl = False
    End With
End Sub

Private Sub MapPoint_Quit()
    RaiseEvent Quit
End Sub

Private Sub UserControl_Terminate()
    Set Map = Nothing
    Set MapPoint = Nothing
End Sub

Public Sub GotoAddress(ByVal Address As String)
    'Zoom to a location
    Set Map.Location = Map.FindResults(Address)(1)
    Map.Saved = True
End Sub

Public Sub AddPushPin(ByVal Address As String, _
    Optional ByVal Name As String = "", _
    Optional ByVal Note As String = "", _
    Optional ByVal GoThere As Boolean = False)

    Dim FindResults As Object
    Dim PushPin As PushPin
    
    Set FindResults = Map.FindResults(Address)(1)
    
    Set PushPin = Map.AddPushPin(FindResults)
    
    With PushPin
    
        If Name <> " " Then
            .Name = Name
        End If
    
        If Note <> " " Then
            .Note = Note
        End If
        
        .Symbol = 85
        .BalloonState = geoDisplayBalloon
    
    End With

    If GoThere Then
        Set Map.Location = FindResults
    End If
    
    Map.ActiveRoute.Waypoints.Add PushPin
    
    Set PushPin = Nothing
    Set FindResults = Nothing

    Map.Saved = True

End Sub

Public Sub CreateRoute()
    With Map
        .ActiveRoute.Calculate
        .Saved = True
    End With
End Sub

Public Sub SaveMap(ByVal FileName As String)
    Map.SaveAs (FileName)
End Sub

