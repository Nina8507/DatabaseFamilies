using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DatabaseFamilies.Models
{
    public class User
    {
        [Key]
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [Required]
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            }); 
        }
    }
}