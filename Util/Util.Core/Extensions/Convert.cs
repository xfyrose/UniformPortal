using System;

namespace Util.Core.Extensions
{
    public static partial class CustomExtensions
    {
        public static string ToStr(this object obj)
        {
            return Conv.ToString(obj);
        }

        public static Guid ToGuid(this string obj)
        {
            return Conv.ToGuid(obj);
        }
    }
}