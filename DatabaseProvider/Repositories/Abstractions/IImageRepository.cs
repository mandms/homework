using Core.Models;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IImageRepository
    {
        public List<Image> GetByProductId(string id);
    }
}
