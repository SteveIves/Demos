<CODEGEN_FILENAME><StructureName>Hooks.dbl</CODEGEN_FILENAME>
<PROCESS_TEMPLATE>replicate</PROCESS_TEMPLATE>
<PROCESS_TEMPLATE>LastRecordCache</PROCESS_TEMPLATE>
;//*****************************************************************************
;//
;// Title:      ReplicationIoHooks.tpl
;//
;// Description:Template to generate an IO Hooks class for use with SQL replication
;//
;// Author:     Steve Ives, Synergex Professional Services Group
;//
;// Copyright   © 2015 Synergex International Corporation.  All rights reserved.
;//
;// WARNING:    All content constituting or related to this code ("Code") is the
;//             property of Synergex International Corporation ("Synergex") and
;//             is protected by U.S. and international copyright laws.
;//             If you were given this Code by a Synergex employee then you may
;//             use and modify it freely for use within your applications.
;//
;//             However, you may use the Code only for your personal use.
;//             Any other use, unless otherwise authorized in writing by
;//             Synergex is strictly prohibited.  You may not under any
;//             circumstances distribute this Code, or any modified version
;//             or part of this Code, to any third party without first
;//             obtaining written permission to do so from Synergex.
;//             In using this Code you accept that it is provided as is,
;//             and without support or warranty of any kind.
;//
;//             Neither Synergex nor the author accept any responsibility
;//             for any losses or damages of any nature which may arise
;//             from the use of this Code.  This header information must
;//             remain unaltered in the Code at all times.  Possession
;//             of this Code, or any modified version or part of this Code,
;//             indicates your acceptance of these terms.
;//

import Synergex.SynergyDE.IOExtensions
import Synergex.SynergyDE.Select

namespace <NAMESPACE>

    .include "<STRUCTURE_NOALIAS>" repository, structure="str<StructureName>", end

    ;;-------------------------------------------------------------------------
    ;;I/O hooks class for <FILE_NAME>
    ;;
    public sealed class <StructureName>Hooks extends IOHooks

        private mActive, boolean
        private mChannel, int, 0
        private <structureName>, str<StructureName>

        ;;---------------------------------------------------------------------
        ;;Constructor

        public method <StructureName>Hooks
            required in          aChannel, n
            endparams
            parent(aChannel)
            record
                openMode, a3
            endrecord
        proc
            ;;Make sure the channel is to an indexed file and open in update mode
            xcall getfa(aChannel,"OMD",openMode)
            if (mActive = (openMode=="U:I"))
            begin
                ;;Record the channel number
                mChannel = aChannel
                ;;Initialize the last record cache for the channel
                LastRecordCache.Init(mChannel)
            end
        endmethod

        ;;---------------------------------------------------------------------
        ;;CLOSE hooks

        public override method close_pre_operation_hook, void
            required in          aFlags,  IOFlags
            endparams
        proc
            if (mActive)
                LastRecordCache.Clear(mChannel)
        endmethod

        ;;---------------------------------------------------------------------
        ;;DELETE hooks

;//     public override method delete_pre_operation_hook, void
;//         endparams
;//     proc
;//
;//     endmethod
;//
        public override method delete_post_operation_hook, void
            required inout       aError,  int
            endparams
        proc
            if (mActive && !aError)
            begin
                ;;A record was just deleted. Replicate the change.
                <structureName> = LastRecordCache.Retrieve(mChannel)
                xcall replicate(REPLICATION_INSTRUCTION.DELETE_ROW,"<STRUCTURE_NAME>",<structureName>.replication_key)
            end
        endmethod

;//     ;;---------------------------------------------------------------------
;//     ;;FIND hooks
;//
;//     public override method find_pre_operation_hook, void
;//         optional in mismatch aKey,    n
;//         optional in          aRfa,    a
;//         optional in          aKeynum, n
;//         required in          aFlags,  IOFlags
;//     proc
;//
;//     endmethod
;//
;//     public override method find_post_operation_hook, void
;//         optional in mismatch aKey,    n
;//         optional in          aRfa,    a
;//         optional in          aKeynum, n
;//         required in          aFlags,  IOFlags
;//         required inout       aError,  int
;//         endparams
;//     proc
;//
;//     endmethod
;//
        ;;---------------------------------------------------------------------
        ;;READ hooks

;//     public override method read_pre_operation_hook, void
;//         optional in mismatch aKey,    n
;//         optional in          aRfa,    a
;//         optional in          aKeynum, n
;//         required in          aFlags,  IOFlags
;//         endparams
;//     proc
;//
;//     endmethod
;//
        public override method read_post_operation_hook, void
            required inout       a<StructureName>, a
            optional in mismatch aKey,    n
            optional in          aRfa,    a
            optional in          aKeynum, n
            required in          aFlags,  IOFlags
            required inout       aError,  int
            endparams
        proc
            if (mActive && !aError)
            begin
                ;;Record the record that was just read (to support delete)
                LastRecordCache.Update(mChannel,a<StructureName>)
            end
        endmethod

        ;;---------------------------------------------------------------------
        ;;READS hooks

;//     public virtual method reads_pre_operation_hook, void
;//         required in          aFlags,  IOFlags
;//         endparams
;//     proc
;//
;//     endmethod
;//
        public override method reads_post_operation_hook ,void
            required inout       a<StructureName>, a
            optional in          aRfa,    a
            required in          aFlags,  IOFlags
            required inout       aError,  int
            endparams
        proc
            if (mActive && !aError)
            begin
                ;;Record the record that was just read (to support delete)
                LastRecordCache.Update(mChannel,a<StructureName>)
            end
        endmethod

        ;;---------------------------------------------------------------------
        ;;STORE hooks

        public override method store_pre_operation_hook, void
            required inout a<StructureName>, a
            required in          aFlags,  IOFlags
            endparams
        proc
            if (mActive)
            begin
                ;;Populate replication key with a %DATETIME value
                <structureName> = a<StructureName>
                <structureName>.replication_key = %datetime
                a<StructureName> = <structureName>
            end
        endmethod

        public override method store_post_operation_hook, void
            required inout       a<StructureName>, a
            optional in          aRfa,    a
            required in          aFlags,  IOFlags
            required inout       aError,  int
            endparams
        proc
            if (mActive && !aError)
            begin
                ;;A new record was just created. Replicate the change.
                <structureName> = a<StructureName>
                xcall replicate(REPLICATION_INSTRUCTION.CREATE_ROW,"<STRUCTURE_NAME>",<structureName>.replication_key)
            end
        endmethod

;//     ;;---------------------------------------------------------------------
;//     ;;UNLOCK hooks
;//
;//     public virtual method unlock_pre_operation_hook, void
;//         optional in          aRfa,    a
;//         required in          aFlags,  IOFlags
;//         endparams
;//     proc
;//
;//     endmethod
;//
;//     public override method unlock_post_operation_hook, void
;//         required in          aFlags,  IOFlags
;//         required inout       aError,  int
;//         endparams
;//     proc
;//
;//     endmethod
;//
        ;;---------------------------------------------------------------------
        ;;WRITE hooks

;//     public override method write_pre_operation_hook, void
;//         required inout       aBuffer, a
;//         optional in          aRecnum, n
;//         optional in          aRfa,    a
;//         required in          aFlags,  IOFlags
;//         endparams
;//     proc
;//
;//     endmethod
;//
        public override method write_post_operation_hook, void
            required inout       a<StructureName>, a
            optional in          aRecnum, n
            optional in          aRfa,    a
            required in          aFlags,  IOFlags
            required inout       aError,  int
            endparams
        proc
            if (mActive && !aError)
            begin
                ;;A record was just updated. If it changed then replicate the change.
                if (LastRecordCache.HasChanged(mChannel,a<StructureName>))
                begin
                    <structureName> = a<StructureName>
                    xcall replicate(REPLICATION_INSTRUCTION.UPDATE_ROW,"<STRUCTURE_NAME>",<structureName>.replication_key)
                end
            end
        endmethod

;//     ;;---------------------------------------------------------------------
;//     ;;WRITES hooks
;//
;//     public override method writes_pre_operation_hook, void
;//         required inout       aBuffer, a
;//         required in          aFlags,  IOFlags
;//         endparams
;//     proc
;//
;//     endmethod
;//
;//     public override method writes_post_operation_hook, void
;//         required inout       aBuffer, a
;//         optional in          aRfa,    a
;//         required in          aFlags,  IOFlags
;//         required inout       aError,  int
;//         endparams
;//     proc
;//
;//     endmethod
;//
    endclass

endnamespace
