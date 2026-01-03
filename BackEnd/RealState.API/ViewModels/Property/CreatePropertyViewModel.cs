namespace RealState.API.ViewModels.Property
{
    public class CreatePropertyViewModel
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
        public CreatePropertyDetailsViewModel Details { get; set; }
        public IEnumerable<CreatePropertyImageViewModel> Images { get; set; }
        public IEnumerable<CreatePropertyVideoViewModel> Videos { get; set; }
    }
}