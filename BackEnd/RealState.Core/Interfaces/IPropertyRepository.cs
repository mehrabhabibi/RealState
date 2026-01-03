using RealState.Domain.Entities;

namespace RealState.Core.Interfaces;

public interface IPropertyRepository
{
    Task<Property> GetByIdAsync(int id);
    Task<IEnumerable<Property>> GetAllAsync();
    Task AddAsync(Property property);
    Task UpdateAsync(Property property);
    Task DeleteAsync(int id);
}