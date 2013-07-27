<CODEGEN_FILENAME>DatabaseTableBase.dbl</CODEGEN_FILENAME>
;//****************************************************************************
;//
;// Title:       DatabaseTableBase.tpl
;//
;// Type:        CodeGen Template
;//
;// Description: This template creates a base class named DatabaseTableBase
;//              which is inherited by and provides functionality for other
;//              classes which are generated from the DatabaseTable and
;//              DatabaseTableMapped templates
;//
;// Date:        12th May 2012
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
;;*****************************************************************************
;;
;; Title:       DatabaseTableBase.dbl
;;
;; Type:        Class
;;
;; Description: This base class is inherited by and provides functionality for
;;              other "*Table" classes.
;;
;; Author:      <AUTHOR>
;;
;; Company:     <COMPANY>
;;
;; Created:     <DATE> at <TIME>
;;
;;*****************************************************************************
;;
;; WARNING:     This code was generated by <CODEGEN_VERSION>. Any changes that
;;              you make to this file will be lost if the code is regenerated.
;;
;;*****************************************************************************
;;
.include "CONNECTDIR:ssql.def"

namespace <NAMESPACE>

    public abstract class DatabaseTableBase

        protected mDb               ,@DatabaseConnection
        protected mErrorNumber      ,int            ;;Last database error number
        protected mErrorMessage     ,string         ;;Last database error message
        protected mCleanData        ,boolean        ;;Clean data before insert
        protected mEmptyAlphaNull   ,boolean        ;;Null terminate empty alpha fields

        public method DatabaseTableBase
            required in aDb, @DatabaseConnection
            endparams
        proc
            mDb = aDb
        endmethod

        protected method startTransaction, boolean
            endparams
        proc
            if (%ssc_commit(mDb.Channel,SSQL_TXON)==SSQL_NORMAL) then
                mreturn true
            else
                mreturn getDatabaseError("Failed to start transaction")
        endmethod

        protected method openNonSelectCursor, boolean
            required in  sqlStatement, string
            required out cursor, int
            endparams
        proc
            if (%ssc_open(mDb.Channel,cursor,sqlStatement,SSQL_NONSEL)==SSQL_NORMAL) then
                mreturn true
            else
                mreturn getDatabaseError("Failed to open cursor")
        endmethod

        protected method openSelectCursor, boolean
            required in  sqlStatement, string
            required out cursor, int
            endparams
        proc
            if (%ssc_open(mDb.Channel,cursor,sqlStatement,SSQL_SELECT)==SSQL_NORMAL) then
                mreturn true
            else
                mreturn getDatabaseError("Failed to open cursor")
        endmethod

        protected method defineStructure, boolean
            required in cursor, int
            required in elements, int
            required in layout, a
            required in buffer, a
            endparams
        proc
            if (%ssc_strdef(mDb.Channel,cursor,1,layout,buffer)==SSQL_NORMAL) then
                mreturn true
            else
                mreturn getDatabaseError("Failed to define input data structure!")
        endmethod

        protected method executeNonSelectCursor, boolean
            required in cursor, int
            endparams
        proc
            if (%ssc_execute(mDb.Channel,cursor,SSQL_STANDARD)==SSQL_NORMAL) then
                mreturn true
            else
                mreturn getDatabaseError("Failed to execute SQL statement")
        endmethod

        protected method closeCursor, void
            required inout cursor, int
            required inout currentStatus, boolean
            endparams
        proc
            if (cursor)
            begin
                if (%ssc_close(mDb.Channel,cursor)==SSQL_FAILURE)
                    if (currentStatus)
                        currentStatus = getDatabaseError("Failed to close cursor")
                clear cursor
            end
        endmethod

        protected method commitOrRollback, boolean
            required in commit, boolean
        proc
            if (commit) then
            begin
                if (%ssc_commit(mDb.Channel,SSQL_TXOFF)==SSQL_FAILURE)
                    mreturn getDatabaseError("Failed to commit transaction")
            end
            else
                xcall ssc_rollback(mDb.Channel,SSQL_TXOFF)
            mreturn true
        endmethod

        protected method getDatabaseError, boolean
            required in defaultMessage, string
            endparams
            record
                dbErrText, a1024
                length, int
            endrecord
        proc
            if (%ssc_getemsg(mDb.Channel,dbErrText,length,,mErrorNumber)==SSQL_NORMAL) then
                mErrorMessage = atrim(dbErrText)
            else
                mErrorMessage = defaultMessage
            mreturn false
        endmethod

        public property CleanData, boolean
            method get
            proc
                mreturn mCleanData
            endmethod
            method set
            proc
                mCleanData = value
            endmethod
        endproperty

        public property EmptyAlphaNull, boolean
            method get
            proc
                mreturn mEmptyAlphaNull
            endmethod
            method set
            proc
                mEmptyAlphaNull = value
            endmethod
        endproperty

        public property ErrorNumber, int
            method get
            proc
                mreturn mErrorNumber
            endmethod
        endproperty

        public property ErrorMessage, string
            method get
            proc
                mreturn mErrorMessage
            endmethod
        endproperty

        protected method IsNumeric, boolean
            a_number        ,a
            endparams

            .align
            stack record
                retval          ,boolean
                posn            ,i4
                number          ,d28.10
            endrecord

        proc
            retval = true
            posn = ^size(a_number)
            ;;Is the last character between "p" and "y"
            if((a_number(posn:1)>='p')&&(a_number(posn:1)<='y')) then
            begin
                ;;If it's the first character then it's a single-digit negative
                if(posn==1)
                    exit
                ;;Make sure the rest of the value looks OK
                try
                begin
                    number=a_number(1:posn-1)
                end
                catch (ex, @BadDigitException)
                begin
                    retval = false
                end
                endtry
            end
            else
            begin
                ;;No "p" through "y", check the whole value
                try
                begin
                    number = a_number
                end
                catch (ex, @BadDigitException)
                begin
                    retval = false
                end
                endtry
            end
            mreturn retval
        endmethod

        protected method IsDate, boolean
            required in argDate, d8
            endparams
        proc
            try
            begin
                data jp, int
                jp = %jperiod(argDate)
                mreturn true
            end
            catch (ex)
            begin
                mreturn false
            end
            endtry
        endmethod

    endclass

endnamespace
