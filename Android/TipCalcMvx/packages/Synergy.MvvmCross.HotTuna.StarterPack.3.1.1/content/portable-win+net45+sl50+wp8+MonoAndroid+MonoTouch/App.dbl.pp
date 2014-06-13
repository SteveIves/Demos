
import System
import System.Collections.Generic
import Cirrious.CrossCore.IoC
import Cirrious.MvvmCross.ViewModels

namespace $rootnamespace$

    public class App extends MvxApplication
    
        public override method Initialize, void
            endparams
        proc
			;TODO: Bug workaround, should be: CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton()
			data serviceTypes, @IEnumerable<Type>, this.CreatableTypes().EndingWith("Service")
			data serviceInterfaces, @IEnumerable<MvxTypeExtensions.ServiceTypeAndImplementationTypePair>, MvxTypeExtensions.AsInterfaces(serviceTypes)
			MvxTypeExtensions.RegisterAsLazySingleton(serviceInterfaces)
			
			RegisterAppStart<$rootnamespace$.ViewModels.FirstViewModel>()
			
        endmethod
        
    endclass

endnamespace