namespace Domain.Aggregates.DealerAggregate.Contracts
{
    public interface IDealerRepository
    {
        Dealer GetById(int id);
    }
}
