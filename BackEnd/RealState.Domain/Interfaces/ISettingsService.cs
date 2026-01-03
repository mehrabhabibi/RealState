using RealState.Domain.Entities;

namespace RealState.Domain.Interfaces
{
    public interface ISettingsService
    {
        Task<SchedulingSettings> GetSchedulingSettingsAsync();
    }
}