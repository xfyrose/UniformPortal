using System.Linq;
using Util.Lambdas.Dynamics;

namespace Util.Core.Extensions
{
    public static partial class Query
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderByDynamic(propertyName);
        }
    }
}