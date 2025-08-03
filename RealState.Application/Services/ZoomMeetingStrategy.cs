using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RealState.Domain.DTOs.VirtualMeeting;
using RealState.Domain.Entities.virtualMeeting;
using RealState.Domain.Interfaces;

namespace RealState.Application.Services
{
    public class ZoomMeetingStrategy : IVirtualMeetingStrategy
    {
        private readonly HttpClient _httpClient;
        private readonly ZoomSettings _settings;
        private readonly ILogger<ZoomMeetingStrategy> _logger;

        private string _cachedToken;
        private DateTime _tokenExpiry;

        public ZoomMeetingStrategy(
            HttpClient httpClient,
            IOptions<ZoomSettings> settings,
            ILogger<ZoomMeetingStrategy> logger)
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

                var zoomRequest = new
                {
                    topic = request.Title,
                    type = 2,
                    start_time = request.StartTime.ToString("yyyy-MM-ddTHH:mm:ss"),
                    duration = (int)(request.EndTime - request.StartTime).TotalMinutes,
                    settings = new
                    {
                        host_video = true,
                        participant_video = true
                    }
                };

                var response = await _httpClient.PostAsJsonAsync("users/me/meetings", zoomRequest);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadFromJsonAsync<ZoomMeetingResponse>();
                return new MeetingResult(
                    true,
                    content.Id.ToString(),
                    content.JoinUrl,
                    "Zoom");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Zoom meeting creation failed");
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
            // Return cached token if still valid
            if (!string.IsNullOrEmpty(_cachedToken) && DateTime.UtcNow < _tokenExpiry)
            {
                return _cachedToken;
            }

            // Zoom requires JWT token generation (for server-to-server apps)
            var token = GenerateZoomJwtToken();

            // For OAuth flow (if using user-level auth):
            // token = await GetZoomOAuthTokenAsync();

            _cachedToken = token;
            _tokenExpiry = DateTime.UtcNow.AddMinutes(50); // Tokens expire after 1 hour

            return token;
        }

        private string GenerateZoomJwtToken()
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_settings.ClientSecret));

            var credentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _settings.ClientId,
                expires: DateTime.UtcNow.AddMinutes(50),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Alternative OAuth implementation (if needed)
        private async Task<string> GetZoomOAuthTokenAsync()
        {
            var authBytes = Encoding.UTF8.GetBytes($"{_settings.ClientId}:{_settings.ClientSecret}");
            var authHeader = Convert.ToBase64String(authBytes);

            var request = new HttpRequestMessage(HttpMethod.Post, "https://zoom.us/oauth/token")
            {
                Content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("grant_type", "account_credentials"),
                new KeyValuePair<string, string>("account_id", _settings.AccountId)
            })
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authHeader);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<ZoomTokenResponseDto>();
            return content.AccessToken;
        }
    }

}