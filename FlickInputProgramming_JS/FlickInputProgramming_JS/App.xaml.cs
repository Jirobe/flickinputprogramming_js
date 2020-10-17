using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlickInputProgramming_JS.Services;
using FlickInputProgramming_JS.Views;

namespace FlickInputProgramming_JS
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
