using Laud.Media.Domain.Entities;

namespace Laud.Media.Application.Models.Product
{
    public class ProductModel:BaseAuditableEntity
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
