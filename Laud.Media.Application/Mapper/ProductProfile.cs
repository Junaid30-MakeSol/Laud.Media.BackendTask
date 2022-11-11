using AutoMapper;
using Laud.Media.Application.Models.Product;
using Laud.Media.Domain.Entities.Product;

namespace Laud.Media.Application.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductModel, ProductEntity>();
            CreateMap<ProductEntity, ProductModel>();

        }
    }
}
