
using System;
using System.Collections.Generic;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;

namespace TipCalc.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.TipViewModel>();
        }
    }
}