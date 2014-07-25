using System;
using System.Collections.Generic;

namespace Apress.Recipes.WebApi
{
    public static class TypeExtensions
    {
        private static readonly HashSet<Type> Numeric = new HashSet<Type>
        {
            typeof (Decimal),
            typeof (Byte),
            typeof (SByte),
            typeof (short),
            typeof (ushort),
            typeof (Int16), 
            typeof (Int32), 
            typeof (Int64), 
            typeof (Double), 
            typeof (Single), 
        };

        public static bool IsNumericType(this Type t)
        {
            return Numeric.Contains(t);
        }
    }
}