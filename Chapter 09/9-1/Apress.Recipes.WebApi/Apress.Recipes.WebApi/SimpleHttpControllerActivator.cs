using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Apress.Recipes.WebApi
{
    public class SimpleHttpControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            if (controllerType == typeof(DependencyTestController))
                return new DependencyTestController(
                    new HelloService());

            return null;
        }
    }
}