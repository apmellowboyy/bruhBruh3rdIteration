using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace bruhBruh.Models
{
    public class FruitContext : DbContext
    {
        public FruitContext(DbContextOptions<FruitContext> options) : base(options)
        { }
        public DbSet<Fruits> Fruits { get; set; }
        public DbSet<veggies> Veggies { get; set; }
        public DbSet<retailLocation> RetailLocation { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Fruits>().HasData(
            new Fruits
            {
                Id = 1,
                Name = "Apple",
                Color = "Red",
                Size = "Small",
                Value = 2
            },
            new Fruits
            {
                Id = 2,
                Name = "Banana",
                Color = "Yellow",
                Size = "Long",
                Value = 3
            },
            new Fruits
            {
                Id = 3,
                Name = "Mango",
                Color = "Greenish",
                Size = "Medium",
                Value = 2
            }
            );
            modelBuilder.Entity<veggies>().HasData(
new veggies
{
    Id = 1,
    Name = "Celery",
    Weight = 1,
    Size = "Long",
    Value = 2
},
new veggies
{
    Id = 2,
    Name = "Green Pepper",
    Weight=2,
    Size = "Wide",
    Value = 3
},
new veggies
{
    Id = 3,
    Name = "Habanero",
    Weight = 1,
    Size = "Small",
    Value = 2
});
            modelBuilder.Entity<retailLocation>().HasData(
    new retailLocation
    {
        Id = 1,
        Name = "Farmers Market",
        City = "TC",
        FruitsId = 1,
        veggiesId = 1



    });
        }
    }
}
