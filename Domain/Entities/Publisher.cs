using BoardGameApp.Core.Domain.Common;

namespace BoardGameApp.Core.Domain.Entities
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
