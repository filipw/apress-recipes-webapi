using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Apress.Recipes.WebApi
{
    public class MappingBasedFilterProvider : IFilterProvider
    {
        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            if (actionDescriptor == null)
            {
                throw new ArgumentNullException("actionDescriptor");
            }

            var actionFilters = actionDescriptor.GetFilters().Select(i => new FilterInfo(i, FilterScope.Action));
            var controllerFilters = actionDescriptor.ControllerDescriptor.GetFilters().Select(i => new FilterInfo(i, FilterScope.Controller));;
            var globalFilters = configuration.Filters.Where(i => i.Scope == FilterScope.Global);

            var result = actionFilters.Concat(controllerFilters).Concat(globalFilters).Distinct().ToList();

            object filterMap;
            if (configuration.Properties.TryGetValue("FilterOrder", out filterMap))
            {
                var dictionaryFilterMap = filterMap as Dictionary<Type, int>;
                if (dictionaryFilterMap != null)
                {
                    var orderedFilters = new List<KeyValuePair<FilterInfo, int>>();
                    result.ForEach(x =>
                    {
                        int position;
                        if (dictionaryFilterMap.TryGetValue(x.Instance.GetType(), out position))
                        {
                            orderedFilters.Add(new KeyValuePair<FilterInfo, int>(x, position));
                        }
                        else
                        {
                            orderedFilters.Add(new KeyValuePair<FilterInfo, int>(x, -1));
                        }
                    });

                    result = orderedFilters.OrderBy(x => x.Value).Select(x => x.Key).ToList();
                }
            }

            return result;
        }
    }
}