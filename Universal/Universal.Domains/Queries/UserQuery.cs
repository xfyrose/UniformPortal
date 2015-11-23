using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Domains.Repositories;

namespace Universal.Domains.Queries
{
    public class UserQuery : EntityBaseQuery<string>
    {
        [Display(ResourceType = typeof(Universal.Resources.User), Name = nameof(Universal.Resources.User.Id))]
        public string Id { get; set; }

        private string _name;
        [Display(ResourceType = typeof (Universal.Resources.User), Name = nameof(Universal.Resources.User.Name))]
        public string Name
        {
            get
            {
                return _name?.Trim() ?? string.Empty;
            }
            set
            {
                _name = value;
            }
        }

        protected override void AddDescriptions()
        {
            base.AddDescriptions();

            AddDescription(nameof(Id), Id);
            AddDescription(nameof(Name), Name);
        }
    }
}
