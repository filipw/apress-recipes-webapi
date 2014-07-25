using System.Configuration;

namespace Apress.Recipes.WebApi.RemoteServer
{
    public class CorsSection : ConfigurationSection
    {
        [ConfigurationProperty("corsPolicies", IsDefaultCollection = true)]
        public CorsElementCollection CorsPolicies
        {
            get { return (CorsElementCollection)this["corsPolicies"]; }
            set { this["corsPolicies"] = value; }
        }
    }
}