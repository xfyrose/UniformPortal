﻿using System.Linq;

namespace Util.Core.Validations
{
    public class ValidationHandler : IValidationHandler
    {
        public void Handle(ValidationResultCollection results)
        {
            if (results.IsValid)
            {
                return;
            }

            throw new Warning(results.First().ErrorMessage);
        }
    }
}