using System;

namespace Apress.Recipes.WebApi
{
    public class Article : IRss
    {
        public int ArticleId { get; set; }
        public Uri Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Author { get; set; }
    }
}