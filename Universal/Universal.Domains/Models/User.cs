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
        [StringLength(64, ErrorMessageResourceType = )]
        public string Name { get; set; }

        public string Password { get; set; }
        public string PasswordFormat { get; set; }
        public string PasswordSalt { get; set; }
    }

    public partial class User
    {
        public override void Init()
        {
            base.Init();

            if (InsertedDateTime == null)
            {
                InsertedDateTime = DateTime.Now;
            }
        }

        protected override void AddDescriptions()
        {
            base.AddDescriptions();

            AddDescription(Universal.Resource.User.Name, Name);
            AddDescription(Universal.Resource.User.Password, Password);
            AddDescription(Universal.Resource.User.PasswordFormat, PasswordFormat);
            AddDescription(Universal.Resource.User.PasswordSalt, PasswordSalt);
        }
    }
}