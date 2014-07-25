using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi.Controllers
{
    public class FormController : ApiController
    {
        public Item Post(Item item)
        {
            return item;
        }
    }

    public class ItemsController : ApiController
    {
        public Item Post(Item data)
        {
            return data;
        }
    }

    public class Item
    {
        public string Name { get; set; }
    }
}
