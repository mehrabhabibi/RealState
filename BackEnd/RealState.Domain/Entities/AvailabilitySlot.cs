namespace RealState.Domain.Entities
{
    public class AvailabilitySlot
    {
        public DateTime Start { get; }
        public DateTime End { get; }
        public bool IsAvailable { get; }
        public string UnavailableReason { get; }

        public AvailabilitySlot(DateTime start, DateTime end,
                             bool isAvailable = true,
                             string reason = null)
        {
            Start = start;
            End = end;
            IsAvailable = isAvailable;
            UnavailableReason = reason;
        }
    }
}