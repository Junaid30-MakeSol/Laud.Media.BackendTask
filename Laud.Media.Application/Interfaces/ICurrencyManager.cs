using Laud.Media.Application.Models;
using Laud.Media.Application.Models.Currency;

namespace Laud.Media.Application.Interfaces
{
    public interface ICurrencyManager
    {
        List<CurrencyModel> GetAllCurrencies();
        CurrencyModel GetCurrencyById(int id);
        void Create(CurrencyModel model);
        ResultModel Update(CurrencyModel model);
        void Delete(int id);
    }
}
