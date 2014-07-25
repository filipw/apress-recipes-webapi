using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Apress.Recipes.WebApi
{
    public class ReflectionHelpers
    {
        public static MethodInfo GetMethodInfo<T, U>(Expression<Func<T, U>> expression)
        {
            return GetMethodInfoInternal(expression);
        }

        public static MethodInfo GetMethodInfo<T>(Expression<Action<T>> expression)
        {
            return GetMethodInfoInternal(expression);
        }

        private static MethodInfo GetMethodInfoInternal(dynamic expression)
        {
            var method = expression.Body as MethodCallExpression;
            if (method != null)
                return method.Method;

            throw new ArgumentException("Expression is incorrect!");
        }
    }
}