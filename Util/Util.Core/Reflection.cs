using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Util.Core
{
    public static class Reflection
    {
        public static string GetDescription(Type type, string memberName)
        {
            if (type == null)
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(memberName))
            {
                return string.Empty;
            }

            return GetDescription(type, type.GetField(memberName));
        }


        public static string GetDescription(Type type, FieldInfo field)
        {
            if (type == null)
            {
                return string.Empty;
            }

            if (field == null)
            {
                return string.Empty;
            }

            DescriptionAttribute attribute =
                field.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;

            if (attribute == null)
            {
                return field.Name;
            }

            return attribute.Description;
        }
    }
}