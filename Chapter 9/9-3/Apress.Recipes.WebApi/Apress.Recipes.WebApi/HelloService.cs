using System;

namespace Apress.Recipes.WebApi
{
    public class HelloService : IService
    {
        private int _random;

        public HelloService()
        {
            _random = new Random().Next(0, 100);
        }

        public string SaySomething()
        {
            return "Hello Service " + _random;
        }
    }
}