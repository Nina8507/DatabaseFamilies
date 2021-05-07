using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DatabaseFamilies.Models
{
    public class Interest
    {
        [Key]
        [JsonPropertyName("interestId")]
        public int Id { get; set; }
        [StringLength(25)]
        [JsonPropertyName("interestType")]
        public string Type { get; set; }
        [StringLength(50)]
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}