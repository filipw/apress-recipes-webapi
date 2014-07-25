using System;
using System.Net.Http.Formatting;
using System.Web.Http.Controllers;

namespace Apress.Recipes.WebApi
{
    public class XmlOnlyAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings,
            HttpControllerDescriptor controllerDescriptor)
        {
            controllerSettings.Formatters.Clear();
            controllerSettings.Formatters.Add(new XmlMediaTypeFormatter());
        }
    }
}