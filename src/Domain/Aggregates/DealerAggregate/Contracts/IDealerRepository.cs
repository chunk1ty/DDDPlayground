using System.Threading.Tasks;
using System.Threading;

namespace Domain.Aggregates.DealerAggregate.Contracts
{
    public interface IDealerRepository
    {
        Task<Dealer> GetByIdAsync(int specification, CancellationToken cancellationToken = default);
    }
}
