using Data.Interfaces;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Data.Context
{
    public class FakeRestAPIBookDataSource : IBookDataSource
    {
        public readonly string FakeRestApiUrl = "https://fakerestapi.azurewebsites.net/api/Books";
        protected readonly HttpClient Client;

        public FakeRestAPIBookDataSource()
        {
            Client = new HttpClient();
        }

        public async Task<IEnumerable<Book>> Get()
        {
            var Books = new List<Book>();

            using (var client = new HttpClient()) 
            {
                var result = await Client.GetAsync(FakeRestApiUrl);
                var json = await result.Content.ReadAsStringAsync();
                var response = JArray.Parse(json);
                var books = response.Value<JArray>();

                foreach (var book in books)
                {
                    Books.Add(new Book
                    {
                        ID = book.Value<int>("ID"),
                        Title = book.Value<string>("Title"),
                        Description = book.Value<string>("Description"),
                        PageCount = book.Value<int>("PageCount"),
                        Excerpt = book.Value<string>("Excerpt"),
                        PublishDate = book.Value<DateTime>("PublishDate")
                    });
                }
            }

            return Books;
        }

        public async Task<Book> Get(int id)
        {
            using (var client = new HttpClient())
            {
                var result = await Client.GetAsync($"{FakeRestApiUrl}/{id}");
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var json = await result.Content.ReadAsStringAsync();
                    var book = JObject.Parse(json);

                    return new Book
                    {
                        ID = book.Value<int>("ID"),
                        Title = book.Value<string>("Title"),
                        Description = book.Value<string>("Description"),
                        PageCount = book.Value<int>("PageCount"),
                        Excerpt = book.Value<string>("Excerpt"),
                        PublishDate = book.Value<DateTime>("PublishDate")
                    };
                }
            }

            return null;
        }

        public async Task<Book> Add(Book book)
        {
            using (var client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(book, Formatting.Indented);
                var result = await client
                    .PostAsync(FakeRestApiUrl, 
                               new StringContent(json, Encoding.UTF8, "application/json"));
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    return book;
                }

            }

            return null;
        }

        public async Task<Book> Edit(Book book)
        {
            using (var client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(book, Formatting.Indented);
                var result = await client.PutAsync($"{FakeRestApiUrl}/{book.ID}",
                    new StringContent(json, Encoding.UTF8, "application/json"));
                if(result.StatusCode == HttpStatusCode.OK)
                {
                    return book;
                }
            }

            return null;
        }

        public async Task<bool> Remove(int id)
        {
            using (var client = new HttpClient())
            {
                var result = await client.DeleteAsync($"{FakeRestApiUrl}/{id}");
                Console.WriteLine(await result.Content.ReadAsStringAsync());
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
