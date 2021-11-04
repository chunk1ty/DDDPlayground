using System.Collections.Generic;
using System.Linq;
using Infrastructure.Persistence;
using MediatR;
using SharedKernel;
using System.Threading.Tasks;

namespace Infrastructure
{
    static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, CarRentalDbContext context)
        {
            IEnumerable<Entity<int>> domainEntities = context.ChangeTracker
                                                             .Entries<Entity<int>>()
                                                             .Select(e => e.Entity)
                                                             .Where(entity => entity.DomainEvents != null && 
                                                                              entity.DomainEvents.Any());

            foreach (Entity<int> domainEntity in domainEntities)
            {
                foreach (INotification domainEntityEvent in domainEntity.DomainEvents)
                {
                    await mediator.Publish(domainEntityEvent);
                }

                domainEntity.ClearDomainEvents();
            }
        }
    }
}
