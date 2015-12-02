using Util.Core.DataAnnotationsTemplates;
using Util.Core.Extensions;

namespace Util.Datas.Queries
{
    public enum OrderDirection
    {
        [DescriptionLocalized(typeof(Util.Resources.OrderDirection), nameof(Util.Resources.OrderDirection.Asc))]
        Asc,

        [DescriptionLocalized(typeof(Util.Resources.OrderDirection), nameof(Util.Resources.OrderDirection.Desc))]
        Desc
    }

    public static class OrderDirectionExtensions
    {
        public static string Description(this OrderDirection? direction)
        {
            return direction == null ? string.Empty : direction.Value.Description();
        }
    }

}