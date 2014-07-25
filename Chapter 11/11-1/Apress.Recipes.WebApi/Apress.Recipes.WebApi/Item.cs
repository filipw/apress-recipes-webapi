using System;
using System.ComponentModel.DataAnnotations;

namespace Apress.Recipes.WebApi
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}