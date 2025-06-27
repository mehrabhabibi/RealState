namespace RealState.Domain.DTOs.Properties
{
    public class CreatePropertyDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public decimal Price { get; set; }
        public int Bedrooms { get; set; }
        public PropertyType Type { get; set; }
        public PropertyStatus Status { get; set; }
        public CreatePropertyDetailsDto Details { get; set; }
        public IEnumerable<CreatePropertyImageDto> Images { get; set; }
        public IEnumerable<CreatePropertyVideoDto> Videos { get; set; }
    }
}