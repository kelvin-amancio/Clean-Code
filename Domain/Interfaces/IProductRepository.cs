using Clean.Domain.Entities;

namespace Clean.Domain.Interfaces
{
    public interface IProductRepository : IRepositoryEF<Product>
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task<Product> GetProductCategoryAsync(Guid id);
    }
}
