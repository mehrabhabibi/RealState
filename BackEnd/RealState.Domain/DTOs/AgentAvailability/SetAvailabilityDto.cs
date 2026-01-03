namespace RealState.Domain.DTOs.AgentAvailability
{
    public class SetAvailabilityDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime? ExceptionDate { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string Reason { get; set; }
    }
}