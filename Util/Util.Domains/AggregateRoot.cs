using System;

namespace Util.Domains
{
    public abstract class AggregateRoot<TKey> : EntityBase<TKey>, IAggregateRoot<TKey>
    {
        protected AggregateRoot(TKey id)
            : base(id)
        {
        }

        public byte[] Version { get; set; }
    }

    public abstract class AggregateRoot : AggregateRoot<Guid>
    {
        protected AggregateRoot(Guid id)
            : base(id)
        {
        }
    }
}