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

        public static T To<T>(object data)
        {
            if (data == null)
            {
                return default(T);
            }

            if ((data is string) && (string.IsNullOrWhiteSpace(data.ToString())))
            {
                return default(T);
            }

            Type type = Sys.GetType<T>();

            try
            {
                if (type.Name.ToLower() == "guid")
                {
                    return (T) (object) new Guid(data.ToString());
                }

                if (data is IConvertible)
                {
                    return (T) Convert.ChangeType(data, type);
                }

                return (T)data;
            }
            catch
            {
                return default(T);
            }
        }
    }
}