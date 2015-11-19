using System;

namespace Util.Core
{
    public class Conv
    {
        public static string ToString(object data)
        {
            return data?.ToString().Trim() ?? string.Empty;
        }

        public static Guid ToGuid(object data)
        {
            if (data == null)
            {
                return Guid.Empty;
            }

            Guid result;

            return Guid.TryParse(data.ToString(), out result) ? result : Guid.Empty;
        }
    }
}