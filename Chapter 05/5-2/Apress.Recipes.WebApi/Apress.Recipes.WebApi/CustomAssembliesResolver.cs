using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http.Dispatcher;
using ExternalLibrary;

namespace Apress.Recipes.WebApi
{
    public class CustomAssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            var baseAssemblies = base.GetAssemblies().ToList();
            //var assemblies = new List<Assembly>(baseAssemblies) {typeof (HelloController).Assembly};

            var unreferencedAssembly =
                Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), 
                "UnreferencedExternalLibrary.dll"));
            baseAssemblies.Add(unreferencedAssembly);

            return baseAssemblies.Distinct().ToList();
        }
    }
}