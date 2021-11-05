namespace Application.Features.CarAds.Queries.GetCarAdDetails
{
    public class CarAdDetailResponse
    {
        public CarAdDetailResponse(int id, string manufacturer, string model, string imageUrl, string category, decimal pricePerDay, bool hasClimateControl, int numberOfSeats, string transmissionType, DealerDetailResponse dealer)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            ImageUrl = imageUrl;
            Category = category;
            PricePerDay = pricePerDay;
            HasClimateControl = hasClimateControl;
            NumberOfSeats = numberOfSeats;
            TransmissionType = transmissionType;
            Dealer = dealer;
        }

        public int Id { get; }

        public string Manufacturer { get; }

        public string Model { get; }

        public string ImageUrl { get; }

        public string Category { get; }

        public decimal PricePerDay { get; }

        public bool HasClimateControl { get; }

        public int NumberOfSeats { get; }

        public string TransmissionType { get; }

        public DealerDetailResponse Dealer { get; }
    }

    public class DealerDetailResponse
    {
        public DealerDetailResponse(int id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; }

        public string Name { get; }

        public string PhoneNumber { get; }
    }
}
