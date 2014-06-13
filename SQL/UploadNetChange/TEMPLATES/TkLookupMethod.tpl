<CODEGEN_FILENAME><StructureName>Lookup.dbl</CODEGEN_FILENAME>
;//****************************************************************************
;//
;// Title:       TkLookupMethod.dbl
;//
;// Type:        CodeGen Template
;//
;// Description: This template generates a Synergy UI Toolkit lookup routine.
;//              The routine builds and presents a simple list of all of the
;//              records in the associated file. If a record is selected then
;//              that record is returned, otherwise an empty record is returned
;//
;// Date:        19th March 2007
;//
;// Author:      Steve Ives, Synergex Professional Services Group
;//              http://www.synergex.com
;//
;//****************************************************************************
;//
;// Copyright (c) 2012, Synergex International, Inc.
;// All rights reserved.
;//
;// Redistribution and use in source and binary forms, with or without
;// modification, are permitted provided that the following conditions are met:
;//
;// * Redistributions of source code must retain the above copyright notice,
;//   this list of conditions and the following disclaimer.
;//
;// * Redistributions in binary form must reproduce the above copyright notice,
;//   this list of conditions and the following disclaimer in the documentation
;//   and/or other materials provided with the distribution.
;//
;// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
;// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
;// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
;// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
;// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
;// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
;// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
;// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
;// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
;// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
;// POSSIBILITY OF SUCH DAMAGE.
;//
;******************************************************************************
;
; Routine:      <StructureName>Lookup
;
; Author:       <AUTHOR>
;
; Company:      <COMPANY>
;
;******************************************************************************
;
; WARNING:      This code was generated by CodeGen.  Any changes that you make
;               to this file will be lost if the code is regenerated.
;
;******************************************************************************
;
subroutine <StructureName>Lookup, reentrant

    ;Required arguments
    a_<structure_name>  ,a      ;Master file record (returned)

    ;Optional arguments
    a_icon              ,a      ;Icon file name
    a_title             ,a      ;Title for list and list report

    endparams

    .include "WND:tools.def"
    .include "DBLDIR:activex.def"
    .include "LIBSRC:system.def"
	.include "LIBSRC:StructureIO.def"

    external function
        <StructureName>IO, ^val
    endexternal

    .include "<STRUCTURE_NOALIAS>" repository, record="listdata", nofields

    stack record ivars
        ok                  ,i4     ;OK to continue
        error               ,i4     ;An error occurred
        window_id           ,i4     ;List input window
        lstclass            ,i4     ;List class
        list_id             ,i4     ;List
        control             ,i4     ;List activex control id
        req                 ,i4     ;List processor request
        nullitem            ,i4     ;Is the current list item null?
        headercnt           ,i4     ;List header count
        idf_<structure_name>_i   ,i4     ;Local channel for master file

    stack record avars
        headings            ,a80    ;List headings
        title               ,a80    ;List title

proc

    xcall e_enter

    clear ^i(ivars), avars
    ok=TRUE

    ;Open the master file
    if (%<StructureName>IO(IO_OPEN_INP,idf_<structure_name>_i)!=IO_OK)
    begin
        xcall u_msgbox("Failed to open file <FILE_NAME>",D_MOK+D_MICONEXCLAM,"Error")
        ok=FALSE
    end

    ;Load list input window
    if (ok)
    begin
        xcall i_ldinp(window_id,,"<STRUCTURE_NAME>_LUP",D_NOPLC,,error)
        if (error) then
        begin
            xcall u_msgbox("Failed to load window <STRUCTURE_NAME>_LUP",D_MOK+D_MICONEXCLAM,"Error")
            ok=FALSE
        end
        else
        begin
            ;Extract list headings from list window
            xcall headings_from_window(window_id,headings)
            if (headings)
                headercnt=1
        end
    end

    ;Create list class
    if (ok)
    begin
        xcall l_class(lstclass,"<STRUCTURE_NAME>_CLS",,,15,headercnt,,,,,,"<StructureName>LookupLoad","ACTIVEX",error)
        if (error)
        begin
            xcall u_msgbox("Failed to create list class <STRUCTURE_NAME>_CLS",D_MOK+D_MICONEXCLAM,"Error")
            ok=FALSE
        end
    end

    ;Create list
    if (ok)
    begin
        xcall l_create(list_id,window_id,listdata,,"<STRUCTURE_NAME>_CLS",,,D_NOPLC,,,,error)
        if (error)
        begin
            xcall u_msgbox("Failed to create list",D_MOK+D_MICONEXCLAM,"Error")
            ok=FALSE
        end
    end

    ;Configure list
    if (ok)
    begin

        if (^passed(a_title)&&a_title)
        begin
            title = a_title
            xcall l_sect(list_id,title,D_TITLE)
        end

        if (headings)
            xcall l_sect(list_id,headings,D_HEADER)

        xcall l_button(list_id,DSB_ADD,"OK",DSB_TEXT,"OK")
        xcall l_button(list_id,DSB_ADD,"CANCEL",DSB_TEXT,"Cancel")

        xcall l_buttonset(list_id,DSB_RIGHT,,,"OK")

        if (wndevent_close)
        begin
            xcall l_method(list_id,D_LWNDEVENT,wndevent_close)
            if (^passed(a_icon) && a_icon)
                xcall l_icon(list_id,a_icon,1)
        end

        xcall l_status(list_id,D_LAXCTRL,control)
        xcall ax_set(control,"RowMode",1)
        xcall ax_set(control,"LightItemColor",RGB_VALUE(255,255,180))
        xcall ax_set(control,"SelBackColor",RGB_VALUE(0,0,180))
    end

    ;Process list
    if (ok)
    begin

        xcall position_window(list_id,1)

        ;xcall ui_okcancel(D_ON)

        repeat
        begin

            xcall l_select(list_id,req,listdata,,,,,,,,,,,,,idf_<structure_name>_i)

            if (g_select) then
            begin
                using g_entnam select
                ("OK"),
                begin
                    call select_record
                    exitloop
                end
                ("CANCEL"),
                    exitloop
                endusing
            end
            else
            begin
                call select_record
                exitloop
            end
        end

    end

    xcall e_exit

    clear g_select

    xreturn

select_record,

    xcall l_status(list_id,D_LNULL,nullitem)
    if (nullitem) then
    begin
        xcall u_msgbox("No record selected.",D_MOK+D_MICONINFO)
        clear a_<structure_name>
    end
    else
        a_<structure_name> = listdata

    return

endsubroutine

;***************************************************************************************************
;
subroutine <StructureName>LookupLoad

    ;Arguments
    a_listid            ,n          ; List id
    a_req               ,n          ; Request flag
    a_data              ,a          ; Item data
    a_inpid             ,n          ; Input window id
    a_disable           ,n          ; (Optional) Disable flag
    a_index             ,n          ; Loading index
    ;Method data
    idf_<structure_name>_i   ,n          ;Master file channel

    endparams

    .include "WND:tools.def"
    .include "LIBSRC:StructureIO.def"

    external function
        <StructureName>IO, ^val
    endexternal

proc

    if (a_index==1)
    begin
        if (%<StructureName>IO(IO_FIND_FIRST,idf_<structure_name>_i,,0)!=IO_OK)
            a_req = D_LEOF
    end

    if (a_req!=D_LEOF)
    begin
        if (%<StructureName>IO(IO_READ_NEXT,idf_<structure_name>_i,,,a_data)==IO_OK) then
            xcall i_display(a_inpid,,a_data)
        else
            a_req = D_LEOF
    end

    xreturn

endsubroutine

