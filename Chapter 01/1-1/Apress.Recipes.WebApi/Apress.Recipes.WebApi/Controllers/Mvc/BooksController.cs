using System.Linq;
using System.Web.Mvc;
using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi.Controllers.Mvc
{
    public class BooksController : Controller
    {
        public ActionResult Details(int id)
        {
            var book = Books.List.FirstOrDefault(x => x.Id == id);
            if(book == null) return new HttpNotFoundResult();

            return View(book);
        }

        public ActionResult Index()
        {
            return View(Books.List);
        }
    }
}