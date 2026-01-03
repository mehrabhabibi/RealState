namespace RealState.API.ViewModels.Property
{
    public class PropertyImageViewModel
    {
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
    }

    public class PropertyVideoViewModel
    {
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}