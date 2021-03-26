using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TestingXamarin.Models;
using TestingXamarin.Views;
using TestingXamarin.ViewModels;

namespace TestingXamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class UsersPage : ContentPage
    {
        UsersViewModel viewModel;

        public UsersPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new UsersViewModel();
        }

        async void OnUserSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var user = args.SelectedItem as User;
            if (user == null)
                return;

            await Navigation.PushAsync(new UserDetailPage(new UserInfoViewModel(user)));

            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Users.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}