namespace RealState.Domain.Interfaces
{
    public interface IAvailabilityService
    {
        Task<bool> IsTimeSlotAvailable(int agentId, DateTime startTime, DateTime endTime);
    }
}