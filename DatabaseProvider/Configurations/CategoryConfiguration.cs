using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace DatabaseProvider.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category").HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(256);
            builder.Property(a => a.Description).IsRequired();
        }
    }
}
