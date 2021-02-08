using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Entities.Base.Interfaces;


namespace WebStoreDomain.Entity.Base
{
    public abstract class Entity : IEntity
    {
       // [Key, DatabaseGenerated(DatabaseGenerated)]
        public int Id { get; set; }
    }
}
