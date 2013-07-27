<CODEGEN_FILENAME><structure_name>_drop.dbl</CODEGEN_FILENAME>
;//*****************************************************************************
;//
;// Title:        sql_drop.tpl
;//
;// Description:  Template to generate a Synergy function which deletes a table
;//               from a SQL Server database.
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
;;*****************************************************************************
;;
;; Routine:      <structure_name>_drop
;;
;; Author:       <AUTHOR> (<ENV:USERNAME>)
;;
;; Company:      <COMPANY>
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
;;   true   Table dropped
;;   false  Error (see a_errtxt)
;;
function <structure_name>_drop ,^val

    required in  a_dbchn    ,int    ;;Connected database channel
    optional out a_errtxt   ,a      ;;Error text
    endparams

    .include "CONNECTDIR:ssql.def"

    stack record local_data
        ok          ,boolean    ;;Return status
        dberror     ,int        ;;Database error number
        cursor      ,int        ;;Database cursor
        length      ,int        ;;Length of a string
        transaction ,int        ;;Transaction in progress
        errtxt      ,a256       ;;Returned error message text
    endrecord

proc

    init local_data
    ok = true

    ;;-------------------------------------------------------------------------
    ;;Start a database transaction
    ;;
    if (%ssc_commit(a_dbchn,SSQL_TXON)==SSQL_NORMAL) then
        transaction=1
    else
    begin
        ok = false
        if (%ssc_getemsg(a_dbchn,errtxt,length,,dberror)==SSQL_FAILURE)
            errtxt="Failed to start transaction"
    end

    ;;-------------------------------------------------------------------------
    ;;Open cursor for DROP TABLE statement
    ;;
    if (ok)
    begin
        if (%ssc_open(a_dbchn,cursor,"DROP TABLE <STRUCTURE_NAME>",SSQL_NONSEL)==SSQL_FAILURE)
        begin
            ok = false
            if (%ssc_getemsg(a_dbchn,errtxt,length,,dberror)==SSQL_FAILURE)
                errtxt="Failed to open cursor"
        end
    end

    ;;-------------------------------------------------------------------------
    ;;Execute DROP TABLE statement
    ;;
    if (ok)
    begin
        if (%ssc_execute(a_dbchn,cursor,SSQL_STANDARD)==SSQL_FAILURE)
        begin
            if (%ssc_getemsg(a_dbchn,errtxt,length,,dberror)==SSQL_NORMAL) then
            begin
                ;;Check if the error was that the table did not exist
                if (dberror==-3701) then 
                    clear errtxt
                else
                    ok = false
            end
            else
            begin
                errtxt="Failed to execute SQL statement"
                ok = false
            end
        end
    end

    ;;-------------------------------------------------------------------------
    ;;Close the database cursor
    ;;
    if (cursor)
    begin
        if (%ssc_close(a_dbchn,cursor)==SSQL_FAILURE)
        begin
            if (ok)
            begin
                ok = false
                if (%ssc_getemsg(a_dbchn,errtxt,length,,dberror)==SSQL_FAILURE)
                    errtxt="Failed to close cursor"
            end
        end
    end

    ;;-------------------------------------------------------------------------
    ;;Commit or rollback the transaction
    ;;
    if (transaction)
    begin
        if (ok) then
        begin
            ;;Success, commit the transaction
            if (%ssc_commit(a_dbchn,SSQL_TXOFF)==SSQL_FAILURE)
            begin
                ok = false
                if (%ssc_getemsg(a_dbchn,errtxt,length,,dberror)==SSQL_FAILURE)
                    errtxt="Failed to commit transaction"
            end
        end
        else
        begin
            ;;There was an error, rollback the transaction
            xcall ssc_rollback(a_dbchn,SSQL_TXOFF)
        end
    end

    ;;-------------------------------------------------------------------------
    ;;If there was an error message, return it to the calling routine

    if (^passed(a_errtxt))
    begin
        if (ok) then
            clear a_errtxt
        else
            a_errtxt=errtxt
    end

    freturn ok

endfunction

