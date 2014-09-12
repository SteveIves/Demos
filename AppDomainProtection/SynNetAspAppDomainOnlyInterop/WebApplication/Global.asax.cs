using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Dictionary<String, String> settings = new Dictionary<string, string>();
            foreach (string key in ConfigurationManager.AppSettings)
                settings.Add(key, ConfigurationManager.AppSettings[key]);

            BusinessLogic.SynergyEnvironment.SetEnvironment(settings);
        }
    }
}