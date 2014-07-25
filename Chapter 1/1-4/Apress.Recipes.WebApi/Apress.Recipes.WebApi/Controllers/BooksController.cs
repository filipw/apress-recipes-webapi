using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi.Controllers
{
    public class BooksController : ApiController
    {
        public Book GetById(int id)
        {
            var book = Books.List.FirstOrDefault(x => x.Id == id);
            if (book == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            book.Link = Url.Link("BookPage", new {controller = "BooksPage", action = "Details", id = id });
            return book;
        }
    }
}