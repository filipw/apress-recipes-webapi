using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using TinyIoC;

namespace Apress.Recipes.WebApi
{
    public class TinyIoCHttpControllerActivator : IHttpControllerActivator
    {
        private readonly TinyIoCContainer _container;

        public TinyIoCHttpControllerActivator(TinyIoCContainer container)
        {
            _container = container;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller = _container.Resolve(controllerType);
            return controller as IHttpController;
        }
    }
}