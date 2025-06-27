using System.Text.Json.Serialization;

namespace BackEnd.DTO
{
    public class UserLoginDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
