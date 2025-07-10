using Microsoft.AspNetCore.Mvc;
using RealState.API.Mapping;
using RealState.API.ViewModels.Property;
using RealState.Domain.Interfaces;

namespace RealState.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        private readonly ILogger<PropertiesController> _logger;

        public PropertiesController(
            IPropertyService propertyService,
            ILogger<PropertiesController> logger)
        {
            _propertyService = propertyService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyViewModel>>> GetAllProperties()
        {
            try
            {
                var properties = (await _propertyService.GetAllPropertiesAsync()).ToViewModel();
                return Ok(properties);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving properties");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyViewModel>> GetProperty(int id)
        {
            try
            {
                var property = (await _propertyService.GetPropertyByIdAsync(id)).ToViewModel();

                if (property == null)
                {
                    return NotFound();
                }

                return Ok(property);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving property with ID: {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateProperty(CreatePropertyViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _propertyService.CreatePropertyAsync(viewModel.ToDto());
            return Ok(new { message = "Property created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(PropertyViewModel updatePropertyViewModel)
        {
            if (_propertyService.GetPropertyByIdAsync(updatePropertyViewModel.Id) == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _propertyService.UpdatePropertyAsync(updatePropertyViewModel.ToDto());
            return Ok(new { message = "Property updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            await _propertyService.DeletePropertyAsync(id);
            return Ok(new { message = "Property deleted successfully" });
        }

        [HttpGet("GetPropertyTypes")]
        public ActionResult<IEnumerable<string>> GetPropertyTypes()
        {
            return Ok(Enum.GetNames(typeof(PropertyType)));
        }

        [HttpGet("GetPropertyStatus")]
        public ActionResult<IEnumerable<string>> GetPropertyStatus()
        {
            return Ok(Enum.GetNames(typeof(PropertyStatus)));
        }
    }
}