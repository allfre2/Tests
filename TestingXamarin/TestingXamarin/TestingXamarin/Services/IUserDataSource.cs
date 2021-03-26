using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestingXamarin.Models;

namespace TestingXamarin.Services
{
    public interface IUserDataSource
    {
        string EndPoint { get; }
        Task<ICollection<User>> GetUsers(int n = 1);
    }
}
