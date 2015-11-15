using System.ComponentModel.DataAnnotations;

namespace Util.Core.Validations
{
    public interface IValidationRule
    {
        ValidationResult Validate();
    }
}