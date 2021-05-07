using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DatabaseFamilies.Models
{
    public class Adult:Person
    {
        [Key]
        [JsonPropertyName("adultId")]
        public override int Id { get; set; }
        [Required]
        [JsonPropertyName("firstName")]
        public override string FirstName { get; set; }
        [Required]
        [JsonPropertyName("lastName")]
        public override string LastName { get; set; }
        [Required]
        [JsonPropertyName("hairColor")]
        public override string HairColor { get; set; }
        [Required]
        [JsonPropertyName("age")]
        public override int Age { get; set; }
        [JsonPropertyName("weight")]
        public override float Weight { get; set; }
        [JsonPropertyName("height")]
        public override int Height { get; set; }
        [Required]
        [JsonPropertyName("sex")]
        public override string Sex { get; set; }
        [JsonPropertyName("jobTitle")]
        public Job JobTitle { get; set; }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}