using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeStudy.Misc.ValidationContexts
{
    //public class ValidateMe : IValidatableObject
    //{
    //    [Required]
    //    public bool Enable { get; set; }

    //    [Range(3, 5)]
    //    public int Prop1 { get; set; }

    //    [Range(1, 5)]
    //    public int Prop2 { get; set; }

    //    [MaxLength(10)]
    //    public string MeName { get; set; }

    //    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    //    {
    //        List<ValidationResult> results = new List<ValidationResult>();

    //        if (this.Enable)
    //        {
    //            Validator.TryValidateProperty(
    //                this.Prop1,
    //                new ValidationContext(this, null, null) { MemberName = "Prop1" }, 
    //                results);

    //            Validator.TryValidateProperty(
    //                this.Prop2,
    //                new ValidationContext(this, null, null) { MemberName = "Prop2" },
    //                results);

    //            // some other random test
    //            if (this.Prop1 <= this.Prop2)
    //            {
    //                results.Add(new ValidationResult("Prop1 must be larger than Prop2"));
    //            }
    //            // some other random test
    //            if (this.Prop1 >= 0)
    //            {
    //                results.Add(new ValidationResult("Prop1 must be less than 0"));
    //            }
    //        }

    //        return results;
    //    }
    //}

    public partial class ValidateMe
    {
        public bool Enable { get; set; }

        public int Prop1 { get; set; }

        public int Prop2 { get; set; }

        public string MeName { get; set; }
    }

    [MetadataType(typeof(ValidateMeMetaData))]
    public partial class ValidateMe : IValidatableObject
    {
        public ValidateMe()
        {
            TypeDescriptor.AddProviderTransparent(
                new AssociatedMetadataTypeTypeDescriptionProvider(typeof(ValidateMe), typeof(ValidateMeMetaData)),
                typeof(ValidateMe));
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (this.Enable)
            {
                Validator.TryValidateProperty(
                    this.Prop1,
                    new ValidationContext(this, null, null) { MemberName = "Prop1" },
                    results);

                Validator.TryValidateProperty(
                    this.Prop2,
                    new ValidationContext(this, null, null) { MemberName = "Prop2" },
                    results);

                // some other random test
                if (this.Prop1 <= this.Prop2)
                {
                    results.Add(new ValidationResult("Prop1 must be larger than Prop2"));
                }
                // some other random test
                if (this.Prop1 >= 0)
                {
                    results.Add(new ValidationResult("Prop1 must be less than 0"));
                }
            }

            return results;
        }
    }

    public class ValidateMeMetaData
    {
        [Required]
        public bool Enable { get; set; }

        [Range(3, 5)]
        public int Prop1 { get; set; }

        [ScaffoldColumn(false)]
        [Range(1, 5)]
        public int Prop2 { get; set; }

        [MaxLength(10)]
        public string MeName { get; set; }
    }

    [MetadataType(typeof(ValidateMeMetaData))]
    public class ValidateMeDto
    {
        public ValidateMeDto()
        {
            //TypeDescriptor.AddProviderTransparent(
            //    new AssociatedMetadataTypeTypeDescriptionProvider(typeof(ValidateMeDto), typeof(ValidateMeMetaData)),
            //    typeof(ValidateMeDto));
        }

        public bool Enable { get; set; }
        public int Prop1 { get; set; }
        //public string Prop2 { get; set; }

        public string MeName { get; set; }

        [Range(1, 5)]
        public int AnotherProp1 { get; set; }
    }
}