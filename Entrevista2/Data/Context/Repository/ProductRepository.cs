using Data.Interfaces;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();
            products.Add(new Product
            {
                Id = 1,
                Description = "aaaaaaa",
                Price = new Decimal(1.00),
                ProductCode = "1"

            });
            products.Add(new Product
            {
                Id = 2,
                Description = "bbbbbbb",
                Price = new Decimal(1.00),
                ProductCode = "2"

            });
            products.Add(new Product
            {
                Id = 3,
                Description = "ccccccc",
                Price = new Decimal(1.00),
                ProductCode = "3"

            });
        }

        public Product Add(Product entity)
        {
            products.Add(entity);
            return entity;
        }

        public Product Get(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public void Remove(Product entity)
        {
            products.Remove(entity);
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
