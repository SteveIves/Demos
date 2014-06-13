import System.Collections.Specialized
import System.Windows.Input
import Android.Views
import Android.Widget

namespace $rootnamespace$

    ;; This class is never actually executed, but when Xamarin linking is enabled
	;; it does how to ensure types and properties are preserved in the deployed app
	
	public class LinkerPleaseInclude
		
		public method Include, void
			button, @Button 
			endparams
		proc
			lambda lambda1(s, e)
			begin
				button.Text = button.Text + ""
			end
			button.Click += lambda1
		endmethod
		
		public method Include, void
			checkBox, @CheckBox 
			endparams
		proc
			lambda lambda1(sender, args)
			begin
				checkBox.Checked = !checkBox.Checked
			end
			checkBox.CheckedChange += lambda1
		endmethod
		
		public method Include, void
			view, @View 
			endparams
		proc
			lambda lambda1(s, e)
			begin
				view.ContentDescription = view.ContentDescription + ""
			end
			view.Click += lambda1
		endmethod
		
		public method Include, void
			text, @TextView 
			endparams
		proc
			lambda lambda1(sender, args)
			begin
				text.Text = "" + text.Text
			end
			text.TextChanged += lambda1
			text.Hint = "" + text.Hint
		endmethod
		
		public method Include, void
			cb, @CompoundButton 
			endparams
		proc
			lambda lambda1(sender, args)
			begin
				cb.Checked = !cb.Checked
			end
			cb.CheckedChange += lambda1
		endmethod
		
		public method Include, void
			sb, @SeekBar 
			endparams
		proc
			lambda lambda1(sender, args)
			begin
				sb.Progress = sb.Progress + 1
			end
			sb.ProgressChanged += lambda1
		endmethod
		
		public method Include, void
			changed, @INotifyCollectionChanged 
			endparams
		proc
			lambda lambda1(s, e)
			begin
				data test, String, String.Format("{0}{1}{2}{3}{4}", e.Action, e.NewItems, e.NewStartingIndex, e.OldItems, e.OldStartingIndex)
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
