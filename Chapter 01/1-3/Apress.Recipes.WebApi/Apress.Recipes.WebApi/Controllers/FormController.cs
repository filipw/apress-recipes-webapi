using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi.Controllers
{
    public class FormController : ApiController
    {
        public UserModel Post(FormDataCollection form)
        {
            //process form...

            var user = new UserModel
            {
                Email = form["Email"],
                Name = form["Name"],
                Gender = form["Gender"]
            };

            return user;
        }
    }
}
