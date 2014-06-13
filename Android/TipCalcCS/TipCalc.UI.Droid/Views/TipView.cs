using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using TipCalc.Core.ViewModels;

namespace TipCalc.UI.Droid.Views
{
    [Activity(MainLauncher=true,Label="TipCalc",Theme="@style/Theme.MainView")]
    class TipView : MvxActivity
    {
        public new TipViewModel ViewModel
        {
            get { return (TipViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.TipView);
        }
    
    }
}