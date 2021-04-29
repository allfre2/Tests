using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class BussinessContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("ProgrammingTest2");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasMany(client => client.Addresses)
                .WithOne(address => address.Client)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bussiness>()
                .HasMany(bussiness => bussiness.Clients)
                .WithOne(client => client.Bussiness)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>()
                .HasMany(client => client.Addresses)
                .WithOne(address => address.Client)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Bussiness> Bussinesses { get; set; }
    }
}
