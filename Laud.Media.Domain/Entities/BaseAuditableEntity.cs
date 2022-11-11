using System.Text.Json.Serialization;

namespace Laud.Media.Domain.Entities
{
    public abstract class BaseAuditableEntity
    {
        //[JsonIgnore]
        public int Id { get; set; }
        //[JsonIgnore]
        public Guid Guid { get; set; }
        [JsonIgnore]
        public DateTime Created { get; set; }
        [JsonIgnore]
        public string? CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime? LastModified { get; set; }
        [JsonIgnore]
        public string? LastModifiedBy { get; set; }
    }
}
