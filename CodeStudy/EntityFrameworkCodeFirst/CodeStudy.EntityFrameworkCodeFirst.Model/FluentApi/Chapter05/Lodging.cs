using System.ComponentModel.DataAnnotations.Schema;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter05
{
    public class Lodging
    {
        public int LodgingId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        //public bool IsResort { get; set; }

        [ForeignKey("PrimaryContact")]
        public int? PrimaryContactId { get; set; }

        public Person PrimaryContact { get; set; }

        [ForeignKey("SecondaryContact")]
        public int? SecondaryContactId { get; set; }

        public Person SecondaryContact { get; set; }

        //public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}