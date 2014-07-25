using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (Int32.TryParse((string)Page.RouteData.Values["id"], out id))
            {
                var book = Books.List.FirstOrDefault(x => x.Id == id);
                if (book == null)
                {
                    Response.StatusCode = 404;
                    return;
                }

                ltlAuthor.Text = book.Author;
                ltlTitle.Text = book.Title;
                hplLink.NavigateUrl = "/api/books/" + book.Id;
            }

            Response.StatusCode = 404;
        }
    }
}