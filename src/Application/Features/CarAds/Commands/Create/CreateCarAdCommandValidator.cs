using Domain.Aggregates.CarAdAggregate.Contracts;
using FluentValidation;
using System;
using Domain.Aggregates.CarAdAggregate.Specifications;

namespace Application.Features.CarAds.Commands.Create
{
    public class CreateCarAdCommandValidator : AbstractValidator<CreateCarAdCommand>
    {
        public CreateCarAdCommandValidator(ICarAdRepository carAdRepository)
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
                .MustAsync(async (categoryId, token) => await carAdRepository.GetBySpec(new CategoryByIdSpec(categoryId), token) != null)
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
