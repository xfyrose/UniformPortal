using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation
{
    public class User
    {
        public virtual string Id { get; set; }
        public virtual string UserName { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
