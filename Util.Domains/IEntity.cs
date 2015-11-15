namespace Util.Domains
{
    public interface IEntity
    {
        void Init();

        void Validate();
    }

    public interface IEntity<out TKey> : IEntity
    {
        TKey Id { get; }
    }
}