using System;
using System.Collections.Generic;
using System.Text;

namespace TestingXamarin.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }

        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

        public string PictureUrl { get; set; }
        public string ThumbnailUrl { get; set; }

        public string FullName => $"{Title} {FirstName} {LastName}";
        public string FullAddress => $"{Street} {Number}, {City} {State}, PostCode: {PostCode}, {Country}";
    }
}
