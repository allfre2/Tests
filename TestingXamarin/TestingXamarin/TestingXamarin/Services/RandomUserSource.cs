using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestingXamarin.Models;

namespace TestingXamarin.Services
{
    public class RandomUserSource : IUserDataSource
    {
        private const string Url = "https://randomuser.me/api";

        public string EndPoint { get; protected set; } = $"{Url}";

        public async Task<ICollection<User>> GetUsers(int n = 1)
        {
            var users = new List<User>();

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync($"{Url}?results={n}");
                var json = await result.Content.ReadAsStringAsync();
                var response = JObject.Parse(json);
                var results = response.Value<JArray>("results");

                foreach (var user in results)
                {
                    users.Add(new User
                    {
                        Gender = user.Value<string>("gender"),
                        Title = user["name"].Value<string>("title"),
                        FirstName = user["name"].Value<string>("first"),
                        LastName = user["name"].Value<string>("last"),

                        Street = user["location"]["street"].Value<string>("name"),
                        Number = user["location"]["street"].Value<string>("number"),
                        City = user["location"].Value<string>("city"),
                        State = user["location"].Value<string>("state"),
                        Country = user["location"].Value<string>("country"),
                        PostCode = user["location"].Value<string>("postcode"),

                        Email = user.Value<string>("email"),
                        Phone = user.Value<string>("phone"),
                        Cell = user.Value<string>("cell"),
                        Username = user["login"].Value<string>("username"),

                        PictureUrl = user["picture"].Value<string>("large"),
                        ThumbnailUrl = user["picture"].Value<string>("medium"),
                    });
                }
            }

            return users;
        }
    }
}
