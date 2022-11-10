using FluentValidation;
using Laud.Media.Application.Models.Currency;

namespace Laud.Media.Application.Validator
{
    public class CurrencyValidator : AbstractValidator<CurrencyModel>
    {
        public CurrencyValidator()
        {
            RuleFor(c => c.Code).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Name).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Status).IsInEnum();
        }
    }
}
