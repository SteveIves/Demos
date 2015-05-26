using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DesktopAppCS.Services
{

    /*
     * In order to be able to self-wcfServiceHost a WCF service in a .NET application, without
     * requiring administrator rights, it is necessary to reserve a portion of the HTTP
     * namespace that the service will use. This is done by issuing NETSH commands.
     * 
     * Add a reservation:
     * 
     * netsh http add urlacl url=http://+:8088/LocalAppService user=DOMAIN\user
     * 
     * View reservations:
     * 
     * netsh http show urlacl url=http://+:8088/LocalAppService/
     * 
     * Delete a reservation:
     * 
     * netsh http delete urlacl url=http://+:8088/LocalAppService/
     * 
     * Note that including the trailing / for the SHOW and DELETE commands is important, even
     * if the trailing / was not included on the ADD statement.
     * 
     * If a reservation is not made then you must start Visual Studio "As Administrator" in
     * order to run the application that hosts the service. Failing to do so will result in
     * an AddressAccessDeniedException exception (HTTP could not register URL XXXXXX. Your
     * process does not have access rights to this namespace) being thrown when you call the
     * Open() method of your ServiceHost object.
     * 
     * 
     * More information at https://msdn.microsoft.com/en-us/library/ms733768.aspx
     */

    public class LocalServicesHost
    {
        ServiceHost wcfServiceHost;
        Thread wcfServiceThread;
        Dispatcher uiThreadDispatcher;

        public LocalServicesHost()
        {
            LocalServicesUrl = String.Empty;
        }

        public void StartServices()
        {
            //Save the current (UI thread dispatcher) so we can use it later
            uiThreadDispatcher = Dispatcher.CurrentDispatcher;

            //Determine the URL that our WCF service will listen at
            LocalServicesUrl = String.Format("http://{0}:8088/LocalAppService/", Dns.GetHostName());

            wcfServiceThread = new Thread(() =>
            {
                //Create an instance of our WCF service implementation
                var wcfServiceInstance = new LocalAppService();

                //Add an event handler for the MessageReceived event
                wcfServiceInstance.MessageReceived += wcfServiceInstance_MessageReceived;

                //Create a new service wcfServiceHost
                wcfServiceHost = new ServiceHost(wcfServiceInstance, new Uri(LocalServicesUrl));

                //-----------------------------------------------------------------------------

                //Add our main endpoint
                ServiceEndpoint ep = wcfServiceHost.AddServiceEndpoint(typeof(ILocalAppService), new WebHttpBinding(), "");
                ep.Behaviors.Add(new WebHttpBehavior { HelpEnabled = true, AutomaticFormatSelectionEnabled = true });

                //Add a MEX endpoint
                wcfServiceHost.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });

                //Working with ServiceDebugBehavior is a little different because there will already be one present in the configuration by default
                ServiceDebugBehavior sdb = wcfServiceHost.Description.Behaviors.OfType<ServiceDebugBehavior>().First();
                sdb.IncludeExceptionDetailInFaults = true;
                sdb.HttpHelpPageEnabled = true;

				//The configuration code above is the equivalent of having the following
				//code in the applications App.config file
				//
				//<system.serviceModel>
				//  <services>
				//    <service behaviorConfiguration="httpBehaviour" name="DesktopApp.Services.LocalAppService">
				//      <endpoint address="" behaviorConfiguration="httpEndpointBehavour" binding="webHttpBinding" contract="DesktopApp.Services.ILocalAppService" />
				//      <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
				//    </service>
				//  </services>
				//  <behaviors>
				//    <serviceBehaviors>
				//      <behavior name="httpBehaviour">
				//        <!--Don't expose WSDL because it's meaningless for REST services-->
				//        <serviceMetadata httpGetEnabled="false"/>
				//        <!--Disable the service home page because it is misleading for REST services because svcutil.exe doesn't work-->
				//        <serviceDebug includeExceptionDetailInFaults="false" httpHelpPageEnabled="false" httpsHelpPageEnabled="false"/>
				//      </behavior>
				//    </serviceBehaviors>
				//    <endpointBehaviors>
				//      <behavior name="httpEndpointBehavour">
				//        <webHttp helpEnabled="true" automaticFormatSelectionEnabled="true"/>
				//      </behavior>
				//    </endpointBehaviors>
				//  </behaviors>
                //</system.serviceModel>
                //-----------------------------------------------------------------------------

                //Start the service
                wcfServiceHost.Open();
            });
            
            //Start the new thread
            wcfServiceThread.Start();
        }

        void wcfServiceInstance_MessageReceived(string id, string data)
        {
            //Raise our NewMessage event back on the UI thread
            uiThreadDispatcher.BeginInvoke((Action)(() =>
            {
                if (NewMessage != null)
                    NewMessage(id, data);
            }));
        }

        public void StopServices()
        {
            try
            {
                wcfServiceHost.Close();
            }
            catch
            {
            }
            finally
            {
                LocalServicesUrl = String.Empty;
                wcfServiceHost = null;
            }
        }

        public delegate void MessageHandler(string id, string data);

        public event MessageHandler NewMessage;

        public string LocalServicesUrl { get; set; }
    }
}
