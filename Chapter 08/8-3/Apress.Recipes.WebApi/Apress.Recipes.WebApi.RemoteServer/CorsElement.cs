using System.Configuration;

namespace Apress.Recipes.WebApi.RemoteServer
{
    public class CorsElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("origins", IsRequired = true)]
        public string Origins
        {
            get { return (string)this["origins"]; }
            set { this["origins"] = value; }
        }

        [ConfigurationProperty("methods", IsRequired = true)]
        public string Methods
        {
            get { return (string)this["methods"]; }
            set { this["methods"] = value; }
        }

        [ConfigurationProperty("headers", IsRequired = false)]
        public string Headers
        {
            get { return (string)this["headers"]; }
            set { this["headers"] = value; }
        }
    }
}