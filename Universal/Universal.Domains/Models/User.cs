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

        [Required(ErrorMessageResourceType = typeof(Util.Resources.Validate), ErrorMessageResourceName = "Required")]
        [StringLength(64, ErrorMessageResourceType = typeof(Util.Resources.Validate), ErrorMessageResourceName = "StringLengthMax")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Util.Resources.Validate), ErrorMessageResourceName = "Required")]
        public string Password { get; set; }
        public string PasswordFormat { get; set; }
        public string PasswordSalt { get; set; }

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