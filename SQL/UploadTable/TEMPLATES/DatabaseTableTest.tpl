<CODEGEN_FILENAME>DatabaseTableTest.dbl</CODEGEN_FILENAME>
;//****************************************************************************
;//
;// Title:       DatabaseTableTest.tpl
;//
;// Type:        CodeGen Template
;//
;// Description: Template to a program that can be used to test code generated
;//              by the various other DatabaseTable*.tpl templates.
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
;; Title:       DatabaseTableTest.dbl
;;
;; Type:        Program
;;
;; Description: A Synergy program which connects to a SQL Server relational
;;              database. The program is intended to be used as a test platform
;;              for routines generated from the DatabaseTable* templates.
;;
;; Author:      <AUTHOR>
;;
;; Company:     <COMPANY>
;;
;;*****************************************************************************
;;
;; WARNING:     This code was generated by <CODEGEN_VERSION>. Any changes that
;;              you make to this file will be lost if the code is regenerated.
;;
;;*****************************************************************************
;;
import <NAMESPACE>

main DatabaseTableTest

    .define DB_CONSTR   "VTX12_SQLNATIVE://DatabaseName/.\\SQLEXPRESS///Trusted_connection=yes"

    record
        tt              ,i4                     ;;Terminal channel
        ok              ,boolean, true          ;;OK to continue?
        connected       ,boolean, false         ;;Connected to database?
        db              ,@DatabaseConnection    ;;Connection to database
        rowcount        ,i4                     ;;Rows to load / loaded
        failrows        ,i4                     ;;Rows that failed to load

        ;???Table       ,@???Table

    endrecord
proc

    ;---------------------------------------------------------------------------
    ;Open the terminal

    open(tt=0,i,"tt:")
    xcall flags(7004020,1)

    try
    begin
        db = new DatabaseConnection(1,DB_CONSTR,,1024)
        connected = false
    end
    catch (ex)
    begin
        ok = false
    end
    endtry

;   if (ok)
;   begin
;       ???Table = new ???Table(db)
;   end

;   if (ok)
;   begin
;       writes(tt,"Checking for table ??? ... ")
;       if (???Table.Exists())
;       begin
;           writes(tt,"Deleting table ??? ... ")
;           if (!???Table.Drop())
;           begin
;               writes(tt,???Table.ErrorMessage)
;               clear ok
;           end
;       end
;       if (ok)
;       begin
;           writes(tt,"Creating table ??? ... ")
;           if (!???Table.Create())
;           begin
;               writes(tt,???Table.ErrorMessage)
;               clear ok
;           end
;       end
;   end

;   if (ok)
;   begin
;       writes(tt,"Loading table ??? ... ")
;       ;;Don't pass rowcount (or set it to 0) to load the full file!
;       rowcount = 100
;       ;???Table.CleanData = true
;       ;???Table.EmptyAlphaNull = true
;       if (???Table.Load(true,tt,rowcount,failrows)) then
;           writes(tt,string(rowcount) + " rows loaded, "+string(failrows)+" failed")
;       else
;       begin
;           writes(tt,???Table.ErrorMessage)
;           clear ok
;       end
;   end

    ;---------------------------------------------------------------------------
    ; Disconnect from the database

    if (connected)
        db.Disconnect()

    ;---------------------------------------------------------------------------
    ;All done

    sleep 2
    close tt
    stop

endmain

