using Clean.Application.Interfaces;
using Clean.Application.Mappings;
using Clean.Application.Services;
using Clean.Domain.Account;
using Clean.Domain.Interfaces;
using Clean.Infrastructure.Context;
using Clean.Infrastructure.Identity;
using Clean.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(
               configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            ));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opt => opt.AccessDeniedPath = "/Account/Login");

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped(typeof(IRepositoryEF<>), typeof(RepositoryEF<>));
            services.AddScoped<IAuthenticate,AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitialService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddMemoryCache();

            return services;
        }
    }
}
