using Data.Model;
using System;
using System.Collections.Generic;

namespace Data.Context
{
    public class SeedData
    {
        public static readonly Random random = new Random();

        internal static IEnumerable<Bussiness> GenerateBussinesses(int count = 5)
        {
            var bussinesses = new List<Bussiness>();

            for (int i = 0; i < count; ++i)
            {
                bussinesses.Add(new Bussiness
                {
                    Name = RandomStr(min: 5, max: 10).ToUpper(),
                    Description = RandomStr(min: 25, max: 50, spaces: true),
                    PhoneNumber = RandomStr(min: 10, max: 10, spaces: false, charset: "0123456789")
                });
            }

            return bussinesses;
        }

        internal static IEnumerable<Client> GenerateClients(IEnumerable<Bussiness> bussinesses, int count = 5)
        {
            var names = new List<string>
            {
                "Alan", "Alfredo", "David", "Sunil", "Leonardo", "Alcy", "Juan Carlos", "Ennio",
                "Alberto", "Guillermo", "Charlie", "Quentin", "Butch", "Elvis", "Larry", "Mikhail"
            };

            var lastNames = new List<string>
            {
                "Turing", "Richter", "Part", "Sibelius", "Morricone", "Gosling", "Von Doom", "Luzón",
                "Perreira", "Vazquez", "Asuncion", "Velazquez", "Smith", "Norris", "Rotzank", "Kitchen", "Vivaldi"
            };

            var clients = new List<Client>();

            foreach (var bussiness in bussinesses)
            {
                int n = random.Next(0, count);

                for (int i = 0; i < n; ++i)
                {
                    clients.Add(new Client
                    {
                        BussinessId = bussiness.Id,
                        Name = names[random.Next(0, names.Count)],
                        LastName = lastNames[random.Next(0, lastNames.Count)],
                        SSN = RandomStr(min: 11, max: 11, spaces: false, charset: "0123456789")
                    });
                }
            }

            return clients;
        }

        internal static IEnumerable<Address> GenerateAddresses(IEnumerable<Client> clients, int count = 4)
        {
            var addresses = new List<Address>();

            foreach(var client in clients)
            {
                int n = random.Next(1, count);
                for (int i = 0; i < n; ++i)
                {
                    addresses.Add(new Address
                    { 
                        ClientId = client.Id,
                        AddressLine1 = RandomStr(min: 20, max: 30, spaces: true),
                        ZipCode = RandomStr(charset: "0123456789")
                    });
                }
            }

            return addresses;
        }

        static string RandomStr(int min = 5, int max = 5, bool spaces = false, string 
            charset = "asdffghjklqwertyuiopzxcvbnm0123456789")
        {
            if (spaces) charset += "           ";
            string result = "";
            for (int i = 0; i <= min && i < max; ++i)
            {
                char x = charset[random.Next(0, charset.Length)];
                result += x;
            }

            return result;
        }
        // Random
        /*
        public static IEnumerable<Contact> GetPermissions(int min = 5, int max = 10)
        {


            var domains = new List<string>
            {
                "recursive.io", "harmony.com", "exhausted.com.do", "playtime.ai", "smothered.com"
            };

            return Enumerable.Range(1, random.Next(min, max) + 1)
                .Select(id =>
                {
                    var contact = new Contact
                    {
                        Name = names[random.Next(0, names.Count)],
                        LastName = lastNames[random.Next(0, lastNames.Count)]
                    };

                    contact.Email = $"{contact.Name[0] + contact.LastName}@{domains[random.Next(0, domains.Count)]}";

                    return contact;
                });
        }
        */
    }
}
