using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base(new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "Store")
                .Options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
