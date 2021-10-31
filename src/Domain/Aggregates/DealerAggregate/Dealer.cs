using Ardalis.GuardClauses;
using Domain.Aggregates.CarAdAggregate;
using SharedKernel;
using System.Collections.Generic;
using System.Linq;
using Domain.Aggregates.DealerAggregate.Contracts;

namespace Domain.Aggregates.DealerAggregate
{
    public class Dealer : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<CarAd> _carAds;

        public Dealer(string name, PhoneNumber phoneNumber)
        {
            Name = Guard.Against.StringLength(name, nameof(name), 2, 20);
            PhoneNumber = phoneNumber;

            _carAds = new HashSet<CarAd>();

            AddDomainEvent(new DealerCreatedDomainEvent(this));
        }

        public string Name { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public void UpdateDealer(string name, PhoneNumber phoneNumber)
        {
            Name = Guard.Against.StringLength(name, nameof(name), 2, 20);
            PhoneNumber = phoneNumber;

            AddDomainEvent(new DealerUpdatedDomainEvent(this));
        }

        public IReadOnlyCollection<CarAd> CarAds 
            => _carAds.ToList().AsReadOnly();

        public void AddCarAd(CarAd carAd) 
            => _carAds.Add(carAd);
    }
}
