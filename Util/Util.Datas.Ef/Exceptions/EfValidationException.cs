using System.Data.Entity.Validation;
using System.Linq;

namespace Util.Datas.Ef.Exceptions
{
    public class EfValidationException : DbEntityValidationException
    {
        public EfValidationException(DbEntityValidationException exception)
            : base($"{Util.Resources.Validate.Failure}:", exception)
        {
            SetExceptionDatas(exception);
        }

        private void SetExceptionDatas(DbEntityValidationException exception)
        {
            exception.EntityValidationErrors.ToList().ForEach(errors =>
            {
                errors.ValidationErrors.ToList().ForEach(error =>
                {
                    Data.Add($"{error.PropertyName}{Util.Resources.Validate.PropertyFailure}", error.ErrorMessage);
                });
            });
        }
    }
}