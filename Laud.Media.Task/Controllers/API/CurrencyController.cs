using FluentValidation;
using Laud.Media.Application.Errors;
using Laud.Media.Application.Interfaces;
using Laud.Media.Application.Models;
using Laud.Media.Application.Models.Currency;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace PIMS.WEB.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiValidationErrorResponce))]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyManager _currencyManager;
        private IValidator<CurrencyModel> _validator;
        public CurrencyController(ICurrencyManager currencyManager, IValidator<CurrencyModel> validator)
        {
            _currencyManager = currencyManager;
            _validator = validator;
        }

        [Route("list")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CurrencyModel>))]
        [Description("Get all currencies")]
        public IActionResult GetAllCurrencies()
        {
            var result = _currencyManager.GetAllCurrencies();
            return Ok(result);
        }

        [Route("{id}"), HttpGet, ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrencyModel)),
         ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiException))]
        [Description("Get currency by id")]
        public IActionResult GetCurrencyById(int id)
        {
            var result = _currencyManager.GetCurrencyById(id);
            return Ok(result);
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrencyModel))]
        [Description("Create a new currency")]
        public IActionResult Create(CurrencyModel model)
        {

            _currencyManager.Create(model);
            return Ok(new { Data = "Currency Added Successfully!" });
        }

        [Route("update/{guid}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultModel))]
        [Description("Update currency by guid")]
        public IActionResult Update(CurrencyModel model, Guid guid)
        {
            model.Guid = guid;
            var result = _currencyManager.Update(model);
            return Ok(result);
        }

        [Route("delete/{id}")]
        [HttpGet]
        [Description("Delete currency by id")]
        public IActionResult Delete(int id)
        {
            _currencyManager.Delete(id);
            return Ok(new { Data = "Currency deleted!" });
        }
    }
}
