using System.Collections.Generic;
using Util.Core;
using Util.Core.Validations;

namespace Util.Domains
{
    public abstract class DomainBase : StateDescription, INullObject
    {
        protected DomainBase()
        {
            _rules = new List<IValidationRule>();
            _handler = new ValidationHandler();
        }

        private List<IValidationRule> _rules;
        private IValidationHandler _handler;

        public void SetValidationHandler(IValidationHandler handler)
        {
            if (handler == null)
            {
                return;
            }

            _handler = handler;
        }

        public void AddValidationRule(IValidationRule rule)
        {
            if (rule == null)
            {
                return;
            }

            _rules.Add(rule);
        }

        public virtual void Validate()
        {
            
        }

        private ValidationResultCollection GetValidationResult()
        {
            
        }

        protected virtual void Validate(ValidationResultCollection results)
        {
            
        }
    }
}