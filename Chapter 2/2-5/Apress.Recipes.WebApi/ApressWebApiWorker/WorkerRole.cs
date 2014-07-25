using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Microsoft.WindowsAzure.ServiceRuntime;
using Owin;

namespace ApressWebApiWorker
{
    public class WorkerRole : RoleEntryPoint
    {
        private IDisposable _app;

        public override void Run()
        {
            while (true)
            {
                Thread.Sleep(10000);
                Trace.TraceInformation("Working", "Information");
            }
        }

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            var endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["Default"];
            var url = string.Format("{0}://{1}", endpoint.Protocol, endpoint.IPEndpoint);

            _app = WebApp.Start(url, app =>
            {
                var config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();

                app.UseWebApi(config);
            });

            return base.OnStart();
        }

        public override void OnStop()
        {
            if (_app != null)
            {
                _app.Dispose();
            }
            base.OnStop();
        }
    }
}
