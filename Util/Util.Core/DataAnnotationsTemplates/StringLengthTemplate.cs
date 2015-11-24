using System;
using System.ComponentModel.DataAnnotations;

namespace Util.Core.DataAnnotationsTemplates
{
    public class StringLengthTemplate : StringLengthAttribute
    {
        public StringLengthTemplate(int maximumLength) : base(maximumLength)
        {
        }

        public Type ErrorMessageTemplateResourceType { get; set; }
        public string ErrorMessageTemplateResourceName { get; set; }

        public override string FormatErrorMessage(string name)
        {
            return string.Empty;
        }
    }
}