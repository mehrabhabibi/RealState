using RealState.Core.Interfaces;
using RealState.Domain.DTOs.AgentAvailability;
using RealState.Domain.Entities;
using RealState.Domain.Interfaces;

namespace RealState.Application.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IAgentAvailabilityRepository _availabilityRepo;
        private readonly IAppointmentRepository _appointmentRepo;
        private readonly ISettingsService _settingsService;

        public AvailabilityService(
            IAgentAvailabilityRepository availabilityRepo,
            IAppointmentRepository appointmentRepo,
            ISettingsService settingsService)
        {
            _availabilityRepo = availabilityRepo;
            _appointmentRepo = appointmentRepo;
            _settingsService = settingsService;
        }

        public async Task<IEnumerable<AvailabilitySlot>> GetAvailableSlotsAsync(
            int agentId, DateTime startDate, DateTime endDate)
        {
            var agentAvailability = await _availabilityRepo
                .GetAgentAvailabilitiesAsync(agentId, startDate, endDate);

            var appointments = await _appointmentRepo
                .GetByAgentAsync(agentId, startDate, endDate);

            // Get system settings (min booking notice, slot duration, etc.)
            var settings = await _settingsService.GetSchedulingSettingsAsync();

            // Generate available slots
            return GenerateAvailabilitySlots(
                startDate,
                endDate,
                agentAvailability,
                appointments,
                settings);
        }

        private IEnumerable<AvailabilitySlot> GenerateAvailabilitySlots(
            DateTime startDate,
            DateTime endDate,
            IEnumerable<AgentAvailability> agentAvailability,
            IEnumerable<Appointment> appointments,
            SchedulingSettings settings)
        {
            var slots = new List<AvailabilitySlot>();
            var currentDate = startDate.Date;

            while (currentDate <= endDate.Date)
            {
                var dayAvailability = agentAvailability
                    .Where(a => a.ExceptionDate?.Date == currentDate ||
                               (a.ExceptionDate == null && a.DayOfWeek == currentDate.DayOfWeek))
                    .OrderBy(a => a.StartTime);

                if (!dayAvailability.Any(a => a.IsAvailable))
                {
                    slots.Add(new AvailabilitySlot(
                        currentDate,
                        currentDate.AddDays(1).AddSeconds(-1),
                        false, "Agent unavailable all day"));
                    currentDate = currentDate.AddDays(1);
                    continue;
                }
                var slotStart = currentDate.Add(settings.DefaultEndTime);
                var dayEnd = currentDate.Add(settings.DefaultEndTime);

                while (slotStart < dayEnd)
                {
                    var slotEnd = slotStart.AddMinutes(settings.SlotDurationMinutes);
                    var isAvailable = IsSlotAvailable(
                        slotStart,
                        slotEnd,
                        dayAvailability,
                        appointments,
                        settings);

                    slots.Add(new AvailabilitySlot(slotStart, slotEnd, isAvailable));
                    slotStart = slotEnd;
                }

                currentDate = currentDate.AddDays(1);
            }

            return slots;
        }

        private bool IsSlotAvailable(
            DateTime slotStart,
            DateTime slotEnd,
            IEnumerable<AgentAvailability> dayAvailability,
            IEnumerable<Appointment> appointments,
            SchedulingSettings settings)
        {
            var isWorkingHour = dayAvailability.Any(a =>
                a.IsAvailable &&
                a.StartTime <= slotStart.TimeOfDay &&
                a.EndTime >= slotEnd.TimeOfDay);

            if (!isWorkingHour) return false;

            var hasConflict = appointments.Any(a =>
                (slotStart >= a.StartTime && slotStart < a.EndTime) ||
                (slotEnd > a.StartTime && slotEnd <= a.EndTime) ||
                (slotStart <= a.StartTime && slotEnd >= a.EndTime));

            if (hasConflict) return false;

            if (slotStart < DateTime.Now.Add(settings.MinimumNotice))
                return false;

            return true;
        }

        public async Task SetAvailabilityAsync(int agentId, SetAvailabilityDto dto)
        {
            var availability = new AgentAvailability
            {
                AgentId = agentId,
                DayOfWeek = dto.DayOfWeek,
                ExceptionDate = dto.ExceptionDate,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                IsAvailable = dto.IsAvailable,
                Reason = dto.Reason
            };

            await _availabilityRepo.AddAsync(availability);
            await _availabilityRepo.SaveAsync();
        }

        public async Task<bool> IsTimeSlotAvailable(int agentId, DateTime startTime, DateTime endTime)
        {
            var agentAvailability = await _availabilityRepo
                .GetAgentAvailabilitiesAsync(agentId, startTime.Date, endTime.Date); 
            return agentAvailability.Any(a =>
                a.IsAvailable &&
                a.StartTime <= startTime.TimeOfDay &&
                a.EndTime >= endTime.TimeOfDay &&
                (a.ExceptionDate == null || a.ExceptionDate.Value.Date == startTime.Date));
        }
    }
}