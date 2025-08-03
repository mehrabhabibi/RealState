using RealState.Core.Interfaces;
using RealState.Domain.DTOs.AgentAvailability;
using RealState.Domain.DTOs.VirtualMeeting;
using RealState.Domain.Entities;
using RealState.Domain.Enumeration;
using RealState.Domain.Interfaces;

namespace RealState.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IAvailabilityService _availabilityService;
        private readonly IVirtualMeetingStrategy _meetingService;

        public AppointmentService(
            IAppointmentRepository repository,
            IAvailabilityService availabilityService,
            IVirtualMeetingStrategy meetingService)
        {
            _repository = repository;
            _availabilityService = availabilityService;
            _meetingService = meetingService;
        }

        public async Task<AppointmentResult> CreateAppointmentAsync(CreateAppointmentDto dto)
        {
            var isAvailable = await _availabilityService.IsTimeSlotAvailable(
                dto.AgentId, dto.StartTime, dto.EndTime);

            if (!isAvailable)
            {
                return new AppointmentResult(false, "Selected time slot is not available");
            }

            var appointment = new Appointment
            {
                Title = dto.Title,
                Description = dto.Description,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                AgentId = dto.AgentId,
                ClientId = dto.ClientId,
                PropertyId = dto.PropertyId,
                Type = dto.Type,
                Status = AppointmentStatus.Confirmed
            };

            if (dto.Type == AppointmentType.VirtualLiveTour)
            {
                var meeting = await _meetingService.CreateMeetingAsync(new MeetingRequest
                (
                    dto.StartTime,
                    dto.EndTime,
                    $"Virtual Tour - {dto.Title}",
                    dto.Description
                ));

                appointment.TourInfo = new TourInfo
                {
                    MeetingUrl = meeting.JoinUrl,  // Assuming JoinUrl is returned
                    Platform = Enum.Parse<Platform>(meeting.Platform),
                    IsVirtual = true,
                    AccessInstructions = "Join using the provided link"
                };
            }

            await _repository.AddAsync(appointment);
            await _repository.SaveAsync();

            var appointmentDto = new AppointmentDto
            {
                Id = appointment.Id,
                Title = appointment.Title,
                Description = appointment.Description,
                StartTime = appointment.StartTime,
                EndTime = appointment.EndTime,
                AgentId = appointment.AgentId,
                ClientId = appointment.ClientId,
                PropertyId = appointment.PropertyId,
                Type = appointment.Type.ToString(),
                Status = appointment.Status.ToString(),
                TourInfo = appointment.TourInfo != null ? new TourInfoDto
                {
                    MeetingUrl = appointment.TourInfo.MeetingUrl,
                    Platform = appointment.TourInfo.Platform.ToString(),
                    IsVirtual = appointment.TourInfo.IsVirtual,
                    AccessInstructions = appointment.TourInfo.AccessInstructions
                } : null
            };

            return new AppointmentResult(true, appointmentDto);
        }
    }
}