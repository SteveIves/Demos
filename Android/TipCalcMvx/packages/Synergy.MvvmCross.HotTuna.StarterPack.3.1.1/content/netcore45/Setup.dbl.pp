import Cirrious.CrossCore.Platform
import Cirrious.MvvmCross.ViewModels
import Cirrious.MvvmCross.WindowsStore.Platform
import Windows.UI.Xaml.Controls

.array 0
namespace $rootnamespace$

    public class Setup extends MvxStoreSetup

        public method Setup
            rootFrame, @Frame 
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

