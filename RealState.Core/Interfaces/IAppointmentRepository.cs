using RealState.Domain.Entities;

namespace RealState.Core.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetByIdAsync(int id);
        Task<IEnumerable<Appointment>> GetByAgentAsync(int agentId, DateTime from, DateTime to);
        Task AddAsync(Appointment appointment);
        Task SaveAsync();
    }
}