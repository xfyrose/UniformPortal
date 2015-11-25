using System;

namespace Util.Core.Extensions
{
    public static partial class Extensions
    {
        public static string ToMillisecondString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
    }
}