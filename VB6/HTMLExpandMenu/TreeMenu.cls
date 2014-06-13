VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "TreeMenu"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit


Public Function DisplayMenu(strFormat As String, ParamArray varInputArray() As Variant) As String
    
    Dim strFormatArray() As String
    Dim intCutOffLevel As Integer, intPosition As Integer
    
    Dim intUbound As Integer, intLBound As Integer
    Dim intOuterLoop As Integer, intInnerLoop As Integer, intMenuUBound As Integer
    Dim intCount As Integer, intMenuItemLoop As Integer
    Dim intCurrentLevel As Integer
    Dim strIcon As String, strTempFormat As String
    
    ' --------------------------------Data Initialisation -----------------------------------
    
    intUbound = UBound(varInputArray)
    intLBound = 0 ' using 0 as lower bound (default)
    intMenuUBound = (intUbound + 1) / 4 - 1
    
    ' Must be groups of 4 - copy to 2d array
    ReDim strFormatArray(intMenuUBound, 3)
    
    For intOuterLoop = intLBound To intMenuUBound
        For intInnerLoop = 0 To 3
            strFormatArray(intOuterLoop, intInnerLoop) = varInputArray(intCount)
            intCount = intCount + 1
        Next
    Next
            
    
    intCutOffLevel = 1
    intPosition = 1

    DisplayMenu = "<table border=""0"" cellpadding=""2"">" & vbCrLf
    
    If strFormat = "" Then
        strFormat = CStr(String(intMenuUBound + 1, "0"))
    End If

    For intMenuItemLoop = 0 To intMenuUBound

        intCurrentLevel = strFormatArray(intMenuItemLoop, 0)
        strIcon = "<td align=""right"" valign=""top"">&nbsp;</td>"

        If intCurrentLevel <= intCutOffLevel Then
        
            If CInt(strFormatArray(intMenuItemLoop, 1)) = 1 Then

                ' has child levels
                
                If CStr(Mid(strFormat, intPosition, 1)) = "1" Then
                    ' children expanded
                    intCutOffLevel = intCurrentLevel + 1
                    strTempFormat = Left(strFormat, intPosition - 1) & "0" & Right(strFormat, Len(strFormat) - intPosition)
                    strIcon = "<a href=menu.asp?format=" & strTempFormat & "><td align=""right"" valign=""top"" align=""middle""><img src=""images/expanded.gif"" alt=""[-]"" border=""0""></a></td>"
                Else
                    ' children not expanded
                    intCutOffLevel = intCurrentLevel
                    strTempFormat = Left(strFormat, intPosition - 1) & "1" & Right(strFormat, Len(strFormat) - intPosition)
                    strIcon = "<a href=menu.asp?format=" & strTempFormat & "><td align=""right"" valign=""top"" align=""middle""><img src=""images/unexpanded.gif"" alt=""[+]"" border=""0""></a></td>"
                End If

            Else
                intCutOffLevel = intCurrentLevel
            End If

            If intCurrentLevel = 1 Then
    
                DisplayMenu = DisplayMenu & _
                    "<tr>" & vbCrLf & _
                        "<td colspan=""2""><hr size=""3"" noshade>" & vbCrLf & _
                        "</td>" & vbCrLf & _
                    "</tr>" & vbCrLf & _
                        "<tr>" & vbCrLf & _
                        strIcon & _
                        "<td><a href=""" & strFormatArray(intMenuItemLoop, 3) & """ target=""main""><font size=""2""><b>" & _
                        strFormatArray(intMenuItemLoop, 2) & "</b></font></a></td>" & vbCrLf & _
                    "</tr>"
            ElseIf intCurrentLevel = 2 Then
                DisplayMenu = DisplayMenu & _
                    "<tr>" & vbCrLf & _
                    strIcon & _
                    "<td><a href=""" & strFormatArray(intMenuItemLoop, 3) & """ target=""main""><font size=""2"">" & _
                    strFormatArray(intMenuItemLoop, 2) & "</font></a></td>" & vbCrLf & _
                    "</tr>"
  
            ElseIf intCurrentLevel = 3 Then
                DisplayMenu = DisplayMenu & _
                "<tr>" & vbCrLf & _
                    strIcon & _
                    "<td><a href=""" & strFormatArray(intMenuItemLoop, 3) & """ target=""main""><font size=""2""><i>" & _
                    strFormatArray(intMenuItemLoop, 2) & "</font></i></a></td>" & vbCrLf & _
                "</tr>"
            End If
        End If

        intPosition = intPosition + 1
    
    Next

    DisplayMenu = DisplayMenu & "</table>" & vbCrLf

End Function
