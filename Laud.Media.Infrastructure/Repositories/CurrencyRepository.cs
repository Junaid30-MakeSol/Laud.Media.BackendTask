using Laud.Media.Domain.Entities.Currency;
using Laud.Media.Domain.Interfaces;
using Laud.Media.Infrastructure.Persistence;

namespace Laud.Media.Infrastructure.Repositories
{
    public class CurrencyRepository : GenericRepository<CurrencyEntity>, ICurrencyRepository
    {
        private readonly ApplicationDbContext _context;
        public CurrencyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public CurrencyEntity GetByGuid(Guid guId)
        {
            return _context.Set<CurrencyEntity>().Where(x => x.Guid == guId).FirstOrDefault();
        }

    }
}
