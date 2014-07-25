using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Apress.Recipes.WebApi.RemoteServer
{
    [EnableCors("*", "*", "*")]
    public class BooksController : ApiController
    {
        private static List<Book> _books = new List<Book>
        {
            new Book {Id = 1, Author = "John Robb", Title = "Punk Rock: An Oral History"},
            new Book {Id = 2, Author = "Daniel Mohl", Title = "Building Web, Cloud, and Mobile Solutions with F#"},
            new Book {Id = 3, Author = "Steve Clarke", Title = "100 Things Blue Jays Fans Should Know & Do Before They Die"},
            new Book {Id = 4, Author = "Mark Frank", Title = "Cuban Revelations: Behind the Scenes in Havana "}
        };

        [Route("books")]
        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        [Route("books/{id:int}", Name = "GetBookById")]
        public Book GetById(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        [Route("books")]
        public IHttpActionResult Post(Book book)
        {
            book.Id = _books.Last() != null ? _books.Last().Id + 1 : 1;
            _books.Add(book);
            return CreatedAtRoute("GetBookById", new {id = book.Id}, book);
        }
    }
}