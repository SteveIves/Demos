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
            ;TODO: Need to add code to call into the API class's method!
        endmethod

        public method Activate, void
            endparams
        proc
            ;TODO: Need to add code to call into the API class's method!
        endmethod

        public method Deactivate, void
            endparams
        proc
            ;TODO: Need to add code to call into the API class's method!
        endmethod

        public method CanBeReused, boolean
            endparams
        proc
            ;TODO: Need to add code to call into the API class's method!
            mreturn true
        endmethod

        public method Cleanup, void
            endparams
        proc
            ;TODO: Need to add code to call into the API class's method!
        endmethod

    endclass

endnamespace
