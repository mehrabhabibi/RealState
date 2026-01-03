using RealState.Domain.Entities;

namespace RealState.Core.Interfaces
{
    public interface IAgentAvailabilityRepository
    {
        Task<IEnumerable<AgentAvailability>> GetAgentAvailabilitiesAsync(
        int agentId, DateTime startDate, DateTime endDate);
        Task AddAsync(AgentAvailability availability);
        Task SaveAsync();
    }
}