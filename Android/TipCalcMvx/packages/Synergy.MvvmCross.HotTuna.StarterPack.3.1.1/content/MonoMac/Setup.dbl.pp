import MonoMac.Foundation
import MonoMac.AppKit
import Cirrious.MvvmCross.ViewModels
import Cirrious.MvvmCross.Mac.Platform
import Cirrious.MvvmCross.Mac.Views.Presenters
import Cirrious.CrossCore.Platform

.array 0
namespace $rootnamespace$

    public class Setup extends MvxMacSetup

        public method Setup
            applicationDelegate, @MvxApplicationDelegate 
            window, @NSWindow 
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

