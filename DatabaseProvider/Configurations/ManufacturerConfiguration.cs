using Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProvider.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturer").HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(256);
            builder.Property(a => a.Address).IsRequired().HasMaxLength(256);
        }
    }
}
