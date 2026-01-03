namespace RealState.Domain.DTOs.Properties
{
    public class CreatePropertyDetailsDto
    {
        public decimal SquareMeters { get; set; }
        public int YearBuilt { get; set; }
        public int Floors { get; set; }
        public int Bathrooms { get; set; }
        public bool HasParking { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasGarden { get; set; }
        public bool HasPool { get; set; }
        public bool HasGym { get; set; }
        public string FurnishingStatus { get; set; }
        public string EnergyRating { get; set; }
        public string AdditionalFeatures { get; set; }
    }
}