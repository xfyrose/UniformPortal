using System.Collections.Generic;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter01
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}