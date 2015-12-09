using System;
using ServiceStack;
using System.Collections.Generic;
using PartsSystem;

namespace server
{
    public partial class PartsSystemService
    {
        public object Any(GetAllPartsRequest request)
        {
            PartsSystemAPI api = new PartsSystemAPI();
            MethodStatus status;
            List<Part> parts;
            GetAllPartsResponse response = new GetAllPartsResponse();
            switch (status = api.ReadAllParts(out parts))
            {
                case MethodStatus.Success:
                    response.Parts = parts;
                    break;
                default:
                    break;
            }
            response.Status = status;
            return response;
        }

        public object Any(GetPartRequest request)
        {
            PartsSystemAPI api = new PartsSystemAPI();
            MethodStatus status;
            Part part;
            string grfa;
            GetPartResponse response = new GetPartResponse();
            switch (status = api.ReadPart(request.id, out part, out grfa))
            {
                case MethodStatus.Success:
                    response.Part = part;
                    response.GRFA = grfa;
                    break;
                default:
                    break;
            }
            response.Status = status;
            return response;
        }
    }

    [Route("/manual/parts")]
    public class GetAllPartsRequest
    {
    }

    public class GetAllPartsResponse
    {
        public MethodStatus Status { get; set; }
        public List<Part> Parts { get; set; }
    }

    [Route("/manual/parts/{id}")]
    public class GetPartRequest
    {
        public string id { get; set; }
    }

    public class GetPartResponse
    {
        public MethodStatus Status { get; set; }
        public Part Part { get; set; }
        public string GRFA { get; set; }
    }

}
