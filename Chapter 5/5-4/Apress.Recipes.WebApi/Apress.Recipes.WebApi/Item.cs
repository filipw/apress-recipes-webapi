using System.ComponentModel.DataAnnotations;

namespace Apress.Recipes.WebApi
{
    public class Item
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(3)]
        public string Code { get; set; }
    }
}