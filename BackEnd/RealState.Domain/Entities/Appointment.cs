using RealState.Domain.Entities.Common;
using RealState.Domain.Enumeration;

namespace RealState.Domain.Entities
{
    public class Appointment : EntityBase
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AppointmentStatus Status { get; set; }
        public AppointmentType Type { get; set; }

        public int? PropertyId { get; set; }
        public Property Property { get; set; }

        public int AgentId { get; set; }
        public User Agent { get; set; }

        public int ClientId { get; set; }
        public User Client { get; set; }

        public TourInfo TourInfo { get; set; }
    }
}