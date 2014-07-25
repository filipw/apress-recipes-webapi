using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using TinyIoC;

namespace Apress.Recipes.WebApi
{
    public class TinyIoCScope : IDependencyScope
    {
        protected TinyIoCContainer Container;

        public TinyIoCScope(TinyIoCContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            Container = container;
        }
        public object GetService(Type serviceType)
        {
            if (Container == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed.");

            try
            {
                return Container.Resolve(serviceType);
            }
            catch (TinyIoCResolutionException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (Container == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed.");

            try
            {
                return Container.ResolveAll(serviceType);
            }
            catch (TinyIoCResolutionException)
            {
                return Enumerable.Empty<object>();
            }
        }

        public void Dispose()
        {
            Container = null;
            GC.SuppressFinalize(this);
        }
    }
}