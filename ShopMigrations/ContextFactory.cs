using DatabaseProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShopMigrations
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            string connectionString =
                "Data Source=.\\SQLEXPRESS;Initial Catalog=Shop;Pooling=true;Integrated Security=SSPI;TrustServerCertificate=True";
            var optionalBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            optionalBuilder.UseSqlServer(connectionString,
                assembly => assembly.MigrationsAssembly("ShopMigrations"));

            return new ApplicationContext(optionalBuilder.Options);
        }
    }
}