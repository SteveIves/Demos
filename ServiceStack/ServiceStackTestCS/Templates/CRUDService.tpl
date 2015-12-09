<CODEGEN_FILENAME><WCF_SERVICE>_<StructureName>.cs</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>WCF_SERVICE</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>API_NAMESPACE</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>API_CLASS</REQUIRES_USERTOKEN>
<PROCESS_TEMPLATE>CRUDServiceBase</PROCESS_TEMPLATE>
//******************************************************************************
// WARNING: THIS FILE WAS CODE GENERATED. CHANGES MAY BE LOST IF REGENERATED
//******************************************************************************

using System;
using ServiceStack;
using System.Collections.Generic;
using System.Threading.Tasks;
using <API_NAMESPACE>;

namespace <NAMESPACE>
{
    public partial class <WCF_SERVICE>
    {
        public object Any(Create<StructureName>Request request)
        {
            return new Create<StructureName>Response();
        }
        
        [Route("/parts")]
        //TODO: Needs to be a PUT method
        public class Create<StructureName>Request
        {
          public <StructureName> <StructureName> { get; set; }
        }

        public class Create<StructureName>Response
        {
            public MethodStatus Status { get; set; }
        }
;//{OperationContract}
;//public method Create<StructureName>, MethodStatus
;//    required in a<StructureName>, @<StructureName>
;//proc
;//    data completionSource = new TaskCompletionSource<MethodStatus>()
;//    lambda curryParams()
;//    begin
;//        data api, @<API_CLASS>, new <API_CLASS>()
;//        completionSource.SetResult(api.Create<StructureName>(a<StructureName>))
;//    end
;//    this.ServiceDispatcher.Dispatch(curryParams)
;//    completionSource.Task.Wait()
;//    mreturn completionSource.Task.Result
;//endmethod

        <PRIMARY_KEY>
        public object Any(Read<StructureName>Request request)
        {
            var completionSource = new TaskCompletionSource<Tuple<MethodStatus,Part,String>>();
            this.ServiceDispatcher.Dispatch( new AppDomainProtection.AppDomainDispatcherHelper(() => {
                var api = new PartsSystemAPI();
                Part tmpPart;
                string tmpGrfa;
                completionSource.SetResult(Tuple.Create(api.ReadPart(request.Id,out tmpPart,out tmpGrfa),tmpPart,tmpGrfa));
            },new TaskCompletionSource<bool>()));
            completionSource.Task.Wait();
            var response = new ReadPartResponse();
            response.Status = completionSource.Task.Result.Item1;
            response.GRFA = completionSource.Task.Result.Item3;
            response.Part = completionSource.Task.Result.Item2;
            return response;
        }

        [Route("/parts/{id}")]
        public class Read<StructureName>Request
        {
            <SEGMENT_LOOP>
            public <SEGMENT_CSTYPE> <SegmentName> { get; set; }
            </SEGMENT_LOOP>
        }

        public class Read<StructureName>Response
        {
            public MethodStatus Status { get; set; }
            public <StructureName> <StructureName> { get; set; }
            public string GRFA { get; set; }
        }
;//{OperationContract}
;//public method Read<StructureName>, MethodStatus
;//    <SEGMENT_LOOP>
;//    required in  a<SegmentName>, <SEGMENT_CSTYPE>
;//    </SEGMENT_LOOP>
;//    required out a<StructureName>, @<StructureName>
;//    required out aGrfa, String
;//    endparams
;//proc
;//    data completionSource = new TaskCompletionSource<Tuple<MethodStatus,<StructureName>,String>>()
;//    lambda curryParams()
;//    begin
;//        data api, @<API_CLASS>, new <API_CLASS>()
;//        data tmp<StructureName>, @<StructureName>
;//        data tmpGrfa, String
;//        completionSource.SetResult(Tuple.Create(api.Read<StructureName>(<SEGMENT_LOOP>a<SegmentName>,</SEGMENT_LOOP>tmp<StructureName>,tmpGrfa),tmp<StructureName>,tmpGrfa))
;//    end
;//    this.ServiceDispatcher.Dispatch(curryParams)
;//    completionSource.Task.Wait()
;//    a<StructureName> = completionSource.Task.Result.Item2
;//    aGrfa = completionSource.Task.Result.Item3
;//    mreturn completionSource.Task.Result.Item1
;//endmethod
        </PRIMARY_KEY>


        public object Any(ReadAll<StructureName>sRequest request)
        {
            return new ReadAll<StructureName>sResponse();
        }

        [Route("/parts")]
        public class ReadAll<StructureName>sRequest
        {
        }

        public class ReadAll<StructureName>sResponse
        {
            public MethodStatus Status { get; set; }
            public List<<StructureName>> <StructureName>s { get; set; }
        }
;//{OperationContract}
;//public method ReadAll<StructureName>s, MethodStatus
;//    required out a<StructureName>s, @List<<StructureName>>
;//    endparams
;//proc
;//    data completionSource = new TaskCompletionSource<Tuple<MethodStatus,List<<StructureName>>>>()
;//    lambda curryParams()
;//    begin
;//        data api, @<API_CLASS>, new <API_CLASS>()
;//        data tmp<StructureName>s, @List<<StructureName>>
;//        completionSource.SetResult(Tuple.Create(api.ReadAll<StructureName>s(tmp<StructureName>s),tmp<StructureName>s))
;//    end
;//    this.ServiceDispatcher.Dispatch(curryParams)
;//    completionSource.Task.Wait()
;//    a<StructureName>s = completionSource.Task.Result.Item2
;//    mreturn completionSource.Task.Result.Item1
;//endmethod

        public object Any(Update<StructureName>Request request)
        {
            return new Update<StructureName>Response();
        }

        [Route("/parts")]
        //TODO: Needs to be a POST method
        public class Update<StructureName>Request
        {
          public <StructureName> <StructureName> { get; set; }
          public string GRFA { get; set; }
        }

        public class Update<StructureName>Response
        {
            public MethodStatus Status { get; set; }
            public <StructureName> <StructureName> { get; set; }
            public string GRFA { get; set; }
        }
;//{OperationContract}
;//public method Update<StructureName>, MethodStatus
;//    required inout a<StructureName>, @<StructureName>
;//    required inout aGrfa, String
;//    endparams
;//proc
;//    data completionSource = new TaskCompletionSource<Tuple<MethodStatus,<StructureName>,String>>()
;//    data tmp<StructureName>, @<StructureName>, a<StructureName>
;//    data tmpGrfa, String, aGrfa
;//    lambda curryParams()
;//    begin
;//        data api, @<API_CLASS>, new <API_CLASS>()
;//        completionSource.SetResult(Tuple.Create(api.Update<StructureName>(tmp<StructureName>,tmpGrfa),tmp<StructureName>,tmpGrfa))
;//    end
;//    this.ServiceDispatcher.Dispatch(curryParams)
;//    completionSource.Task.Wait()
;//    a<StructureName> = completionSource.Task.Result.Item2
;//    aGrfa = completionSource.Task.Result.Item3
;//    mreturn completionSource.Task.Result.Item1
;//endmethod

        public object Any(Delete<StructureName>Request request)
        {
            return new Delete<StructureName>Response();
        }
        
        [Route("/parts/{id}")]
        //TODO: Needs to be a DELETE method
        public class Delete<StructureName>Request
        {
            public string GRFA { get; set; }
        }

        public class Delete<StructureName>Response
        {
            public MethodStatus Status { get; set; }
        }
;//{OperationContract}
;//public method Delete<StructureName>, MethodStatus
;//    required in aGrfa, String
;//    endparams
;//proc
;//    data completionSource = new TaskCompletionSource<MethodStatus>()
;//    lambda curryParams()
;//    begin
;//        data api, @<API_CLASS>, new <API_CLASS>()
;//        completionSource.SetResult(api.Delete<StructureName>(aGrfa))
;//    end
;//    this.ServiceDispatcher.Dispatch(curryParams)
;//    completionSource.Task.Wait()
;//    mreturn completionSource.Task.Result
;//endmethod

        <PRIMARY_KEY>
        public object Any(<StructureName>ExistsRequest request)
        {
            return new <StructureName>ExistsResponse();
        }

        [Route("/parts/exists/{id}")]
        public class <StructureName>ExistsRequest
        {
            <SEGMENT_LOOP>
            public <SEGMENT_CSTYPE> <SegmentName> { get; set; }
            </SEGMENT_LOOP>
        }

        public class <StructureName>ExistsResponse
        {
            public MethodStatus Status { get; set; }
        }
;//{OperationContract}
;//public method <StructureName>Exists, MethodStatus
;//    <SEGMENT_LOOP>
;//    required in a<SegmentName>, <SEGMENT_CSTYPE>
;//    </SEGMENT_LOOP>
;//    endparams
;//proc
;//    data completionSource = new TaskCompletionSource<MethodStatus>()
;//    lambda curryParams()
;//    begin
;//        data api, @<API_CLASS>, new <API_CLASS>()
;//        completionSource.SetResult(api.<StructureName>Exists(<SEGMENT_LOOP>a<SegmentName><,></SEGMENT_LOOP>))
;//    end
;//    this.ServiceDispatcher.Dispatch(curryParams)
;//    completionSource.Task.Wait()
;//    mreturn completionSource.Task.Result
;//endmethod
        </PRIMARY_KEY>
    }
}
