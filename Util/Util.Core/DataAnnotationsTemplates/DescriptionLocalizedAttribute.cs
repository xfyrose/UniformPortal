using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace Util.Core.DataAnnotationsTemplates
{
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter)]
    public class DescriptionLocalizedAttribute : DescriptionAttribute
    {
        readonly ResourceManager _resourceManager;
        readonly string _resourceKey;

        public DescriptionLocalizedAttribute(Type resourceType, string resourceKey)
        {
            _resourceManager = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                //string description = _resourceManager.GetString(_resourceKey, CultureInfo.CurrentCulture);
                string description = _resourceManager.GetString(_resourceKey);
                return string.IsNullOrWhiteSpace(description) ? _resourceKey : description;
            }
        }
    }
}