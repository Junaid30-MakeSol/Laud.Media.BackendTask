using Laud.Media.Domain.Entities.Currency;
using Microsoft.EntityFrameworkCore;
using Laud.Media.Infrastructure.Persistence.Interceptors;
using System.Reflection;

namespace Laud.Media.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public DbSet<CurrencyEntity> CurrencyEntity => Set<CurrencyEntity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
