<CODEGEN_FILENAME>I<WCF_SERVICE>.dbl</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>WCF_SERVICE</REQUIRES_USERTOKEN>
;;******************************************************************************
;; WARNING: THIS FILE WAS CODE GENERATED. CHANGES MAY BE LOST IF REGENERATED
;;******************************************************************************

import System
import System.Collections.Generic
import System.ServiceModel
import System.Threading.Tasks
import AppDomainProtection
import AppDomainProtectionCore

namespace <NAMESPACE>

    {ServiceContract(SessionMode = SessionMode.Required)}
    {SingletonBehaviorAttribute(^typeof(<WCF_SERVICE>))}
	{MarshaledAsyncBehavior}
    public partial interface I<WCF_SERVICE>

    endinterface

endnamespace
