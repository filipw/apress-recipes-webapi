using System.Web.Http.Filters;

namespace Apress.Recipes.WebApi
{
    public class OrderedActionFilterAttribute : ActionFilterAttribute
    {
        public int Order { get; set; }

        public OrderedActionFilterAttribute() : this(-1)
        {}

        public OrderedActionFilterAttribute(int order)
        {
            Order = order;
        }
    }
}