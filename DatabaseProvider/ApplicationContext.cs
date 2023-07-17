using DatabaseProvider.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProvider
{
    public class ApplicationContext : DbContext
    {
        private readonly string ?_connectionString;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public ApplicationContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSaleConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString == null)
            {
                return;
            }
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
