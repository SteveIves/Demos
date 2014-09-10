<CODEGEN_FILENAME>ServicesHelper.dbl</CODEGEN_FILENAME>
;;******************************************************************************
;;WARNING: This file was created by CodeGen. Changes will be lost if regenerated
;;******************************************************************************

import System
import System.Collections.Generic
import System.Reflection

namespace <NAMESPACE>

	public class ServicesHelper extends Services

		public method ServicesHelper
			endparams
		proc
			;;CRITICAL: If your Synergy .NET code uses xfServer to access data then you must ensure that
			;;your xfServer connection is locked to the current thread.
			try
			begin
				xcall s_server_thread_init
			end
			catch (ex)
			begin
				nop
			end
			endtry
			
		endmethod

	endclass

    public partial class Services extends MarshalByRefObject
	
    endclass

endnamespace
