<CODEGEN_FILENAME>AppHost.dbl</CODEGEN_FILENAME>
;//<REQUIRES_USERTOKEN>LOGIC_PROJECT</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>SERVICES_PROJECT</REQUIRES_USERTOKEN>
;;******************************************************************************
;; WARNING: THIS FILE WAS CODE GENERATED. CHANGES MAY BE LOST IF REGENERATED
;;******************************************************************************

import System.Reflection
import Funq
import ServiceStack
;import <LOGIC_PROJECT>
import <SERVICES_PROJECT>

.array 0

namespace <NAMESPACE>

    public class AppHost extends AppSelfHostBase

        ;;;  <summary>
        ;;;  Default constructor.
        ;;;  Base constructor requires a name and assembly to locate web service classes. 
        ;;;  </summary>
        public method AppHost
            endparams
            parent("SynNetServiceStackAppDomainOnly Service", ^typeof(<StructureName>sService).Assembly)
        proc

        endmethod

        ;;;  <summary>
        ;;;  Application specific configuration
        ;;;  This method should initialize any IoC resources utilized by your web service classes.
        ;;;  </summary>
        ;;;  <param name="container"></param>
        public override method Configure, void
            ctr, @Container
            endparams
        proc
            ;; Enable sessions
            ;; this.Plugins.Add(new SessionFeature())
        endmethod

    endclass

endnamespace
