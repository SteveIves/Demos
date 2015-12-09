<CODEGEN_FILENAME><WCF_SERVICE>.cs</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>WCF_SERVICE</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>API_NAMESPACE</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>API_CLASS</REQUIRES_USERTOKEN>
//******************************************************************************
// WARNING: THIS FILE WAS CODE GENERATED. CHANGES MAY BE LOST IF REGENERATED
//******************************************************************************

using System;
using ServiceStack;
using System.Threading.Tasks;
using AppDomainProtection;
using ServiceStack.Web;
using ServiceStack.Configuration;
using <API_NAMESPACE>;

namespace <NAMESPACE>
{

    public class OurServiceWrapper : MarshalByRefObject, IService, IServiceBase, IRequiresRequest, IResolver, IDisposable
    {
        #region To be a ServiceStack.Service

        Service s = new Service();

        public IResolver GetResolver()
        {
            return s.GetResolver();
        }

        public T ResolveService<T>()
        {
            return s.ResolveService<T>();
        }

        public IRequest Request
        {
            get
            {
                return s.Request;
            }
            set
            {
                s.Request = value;
            }
        }

        public T TryResolve<T>()
        {
            return s.TryResolve<T>();
        }

        public void Dispose()
        {
            s.Dispose();
        }

        #endregion

        #region Our stuff

        public AppDomain GetAppDomain()
        {
            return AppDomain.CurrentDomain;
        }

        public BackgroundDispatcher ServiceDispatcher { get; set; }


        #endregion

    }

    public class <WCF_SERVICE>Host : AppSelfHostBase
    {
        public <WCF_SERVICE>Host()
            : base("HttpListener Self-Host", typeof(<WCF_SERVICE>).Assembly) { }

        public override void Configure(Funq.Container container) { }
    }

    //{ServiceContract(SessionMode = SessionMode.Required)}
    //{SingletonBehaviorAttribute(^typeof(<WCF_SERVICE>))}
    
    public partial class <WCF_SERVICE> : OurServiceWrapper, IAppDomainPoolable
    {
        public void Initialize()
        {
            //TODO: Shouldn't be using MethodStatus here because Initialize() is a void method, but there seems to be a compiler issue!
            //data completionSource = new TaskCompletionSource<MethodStatus>()
            //lambda curryParams()
            //begin
            //    data api, @<API_CLASS>, new <API_CLASS>()
            //    api.Initialize()
            //    completionSource.SetResult(MethodStatus.Success)
            //end
            //this.ServiceDispatcher.Dispatch(curryParams)
            //completionSource.Task.Wait()
        }

        public void Activate()
        {
            //TODO: Shouldn't be using MethodStatus here because Initialize() is a void method, but there seems to be a compiler issue!
            //data completionSource = new TaskCompletionSource<MethodStatus>()
            //lambda curryParams()
            //begin
            //    data api, @<API_CLASS>, new <API_CLASS>()
            //    api.Activate()
            //    completionSource.SetResult(MethodStatus.Success)
            //end
            //this.ServiceDispatcher.Dispatch(curryParams)
            //completionSource.Task.Wait()
        }

        public void Deactivate()
        {
            //TODO: Shouldn't be using MethodStatus here because Initialize() is a void method, but there seems to be a compiler issue!
            //data completionSource = new TaskCompletionSource<MethodStatus>()
            //lambda curryParams()
            //begin
            //    data api, @<API_CLASS>, new <API_CLASS>()
            //    api.Deactivate()
            //    completionSource.SetResult(MethodStatus.Success)
            //end
            //this.ServiceDispatcher.Dispatch(curryParams)
            //completionSource.Task.Wait()
        }

        public bool CanBeReused()
        {
            //data completionSource = new TaskCompletionSource<Boolean>()
            //lambda curryParams()
            //begin
            //    data api, @<API_CLASS>, new <API_CLASS>()
            //    completionSource.SetResult(api.CanBeReused())
            //end
            //this.ServiceDispatcher.Dispatch(curryParams)
            //completionSource.Task.Wait()
            //mreturn completionSource.Task.Result
            return false;
        }

        public void Cleanup()
        {
            //TODO: Shouldn't be using MethodStatus here because Initialize() is a void method, but there seems to be a compiler issue!
            //data completionSource = new TaskCompletionSource<MethodStatus>()
            //lambda curryParams()
            //begin
            //    data api, @<API_CLASS>, new <API_CLASS>()
            //    api.Cleanup()
            //    completionSource.SetResult(MethodStatus.Success)
            //end
            //this.ServiceDispatcher.Dispatch(curryParams)
            //completionSource.Task.Wait()
        }
    }
}
