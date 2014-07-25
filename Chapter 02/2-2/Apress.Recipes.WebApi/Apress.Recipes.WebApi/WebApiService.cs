using System;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi
{
    public partial class WebApiService : ServiceBase
    {
        private IDisposable _owinHost;
        const string Address = "http://localhost:999/";

        public WebApiService()
        {
            InitializeComponent();
            
        }

        protected override void OnStart(string[] args)
        {
            _owinHost = WebApp.Start<Startup>(Address);
        }

        protected override void OnStop()
        {
            _owinHost.Dispose();
        }
    }
}
