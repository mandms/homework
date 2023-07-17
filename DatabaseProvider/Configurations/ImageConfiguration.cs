using Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProvider.Configurations
{
    internal class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image").HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(256);
            builder.Property(a => a.Path).IsRequired().HasMaxLength(256);
            builder.Property(a => a.IsMain).IsRequired();
            builder.HasOne(b => b.Product).WithMany(a => a.Images).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
