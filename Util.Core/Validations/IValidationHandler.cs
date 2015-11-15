namespace Util.Core.Validations
{
    public interface IValidationHandler
    {
        void Handle(ValidationResultCollection results);
    }
}