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
import Synergex.SynergyDE.Select
import AppDomainProtection

namespace <NAMESPACE>

    {ServiceContract(SessionMode = SessionMode.Required)}
    {SingletonBehaviorAttribute(^typeof(<WCF_SERVICE>))}
    public partial class <WCF_SERVICE> extends IsolatableServiceBase

    endclass

endnamespace
