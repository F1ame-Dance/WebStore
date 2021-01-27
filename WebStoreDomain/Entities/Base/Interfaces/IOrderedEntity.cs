namespace WebStore.Entities.Base.Interfaces
{
    public interface IOrderedEntity : IEntity
    {
        int Order { get; set; }
    }
}
