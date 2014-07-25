using Apress.Recipes.WebApi.Models;
using Microsoft.AspNet.SignalR;

namespace Apress.Recipes.WebApi
{
    public class BooksBroadcaster : IBooksBroadcaster
    {
        private readonly IHubContext _booksHubContext;

        public BooksBroadcaster(IHubContext booksHubContext)
        {
            _booksHubContext = booksHubContext;
        }

        public void BookAdded(Book book)
        {
            _booksHubContext.Clients.All.bookAdded(book);
        }
    }
}