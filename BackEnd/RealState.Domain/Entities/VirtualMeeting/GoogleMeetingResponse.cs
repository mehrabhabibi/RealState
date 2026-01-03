namespace RealState.Domain.Entities.VirtualMeeting
{
    public class GoogleMeetingResponse
    {
        public string Id { get; set; }
        public string HangoutLink { get; set; }
        public string HtmlLink { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public string Status { get; set; }
    }

    public class GoogleTokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public string Scope { get; set; }
    }
    public class GoogleSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ProjectId { get; set; }
        public string[] Scopes { get; set; } =
        {
        "https://www.googleapis.com/auth/calendar.events"
        };
        public string AuthUri { get; set; } = "https://accounts.google.com/o/oauth2/auth";
        public string TokenUri { get; set; } = "https://oauth2.googleapis.com/token";
    }

    public class GoogleEventResponse
    {
        public string Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string HangoutLink { get; set; }
        public EventDateTime Start { get; set; }
        public EventDateTime End { get; set; }
    }

    public class EventDateTime
    {
        public DateTime DateTime { get; set; }
        public string TimeZone { get; set; }
    }
}