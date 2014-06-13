import Cirrious.CrossCore.Platform
import Cirrious.MvvmCross.ViewModels
import Cirrious.MvvmCross.WindowsPhone.Platform
import Microsoft.Phone.Controls

.array 0
namespace $rootnamespace$

    public class Setup extends MvxPhoneSetup

        public method Setup
            rootFrame, @PhoneApplicationFrame 
            endparams
            parent(rootFrame)
        proc

        endmethod

        protected override method CreateApp, @IMvxApplication
            endparams
        proc
            mreturn new Core.App()
        endmethod

        protected override method CreateDebugTrace, @IMvxTrace
            endparams
        proc
            mreturn new DebugTrace()
        endmethod
        
    endclass
    
endnamespace

