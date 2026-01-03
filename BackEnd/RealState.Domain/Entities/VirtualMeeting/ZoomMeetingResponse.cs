namespace RealState.Domain.Entities.virtualMeeting
{
    public class ZoomMeetingResponse
    {
        public long Id { get; set; }
        public string JoinUrl { get; set; }
        public string StartUrl { get; set; }
        public string Password { get; set; }
        public string Topic { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public string Timezone { get; set; }
    }

    public class ZoomTokenResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
        public string Scope { get; set; }
    }

    public class ZoomSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AccountId { get; set; }
        public string JwtApiKey { get; set; }
        public string JwtApiSecret { get; set; }
    }
}