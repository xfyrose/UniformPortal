using System;
using System.ComponentModel.DataAnnotations;
using Util.Domains;

namespace Universal.Domains.Models
{
    public partial class User : AggregateRoot<string>
    {
        public User(string id)
            : base(id)
        {
        }

        public User()
            : this(string.Empty)
        {
        }

        [Required()]
        [StringLength(32, )]
        public string Name { get; set; }

        public string Password { get; set; }
        public string PasswordFormat { get; set; }
        public string PasswordSalt { get; set; }
    }

    public partial class User
    {
        
    }
}