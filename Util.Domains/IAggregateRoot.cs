namespace Util.Domains
{
    public interface IAggregateRoot : IEntity
    {
        byte[] Version { get; set; }
    }

    public interface IAggregateRoot<out TKey> : IEntity<TKey>, IAggregateRoot
    {
    }
}