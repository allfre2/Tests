using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
    }
}
