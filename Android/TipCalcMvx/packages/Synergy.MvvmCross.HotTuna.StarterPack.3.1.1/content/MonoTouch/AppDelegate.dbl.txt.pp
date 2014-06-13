import MonoTouch.Foundation
import MonoTouch.UIKit
import Cirrious.CrossCore
import Cirrious.MvvmCross.Touch.Platform
import Cirrious.MvvmCross.ViewModels

.array 0
namespace $rootnamespace$

    {Register("AppDelegate")}
    public partial class AppDelegate extends MvxApplicationDelegate

        mindow, @UIWindow

        public override method FinishedLaunching, boolean
            app, @UIApplication 
            options, @NSDictionary 
            endparams
        proc
            mWindow = new UIWindow(UIScreen.MainScreen.Bounds)
            
            data setup, @Setup, new Setup(this, mWindow)
            setup.Initialize()
            
            data startup = Mvx.Resolve<IMvxAppStart>()
            startup.Start()
            
            mWindow.MakeKeyAndVisible()
            
            mreturn true

        endmethod
        
    endclass
    
endnamespace

