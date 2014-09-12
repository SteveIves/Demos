<CODEGEN_FILENAME><MAIN_CLASS>.dbl</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>MAIN_CLASS</REQUIRES_USERTOKEN>
;;******************************************************************************
;; WARNING: THIS FILE WAS CODE GENERATED. CHANGES MAY BE LOST IF REGENERATED
;;******************************************************************************

import AppDomainProtection

namespace <NAMESPACE>

    ;;; <summary>
    ;;; This partial class implements AppDomain pooling support methods. The
    ;;; methods declared here will be called by the AppDomain pooling manager
    ;;; as various events occur during the lifteime of <MAIN_CLASS> objects.
    ;;; </summary>
    public partial class <MAIN_CLASS> implements IAppDomainPoolable

        public method Initialize, void
            endparams
        proc
            ;TODO: Add code that you want to be executed only once
            ;      when a brand new instance of this class is created
        endmethod

        public method Activate, void
            endparams
        proc
            ;TODO: Add code that you want to be executed each time an instance
            ;      of this class is allocated for use by the AppDomain pool manager
        endmethod

        public method Deactivate, void
            endparams
        proc
            ;TODO: Add code that you want to be executed each time an instance
            ;      of this class is released back to the AppDomain pool manager
            ;      for potential reuse. The code should typically clean up any
            ;      resources that were allocated in the Activate method, and
            ;      could also be used to reset common or global variables to
            ;      known initial values.
        endmethod

        public method CanBeReused, boolean
            endparams
        proc
            ;TODO: Add code that you want to be executed as an instance of this
            ;      class is released back to the pool manager for potential reuse.
            ;      If this method returns a value of true then the object will be
            ;      returned to the pool for subsequent reuse. If the method returns
            ;      a value of false then the object will be discarded.
            mreturn true
        endmethod

        public method Cleanup, void
            endparams
        proc
            ;TODO: Add code that you want to be executed when an instance of the
            ;      class is about to be discarded by the AppDomain pool manager.
            ;      The code should typically release any resources that were allocated
            ;      by the Initialize method.
        endmethod

    endclass

endnamespace
