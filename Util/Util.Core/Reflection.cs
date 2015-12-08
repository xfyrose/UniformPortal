using System;
using System.Collections.Generic;
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

            DescriptionAttribute attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;

            if (attribute == null)
            {
                return field.Name;
            }

            return attribute.Description;
        }

        public static T CreateInstance<T>(string className, params object[] parameters)
        {
            Type type = Type.GetType(className) ?? Assembly.GetCallingAssembly().GetType(className);
            return CreateInstance<T>(type, parameters);
        }

        public static T CreateInstance<T>(Type type, params object[] parameters)
        {
            return Conv.To<T>(Activator.CreateInstance(type, parameters));
        }

        public static List<T> GetByInterface<T>(Assembly assembly)
        {
            Type typeInterface = typeof(T);

            return assembly.GetTypes()
                .Where(t => (typeInterface.IsAssignableFrom(t)) && (!t.IsInterface) && (!t.IsAbstract))
                .Select(t => CreateInstance<T>(t))
                .ToList();
        }
    }
}