using Clean.Domain.Entities;

namespace Clean.Domain.Interfaces
{
    public interface ICategoryRepository : IRepositoryEF<Category>
    {
      Task<IEnumerable<Category>> GetCategories();
      Task<Category> GetById(Guid id);
    }
}
