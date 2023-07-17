using Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProvider.Configurations
{
    public class ProductSaleConfiguration : IEntityTypeConfiguration<ProductSale>
    {
        public void Configure(EntityTypeBuilder<ProductSale> builder)
        {
            builder.ToTable("ProductSale").HasKey(a => a.Id);
            builder.Property(a => a.Count).IsRequired();
            builder.Property(a => a.DateTime).IsRequired();
            builder.HasOne(b => b.Product).WithMany(a => a.ProductSales).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
