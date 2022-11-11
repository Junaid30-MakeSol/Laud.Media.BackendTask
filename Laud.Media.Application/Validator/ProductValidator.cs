using FluentValidation;
using Laud.Media.Application.Models.Product;

namespace Laud.Media.Application.Validator
{
    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Number).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Name).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Status).NotEmpty().NotNull();
            RuleFor(c => c.Price).NotEmpty().NotNull();
        }
    }
}
