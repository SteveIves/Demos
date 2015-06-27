using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DesktopAppCS.Services
{
    /*
     * NOTE: To be able to wcfServiceHost this service in Visual Studio you must prevent WebFaultException
     * from being reported as "unprocessed by user code". To do this use the DEBUG > Exceptions
     * Dialog and under Common Language Runtime Exceptions uncheck the "User-unhandled" checkbox
     * next to System.ServiceModel.Web.WebFaultException.
     * 
     * If you can't find the exception listed use the Add... button to add the exception using its
     * full path System.ServiceModel.Web.WebFaultException under Common Language Runtime Exceptions.
     */


    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class LocalAppService : ILocalAppService
    {
        public void MessagesCreate(string id, string data)
        {
            //Validate the message that was received
            switch (id)
            {
                case "COLOR":
                    //Make sure the data contains one of the supported colors
                    switch (data.ToUpper())
                    {
                        case "RED":
                        case "WHITE":
                        case "BLUE":
                            break;
                        default:
                            throw new WebFaultException(HttpStatusCode.NotFound);
                    }
                    break;

                case "EXIT":
                    break;
                
                default:
                    throw new WebFaultException(HttpStatusCode.NotFound);
            }


            if (MessageReceived != null)
                MessageReceived(id.ToUpper(), data);
        }

        public delegate void MessageReceivedHandler(string id, string data);

        public event MessageReceivedHandler MessageReceived;
    }
}
