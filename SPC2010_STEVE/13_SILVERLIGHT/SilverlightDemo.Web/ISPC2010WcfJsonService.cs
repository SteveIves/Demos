using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SilverlightDemo.Web
{
    [ServiceContract]
    public interface ISPC2010WcfJsonService
    {
        [OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest,ResponseFormat = WebMessageFormat.Json]
        MethodStatus GetCustomers(out List<Customer> customers, out string message);

        [OperationContract]
        List<Contact> GetCustomerContacts(int customerId);

        [OperationContract]
        List<Address> GetCustomerAddresses(int customerId);

        [OperationContract]
        MethodStatus GetCustomerForUpdate(int customerId, out Customer customer, out byte[] grfa, out string message);

        [OperationContract]
        MethodStatus UpdateCustomer(ref Customer customer, ref byte[] grfa, out string message);
    }
}
