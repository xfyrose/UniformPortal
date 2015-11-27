namespace Util.Core.Extensions
{
    public static class Nullable
    {
        public static T SafeValue<T>(this T? value)
            where T : struct
        {
            return value ?? default(T);
        }
    }
}