using Microsoft.EntityFrameworkCore;
using RealState.Core.Interfaces;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Data.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly AppDbContext _context;

        public PropertyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Property> GetByIdAsync(int id)
        {
            return await _context.Properties
                .Include(p => p.Details)
                .Include(p => p.Images)
                .Include(p => p.Videos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            return await _context.Properties
                .Include(p => p.Details)
                .Include(p => p.Images)
                .ToListAsync();
        }

        public async Task AddAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
        }

        public Task UpdateAsync(Property user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

