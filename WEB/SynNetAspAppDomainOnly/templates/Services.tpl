<CODEGEN_FILENAME>Services.dbl</CODEGEN_FILENAME>
;;******************************************************************************
;;WARNING: This file was created by CodeGen. Changes will be lost if regenerated
;;******************************************************************************

import System
import System.Collections.Generic
import System.Reflection

namespace <NAMESPACE>

    ;;; <summary>
    ;;; This class exposes Synergy methods to the client application. Notice that
    ;;; it is a PARTIAL class, so additional code generated methods can be added
    ;;; to the class (for example via the ServicesCRUD template), and other
    ;;; hand-crafted methods could be added in seperate source files.
    ;;; </summary>
    public partial class Services extends MarshalByRefObject
		
		;;If you need to pass configuration data in from the Web application then this constructor
		;;should have a parameter to do that. If you don't need to pass in configuration data
		;;then you don't need the "settings" parameter or the code that uses it. Also refer to the
		;;comments in ServicesWrapper.cs
		
		public method Services
;			required in settings, @Dictionary<String, String>
			endparams
			record
				status, i4	;Result of XCALL SETLOG
			endrecord
		proc
			;;This is an example of taking configuration data that was passed in by the Web
			;;application, and setting environment variables based on the values passed.
			;;If you are not passing in configuration data then remove these lines.
;			data item, @KeyValuePair<String,String>
;			foreach item in settings
;				xcall setlog(item.Key, item.Value, status)
			
			;;You can also just set logicals here without passing the data in. The code in
			;;this example needs DAT: to be defined to the location of data files.
			data dataPath, String, string.Format("{0}\..\..\data",System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            xcall setlog("DAT",dataPath,status)

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
	
endnamespace