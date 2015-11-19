namespace Util.Core.Validations
{
    public interface IValidation
    {
        ValidationResultCollection Validate(object target);
    }
}