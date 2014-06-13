import System
import System.Collections.Specialized
import System.Windows.Input
import MonoTouch.UIKit

.array 0
namespace $rootnamespace$

    ;; This class is never actually executed, but when Xamarin linking is enabled it does how to ensure types and properties
    ;; are preserved in the deployed app

    {MonoTouch.Foundation.Preserve(AllMembers = true)}
    public class LinkerPleaseInclude

        public method Include, void
            uiButton, @UIButton 
            endparams
        proc
            lambda lambda1(s, e)
            begin
                uiButton.SetTitle(uiButton.Title(UIControlState.Normal), UIControlState.Normal)
            end
            uiButton.TouchUpInside += lambda1
        endmethod

        public method Include, void
            barButton, @UIBarButtonItem 
            endparams
        proc
            lambda lambda1(s, e)
            begin
                barButton.Title = barButton.Title.ToString() + ""
            end
            barButton.Clicked += lambda1
        endmethod

        public method Include, void
            textField, @UITextField 
            endparams
        proc
            textField.Text = textField.Text.ToString() + ""
            lambda lambda1(sender, args)
            begin
                textField.Text = ""
            end
            textField.EditingChanged += lambda1
        endmethod

        public method Include, void
            textView, @UITextView 
            endparams
        proc
            textView.Text = textView.Text.ToString() + ""
            lambda lambda1(sender, args)
            begin
                textView.Text = ""
            end
            textView.Changed += lambda1
        endmethod

        public method Include, void
            label, @UILabel 
            endparams
        proc
            label.Text = label.Text.ToString() + ""
        endmethod

        public method Include, void
            imageView, @UIImageView 
            endparams
        proc
            imageView.Image = new UIImage(imageView.Image.CGImage)
        endmethod

        public method Include, void
            date, @UIDatePicker 
            endparams
        proc
            date.Date = date.Date.AddSeconds(1)
            lambda lambda1(sender, args)
            begin
                date.Date = DateTime.MaxValue
            end
            date.ValueChanged += lambda1
        endmethod

        public method Include, void
            slider, @UISlider 
            endparams
        proc
            slider.Value = slider.Value + 1
            lambda lambda1(sender, args)
            begin
                slider.Value = 1
            end
            slider.ValueChanged += lambda1
        endmethod

        public method Include, void
            progress, @UIProgressView 
            endparams
        proc
            progress.Progress = progress.Progress + 1
        endmethod

        public method Include, void
            sw, @UISwitch 
            endparams
        proc
            sw.On = !sw.On
            lambda lambda1(sender, args)
            begin
                sw.On = false
            end
            sw.ValueChanged += lambda1
        endmethod

        public method Include, void
            changed, @INotifyCollectionChanged 
            endparams
        proc
            lambda lambda1(s, e)
            begin
                data test = string.Format("{0}{1}{2}{3}{4}", e.Action, e.NewItems, e.NewStartingIndex, e.OldItems, e.OldStartingIndex)
            end
            changed.CollectionChanged += lambda1
        endmethod

        public method Include, void
            command, @ICommand 
            endparams
        proc
            lambda lambda1(s, e)
            begin
                if (command.CanExecute(^null))
                    command.Execute(^null)
            end
            command.CanExecuteChanged += lambda1
        endmethod
        
    endclass
    
endnamespace

