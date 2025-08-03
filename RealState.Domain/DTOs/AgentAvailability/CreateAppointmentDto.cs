using RealState.Domain.Enumeration;

namespace RealState.Domain.DTOs.AgentAvailability
{
    public class CreateAppointmentDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AgentId { get; set; }
        public int ClientId { get; set; }
        public int PropertyId { get; set; }
        public AppointmentType Type { get; set; }
    }
}