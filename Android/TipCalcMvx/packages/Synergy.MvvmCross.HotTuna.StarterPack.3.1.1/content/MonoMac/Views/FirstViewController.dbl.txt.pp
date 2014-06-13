import System
import System.Collections.Generic
import System.Linq
import MonoMac.Foundation
import MonoMac.AppKit
import Cirrious.MvvmCross.Mac.Views
import Cirrious.MvvmCross.Binding.BindingContext
import Cirrious.MvvmCross.ViewModels

.array 0
namespace $rootnamespace$.Views

    {MvxViewFor(^typeof(FirstViewModel))}
    public partial class FirstViewController extends MvxViewController
        
.region "Constructors"

        ;; Called when created from unmanaged code
        public method FirstViewController
            handle, IntPtr 
            endparams
            parent(handle)
        proc
            Initialize()
        endmethod
        
        ;; Called when created directly from a XIB file
        {Export("initWithCoder:")}
        public method FirstViewController
            coder, @NSCoder 
            endparams
            parent(coder)
        proc
            Initialize()
        endmethod
        
        ;; Call to load from the XIB/NIB file
        public method FirstViewController
            endparams
            parent()
        proc
            Initialize()
        endmethod
        
        ;; Shared initialization code
        method Initialize, void
            endparams
        proc

        endmethod

.endregion

        ;; Strongly typed view accessor
        public new property View, @FirstView
            method get
            proc
                mreturn (@FirstView)parent.View
            endmethod
        endproperty

        public override method ViewDidLoad, void
            endparams
        proc
            parent.ViewDidLoad()
            data set = this.CreateBindingSet<FirstViewController, FirstViewModel>()
            lambda lambda1(v)
            begin
                v.StringValue
            end
            lambda lambda2(vm)
            begin
                vm.Hello
            end
            set.Bind(textFirst).For(lambda1).To(lambda2)
            set.Apply()
        endmethod
        
    endclass
    
endnamespace

