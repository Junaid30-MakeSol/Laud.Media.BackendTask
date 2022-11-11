namespace Laud.Media.Domain.Entities.Product
{
    public class ProductEntity:BaseAuditableEntity
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
