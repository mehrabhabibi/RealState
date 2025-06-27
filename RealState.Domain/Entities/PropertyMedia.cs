namespace RealState.Domain.Entities
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public Property Property { get; set; }
    }

    public class PropertyVideo
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public Property Property { get; set; }
    }
}