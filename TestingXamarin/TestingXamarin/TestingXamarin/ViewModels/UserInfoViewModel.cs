using System;

using TestingXamarin.Models;

namespace TestingXamarin.ViewModels
{
    public class UserInfoViewModel : BaseViewModel
    {
        public User User { get; set; }
        public UserInfoViewModel(User user = null)
        {
            Title = user?.FullName;
            User = user;
        }
    }
}
