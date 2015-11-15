using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;


namespace CodeStudy.EntityFrameworkCodeFirst.Model
{
    public class Destination
    {
        public int DestinationId { get; set; }
        //[Required]
        //[MaxLength(200)]
        public string Name { get; set; }
        public string Country { get; set; }
        //[MaxLength(500)]
        public string Description { get; set; }
        //[Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public virtual List<Lodging> Lodgings { get; set; }
    }
}
