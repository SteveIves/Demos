<CODEGEN_FILENAME><WCF_SERVICE>.dbl</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>WCF_SERVICE</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>API_NAMESPACE</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>API_CLASS</REQUIRES_USERTOKEN>
;;******************************************************************************
;;* WARNING: Code generated at <TIME> on <DATE> by <AUTHOR>
;;******************************************************************************

import System
import System.Collections.Generic
import System.ServiceModel
import System.Threading.Tasks
import AppDomainProtection
import <API_NAMESPACE>

namespace <NAMESPACE>

    {ServiceContract(SessionMode = SessionMode.Required)}
    {SingletonBehaviorAttribute()}
    public partial class <WCF_SERVICE> extends IsolatableServiceBase

    endclass

endnamespace
