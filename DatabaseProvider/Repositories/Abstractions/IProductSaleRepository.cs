using Core.Models;

namespace DatabaseProvider.Repositories.Abstractions
{
    internal interface IProductSaleRepository
    {
        public List<ProductSale> GetByProductId(string id);
    }
}
