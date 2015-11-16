namespace Util.Core.Validations
{
    public interface IValidationResultHandler
    {
        void Handle(ValidationResultCollection results);
    }
}