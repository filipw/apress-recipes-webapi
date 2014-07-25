using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi.Controllers
{
    public class DiceController : ApiController
    {
        public DiceResult Get()
        {
            var newValue = new Random().Next(1, 7);

            object context;
            if (Request.Properties.TryGetValue("MS_HttpContext", out context))
            {
                var httpContext = context as HttpContextBase;
                if (httpContext != null && httpContext.Session != null)
                {
                    var lastValue = httpContext.Session["LastValue"] as int?;
                    httpContext.Session["LastValue"] = newValue;

                    return new DiceResult
                    {
                        NewValue = newValue,
                        LastValue = lastValue ?? 0
                    };
                }
            }

            return new DiceResult { NewValue = newValue};
        }
    }
}
