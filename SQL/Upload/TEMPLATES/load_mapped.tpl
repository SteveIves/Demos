<CODEGEN_FILENAME><structure_name>_load.dbl</CODEGEN_FILENAME>
<PROCESS_TEMPLATE>map.tpl</PROCESS_TEMPLATE>
<PROCESS_TEMPLATE>insert_rows.tpl</PROCESS_TEMPLATE>
;//*****************************************************************************
;//
;// Title:        sql_load_mapped.tpl
;//
;// Description:  Template to generate a Synergy function which loads data from
;//               a data file to a database table for a mapped structure.
;//
;// Author:       Steve Ives, Synergex Professional Services Group
;//
;// Copyright:    �Synergex International Inc.  All rights reserved.
;//
;// WARNING:      If you were given this code by a Synergex employee then you
;//               may use and modify it freely to generate code for your
;//               applications. However, you may not under any circumstances
;//               distribute this code, or any modified version of this code,
;//               to any third party without first obtaining written permission
;//               to do so from Synergex. In using this code you accept that it
;//               is provided as is, and without support or warranty. Neither
;//               Synergex or the author accept any responsibility for any
;//               losses or damages of any nature which may arise from the use
;//               of this code. This header information must remain unaltered
;//               in the code at all times. Possession of this code, or any
;//               modified version of this code, indicates your acceptance of
;//               these terms.
;//
;// $Revision: 1 $
;//
;// $Date: 2012-02-15 23:52:19-06:00 $
;//
;;*****************************************************************************
;;
;; Routine:     <structure_name>_load
;;
;; Author:      <AUTHOR> (<ENV:USERNAME>)
;;
;; Company:     <COMPANY>
;;
;; Created:     <DATE> at <TIME>
;;
;;*****************************************************************************
;;
;; WARNING:     This code was generated by <CODEGEN_VERSION>.  Any changes that
;;              you make to this file will be lost if the code is regenerated.
;;
;; This code is supplied as seen and without warranty or support, and is used
;; at your own risk. Neither the author or Synergex accept any responsability
;; for any loss or damage which may result from the use of this code. This text
;; must remain unaltered in this file at all times. Possession or use of this
;; code, or any modified version of this code, indicates your acceptance of
;; these conditions.
;;
;;*****************************************************************************
;;
;; Possible return values from this routine are:
;;
;;  true    Table loaded
;;  false   Error (see a_errtxt)
;;
function <structure_name>_load ,^val

    required in  a_dbchn    ,int        ;;Connected database channel
    optional out a_errtxt   ,a          ;;Error text
    optional in  a_logex    ,boolean    ;;Log exception records
    optional in  a_terminal ,int        ;;Terminal channel to log errors on
    endparams

    .include "CONNECTDIR:ssql.def"
    .include "<MAPPED_STRUCTURE>" repository, stack record="<mapped_structure>"
    .include "<STRUCTURE_NOALIAS>" repository, structure="<structure_name>"

    .define BUFFER_ROWS 1000
    .define EXCEPTION_BUFSZ 100

    stack record local_data
        ok      ,boolean    ;;Return status
        filechn ,int        ;;Data file channel
        mh      ,int        ;;Memory handle containing data to insert
        ms      ,int        ;;Size of memory buffer in rows
        mc      ,int        ;;Memory buffer rows currently used
        ex_mh   ,int        ;;Memory buffer for exception records
        ex_mc   ,int        ;;Number of records in returned exception array
        ex_ch   ,int        ;;Exception log file channel
        cnt     ,int        ;;Loop counter
        errtxt  ,a256       ;;Error message text
    endrecord

proc

    init local_data
    ok = true

    ;;Open the data file associated with the mapped structure
    begin
        open(filechn=%syn_freechn,i:i,"<MAPPED_FILE>") [ERR=fnf]
        exit
fnf,    ok = false
        errtxt = "Failed to open file <MAPPED_FILE>"
        clear filechn
    end

    if (ok)
    begin

        ;;Allocate memory buffer for the database rows
        mh = %mem_proc(DM_ALLOC,^size(<structure_name>)*(ms=BUFFER_ROWS))

        ;;Read records from the input file
        repeat
        begin

            ;;Get the next record from the input file
            reads(filechn,<mapped_structure>,eof)

            ;;Map the data into the next database record
            xcall <structure_name>_map(<mapped_structure>,(a)^m(<structure_name>[mc+=1],mh))

            ;;If the buffer is full, write it to the database
            if (mc==ms)
                call insert_data

            if (!ok)
                exitloop

        end

eof,    ;;Any data waiting to be written?
        if (mc)
        begin
            mh = %mem_proc(DM_RESIZ,^size(<structure_name>)*mc,mh)
            call insert_data
        end

        ;;Deallocate memory buffer
        mh = %mem_proc(DM_FREE,mh)

    end

    ;;Close the file
    if (filechn)
        close filechn

    ;;Close the exceptions log file
    if (ex_ch)
        close ex_ch

    ;;Return the error text
    if (^passed(a_errtxt))
        a_errtxt = errtxt

    freturn ok

insert_data,

    if (%<structure_name>_insert_rows(a_dbchn,mh,errtxt,ex_mh,a_terminal))
    begin
        ;;Any exceptions?
        if (ex_mh)
        begin
            ;;Are we logging exceptions?
            if (^passed(a_logex)&&a_logex) then
            begin
                ;;Open the log file
                if (!ex_ch)
                    open(ex_ch=%syn_freechn,o:s,"exceptions_<structure_name>.log")
                ;;How many exceptions to log?
                ex_mc = (%mem_proc(DM_GETSIZE,ex_mh)/^size(<structure_name>))
                ;Log the exceptions
                for cnt from 1 thru ex_mc
                    writes(ex_ch,^m(<structure_name>[cnt],ex_mh))
                if (^passed(a_terminal)&&a_terminal)
                    writes(a_terminal,"Exceptions were logged to exceptions_<structure_name>.log")
            end
            else
            begin
                ;;No, report and error
                ok = false
            end
            ;;Release the exception buffer
            ex_mh=%mem_proc(DM_FREE,ex_mh)
        end
    end

    clear mc

    return

endfunction
