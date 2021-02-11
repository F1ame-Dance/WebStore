using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Entities.Base.Interfaces;
using WebStoreDomain.Entity.Base;

namespace WebStore.Domain.Entities
{
    public class Section : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Section Parent { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }

}
