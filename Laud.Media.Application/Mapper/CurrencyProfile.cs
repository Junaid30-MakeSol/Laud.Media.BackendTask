using AutoMapper;
using Laud.Media.Application.Models.Currency;
using Laud.Media.Domain.Enums;
using Laud.Media.Domain.Entities.Currency;

namespace Laud.Media.Application.Mapper
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<CurrencyModel, CurrencyEntity>();
            CreateMap<CurrencyEntity, CurrencyModel>()
                 .ForMember(dst => dst.Status, opt =>
                        opt.MapFrom(src => EnumHelper.GetDescription((EnumEntities.GenericStatus)System.Enum.ToObject(typeof(EnumEntities.GenericStatus),
                        Convert.ToInt32(src.Status)))));
        }
    }
}
