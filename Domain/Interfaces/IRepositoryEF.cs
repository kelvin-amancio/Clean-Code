
namespace Clean.Domain.Interfaces
{
    public interface IRepositoryEF<T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> Remove(T entity);
        Task<T> Update(T entity);
    }
}
