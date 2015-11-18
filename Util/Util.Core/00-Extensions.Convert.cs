using System;

namespace Util.Core
{
    public static partial class Extensions
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