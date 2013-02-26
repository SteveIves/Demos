using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

using WcfRestDynamicResponse;

namespace WcfRestWebHost
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            // Edit the base address of the service by replacing the "Customers" string below

            //Default factory, XML or JSON but not both, without duplicating methods & code
            //RouteTable.Routes.Add(new ServiceRoute("Customers", new WebServiceHostFactory(), typeof(WcfRestService.CustomersService)));
            
            //Custom factory used to support XML or JSON based on headers from the client
            RouteTable.Routes.Add(new ServiceRoute("Customers", new DynamicResponseServiceHostFactory(), typeof(WcfRestService.CustomersService)));
        }
    }
}
