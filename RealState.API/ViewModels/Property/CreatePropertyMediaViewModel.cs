namespace RealState.API.ViewModels.Property
{
    public class CreatePropertyImageViewModel
    {
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
    }

    public class CreatePropertyVideoViewModel
    {
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}