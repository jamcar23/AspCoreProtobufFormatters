using System;
using System.Reflection;

namespace AspCoreProtobufFormatters.Extensions
{
    internal static class TypeExtensions
    {
        public static T GetPropertyValue<T>(this Type type, string propertyName, object obj = null)
        {
            PropertyInfo info = type.GetProperty(propertyName);

            if (info == null)
                return default;

            return (T)info.GetValue(info.GetGetMethod().IsStatic ? null : obj);
        }
    }
}
