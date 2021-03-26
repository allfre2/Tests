using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TestingXamarin.Models;
using TestingXamarin.ViewModels;

namespace TestingXamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class UserDetailPage : ContentPage
    {
        UserInfoViewModel viewModel;

        public UserDetailPage(UserInfoViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public UserDetailPage()
        {
            InitializeComponent();

            var user = new User
            {
                Username = "diezletras",
                Email = "diezletras@house.com"
            };

            viewModel = new UserInfoViewModel(user);
            BindingContext = viewModel;
        }
    }
}