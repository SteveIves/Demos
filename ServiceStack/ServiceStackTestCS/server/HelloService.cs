using System;
using ServiceStack;

namespace server
{
    public class HelloService : Service
    {
        public object Any(HelloRequest request)
        {
            return new HelloResponse { Result = "Hello, " + request.Name };
        }
    }

    public class HelloServiceHost : AppSelfHostBase
    {
        public HelloServiceHost()
            : base("HttpListener Self-Host", typeof(HelloService).Assembly) { }

        public override void Configure(Funq.Container container) { }
    }

    [Route("/hello/{Name}")]
    public class HelloRequest
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Result { get; set; }
    }

}
