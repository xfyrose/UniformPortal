namespace Util.Core
{
    public static partial class Extensions
    {
        public static string Description(this System.Enum instance)
        {
            return Enum.GetDescription(instance.GetType(), instance);
        }
    }
}