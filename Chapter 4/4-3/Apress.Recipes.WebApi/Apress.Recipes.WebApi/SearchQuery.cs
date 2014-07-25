using System.ComponentModel;

namespace Apress.Recipes.WebApi
{
    public class SearchQuery
    {
        public SearchQuery()
        {
            PageSize = 10;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string StartsWith { get; set; }
    }

    [TypeConverter(typeof(SearchQueryConverter))]
    public class ConvertedSearchQuery : SearchQuery
    {
        
    }
}