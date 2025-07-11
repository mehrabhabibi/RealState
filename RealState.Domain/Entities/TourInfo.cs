using RealState.Domain.Enumeration;

namespace RealState.Domain.Entities
{
    public class TourInfo
    {
        public int Id { get; set; }
        public string MeetingUrl { get; set; }
        public Platform Platform { get; set; }
        public bool IsVirtual { get; set; }
        public string AccessInstructions { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}