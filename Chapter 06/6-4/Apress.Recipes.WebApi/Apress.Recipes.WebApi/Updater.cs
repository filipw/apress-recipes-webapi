using System;
using System.Collections;
using System.Reflection;

namespace Apress.Recipes.WebApi
{
    public static class Updater
    {
        public static void Patch<T>(T obj, string propertyName, object value)
        {
            if (value is Int64)
                value = Convert.ToInt32(value);

            var propertyInfo = obj.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null)
                throw new ArgumentException("Property cannot be updated.");

            if (!propertyInfo.CanRead || (typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType) && propertyInfo.PropertyType != typeof(string)))
                throw new ArgumentException("Property cannot be updated.");

            SetValue(obj, value, propertyInfo);
        }

        private static void SetValue(object o, object value, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType.IsEnum)
            {
                propertyInfo.SetValue(o, Convert.ToInt32(value));
            }
            else if (propertyInfo.PropertyType.IsNumericType())
            {
                propertyInfo.SetValue(o, Convert.ChangeType(value, propertyInfo.PropertyType));
            }
            else if (propertyInfo.PropertyType == typeof(Guid) || propertyInfo.PropertyType == typeof(Guid?))
            {
                Guid g;
                if (Guid.TryParse((string)value, out g))
                {
                    propertyInfo.SetValue(o, g);
                }
                else
                {
                    throw new InvalidOperationException("Cannot use non Guid value on a Guid property!");
                }
            }
            else
            {
                propertyInfo.SetValue(o, value);
            }
        }
    }
}