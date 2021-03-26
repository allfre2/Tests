using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestingXamarin.Services;
using TestingXamarin.Views;

namespace TestingXamarin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            // DependencyService.Register<IUserDataSource, RandomUserSource>();
            DependencyService.Register<IUserDataSource, JSONPlaceHolderUserSource>();
            MainPage = new MainPage();
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
