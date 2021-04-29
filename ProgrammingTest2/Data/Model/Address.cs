using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    public class Address
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        [JsonIgnore]
        public virtual Client Client { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string ZipCode { get; set; }
        public override string ToString()
        {
            return AddressLine1 + "\n" + AddressLine2 + "\nZipCode: " + ZipCode;
        }
    }
}
