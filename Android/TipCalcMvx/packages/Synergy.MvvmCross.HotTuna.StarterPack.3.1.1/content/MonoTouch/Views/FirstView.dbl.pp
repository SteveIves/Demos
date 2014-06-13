import System.Drawing
import Cirrious.MvvmCross.Binding.BindingContext
import Cirrious.MvvmCross.Touch.Views
import MonoTouch.ObjCRuntime
import MonoTouch.UIKit
import MonoTouch.Foundation

.array 0
namespace $rootnamespace$.Views

    {Register("FirstView")}
    public class FirstView extends MvxViewController

        public override method ViewDidLoad, void
            endparams
        proc
            View = new UIView {BackgroundColor = UIColor.White}
            parent.ViewDidLoad()

            ;; iOS 7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None

            data label, @UILabel, new UILabel(new RectangleF(10, 10, 300, 40))
            this.Add(label)
            
            data textField, @UITextField, new UITextField(new RectangleF(10, 50, 300, 40))
            this.Add(textField)
            
            data set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>()
            
            lambda lambda1(vm)
            begin
                vm.Hello
            end
            set.Bind(label).To(lambda1)
            
            lambda lambda2(vm)
            begin
                vm.Hello
            end
            set.Bind(textField).To(lambda2)
            
            set.Apply()
            
        endmethod
        
    endclass
    
endnamespace

