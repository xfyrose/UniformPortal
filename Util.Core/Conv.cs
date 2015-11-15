namespace Util.Core
{
    public class Conv
    {
        public static string ToString(object data)
        {
            return data?.ToString().Trim() ?? string.Empty;
        }
    }
}