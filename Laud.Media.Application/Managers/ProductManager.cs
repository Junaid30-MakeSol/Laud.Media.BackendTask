using AutoMapper;
using Laud.Media.Application.Errors;
using Laud.Media.Application.Interfaces;
using Laud.Media.Application.Models;
using Laud.Media.Application.Models.Product;
using Laud.Media.Domain.Entities.Product;
using Laud.Media.Domain.Interfaces;
using System.Net;

namespace Laud.Media.Application.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public ProductManager(IMapper mapper, IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public List<ProductModel> GetAllProducts()
        {
            var data = _ProductRepository.GetAll();
            var result = _mapper.Map<List<ProductModel>>(data);
            return result;
        }

        public ProductModel GetProductById(int id)
        {
            var data = _ProductRepository.GetById(id);
            if (data == null) throw new CustomApiException("Product id does not exist", HttpStatusCode.NotFound);
            var result = _mapper.Map<ProductModel>(data);
            return result;
        }
        public void Create(ProductModel model)
        {
            var data = _mapper.Map<ProductEntity>(model);
            _ProductRepository.Create(data);
        }

        public ResultModel Update(ProductModel model)
        {
            var dto = _mapper.Map<ProductEntity>(model);
            _ProductRepository.Update(dto);

            var response = new ResultModel
            {
                Data = dto,
                Message = "Product Updated Successfully !"
            };

            return response;
        }

        public void Delete(int id)
        {
            _ProductRepository.Delete(id);
        }


    }
}
