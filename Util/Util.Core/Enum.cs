using System;

namespace Util.Core
{
    public static class Enum
    {
        public static string GetName(Type type, object member)

        {
            if (type == null)
            {
                return string.Empty;
            }

            if (member == null)
            {
                return string.Empty;
            }

            if (member is string)
            {
                return member.ToString();
            }

            if (type.IsEnum == false)
            {
                return string.Empty;
            }

            return System.Enum.GetName(type, member);
        }


        public static string GetDescription(Type type, object member)
        {
            return Reflection.GetDescription(type, GetName(type, member));
        }
    }
}