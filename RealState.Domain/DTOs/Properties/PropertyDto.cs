
namespace RealState.Domain.DTOs.Properties
{
    public class PropertyDto
    {
        public int Id { get; set; }
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
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public PropertyDetailsDto Details { get; set; }
        public IEnumerable<PropertyImageDto> Images { get; set; }
        public IEnumerable<PropertyVideoDto> Videos { get; set; }
    }
}

