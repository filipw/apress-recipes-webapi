using System.Configuration;

namespace Apress.Recipes.WebApi.RemoteServer
{
    [ConfigurationCollection(typeof(CorsElement))]
    public class CorsElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CorsElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CorsElement)element).Name;
        }
    }
}