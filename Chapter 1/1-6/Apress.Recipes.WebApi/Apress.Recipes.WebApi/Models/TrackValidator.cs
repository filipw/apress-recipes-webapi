using System;
using FluentValidation;

namespace Apress.Recipes.WebApi.Models
{
    public class TrackValidator : AbstractValidator<Track>
    {
        public TrackValidator()
        {
            RuleFor(track => track.Artist).Length(0, 30).WithMessage("Artist is required");
            RuleFor(track => track.Artist).Length(0, 40).WithMessage("Title is required");
            RuleFor(track => track.Starred).NotNull().Equal(x => true).Unless(track => track.Rating.HasValue && track.Rating > 0 && track.Rating < 10);
            RuleFor(track => track.Rating).NotNull().GreaterThan(0).LessThan(10).Unless(track => track.Starred.HasValue && track.Starred.Value);
        }
    }
}