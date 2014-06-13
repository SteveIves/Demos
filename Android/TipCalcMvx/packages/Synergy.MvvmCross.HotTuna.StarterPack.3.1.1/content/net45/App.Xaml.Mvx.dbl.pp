import System
import System.Windows
import Cirrious.CrossCore
import Cirrious.MvvmCross.ViewModels
import Cirrious.MvvmCross.Wpf.Views

.array 0
namespace $rootnamespace$

    public partial class App extends Application

        private mSetupComplete, boolean

        private method DoSetup, void
            endparams
        proc
            LoadMvxAssemblyResources()
            data presenter, @MvxSimpleWpfViewPresenter, new MvxSimpleWpfViewPresenter(MainWindow)
            data setup, @Setup, new Setup(Dispatcher, presenter)
            setup.Initialize()
            data start = Mvx.Resolve<IMvxAppStart>()
            start.Start()
            mSetupComplete = true
        endmethod

        protected override method OnActivated, void
            e, @EventArgs 
            endparams
        proc
            if (!mSetupComplete)
                DoSetup()
            parent.OnActivated(e)
        endmethod

        private method LoadMvxAssemblyResources, void
            endparams
        proc
            data i, int, 0
            while (true) do
            begin
                data key, string, "MvxAssemblyImport" + i.ToString()
                data data = TryFindResource(key)
                if (data == ^null)
                    mreturn
                ^incr(i, true)
            end
        endmethod
        
    endclass
    
endnamespace

