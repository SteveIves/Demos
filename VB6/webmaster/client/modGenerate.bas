Attribute VB_Name = "modGenerate"
Option Explicit

Private Structure As String
Private WebDir As String
Private SynDir As String
Private OutFile As String

Public Sub GeneratePage(FileName As String)

    WebDir = Project.WebDir
    If Right(WebDir, 1) <> "\" Then WebDir = WebDir & "\"
    
    SynDir = Project.SynergyDir
    If Right(SynDir, 1) <> "\" Then SynDir = SynDir & "\"
    
    If FileName = "global.asa" Then
    
        Call GenerateAsa
    
    Else

        Structure = LCase(Project.ProjectFiles(FileName).Structure)
        
        'Generate ASP page & global.asa
        Call GenerateAsp(FileName)
        
        'Generate Synergy support routines & files
        Call GenerateRead
        Call GenerateWrite
        Call GenerateList
        Call GenerateLogin
        Call GenerateLogout
        Call GenerateInclude
        Call GenerateBuild

    End If

End Sub

Private Sub GenerateAsp(FileName As String)

    'Create the ASP page

    Dim Font As String
    Dim c As Integer
    Dim Field As ProjectFileField
    
    OutFile = WebDir & FileName
    Font = "Arial"

    Open OutFile For Output As #1

    Print #1, "<%@ LANGUAGE=""VBScript"" %>"
    Print #1, "<%"
    Print #1, "  Option Explicit"
    Print #1, "  Response.Buffer = True"
    Print #1, "  Response.Expires = -1441"
    Print #1, ""
    Print #1, "  Dim Mode"
    Print #1, "  Mode = Request(""mode"")"
    Print #1, "  If (Mode="""") Then Mode=""list"""
    Print #1, ""
    Print #1, "  Select Case Mode"
    Print #1, "  Case ""do_create"""
    Print #1, ""
    Print #1, "    'Add code to create a new record"
    Print #1, "    '"
    Print #1, "    '"
    Print #1, "    Mode=""list"""
    Print #1, ""
    Print #1, "  Case ""do_update"""
    Print #1, ""
    Print #1, "    'Add code to update an existing record"
    Print #1, "    '"
    Print #1, "    '"
    Print #1, "    Mode=""list"""
    Print #1, ""
    Print #1, "  Case ""do_delete"""
    Print #1, ""
    Print #1, "    'Add code to delete an existing record"
    Print #1, "    '"
    Print #1, "    '"
    Print #1, "    Mode=""list"""
    Print #1, ""
    Print #1, "  End Select"
    Print #1, "%>"
    Print #1, "<html>"
    Print #1, "<head>"
    Print #1, "<title></title>"
    Print #1, "<script language=""JavaScript"">"
    Print #1, "<!--"
    Print #1, "function validate() {"
    Print #1, "  alert(""Validate data"");"
    Print #1, "}"
    Print #1, "function cancel() {"
    Print #1, "  alert(""Cancel action"");"
    Print #1, "}"
    Print #1, "-->"
    Print #1, "</script>"
    Print #1, "</head>"
    Print #1, "<body>"
    
    Print #1, ""
    Print #1, "<!-- LIST MODE ------------------------------------------->"
    Print #1, "<%If (Mode=""list"") Then%>"
    Print #1, "  <!-- Add code here to present a list of records -->"
    Print #1, "<%End If%>"
    Print #1, ""
    
    Print #1, "<!-- CREATE / AMEND MODE --------------------------------->"
    Print #1, "<%"
    Print #1, "  If (Mode=""create"" Or Mode=""amend"") Then"
    Print #1, ""
    
    For Each Field In Project.ProjectFiles(FileName).ProjectFileFields
        With Repository.Structures(Structure).Fields(Field.FieldName)
            Print #1, "    Dim " & .FieldName & "_DATA"
        End With
    Next Field
    
    Print #1, ""
    Print #1, "    If (Mode=""amend"") Then"
    Print #1, ""
    Print #1, "      'Get and lock existing record"
    Print #1, "      Dim Status, Key, Data, Lock"
    Print #1, "      Key=Request(""key"")"
    Print #1, "      Data="""""
    Print #1, "      Lock=1"
    Print #1, ""
    Print #1, "      Status=Synergy.xfSubr(""" & Structure & "_read"",Key,Data,Lock)"
    Print #1, ""
    Print #1, "      If (VarType(Status) = vbError) Then"
    Print #1, "        Session(""ERROR_PAGE"") = """ & FileName & """"
    Print #1, "        Session(""ERROR_PAGE_MODE"") = Mode"
    Print #1, "        Session(""ERROR_ROUTINE"") = """ & Structure & "_read"""
    Print #1, "        Session(""ERROR_TEXT"") = Synergy.getxfErrorMessage"
    Print #1, "        Response.Redirect(""error.asp"")"
    Print #1, "      Else"
    Print #1, "        If (Status <> 0) Then"
    Print #1, "          Session(""ERROR_PAGE"") = """ & FileName & """"
    Print #1, "          Session(""ERROR_PAGE_MODE"") = Mode"
    Print #1, "          Session(""ERROR_ROUTINE"") = """ & Structure & "_read"""
    Print #1, "          Session(""ERROR_TEXT"") = ""Routine returned error "" & Status"
    Print #1, "          Response.Redirect(""error.asp"")"
    Print #1, "        End If"
    Print #1, "      End If"
    Print #1, ""
    Print #1, "      'Load current values into field data for editing"
    
    For Each Field In Project.ProjectFiles(FileName).ProjectFileFields
        With Repository.Structures(Structure).Fields(Field.FieldName)
            Print #1, "      " & .FieldName & "_DATA = Mid(Data," & .Position & "," & .Size & ")"
        End With
    Next Field
    
    Print #1, ""
    Print #1, "    Else"
    Print #1, ""
    
    Print #1, "      'Setup default values in field data for new record"
    
    For Each Field In Project.ProjectFiles(FileName).ProjectFileFields
        With Repository.Structures(Structure).Fields(Field.FieldName)
            Print #1, "      " & .FieldName & "_DATA = """""
        End With
    Next Field
    
    Print #1, ""
    Print #1, "    End If"
    Print #1, "%>"
    
    Print #1, "<form name=""" & Structure & """ action=""" & FileName & """ method=""post"">"
    Print #1, "  <table border=""0"">"
    
    For Each Field In Project.ProjectFiles(FileName).ProjectFileFields
        With Repository.Structures(Structure).Fields(Field.FieldName)
            Print #1, "    <tr>"
            Print #1, "      <td><font face=""" & Font & """>" & .Prompt & "</font></td>"
            Print #1, "      <td><input type=""text"" name=""" & .FieldName & """ size=""" & .Size & """ maxlength=""" & .Size & """ value=""<%=" & .FieldName & "_DATA%>""></td>"
            Print #1, "    </tr>"
        End With
    Next Field
    
    Print #1, "    <tr>"
    Print #1, "      <td>&nbsp;</td>"
    Print #1, "      <td>"
    Print #1, "        <input type=""hidden"" name=""mode"" value=""do_<%=Mode%>"">"
    Print #1, "        <input type=""button"" value=""OK"" onclick=""validate();"">"
    Print #1, "        <input type=""button"" value=""Cancel"" onclick=""cancel();"">"
    Print #1, "      </td>"
    Print #1, "    </tr>"
    
    Print #1, "  </table>"
    Print #1, "</form>"
    
    Print #1, "<%End If%>"
    Print #1, ""
    
    Print #1, "</body>"
    Print #1, "</html>"

    Close #1

    With frmGenerate.Log
        .AddItem OutFile
        .Refresh
    End With

End Sub

Private Sub GenerateAsa()

    'Generate a global.asa file for the web application

    OutFile = WebDir & "global.asa"

    Open OutFile For Output As #1
    Print #1, ""
    Print #1, "<OBJECT RUNAT=""Server"" SCOPE=""Session"" ID=""Synergy"" PROGID=""xfnlCom.xfProxy""></OBJECT>"
    Print #1, ""
    Print #1, "<SCRIPT LANGUAGE=""VBScript"" RUNAT=""Server"">"
    Print #1, ""
    Print #1, "Sub Session_OnStart()"
    Print #1, ""
    Print #1, "    Dim Status"
    Print #1, ""
    Print #1, "    'Bring up xfServerPlus connection"
    Print #1, "    Status = Synergy.xfStartup(""" & Project.Server & """, " & Project.Port & ")"
    Print #1, ""
    Print #1, "    If (VarType(Status) = vbError) Then"
    Print #1, "        Session(""ERROR_PAGE"") = ""global.asa"""
    Print #1, "        Session(""ERROR_PAGE_MODE"") = """""
    Print #1, "        Session(""ERROR_ROUTINE"") = ""xfStartup"""
    Print #1, "        Session(""ERROR_TEXT"") = Synergy.getxfErrorMessage"
    Print #1, "        Response.Redirect(""error.asp"")"
    Print #1, "    End If"
    Print #1, ""
    Print #1, "    'Connected to xfServerPlus, now log in to the application"
    Print #1, ""
    Print #1, "    Status = Synergy.xfSubr(""login"")"
    Print #1, ""
    Print #1, "    If (VarType(Status) = vbError) Then"
    Print #1, "        Session(""ERROR_PAGE"") = ""global.asa"""
    Print #1, "        Session(""ERROR_PAGE_MODE"") = """""
    Print #1, "        Session(""ERROR_ROUTINE"") = ""login"""
    Print #1, "        Session(""ERROR_TEXT"") = Synergy.getxfErrorMessage"
    Print #1, "        Response.Redirect(""error.asp"")"
    Print #1, "    Else"
    Print #1, "        If (Status <> 0) Then"
    Print #1, "            Session(""ERROR_PAGE"") = ""global.asa"""
    Print #1, "            Session(""ERROR_PAGE_MODE"") = """""
    Print #1, "            Session(""ERROR_ROUTINE"") = ""login"""
    Print #1, "            Session(""ERROR_TEXT"") = ""Routine returned error "" & Status"
    Print #1, "            Response.Redirect(""error.asp"")"
    Print #1, "        End If"
    Print #1, "    End If"
    Print #1, ""
    Print #1, "    'Logged in to the application OK"
    Print #1, ""
    Print #1, "End Sub"
    Print #1, ""
    Print #1, "Sub Session_OnEnd()"
    Print #1, ""
    Print #1, "    'Destroy the xfServerPlus session"
    Print #1, "    Synergy.xfSubr ""logout"""
    Print #1, "    Synergy.xfShutdown"
    Print #1, ""
    Print #1, "End Sub"
    Print #1, ""
    Print #1, "</SCRIPT>"
    
    Close #1
    
    With frmGenerate.Log
        .AddItem OutFile
        .Refresh
    End With

End Sub

Private Sub GenerateRead()

    'Create the Synergy routine to read a record for this page

    OutFile = SynDir & Structure & "_read.dbl"

    Open OutFile For Output As #1
    
    Print #1, ".function " & Structure & "_read, ^VAL"
    Print #1, ""
    Print #1, "    ;Argument list"
    Print #1, ""
    Print #1, "      a_key      ,a"
    Print #1, ""
    Print #1, "      a_data     ,a"
    Print #1, ""
    Print #1, "      a_lock     ,n"
    Print #1, ""
    Print #1, "    ;End of argument list"
    Print #1, ""
    Print #1, ".include 'webapp.def'"
    Print #1, ""
    Print #1, ".proc"
    Print #1, ""
    Print #1, "    ;Default to success"
    Print #1, "    clear status"
    Print #1, ""
    Print #1, "    if (^passed(a_lock).and.a_lock) then"
    Print #1, "        read(ch_" & Structure & ",a_data,a_key,KEYNUM:Q_PRIMARY) [ERR=Err]"
    Print #1, "    Else"
    Print #1, "        read(ch_" & Structure & ",a_data,a_key,KEYNUM:Q_PRIMARY,LOCK:Q_NO_LOCK) [ERR=Err]"
    Print #1, ""
    Print #1, "    if (FALSE)"
    Print #1, "Err,  status=1"
    Print #1, ""
    Print #1, "    freturn status"
    Print #1, ""
    Print #1, ".end"
    
    Close #1

    With frmGenerate.Log
        .AddItem OutFile
        .Refresh
    End With

End Sub

Private Sub GenerateWrite()

    'Create the Synergy routine to write/store a record for this page

    OutFile = SynDir & Structure & "_write.dbl"

    Open OutFile For Output As #1
    
    Print #1, ".function " & Structure & "_write, ^VAL"
    Print #1, ""
    Print #1, "    ;Argument list"
    Print #1, ""
    Print #1, "      a_data     ,a"
    Print #1, ""
    Print #1, "      a_create   ,n"
    Print #1, ""
    Print #1, "    ;End of argument list"
    Print #1, ""
    Print #1, ".include 'webapp.def'"
    Print #1, ""
    Print #1, ".proc"
    Print #1, ""
    Print #1, "    ;Default to success"
    Print #1, "    clear status"
    Print #1, ""
    Print #1, "    if (^passed(a_create) .and. a_create) then"
    Print #1, "      store(ch_" & Structure & ",a_data) [ERR=Err]"
    Print #1, "    else"
    Print #1, "      write(ch_" & Structure & ",a_data) [ERR=Err]"
    Print #1, ""
    Print #1, "    if (FALSE)"
    Print #1, "Err,  status=TRUE"
    Print #1, ""
    Print #1, "    freturn status"
    Print #1, ""
    Print #1, ".end"
    
    Close #1

    With frmGenerate.Log
        .AddItem OutFile
        .Refresh
    End With

End Sub

Private Sub GenerateList()

    'Create the Synergy routine to return a list of records for this page
    
    OutFile = SynDir & Structure & "_list.dbl"

    Open OutFile For Output As #1
    
    Print #1, ".function " & Structure & "_list, ^VAL"
    Print #1, ""
    Print #1, "    ;Argument list"
    Print #1, ""
    Print #1, "    a_mode      ,n      ;Operation mode (Required, Passed)"
    Print #1, "                        ;   1 = Build new array and return count"
    Print #1, "                        ;   2 = Return existing array content"
    Print #1, ""
    Print #1, "    a_count     ,a      ;Returned record count"
    Print #1, ""
    Print #1, "    a_data      ,a      ;Optional returned data array (mode 2)"
    Print #1, ""
    Print #1, "    ;End of argument list"
    Print #1, ""
    Print #1, ".include 'webapp.def'"
    Print #1, ".include '" & Structure & "' repository, stack record = '" & Structure & "'"
    Print #1, ".include '" & Structure & "' repository, structure = '" & Structure & "_list'"
    Print #1, ""
    Print #1, ".align"
    Print #1, "static record dm_control"
    Print #1, "    mh          ,i4     ;Memory handle for array"
    Print #1, "    ms          ,i4     ;Current size of array"
    Print #1, "    mc          ,i4     ;Current content of array"
    Print #1, ""
    Print #1, "stack record"
    Print #1, "    c           ,i4     ;Local counter"
    Print #1, ""
    Print #1, ".define INCREMENT 10"
    Print #1, ""
    Print #1, ".proc"
    Print #1, ""
    Print #1, "    ;Default to success"
    Print #1, "    clear status"
    Print #1, ""
    Print #1, "    using (a_mode) select"
    Print #1, "    (1),"
    Print #1, "    begin"
    Print #1, ""
    Print #1, "        ;First time in and need to allocate memory?"
    Print #1, "        if (.not.mh)"
    Print #1, "        begin"
    Print #1, "            ms = INCREMENT"
    Print #1, "            mh=%mem_proc(DM_ALLOC+DM_STATIC,^size(" & Structure & "_list)*ms)"
    Print #1, "        end"
    Print #1, ""
    Print #1, "        ;Setup initial position in file"
    Print #1, "        clear mc"
    Print #1, "        find(ch_" & Structure & ",,^FIRST,KEYNUM:Q_PRIMARY) [ERR=Eof]"
    Print #1, ""
    Print #1, "        ;Read file and store details to dynamic memory"
    Print #1, "        repeat"
    Print #1, "        begin"
    Print #1, "            reads(ch_" & Structure & "," & Structure & ",Eof,LOCK:Q_NO_LOCK)"
    Print #1, "            incr mc"
    Print #1, ""
    Print #1, "            ;Make sure dynamic memory is big enough"
    Print #1, "            if (mc.gt.ms)"
    Print #1, "            begin"
    Print #1, "                ms = ms + INCREMENT"
    Print #1, "                mh = %mem_proc(DM_RESIZ,^size(" & Structure & "_list)*ms,mh)"
    Print #1, "            end"
    Print #1, ""
    Print #1, "            ^m(" & Structure & "_list[mc],mh) = " & Structure
    Print #1, "        end"
    Print #1, ""
    Print #1, "Eof,    a_count = mc"
    Print #1, ""
    Print #1, "    end"
    Print #1, "    (2),"
    Print #1, "    begin"
    Print #1, "        ;Assign array data to retun argument"
    Print #1, "        for c from 1 thru mc"
    Print #1, "            a_data(c) = ^m(" & Structure & "_list[c],mh)"
    Print #1, "    end"
    Print #1, "    endusing"
    Print #1, ""
    Print #1, "    freturn status"
    Print #1, ""
    Print #1, ".end"
    
    Close #1

    With frmGenerate.Log
        .AddItem OutFile
        .Refresh
    End With

End Sub

Private Sub GenerateLogin()

    'Generate the Synergy routine to log in to the application
    
    OutFile = SynDir & "login.dbl"
    
    Open OutFile For Output As #1
    
    Print #1, ".function login, ^VAL"
    Print #1, ""
    Print #1, "    ;Argument list"
    Print #1, ""
    Print #1, ""
    Print #1, ""
    Print #1, "    ;End of argument list"
    Print #1, ""
    Print #1, ".define WEBAPP_INIT"
    Print #1, ".include 'webapp.def'"
    Print #1, ""
    Print #1, ".proc"
    Print #1, ""
    Print #1, "    ;Default to success"
    Print #1, "    clear status"
    Print #1, ""
    Print #1, "    ;Open data files"
    Print #1, ""
    Print #1, ""
    Print #1, ""
    Print #1, ""
    Print #1, "    freturn status"
    Print #1, ""
    Print #1, ".end"
    
    Close #1

    With frmGenerate.Log
        .AddItem OutFile
        .Refresh
    End With

End Sub

Private Sub GenerateLogout()

    'Generate the Synergy routine to log out from the application
    
    OutFile = SynDir & "logout.dbl"
    
    Open OutFile For Output As #1
    
    Print #1, ".function logout, ^VAL"
    Print #1, ""
    Print #1, "    ;Argument list"
    Print #1, ""
    Print #1, ""
    Print #1, ""
    Print #1, "    ;End of argument list"
    Print #1, ""
    Print #1, ".include 'webapp.def'"
    Print #1, ""
    Print #1, ".proc"
    Print #1, ""
    Print #1, "    ;Default to success"
    Print #1, "    clear status"
    Print #1, ""
    Print #1, "    ;Close data files"
    Print #1, ""
    Print #1, ""
    Print #1, ""
    Print #1, ""
    Print #1, "    freturn status"
    Print #1, ""
    Print #1, ".end"
    
    Close #1
    
    With frmGenerate.Log
        .AddItem OutFile
        .Refresh
    End With

End Sub

Private Sub GenerateInclude()

    'Generate the Synergy include file for the application
    
    OutFile = SynDir & "webapp.def"
    
    Open OutFile For Output As #1
    
    Print #1, ".ifdef WEBAPP_INIT"
    Print #1, "  global data section WEBAPP, init"
    Print #1, "  .undefine WEBAPP_INIT"
    Print #1, ".else"
    Print #1, "  global data section WEBAPP"
    Print #1, ".endc"
    Print #1, ""
    Print #1, "    record"
    Print #1, "      ch_" & Structure & " ,i4 ;Channel for " & Structure & " structure"
    Print #1, ""
    Print #1, "  endglobal"
    Print #1, ""
    Print #1, ".align"
    Print #1, "stack record"
    Print #1, "    status       ,i4"
    Print #1, ""
    Print #1, ".ifndef TRUE"
    Print #1, "  .define TRUE  1"
    Print #1, "  .define FALSE 0"
    Print #1, ".endc"
    Print #1, ""
    
    Close #1

    With frmGenerate.Log
        .AddItem OutFile
        .Refresh
    End With

End Sub

Private Sub GenerateBuild()

    'Generate a build script for the application ELB

    OutFile = SynDir & "build.bat"
    
    Dim Olb As String, Elb As String
    
    Olb = SynDir & Project.Olb
    Elb = SynDir & Project.Elb
    
    Open OutFile For Output As #1
    
    Print #1, "rem Build Script"
    Print #1, "set RPSMFIL=" & Project.RpsMainFile
    Print #1, "set RPSTFIL=" & Project.RpsTextFile
    Print #1, "dblibr -c " & Olb
    Print #1, "dbl -XT " & Structure & "_read"
    Print #1, "dblibr -a " & Olb & " " & Structure & "_read"
    Print #1, "dbl -XT " & Structure & "_write"
    Print #1, "dblibr -a " & Olb & " " & Structure & "_write"
    Print #1, "dbl -XT " & Structure & "_list"
    Print #1, "dblibr -a " & Olb & " " & Structure & "_list"
    Print #1, "dbl -XT login"
    Print #1, "dblibr -a " & Olb & " login"
    Print #1, "dbl -XT logout"
    Print #1, "dblibr -a " & Olb & " logout"
    Print #1, "dblink -l " & Elb & " " & Olb
    
    Close #1

    With frmGenerate.Log
        .AddItem OutFile
        .Refresh
    End With

End Sub
