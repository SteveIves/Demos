using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebServer
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        string GetUserName();

        [OperationContract]
        int AddTwoNumbers(int x, int y);

        [OperationContract]
        List<Person> GetPeople(int howMany);
    }
}
