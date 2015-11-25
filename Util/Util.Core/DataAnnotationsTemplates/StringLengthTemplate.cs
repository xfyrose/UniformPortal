using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Resources;

namespace Util.Core.DataAnnotationsTemplates
{
    public class StringLengthTemplate : StringLengthAttribute
    {
        //ResourceManager _resourceManager;

        public StringLengthTemplate(int maximumLength) : base(maximumLength)
        {
        }

        public Type ErrorMessageTemplateResourceType { get; set; }
        public string ErrorMessageTemplateResourceName { get; set; }

        //public override string FormatErrorMessage(string name)
        //{
        //    _resourceManager = new ResourceManager(ErrorMessageTemplateResourceType);

        //    this.EnsureLegalLengths();

        //    bool useErrorMessageWithMinimum = this.MinimumLength != 0 && ! CustomErrorMessageSet;

        //    string errorMessage = useErrorMessageWithMinimum ?
        //        DataAnnotationsResources.StringLengthAttribute_ValidationErrorIncludingMinimum : this.ErrorMessageString;

        //    // it's ok to pass in the minLength even for the error message without a {2} param since String.Format will just
        //    // ignore extra arguments
        //    return String.Format(CultureInfo.CurrentCulture, errorMessage, name, this.MaximumLength, this.MinimumLength);
        //}

        //private void EnsureLegalLengths()
        //{
        //    if (this.MaximumLength < 0)
        //    {
        //        throw new InvalidOperationException(DataAnnotationsResources.StringLengthAttribute_InvalidMaxLength);
        //    }

        //    if (this.MaximumLength < this.MinimumLength)
        //    {
        //        throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, DataAnnotationsResources.RangeAttribute_MinGreaterThanMax, this.MaximumLength, this.MinimumLength));
        //    }
        //}
    }
}