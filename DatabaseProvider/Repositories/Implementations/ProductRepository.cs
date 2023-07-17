using Core.Models;
using DatabaseProvider.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProvider.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public List<Product> GetByCategoryId(int id)
        {
            return Entities.Include(b => b.Category).Where(b => b.CategoryId == id).ToList();
        }

        public List<Product> GetByManufacturerId(int id)
        {
            return Entities.Include(b => b.Manufacturer).Where(b => b.ManufacturerId == id).ToList();
        }
    }
}
