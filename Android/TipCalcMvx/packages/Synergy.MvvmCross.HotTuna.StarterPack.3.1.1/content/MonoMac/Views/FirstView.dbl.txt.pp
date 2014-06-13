import System
import System.Collections.Generic
import System.Linq
import MonoMac.Foundation
import MonoMac.AppKit
import Cirrious.MvvmCross.Binding.Mac.Views

.array 0
namespace $rootnamespace$.Views

    public partial class FirstView extends MvxView
        
.region "Constructors"

        ;;  Called when created from unmanaged code
        public method FirstView
            handle, IntPtr 
            endparams
            parent(handle)
        proc
            Initialize()
        endmethod

        ;;  Called when created directly from a XIB file
        {Export("initWithCoder:")}
        public method FirstView
            coder, @NSCoder 
            endparams
            parent(coder)
        proc
            Initialize()
        endmethod

        ;;  Shared initialization code
        method Initialize, void
            endparams
        proc

        endmethod

.endregion

    endclass

endnamespace

