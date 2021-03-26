using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TestingXamarin.Models;
using TestingXamarin.Views;
using TestingXamarin.Services;
using System.Linq;

namespace TestingXamarin.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public int PageSize { get; set; } = 5;
        public Command LoadItemsCommand { get; set; }

        public UsersViewModel()
        {
            Title = "Browse";
            Users = new ObservableCollection<User>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Users.Clear();

                foreach (var user in await DataStore.GetUsers(PageSize))
                {
                    Users.Add(user);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}