using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ValuesController : ApiController
    {
        private readonly List<Article> _articles;

        public ValuesController()
        {
            _articles = new List<Article> {
                new Article {
                    ArticleId = 1,
                    Author = "Filip",
                    CreatedAt = new DateTime(2012,10,25),
                    Description = "Some text",
                    Link = new Uri("http://www.strathweb.com/1"),
                    Title = "Article One"
                },
                new Article {
                    ArticleId = 2,
                    Author = "Filip",
                    CreatedAt = new DateTime(2012,10,26),
                    Description = "Different text",
                    Link = new Uri("http://www.strathweb.com/2"),
                    Title = "Article Two"
                }
            };
        }

        [Route("values")]
        public IEnumerable<Article> Get()
        {
            return _articles;
        }

        public Article Get(int id)
        {
            return _articles.FirstOrDefault(i => i.ArticleId == id);
        }
    }

}