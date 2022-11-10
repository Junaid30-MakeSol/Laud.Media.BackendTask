using Laud.Media.Domain.Entities;
using Laud.Media.Domain.Enums;

namespace Laud.Media.Application.Models.Currency
{
    public class CurrencyModel : BaseAuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public EnumEntities.GenericStatus Status { get; set; }
    }
}
