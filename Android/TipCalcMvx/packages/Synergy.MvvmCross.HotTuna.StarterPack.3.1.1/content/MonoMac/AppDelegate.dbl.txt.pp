import System
import System.Drawing
import MonoMac.Foundation
import MonoMac.AppKit
import MonoMac.ObjCRuntime
import Cirrious.MvvmCross.Mac.Views.Presenters
import Cirrious.CrossCore
import Cirrious.MvvmCross.ViewModels
import Cirrious.MvvmCross.Mac.Platform

.array 0
namespace $rootnamespace$

    public partial class AppDelegate extends MvxApplicationDelegate

        mWindow, @NSWindow

        public override method FinishedLaunching, void
            notification, @NSObject 
            endparams
        proc
            mWindow = new NSWindow(new RectangleF(200, 200, 400, 700), (NSWindowStyle.Closable | NSWindowStyle.Resizable) | NSWindowStyle.Titled, NSBackingStore.Buffered, false, NSScreen.MainScreen)
            
            data setup, @Object, new Setup(this, mWindow)
            setup.Initialize()

            data startup = Mvx.Resolve<IMvxAppStart>()
            startup.Start()

            mWindow.MakeKeyAndOrderFront(this)

        endmethod

    endclass
    
endnamespace

