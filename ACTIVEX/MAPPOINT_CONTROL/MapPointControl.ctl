VERSION 5.00
Object = "{51C0A9CA-F7B7-4F5A-96F4-43927C6FA50F}#1.0#0"; "MapPointControl.ocx"
Begin VB.UserControl MapPointControl 
   ClientHeight    =   6870
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   8895
   ScaleHeight     =   6870
   ScaleWidth      =   8895
   Begin MapPointCtl.MappointControl MappointControl1 
      Height          =   3855
      Left            =   1440
      TabIndex        =   0
      Top             =   840
      Width           =   5895
      BorderStyle     =   0
      MousePointer    =   0
      Object.TabStop         =   0   'False
      Appearance      =   1
      PaneState       =   3
      UnitsOfMeasure  =   0
   End
End
Attribute VB_Name = "MapPointControl"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Private Sub UserControl_Initialize()

    Dim objMap As MapPointCtl.Map
    
    With MappointControl1

        'Create a new map and get a reference to it
        .NewMap geoMapNorthAmerica
        Set objMap = .ActiveMap
        
        'Setup the control's UI
        With .Toolbars
            .Item("Standard").Visible = True
            .Item("Navigation").Visible = True
            .Item("Location and Scale").Visible = True
            .Item("Drawing").Visible = True
        End With
        
        .PaneState = geoPaneNone
        
    End With
    
    'Configure map settings
    With objMap
        .MapStyle = geoMapStyleRoad
        .MapFont = geoMapFontSmaller
        .Projection = geoGlobeViewWhenZoomedOut
        .Saved = True
    End With
    
End Sub

Private Sub UserControl_Resize()
    With MappointControl1
        .Top = 1
        .Left = 1
        .Width = UserControl.ScaleWidth
        .Height = UserControl.ScaleHeight
    End With
    Refresh
End Sub

Private Sub UserControl_Terminate()
    MappointControl1.ActiveMap.Saved = True
End Sub

Public Sub AddPushPin(ByVal Address As String, Optional ByVal Name As String = "Customer location")
    Dim FindResults As Object
    Dim PushPin As PushPin
    With MappointControl1.ActiveMap
        Set FindResults = .FindResults(Address)(1)
        Set PushPin = .AddPushPin(FindResults, Name)
        .ActiveRoute.Waypoints.Add PushPin
        .Saved = True
    End With
End Sub

Public Sub CreateRoute()
    With MappointControl1.ActiveMap
        .ActiveRoute.Calculate
        .Saved = True
    End With
End Sub
