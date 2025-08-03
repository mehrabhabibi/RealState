using Microsoft.EntityFrameworkCore;
using RealState.Core.Interfaces;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Data.Repositories
{
    public class AgentAvailabilityRepository : IAgentAvailabilityRepository
    {
        private readonly AppDbContext _context;

        public AgentAvailabilityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AgentAvailability>> GetAgentAvailabilitiesAsync(
            int agentId, DateTime startDate, DateTime endDate)
        {
            var weeklyAvailability = await _context.AgentAvailabilities
                .Where(a => a.AgentId == agentId &&
                           a.ExceptionDate == null)
                .ToListAsync();

            var exceptions = await _context.AgentAvailabilities
                .Where(a => a.AgentId == agentId &&
                           a.ExceptionDate != null &&
                           a.ExceptionDate >= startDate &&
                           a.ExceptionDate <= endDate)
                .ToListAsync();

            return weeklyAvailability.Concat(exceptions);
        }

        public async Task AddAsync(AgentAvailability availability)
        {
            await _context.AgentAvailabilities.AddAsync(availability);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}