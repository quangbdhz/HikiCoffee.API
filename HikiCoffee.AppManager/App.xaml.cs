using HikiCoffee.AppManager.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Windows;

namespace HikiCoffee.AppManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            //ViewModelLocationProvider.Register<MainView, MainViewModel>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
