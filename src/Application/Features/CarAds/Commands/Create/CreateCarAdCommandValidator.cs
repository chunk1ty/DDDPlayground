using Domain.Aggregates.CarAdAggregate.Contracts;
using FluentValidation;
using System;

namespace Application.Features.CarAds.Commands.Create
{
    public class CreateCarAdCommandValidator : AbstractValidator<CreateCarAdCommand>
    {
        public CreateCarAdCommandValidator(ICarAdReadRepository carAdReadRepository)
        {
            RuleFor(c => c.ManufacturerName)
                .MinimumLength(2)
                .MaximumLength(20)
                .NotEmpty();

            RuleFor(c => c.Model)
                .MinimumLength(2)
                .MaximumLength(20)
                .NotEmpty();

            RuleFor(c => c.CategoryId)
                .MustAsync(async (categoryId, token) => await carAdReadRepository.GetCategoryById(categoryId, token) != null)
                .WithMessage("'{PropertyName}' does not exist.");

            RuleFor(c => c.ImageUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("'{PropertyName}' must be a valid url.")
                .NotEmpty();

            RuleFor(c => c.PricePerDay)
                .InclusiveBetween(0, decimal.MaxValue);

            RuleFor(c => c.NumberOfSeats)
                .InclusiveBetween(2, 50);
        }
    }
}
