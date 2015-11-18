using System.ComponentModel.DataAnnotations;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter01
{
    public class AnimalType
    {
        public int Id { get; set; }

        [Required]
        public string TypeName { get; set; }
    }
}