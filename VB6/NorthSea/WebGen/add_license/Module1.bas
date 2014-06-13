Attribute VB_Name = "Module1"
Sub Main()
    
    Dim UsageCount As Integer
    Dim CutOffDate, CurrentDate As String

    '*******************************************************************
    'EDIT THESE DATES BEFORE COMPILING THE PROGRAM!!!!!
    CreateDate = "19991215"     'Date patch program is being compiled
    CutOffDate = "19991217"     'Latest date patch program can run
    '*******************************************************************
    
    'Get current date in YYYYMMDD format
    CurrentDate = Format(Year(Now), "0000") & Format(Month(Now), "00") & Format(Day(Now), "00")
    
    'Compare to cutoff date
    If (CurrentDate > CutOffDate) Then
        
        'Re-licence program has expired!
        MsgBox "Sorry, this licence patch has expired!"
    
    Else
        
        If GetSettingString(HKEY_LOCAL_MACHINE, "Software\ISSL\", CStr(CreateDate), "") = CreateDate Then
            
            'This patch program has already been used on this system!
            MsgBox "Sorry, this licence patch has already been applied!"
        
        Else
            
            'Save patch information to registry
            Call SaveSettingString(HKEY_LOCAL_MACHINE, "Software\ISSL\", CStr(CreateDate), CStr(CreateDate))
            
            'Reset usage count to 0 in Registry
            UsageCount = (0 + 479) * 7
            Call SaveSettingString(HKEY_LOCAL_MACHINE, "Software\ISSL\", "AppPosTop", CStr(UsageCount))
        
            'Report success
            MsgBox "Your licence count has been reset to 20"
        
        End If
    
    End If
    
End Sub
