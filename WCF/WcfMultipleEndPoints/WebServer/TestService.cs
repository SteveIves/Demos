using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WebServer
{
    public class TestService : ITestService
    {
        public string GetUserName()
        {
            return System.Threading.Thread.CurrentPrincipal.Identity.Name;
        }

        public int AddTwoNumbers(int x, int y)
        {
            return x + y;
        }


        public List<Person> GetPeople(int howMany)
        {
            List<Person> people = new List<Person>();
            for (int i=0; i<howMany; i++)
                people.Add(new Person());
            return people;
        }
    }
}