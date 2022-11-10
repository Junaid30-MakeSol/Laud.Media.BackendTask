using Laud.Media.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Laud.Media.Infrastructure.Persistence;
using Laud.Media.Infrastructure.Persistence.Interceptors;
using Laud.Media.Infrastructure.Repositories;

namespace Laud.Media.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();

            services.AddTransient<IGenericRepository<ApplicationDbContext>, GenericRepository<ApplicationDbContext>>();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }

    }
}
