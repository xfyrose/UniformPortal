using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkCodeFirst.Model
{
    [Table("Blog2")]
    public class Blog
    {
        public int BlogId { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public int Rating { get; set; }

        public string Digest { get; set; }

        public Author Author { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
