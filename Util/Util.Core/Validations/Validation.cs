using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Util.Core.Extensions;

namespace Util.Core.Validations
{
    public class Validation : IValidation
    {
        public ValidationResultCollection Validate(object target)
        {
            target.CheckNull(nameof(target));

            ValidationResultCollection result = new ValidationResultCollection();
            List<ValidationResult> validationResults = new List<ValidationResult>();

            ValidationContext context = new ValidationContext(target, null, null);
            bool isValid = Validator.TryValidateObject(target, context, validationResults, true);
            if (!isValid)
            {
                result.AddResults(validationResults);
            }

            return result;
        }
    }
}