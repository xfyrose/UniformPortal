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

        [Required(ErrorMessageResourceType = typeof(Universal.Resources.User), ErrorMessageResourceName = nameof(Universal.Resources.User.ValidateNameRequired))]
        [StringLength(Util.Resources.Consts.UserNameLengthMax, ErrorMessageResourceType = typeof(Universal.Resources.User), ErrorMessageResourceName = nameof(Universal.Resources.User.ValidateNameStringLengthMax))]
        public virtual string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Universal.Resources.User), ErrorMessageResourceName = nameof(Universal.Resources.User.ValidatePasswordRequired))]
        public virtual string Password { get; set; }
        public virtual string PasswordFormat { get; set; }
        public virtual string PasswordSalt { get; set; }

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

            AddDescription(nameof(Name), Name);
            AddDescription(nameof(Password), Password);
            AddDescription(nameof(PasswordFormat), PasswordFormat);
            AddDescription(nameof(PasswordSalt), PasswordSalt);
        }
    }
}