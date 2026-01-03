namespace RealState.Domain.DTOs.VirtualMeeting
{
    public class TourInfoDto
    {
        public string MeetingUrl { get; set; }
        public string Platform { get; set; }
        public bool IsVirtual { get; set; }
        public string AccessInstructions { get; set; }
    }
}