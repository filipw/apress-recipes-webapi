using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Apress.Recipes.WebApi.Models
{
    public class Album : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Artist is required")]
        [MaxLength(30)]
        public string Artist { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(40)]
        public string Title { get; set; }

        public int? Rating { get; set; }

        public bool? Starred { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!(Rating.HasValue && Rating > 0 && Rating < 10) || (Starred.HasValue && Starred.Value))
            {
                yield return new ValidationResult("You must set either the Rating  in the 0-9 range or Starred flag.");
            }
        }
    }
}