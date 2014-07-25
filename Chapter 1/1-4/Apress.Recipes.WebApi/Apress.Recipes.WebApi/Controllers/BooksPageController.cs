using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi.Controllers
{
    public class BooksPageController : Controller
    {
        public ActionResult Details(int id)
        {
            var book = Books.List.FirstOrDefault(x => x.Id == id);
            if(book == null) return new HttpNotFoundResult();

            book.Link = Url.HttpRouteUrl("DefaultApi", new { controller = "Books", id = id });
            return View(book);
        }
    }
}