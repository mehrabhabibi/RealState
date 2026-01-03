using RealState.Core.Interfaces;
using RealState.Domain.DTOs.Properties;
using RealState.Domain.Interfaces;
using RealState.Application.Mapping;

namespace RealState.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<IEnumerable<PropertyDto>> GetAllPropertiesAsync()
        {
            var properties = await _propertyRepository.GetAllAsync();
            return properties.ToDto();
        }

        public async Task<PropertyDto> GetPropertyByIdAsync(int id)
        {
            var property = await _propertyRepository.GetByIdAsync(id);
            return property.ToDto();
        }

        public async Task CreatePropertyAsync(CreatePropertyDto createPropertyDto)
            => await _propertyRepository.AddAsync(createPropertyDto.ToDataModel());

        public async Task UpdatePropertyAsync(PropertyDto dto)
        {
            await _propertyRepository.UpdateAsync(dto.ToDataModel());
        }

        public async Task DeletePropertyAsync(int id)
            => await _propertyRepository.DeleteAsync(id);
    }
}

