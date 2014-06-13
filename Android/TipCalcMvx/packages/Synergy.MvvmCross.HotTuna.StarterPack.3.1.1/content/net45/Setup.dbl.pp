import System.Windows.Threading
import Cirrious.CrossCore.Platform
import Cirrious.MvvmCross.ViewModels
import Cirrious.MvvmCross.Wpf.Platform
import Cirrious.MvvmCross.Wpf.Views

.array 0
namespace $rootnamespace$

    public class Setup extends MvxWpfSetup

        public method Setup
            dispatcher, @Dispatcher 
            presenter, @IMvxWpfViewPresenter 
            endparams
            parent(dispatcher, presenter)
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

