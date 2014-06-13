import Cirrious.MvvmCross.ViewModels

namespace $rootnamespace$.ViewModels

    public class FirstViewModel extends MvxViewModel
    
		private mHello, String, "Hello MvvmCross"

        public property Hello, String
		    method get
		    proc
		        mreturn mHello
		    endmethod
		    method set
		    proc
		        mHello = value
		        RaisePropertyChanged("Hello")
		    endmethod
		endproperty

    endclass
    
endnamespace
