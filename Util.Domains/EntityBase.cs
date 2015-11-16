namespace Util.Domains
{
    public class EntityBase<TKey> : DomainBase, IEntity<TKey>
    {
        protected EntityBase(TKey id)
        {
            Id = id;
            Log = Logs.Log4.Log.GetContextLog(this);
        }


        public TKey Id { get; }
        public void Init()
        {
            throw new System.NotImplementedException();
        }
    }
}