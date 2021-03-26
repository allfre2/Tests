using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestingXamarin.Models;

namespace TestingXamarin.Services
{
    public class JSONPlaceHolderUserSource : IUserDataSource
    {
        private static string Url = "https://jsonplaceholder.typicode.com/users";

        public string EndPoint { get; protected set; } = $"{Url}";

        public async Task<ICollection<User>> GetUsers(int n = 1)
        {
            var users = new List<User>();

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync($"{Url}");
                var json = await result.Content.ReadAsStringAsync();
                var results = JArray.Parse(json);

                foreach (var user in results)
                {
                    users.Add(new User
                    {
                        FirstName = user.Value<string>("name"),
                        LastName = user.Value<string>("name"),
                        Username = user.Value<string>("username"),
                        Email = user.Value<string>("email"),

                        Street = user["address"].Value<string>("street"),
                        Number = user["address"].Value<string>("suite"),
                        City = user["address"].Value<string>("city"),
                        PostCode = user["address"].Value<string>("zipcode"),

                        Phone = user.Value<string>("phone"),
                    });
                }
            }

            return users;
        }
    }
}
