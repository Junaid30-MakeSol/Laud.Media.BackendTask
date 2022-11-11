using FluentValidation;
using Laud.Media.Application.Errors;
using Laud.Media.Application.Interfaces;
using Laud.Media.Application.Models;
using Laud.Media.Application.Models.Product;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace PIMS.WEB.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiValidationErrorResponce))]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _ProductManager;
        private IValidator<ProductModel> _validator;
        public ProductController(IProductManager ProductManager, IValidator<ProductModel> validator)
        {
            _ProductManager = ProductManager;
            _validator = validator;
        }

        [Route("list")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductModel>))]
        [Description("Get all products")]
        public IActionResult GetAllCurrencies()
        {
            var result = _ProductManager.GetAllProducts();
            return Ok(result);
        }

        [Route("{id}"), HttpGet, ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductModel)),
         ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiException))]
        [Description("Get Product by id")]
        public IActionResult GetProductById(int id)
        {
            var result = _ProductManager.GetProductById(id);
            return Ok(result);
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductModel))]
        [Description("Create a new Product")]
        public IActionResult Create(ProductModel model)
        {

            _ProductManager.Create(model);
            return Ok(new { Data = "Product Added Successfully!" });
        }

        [Route("update")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultModel))]
        [Description("Update Product")]
        public IActionResult Update(ProductModel model)
        {
            var result = _ProductManager.Update(model);
            return Ok(result);
        }

        [Route("delete/{id}")]
        [HttpGet]
        [Description("Delete Product by id")]
        public IActionResult Delete(int id)
        {
            _ProductManager.Delete(id);
            return Ok(new { Data = "Product deleted!" });
        }
    }
}
