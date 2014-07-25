using System.Web.Http;
using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi.Controllers
{
    public class UserController : ApiController
    {
        public UserModel Post(UserModel user)
        {
            //process user...

            return user;
        }
    }
}