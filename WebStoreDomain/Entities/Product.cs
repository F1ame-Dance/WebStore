using WebStore.Entities.Base.Interfaces;
using WebStoreDomain.Entity.Base;

namespace WebStore.Domain.Entities
{
    public class Product :NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int SectionId { get; set; }
        public int? BrandId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

    }
}
