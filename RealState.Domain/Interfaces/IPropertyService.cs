using RealState.Domain.DTOs.Properties;

namespace RealState.Domain.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyDto> GetPropertyByIdAsync(int id);
        Task<IEnumerable<PropertyDto>> GetAllPropertiesAsync();
        Task CreatePropertyAsync(CreatePropertyDto createDto);
        Task UpdatePropertyAsync(PropertyDto dto);
        Task DeletePropertyAsync(int id);
    }
}