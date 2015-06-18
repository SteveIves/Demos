<CODEGEN_FILENAME><WCF_SERVICE>_<StructureName>.dbl</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>WCF_SERVICE</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>API_NAMESPACE</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>API_CLASS</REQUIRES_USERTOKEN>
<PROCESS_TEMPLATE>CRUDInterface</PROCESS_TEMPLATE>
<PROCESS_TEMPLATE>CRUDServiceBase</PROCESS_TEMPLATE>
;;******************************************************************************
;; WARNING: THIS FILE WAS CODE GENERATED. CHANGES MAY BE LOST IF REGENERATED
;;******************************************************************************

import System
import System.Collections.Generic
import System.Runtime.Serialization
import System.ServiceModel
import System.Threading.Tasks
import AppDomainProtection
import <API_NAMESPACE>

namespace <NAMESPACE>

    public partial class <WCF_SERVICE>

        public method Create<StructureName>, @Task<<WCF_SERVICE>Response>
            required in a<StructureName>, @<StructureName>
        proc
            data completionSource = new TaskCompletionSource<<WCF_SERVICE>Response>()
            lambda curryParams()
            begin
                data tmpErrorMessage, string
                data api = new <API_CLASS>()
                completionSource.SetResult(new <WCF_SERVICE>Response() { Status = api.Create<StructureName>(a<StructureName>,tmpErrorMessage), ErrorMessage = tmpErrorMessage } )
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            mreturn completionSource.Task
        endmethod

        <PRIMARY_KEY>
        public method Read<StructureName>, @Task<<StructureName>ReadResponse>
            <SEGMENT_LOOP>
            required in  a<SegmentName>, <SEGMENT_CSTYPE>
            </SEGMENT_LOOP>
        proc
            data completionSource = new TaskCompletionSource<<StructureName>ReadResponse>()
            lambda curryParams()
            begin
                data tmp<StructureName>, @<StructureName>
                data tmpGrfa, [#]byte
                data tmpErrorMessage, string
                data api = new <API_CLASS>()
                ;------
                ;TODO: Compiler Bug: Type mismatch between System.Byte and System.Byte!
                ;completionSource.SetResult(new <StructureName>ReadResponse() { Status = api.Read<StructureName>(<SEGMENT_LOOP>a<SegmentName>,</SEGMENT_LOOP>tmp<StructureName>,tmpGrfa,tmpErrorMessage), ErrorMessage = tmpErrorMessage, Result = tmp<StructureName>, Grfa = tmpGrfa } )
                ;------
                ;WORKAROUND:
                data r = new <StructureName>ReadResponse()
                r.Status = api.Read<StructureName>(<SEGMENT_LOOP>a<SegmentName>,</SEGMENT_LOOP>tmp<StructureName>,tmpGrfa,tmpErrorMessage)
                r.ErrorMessage = tmpErrorMessage
                r.Result = tmp<StructureName>
                r.Grfa = tmpGrfa
                completionSource.SetResult(r)
                ;------
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            mreturn completionSource.Task
        endmethod
        </PRIMARY_KEY>

        public method ReadAll<StructureName>s, @Task<<StructureName>ReadAllResponse>
        proc
            data completionSource = new TaskCompletionSource<<StructureName>ReadAllResponse>()
            lambda curryParams()
            begin
                data tmp<StructureName>s, @List<<StructureName>>
                data tmpErrorMessage, string
                data api = new <API_CLASS>()
                completionSource.SetResult(new <StructureName>ReadAllResponse() { Status = api.ReadAll<StructureName>s(tmp<StructureName>s,tmpErrorMessage), ErrorMessage = tmpErrorMessage, Result = tmp<StructureName>s} )
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            mreturn completionSource.Task
        endmethod

        public method Update<StructureName>, @Task<<StructureName>UpdateResponse>
            required in a<StructureName>, @<StructureName>
            required in aGrfa, [#]byte
        proc
            data completionSource = new TaskCompletionSource<<StructureName>UpdateResponse>()
            lambda curryParams()
            begin
                data tmp<StructureName>, @<StructureName>, a<StructureName>
                data tmpGrfa, [#]byte, aGrfa
                data tmpErrorMessage, string
                data api = new <API_CLASS>()
                ;------
                ;TODO: Compiler Bug: Type mismatch between System.Byte and System.Byte!
                ;completionSource.SetResult(new <StructureName>UpdateResponse() { Status = api.Update<StructureName>(tmp<StructureName>,tmpGrfa,tmpErrorMessage), ErrorMessage = tmpErrorMessage, Result = tmp<StructureName>, Grfa = tmpGrfa} )
                ;------
                ;WORKAROUND:
                data r = new <StructureName>UpdateResponse()
                r.Status = api.Update<StructureName>(tmp<StructureName>,tmpGrfa,tmpErrorMessage)
                r.ErrorMessage = tmpErrorMessage
                r.Result = tmp<StructureName>
                r.Grfa = tmpGrfa
                completionSource.SetResult(r)
                ;------
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            mreturn completionSource.Task
        endmethod

        public method Delete<StructureName>, @Task<<WCF_SERVICE>Response>
            required in aGrfa, [#]byte
        proc
            data completionSource = new TaskCompletionSource<<WCF_SERVICE>Response>()
            lambda curryParams()
            begin
                data tmpErrorMessage, string
                data api = new <API_CLASS>()
                completionSource.SetResult(new <WCF_SERVICE>Response() { Status = api.Delete<StructureName>(aGrfa,tmpErrorMessage), ErrorMessage = tmpErrorMessage } )
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            mreturn completionSource.Task
        endmethod

        <PRIMARY_KEY>
        public method <StructureName>Exists, @Task<<WCF_SERVICE>Response>
            <SEGMENT_LOOP>
            required in a<SegmentName>, <SEGMENT_CSTYPE>
            </SEGMENT_LOOP>
        proc
            data completionSource = new TaskCompletionSource<<WCF_SERVICE>Response>()
            lambda curryParams()
            begin
                data tmpErrorMessage, string
                data api = new <API_CLASS>()
                completionSource.SetResult(new <WCF_SERVICE>Response() { Status = api.<StructureName>Exists(<SEGMENT_LOOP>a<SegmentName><,></SEGMENT_LOOP>,tmpErrorMessage), ErrorMessage = tmpErrorMessage } )
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            mreturn completionSource.Task
        endmethod
        </PRIMARY_KEY>

    endclass

endnamespace
