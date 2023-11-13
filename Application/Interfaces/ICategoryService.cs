using Clean.Application.Dtos;

namespace Clean.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(Guid id);
        Task Create(CategoryDTO entity);
        Task Remove(Guid id);
        Task Update(CategoryDTO entity);
    }
}
