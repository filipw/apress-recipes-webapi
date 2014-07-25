  public class TestController : ApiController {
	public string Get() { return "Hello scriptcs!";}
}

var webApi = Require<WebApi>();
var server = webApi.CreateServer("http://localhost:900");
server.OpenAsync().Wait();
Console.WriteLine("Server running Press any key to exit...");
Console.ReadKey();