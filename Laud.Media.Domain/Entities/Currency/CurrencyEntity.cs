using Laud.Media.Domain.Domain.Enums;
namespace Laud.Media.Domain.Entities.Currency
{
    public class CurrencyEntity:BaseAuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public EnumEntities.GenericStatus Status { get; set; }
    }
}
