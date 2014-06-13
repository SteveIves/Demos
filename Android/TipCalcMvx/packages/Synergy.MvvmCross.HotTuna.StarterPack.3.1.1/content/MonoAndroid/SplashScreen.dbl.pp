import Android.App
import Android.Content.PM
import Cirrious.MvvmCross.Droid.Views

namespace $rootnamespace$
	
	{Activity(Label = "TipCalc.Android", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.Splash", NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)}
	public class SplashScreen extends MvxSplashScreenActivity
		
		public method SplashScreen
			endparams
			parent(Resource.Layout.SplashScreen)
		proc
			
		endmethod

	endclass

endnamespace
