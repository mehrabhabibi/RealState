using Microsoft.EntityFrameworkCore;
using RealState.Core.Interfaces;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await _context.Appointments
                .Include(a => a.Property)
                .Include(a => a.Agent)
                .Include(a => a.Client)
                .Include(a => a.TourInfo)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetByAgentAsync(int agentId, DateTime from, DateTime to)
        {
            return await _context.Appointments
                .Where(a => a.AgentId == agentId &&
                           a.StartTime >= from &&
                           a.EndTime <= to)
                .ToListAsync();
        }

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}