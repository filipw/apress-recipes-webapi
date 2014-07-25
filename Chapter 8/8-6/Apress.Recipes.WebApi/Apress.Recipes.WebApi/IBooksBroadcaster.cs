using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi
{
    public interface IBooksBroadcaster
    {
        void BookAdded(Book book);
    }
}