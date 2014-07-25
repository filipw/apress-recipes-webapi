using System;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Apress.Recipes.WebApi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new WebApiService(),  
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
