using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreshMvvm;
using Mde.MvvmNames.Mobile.ViewModels;

namespace Mde.MvvmNames.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var namePage = FreshPageModelResolver.ResolvePageModel<NameViewModel>();
            MainPage = new FreshNavigationContainer(namePage);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
