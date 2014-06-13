using System;
using System.Drawing;

using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using TipCalc.Core.ViewModels;

namespace TipCalc.UI.Touch.Views
{
    [Register("UniversalView")]
    public class UniversalView : UIView
    {
        public UniversalView()
        {
            Initialize();
        }

        public UniversalView(RectangleF bounds)
            : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.White;
        }
    }

    [Register("TipView")]
    public class TipView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UniversalView();

            base.ViewDidLoad();

            // Perform any additional setup after loading the view

            var billAmountLabel = new UILabel(new RectangleF(10, 40, 300, 40));
            billAmountLabel.Text = "Bill Amount";
            Add(billAmountLabel);

            var subTotalTextField = new UITextField(new RectangleF(10, 80, 300, 40));
            Add(subTotalTextField);

            var sliderLabel = new UILabel(new RectangleF(10, 120, 300, 40));
            sliderLabel.Text = "Generosity";
            Add(sliderLabel);

            var slider = new UISlider(new RectangleF(10, 160, 300, 40));
            slider.MinValue = 0;
            slider.MaxValue = 40;
            Add(slider);

            var generosityPercentLabel = new UILabel(new RectangleF(10, 200, 300, 40));
            generosityPercentLabel.Text = "Tip Percentage";
            Add(generosityPercentLabel);

            var generosityPercent = new UILabel(new RectangleF(10, 240, 300, 40));
            Add(generosityPercent);

            var tipAmountLabel = new UILabel(new RectangleF(10, 280, 300, 40));
            tipAmountLabel.Text = "Tip to Leave";
            Add(tipAmountLabel);

            var tipAmount = new UILabel(new RectangleF(10, 320, 300, 40));
            Add(tipAmount);

            var totalLabel = new UILabel(new RectangleF(10, 360, 300, 40));
            totalLabel.Text = "Amount to Pay";
            Add(totalLabel);

            var total = new UILabel(new RectangleF(10, 400, 300, 40));
            Add(total);

            var set = this.CreateBindingSet<TipView, TipViewModel>();
            set.Bind(subTotalTextField).To(vm => vm.SubTotal);
            set.Bind(slider).To(vm => vm.Generosity);
            set.Bind(generosityPercent).To(vm => vm.Generosity);
            set.Bind(tipAmount).To(vm => vm.Tip);
            set.Bind(total).To(vm => vm.Total);
            set.Apply();


        }
    }
}