using Microsoft.EntityFrameworkCore;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.Infrastructure.Configurations;
using System.Reflection;

namespace MyCloset.Backend.Infrastructure.Contexts
{
    public class MyClosetContext : DbContext
    {
        public MyClosetContext(DbContextOptions<MyClosetContext> options) : base(options)
        {
        }
        public required DbSet<Clothing> Clothes { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            new ClothingConfiguration().Configure(modelBuilder.Entity<Clothing>());
        }

    }
}
