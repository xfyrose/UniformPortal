namespace Util.Core.Extensions
{
    public static partial class CustomExtensions
    {
        public static string Description(this System.Enum instance)
        {
            return Enum.GetDescription(instance.GetType(), instance);
        }
    }
}