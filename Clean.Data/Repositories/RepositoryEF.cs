using Clean.Domain.Interfaces;
using Clean.Infrastructure.Context;

namespace Clean.Infrastructure.Repositories
{
    public class RepositoryEF<T> : IRepositoryEF<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RepositoryEF(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<T> Create(T entity)
        {
            _applicationDbContext.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Remove(T entity)
        {
            _applicationDbContext.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _applicationDbContext.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
