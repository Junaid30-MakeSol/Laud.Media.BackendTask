using System.ComponentModel;

namespace Laud.Media.Domain.Domain.Enums
{
    public class EnumEntities
    {
        public enum SortOrder
        {
            [Description("Asc")]
            Asc = 0,

            [Description("Desc")]
            Des = 1,
        }

        public enum GenericStatus
        {
            [Description("Deactivate")]
            Deactivate = 0,
            [Description("Active")]
            Active = 1,

        }

    }
}
