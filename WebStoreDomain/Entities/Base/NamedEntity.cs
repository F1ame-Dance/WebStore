using System.ComponentModel.DataAnnotations;
using WebStore.Entities.Base.Interfaces;


namespace WebStoreDomain.Entity.Base
{
    public abstract class NamedEntity :Entity,INamedEnity
    {
        [Required]
        public string Name { get; set; }
    }
}
