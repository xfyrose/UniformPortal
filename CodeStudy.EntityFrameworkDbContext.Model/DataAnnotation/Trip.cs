using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation
{
    public class Trip : IValidatableObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Identifier { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public decimal CostUsd { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public List<Activity> Activities { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate.Date >= EndDate.Date)
            {
                yield return new ValidationResult("Start Date must be earlier than End Date", new[] {"StartDate", "EndDate"});
            }

            List<string> unwantedWords = new List<string>
            {
                "sad",
                "worry",
                "freezing",
                "cold"
            };

            IEnumerable<string> badwords = unwantedWords.Where(word => Description.Contains(word));
            IEnumerable<string> enumerable = badwords as string[] ?? badwords.ToArray();
            if (enumerable.Any())
            {
                yield return
                    new ValidationResult("Description has bad words:" + string.Join(";", enumerable),
                        new[] {"Description"});
            }
        }
    }
}
