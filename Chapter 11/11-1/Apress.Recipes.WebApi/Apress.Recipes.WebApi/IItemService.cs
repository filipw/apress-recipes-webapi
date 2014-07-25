using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apress.Recipes.WebApi
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetById(int id); 
        Task SaveAsync(Item item);
    }
}