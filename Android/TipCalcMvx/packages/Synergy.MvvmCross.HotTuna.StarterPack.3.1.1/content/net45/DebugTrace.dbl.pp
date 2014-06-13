import System
import System.Diagnostics
import Cirrious.CrossCore.Platform

.array 0
namespace $rootnamespace$

    public class DebugTrace implements IMvxTrace

        public method Trace, void
            level, MvxTraceLevel 
            tag, string 
            message, @Func<string> 
            endparams
        proc
            Debug.WriteLine(tag + ":" + level + ":" + message())
        endmethod

        public method Trace, void
            level, MvxTraceLevel 
            tag, string 
            message, string 
            endparams
        proc
            Debug.WriteLine(tag + ":" + level + ":" + message)
        endmethod

        public method Trace, void
            level, MvxTraceLevel 
            tag, string 
            message, string 
            {System.ParamArray()}
            args, [#]@object 
            endparams
        proc
            try
            begin
                Debug.WriteLine(string.Format(tag + ":" + level + ":" + message, args))
            end
            catch (syn_exception, @FormatException)
            begin
                Trace(MvxTraceLevel.Error, tag, "Exception during trace of {0} {1} {2}", level, message)
            end
            endtry
        endmethod
        
    endclass
    
endnamespace

