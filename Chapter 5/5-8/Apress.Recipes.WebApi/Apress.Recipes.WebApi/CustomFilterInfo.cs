using System;
using System.Web.Http.Filters;

namespace Apress.Recipes.WebApi
{
    public class CustomFilterInfo : IComparable
    {
        public CustomFilterInfo(IFilter instance, FilterScope scope)
        {
            Instance = instance;
            Scope = scope;
            FilterInfo = new FilterInfo(Instance, Scope);
        }

        public CustomFilterInfo(FilterInfo filterInfo)
        {
            Instance = filterInfo.Instance;
            Scope = filterInfo.Scope;
            FilterInfo = filterInfo;
        }

        public IFilter Instance { get; set; }
        public FilterScope Scope { get; set; }
        public FilterInfo FilterInfo { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is CustomFilterInfo)
            {
                var item = obj as CustomFilterInfo;

                if (item.Instance is OrderedActionFilterAttribute)
                {
                    var itemAttribute = item.Instance as OrderedActionFilterAttribute;
                    var thisAttribute = Instance as OrderedActionFilterAttribute;
                    if (thisAttribute != null) 
                        return thisAttribute.Order.CompareTo(itemAttribute.Order);
                }
            }

            throw new ArgumentException("Object is of wrong type");
        }
    }
}