using System;
using System.Web.Script.Serialization;

namespace KitaroDemo
{
    public class Person
    {
        public string PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ScriptIgnore]
        public string JsonData
        {
            get
            {
                return new JavaScriptSerializer().Serialize(this);
            }
        }

        public string ToJson()
        {
            return new JavaScriptSerializer().Serialize(this);
        }

        public static Person FromJson(string json)
        {
            return new JavaScriptSerializer().Deserialize<Person>(json);
        }

    }

}
