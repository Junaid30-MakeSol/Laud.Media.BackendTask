using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Laud.Media.Application.Errors;
using Laud.Media.Application.Interfaces;
using Laud.Media.Application.Managers;
using Laud.Media.Application.Mapper;
using Laud.Media.Application.Validator;
using Laud.Media.Infrastructure;

namespace Laud.Media.Application
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configure)
        {
            services.AddTransient<ICurrencyManager, CurrencyManager>();
            services.AddAutoMapper(typeof(CurrencyProfile));

            services.AddValidatorsFromAssemblyContaining<CurrencyValidator>();
            services.AddFluentValidationRulesToSwagger();
            services.AddFluentValidationAutoValidation();


            services.Configure<ApiBehaviorOptions>(options =>
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var error = actionContext.ModelState
                        .Where(e => e.Value != null && e.Value.Errors.Count > 0)
                        .SelectMany(e => e.Value?.Errors)
                        .Select(e => e.ErrorMessage).ToArray();
                    var errorresponce = new ApiValidationErrorResponce
                    {
                        Errors = error
                    };
                    return new BadRequestObjectResult(errorresponce);
                }
            );
            services.AddInfrastructureServices(configure);
            return services;
        }
    }

}
