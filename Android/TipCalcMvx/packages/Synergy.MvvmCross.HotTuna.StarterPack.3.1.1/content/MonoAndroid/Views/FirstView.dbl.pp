import Android.App
import Android.OS
import Cirrious.MvvmCross.Droid.Views

.array 0
namespace $rootnamespace$.Views

    {Activity(Label = "View for FirstViewModel", Theme = "@style/Theme.MainView")}
    public class FirstView extends MvxActivity

        protected override method OnCreate, void
            bundle, @Bundle 
            endparams
        proc
            parent.OnCreate(bundle)
            SetContentView(Resource.Layout.FirstView)
        endmethod

    endclass

endnamespace