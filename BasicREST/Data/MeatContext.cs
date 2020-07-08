using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BasicREST.Models;

namespace BasicREST.Data
{
    public class MeatContext : DbContext
    {
        public MeatContext (DbContextOptions<MeatContext> options)
            : base(options)
        {
        }

        public DbSet<Meat> Meat { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            MeatSeeder.SeedMeat(modelBuilder);
        }
    }
}
