using Microsoft.EntityFrameworkCore;
using FruitMarket.API.Domain.Models;
using System.Collections.Generic;

public class DbInitializer
{
    private readonly ModelBuilder modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void Seed()
    {

        modelBuilder.Entity<Product>().HasData(
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
            );
        modelBuilder.Entity<Bracket>().HasData(
            new Bracket { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
                new Bracket { Id = 101, Name = "Dairy" }
            );
    }
}
