using System;

namespace Util.Core.Extensions
{
    public static partial class CustomExtensions
    {
        public static void CheckNull(this object obj, string parameterName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}