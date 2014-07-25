using System;

namespace Apress.Recipes.WebApi
{
    public class ErrorData
    {
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public Uri RequestUri { get; set; }
        public Guid ErrorId { get; set; }
    }
}