import MonoTouch.UIKit
import Cirrious.CrossCore.Platform
import Cirrious.MvvmCross.ViewModels
import Cirrious.MvvmCross.Touch.Platform

.array 0
namespace $rootnamespace$

    public class Setup extends MvxTouchSetup

        public method Setup
            applicationDelegate, @MvxApplicationDelegate 
            window, @UIWindow 
            endparams
            parent(applicationDelegate, window)
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

