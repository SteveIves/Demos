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
        [Description("Query for all items that currently exist.")]
        [WebGet(UriTemplate = "/favorites")]
        Dictionary<string, string> FavoritesQuery();

        [OperationContract]
        [Description("Create something new.")]
        [WebInvoke(Method = "POST", UriTemplate = "/favorites/{id}")]
        void FavoritesCreate(string id, string data);

        [OperationContract]
        [Description("Read something that already exists.")]
        [WebGet(UriTemplate = "/favorites/{id}")]
        string FavoritesRead(string id);

        [OperationContract]
        [Description("Update something that already exists.")]
        [WebInvoke(Method = "PUT", UriTemplate = "/favorites/{id}")]
        void FavoritesUpdate(string id, string data);

        [OperationContract]
        [Description("Delete something that already exists.")]
        [WebInvoke(Method = "DELETE", UriTemplate = "/favorites/{id}")]
        void FavoritesDelete(string id);

        [OperationContract]
        [Description("Post a message to the application.")]
        [WebInvoke(Method = "POST", UriTemplate = "/messages/{id}")]
        void MessagesCreate(string id, string data);

    }
}
