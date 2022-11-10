using AutoMapper;
using Laud.Media.Application.Errors;
using Laud.Media.Application.Interfaces;
using Laud.Media.Application.Models;
using Laud.Media.Application.Models.Currency;
using Laud.Media.Domain.Entities.Currency;
using Laud.Media.Domain.Interfaces;
using System.Net;

namespace Laud.Media.Application.Managers
{
    public class CurrencyManager : ICurrencyManager
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;
        public CurrencyManager(IMapper mapper, ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        public List<CurrencyModel> GetAllCurrencies()
        {
            var data = _currencyRepository.GetAll();
            var result = _mapper.Map<List<CurrencyModel>>(data);
            return result;
        }

        public CurrencyModel GetCurrencyById(int id)
        {
            var data = _currencyRepository.GetById(id);
            if (data == null) throw new CustomApiException("Currency id does not exist", HttpStatusCode.NotFound);
            var result = _mapper.Map<CurrencyModel>(data);
            return result;
        }
        public void Create(CurrencyModel model)
        {
            var data = _mapper.Map<CurrencyEntity>(model);
            _currencyRepository.Create(data);
        }

        public ResultModel Update(CurrencyModel model)
        {
            var data = _currencyRepository.GetByGuid(model.Guid);
            if (data == null) throw new CustomApiException("Currency id does not exist", HttpStatusCode.NotFound);
            data.Code = model.Code;
            data.Name = model.Name;
            data.Status = (int)model.Status;
            var dto = _mapper.Map<CurrencyEntity>(data);
            _currencyRepository.Update(dto);

            var response = new ResultModel
            {
                Data = dto,
                Message = "Category Updated Successfully !"
            };

            return response;
        }

        public void Delete(int id)
        {
            _currencyRepository.Delete(id);
        }


    }
}
