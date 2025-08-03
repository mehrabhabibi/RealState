using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RealState.Domain.Entities.VirtualMeeting;
using RealState.Domain.Interfaces;

namespace RealState.Application.Services
{
    public class GoogleMeetStrategy : IVirtualMeetingStrategy
    {
        private readonly HttpClient _httpClient;
        private readonly GoogleSettings _settings;
        private readonly ILogger<GoogleMeetStrategy> _logger;
        private string _cachedToken;
        private DateTime _tokenExpiry;

        public GoogleMeetStrategy(
            HttpClient httpClient,
            IOptions<GoogleSettings> settings,
            ILogger<GoogleMeetStrategy> logger)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
            _logger = logger;
        }

        public Task<bool> CancelMeetingAsync(string meetingId)
        {
            throw new NotImplementedException();
        }

        public async Task<MeetingResult> CreateMeetingAsync(MeetingRequest request)
        {
            try
            {
                var token = await GetAccessTokenAsync();
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var googleRequest = new
                {
                    summary = request.Title,
                    description = request.Description,
                    start = new { dateTime = request.StartTime.ToString("o") },
                    end = new { dateTime = request.EndTime.ToString("o") },
                    conferenceData = new
                    {
                        createRequest = new { requestId = Guid.NewGuid().ToString() }
                    }
                };

                var response = await _httpClient.PostAsJsonAsync(
                    "calendar/v3/calendars/primary/events?conferenceDataVersion=1",
                    googleRequest);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadFromJsonAsync<GoogleEventResponse>();
                return new MeetingResult(
                    true,
                    content.Id,
                    content.HangoutLink,
                    "Google Meet");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Google Meet creation failed");
                return new MeetingResult(false, ErrorMessage: ex.Message);
            }
        }

        public Task<string> GetJoinUrlAsync(string meetingId)
        {
            throw new NotImplementedException();
        }

        public Task<MeetingResult> UpdateMeetingAsync(string meetingId, MeetingRequest request)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GetAccessTokenAsync()
        {
            // Return cached token if still valid (Google tokens expire after 1 hour)
            if (!string.IsNullOrEmpty(_cachedToken) && DateTime.UtcNow < _tokenExpiry)
            {
                return _cachedToken;
            }

            // Google requires OAuth 2.0 with refresh token flow
            var token = await GetGoogleOAuthTokenAsync();

            _cachedToken = token;
            _tokenExpiry = DateTime.UtcNow.AddMinutes(55); // Tokens expire after 1 hour

            return token;
        }

        private async Task<string> GetGoogleOAuthTokenAsync()
        {
            try
            {
                // In production, you would use a stored refresh token
                // This is a simplified implementation
                var request = new HttpRequestMessage(HttpMethod.Post, _settings.TokenUri)
                {
                    Content = new FormUrlEncodedContent(new[]
                    {
                    new KeyValuePair<string, string>("client_id", _settings.ClientId),
                    new KeyValuePair<string, string>("client_secret", _settings.ClientSecret),
                    new KeyValuePair<string, string>("refresh_token", "YOUR_STORED_REFRESH_TOKEN"),
                    new KeyValuePair<string, string>("grant_type", "refresh_token")
                })
                };

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var tokenResponse = await response.Content.ReadFromJsonAsync<GoogleTokenResponse>();
                return tokenResponse.AccessToken;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Google OAuth token");
                throw; // Or handle gracefully
            }
        }
    }
}