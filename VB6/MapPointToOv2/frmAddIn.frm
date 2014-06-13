VERSION 5.00
Object = "{5E9E78A0-531B-11CF-91F6-C2863C385E30}#1.0#0"; "MSFLXGRD.OCX"
Begin VB.Form frmAddIn 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Export TomTom POI's"
   ClientHeight    =   4230
   ClientLeft      =   2175
   ClientTop       =   1935
   ClientWidth     =   6030
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4230
   ScaleWidth      =   6030
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.TextBox PoiCategory 
      Height          =   285
      Left            =   1800
      TabIndex        =   5
      Top             =   3240
      Width           =   2535
   End
   Begin MSFlexGridLib.MSFlexGrid FlexGrid 
      Height          =   2295
      Left            =   120
      TabIndex        =   3
      Top             =   720
      Width           =   4455
      _ExtentX        =   7858
      _ExtentY        =   4048
      _Version        =   393216
      Rows            =   1
      Cols            =   3
      FixedCols       =   0
      AllowUserResizing=   1
   End
   Begin VB.CommandButton CancelButton 
      Caption         =   "Cancel"
      Height          =   375
      Left            =   4680
      TabIndex        =   1
      Top             =   600
      Width           =   1215
   End
   Begin VB.CommandButton ExportButton 
      Caption         =   "Export"
      Enabled         =   0   'False
      Height          =   375
      Left            =   4680
      TabIndex        =   0
      Top             =   120
      Width           =   1215
   End
   Begin VB.Label Label1 
      Caption         =   "POI Category Name"
      Height          =   255
      Left            =   240
      TabIndex        =   4
      Top             =   3240
      Width           =   1455
   End
   Begin VB.Label StatusBox 
      Height          =   255
      Left            =   240
      TabIndex        =   2
      Top             =   240
      Width           =   4215
   End
End
Attribute VB_Name = "frmAddIn"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public Connect As Connect
Public g_oApp As MapPoint.Application

Option Explicit

Private Sub Form_Load()

    MsgBox ("Load")

End Sub

Private Sub Form_Activate()
    
    MsgBox ("Activate")

    Dim DataSet As DataSet, PushpinDataset As DataSet
    Dim GotPushpins As Boolean
    For Each DataSet In g_oApp.ActiveMap.DataSets
        If DataSet.Name = "My Pushpins" Then
            Set PushpinDataset = DataSet
            GotPushpins = True
            Exit For
        End If
    Next

    If GotPushpins = False Then
        StatusBox.Caption = "My Pushpins not found!"
        Exit Sub
    End If
    
    If PushpinDataset.RecordCount = 0 Then
        StatusBox.Caption = "My Pushpins is empty!"
        Exit Sub
    Else
        StatusBox.Caption = PushpinDataset.RecordCount & " pushpins found."
        ExportButton.Enabled = True
    End If
    
    Dim objRs As MapPoint.Recordset
    Dim PushPinField As MapPoint.Field
    
    Set objRs = PushpinDataset.QueryAllRecords
    
    Dim Lat As Double
    Dim Lon As Double
    
    With FlexGrid
        .row = 0
        .Col = 0
        .Text = "Location"
        .Col = 1
        .Text = "Latitude"
        .Col = 2
        .Text = "Longitude"
    End With
    
    objRs.MoveFirst
    Do While Not objRs.EOF
        
        'Get Latitude and Longitude
        Call CalcPos(g_oApp.ActiveMap, objRs.Location, Lat, Lon)
        
        'Add to data grid
        With FlexGrid
            .AddItem (objRs.Pushpin.Name & " " & objRs.Pushpin.Note & vbTab & Lat & vbTab & Lon)
        End With
        
        objRs.MoveNext
    
    Loop


End Sub

Private Sub ExportButton_Click()
        
    If PoiCategory.Text = "" Then
        MsgBox ("Please specify a POI Category name")
        Exit Sub
    End If
    
    Dim row As Integer
    Dim PoiData As String
    
    With FlexGrid
        If .Rows > 1 Then
            Open "c:\" & PoiCategory.Text & ".ovr" For Output As #1
            For row = 1 To .Rows - 1
                .row = row
                .Col = 1
                PoiData = .Text & " , "
                .Col = 2
                PoiData = PoiData & .Text & " , "
                .Col = 0
                PoiData = PoiData & """" & .Text & """"
                Print #1, PoiData
            Next
            Close #1
        End If
    End With
    
    
    Connect.Hide

End Sub

Private Sub CancelButton_Click()
    
    Connect.Hide
    
End Sub
    
' Compute latitude and longitude given a location object
' Author: Gilles Kohl
' (gilles@compuserve.com)
'
' This code is copyrighted freeware - use freely, but please leave this
' header intact. Suggestions and comments welcome.

Function Arccos(x As Double) As Double
   If x = 1 Then
      Arccos = 0
      Exit Function
   End If
   Arccos = Atn(-x / Sqr(-x * x + 1)) + 2 * Atn(1)
End Function

Sub CalcPos(objMap As MapPoint.Map, locX As MapPoint.Location, dblLat As Double, dblLon As Double)
   
   Static locNorthPole As MapPoint.Location
   Static locSantaCruz As MapPoint.Location ' Center of western hemisphere
   Static dblHalfEarth As Double ' Half circumference of the earth (as a sphere)
   Static dblQuarterEarth As Double ' Quarter circumference of the earth (as a sphere)
   Static Pi As Double

   ' Check if initialization already done
   If locNorthPole Is Nothing Then
      Set locNorthPole = objMap.GetLocation(90, 0)
      Set locSantaCruz = objMap.GetLocation(0, -90)

      ' Compute distance between north and south poles == half earth circumference
      dblHalfEarth = objMap.Distance(locNorthPole, objMap.GetLocation(-90, 0))

      ' Quarter of that is the max distance a point may be away from locSantaCruz and still be in western hemisphere
      dblQuarterEarth = dblHalfEarth / 2
      Pi = 3.14159265358979
   End If

   ' Compute latitude from distance to north pole
   dblLat = 90 - 180 * objMap.Distance(locNorthPole, locX) / dblHalfEarth

   Dim l As Double
   Dim d As Double

   ' Compute great circle distance to locX from point on Greenwich meridian and computed Latitude
   d = objMap.Distance(objMap.GetLocation(dblLat, 0), locX)

   ' convert latitude to radian
   l = (dblLat / 180) * Pi

   ' Compute Longitude from great circle distance
   dblLon = 180 * Arccos((Cos((d * 2 * Pi) / (2 * dblHalfEarth)) - Sin(l) * Sin(l)) / (Cos(l) * Cos(l))) / Pi

   ' Correct longitude sign if located in western hemisphere
   If objMap.Distance(locSantaCruz, locX) < dblQuarterEarth Then dblLon = -dblLon

End Sub

