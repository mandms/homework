using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseProvider.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product").HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(256);
            builder.Property(a => a.Price).IsRequired().HasPrecision(10, 2);
            builder.Property(a => a.Description).IsRequired();
            builder.HasOne(b => b.Manufacturer).WithMany(a => a.Products).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(b => b.Category).WithMany(a => a.Products).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
