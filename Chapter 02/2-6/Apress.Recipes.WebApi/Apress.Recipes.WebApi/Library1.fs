namespace Apress.Recipes.WebApi

open Owin
open System
open System.Diagnostics
open System.Net
open System.Threading
open System.Net.Http
open System.Web.Http
open Microsoft.Owin.Hosting
open Microsoft.WindowsAzure.ServiceRuntime

type TestController() = 
    inherit ApiController()
    [<Route("test")>]
    member x.Get() = "Hello Azure!"

type WorkerRole() =
    inherit RoleEntryPoint() 
    let mutable webApp = None

    override w.Run() =
        while(true) do 
            Thread.Sleep(10000)
            Trace.TraceInformation("Working", "Information")

    override w.OnStart() = 
        ServicePointManager.DefaultConnectionLimit <- 12

        let endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints.["Default"]
        let uri = sprintf "%s://%O" endpoint.Protocol endpoint.IPEndpoint
        webApp <- Some(WebApp.Start(uri, fun app -> 
            let config = new HttpConfiguration()
            config.MapHttpAttributeRoutes()
            app.UseWebApi(config) |> ignore
        ))

        base.OnStart()

    override w.OnStop() =
         match webApp with
            | Some x -> x.Dispose() |> ignore
            | None -> ()
         base.OnStop()