//******************************************************************************
// WARNING: THIS FILE WAS CODE GENERATED. CHANGES MAY BE LOST IF REGENERATED
//******************************************************************************

using System;
using ServiceStack;
using System.Collections.Generic;
using System.Threading.Tasks;
using PartsSystem;

namespace server
{
    public partial class PartsSystemService
    {
        public object Any(CreatePartRequest request)
        {
            return new CreatePartResponse();
        }

        [Route("/parts")]
        //TODO: Needs to be a PUT method
        public class CreatePartRequest
        {
          public Part Part { get; set; }
        }

        public class CreatePartResponse
        {
            public MethodStatus Status { get; set; }
        }

        public object Any(ReadPartRequest request)
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
        public class ReadPartRequest
        {
            public string Id { get; set; }
        }

        public class ReadPartResponse
        {
            public MethodStatus Status { get; set; }
            public Part Part { get; set; }
            public string GRFA { get; set; }
        }


        public object Any(ReadAllPartsRequest request)
        {
            return new ReadAllPartsResponse();
        }

        [Route("/parts")]
        public class ReadAllPartsRequest
        {
        }

        public class ReadAllPartsResponse
        {
            public MethodStatus Status { get; set; }
            public List<Part> Parts { get; set; }
        }

        public object Any(UpdatePartRequest request)
        {
            return new UpdatePartResponse();
        }

        [Route("/parts")]
        //TODO: Needs to be a POST method
        public class UpdatePartRequest
        {
          public Part Part { get; set; }
          public string GRFA { get; set; }
        }

        public class UpdatePartResponse
        {
            public MethodStatus Status { get; set; }
            public Part Part { get; set; }
            public string GRFA { get; set; }
        }

        public object Any(DeletePartRequest request)
        {
            return new DeletePartResponse();
        }

        [Route("/parts/{id}")]
        //TODO: Needs to be a DELETE method
        public class DeletePartRequest
        {
            public string GRFA { get; set; }
        }

        public class DeletePartResponse
        {
            public MethodStatus Status { get; set; }
        }

        public object Any(PartExistsRequest request)
        {
            return new PartExistsResponse();
        }

        [Route("/parts/exists/{id}")]
        public class PartExistsRequest
        {
            public string Id { get; set; }
        }

        public class PartExistsResponse
        {
            public MethodStatus Status { get; set; }
        }
    }
}
