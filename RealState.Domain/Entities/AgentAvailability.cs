namespace RealState.Domain.Entities
{
    public class AgentAvailability
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime? ExceptionDate { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string Reason { get; set; }
        public int AgentId { get; set; }
        public User Agent { get; set; }
    }
}