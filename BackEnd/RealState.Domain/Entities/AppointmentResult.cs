using RealState.Domain.DTOs.VirtualMeeting;

namespace RealState.Domain.Entities
{
    public class AppointmentResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public AppointmentDto Data { get; set; }

        public AppointmentResult (bool success, AppointmentDto data)
        {
            Success = success;
            Data = data;
        }

        public AppointmentResult(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}