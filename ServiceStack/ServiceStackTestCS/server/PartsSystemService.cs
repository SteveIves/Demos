//******************************************************************************
// WARNING: THIS FILE WAS CODE GENERATED. CHANGES MAY BE LOST IF REGENERATED
//******************************************************************************

using System;
using ServiceStack;
using System.Threading.Tasks;
using AppDomainProtection;
using ServiceStack.Web;
using ServiceStack.Configuration;
using PartsSystem;

namespace server
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

    public class PartsSystemServiceHost : AppSelfHostBase
    {
        public PartsSystemServiceHost()
            : base("HttpListener Self-Host", typeof(PartsSystemService).Assembly) { }

        public override void Configure(Funq.Container container) { }
    }

    //{ServiceContract(SessionMode = SessionMode.Required)}
    //{SingletonBehaviorAttribute(^typeof(PartsSystemService))}

    public partial class PartsSystemService : OurServiceWrapper, IAppDomainPoolable
    {
        public void Initialize()
        {
            //TODO: Shouldn't be using MethodStatus here because Initialize() is a void method, but there seems to be a compiler issue!
            //data completionSource = new TaskCompletionSource<MethodStatus>()
            //lambda curryParams()
            //begin
            //    data api, @PartsSystemAPI, new PartsSystemAPI()
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
            //    data api, @PartsSystemAPI, new PartsSystemAPI()
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
            //    data api, @PartsSystemAPI, new PartsSystemAPI()
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
            //    data api, @PartsSystemAPI, new PartsSystemAPI()
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
            //    data api, @PartsSystemAPI, new PartsSystemAPI()
            //    api.Cleanup()
            //    completionSource.SetResult(MethodStatus.Success)
            //end
            //this.ServiceDispatcher.Dispatch(curryParams)
            //completionSource.Task.Wait()
        }
    }
}
