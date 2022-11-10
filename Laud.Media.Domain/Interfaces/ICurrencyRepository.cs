using Laud.Media.Domain.Entities.Currency;

namespace Laud.Media.Domain.Interfaces
{
    public interface ICurrencyRepository : IGenericRepository<CurrencyEntity>
    {
        CurrencyEntity GetByGuid(Guid guId);
    }
}
