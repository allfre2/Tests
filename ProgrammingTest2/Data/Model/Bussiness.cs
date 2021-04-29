using System.Collections.Generic;

namespace Data.Model
{
    public class Bussiness
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Client> Clients { get; internal set; }

        public override string ToString()
        {
            return $"#{Id}: ({Name})\n===\n{Description}\n===\nPhone: {PhoneNumber}";
        }
    }
}