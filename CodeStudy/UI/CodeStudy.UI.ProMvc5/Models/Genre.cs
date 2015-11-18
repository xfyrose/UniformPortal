using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeStudy.UI.ProMvc5.Models
{
    public class Genre
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}