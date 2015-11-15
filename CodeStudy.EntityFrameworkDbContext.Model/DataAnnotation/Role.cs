using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation
{
    public class Role
    {
        public virtual string Id { get; set; }
        public virtual string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
