<CODEGEN_FILENAME><MAIN_CLASS>.dbl</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>MAIN_CLASS</REQUIRES_USERTOKEN>
;;******************************************************************************
;;* WARNING: Code generated at <TIME> on <DATE> by <AUTHOR>
;;******************************************************************************

import System

namespace <NAMESPACE>

    ;;; <summary>
    ;;; This class exposes Synergy methods to the client application. Notice that
    ;;; it is a PARTIAL class, so additional code generated methods can be added
    ;;; to the class, and other hand-crafted methods could be added in seperate
    ;;; source files.
    ;;; </summary>
    public partial class <MAIN_CLASS> extends MarshalByRefObject
		
.region "MarshalByRefObject Members"
		
    ;;; <summary>
    ;;; This method ensures that the lifetime of the proxy for objects
    ;;; is set to an indefinite period of time. This is OK because the
    ;;; lifetime of the containing AppDomain is managed based on the
    ;;; lifetime of the ASP.NET session.
    ;;; </summary>
    public override method InitializeLifetimeService, @Object
        endparams
    proc
        mreturn ^null
    endmethod
		
.endregion
		
	endclass
	
endnamespace

