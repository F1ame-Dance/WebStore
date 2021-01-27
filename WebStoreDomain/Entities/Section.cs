using WebStore.Entities.Base.Interfaces;
using WebStoreDomain.Entity.Base;

namespace WebStore.Domain.Entities
{
    public class Section : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int? ParentId { get; set; }
    }

}
