using System;
using System.Web;
using System.IO;
using BusinessLogic;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace WebApplication
{
    /* 
     * This class provides an AppDomain protection wrapper for the
     * Synergy .NET code in the Services class. It is CRITICAL that
     * the Web application ALWAYS calls the methods exposed by the
     * Services class via an instance of the ServicesWrapper class.
     * The ServicesWrapper class should NEVER be persisted beyond
     * a single page instance, and the Dispose method should be called.
     * The best way to achieve this is to use a pattern like this:
     * 
     *      using (var servicesWrapper = new ServicesWrapper())
     *      {
     *          result = servicesWrapper.Services.SomeMethod(params)
     *      
     *          //Other code
     * 
     *      }
     */

    class ServicesWrapper : IDisposable
    {
        AppDomain _domain;
        public Services Services;


        public ServicesWrapper()
        {
            _domain = AppDomainUtil.GetAppDomain();

            //If you need to pass configuration information into your Synergy .NET code then
            //add a Dictionary<string,string> parameter to the constructor of your
            //helper class and do something like this. This example assumes you have
            //configuration info in Web.config.
            //Dictionary<String, String> settings = new Dictionary<string, string>();
            //foreach (string key in ConfigurationManager.AppSettings)
            //    settings.Add(key, ConfigurationManager.AppSettings[key]);
            // 
            //Services = _domain.CreateInstanceFromAndUnwrap(typeof(ServicesHelper).Assembly.CodeBase, typeof(ServicesHelper).FullName,
            //    false, System.Reflection.BindingFlags.CreateInstance, null, new object[] { settings }, null, null) as Services;
            
            //Otherwise your helper class constructor does not need a parameter, and you can do this:
            Services = _domain.CreateInstanceFromAndUnwrap(typeof(ServicesHelper).Assembly.CodeBase, typeof(ServicesHelper).FullName) as Services;
        }

        public void Dispose()
        {
            _domain = null;
            Services = null;
            AppDomainUtil.ThreadCleanup();
        }
    }
    
    public static class AppDomainUtil
    {
        public static Dictionary<Thread, AppDomain> _activeDomains = new Dictionary<Thread, AppDomain>();

        public static AppDomain GetAppDomain()
        {
            lock (_activeDomains)
            {
                if (_activeDomains.ContainsKey(Thread.CurrentThread))
                    return _activeDomains[Thread.CurrentThread];
                else
                {
                    var domain = AppDomain.CreateDomain(Guid.NewGuid().ToString());
                    _activeDomains.Add(Thread.CurrentThread,domain);
                    return domain;
                }
            }
        }

        public static void ThreadCleanup()
        {
            lock (_activeDomains)
            {
                foreach (var item in _activeDomains.Where(tpl => !tpl.Key.IsAlive).ToList())
                {
                    AppDomain.Unload(item.Value);
                    _activeDomains.Remove(item.Key);
                }
            }
        }

    }

}