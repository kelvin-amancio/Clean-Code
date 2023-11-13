using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using Clean.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryEF<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var query = await _applicationDbContext.Products.FindAsync(id);
            return query!;
        }

        public async Task<Product> GetProductCategoryAsync(Guid id)
        {
           var query = await _applicationDbContext.Products.Include(x=>x.Category).SingleOrDefaultAsync(x=>x.Id == id);
           return  query!;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

       
    }
}
