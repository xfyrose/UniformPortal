using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation
{
    public class Lodging : IObjectWithState
    {
        public virtual int LodgingId { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(10)]
        public virtual string Name { get; set; }
        public virtual string Owner { get; set; }
        public virtual decimal MilesFromNearestAirport { get; set; }

        [Column("destination_id")]
        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; }

        public virtual ICollection<InternetSpecial> InternetSpecials { get; set; }

        public virtual int? PrimaryContactId { get; set; }
        [InverseProperty("PrimaryContactFor")]
        [ForeignKey("PrimaryContactId")]
        public virtual Person PrimaryContact { get; set; }

        public virtual int? SecondaryContactId { get; set; }
        [InverseProperty("SecondaryContactFor")]
        [ForeignKey("SecondaryContactId")]
        public virtual Person SecondaryContact { get; set; }

        [NotMapped]
        public State State { get; set; }

        public List<string> ModifiedProperties { get; set; }
    }
}
