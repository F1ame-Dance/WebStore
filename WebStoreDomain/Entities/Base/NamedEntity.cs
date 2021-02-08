using WebStore.Entities.Base.Interfaces;


namespace WebStoreDomain.Entity.Base
{
    public abstract class NamedEntity :Entity,INamedEnity
    {
        public string Name { get; set; }
    }
}
