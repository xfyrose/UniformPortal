using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Resources;

namespace Util.Core.Logs
{
    public enum LogLevel
    {
        [Description("致命错误")]
        [Display(ResourceType = typeof(Common), Name = "Fatal")]
        Fatal,

        [Display(ResourceType = typeof(Common), Name = "Error")]
        Error,

        [Display(ResourceType = typeof(Common), Name = "Warning")]
        Warning,

        [Display(ResourceType = typeof(Common), Name = "Information")]
        Information,

        [Display(ResourceType = typeof(Common), Name = "Debug")]
        Debug
    }
}