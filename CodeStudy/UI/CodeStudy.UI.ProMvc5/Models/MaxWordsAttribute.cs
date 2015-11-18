using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeStudy.UI.ProMvc5.Models
{
    public class MaxWordsAttribute : ValidationAttribute, IClientValidatable
    {
        public int WordCount;

        public MaxWordsAttribute(int wordCount)
            : base("{0} has too many words.")
        {
            WordCount = wordCount;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length > WordCount)
                {
                    string errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule();

            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("wordcount", WordCount);
            rule.ValidationType = "maxword";

            yield return rule;
        }
    }
}