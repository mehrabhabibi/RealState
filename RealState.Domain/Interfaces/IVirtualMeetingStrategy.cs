using RealState.Domain.Entities;

namespace RealState.Domain.Interfaces
{
    public interface IVirtualMeetingStrategy
    {
        Task<MeetingResult> CreateMeetingAsync(MeetingRequest request);
        Task<MeetingResult> UpdateMeetingAsync(string meetingId, MeetingRequest request);
        Task<bool> CancelMeetingAsync(string meetingId);
        Task<string> GetJoinUrlAsync(string meetingId);
    }

    public record MeetingRequest(
    DateTime StartTime,
    DateTime EndTime,
    string Title,
    string Description = null);

    public record MeetingResult(
        bool Success,
        string MeetingId = null,
        string JoinUrl = null,
        string Platform = null,
        string ErrorMessage = null);
}