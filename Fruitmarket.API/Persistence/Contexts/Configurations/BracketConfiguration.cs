using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FruitMarket.API.Domain.Models;

namespace FruitMarket.API.Persistence.Contexts.Configurations
{
    public class BracketConfiguration : IEntityTypeConfiguration<Bracket>
    {
        public void Configure(EntityTypeBuilder<Bracket> builder)
        {
            builder.ToTable("Brackets");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();//.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.HasMany(p => p.Products).WithOne(p => p.bracket).HasForeignKey(p => p.CategoryId);
        }
    }
}