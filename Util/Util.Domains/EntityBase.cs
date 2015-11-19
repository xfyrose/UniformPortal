using Util.Logs.Log4;

namespace Util.Domains
{
    public class EntityBase<TKey> : DomainBase, IEntity<TKey>
    {
        protected EntityBase(TKey id)
        {
            Id = id;
            Log = Log.GetContextLog(this);
        }


        public TKey Id { get; }
        public void Init()
        {
            throw new System.NotImplementedException();
        }
    }
}