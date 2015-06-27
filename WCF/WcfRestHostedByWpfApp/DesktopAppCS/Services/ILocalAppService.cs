using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DesktopAppCS.Services
{
    [ServiceContract(Namespace="demos.synergex.com")]
    [Description("Service description")]
    public interface ILocalAppService
    {
        [OperationContract]
        [Description("Post a message to the application.")]
        [WebInvoke(Method = "POST", UriTemplate = "/messages/{id}")]
        void MessagesCreate(string id, string data);

    }
}
