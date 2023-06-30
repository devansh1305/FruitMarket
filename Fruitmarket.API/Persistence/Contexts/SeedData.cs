using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FruitMarket.API.Domain.Models;


namespace FruitMarket.API.Persistence.Contexts
{
    public static class SeedData
    {
        public static async Task Seed(AppDbContext context)
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 100,
                    Name = "Apple",
                    QuantityInPackage = 1,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 100
                },
                new Product
                {
                    Id = 101,
                    Name = "Milk",
                    QuantityInPackage = 2,
                    UnitOfMeasurement = EUnitOfMeasurement.Liter,
                    CategoryId = 101,
                }
            };

            var brackets = new List<Bracket>
            {
                new Bracket { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
                new Bracket { Id = 101, Name = "Dairy" }
            };

            context.Products.AddRange(products);
            context.Brackets.AddRange(brackets);
            await context.SaveChangesAsync();
        }
    }
}