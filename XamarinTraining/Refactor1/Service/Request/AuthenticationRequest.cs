using Newtonsoft.Json;

namespace Refactor1.Service.Request
{
    public class AuthenticationRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
