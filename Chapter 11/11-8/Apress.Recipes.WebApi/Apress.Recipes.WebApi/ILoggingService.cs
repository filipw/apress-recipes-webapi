namespace Apress.Recipes.WebApi
{
    public interface ILoggingService
    {
        void Log(string message);
    }

    public class SampleLoggingService : ILoggingService
    {
        public void Log(string message)
        {
            //null pattern
        }
    }
}