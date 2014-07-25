using System.Collections.Generic;

namespace Apress.Recipes.WebApi.Models
{
    public static class Books
    {
        public static List<Book> List = new List<Book>
        {
            new Book {Id = 1, Author = "John Robb", Title = "Punk Rock: An Oral History"},
            new Book {Id = 2, Author = "Daniel Mohl", Title = "Building Web, Cloud, and Mobile Solutions with F#"},
            new Book {Id = 3, Author = "Steve Clarke", Title = "100 Things Blue Jays Fans Should Know & Do Before They Die"},
            new Book {Id = 4, Author = "Mark Frank", Title = "Cuban Revelations: Behind the Scenes in Havana "}
        };
    }
}