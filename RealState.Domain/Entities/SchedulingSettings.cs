namespace RealState.Domain.Entities
{
    public class SchedulingSettings
    {
        public TimeSpan DefaultStartTime { get; set; }
        public TimeSpan DefaultEndTime { get; set; }
        public int SlotDurationMinutes { get; set; }
        public TimeSpan MinimumNotice { get; set; }
        public int MaxBookingDays { get; set; }
        public bool AllowWeekendBookings { get; set; }
        public List<TimeSpan> BreakTimes { get; set; } = new();
    }
}