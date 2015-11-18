using System.ComponentModel.DataAnnotations.Schema;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter02
{
    [ComplexType]
    public class PersonalInfo
    {
        public Measurement Weight { get; set; }
        public Measurement Height { get; set; }
        public string DietryRestrictions { get; set; }
    }
}