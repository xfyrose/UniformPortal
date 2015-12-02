using System.Collections.Generic;

namespace Util.Core.Extensions
{
    public static partial class CustomExtensions
    {
        public static string Splice<T>(this IEnumerable<T> list, string quote = Util.Resources.Consts.StringQuoteEmpty, string separator = Util.Resources.Consts.StringSeparator)
        {
            return Str.Splice(list, quote, separator);
        }
    }
}