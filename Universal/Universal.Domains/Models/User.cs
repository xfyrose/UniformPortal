using System;
using Util.Domains;

namespace Universal.Domains.Models
{
    public class User : AggregateRoot
    {
        public User(Guid id)
            : base(id)
        {
            
        }

        public User()
            : this(Guid.Empty)
        {
            
        }
    }
}