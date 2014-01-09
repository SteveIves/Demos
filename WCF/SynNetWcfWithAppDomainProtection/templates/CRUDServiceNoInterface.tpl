<CODEGEN_FILENAME><WCF_SERVICE>_<StructureName>.dbl</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>WCF_SERVICE</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>API_NAMESPACE</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>API_CLASS</REQUIRES_USERTOKEN>
<PROCESS_TEMPLATE>CRUDServiceBaseNoInterface</PROCESS_TEMPLATE>
;;******************************************************************************
;;* WARNING: Code generated at <TIME> on <DATE> by <AUTHOR>
;;******************************************************************************

import System
import System.Collections.Generic
import System.ServiceModel
import System.Threading.Tasks
import AppDomainProtection
import <API_NAMESPACE>

namespace <NAMESPACE>

    public partial class <WCF_SERVICE>

        {OperationContract}
        public method Create<StructureName>, MethodStatus
            required in a<StructureName>, @<StructureName>
        proc
            data completionSource = new TaskCompletionSource<MethodStatus>()
            lambda curryParams()
            begin
                data api, @<API_CLASS>, new <API_CLASS>()
                completionSource.SetResult(api.Create<StructureName>(a<StructureName>))
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            completionSource.Task.Wait()
            mreturn completionSource.Task.Result
        endmethod

        <PRIMARY_KEY>
        {OperationContract}
        public method Read<StructureName>, MethodStatus
            <SEGMENT_LOOP>
            required in  a<SegmentName>, <SEGMENT_CSTYPE>
            </SEGMENT_LOOP>
            required out a<StructureName>, @<StructureName>
            required out aGrfa, String
            endparams
        proc
            data completionSource = new TaskCompletionSource<Tuple<MethodStatus,<StructureName>,String>>()
            lambda curryParams()
            begin
                data api, @<API_CLASS>, new <API_CLASS>()
                data tmp<StructureName>, @<StructureName>
                data tmpGrfa, String
                completionSource.SetResult(Tuple.Create(api.Read<StructureName>(<SEGMENT_LOOP>a<SegmentName>,</SEGMENT_LOOP>tmp<StructureName>,tmpGrfa),tmp<StructureName>,tmpGrfa))
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            completionSource.Task.Wait()
            a<StructureName> = completionSource.Task.Result.Item2
            aGrfa = completionSource.Task.Result.Item3
            mreturn completionSource.Task.Result.Item1
        endmethod
        </PRIMARY_KEY>

        {OperationContract}
        public method ReadAll<StructureName>s, MethodStatus
            required out a<StructureName>s, @List<<StructureName>>
            endparams
        proc
            data completionSource = new TaskCompletionSource<Tuple<MethodStatus,List<<StructureName>>>>()
            lambda curryParams()
            begin
                data api, @<API_CLASS>, new <API_CLASS>()
                data tmp<StructureName>s, @List<<StructureName>>
                completionSource.SetResult(Tuple.Create(api.ReadAll<StructureName>s(tmp<StructureName>s),tmp<StructureName>s))
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            completionSource.Task.Wait()
            a<StructureName>s = completionSource.Task.Result.Item2
            mreturn completionSource.Task.Result.Item1
        endmethod

        {OperationContract}
        public method Update<StructureName>, MethodStatus
            required inout a<StructureName>, @<StructureName>
            required inout aGrfa, String
            endparams
        proc
            data completionSource = new TaskCompletionSource<Tuple<MethodStatus,<StructureName>,String>>()
            data tmp<StructureName>, @<StructureName>, a<StructureName>
            data tmpGrfa, String, aGrfa
            lambda curryParams()
            begin
                data api, @<API_CLASS>, new <API_CLASS>()
                completionSource.SetResult(Tuple.Create(api.Update<StructureName>(tmp<StructureName>,tmpGrfa),tmp<StructureName>,tmpGrfa))
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            completionSource.Task.Wait()
            a<StructureName> = completionSource.Task.Result.Item2
            aGrfa = completionSource.Task.Result.Item3
            mreturn completionSource.Task.Result.Item1
        endmethod

        {OperationContract}
        public method Delete<StructureName>, MethodStatus
            required in aGrfa, String
            endparams
        proc
            data completionSource = new TaskCompletionSource<MethodStatus>()
            lambda curryParams()
            begin
                data api, @<API_CLASS>, new <API_CLASS>()
                completionSource.SetResult(api.Delete<StructureName>(aGrfa))
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            completionSource.Task.Wait()
            mreturn completionSource.Task.Result
        endmethod

        <PRIMARY_KEY>
        {OperationContract}
        public method <StructureName>Exists, MethodStatus
            <SEGMENT_LOOP>
            required in a<SegmentName>, <SEGMENT_CSTYPE>
            </SEGMENT_LOOP>
            endparams
        proc
            data completionSource = new TaskCompletionSource<MethodStatus>()
            lambda curryParams()
            begin
                data api, @<API_CLASS>, new <API_CLASS>()
                completionSource.SetResult(api.<StructureName>Exists(<SEGMENT_LOOP>a<SegmentName><,></SEGMENT_LOOP>))
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            completionSource.Task.Wait()
            mreturn completionSource.Task.Result
        endmethod
        </PRIMARY_KEY>

    endclass

endnamespace
