using System.Collections.Generic;

namespace Apress.Recipes.WebApi.WebHost.Models
{
    public class Items
    {
        public IEnumerable<Item> Collection { get; set; }
    }
}