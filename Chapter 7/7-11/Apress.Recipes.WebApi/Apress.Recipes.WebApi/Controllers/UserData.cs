using System.ComponentModel.DataAnnotations;

namespace Apress.Recipes.WebApi.Controllers
{
    public class UserData
    {
        [Required]
        public string Username { get; set; }

        [EmailAddress]
        [Compare("RepeatEmail")]
        public string Email { get; set; }

        [EmailAddress]
        [Compare("Email")]
        public string RepeatEmail { get; set; }
    }
}