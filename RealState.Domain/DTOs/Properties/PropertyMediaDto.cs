namespace RealState.Domain.DTOs.Properties
{
    public class PropertyImageDto
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public PropertyDto Property { get; set; }
    }

    public class PropertyVideoDto
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public PropertyDto Property { get; set; }
    }
}