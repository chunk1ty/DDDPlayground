namespace Application.Features.CarAds.Commands.Create
{
    public class CreateCarAdResponse
    {
        public CreateCarAdResponse(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
