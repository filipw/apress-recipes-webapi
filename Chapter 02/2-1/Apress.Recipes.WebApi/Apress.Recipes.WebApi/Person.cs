using System.ComponentModel.DataAnnotations;

namespace Apress.Recipes.WebApi
{
    public class Person
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}