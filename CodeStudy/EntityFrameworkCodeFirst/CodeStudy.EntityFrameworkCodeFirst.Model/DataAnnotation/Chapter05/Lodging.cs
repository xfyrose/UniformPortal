using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter05
{
    public class Lodging
    {
        [Column("LodId")]
        public int LodgingId { get; set; }

        [Required, Column("LodName")]
        public string Name { get; set; }

        public string Owner { get; set; }
        public decimal MilesFromNearestAirport { get; set; }
        //public bool IsResort { get; set; }

        [Column("destination_id")]
        public int DestinationId { get; set; }

        public Destination Destination { get; set; }
    }
}