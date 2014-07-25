using System;
using System.Web.Http.Controllers;

namespace Apress.Recipes.WebApi
{
    public class MvcBindingConfigurationAttribute : Attribute, IControllerConfiguration
    {
        public Type ActionValueBinder { get; set; }

        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            if (ActionValueBinder != null)
                controllerSettings.Services.Replace(typeof(IActionValueBinder), Activator.CreateInstance(ActionValueBinder));
        }
    }
}