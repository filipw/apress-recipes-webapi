using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Apress.Recipes.WebApi
{
    public class OrderBasedFilterProvider : IFilterProvider
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

            var customActionFilters = actionDescriptor.GetFilters().Select(i => new CustomFilterInfo(i, FilterScope.Action));
            var customControllerFilters = actionDescriptor.ControllerDescriptor.GetFilters().Select(i => new CustomFilterInfo(i, FilterScope.Controller));
            var customGlobalFilters = configuration.Filters.Select(i => new CustomFilterInfo(i));

            var result = (customControllerFilters.Concat(customActionFilters).Concat(customGlobalFilters)).OrderBy(i => i).Select(i => i.FilterInfo);
            return result;
        }
    }
}