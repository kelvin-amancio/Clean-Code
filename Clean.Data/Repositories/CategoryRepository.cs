using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using Clean.Infrastructure.Context;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Clean.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryEF<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        private readonly string defaultConnection;
        public CategoryRepository(ApplicationDbContext applicationDbContext, IConfiguration configuration) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
            defaultConnection = _configuration!.GetConnectionString("DefaultConnection")!;
        }

        public async Task<Category> GetById(Guid id)
        {
            var query = await _applicationDbContext.Categories.FindAsync(id);
            return query!;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            using var cn = new SqlConnection(defaultConnection);
            var query = await cn.QueryAsync<Category>("SELECT * FROM Categories");
            return query;
        }

    }
}
