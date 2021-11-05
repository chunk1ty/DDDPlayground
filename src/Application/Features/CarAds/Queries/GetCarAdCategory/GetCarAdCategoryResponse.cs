namespace Application.Features.CarAds.Queries.GetCarAdCategory
{
    public class GetCarAdCategoryResponse
    {
        public GetCarAdCategoryResponse(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; }

        public string Name { get; }

        public string Description { get; }
    }
}
