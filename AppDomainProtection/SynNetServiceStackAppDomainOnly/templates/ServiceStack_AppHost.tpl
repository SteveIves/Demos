<CODEGEN_FILENAME>AppHost.dbl</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>SERVICES_PROJECT</REQUIRES_USERTOKEN>
;;******************************************************************************
;; WARNING: THIS FILE WAS CODE GENERATED. CHANGES MAY BE LOST IF REGENERATED
;;******************************************************************************

.array 0

namespace <NAMESPACE>

    public class AppHost extends ServiceStack.AppSelfHostBase

        ;;;  <summary>
        ;;;  Default constructor.
        ;;;  Base constructor requires a name and assembly to locate web service classes. 
        ;;;  </summary>
        public method AppHost
            endparams
            parent("SynNetServiceStackAppDomainOnly Service", ^typeof(<SERVICES_PROJECT>.<StructureName>sService).Assembly)
        proc

        endmethod

        ;;;  <summary>
        ;;;  Application specific configuration
        ;;;  This method should initialize any IoC resources utilized by your web service classes.
        ;;;  </summary>
        ;;;  <param name="container"></param>
        public override method Configure, void
            container, @Funq.Container
            endparams
        proc

        endmethod

    endclass

endnamespace
