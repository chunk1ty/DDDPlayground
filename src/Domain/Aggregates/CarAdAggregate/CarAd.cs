﻿using Ardalis.GuardClauses;
using Domain.Aggregates.CarAdAggregate.Contracts;
using SharedKernel;

namespace Domain.Aggregates.CarAdAggregate
{
    public class CarAd : Entity<int>, IAggregateRoot 
    {
        public CarAd(Manufacturer manufacturer,
                     string model,
                     Category category,
                     string imageUrl,
                     decimal pricePerDay,
                     Options options,
                     bool isAvailable)
        {
            Validate(model, imageUrl, pricePerDay);

            Manufacturer = manufacturer;
            Model = model;
            Category = category;
            ImageUrl = imageUrl;
            PricePerDay = pricePerDay;
            Options = options;
            IsAvailable = isAvailable;

            AddDomainEvent(new CarAdCreatedDomainEvent(this));
        }

        public Manufacturer Manufacturer { get; private set; }

        public string Model { get; private set; }

        public Category Category { get; private set; }

        public string ImageUrl { get; private set; }

        public decimal PricePerDay { get; private set; }

        public Options Options { get; private set; }

        public bool IsAvailable { get; private set; }

        public void UpdateCarAd(Manufacturer manufacturer,
                                string model,
                                Category category,
                                string imageUrl,
                                decimal pricePerDay,
                                Options options,
                                bool isAvailable)
        {
            Validate(model, imageUrl, pricePerDay);

            Manufacturer = manufacturer;
            Model = model;
            Category = category;
            ImageUrl = imageUrl;
            PricePerDay = pricePerDay;
            Options = options;
            IsAvailable = isAvailable;

            AddDomainEvent(new CarAdUpdatedDomainEvent(this));
        }

        public void ChangeAvailability()
        {
            IsAvailable = !IsAvailable;

            AddDomainEvent(new CarAdUpdatedAvailabilityDomainEvent(this));
        }

        private void Validate(string model, string imageUrl, decimal pricePerDay)
        {
            Guard.Against.StringLength(model, nameof(model), 2, 20);
            Guard.Against.InvalidUrl(imageUrl, nameof(imageUrl));
            Guard.Against.OutOfRange(pricePerDay, nameof(pricePerDay), 0, decimal.MaxValue);
        }
    }
}