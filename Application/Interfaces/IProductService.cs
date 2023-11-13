using Clean.Application.Dtos;

namespace Clean.Application.Interfaces
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(Guid id);
        Task<ProductDTO> GetProductCategory(Guid id);
        Task Create(ProductDTO entity);
        Task Remove(Guid id);
        Task Update(ProductDTO entity);
    }
}
