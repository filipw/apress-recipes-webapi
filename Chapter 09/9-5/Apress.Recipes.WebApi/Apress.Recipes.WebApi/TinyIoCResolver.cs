using System.Web.Http.Dependencies;
using TinyIoC;

namespace Apress.Recipes.WebApi
{
    public class TinyIoCResolver : TinyIoCScope, IDependencyResolver
    {
        public TinyIoCResolver(TinyIoCContainer container)
            : base(container)
        { }

        public IDependencyScope BeginScope()
        {
            return new TinyIoCScope(Container.GetChildContainer());
        }
    }
}