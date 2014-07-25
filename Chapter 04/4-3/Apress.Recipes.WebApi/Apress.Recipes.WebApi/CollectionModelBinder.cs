using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace Apress.Recipes.WebApi
{
    public class CollectionModelBinder<T> : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var key = bindingContext.ModelName;
            var val = bindingContext.ValueProvider.GetValue(key);
            if (val != null)
            {
                var s = val.AttemptedValue;
                try
                {
                    T[] result;
                    if (s != null && s.IndexOf(",", StringComparison.Ordinal) > 0)
                    {
                        result = s.Split(new[] { "," }, StringSplitOptions.None)
                            .Select(x => (T)Convert.ChangeType(x, typeof(T)))
                            .ToArray();
                    }
                    else
                    {
                        result = new[] { (T)Convert.ChangeType(s, typeof(T)) };
                    }

                    bindingContext.Model = result;
                    return true;
                }
                catch (InvalidCastException)
                {
                    return false;
                }
            }
            return false;
        }
    }
}