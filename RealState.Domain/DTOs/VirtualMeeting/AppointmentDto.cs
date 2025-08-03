namespace RealState.Domain.DTOs.VirtualMeeting
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AgentId { get; set; }
        public int ClientId { get; set; }
        public int? PropertyId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public TourInfoDto TourInfo { get; set; }
    }
}