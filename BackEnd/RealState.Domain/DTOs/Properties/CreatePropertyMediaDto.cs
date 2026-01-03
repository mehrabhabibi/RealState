namespace RealState.Domain.DTOs.Properties
{
    public class CreatePropertyImageDto
    {
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
    }

    public class CreatePropertyVideoDto
    {
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}