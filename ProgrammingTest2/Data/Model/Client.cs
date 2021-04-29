using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }

        public virtual ICollection<Address> Addresses { get; internal set; }


        public int BussinessId { get; set; }
        
        [ForeignKey("BussinessId")]
        [JsonIgnore]
        public virtual Bussiness Bussiness { get; set; }

        public override string ToString()
        {
            return $"{Name} {LastName} ({SSN})";
        }
    }
}
