using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Context
{
    public class PermissionsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("ProgrammingTest0");
        }

        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionType> PermissionTypes { get; set; }
    }
}
