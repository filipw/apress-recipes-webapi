using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Apress.Recipes.WebApi.Models
{
    public class Track : IValidatableObject
    {
        public int Id { get; set; }

        public string Artist { get; set; }

        public string Title { get; set; }

        public int? Rating { get; set; }

        public bool? Starred { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new TrackValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}