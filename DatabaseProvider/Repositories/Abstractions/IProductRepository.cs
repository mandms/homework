using Core.Models;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IProductRepository
    {
        public List<Product> GetByCategoryId(int id);
        public List<Product> GetByManufacturerId(int id);
    }
}
