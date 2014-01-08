<CODEGEN_FILENAME>IsolatableServiceBase.dbl</CODEGEN_FILENAME>
;;******************************************************************************
;;* WARNING: Code generated at <TIME> on <DATE> by <AUTHOR>
;;******************************************************************************

import System

namespace <NAMESPACE>

    public class IsolatableServiceBase extends MarshalByRefObject
        
        public method GetAppDomain, @AppDomain
            endparams
        proc
            mreturn AppDomain.CurrentDomain
        endmethod

        public property ServiceDispatcher, @BackgroundDispatcher
            method get
            endmethod
            method set
            endmethod
        endproperty

    endclass

endnamespace
