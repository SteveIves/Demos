<CODEGEN_FILENAME><WCF_SERVICE>.dbl</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>WCF_SERVICE</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>API_NAMESPACE</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>API_CLASS</REQUIRES_USERTOKEN>
;;******************************************************************************
;; WARNING: THIS FILE WAS CODE GENERATED. CHANGES MAY BE LOST IF REGENERATED
;;******************************************************************************

import System
import System.Collections.Generic
import System.ServiceModel
import System.Threading.Tasks
import AppDomainProtection
import <API_NAMESPACE>

namespace <NAMESPACE>

    {ServiceContract(SessionMode = SessionMode.Required)}
    {SingletonBehaviorAttribute(^typeof(<WCF_SERVICE>))}
    public partial class <WCF_SERVICE> extends IsolatableServiceBase implements IAppDomainPoolable

        public method Initialize, void
            endparams
        proc
            ;TODO: Shouldn't be using MethodStatus here because Initialize() is a void method, but there seems to be a compiler issue!
            data completionSource = new TaskCompletionSource<MethodStatus>()
            lambda curryParams()
            begin
                data api, @<API_CLASS>, new <API_CLASS>()
                api.Initialize()
                completionSource.SetResult(MethodStatus.Success)
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            completionSource.Task.Wait()
        endmethod

        public method Activate, void
            endparams
        proc
            ;TODO: Shouldn't be using MethodStatus here because Initialize() is a void method, but there seems to be a compiler issue!
            data completionSource = new TaskCompletionSource<MethodStatus>()
            lambda curryParams()
            begin
                data api, @<API_CLASS>, new <API_CLASS>()
                api.Activate()
                completionSource.SetResult(MethodStatus.Success)
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            completionSource.Task.Wait()
        endmethod

        public method Deactivate, void
            endparams
        proc
            ;TODO: Shouldn't be using MethodStatus here because Initialize() is a void method, but there seems to be a compiler issue!
            data completionSource = new TaskCompletionSource<MethodStatus>()
            lambda curryParams()
            begin
                data api, @<API_CLASS>, new <API_CLASS>()
                api.Deactivate()
                completionSource.SetResult(MethodStatus.Success)
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            completionSource.Task.Wait()
        endmethod

        public method CanBeReused, boolean
            endparams
        proc
            data completionSource = new TaskCompletionSource<Boolean>()
            lambda curryParams()
            begin
                data api, @<API_CLASS>, new <API_CLASS>()
                completionSource.SetResult(api.CanBeReused())
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            completionSource.Task.Wait()
            mreturn completionSource.Task.Result
        endmethod

        public method Cleanup, void
            endparams
        proc
            ;TODO: Shouldn't be using MethodStatus here because Initialize() is a void method, but there seems to be a compiler issue!
            data completionSource = new TaskCompletionSource<MethodStatus>()
            lambda curryParams()
            begin
                data api, @<API_CLASS>, new <API_CLASS>()
                api.Cleanup()
                completionSource.SetResult(MethodStatus.Success)
            end
            this.ServiceDispatcher.Dispatch(curryParams)
            completionSource.Task.Wait()
        endmethod

    endclass

endnamespace
