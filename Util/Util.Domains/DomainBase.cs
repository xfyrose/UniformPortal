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
            _handler = new ValidationResultHandler();
        }

        private readonly List<IValidationRule> _rules;
        private IValidationResultHandler _handler;

        public void SetValidationResultHandler(IValidationResultHandler handler)
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
            ValidationResultCollection result = GetValidationResult();

            HandleVlidationResult(result);
        }

        private ValidationResultCollection GetValidationResult()
        {
            ValidationResultCollection result = ValidationFactory.Create().Validate(this);
            Validate(result);
            _rules.ForEach(rule => result.Add(rule.Validate()));

            return result;
        }

        protected virtual void Validate(ValidationResultCollection results)
        {
            
        }

        private void HandleVlidationResult(ValidationResultCollection results)
        {
            if (results.IsValid)
            {
                return;
            }

            _handler.Handle(results);
        }

        public virtual bool IsNull()
        {
            return false;
        }
    }
}